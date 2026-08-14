using DiGi.Core.Parameter.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Spatial.Classes;
using DiGi.GIS.Classes;
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
    /// <para><b>"County" here means one polygon part.</b> The county listing returns 406 references for 380 codes, because a county whose territory is disconnected is stored as one row per part. The task reads and uploads by <c>Id</c>, so each part is filled from its own <c>building_2d</c> rows; uploading by <c>Code</c> instead would let the server file every part's models under a single one, which is what left three counties reading back empty. The county code is still written onto each model as descriptive metadata.</para>
    /// <para>Because <c>building_2d</c> holds the same building under every part it was imported under, a building shared by two parts is modelled once per part. That is inherent to keying by part and is not a duplicate to suppress here - it mirrors the underlying table.</para>
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
        /// Gets or sets how many CityGML and terrain requests are allowed to be in flight at once.
        /// <para>One CityGML request per building at roughly 60 ms each makes a national pass a matter of weeks when they are issued one after another. The requests are independent, so they are issued in groups of this size. Lower it if the server or the terrain service starts refusing.</para>
        /// </summary>
        public int MaxConcurrentRequests { get; set; } = 8;

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

            HttpClient? httpClient_GUGiK = WebAPI.Create.HttpClient_GUGiK(GISWebAPIManager);
            if (httpClient_GUGiK is null)
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

                        List<GIS.Classes.Building2D> building2Ds_Referenced = building2Ds.FindAll(x => x is not null && !string.IsNullOrWhiteSpace(x.Reference));

                        // The CityGML pull is what the run is made of - one request per building, and at ~60 ms
                        // each a national pass takes weeks sequentially. The requests are independent, so they
                        // go out in bounded groups instead; the geometry that follows stays serial because it
                        // is a fraction of the cost.
                        CityGML.Classes.Building?[] buildings = new CityGML.Classes.Building?[building2Ds_Referenced.Count];
                        bool[] failures = new bool[building2Ds_Referenced.Count];

                        int maxConcurrentRequests = MaxConcurrentRequests < 1 ? 1 : MaxConcurrentRequests;

                        for (int i = 0; i < building2Ds_Referenced.Count; i += maxConcurrentRequests)
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            List<Task> tasks = [];
                            for (int j = i; j < System.Math.Min(i + maxConcurrentRequests, building2Ds_Referenced.Count); j++)
                            {
                                int index = j;

                                string requestUri_Building = new UrlBuilder(path_Building).AddParameter("reference", building2Ds_Referenced[index].Reference).AddParameter("countyid", countyId).ToString();

                                tasks.Add(Task.Run(async () =>
                                {
                                    try
                                    {
                                        PostResponse<CityGML.Classes.Building?> postResponse_Building = await DiGi.WebAPI.Query.GetAsync<CityGML.Classes.Building>(httpClient_Building, requestUri_Building, postOptions);

                                        // A 204 (no matching CityGML building) is a success with a null result; the footprint is extruded instead.
                                        buildings[index] = postResponse_Building is not null && postResponse_Building.Succeeded ? postResponse_Building.Result : null;
                                    }
                                    catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                                    {
                                        Serilog.Modify.Log(exception, "Building request failed for reference {Reference} in county {CountyId} - generating model from footprint", building2Ds_Referenced[index].Reference ?? string.Empty, countyId);
                                        failures[index] = true;
                                    }
                                }, cancellationToken));
                            }

                            await Task.WhenAll(tasks);
                        }

                        // Built with the elevation withheld, exactly as Analytical.Create.BuildingModelAsync does:
                        // a model that comes back carried its own elevations in the 3D geometry, and only the ones
                        // that fall through to an extrusion need the terrain.
                        DiGi.Analytical.Building.Classes.BuildingModel?[] buildingModels_Page = new DiGi.Analytical.Building.Classes.BuildingModel?[building2Ds_Referenced.Count];
                        List<int> indexes_Elevation = [];

                        for (int i = 0; i < building2Ds_Referenced.Count; i++)
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            // One building whose geometry the creator cannot handle used to end the whole run: the
                            // exception left the task, and BackgroundTask stores it without logging, so a county
                            // stopped mid-page with no upload and no recorded reason. A building that throws is now
                            // named and skipped, exactly as one that converts to null already was.
                            try
                            {
                                if (failures[i])
                                {
                                    // No terrain query on this path - the model is extruded at an elevation of zero rather than dropped.
                                    buildingModels_Page[i] = Analytical.Create.BuildingModel(building2Ds_Referenced[i]);
                                    continue;
                                }

                                buildingModels_Page[i] = Analytical.Create.BuildingModel(buildings[i], building2Ds_Referenced[i], double.NaN);
                                if (buildingModels_Page[i] is null)
                                {
                                    indexes_Elevation.Add(i);
                                }
                            }
                            catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                            {
                                Serilog.Modify.Log(exception, "BuildingModel could not be created for reference {Reference} in county {CountyId} - the building is not part of the upload", building2Ds_Referenced[i].Reference ?? string.Empty, countyId);
                                buildingModels_Page[i] = null;
                            }
                        }

                        if (indexes_Elevation.Count != 0)
                        {
                            List<Point2D> point2Ds = [];
                            foreach (int index in indexes_Elevation)
                            {
                                Point2D? point2D = building2Ds_Referenced[index].PolygonalFace2D?.GetInternalPoint();
                                point2Ds.Add(point2D ?? new Point2D(double.NaN, double.NaN));
                            }

                            List<Point3D>? point3Ds = await GIS.Query.ElevationsAsync(httpClient_GUGiK, point2Ds, maxConcurrentRequests);

                            // The helper drops the points it could not resolve, so the answers are matched back by
                            // coordinate rather than by position. They are the same doubles that were sent.
                            Dictionary<(double X, double Y), double> elevations = [];
                            foreach (Point3D point3D in point3Ds ?? [])
                            {
                                elevations[(point3D.X, point3D.Y)] = point3D.Z;
                            }

                            for (int i = 0; i < indexes_Elevation.Count; i++)
                            {
                                cancellationToken.ThrowIfCancellationRequested();

                                int index = indexes_Elevation[i];

                                // An unresolved point falls back to zero, the same as an unreachable service.
                                double elevation = elevations.TryGetValue((point2Ds[i].X, point2Ds[i].Y), out double elevation_Temp) ? elevation_Temp : 0;

                                // Same reasoning as the first pass: a building the creator cannot handle is named
                                // and skipped rather than taking the county down with it.
                                try
                                {
                                    buildingModels_Page[index] = Analytical.Create.BuildingModel(buildings[index], building2Ds_Referenced[index], elevation);
                                }
                                catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                                {
                                    Serilog.Modify.Log(exception, "BuildingModel could not be created at elevation {Elevation} for reference {Reference} in county {CountyId} - the building is not part of the upload", elevation, building2Ds_Referenced[index].Reference ?? string.Empty, countyId);
                                    buildingModels_Page[index] = null;
                                }
                            }
                        }

                        for (int i = 0; i < building2Ds_Referenced.Count; i++)
                        {
                            GIS.Classes.Building2D building2D = building2Ds_Referenced[i];

                            string reference = building2D.Reference!;

                            DiGi.Analytical.Building.Classes.BuildingModel? buildingModel = buildingModels_Page[i];
                            if (buildingModel is null)
                            {
                                // A null result no longer means the terrain service was unreachable - the creator extrudes at an elevation of
                                // zero in that case - so the geometry itself could not be converted. Dropping it silently would let a whole
                                // county import short, so every loss is logged.
                                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "BuildingModel could not be created for reference {Reference} in county {CountyId} - the building is not part of the upload", reference, countyId);
                                continue;
                            }

                            // A building whose CityGML geometry cannot be converted is silently extruded from
                            // its footprint instead, which loses every wall and roof shape it had and is
                            // otherwise indistinguishable from a building that never had CityGML at all.
                            // The two cases are worth telling apart in the log.
                            if (buildings[i] is CityGML.Classes.Building building && buildingModel.GetComponents<DiGi.Analytical.Building.Interfaces.IComponent>() is List<DiGi.Analytical.Building.Interfaces.IComponent> components_Created)
                            {
                                int count_Surfaces = 0;
                                foreach (CityGML.Interfaces.ISurface surface in building.Surfaces ?? [])
                                {
                                    count_Surfaces++;
                                }

                                if (count_Surfaces != 0 && components_Created.Count != count_Surfaces)
                                {
                                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "BuildingModel for reference {Reference} in county {CountyId} holds {Components} components for {Surfaces} CityGML surfaces - the 3D geometry was not carried over in full", reference, countyId, components_Created.Count, count_Surfaces);
                                }
                            }

                            // Carry the county code as metadata (parity with Building). It is descriptive only -
                            // the upload is keyed by countyId, because a code covers every polygon part of a
                            // multi-part county and would let the server file this part's models under another.
                            buildingModel.SetValue(Analytical.Enums.BuildingModelParameter.Code, administrativeAreal2DReference.Code, new SetValueSettings(true, false));
                            buildingModel.SetValue(Analytical.Enums.BuildingModelParameter.Reference, reference, new SetValueSettings(true, false));
                            buildingModels.Add(buildingModel);
                        }

                        if (buildingModels.Count != 0)
                        {
                            if (!await ExecuteAsync(buildingModels, countyId, longProgressWrapper, cancellationToken))
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

                Serilog.Modify.Log("County {Code} (id {CountyId}) ended", administrativeAreal2DReference.Code ?? string.Empty, countyId);
            }

            return true;
        }
    }
}
