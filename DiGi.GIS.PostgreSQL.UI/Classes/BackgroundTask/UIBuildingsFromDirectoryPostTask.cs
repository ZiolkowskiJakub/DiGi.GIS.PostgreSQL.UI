using DiGi.CityGML.Classes;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.WebAPI.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// A UI-driven post task that prompts the user to select a directory, reads CityGML city models from it, extracts <see cref="DiGi.CityGML.Classes.Building"/> instances, determines the county code from the file path, and uploads them to the server in batches.
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

            bool result = true;

            await CityGML.Query.RunAsync(directory, async (path, cityModel) =>
            {
                if (!result)
                {
                    return;
                }

                cancellationToken.ThrowIfCancellationRequested();

                IEnumerable<Building>? buildings = cityModel?.Buildings;
                if (buildings is null || !buildings.Any())
                {
                    return;
                }

                string? code = null;
                if (!string.IsNullOrWhiteSpace(path))
                {
                    if (Path.GetFileNameWithoutExtension(path) is string name)
                    {
                        if (name.Contains("_"))
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

                if (!await ExecuteAsync(buildings, code, longProgressWrapper, cancellationToken))
                {
                    result = false;
                }
            });

            return result;
        }
    }
}
