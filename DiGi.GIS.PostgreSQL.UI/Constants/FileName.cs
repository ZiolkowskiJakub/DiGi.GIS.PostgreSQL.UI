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
    }
}
