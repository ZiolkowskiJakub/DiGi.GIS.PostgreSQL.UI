using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    public class GISPostgreSQLUIAdministrativeAreal2DPostTask : GISPostgreSQLWebAPIAdministrativeAreal2DPostTask, IGISPostgreSQLUIObject
    {
        public GISPostgreSQLUIAdministrativeAreal2DPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        /// <summary>
        /// Concrete implementation of the background work.
        /// </summary>
        protected override async Task<bool> ExecuteAsync()
        {
            return await base.ExecuteAsync();
        }
    }
}