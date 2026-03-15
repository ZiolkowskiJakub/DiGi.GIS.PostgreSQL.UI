using DiGi.GIS.PostgreSQL.Classes;
using DiGi.UI.WPF.Interfaces;
using System.Collections.Generic;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Create
    {
        public static List<IVisualBackgroundTask>? VisualBackgroundTasks(GISPostgreSQLConverterManager? gISPostgreSQLConverterManager)
        {
            if(gISPostgreSQLConverterManager is null)
            {
                return null;
            }

            List<IVisualBackgroundTask> result = [];

            result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLAdministrativeAreal2DCreateDatabaseTask(gISPostgreSQLConverterManager), "Create AdministrativeAreal2D database", "Creates AdministrativeAreal2D database"));

            Building2DPostgreSQLConverter? building2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<Building2DPostgreSQLConverter>();
            if(building2DPostgreSQLConverter is not null)
            {
                result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLBuilding2DRefreshTask(building2DPostgreSQLConverter), "Refresh Building2D", "Refreshes Building2D table in database")); 
            }

            AdministrativeAreal2DPostgreSQLConverter? administrativeAreal2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<AdministrativeAreal2DPostgreSQLConverter>();
            if (administrativeAreal2DPostgreSQLConverter is not null)
            {
                result.Add(DiGi.UI.WPF.Create.VisualBackgroundTask(new PostgreSQLAdministrativeAreal2DRefreshTask(administrativeAreal2DPostgreSQLConverter), "Refresh AdministrativeAreal2D", "Refreshes AdministrativeAreal2D table in database"));
            }

            result.Sort((x, y) => x.Name!.CompareTo(y.Name));

            return result;
        }
    }
}