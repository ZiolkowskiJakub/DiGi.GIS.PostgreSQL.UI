using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.Enums;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// A post task that generates <see cref="DiGi.Analytical.Building.Classes.BuildingModel"/> instances entirely from data already held on the server - the CityGML <see cref="CityGML.Classes.Building"/> records stored in the database are used instead of CityGML archives read from a local directory.
    /// <para>For every county in scope the task pages through the county's <see cref="Building2DReference"/> records and, per page, downloads the <see cref="GIS.Classes.Building2D"/> data, so a whole county's buildings are never held in memory at once.</para>
    /// <para>Each <see cref="GIS.Classes.Building2D"/> is then processed individually: its single best ranked CityGML <see cref="CityGML.Classes.Building"/> is pulled by reference through <see cref="BuildingController.GetItemByReferenceAsync"/> and refined into storeys by the matching <c>Analytical.Create.BuildingModel</c> overload. A 2D building whose reference has no stored CityGML building, no reference at all, or whose pull fails is modelled from an extruded footprint instead.</para>
    /// </summary>
    public class UIBuildingModelsFromDatabasePostTask : BuildingModelsPostTask, IGISPostgreSQLUIObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIBuildingModelsFromDatabasePostTask"/> class.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to communicate with the server.</param>
        public UIBuildingModelsFromDatabasePostTask(GISWebAPIManager GISWebAPIManager)
            : base(GISWebAPIManager)
        {
        }

        /// <summary>
        /// Gets or sets the identifiers of the counties to be processed. When null every county held on the server is processed.
        /// </summary>
        public IEnumerable<int>? CountyIds { get; set; } = null;

        /// <summary>
        /// Gets or sets the number of <see cref="Building2DReference"/> items requested per page while downloading a county's buildings.
        /// </summary>
        public int PageSize { get; set; } = 250;

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            if (Values is not null)
            {
                return await base.ExecuteAsync(progress, cancellationToken);
            }

            HttpClient? httpClient_AdministrativeAreal2D = GISWebAPIManager.CreateHttpClient<AdministrativeAreal2DController>(nameof(AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync), out string? path_AdministrativeAreal2D);
            if (httpClient_AdministrativeAreal2D is null || string.IsNullOrWhiteSpace(path_AdministrativeAreal2D))
            {
                return false;
            }

            // The endpoint is a HttpGet action and its administrativearealtype parameter is not nullable - omitting it binds to Country, not County.
            string requestUri_AdministrativeAreal2D = new UrlBuilder(path_AdministrativeAreal2D).AddParameter("administrativearealtype", (int)AdministrativeArealType.County).ToString();

            PostOptions postOptions = new() { RequestResult = true };

            PostResponse<List<AdministrativeAreal2DReference>?> postResponse_AdministrativeAreal2DReferences = await DiGi.WebAPI.Query.GetAsync<List<AdministrativeAreal2DReference>>(httpClient_AdministrativeAreal2D, requestUri_AdministrativeAreal2D, postOptions);
            if (postResponse_AdministrativeAreal2DReferences is null || !postResponse_AdministrativeAreal2DReferences.Succeeded || postResponse_AdministrativeAreal2DReferences.Result is not List<AdministrativeAreal2DReference> administrativeAreal2DReferences)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "County references could not be retrieved");
                return false;
            }

            HashSet<int>? countyIds = null;
            if (CountyIds is not null)
            {
                countyIds = [.. CountyIds];
                if (countyIds.Count == 0)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "CountyIds is empty - nothing to process");
                    return false;
                }
            }

            HttpClient? httpClient_Building2DReferences = GISWebAPIManager.CreateHttpClient<Building2DController>(nameof(Building2DController.GetBuilding2DReferencesByPagingParameterAsync), out string? path_Building2DReferences);
            if (httpClient_Building2DReferences is null || string.IsNullOrWhiteSpace(path_Building2DReferences))
            {
                return false;
            }

            HttpClient? httpClient_Building2D = GISWebAPIManager.CreateHttpClient<Building2DController>(nameof(Building2DController.GetItemsByBuilding2DReferencesAsync), out string? path_Building2D);
            if (httpClient_Building2D is null || string.IsNullOrWhiteSpace(path_Building2D))
            {
                return false;
            }

            HttpClient? httpClient_Building = GISWebAPIManager.CreateHttpClient<BuildingController>(nameof(BuildingController.GetItemByReferenceAsync), out string? path_Building);
            if (httpClient_Building is null || string.IsNullOrWhiteSpace(path_Building))
            {
                return false;
            }

            string requestUri_Building2DReferences = new UrlBuilder(path_Building2DReferences).ToString();
            string requestUri_Building2D = new UrlBuilder(path_Building2D).ToString();

            Core.Classes.LongProgressWrapper? longProgressWrapper = Core.Create.LongProgressWrapper(progress);

            int pageSize = PageSize < 1 ? 1 : PageSize;

            foreach (AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Id identifies the county itself - CountryId/VoivodeshipId/CountyId are the parent chain and are not the value building_2d.county_id holds.
                int countyId = administrativeAreal2DReference.Id;
                if (countyId < 0)
                {
                    continue;
                }

                if (countyIds is not null && !countyIds.Contains(countyId))
                {
                    continue;
                }

                Serilog.Modify.Log("County {Code} (id {CountyId}) started", administrativeAreal2DReference.Code ?? string.Empty, countyId);

                string? cursor = null;

                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    List<Building2DReference>? building2DReferences = null;

                    Building2DReferencesByPagingParameter building2DReferencesByPagingParameter = new() { CountyId = countyId, PageSize = pageSize, Cursor = cursor };

                    try
                    {
                        using CancellationTokenSource cancellationTokenSource = new(postOptions.Delay);

                        using (HttpContent? httpContent = await WebAPI.Create.HttpContent(Core.Convert.ToSystem_String(building2DReferencesByPagingParameter) ?? string.Empty, cancellationTokenSource.Token).ConfigureAwait(false))
                        {
                            if (httpContent is null)
                            {
                                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Paging parameter content could not be created");
                                return false;
                            }

                            PostResponse<List<Building2DReference>?> postResponse_Building2DReferences = await DiGi.WebAPI.Modify.PostAsync<List<Building2DReference>>(httpClient_Building2DReferences, requestUri_Building2DReferences, httpContent, postOptions);
                            if (postResponse_Building2DReferences is null || !postResponse_Building2DReferences.Succeeded)
                            {
                                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building2DReferences page could not be retrieved for county {CountyId}", countyId);
                                return false;
                            }

                            building2DReferences = postResponse_Building2DReferences.Result;
                        }
                    }
                    // A cancellation raised by the caller's token is left to propagate; anything else is a genuine request failure.
                    catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                    {
                        Serilog.Modify.Log(exception, "Building2DReferences page request failed for county {CountyId}", countyId);
                        return false;
                    }

                    if (building2DReferences is null || building2DReferences.Count == 0)
                    {
                        break;
                    }

                    List<GIS.Classes.Building2D>? building2Ds = null;

                    try
                    {
                        using CancellationTokenSource cancellationTokenSource = new(postOptions.Delay);

                        using HttpContent? httpContent = await WebAPI.Create.HttpContent(building2DReferences, cancellationTokenSource.Token).ConfigureAwait(false);

                        if (httpContent is null)
                        {
                            Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building2DReferences content could not be created");
                            return false;
                        }

                        PostResponse<List<GIS.Classes.Building2D>?> postResponse_Building2D = await DiGi.WebAPI.Modify.PostAsync<List<GIS.Classes.Building2D>>(httpClient_Building2D, requestUri_Building2D, httpContent, postOptions);
                        if (postResponse_Building2D is null || !postResponse_Building2D.Succeeded)
                        {
                            Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building2Ds could not be retrieved for county {CountyId}", countyId);
                            return false;
                        }

                        building2Ds = postResponse_Building2D.Result;
                    }
                    catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                    {
                        Serilog.Modify.Log(exception, "Building2Ds request failed for county {CountyId}", countyId);
                        return false;
                    }

                    if (building2Ds is not null && building2Ds.Count != 0)
                    {
                        List<DiGi.Analytical.Building.Classes.BuildingModel> buildingModels = [];

                        foreach (GIS.Classes.Building2D building2D in building2Ds)
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            if (building2D is null)
                            {
                                continue;
                            }

                            DiGi.Analytical.Building.Classes.BuildingModel? buildingModel;

                            string? reference = building2D.Reference;
                            if (string.IsNullOrWhiteSpace(reference))
                            {
                                // No reference to look up - extrude the model from the footprint.
                                // buildingModel = Analytical.Create.BuildingModel(building2D);
                                continue;
                            }

                            string requestUri_Building = new UrlBuilder(path_Building).AddParameter("reference", reference).AddParameter("countyid", countyId).ToString();

                            try
                            {
                                PostResponse<CityGML.Classes.Building?> postResponse_Building = await DiGi.WebAPI.Query.GetAsync<CityGML.Classes.Building>(httpClient_Building, requestUri_Building, postOptions);

                                // A 204 (no matching CityGML building) is a success with a null result; the combined method then extrudes the footprint itself.
                                CityGML.Classes.Building? building = postResponse_Building is not null && postResponse_Building.Succeeded ? postResponse_Building.Result : null;

                                buildingModel = Analytical.Create.BuildingModel(building, building2D);
                            }
                            catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                            {
                                Serilog.Modify.Log(exception, "Building request failed for reference {Reference} in county {CountyId} - generating model from footprint", reference, countyId);

                                buildingModel = Analytical.Create.BuildingModel(building2D);
                            }

                            if (buildingModel is not null)
                            {
                                // Carry the county code as metadata (parity with Building); the server resolves the code passed on the upload to a county id.
                                buildingModel.SetValue(Analytical.Enums.BuildingModelParameter.Code, administrativeAreal2DReference.Code, new Core.Parameter.Classes.SetValueSettings(true, false));
                                buildingModels.Add(buildingModel);
                            }
                        }

                        if (buildingModels.Count != 0)
                        {
                            if (!await ExecuteAsync(buildingModels, administrativeAreal2DReference.Code, longProgressWrapper, cancellationToken))
                            {
                                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "BuildingModels could not be uploaded for county {CountyId}", countyId);
                                return false;
                            }
                        }
                    }

                    if (building2DReferences.Count < pageSize)
                    {
                        break;
                    }

                    cursor = building2DReferences[building2DReferences.Count - 1].Reference;
                    if (string.IsNullOrWhiteSpace(cursor))
                    {
                        break;
                    }
                }
            }

            return true;
        }
    }
}
