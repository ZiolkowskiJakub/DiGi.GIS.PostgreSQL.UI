using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using DiGi.GIS.PostgreSQL.UI.Windows;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// Provides the application context for the GIS PostgreSQL tray application, managing its lifecycle and dependencies.
    /// </summary>
    public class GISPostgreSQLTrayApplicationContext : DiGi.UI.Windows.Classes.TrayApplicationContext<MainWindow>
    {
        private readonly Mode? mode = null;

        private readonly GISPostgreSQLConverterManager? gISPostgreSQLConverterManager = PostgreSQL.Create.GISPostgreSQLConverterManager();

        private readonly GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager = WebAPI.Create.GISPostgreSQLWebAPIManager();

        /// <summary>
        /// Initializes a new instance of the <see cref="GISPostgreSQLTrayApplicationContext"/> class.
        /// </summary>
        public GISPostgreSQLTrayApplicationContext()
            : base("GIS PostgreSQL")
        {

        }

        /// <summary>
        /// Creates and returns the main window associated with this application context.
        /// </summary>
        /// <returns>An instance of the <see cref="MainWindow"/> class.</returns>
        protected override MainWindow GetWindow()
        {
            return new(gISPostgreSQLConverterManager, gISPostgreSQLWebAPIManager, mode);
        }
    }
}