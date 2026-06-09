using System;
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
            // Catch exceptions from the main UI thread
            Current.DispatcherUnhandledException += App_DispatcherUnhandledException;

            // Catch exceptions from other threads
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Disable hardware acceleration to diagnose rendering issues
            System.Windows.Media.RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.SoftwareOnly;

            base.OnStartup(e);

            // Prevent application from shutting down when all windows are closed
            ShutdownMode = ShutdownMode.OnExplicitShutdown;

            gISPostgreSQLTrayApplicationContext = new Classes.GISPostgreSQLTrayApplicationContext();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Exception currentException = e.Exception;
            string errorMessage = string.Format("UI Thread Exception: {0}\n{1}", currentException.Message, currentException.StackTrace);

            MessageBox.Show(errorMessage, "Critical UI Error");

            // Prevent the application from crashing immediately to allow for state inspection
            e.Handled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception currentException = (Exception)e.ExceptionObject;
            string errorMessage = string.Format("Non-UI Thread Exception: {0}\n{1}", currentException.Message, currentException.StackTrace);

            MessageBox.Show(errorMessage, "Fatal Domain Error");
        }
    }
}