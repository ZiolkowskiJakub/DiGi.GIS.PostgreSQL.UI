using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using DiGi.UI.WPF.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DiGi.GIS.PostgreSQL.UI.Windows
{
    public partial class MainWindow : Window
    {
        private readonly GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager;
        private readonly GISPostgreSQLConverterManager? gISPostgreSQLConverterManager;
        private readonly Mode? mode;

        public MainWindow(Mode mode, GISPostgreSQLConverterManager? gISPostgreSQLConverterManager, GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager)
        {
            this.gISPostgreSQLConverterManager = gISPostgreSQLConverterManager;
            this.gISPostgreSQLWebAPIManager = gISPostgreSQLWebAPIManager;
            this.mode = mode;


            // Initialize collections before InitializeComponent to avoid binding errors
            List<IVisualBackgroundTask>? visualBackgroundTasks;

            visualBackgroundTasks = Create.VisualBackgroundTasks(gISPostgreSQLConverterManager, gISPostgreSQLWebAPIManager, Mode.Client);
            if (visualBackgroundTasks is not null)
            {
                VisualBackgroundTasks_Client = [.. visualBackgroundTasks];
            }

            visualBackgroundTasks = Create.VisualBackgroundTasks(gISPostgreSQLConverterManager, gISPostgreSQLWebAPIManager, Mode.Server);
            if (visualBackgroundTasks is not null)
            {
                VisualBackgroundTasks_Server = [.. visualBackgroundTasks];
            }

            InitializeComponent();

            // Setting the DataContext for bindings to work
            DataContext = this;
        }

        public Mode Mode
        {
            get
            {
                if (mode is null || !mode.HasValue)
                {
                    return Mode.Client;
                }

                return gISPostgreSQLConverterManager is null ? Mode.Client : Mode.ServerAndCient;
            }
        }

        // Explicit typing as requested
        public ObservableCollection<IVisualBackgroundTask>? VisualBackgroundTasks_Client { get; set; }
        public ObservableCollection<IVisualBackgroundTask>? VisualBackgroundTasks_Server { get; set; }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            if (Mode == Mode.Client)
            {
                TabItem_Server.Visibility = Visibility.Hidden;
            }
        }
    }
}