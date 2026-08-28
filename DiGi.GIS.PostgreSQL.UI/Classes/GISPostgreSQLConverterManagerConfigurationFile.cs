using DiGi.Core.Classes;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// Represents a configuration file specifically for the GIS PostgreSQL converter manager settings, extending the base configuration file functionality.
    /// </summary>
    public class GISPostgreSQLConverterManagerConfigurationFile : ConfigurationFile, IGISPostgreSQLUIObject
    {
        /// <summary>
        /// Initializes a new empty instance of the <see cref="GISPostgreSQLConverterManagerConfigurationFile"/> class.
        /// </summary>
        public GISPostgreSQLConverterManagerConfigurationFile()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GISPostgreSQLConverterManagerConfigurationFile"/> class from a <see cref="JsonObject"/>.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the configuration data.</param>
        public GISPostgreSQLConverterManagerConfigurationFile(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GISPostgreSQLConverterManagerConfigurationFile"/> class by copying settings from another <see cref="ConfigurationFile"/>.
        /// </summary>
        /// <param name="configurationFile">The source configuration file to copy settings from.</param>
        public GISPostgreSQLConverterManagerConfigurationFile(ConfigurationFile? configurationFile)
            : base(configurationFile)
        {
        }

        /// <summary>
        /// Gets or sets the API authorization key used for authenticating requests to protected Web API endpoints.
        /// </summary>
        [JsonIgnore]
        public string? Key
        {
            get
            {
                return GetValue<string>(Constants.Names.GISPostgreSQLConverterManagerConfigurationFile.Key);
            }

            set
            {
                Add(Constants.Names.GISPostgreSQLConverterManagerConfigurationFile.Key, value);
            }
        }
    }
}
