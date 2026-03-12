using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    public class TrayApplicationContext : ApplicationContext
    {
        private readonly Mode mode = Mode.ServerAndCient;

        private readonly GISPostgreSQLConverterManager? gISPostgreSQLConverterManager;

        private readonly NotifyIcon notifyIcon;
        private Windows.MainWindow? mainWindow;
        private bool isClosingFromMenu = false;

        public TrayApplicationContext()
        {
            // 1. Setup Context Menu
            ContextMenuStrip contextMenuStrip = new();
            contextMenuStrip.Items.Add("Open", null, (s, e) => ShowWindow());
            contextMenuStrip.Items.Add("-");
            contextMenuStrip.Items.Add("Exit", null, (s, e) => ExitApplication());

            // 2. Setup NotifyIcon
            notifyIcon = new NotifyIcon()
            {
                // Extracting icon from current executable to ensure it's not null
                Icon = Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath),
                ContextMenuStrip = contextMenuStrip,
                Visible = true,
                Text = "GIS PostgreSQL UI"
            };

            // 3. Set GISPostgreSQLConverterManager
            gISPostgreSQLConverterManager = PostgreSQL.Create.GISPostgreSQLConverterManager();

            notifyIcon.DoubleClick += (s, e) => ShowWindow();
        }

        private void ShowWindow()
        {
            if (mainWindow == null)
            {
                mainWindow = new(mode, gISPostgreSQLConverterManager)
                {
                    WindowStartupLocation = WindowStartupLocation.Manual,
                };

                // Set window startup position manually near the tray
                //mainWindow.PositionWindowAboveTray(mainWindow);

                // Subscribing to lifecycle events
                mainWindow.Closing += OnWindowClosing;
                mainWindow.Deactivated += OnWindowDeactivated;

                mainWindow.Show();
            }
            else
            {
                // Bring to front if already exists
                if (mainWindow.WindowState == WindowState.Minimized)
                {
                    mainWindow.WindowState = WindowState.Normal;
                }
                mainWindow.Activate();
            }
        }

        //private void PositionWindowAboveTray(Windows.MainWindow mainWindow)
        //{
        //    // Get working area (excluding taskbar)
        //    Rect desktopWorkingArea = SystemParameters.WorkArea;

        //    // Basic alignment: bottom right corner
        //    // You might need to adjust these offsets based on your window size
        //    mainWindow.Left = desktopWorkingArea.Right - mainWindow.Width - 10;
        //    mainWindow.Top = desktopWorkingArea.Bottom - mainWindow.Height - 10;
        //}

        private void OnWindowDeactivated(object? sender, EventArgs e)
        {
            // Scenario: User clicks outside the window
            // We call Close(), which triggers OnWindowClosing
            mainWindow?.Close();
        }

        private void OnWindowClosing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            // Scenario: User clicked 'X' or Deactivated triggered Close()
            if (!isClosingFromMenu)
            {
                // We let the window close naturally (no e.Cancel = true),
                // but we must detach events and null the reference
                // to avoid InvalidOperationException.
                DetachWindowEvents();
                mainWindow = null;
            }
            // If _isClosingFromMenu is true, the window closes as part of app shutdown.
        }

        private void DetachWindowEvents()
        {
            if (mainWindow != null)
            {
                mainWindow.Closing -= OnWindowClosing;
                mainWindow.Deactivated -= OnWindowDeactivated;
            }
        }

        private void ExitApplication()
        {
            isClosingFromMenu = true;

            // Cleanup NotifyIcon
            notifyIcon.Visible = false;
            notifyIcon.Dispose();

            // Shutdown the WPF Application
            mainWindow?.Close();

            System.Windows.Application.Current.Shutdown();
        }
    }
}