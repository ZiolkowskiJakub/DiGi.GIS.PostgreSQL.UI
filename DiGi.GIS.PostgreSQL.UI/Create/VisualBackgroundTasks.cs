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

                    // ARMED for voivodeship 16, on the evidence of its own dry run of 2026-08-15 22:45. Superseded
                    // rows matched that part's building_2d reference count exactly on all twelve parts - 32 379,
                    // 25 120, 36 231, 29 990, 29 416, 22 693, 59 187, 42 367, 74 982, 31 248, 37 737, 27 257,
                    // totalling 448 607 - so every building regenerated and none was missed. Equal rather than
                    // greater also says this voivodeship held exactly one legacy row per reference.
                    // 0 references without a building, so RemoveOrphans stays off; it answers a different question
                    // - whether the building moved - and only belongs on after a repair report says so.
                    // The delete is safe by construction: a row goes only where a reference-keyed row for the same
                    // (county_id, reference) sits beside it, so no building can lose its last model.
                    // Each further round repeats this: set VoivodeshipCodes, run with DryRun on, compare the
                    // superseded count per part against that part's reference count, then arm the same scope.
                    // Cleaning a voivodeship before the next is regenerated is what keeps the storage tablespace
                    // from carrying a second copy of more than one voivodeship at a time.
                    // The name and the description are derived from DryRun rather than written beside it. They were
                    // last written by hand while the task was armed and were left saying "DryRun is off - this
                    // writes and has no undo" after it had been put back behind the flag, which is the wrong
                    // direction for a label on a row whose button deletes rows with no undo.
                    PostgreSQLBuildingModelCleanupTask postgreSQLBuildingModelCleanupTask = new(gISPostgreSQLConverterManager)
                    {
                        VoivodeshipCodes = ["16"],
                        DryRun = false,
                        RemoveOrphans = false
                    };

                    result.Add(Visual(postgreSQLBuildingModelCleanupTask,
                    postgreSQLBuildingModelCleanupTask.DryRun ? "Report superseded BuildingModels (dry run, deletes nothing)" : "Clean up superseded BuildingModels (DELETES rows)",
                    $"Reports BuildingModel rows a regeneration has already replaced, keeping the correctly keyed row beside them{(postgreSQLBuildingModelCleanupTask.RemoveOrphans ? ", and models whose building no longer exists under the part" : string.Empty)}. Scope: {(postgreSQLBuildingModelCleanupTask.VoivodeshipCodes is null ? "every voivodeship" : $"voivodeship {string.Join(' ', postgreSQLBuildingModelCleanupTask.VoivodeshipCodes)}")}. {(postgreSQLBuildingModelCleanupTask.DryRun ? "Dry run - nothing is written until DryRun is turned off" : "DryRun is OFF - this writes and has no undo")}"));
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
                    // The national regeneration (issue #2), run one voivodeship at a time. County 5 was the pilot
                    // and is done - 33 687 buildings, regenerated twice with the row count unchanged - and the
                    // three repaired parts 73482 / 76989 / 86713 hold a handful of buildings each. Every other
                    // part still holds models keyed on the Guid the model reissued on every creation, and only a
                    // regeneration turns those into rows the cleanup task can see.
                    // 16 (opolskie) was the scale test and is regenerated: 448 607 buildings across 12 parts in
                    // 1 h 32 m on 2026-08-15, no county failed, no building was lost, and the cleanup dry run
                    // afterwards accounted for every one of them. A run that finishes proves nothing on its own -
                    // county 5 modelled 65 % of its buildings and reported success when QuikGraph was missing from
                    // the host - which is why the count is read back rather than the task's own verdict trusted.
                    // The checkpoint means re-running this scope is a no-op; set VoivodeshipCodes to the next round.
                    // Then round by round in ascending code order: 02 04 06 08 10 12 14 16 18 20 22 24 26 28 30 32,
                    // each followed by the cleanup task at the same scope. Turn MaxConcurrentRequests down if the
                    // server or GUGiK starts refusing.
                    result.Add(Visual(new UIBuildingModelsFromDatabasePostTask(GISWebAPIManager)
                    {
                        VoivodeshipCodes = ["16"],
                        MaxConcurrentRequests = 8
                    },
                    "Create BuildingModels from database", "Creates BuildingModels for Building2Ds from database based on CityGML Buildings stored in database"));

                    // Scoped to the 16 (opolskie) scale test, with SampleSize 0 so every reference is read rather
                    // than a sample of 200: the gate this has to pass before the national pass widens is Missing = 0
                    // on every county, and a sample cannot say that.
                    // For the acceptance run, clear VoivodeshipCodes and put SampleSize back to 200. The seed stays
                    // 20260811 to match the 2026-08-11 baseline, but note the comparison is aggregate only: the
                    // baseline was drawn from one generator shared across counties, and the 2026-08-14 county part
                    // repair changed three counties from 10 198 / 24 260 / 51 740 references to 1 / 3 / 1, shifting
                    // the draw of every county after them. The per-county seed removes that for future runs; it
                    // cannot retrofit the baseline.
                    result.Add(Visual(new UIBuildingModelsVerificationTask(GISWebAPIManager)
                    {
                        RandomSeed = 20260811,
                        SampleSize = 0,
                        VoivodeshipCodes = ["16"]
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
