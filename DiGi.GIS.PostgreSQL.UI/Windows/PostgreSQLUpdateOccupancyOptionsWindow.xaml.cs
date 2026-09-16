using DiGi.GIS.PostgreSQL.Classes;
using DiGi.UI.WPF.Classes;
using System.Collections.Generic;
using System.Windows;

namespace DiGi.GIS.PostgreSQL.UI.Windows
{
    /// <summary>
    /// Interaction logic for PostgreSQLUpdateOccupancyOptionsWindow.xaml
    /// <para>Asks which side of the occupancy update runs - the administrative roll-up, the per-building distribution, or both - whether the stored rows are cleared first, and which counties the building side is limited to. The roll-up is a sum over the whole hierarchy and stays nationwide whatever counties are selected.</para>
    /// <para>No county selected means every county, which is what the task has always meant; with counties selected a clear removes only their buildings' rows, so the rest of the table is left as it stands.</para>
    /// <para>The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.</para>
    /// </summary>
    public partial class PostgreSQLUpdateOccupancyOptionsWindow : Window
    {
        private readonly PostgreSQLUpdateOccupancyOptions postgreSQLUpdateOccupancyOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSQLUpdateOccupancyOptionsWindow"/> class.
        /// </summary>
        /// <param name="postgreSQLUpdateOccupancyOptions">The options the controls are filled from. When null the defaults are used.</param>
        /// <param name="administrativeAreal2DReferences">The counties to choose from. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own.</param>
        public PostgreSQLUpdateOccupancyOptionsWindow(PostgreSQLUpdateOccupancyOptions? postgreSQLUpdateOccupancyOptions, IEnumerable<AdministrativeAreal2DReference>? administrativeAreal2DReferences)
        {
            InitializeComponent();

            this.postgreSQLUpdateOccupancyOptions = postgreSQLUpdateOccupancyOptions is null ? new PostgreSQLUpdateOccupancyOptions() : new PostgreSQLUpdateOccupancyOptions(postgreSQLUpdateOccupancyOptions);

            CheckBox_IncludeAdministrativeAreal2Ds.IsChecked = this.postgreSQLUpdateOccupancyOptions.IncludeAdministrativeAreal2Ds;
            CheckBox_IncludeBuilding2Ds.IsChecked = this.postgreSQLUpdateOccupancyOptions.IncludeBuilding2Ds;
            CheckBox_Clear.IsChecked = this.postgreSQLUpdateOccupancyOptions.Clear;

            // Subscribed before the list is filled - the text of an item is decided as it is added.
            ListBoxControl_Counties.ItemAdding += ListBoxControl_Counties_ItemAdding;

            SetCounties(administrativeAreal2DReferences);
        }

        /// <summary>
        /// Gets the options the window holds. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with.
        /// </summary>
        public PostgreSQLUpdateOccupancyOptions PostgreSQLUpdateOccupancyOptions
        {
            get
            {
                return postgreSQLUpdateOccupancyOptions;
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            bool includeAdministrativeAreal2Ds = CheckBox_IncludeAdministrativeAreal2Ds.IsChecked == true;
            bool includeBuilding2Ds = CheckBox_IncludeBuilding2Ds.IsChecked == true;

            if (!includeAdministrativeAreal2Ds && !includeBuilding2Ds)
            {
                MessageBox.Show("At least one side has to be selected.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // No selection is "every county" - the task takes null as the whole table. An empty set would mean
            // "none" and write nothing, so it is never handed over.
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

            postgreSQLUpdateOccupancyOptions.IncludeAdministrativeAreal2Ds = includeAdministrativeAreal2Ds;
            postgreSQLUpdateOccupancyOptions.IncludeBuilding2Ds = includeBuilding2Ds;
            postgreSQLUpdateOccupancyOptions.Clear = CheckBox_Clear.IsChecked == true;
            postgreSQLUpdateOccupancyOptions.CountyIds = countyIds;

            DialogResult = true;
            Close();
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

            HashSet<int>? countyIds = postgreSQLUpdateOccupancyOptions.CountyIds;
            if (countyIds is null || countyIds.Count == 0)
            {
                return;
            }

            // Matched on the identifier rather than on the references themselves: the options carry identifiers,
            // and the references are read afresh from the database on every run.
            ListBoxControl_Counties.SelectItems<AdministrativeAreal2DReference>(x => countyIds.Contains(x.Id));
        }
    }
}
