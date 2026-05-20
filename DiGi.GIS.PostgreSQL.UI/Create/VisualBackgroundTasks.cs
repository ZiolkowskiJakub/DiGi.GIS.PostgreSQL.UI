using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using DiGi.UI.WPF.Interfaces;
using System.Collections.Generic;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Create
    {
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
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLUpdateBuilding2DDataTask(gISPostgreSQLConverterManager), "Update Building2D data", "Update calulated Building2D data in dump table"));


                    Building2DPostgreSQLConverter? building2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<Building2DPostgreSQLConverter>();
                    if (building2DPostgreSQLConverter is not null)
                    {
                        result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLBuilding2DRefreshTask(building2DPostgreSQLConverter), "Refresh Building2Ds", "Refreshes Building2D table in database"));
                    }

                    AdministrativeAreal2DPostgreSQLConverter? administrativeAreal2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<AdministrativeAreal2DPostgreSQLConverter>();
                    if (administrativeAreal2DPostgreSQLConverter is not null)
                    {
                        result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLAdministrativeAreal2DRefreshTask(administrativeAreal2DPostgreSQLConverter), "Refresh AdministrativeAreal2Ds", "Refreshes AdministrativeAreal2D table in database"));
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
                }
            }

            if (mode == Mode.Client || mode == Mode.ServerAndCient)
            {
                if (gISPostgreSQLWebAPIManager is not null)
                {
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new UIUpdateFromFilePostTask(gISPostgreSQLWebAPIManager), "Upload Areal2Ds from BDOT10k file", "Upload AdministrativeAreal2Ds and/or Building2Ds from BDOT10k *.zip file"));
                    
                    result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new UIAdministrativeAreal2DFromFilePostTask(gISPostgreSQLWebAPIManager), "Upload AdministrativeAreal2Ds from file", "Uploads AdministrativeAreal2Ds from file to the server"));
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