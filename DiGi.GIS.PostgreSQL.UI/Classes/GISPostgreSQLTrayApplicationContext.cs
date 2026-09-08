using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using DiGi.GIS.PostgreSQL.UI.Windows;
using DiGi.GIS.WebAPI.Classes;
using DiGi.User.PostgreSQL.Classes;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// Provides the application context for the GIS PostgreSQL tray application, managing its lifecycle and dependencies.
    /// </summary>
    public class GISPostgreSQLTrayApplicationContext : DiGi.UI.Windows.Classes.TrayApplicationContext<MainWindow>
    {
        private readonly Mode? mode = null;

        private readonly GISPostgreSQLConverterManager? gISPostgreSQLConverterManager = PostgreSQL.Create.GISPostgreSQLConverterManager();

        // Fully qualified: from this namespace an unqualified PostgreSQL binds to DiGi.GIS.PostgreSQL, and the
        // users this application creates live in the database DiGi.User.PostgreSQL names, not in that one.
        private readonly UserPostgreSQLConverterManager? userPostgreSQLConverterManager = DiGi.User.PostgreSQL.Create.UserPostgreSQLConverterManager();

        private readonly GISWebAPIManager? GISWebAPIManager = WebAPI.Create.GISWebAPIManager(Create.GISPostgreSQLConverterManagerConfigurationFile()?.Key);

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
            return new(gISPostgreSQLConverterManager, userPostgreSQLConverterManager, GISWebAPIManager, mode);
        }
    }
}
