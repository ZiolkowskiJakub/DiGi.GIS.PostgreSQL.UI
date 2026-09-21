using DiGi.Core.Classes;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// Provides configuration options for generating BuildingModels from CityGML Buildings stored in a database.
    /// <para>Held by the user interface task rather than by a class library task, so it lives in this project: the run it configures is started from the user interface, through <see cref="Windows.BuildingModelsFromDatabaseOptionsWindow"/>.</para>
    /// <para>Carries the scope of a run only. The request pacing and the page size are tuning nobody changes between runs, so they stay properties of the task and are set where it is registered.</para>
    /// </summary>
    public class BuildingModelsFromDatabaseOptions : SerializableOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingModelsFromDatabaseOptions"/> class using the provided JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the configuration data used to populate the options.</param>
        public BuildingModelsFromDatabaseOptions(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingModelsFromDatabaseOptions"/> class.
        /// </summary>
        public BuildingModelsFromDatabaseOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingModelsFromDatabaseOptions"/> class by copying the values from an existing <see cref="BuildingModelsFromDatabaseOptions"/> instance.
        /// </summary>
        /// <param name="buildingModelsFromDatabaseOptions">The source <see cref="BuildingModelsFromDatabaseOptions"/> instance to copy settings from.</param>
        public BuildingModelsFromDatabaseOptions(BuildingModelsFromDatabaseOptions? buildingModelsFromDatabaseOptions)
            : base(buildingModelsFromDatabaseOptions)
        {
            if (buildingModelsFromDatabaseOptions is not null)
            {
                Resume = buildingModelsFromDatabaseOptions.Resume;
                ReportDirectory = buildingModelsFromDatabaseOptions.ReportDirectory;
                CountyIds = buildingModelsFromDatabaseOptions.CountyIds is null ? null : [.. buildingModelsFromDatabaseOptions.CountyIds];
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether counties named in the checkpoint of an earlier run are skipped.
        /// <para>A national pass is a matter of days, so it has to survive being interrupted. Turning this off starts from the first county in scope and truncates the checkpoint, which is what a deliberate re-run of an already-completed scope needs.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Resume))]
        public bool Resume { get; set; } = true;

        /// <summary>
        /// Gets or sets the directory the checkpoint and the list of failed counties are written into. When null the directory the application was launched from is used.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ReportDirectory))]
        public string? ReportDirectory { get; set; } = null;

        /// <summary>
        /// Gets or sets the county polygon part identifiers to be processed. <see langword="null"/> means every county.
        /// <para>A county code is not a key - a multi-part county has one identifier per polygon part - so name every part that is wanted.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CountyIds))]
        public HashSet<int>? CountyIds { get; set; } = null;
    }
}
