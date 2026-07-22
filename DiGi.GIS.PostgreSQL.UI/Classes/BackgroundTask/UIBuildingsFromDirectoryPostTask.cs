using DiGi.CityGML.Classes;
using DiGi.Core.Parameter.Classes;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.WebAPI.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// A UI-driven post task that prompts the user to select a directory, reads CityGML city models from it, extracts <see cref="Building"/> instances, determines the county code from the file path, and uploads them to the server in batches.
    /// </summary>
    public class UIBuildingsFromDirectoryPostTask : BuildingsPostTask, IGISPostgreSQLUIObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIBuildingsFromDirectoryPostTask"/> class.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to communicate with the server.</param>
        public UIBuildingsFromDirectoryPostTask(GISWebAPIManager GISWebAPIManager)
            : base(GISWebAPIManager)
        {
        }

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            if (Values is not null)
            {
                return await base.ExecuteAsync(progress, cancellationToken);
            }

            OpenFolderDialog openFolderDialog = new();
            bool? dialogResult = openFolderDialog.ShowDialog();
            if (dialogResult == null || !dialogResult.HasValue || !dialogResult.Value)
            {
                return false;
            }

            string directory = openFolderDialog.FolderName;
            if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
            {
                return false;
            }

            Core.Classes.LongProgressWrapper? longProgressWrapper = Core.Create.LongProgressWrapper(progress);

            // Parsing a city model and uploading a batch are independent: one is CPU bound, the other
            // waits on the server. A bounded channel lets the next file be parsed while the previous
            // batch is in flight, without ever putting more than one POST on the wire.
            Channel<BuildingsBatch> channel = Channel.CreateBounded<BuildingsBatch>(new BoundedChannelOptions(1)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleReader = true,
                SingleWriter = true,
            });

            using CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            Task<bool> task_Producer = ProduceAsync(directory, channel.Writer, cancellationTokenSource.Token);

            bool result = true;

            try
            {
                await foreach (BuildingsBatch buildingsBatch in channel.Reader.ReadAllAsync(cancellationToken))
                {
                    if (!await ExecuteAsync(buildingsBatch.Buildings, buildingsBatch.Code, longProgressWrapper, cancellationToken))
                    {
                        result = false;

                        // Stop the producer before it parses another file for a run that is already lost.
                        cancellationTokenSource.Cancel();
                        break;
                    }
                }
            }
            finally
            {
                cancellationTokenSource.Cancel();

                try
                {
                    result &= await task_Producer;
                }
                catch (OperationCanceledException)
                {
                    // Expected once the consumer has stopped the walk.
                }
            }

            return result;
        }

        /// <summary>
        /// Walks the directory, parses each city model and publishes its tagged buildings to the channel.
        /// </summary>
        /// <param name="directory">The directory to walk.</param>
        /// <param name="channelWriter">The writer the parsed batches are published to.</param>
        /// <param name="cancellationToken">A token observed before each file is parsed.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the walk completed successfully; otherwise, false.</returns>
        private static async Task<bool> ProduceAsync(string directory, ChannelWriter<BuildingsBatch> channelWriter, CancellationToken cancellationToken)
        {
            Exception? exception = null;

            bool result;

            try
            {
                result = await CityGML.Query.RunAsync(directory, async (path, cityModel) =>
                {
                    IEnumerable<Building>? buildings = cityModel?.Buildings;
                    if (buildings is null || !buildings.Any())
                    {
                        return true;
                    }

                    GetValueSettings getValueSettings = new(true, false);

                    if (cityModel is null || !cityModel.TryGetValue(CityGML.Enums.CityModelParameter.Year, out short? year, getValueSettings))
                    {
                        year = null;
                    }

                    if (cityModel is null || !cityModel.TryGetValue(CityGML.Enums.CityModelParameter.LOD, out CityGML.Enums.LOD? lOD, getValueSettings))
                    {
                        lOD = null;
                    }

                    string? code = null;
                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        if (Path.GetFileNameWithoutExtension(path) is string name)
                        {
                            if (name.Contains('_'))
                            {
                                string value = name.Split("_")[0];
                                if (string.IsNullOrWhiteSpace(code) && int.TryParse(value, out _))
                                {
                                    code = value;
                                }
                            }

                            if (string.IsNullOrWhiteSpace(code) && int.TryParse(name, out _))
                            {
                                code = name;
                            }
                        }
                    }

                    SetValueSettings setValueSettings = new(true, false);

                    foreach (Building building in buildings)
                    {
                        building.SetValue(PostgreSQL.Enums.BuildingParameter.Year, year, setValueSettings);
                        building.SetValue(PostgreSQL.Enums.BuildingParameter.LOD, lOD, setValueSettings);
                        building.SetValue(PostgreSQL.Enums.BuildingParameter.Source, path, setValueSettings);

                        if (!string.IsNullOrWhiteSpace(code))
                        {
                            building.SetValue(PostgreSQL.Enums.BuildingParameter.Code, code, setValueSettings);
                        }
                    }

                    // Blocks once the channel is full, so at most one parsed city model is held ahead
                    // of the upload - the parse runs during the previous POST, not unboundedly ahead.
                    await channelWriter.WriteAsync(new BuildingsBatch(buildings, code), cancellationToken);

                    return true;
                }, cancellationToken);
            }
            catch (Exception exception_Temp)
            {
                exception = exception_Temp;
                result = false;
            }

            channelWriter.Complete(exception);

            return result;
        }

        /// <summary>
        /// A parsed city model's buildings together with the county code derived from its file path.
        /// </summary>
        private sealed class BuildingsBatch
        {
            private readonly IEnumerable<Building> buildings;
            private readonly string? code;

            /// <summary>
            /// Initializes a new instance of the <see cref="BuildingsBatch"/> class.
            /// </summary>
            /// <param name="buildings">The buildings parsed from a single city model.</param>
            /// <param name="code">The county code derived from the source file path, or null when it could not be determined.</param>
            public BuildingsBatch(IEnumerable<Building> buildings, string? code)
            {
                this.buildings = buildings;
                this.code = code;
            }

            /// <summary>
            /// Gets the buildings parsed from a single city model.
            /// </summary>
            public IEnumerable<Building> Buildings => buildings;

            /// <summary>
            /// Gets the county code derived from the source file path.
            /// </summary>
            public string? Code => code;
        }
    }
}
