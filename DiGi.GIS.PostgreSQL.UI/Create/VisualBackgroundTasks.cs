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
                    if (GISWebAPIManager is not null)
                    {
                        result.Add(Visual(new OrtoDatasTask(GISWebAPIManager, gISPostgreSQLConverterManager), "Bypass upload OrtoDatas from database", "Upload OrtoDatas from database. Direct update of OrtoDatas by bypassing the GIS WebAPI HTTP post."));
                    }

                    // Scoped from a dialog rather than from defaults written here: the cost of this run is the
                    // square of the grid size over the area chosen, from an afternoon over one county to
                    // hundreds of millions of requests over the country, so it is asked for at the moment the
                    // task is started.
                    result.Add(Visual(new UIPostgreSQLTerrainPointCreateTableTask(GISWebAPIManager, gISPostgreSQLConverterManager), "Create TerrainPoint table", "Creates the TerrainPoint table and fills it by sampling terrain elevations onto a shared grid. Grid size, override existing and the counties are asked for when the task is started"));
                    result.Add(Visual(new UIPostgreSQLTerrainPointFillGapsTask(GISWebAPIManager, gISPostgreSQLConverterManager), "Fill TerrainPoint gaps", "Measures each county against the lattice and samples only the nodes it is short of, recovering the points a sampling run lost. Grid size and the counties are asked for when the task is started"));

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
                            OverrideExisting = false,
                            UpdateSubdivisionIds = true
                        }
                    },
                    "Refresh OrtoDatas", "Queues the orthophoto downloads each county is short of, for the download task to work through. Stores no orthophoto data itself"));

                    result.Add(Visual(new PostgreSQLUpdateOccupancyTask(gISPostgreSQLConverterManager), "Update occupancy from database", "Update occupancy for Building2Ds and AdministrativeAreal2Ds based on data in database"));

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

                    // Orphan cleanup only. The superseded half went with the unique_id migration of issue
                    // ZiolkowskiJakub/DiGi.GIS.PostgreSQL#5: rows are keyed on the model they hold, so nothing is
                    // keyed on its reference any more and nothing supersedes anything.
                    // What remains answers a different question - whether the building moved. A model whose part no
                    // longer holds its building_2d is what a PostgreSQLBuilding2DCountyPartRepairTask run can leave
                    // behind, and it loses its only row when deleted, which is why this stays behind DryRun.
                    // The name and the description are derived from DryRun rather than written beside it, so a row
                    // whose button deletes rows with no undo cannot end up labelled as though it were reporting.
                    PostgreSQLBuildingModelCleanupTask postgreSQLBuildingModelCleanupTask = new(gISPostgreSQLConverterManager)
                    {
                        DryRun = true
                    };

                    result.Add(Visual(postgreSQLBuildingModelCleanupTask,
                    postgreSQLBuildingModelCleanupTask.DryRun ? "Report BuildingModels without a building (dry run, deletes nothing)" : "Remove BuildingModels without a building (DELETES rows)",
                    $"Reports BuildingModel rows whose building no longer exists under the county part holding them. Scope: {(postgreSQLBuildingModelCleanupTask.VoivodeshipCodes is null ? "every voivodeship" : $"voivodeship {string.Join(' ', postgreSQLBuildingModelCleanupTask.VoivodeshipCodes)}")}. {(postgreSQLBuildingModelCleanupTask.DryRun ? "Dry run - nothing is written until DryRun is turned off" : "DryRun is OFF - this writes and has no undo")}"));
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
