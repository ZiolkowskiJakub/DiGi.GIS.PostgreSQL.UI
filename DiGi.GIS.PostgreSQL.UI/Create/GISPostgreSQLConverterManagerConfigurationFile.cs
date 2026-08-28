using DiGi.Core.Classes;
using DiGi.GIS.PostgreSQL.UI.Classes;
using System.IO;
using System.Reflection;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Create
    {
        /// <summary>
        /// Creates a new instance of a <see cref="GISPostgreSQLConverterManagerConfigurationFile"/> from the specified path or default location.
        /// </summary>
        /// <param name="path">The optional path to the configuration file. If omitted, resolves from the executing assembly's location.</param>
        /// <returns>A <see cref="GISPostgreSQLConverterManagerConfigurationFile"/> instance if successful; otherwise, null.</returns>
        public static GISPostgreSQLConverterManagerConfigurationFile? GISPostgreSQLConverterManagerConfigurationFile(string? path = null)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                string? directory_ExecutingAssembly = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (string.IsNullOrWhiteSpace(directory_ExecutingAssembly) || !Directory.Exists(directory_ExecutingAssembly))
                {
                    return null;
                }

                path = System.IO.Path.Combine(directory_ExecutingAssembly, Constants.FileName.GISWebAPIClientConfigurationFile);
            }

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            ConfigurationFile? configurationFile = Core.Create.ConfigurationFile(path);
            if (configurationFile is null)
            {
                return null;
            }

            return new GISPostgreSQLConverterManagerConfigurationFile(configurationFile);
        }
    }
}
