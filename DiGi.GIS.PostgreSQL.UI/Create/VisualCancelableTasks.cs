using DiGi.GIS.PostgreSQL.Classes;
using DiGi.UI.WPF.Core.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Create
    {
        public static List<VisualCancelableTask>? VisualCancelableTasks(GISPostgreSQLConverterManager? gISPostgreSQLConverterManager)
        {
            if(gISPostgreSQLConverterManager is null)
            {
                return null;
            }

            List<VisualCancelableTask> result = [];

            Building2DPostgreSQLConverter? building2DPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<Building2DPostgreSQLConverter>();
            if(building2DPostgreSQLConverter is not null)
            {
                result.Add(new VisualCancelableTask(new PostgreSQLBuilding2DRefreshTask(building2DPostgreSQLConverter), "Refresh Building2D", "Refreshes Building2D table in database")); 
            }

            return result;
        }
    }
}