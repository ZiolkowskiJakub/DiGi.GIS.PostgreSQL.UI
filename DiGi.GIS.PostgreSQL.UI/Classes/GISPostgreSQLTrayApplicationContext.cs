using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using DiGi.GIS.PostgreSQL.UI.Windows;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    public class GISPostgreSQLTrayApplicationContext : DiGi.UI.Windows.Classes.TrayApplicationContext<MainWindow>
    {
        private readonly Mode? mode = null;

        private readonly GISPostgreSQLConverterManager? gISPostgreSQLConverterManager = PostgreSQL.Create.GISPostgreSQLConverterManager();

        private readonly GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager = WebAPI.Create.GISPostgreSQLWebAPIManager();

        public GISPostgreSQLTrayApplicationContext()
            : base("GIS PostgreSQL")
        {

        }

        protected override MainWindow GetWindow()
        {
            return new(gISPostgreSQLConverterManager, gISPostgreSQLWebAPIManager, mode);
        }
    }
}