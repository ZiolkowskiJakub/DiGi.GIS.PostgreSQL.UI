using DiGi.Core;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.Enums;
using DiGi.GIS.PostgreSQL.UI.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
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
        /// <param name="gISPostgreSQLWebAPIManager">The manager responsible for interacting with the PostgreSQL Web API.</param>
        /// <param name="mode">The operation mode (Server, Client, or both) that determines which tasks are instantiated.</param>
        /// <returns>A list of <see cref="IVisualBackgroundTask"/> objects sorted by name, or null if not applicable.</returns>
        public static List<IVisualBackgroundTask>? VisualBackgroundTasks(GISPostgreSQLConverterManager? gISPostgreSQLConverterManager, GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, Mode mode)
        {
            List<IVisualBackgroundTask> result = [];

            if (mode == Mode.Server || mode == Mode.ServerAndCient)
            {
                if (gISPostgreSQLConverterManager is not null)
                {
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLAdministrativeAreal2DCreateDatabaseTask(gISPostgreSQLConverterManager), "Create main database", "Creates main database for AdministrativeAreal2D and Biulding2D objects"));
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLOrtoDatasCreateDatabaseTask(gISPostgreSQLConverterManager), "Create storage database", "Creates storage database for OrtoDatas objects"));
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new OrtoDatasTask(gISPostgreSQLWebAPIManager, gISPostgreSQLConverterManager), "Bypass upload OrtoDatas from database", "Upload OrtoDatas from database. Direct update of OrtoDatas by bypassing the GIS WebAPI HTTP post."));

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
                            postgreSQLBuildingDataUpdateTask_Temp.uIBuildingDataUpdateOptions.BuildingDataUpdateTypes = [];
                            return;
                        }

                        List<BuildingDataUpdateType> buildingDataUpdateTypes = [];
                        foreach (string text in texts)
                        {
                            buildingDataUpdateTypes.Add(dictionary[text]);
                        }

                        postgreSQLBuildingDataUpdateTask_Temp.uIBuildingDataUpdateOptions.BuildingDataUpdateTypes = buildingDataUpdateTypes;
                    };

                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(postgreSQLBuildingDataUpdateTask, "Update building data", "Update building data base on Buidling2D and other data sources (database, OrtoDatas etc.)"));

                    Building2DPostgreSQLConverter? building2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<Building2DPostgreSQLConverter>();
                    if (building2DPostgreSQLConverter is not null)
                    {
                        result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLBuilding2DRefreshTask(building2DPostgreSQLConverter), "Refresh Building2Ds", "Refreshes Building2D table in database"));
                        result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLBuilding2DCreateTableTask(building2DPostgreSQLConverter), "Create Building2D table", "Creates or updates (table indexes etc.) Building2D table in database"));
                    }

                    AdministrativeAreal2DPostgreSQLConverter? administrativeAreal2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<AdministrativeAreal2DPostgreSQLConverter>();
                    if (administrativeAreal2DPostgreSQLConverter is not null)
                    {
                        result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLAdministrativeAreal2DRefreshTask(administrativeAreal2DPostgreSQLConverter), "Refresh AdministrativeAreal2Ds", "Refreshes AdministrativeAreal2D table in database"));
                        result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLAdministrativeAreal2DCreateTableTask(administrativeAreal2DPostgreSQLConverter), "Create AdministrativeAreal2D table", "Creates or updates (table indexes etc.) AdministrativeAreal2D table in database"));
                    }

                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLOrtoDatasRefreshTask(gISPostgreSQLConverterManager)
                    {
                        PostgreSQLOrtoDatasRefreshOptions = new PostgreSQLOrtoDatasRefreshOptions()
                        {
                            OverrideExistsing = false,
                            UpdateSubdivisionIds = true
                        }
                    },
                    "Refresh OrtoDatas", "Refreshes OrtoDatas table in database"));

                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLUpdateOccupancyTask(gISPostgreSQLConverterManager), "Update occupancy from database", "Update occupancy for Building2Ds and AdministrativeAreal2Ds based on data in database"));
                }
            }

            if (mode == Mode.Client || mode == Mode.ServerAndCient)
            {
                if (gISPostgreSQLWebAPIManager is not null)
                {
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new UIUpdateFromFilePostTask(gISPostgreSQLWebAPIManager), "Upload Areal2Ds from BDOT10k file", "Upload AdministrativeAreal2Ds and/or Building2Ds from BDOT10k *.zip file"));

                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new UIAdministrativeAreal2DFromFilePostTask(gISPostgreSQLWebAPIManager), "Upload AdministrativeAreal2Ds from file", "Uploads AdministrativeAreal2Ds from file to the server"));
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new UIEPWFileFromFilePostTask(gISPostgreSQLWebAPIManager), "Upload EPWFile from file", "Uploads EPWFile from selected file or directory to the server"));
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new UIBuilding2DsFromFilePostTask(gISPostgreSQLWebAPIManager), "Upload Building2Ds from file", "Uploads Building2Ds from file to the server"));
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new OrtoDatasFromDatabasePostTask(gISPostgreSQLWebAPIManager), "Upload OrtoDatas from database", "Uploads OrtoDatas from Building2D information stored in the database to the server"));
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new UIYearBuiltDatasFromFilePostTask(gISPostgreSQLWebAPIManager), "Upload YearBuiltDatas from file", "Uploads YearBuiltDatas from file to the server"));
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new UIOccupancyDatasFromFilePostTask(gISPostgreSQLWebAPIManager), "Upload OccupancyDatas from file", "Uploads OccupancyDatas (Building2D and AdministrativeAreal2D) from file to the server"));

                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new UIOrtoDatasFromFilePostTask(gISPostgreSQLWebAPIManager)
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