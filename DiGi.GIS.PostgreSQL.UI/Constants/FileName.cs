namespace DiGi.GIS.PostgreSQL.UI.Constants
{
    /// <summary>
    /// Provides constant values for configuration file names used within the GIS PostgreSQL UI.
    /// </summary>
    public static class FileName
    {
        /// <summary>
        /// Gets the default filename of the configuration file for the Web API client.
        /// </summary>
        public const string GISWebAPIClientConfigurationFile = "GIS_WebAPI_Client.conf";

        /// <summary>
        /// Gets the file name of the headless Year Built prediction runner.
        /// </summary>
        /// <remarks>The pipeline itself is not hosted in this application - it carries the machine learning closure, which is about a gigabyte of native libraries against an application that publishes self-contained and single-file. The run is handed to this executable instead, and <see cref="Query.YearBuiltPredictionConsoleAppPath"/> is what finds it.</remarks>
        public const string YearBuiltPredictionConsoleApp = "DiGi.GIS.YOLO.UI.ConsoleApp.exe";

        /// <summary>
        /// Gets the file name of the deployed YOLO detector - the weights a Re-train run starts from and the incumbent a training run is gated against. No training run ever writes it.
        /// </summary>
        public const string Model = "model.pt";

        /// <summary>
        /// Gets the file name of the pretrained YOLO base checkpoint a fresh training run starts from. Its SHA-256 is recorded in the DiGi.YOLO README.
        /// </summary>
        public const string BaseModel = "yolo26x.pt";

        /// <summary>
        /// Gets the suffix of the file a tray training run's options are written to, beside the run folder as <c>&lt;RunName&gt;.YOLOTrainingRunOptions.json</c>.
        /// </summary>
        /// <remarks>Beside the run folder rather than inside it: the runner refuses a run whose folder already exists, so writing into it first would refuse every run.</remarks>
        public const string YOLOTrainingRunOptionsSuffix = "." + DiGi.GIS.YOLO.UI.Constants.FileName.YOLOTrainingRunOptions;

        /// <summary>
        /// Gets the infix of the file a tray resume's options are written to, beside the run folder as <c>&lt;RunName&gt;.resume-&lt;yyyyMMdd_HHmmss&gt;.YOLOTrainingRunOptions.json</c>.
        /// </summary>
        /// <remarks>The original run's <c>&lt;RunName&gt;.YOLOTrainingRunOptions.json</c> is the record of what that run was asked to do, so a resume never overwrites it - the resume gets a file of its own.</remarks>
        public const string YOLOTrainingRunOptionsResumeInfix = ".resume-";
    }
}
