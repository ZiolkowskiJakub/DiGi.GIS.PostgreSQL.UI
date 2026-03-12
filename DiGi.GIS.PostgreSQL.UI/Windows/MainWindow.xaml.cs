using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using DiGi.UI.WPF.Core.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DiGi.GIS.PostgreSQL.UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GISPostgreSQLConverterManager? gISPostgreSQLConverterManager;
        private readonly Mode? mode;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Mode mode, GISPostgreSQLConverterManager? gISPostgreSQLConverterManager)
        {
            this.gISPostgreSQLConverterManager = gISPostgreSQLConverterManager;
            this.mode = mode;
            
            InitializeComponent();

            List<VisualCancelableTask>? visualCancelableTasks = Create.VisualCancelableTasks(gISPostgreSQLConverterManager);
            if (visualCancelableTasks is not null)
            {
                VisualCancelableTasks = [.. visualCancelableTasks];
            }

            DataContext = this;
        }

        public Mode Mode
        {
            get
            {
                if(mode is null || !mode.HasValue)
                {
                    return Mode.Client;
                }

                return gISPostgreSQLConverterManager is null ? Mode.Client : Mode.ServerAndCient;
            }
        }
        
        public ObservableCollection<VisualCancelableTask>? VisualCancelableTasks { get; set; }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            if(Mode == Mode.Client)
            {
                TabItem_Server.Visibility = Visibility.Hidden;
            }
        }
    }
}