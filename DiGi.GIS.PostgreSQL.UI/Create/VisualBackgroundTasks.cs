using DiGi.Core;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.Enums;
using DiGi.GIS.PostgreSQL.UI.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using DiGi.GIS.WebAPI.Classes;
using DiGi.UI.WPF.Interfaces;
using System.Collections.Generic;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Create
    {
        /// <summary>
        /// Creates and returns a sorted list of visual background tasks based on the specified operation mode and available managers.
        /// </summary>
        /// <param name="gISPostgreSQLConverterManager">The manager responsible for PostgreSQL conversion operations.</param>
        /// <param name="GISWebAPIManager">The manager responsible for interacting with the PostgreSQL Web API.</param>
        /// <param name="mode">The operation mode (Server, Client, or both) that determines which tasks are instantiated.</param>
        /// <returns>A list of <see cref="IVisualBackgroundTask"/> objects sorted by name, or null if not applicable.</returns>
        public static List<IVisualBackgroundTask>? VisualBackgroundTasks(GISPostgreSQLConverterManager? gISPostgreSQLConverterManager, GISWebAPIManager? GISWebAPIManager, Mode mode)
        {
            List<IVisualBackgroundTask> result = [];

            // A task keeps the exception that stopped it in a property and logs nothing, so a failed run left
            // no record of why - the reason existed only as a tooltip on the row. Reporting it here, on the
            // event the base class already raises, covers every task built below and keeps the logging in this
            // project: DiGi.UI.WPF has no logging dependency and does not need one to get this.
            IVisualBackgroundTask Visual(Core.Interfaces.IBackgroundTask backgroundTask, string name, string description)
            {
                backgroundTask.Stopped += (sender, args) =>
                {
                    if (backgroundTask.Exception is System.Exception exception)
                    {
                        Serilog.Modify.Log(exception, "{Name} failed", name);
                    }
                };

                return DiGi.UI.WPF.Create.VisualBackgroundTask(backgroundTask, name, description);
            }

            if (mode == Mode.Server || mode == Mode.ServerAndCient)
            {
                if (gISPostgreSQLConverterManager is not null)
                {
                    result.Add(Visual(new PostgreSQLAdministrativeAreal2DCreateDatabaseTask(gISPostgreSQLConverterManager), "Create main database", "Creates main database for AdministrativeAreal2D and Biulding2D objects"));
                    result.Add(Visual(new PostgreSQLOrtoDatasCreateDatabaseTask(gISPostgreSQLConverterManager), "Create storage database", "Creates storage database for OrtoDatas objects"));
                    result.Add(Visual(new OrtoDatasTask(GISWebAPIManager, gISPostgreSQLConverterManager), "Bypass upload OrtoDatas from database", "Upload OrtoDatas from database. Direct update of OrtoDatas by bypassing the GIS WebAPI HTTP post."));

                    PostgreSQLBuildingDataUpdateTask postgreSQLBuildingDataUpdateTask = new(gISPostgreSQLConverterManager);
                    postgreSQLBuildingDataUpdateTask.Starting += (sender, args) =>
                    {
                        if (sender is not PostgreSQLBuildingDataUpdateTask postgreSQLBuildingDataUpdateTask_Temp)
                        {
                            return;
                        }

                        Dictionary<string, BuildingDataUpdateType> dictionary = [];
                        foreach (BuildingDataUpdateType buildingDataUpdateType in System.Enum.GetValues<BuildingDataUpdateType>())
                        {
                            dictionary[buildingDataUpdateType.Description() ?? buildingDataUpdateType.ToString()] = buildingDataUpdateType;
                        }

                        DiGi.UI.WPF.Windows.ListBoxWindow listBoxWindow = new("Update building data");
                        listBoxWindow.SetItems(dictionary.Keys);

                        if (listBoxWindow.ShowDialog() is not bool dialogResult || !dialogResult || listBoxWindow.GetItems<string>() is not List<string> texts)
                        {
                            postgreSQLBuildingDataUpdateTask_Temp.PostgreSQLBuildingDataUpdateOptions.BuildingDataUpdateTypes = [];
                            return;
                        }

                        List<BuildingDataUpdateType> buildingDataUpdateTypes = [];
                        foreach (string text in texts)
                        {
                            buildingDataUpdateTypes.Add(dictionary[text]);
                        }

                        postgreSQLBuildingDataUpdateTask_Temp.PostgreSQLBuildingDataUpdateOptions.BuildingDataUpdateTypes = buildingDataUpdateTypes;
                    };

                    result.Add(Visual(postgreSQLBuildingDataUpdateTask, "Update building data", "Update building data base on Buidling2D and other data sources (database, OrtoDatas etc.)"));

                    Building2DPostgreSQLConverter? building2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<Building2DPostgreSQLConverter>();
                    if (building2DPostgreSQLConverter is not null)
                    {
                        result.Add(Visual(new PostgreSQLBuilding2DRefreshTask(building2DPostgreSQLConverter), "Refresh Building2Ds", "Refreshes Building2D table in database"));
                        result.Add(Visual(new PostgreSQLBuilding2DCreateTableTask(building2DPostgreSQLConverter), "Create Building2D table", "Creates or updates (table indexes etc.) Building2D table in database"));
                    }

                    AdministrativeAreal2DPostgreSQLConverter? administrativeAreal2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<AdministrativeAreal2DPostgreSQLConverter>();
                    if (administrativeAreal2DPostgreSQLConverter is not null)
                    {
                        result.Add(Visual(new PostgreSQLAdministrativeAreal2DRefreshTask(administrativeAreal2DPostgreSQLConverter), "Refresh AdministrativeAreal2Ds", "Refreshes AdministrativeAreal2D table in database"));
                        result.Add(Visual(new PostgreSQLAdministrativeAreal2DCreateTableTask(administrativeAreal2DPostgreSQLConverter), "Create AdministrativeAreal2D table", "Creates or updates (table indexes etc.) AdministrativeAreal2D table in database"));
                    }

                    result.Add(Visual(new PostgreSQLOrtoDatasRefreshTask(gISPostgreSQLConverterManager)
                    {
                        PostgreSQLOrtoDatasRefreshOptions = new PostgreSQLOrtoDatasRefreshOptions()
                        {
                            OverrideExistsing = false,
                            UpdateSubdivisionIds = true
                        }
                    },
                    "Refresh OrtoDatas", "Refreshes OrtoDatas table in database"));

                    result.Add(Visual(new PostgreSQLUpdateOccupancyTask(gISPostgreSQLConverterManager), "Update occupancy from database", "Update occupancy for Building2Ds and AdministrativeAreal2Ds based on data in database"));

                    // Disarmed again. 2212, 2405 and 2612 were repaired on 2026-08-14: 86 196 copies deleted,
                    // and the parts read back 1/44 809, 42 585/3 and 51 739/1 with their unions intact, so no
                    // building lost its last row. Re-running now is a no-op - a reference held by a single part
                    // is skipped - but the delete has no undo, so it goes back behind DryRun.
                    // Scoped to the three codes whose parts both held buildings; clear Codes to sweep all 18
                    // multi-part codes, of which 15 are still latent and become live once an import lands on a
                    // currently-empty part.
                    result.Add(Visual(new PostgreSQLBuilding2DCountyPartRepairTask(gISPostgreSQLConverterManager)
                    {
                        Codes = ["2212", "2405", "2612"],
                        DryRun = true
                    },
                    "Report Building2D county part duplicates", "Reports Building2Ds held under more than one polygon part of the same county and which part each belongs to. Dry run - deletes nothing until DryRun is turned off"));

                    // Back behind DryRun for one run: RemoveOrphans is on for the first time and has never executed.
                    // The superseded half is proven - county 5 deleted 33 687 rows on 2026-08-14 and a following
                    // regeneration left the count unchanged - but orphan removal reaches across to a different part
                    // and deletes a model whose building is gone, so it gets a report before it gets to write.
                    // All six parts of the three repaired codes: the small ones hold the moved buildings and should
                    // report nothing once regenerated, the large ones hold the 1 + 6 + 1 model rows left behind.
                    // Expected: 0 superseded everywhere, 8 references without a building.
                    result.Add(Visual(new PostgreSQLBuildingModelCleanupTask(gISPostgreSQLConverterManager)
                    {
                        CountyIds = [73482, 73485, 76984, 76989, 86698, 86713],
                        DryRun = true,
                        RemoveOrphans = true
                    },
                    "Clean up superseded BuildingModels", "Reports BuildingModel rows a regeneration has already replaced, and models whose building no longer exists under the part. Dry run - deletes nothing until DryRun is turned off"));
                }
            }

            if (mode == Mode.Client || mode == Mode.ServerAndCient)
            {
                if (GISWebAPIManager is not null)
                {
                    result.Add(Visual(new UIUpdateFromFilePostTask(GISWebAPIManager), "Upload Areal2Ds from BDOT10k file", "Upload AdministrativeAreal2Ds and/or Building2Ds from BDOT10k *.zip file"));

                    result.Add(Visual(new UIAdministrativeAreal2DFromFilePostTask(GISWebAPIManager), "Upload AdministrativeAreal2Ds from file", "Uploads AdministrativeAreal2Ds from file to the server"));
                    result.Add(Visual(new UIEPWFileFromFilePostTask(GISWebAPIManager), "Upload EPWFile from file", "Uploads EPWFile from selected file or directory to the server"));
                    result.Add(Visual(new UIBuilding2DsFromFilePostTask(GISWebAPIManager), "Upload Building2Ds from file", "Uploads Building2Ds from file to the server"));
                    result.Add(Visual(new OrtoDatasFromDatabasePostTask(GISWebAPIManager), "Upload OrtoDatas from database", "Uploads OrtoDatas from Building2D information stored in the database to the server"));
                    result.Add(Visual(new UIYearBuiltDatasFromFilePostTask(GISWebAPIManager), "Upload YearBuiltDatas from file", "Uploads YearBuiltDatas from file to the server"));
                    result.Add(Visual(new UIOccupancyDatasFromFilePostTask(GISWebAPIManager), "Upload OccupancyDatas from file", "Uploads OccupancyDatas (Building2D and AdministrativeAreal2D) from file to the server"));

                    result.Add(Visual(new UIBuildingsFromDirectoryPostTask(GISWebAPIManager), "Create CityGML Buildings from directory", "Creates Buildings for Building2Ds from database based on CityGML files saved in directory"));
                    result.Add(Visual(new UIBuildingModelsFromDirectoryPostTask(GISWebAPIManager), "Create BuildingModels from directory", "Creates BuildingModels for Building2Ds from database based on CityGML files saved in directory"));
                    // The five buildings the county part repair moved to a part holding no models: 1 under 73482,
                    // 3 under 76989, 1 under 86713. Their models still sit under the sibling part they came from
                    // and are removed as orphans by the cleanup task, which is scoped to all six parts.
                    // County 5 was the pilot and is done - 33 687 buildings, regenerated twice with the row count
                    // unchanged. Clear CountyIds for a national pass, and turn MaxConcurrentRequests down if the
                    // server or GUGiK starts refusing.
                    result.Add(Visual(new UIBuildingModelsFromDatabasePostTask(GISWebAPIManager)
                    {
                        CountyIds = [73482, 76989, 86713],
                        MaxConcurrentRequests = 8
                    },
                    "Create BuildingModels from database", "Creates BuildingModels for Building2Ds from database based on CityGML Buildings stored in database"));

                    // The seed and the sample size are what make two runs comparable - they match the 2026-08-11 baseline
                    // and should not be changed without restating the baseline they are being compared against.
                    result.Add(Visual(new UIBuildingModelsVerificationTask(GISWebAPIManager)
                    {
                        RandomSeed = 20260811,
                        SampleSize = 200
                    },
                    "Verify BuildingModels from database", "Reads BuildingModels stored in database and reports completeness and space enclosure. Read only - nothing is uploaded"));


                    result.Add(Visual(new UIOrtoDatasFromFilePostTask(GISWebAPIManager)
                    {
                        SerializableObjectsPostOptions = new SerializableObjectsPostOptions()
                        {
                            BatchMemorySize = 10 * 1024 * 1024, // 10 MB
                        }
                    },
                    "Upload OrtoDatas from file", "Uploads OrtoDatas from file to the server"));
                }
            }

            result.Sort((x, y) => x.Name!.CompareTo(y.Name));

            return result;
        }
    }
}
