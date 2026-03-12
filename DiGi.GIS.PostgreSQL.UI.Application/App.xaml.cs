using System.Windows;

namespace DiGi.GIS.PostgreSQL.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Classes.GISPostgreSQLTrayApplicationContext? gISPostgreSQLTrayApplicationContext;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Prevent application from shutting down when all windows are closed
            ShutdownMode = ShutdownMode.OnExplicitShutdown;

            gISPostgreSQLTrayApplicationContext = new Classes.GISPostgreSQLTrayApplicationContext();
        }
    }
}