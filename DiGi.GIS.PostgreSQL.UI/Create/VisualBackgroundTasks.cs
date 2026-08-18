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

                    // Scoped from a dialog rather than from defaults written here: the cost of this run is the
                    // square of the grid size over the area chosen, from an afternoon over one county to
                    // hundreds of millions of requests over the country, so it is asked for at the moment the
                    // task is started.
                    result.Add(Visual(new UIPostgreSQLTerrainPointCreateTableTask(GISWebAPIManager, gISPostgreSQLConverterManager), "Create TerrainPoint table", "Creates the TerrainPoint table and fills it by sampling terrain elevations onto a shared grid. Grid size, override existing and the counties are asked for when the task is started"));

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

                    // TODO [BuildingModelRowIdentity]: temporary registration for the one-off unique_id migration
                    // of issue ZiolkowskiJakub/DiGi.GIS.PostgreSQL#5. Remove it with the task itself once every
                    // deployed database has run it and reports zero pending rows nationally.
                    // It has to be run against a database BEFORE a DiGi.GIS.WebAPI build converting models with
                    // their own identifier is deployed against it. In the other order the first upload matches
                    // no row and inserts a second model for every building, which is the duplication issue #1
                    // removed. This app and the WebAPI host are deployed separately, which is what makes that
                    // order achievable from one commit: install this, run the task, then deploy the WebAPI.
                    // Armed, unlike the cleanup task below. It destroys nothing - the value it overwrites is the
                    // building's reference, which the row still carries in its own reference column - so a
                    // migrated row can be read back either way round. Turn DryRun on for a pass that only
                    // reports the blocked and missing counts.
                    // The name and the description are derived from DryRun rather than written beside it, for
                    // the reason recorded above the cleanup task registration.
                    PostgreSQLBuildingModelUniqueIdMigrationTask postgreSQLBuildingModelUniqueIdMigrationTask = new(gISPostgreSQLConverterManager)
                    {
                        PostgreSQLBuildingModelUniqueIdMigrationOptions = new PostgreSQLBuildingModelUniqueIdMigrationOptions()
                        {
                            DryRun = false
                        }
                    };

                    // DiGi.GIS.PostgreSQL carries no logging dependency, so the task keeps what every county
                    // part reported and the totals are logged from here, the same way this file already
                    // reports the exception a failed task would otherwise have kept to itself.
                    postgreSQLBuildingModelUniqueIdMigrationTask.Stopped += (sender, args) =>
                    {
                        if (sender is not PostgreSQLBuildingModelUniqueIdMigrationTask postgreSQLBuildingModelUniqueIdMigrationTask_Temp)
                        {
                            return;
                        }

                        long total = 0;
                        long done = 0;
                        long pending = 0;
                        long blocked = 0;
                        long missing = 0;

                        List<int> countyIds_Unresolved = [];

                        foreach (UniqueIdMigrationResult uniqueIdMigrationResult in postgreSQLBuildingModelUniqueIdMigrationTask_Temp.UniqueIdMigrationResults)
                        {
                            total += uniqueIdMigrationResult.Total;
                            done += uniqueIdMigrationResult.Done;
                            pending += uniqueIdMigrationResult.Pending;
                            blocked += uniqueIdMigrationResult.Blocked;
                            missing += uniqueIdMigrationResult.Missing;

                            if (uniqueIdMigrationResult.Blocked != 0 || uniqueIdMigrationResult.Missing != 0)
                            {
                                countyIds_Unresolved.Add(uniqueIdMigrationResult.CountyId);
                            }
                        }

                        // The counts were taken before each part was written, so on an armed run Pending is what
                        // the migration then moved and on a dry run it is what it would have moved.
                        Serilog.Modify.Log("{Name} ended. DryRun: {DryRun}. County rows visited: {Count}. Rows {Total}, already keyed on the model {Done}, pending before the run {Pending}, blocked {Blocked}, without an identifier {Missing}", nameof(PostgreSQLBuildingModelUniqueIdMigrationTask), postgreSQLBuildingModelUniqueIdMigrationTask_Temp.PostgreSQLBuildingModelUniqueIdMigrationOptions.DryRun, postgreSQLBuildingModelUniqueIdMigrationTask_Temp.UniqueIdMigrationResults.Count, total, done, pending, blocked, missing);

                        if (countyIds_Unresolved.Count != 0)
                        {
                            // These are the rows a converter emitting the model's own identifier cannot match,
                            // so the building gets a second model on its next upload rather than a replacement.
                            Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "County rows the migration could not fully resolve: {CountyIds}", string.Join(", ", countyIds_Unresolved));
                        }
                    };

                    result.Add(Visual(postgreSQLBuildingModelUniqueIdMigrationTask,
                    postgreSQLBuildingModelUniqueIdMigrationTask.PostgreSQLBuildingModelUniqueIdMigrationOptions.DryRun ? "Report BuildingModel unique_id migration (dry run, writes nothing)" : "Migrate BuildingModel unique_id (WRITES rows)",
                    $"Moves each stored BuildingModel's own identifier into the unique_id column of the row holding it, so building_model follows the same row identity as every other referenced object table. Must be run before a WebAPI build converting models with their own identifier is deployed. Scope: {(postgreSQLBuildingModelUniqueIdMigrationTask.PostgreSQLBuildingModelUniqueIdMigrationOptions.VoivodeshipCodes is null ? "every voivodeship" : $"voivodeship {string.Join(' ', postgreSQLBuildingModelUniqueIdMigrationTask.PostgreSQLBuildingModelUniqueIdMigrationOptions.VoivodeshipCodes)}")}. {(postgreSQLBuildingModelUniqueIdMigrationTask.PostgreSQLBuildingModelUniqueIdMigrationOptions.DryRun ? "Dry run - nothing is written until DryRun is turned off" : "DryRun is OFF - this writes, though it overwrites only a value the row also holds in its reference column")}"));

                    // TODO [CountyPartAssignment]: temporary registration for the one-off county part repair of
                    // issue #1. Remove it with PostgreSQLBuilding2DCountyPartRepairTask, once no county part holds
                    // a building whose footprint lies in a sibling part.
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

                    // Disarmed and out of the regeneration process (issue #2). It ran once, for voivodeship 16 on
                    // 2026-08-15, and deleted the 448 607 legacy rows that round superseded.
                    // The national pass no longer needs it: building_model_component is truncated first, so nothing
                    // supersedes anything and every row the run writes is the only row for its building. Leaving
                    // this armed is the one way that plan could delete something it should not.
                    // It stays here because it remains the right tool if legacy rows ever reappear - a row goes
                    // only where a reference-keyed row for the same (county_id, reference) sits beside it, so no
                    // building can lose its last model. Scope it, run it with DryRun on, compare the superseded
                    // count per part against that part's building_2d reference count, then arm the same scope.
                    // RemoveOrphans answers a different question - whether the building moved - and only belongs
                    // on after a repair report says so.
                    // The name and the description are derived from DryRun rather than written beside it. They were
                    // last written by hand while the task was armed and were left saying "DryRun is off - this
                    // writes and has no undo" after it had been put back behind the flag, which is the wrong
                    // direction for a label on a row whose button deletes rows with no undo.
                    PostgreSQLBuildingModelCleanupTask postgreSQLBuildingModelCleanupTask = new(gISPostgreSQLConverterManager)
                    {
                        DryRun = true,
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
                    // The national regeneration (issue #2), unscoped: all 406 county parts, ~15.2 million buildings,
                    // ~2.3 days at the measured 13 ms each.
                    // It runs against a truncated building_model_component, so every row it writes is the only row
                    // for its building and no cleanup follows it. Truncating also restores the completeness gate:
                    // while legacy rows remain, a building the run skips still answers with its old row, so a
                    // missing-model count proves nothing - which is why voivodeship 16 had to be checked through
                    // the superseded count instead.
                    // 16 (opolskie) was the scale test that earned this scope: 448 607 buildings across 12 parts in
                    // 1 h 32 m on 2026-08-15, no county failed, no building was lost, and the cleanup dry run
                    // afterwards accounted for every one of them. A run that finishes proves nothing on its own -
                    // county 5 modelled 65 % of its buildings and reported success when QuikGraph was missing from
                    // the host - which is why the count is read back rather than the task's own verdict trusted.
                    // Delete BuildingModels_Regeneration_Checkpoint.txt before starting, or voivodeship 16's twelve
                    // parts are skipped as already done when the truncate has just emptied them. Delete the file
                    // rather than turning Resume off, which would restart from the first county after any
                    // interruption. Turn MaxConcurrentRequests down if the server or GUGiK starts refusing.
                    result.Add(Visual(new UIBuildingModelsFromDatabasePostTask(GISWebAPIManager)
                    {
                        MaxConcurrentRequests = 8
                    },
                    "Create BuildingModels from database", "Creates BuildingModels for Building2Ds from database based on CityGML Buildings stored in database"));

                    // The acceptance run for the national pass: every voivodeship, 200 references per county.
                    // Missing is a real gate again once the table has been truncated - no legacy row can answer for
                    // a building the regeneration skipped - so it should come back 0.
                    // Scope it and set SampleSize to 0 to read every reference of a county instead of a sample.
                    // The seed stays 20260811 to match the 2026-08-11 baseline, but note the comparison is
                    // aggregate only: the
                    // baseline was drawn from one generator shared across counties, and the 2026-08-14 county part
                    // repair changed three counties from 10 198 / 24 260 / 51 740 references to 1 / 3 / 1, shifting
                    // the draw of every county after them. The per-county seed removes that for future runs; it
                    // cannot retrofit the baseline.
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
