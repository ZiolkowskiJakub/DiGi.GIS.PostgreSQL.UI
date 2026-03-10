using System.Windows;

namespace DiGi.GIS.PostgreSQL.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private Classes.TrayApplicationContext trayApplicationContext;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Prevent application from shutting down when all windows are closed
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            trayApplicationContext = new Classes.TrayApplicationContext();
        }
    }

}
