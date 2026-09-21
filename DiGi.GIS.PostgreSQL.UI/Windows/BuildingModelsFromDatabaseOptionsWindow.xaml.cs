using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Classes;
using DiGi.UI.WPF.Classes;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace DiGi.GIS.PostgreSQL.UI.Windows
{
    /// <summary>
    /// Interaction logic for BuildingModelsFromDatabaseOptionsWindow.xaml
    /// <para>Asks what decides the reach of a BuildingModel regeneration from the database: which county polygon parts are walked, whether the checkpoint of an earlier run is honoured, and where the checkpoint and the failed-county list are written. The request pacing stays with the task - it is tuning nobody changes between runs, and is set where the task is registered.</para>
    /// <para>No county selected means every county, which is what the task has always meant.</para>
    /// <para>The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.</para>
    /// </summary>
    public partial class BuildingModelsFromDatabaseOptionsWindow : Window
    {
        private readonly BuildingModelsFromDatabaseOptions buildingModelsFromDatabaseOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingModelsFromDatabaseOptionsWindow"/> class.
        /// </summary>
        /// <param name="buildingModelsFromDatabaseOptions">The options the controls are filled from. When null the defaults are used.</param>
        /// <param name="administrativeAreal2DReferences">The counties to choose from. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own.</param>
        public BuildingModelsFromDatabaseOptionsWindow(BuildingModelsFromDatabaseOptions? buildingModelsFromDatabaseOptions, IEnumerable<AdministrativeAreal2DReference>? administrativeAreal2DReferences)
        {
            InitializeComponent();

            this.buildingModelsFromDatabaseOptions = buildingModelsFromDatabaseOptions is null ? new BuildingModelsFromDatabaseOptions() : new BuildingModelsFromDatabaseOptions(buildingModelsFromDatabaseOptions);

            CheckBox_Resume.IsChecked = this.buildingModelsFromDatabaseOptions.Resume;
            TextBox_ReportDirectory.Text = this.buildingModelsFromDatabaseOptions.ReportDirectory ?? string.Empty;

            // Subscribed before the list is filled - the text of an item is decided as it is added.
            ListBoxControl_Counties.ItemAdding += ListBoxControl_Counties_ItemAdding;

            SetCounties(administrativeAreal2DReferences);
        }

        /// <summary>
        /// Gets the options the window holds. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with.
        /// </summary>
        public BuildingModelsFromDatabaseOptions BuildingModelsFromDatabaseOptions
        {
            get
            {
                return buildingModelsFromDatabaseOptions;
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            // Resolved the way the task resolves it - the directory the application was launched from - so a
            // blank box means that directory rather than nothing, and a typed path is checked for existence
            // here rather than failing the run after the counties have been chosen.
            string? reportDirectory = null;
            string directory_Text = TextBox_ReportDirectory.Text?.Trim() ?? string.Empty;
            if (directory_Text != string.Empty)
            {
                if (!Directory.Exists(directory_Text))
                {
                    MessageBox.Show("Report directory does not exist.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                reportDirectory = directory_Text;
            }

            // No selection is "every county" - the task takes null as the whole table. An empty set would
            // mean "none" and process nothing, so it is never handed over.
            List<AdministrativeAreal2DReference>? administrativeAreal2DReferences = ListBoxControl_Counties.GetItems<AdministrativeAreal2DReference>();

            HashSet<int>? countyIds = null;
            if (administrativeAreal2DReferences is not null && administrativeAreal2DReferences.Count != 0)
            {
                countyIds = [];
                foreach (AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences)
                {
                    countyIds.Add(administrativeAreal2DReference.Id);
                }
            }

            buildingModelsFromDatabaseOptions.Resume = CheckBox_Resume.IsChecked == true;
            buildingModelsFromDatabaseOptions.ReportDirectory = reportDirectory;
            buildingModelsFromDatabaseOptions.CountyIds = countyIds;

            DialogResult = true;
            Close();
        }

        private void Button_ReportDirectory_Click(object sender, RoutedEventArgs e)
        {
            // The window is on the user interface thread, so a folder dialog opens here - the task body
            // cannot use one, because it runs on a thread pool thread.
            OpenFolderDialog openFolderDialog = new();
            if (openFolderDialog.ShowDialog(this) is not true)
            {
                return;
            }

            TextBox_ReportDirectory.Text = openFolderDialog.FolderName;
        }

        private void ListBoxControl_Counties_ItemAdding(object sender, ListBoxItemAddingEventArgs e)
        {
            if (e.Item is not AdministrativeAreal2DReference administrativeAreal2DReference)
            {
                return;
            }

            // The identifier is shown because it is what the run is keyed by, and because two pieces of the same
            // county are told apart by nothing else - they share their code and their name.
            e.Name = $"{administrativeAreal2DReference.Code} {administrativeAreal2DReference.Name} (id {administrativeAreal2DReference.Id})";
        }

        private void SetCounties(IEnumerable<AdministrativeAreal2DReference>? administrativeAreal2DReferences)
        {
            if (administrativeAreal2DReferences is null)
            {
                ListBoxControl_Counties.ClearItems();
                return;
            }

            List<AdministrativeAreal2DReference> administrativeAreal2DReferences_Sorted = [];
            foreach (AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences)
            {
                if (administrativeAreal2DReference is null)
                {
                    continue;
                }

                administrativeAreal2DReferences_Sorted.Add(administrativeAreal2DReference);
            }

            // By code, so that the counties of one voivodeship sit together; by identifier within a code,
            // because the pieces of a multi-part county share their code and their name and the identifier is
            // all that separates them.
            administrativeAreal2DReferences_Sorted.Sort((x, y) =>
            {
                int result = string.CompareOrdinal(x.Code ?? string.Empty, y.Code ?? string.Empty);

                return result != 0 ? result : x.Id.CompareTo(y.Id);
            });

            ListBoxControl_Counties.SetItems(administrativeAreal2DReferences_Sorted);

            HashSet<int>? countyIds = buildingModelsFromDatabaseOptions.CountyIds;
            if (countyIds is null || countyIds.Count == 0)
            {
                return;
            }

            // Matched on the identifier rather than on the references themselves: the options carry identifiers,
            // and the references are read afresh from the server on every run.
            ListBoxControl_Counties.SelectItems<AdministrativeAreal2DReference>(x => countyIds.Contains(x.Id));
        }
    }
}
