using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.PostgreSQL.UI.Windows;
using DiGi.GIS.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// A terrain point repair that is scoped from the user interface: the counties and the spacing they were sampled at are asked for through <see cref="PostgreSQLTerrainPointFillGapsOptionsWindow"/> each time the task is started, and only then is the run handed to <see cref="PostgreSQLTerrainPointFillGapsTask"/>.
    /// <para>The spacing is why the dialog is worth showing at all. It is what decides which nodes count as missing, and a value finer than a county actually holds turns a repair of a few thousand points into a densification of the whole country - so the measured spacing of each county is put in front of whoever is choosing it.</para>
    /// </summary>
    public class UIPostgreSQLTerrainPointFillGapsTask : PostgreSQLTerrainPointFillGapsTask, IGISPostgreSQLUIObject
    {
        private readonly GISWebAPIManager? gISWebAPIManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIPostgreSQLTerrainPointFillGapsTask"/> class.
        /// </summary>
        /// <param name="GISWebAPIManager">The manager the elevation service client is built from.</param>
        /// <param name="GISPostgreSQLConverterManager">The GIS PostgreSQL converter manager used to read the areas and write the points.</param>
        public UIPostgreSQLTerrainPointFillGapsTask(GISWebAPIManager? GISWebAPIManager, GISPostgreSQLConverterManager? GISPostgreSQLConverterManager)
            : base(WebAPI.Create.HttpClient_GUGiK(GISWebAPIManager), GISPostgreSQLConverterManager)
        {
            gISWebAPIManager = GISWebAPIManager;
        }

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            // Asked before the dialog rather than after it: without a client the run cannot sample anything, and
            // the base task would answer that by returning false once the counties had already been chosen.
            if (httpClient is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Elevation service client could not be created - the terrain point repair cannot start");
                return false;
            }

            // The dialog is a window, and this runs on a thread pool thread, where a window cannot be created at
            // all. Without an application there is no user interface thread to move it to.
            if (System.Windows.Application.Current is not System.Windows.Application application)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "No WPF application is running - the terrain point repair options cannot be asked for");
                return false;
            }

            AdministrativeAreal2DPostgreSQLConverter? administrativeAreal2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<AdministrativeAreal2DPostgreSQLConverter>();
            if (administrativeAreal2DPostgreSQLConverter is null)
            {
                return false;
            }

            // References rather than the identifiers GetIdsAsync returns: that method does list every county row
            // - all 406 polygon parts of the 380 codes, which is exactly what the run iterates - but it carries
            // neither code nor name, and a list of 406 bare integers is not one a county can be picked from.
            // uniqueCode stays false, or a multi-part county would collapse to one part and lose the rest of its
            // territory.
            List<AdministrativeAreal2DReference>? administrativeAreal2DReferences = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync(PostgreSQL.Enums.AdministrativeArealType.County, parentId: null, uniqueCode: false, cancellationToken: cancellationToken);
            if (administrativeAreal2DReferences is null || administrativeAreal2DReferences.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Counties could not be retrieved - the terrain point repair cannot be scoped");
                return false;
            }

            List<TerrainPointDensityResult>? terrainPointDensityResults = null;
            if (gISWebAPIManager is not null)
            {
                System.Net.Http.HttpClient? httpClient_Terrain = gISWebAPIManager.CreateHttpClient<TerrainController>(nameof(TerrainController.GetDensitiesByCountyIdsAsync), out string? path_Densities);
                if (httpClient_Terrain is not null && !string.IsNullOrWhiteSpace(path_Densities))
                {
                    List<int> countyIds = [];
                    foreach (AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences)
                    {
                        countyIds.Add(administrativeAreal2DReference.Id);
                    }

                    terrainPointDensityResults = [];
                    DiGi.WebAPI.Classes.PostOptions postOptions = new() { RequestResult = true };
                    int batchSize = WebAPI.Constants.Terrain.MaximumDensityCountyCount;

                    for (int i = 0; i < countyIds.Count; i += batchSize)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        int count = Math.Min(batchSize, countyIds.Count - i);
                        List<int> countyIds_Batch = countyIds.GetRange(i, count);

                        System.Text.StringBuilder stringBuilder = new(path_Densities);
                        for (int j = 0; j < countyIds_Batch.Count; j++)
                        {
                            stringBuilder.Append(j == 0 ? "?" : "&");
                            stringBuilder.Append("countyids=").Append(countyIds_Batch[j]);
                        }

                        if (PostgreSQLTerrainPointFillGapsOptions.GridSize > 0)
                        {
                            stringBuilder.Append("&gridsize=").Append(PostgreSQLTerrainPointFillGapsOptions.GridSize.ToString(System.Globalization.CultureInfo.InvariantCulture));
                        }

                        try
                        {
                            DiGi.WebAPI.Classes.PostResponse<List<TerrainPointDensityResult>?> postResponse = await DiGi.WebAPI.Query.GetAsync<List<TerrainPointDensityResult>>(httpClient_Terrain, stringBuilder.ToString(), postOptions);
                            if (postResponse is not null && postResponse.Succeeded && postResponse.Result is List<TerrainPointDensityResult> results)
                            {
                                terrainPointDensityResults.AddRange(results);
                            }
                        }
                        catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                        {
                            Serilog.Modify.Log(exception, "Terrain point densities could not be retrieved for batch starting at index {Index}", i);
                        }
                    }
                }
            }

            // Read on this thread, shown on the user interface thread. Reading inside the callback below would
            // hold the interface still for the whole of the query.
            PostgreSQLTerrainPointFillGapsOptions? postgreSQLTerrainPointFillGapsOptions = null;

            application.Dispatcher.Invoke(() =>
            {
                PostgreSQLTerrainPointFillGapsOptionsWindow postgreSQLTerrainPointFillGapsOptionsWindow = new(PostgreSQLTerrainPointFillGapsOptions, administrativeAreal2DReferences, terrainPointDensityResults);

                if (postgreSQLTerrainPointFillGapsOptionsWindow.ShowDialog() is not bool dialogResult || !dialogResult)
                {
                    return;
                }

                postgreSQLTerrainPointFillGapsOptions = postgreSQLTerrainPointFillGapsOptionsWindow.PostgreSQLTerrainPointFillGapsOptions;
            });

            // A cancelled dialog leaves the options of an earlier run as they were - the window works on a copy -
            // and ends the run here rather than starting a national pass nobody asked for.
            if (postgreSQLTerrainPointFillGapsOptions is null)
            {
                Serilog.Modify.Log("Terrain point repair options were cancelled - nothing was sampled");
                return false;
            }

            PostgreSQLTerrainPointFillGapsOptions = postgreSQLTerrainPointFillGapsOptions;

            return await base.ExecuteAsync(progress, cancellationToken);
        }
    }
}
