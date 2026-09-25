using DiGi.Analytical.Building.Enums;
using DiGi.Core.Classes;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// Provides configuration options for stamping the WGS 84 coordinates and the UTC offset onto the <c>BuildingInformation</c> of the stored <see cref="DiGi.Analytical.Building.Classes.BuildingModel"/> records.
    /// <para>Held by the user interface task rather than by a class library task, so it lives in this project: the run it configures is started from the user interface, through <see cref="Windows.PostgreSQLBuildingModelBuildingInformationUpdateOptionsWindow"/>.</para>
    /// <para>Carries the scope of a run: the county polygon parts, the detail level, the page size, the statement timeout, the checkpoint behaviour and the report directory. A null county set means every county and a null level means every level whose table exists.</para>
    /// </summary>
    public class PostgreSQLBuildingModelBuildingInformationUpdateOptions : SerializableOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSQLBuildingModelBuildingInformationUpdateOptions"/> class using the provided JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the configuration data used to populate the options.</param>
        public PostgreSQLBuildingModelBuildingInformationUpdateOptions(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSQLBuildingModelBuildingInformationUpdateOptions"/> class.
        /// </summary>
        public PostgreSQLBuildingModelBuildingInformationUpdateOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSQLBuildingModelBuildingInformationUpdateOptions"/> class by copying the values from an existing <see cref="PostgreSQLBuildingModelBuildingInformationUpdateOptions"/> instance.
        /// </summary>
        /// <param name="options">The source <see cref="PostgreSQLBuildingModelBuildingInformationUpdateOptions"/> instance to copy settings from.</param>
        public PostgreSQLBuildingModelBuildingInformationUpdateOptions(PostgreSQLBuildingModelBuildingInformationUpdateOptions? options)
            : base(options)
        {
            if (options is not null)
            {
                CountyIds = options.CountyIds is null ? null : [.. options.CountyIds];
                BuildingModelDetailLevel = options.BuildingModelDetailLevel;
                DryRun = options.DryRun;
                BatchSize = options.BatchSize;
                CommandTimeout = options.CommandTimeout;
                Resume = options.Resume;
                ReportDirectory = options.ReportDirectory;
            }
        }

        /// <summary>
        /// Gets or sets the county polygon part identifiers to be processed. <see langword="null"/> means every county.
        /// <para>A county code is not a key - a multi-part county has one identifier per polygon part - so name every part that is wanted.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CountyIds))]
        public HashSet<int>? CountyIds { get; set; } = null;

        /// <summary>
        /// Gets or sets the detail level of the building model table to walk. <see langword="null"/> walks every level whose table exists.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(BuildingModelDetailLevel))]
        public BuildingModelDetailLevel? BuildingModelDetailLevel { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether the run only reports what it would stamp. Defaults to <see langword="true"/>; nothing is written until it is turned off.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(DryRun))]
        public bool DryRun { get; set; } = true;

        /// <summary>
        /// Gets or sets the number of rows read and classified per page.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(BatchSize))]
        public int BatchSize { get; set; } = 500;

        /// <summary>
        /// Gets or sets the timeout in seconds applied to the statements. A value of 0 disables the timeout.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CommandTimeout))]
        public int CommandTimeout { get; set; } = 120;

        /// <summary>
        /// Gets or sets a value indicating whether the parts named in the checkpoint of an earlier run are skipped. Defaults to <see langword="true"/>.
        /// <para>The national pass has to survive being interrupted mid-country, so it resumes rather than restarting from the first part. Turning this off starts from the first part in scope and truncates the checkpoint, which is what a deliberate re-run of an already-completed scope needs.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Resume))]
        public bool Resume { get; set; } = true;

        /// <summary>
        /// Gets or sets the directory the checkpoint and the reports are written into. When null the directory the application was launched from is used.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ReportDirectory))]
        public string? ReportDirectory { get; set; } = null;
    }
}
