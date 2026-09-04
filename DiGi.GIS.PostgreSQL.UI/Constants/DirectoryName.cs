namespace DiGi.GIS.PostgreSQL.UI.Constants
{
    /// <summary>
    /// Provides constant directory names used within the GIS PostgreSQL UI.
    /// </summary>
    public static class DirectoryName
    {
        /// <summary>
        /// Gets the name of the folder a county's exported orthophoto prediction images are written to.
        /// </summary>
        public const string PredictionImages = "images";

        /// <summary>
        /// Gets the name of the folder beside this application's executable that standalone tools are deployed into.
        /// </summary>
        /// <remarks>Not the same convention as <c>DiGi.WebAPI.WindowsService</c>'s <c>extensions</c> folder, which holds plugin assemblies loaded into the host process through an <c>AssemblyLoadContext</c>. Nothing under this one is loaded into this application at all - each subfolder is a self contained executable started as its own process, with its own dependency closure and its own configuration files.</remarks>
        public const string Extensions = "extensions";

        /// <summary>
        /// Gets the name of the folder under <see cref="Extensions"/> that the headless Year Built prediction runner is deployed into.
        /// </summary>
        /// <remarks>Assembled by <c>DiGi.Maintenance/Scripts/SyncDirectories.ps1</c> when <c>IncludeYearBuiltPredictionExtension</c> is set, into this application's own build output, so that the deployment carries it as part of this application rather than as a folder of its own. A machine that will never score a building is deployed without it and simply does not offer the task.</remarks>
        public const string YearBuiltPredictionExtension = "DiGi.GIS.YOLO.UI.ConsoleApp";
    }
}
