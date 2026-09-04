using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.YOLO.UI.Classes;
using DiGi.UI.WPF.Classes;
using System.Collections.Generic;
using System.Windows;

namespace DiGi.GIS.PostgreSQL.UI.Windows
{
    /// <summary>
    /// Interaction logic for YearBuiltPredictionsOptionsWindow.xaml
    /// <para>Asks for what one Year Built prediction run covers and does - the counties, where its imagery goes, which interpreter and weights score it, which of its steps run, and how the run talks to the server: the concurrency of its requests and the two batch sizes. The year range and the radiuses are not asked for, deliberately: they have to match what the regressor was trained on, and a projection that disagrees with them hands the model defaults rather than features, which scores without failing (ZiolkowskiJakub/DiGi.GIS.ML#6).</para>
    /// <para>The three write steps change stored production data, so they are shown apart from the rest and start from whatever the options already ask for - which the template ships as off. A first pass over a county reads everything, scores everything and stores nothing.</para>
    /// <para>The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.</para>
    /// </summary>
    public partial class YearBuiltPredictionsOptionsWindow : Window
    {
        private readonly YearBuiltPredictionPipelineOptions yearBuiltPredictionPipelineOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="YearBuiltPredictionsOptionsWindow"/> class.
        /// </summary>
        /// <param name="yearBuiltPredictionPipelineOptions">The options the controls are filled from. When null the defaults are used.</param>
        /// <param name="administrativeAreal2DReferences">The counties to choose from. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own - a run names every part of a county so that each written row is filed under the part its reference belongs to.</param>
        public YearBuiltPredictionsOptionsWindow(YearBuiltPredictionPipelineOptions? yearBuiltPredictionPipelineOptions, IEnumerable<AdministrativeAreal2DReference>? administrativeAreal2DReferences)
        {
            InitializeComponent();

            this.yearBuiltPredictionPipelineOptions = yearBuiltPredictionPipelineOptions is null ? new YearBuiltPredictionPipelineOptions() : new YearBuiltPredictionPipelineOptions(yearBuiltPredictionPipelineOptions);

            // The captions stay in the XAML - the designer does not run this constructor, and a caption set here
            // leaves an empty label over an empty box in the preview. Only the values come from the options.
            TextBoxControl_ScratchDirectory.Value = this.yearBuiltPredictionPipelineOptions.ScratchDirectory;
            TextBoxControl_PythonPath.Value = this.yearBuiltPredictionPipelineOptions.PythonPath;
            TextBoxControl_ModelPath.Value = this.yearBuiltPredictionPipelineOptions.ModelPath;
            TextBoxControl_WorkingDirectory.Value = this.yearBuiltPredictionPipelineOptions.WorkingDirectory;
            TextBoxControl_Confidence.Value = this.yearBuiltPredictionPipelineOptions.Confidence.ToString();
            TextBoxControl_MaxConcurrentRequests.Value = this.yearBuiltPredictionPipelineOptions.MaxConcurrentRequests.ToString();
            TextBoxControl_BatchSize.Value = this.yearBuiltPredictionPipelineOptions.BatchSize.ToString();
            TextBoxControl_ReferenceBatchSize.Value = this.yearBuiltPredictionPipelineOptions.ReferenceBatchSize.ToString();

            CheckBox_ExportImages.IsChecked = this.yearBuiltPredictionPipelineOptions.ExportImages;
            CheckBox_RunPrediction.IsChecked = this.yearBuiltPredictionPipelineOptions.RunPrediction;
            CheckBox_Score.IsChecked = this.yearBuiltPredictionPipelineOptions.Score;
            CheckBox_Resume.IsChecked = this.yearBuiltPredictionPipelineOptions.Resume;
            CheckBox_CleanScratchDirectory.IsChecked = this.yearBuiltPredictionPipelineOptions.CleanScratchDirectory;

            CheckBox_UpdateDetections.IsChecked = this.yearBuiltPredictionPipelineOptions.UpdateDetections;
            CheckBox_UpdateYearBuiltData.IsChecked = this.yearBuiltPredictionPipelineOptions.UpdateYearBuiltData;
            CheckBox_UpdatePredictedYearBuilt.IsChecked = this.yearBuiltPredictionPipelineOptions.UpdatePredictedYearBuilt;

            // Subscribed before the list is filled - the text of an item is decided as it is added.
            ListBoxControl_Counties.ItemAdding += ListBoxControl_Counties_ItemAdding;

            SetCounties(administrativeAreal2DReferences);
        }

        /// <summary>
        /// Gets the options the window holds. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with.
        /// </summary>
        public YearBuiltPredictionPipelineOptions YearBuiltPredictionPipelineOptions
        {
            get
            {
                return yearBuiltPredictionPipelineOptions;
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            string? scratchDirectory = TextBoxControl_ScratchDirectory.Value;
            if (string.IsNullOrWhiteSpace(scratchDirectory))
            {
                // The run refuses this itself, but only after the counties have been chosen and only into a log.
                // Refusing it here is the one place the reason reaches whoever is looking at the dialog.
                MessageBox.Show("A scratch directory is needed - the imagery has nowhere else to go.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TextBoxControl_Confidence.TryGetValue(out double confidence) || double.IsNaN(confidence) || double.IsInfinity(confidence) || confidence <= 0 || confidence > 1)
            {
                MessageBox.Show("Confidence has to be a number greater than zero and no greater than one.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TextBoxControl_MaxConcurrentRequests.TryGetValue(out int maxConcurrentRequests) || maxConcurrentRequests < 1)
            {
                MessageBox.Show("Max concurrent requests has to be a whole number of at least one.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TextBoxControl_BatchSize.TryGetValue(out int batchSize) || batchSize < 1)
            {
                MessageBox.Show("Batch size has to be a whole number of at least one.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // The runner clamps whatever arrives here to the endpoint's cap before it sends anything, but it
            // does so silently - refusing it in front of the operator is the difference between a value nobody
            // meant and a value nobody was told about.
            if (!TextBoxControl_ReferenceBatchSize.TryGetValue(out int referenceBatchSize) || referenceBatchSize < 1 || referenceBatchSize > Constants.Count.BuildingDataReference_Maximum)
            {
                MessageBox.Show($"Reference batch size has to be a whole number between one and {Constants.Count.BuildingDataReference_Maximum} - the building data endpoint refuses more.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<AdministrativeAreal2DReference>? administrativeAreal2DReferences = ListBoxControl_Counties.GetItems<AdministrativeAreal2DReference>();
            if (administrativeAreal2DReferences is null || administrativeAreal2DReferences.Count == 0)
            {
                // An empty set is not the same as no set: the run takes it as "no county was named" and stops, so
                // it must never leave this window.
                MessageBox.Show("At least one county has to be selected.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            HashSet<int> countyIds = [];
            foreach (AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences)
            {
                countyIds.Add(administrativeAreal2DReference.Id);
            }

            yearBuiltPredictionPipelineOptions.ScratchDirectory = scratchDirectory;
            yearBuiltPredictionPipelineOptions.Confidence = confidence;
            yearBuiltPredictionPipelineOptions.CountyIds = countyIds;

            yearBuiltPredictionPipelineOptions.MaxConcurrentRequests = maxConcurrentRequests;
            yearBuiltPredictionPipelineOptions.BatchSize = batchSize;
            yearBuiltPredictionPipelineOptions.ReferenceBatchSize = referenceBatchSize;

            // An empty path is not a path: null is what makes the runner search PATH for an interpreter and the
            // script search for its own weights, while an empty string is a path that resolves to nothing.
            yearBuiltPredictionPipelineOptions.PythonPath = Value(TextBoxControl_PythonPath.Value);
            yearBuiltPredictionPipelineOptions.ModelPath = Value(TextBoxControl_ModelPath.Value);
            yearBuiltPredictionPipelineOptions.WorkingDirectory = Value(TextBoxControl_WorkingDirectory.Value);

            // Resume and CleanScratchDirectory interact: with cleanup on, a county that completes leaves nothing
            // on disk for a later run to resume into, so the two checkboxes sit together in the dialog and only
            // a combination the operator actually asked for is written.
            yearBuiltPredictionPipelineOptions.ExportImages = CheckBox_ExportImages.IsChecked == true;
            yearBuiltPredictionPipelineOptions.RunPrediction = CheckBox_RunPrediction.IsChecked == true;
            yearBuiltPredictionPipelineOptions.Score = CheckBox_Score.IsChecked == true;
            yearBuiltPredictionPipelineOptions.Resume = CheckBox_Resume.IsChecked == true;
            yearBuiltPredictionPipelineOptions.CleanScratchDirectory = CheckBox_CleanScratchDirectory.IsChecked == true;

            yearBuiltPredictionPipelineOptions.UpdateDetections = CheckBox_UpdateDetections.IsChecked == true;
            yearBuiltPredictionPipelineOptions.UpdateYearBuiltData = CheckBox_UpdateYearBuiltData.IsChecked == true;
            yearBuiltPredictionPipelineOptions.UpdatePredictedYearBuilt = CheckBox_UpdatePredictedYearBuilt.IsChecked == true;

            // Years and Radiuses have no control here on purpose: they decide which columns the feature
            // projection asks for, and a range narrower than the one the regressor was trained on hands the
            // model type defaults instead of features - it scores without failing, and the predictions are
            // worse by an amount nothing measures (ZiolkowskiJakub/DiGi.GIS.ML#6). They carry through the copy
            // untouched, as does anything else this window is not responsible for.

            DialogResult = true;
            Close();

            static string? Value(string? text)
            {
                return string.IsNullOrWhiteSpace(text) ? null : text!.Trim();
            }
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

            HashSet<int>? countyIds = yearBuiltPredictionPipelineOptions.CountyIds;
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
