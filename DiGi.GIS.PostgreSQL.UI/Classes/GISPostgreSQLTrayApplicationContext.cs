using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using DiGi.GIS.PostgreSQL.UI.Windows;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    public class GISPostgreSQLTrayApplicationContext : DiGi.UI.Windows.Classes.TrayApplicationContext<MainWindow>
    {
        private readonly Mode mode = Mode.ServerAndCient;

        private readonly GISPostgreSQLConverterManager? gISPostgreSQLConverterManager;

        public GISPostgreSQLTrayApplicationContext()
            :base("GIS PostgreSQL")
        {
            gISPostgreSQLConverterManager = PostgreSQL.Create.GISPostgreSQLConverterManager();
        }

        protected override MainWindow GetWindow()
        {
            return new(mode, gISPostgreSQLConverterManager);
        }
    }
}