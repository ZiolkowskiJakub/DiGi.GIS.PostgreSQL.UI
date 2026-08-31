using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// Represents a task for creating the statistical data collection table in PostgreSQL and populating it from .sdcf files in a directory selected through the user interface.
    /// </summary>
    public class UIPostgreSQLStatisticalDataCollectionCreateTableTask : PostgreSQLStatisticalDataCollectionCreateTableTask, IGISPostgreSQLUIObject
    {
        private readonly StatisticalDataCollectionPostgreSQLConverter statisticalDataCollectionPostgreSQLConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIPostgreSQLStatisticalDataCollectionCreateTableTask"/> class with a statistical data collection PostgreSQL converter.
        /// </summary>
        /// <param name="statisticalDataCollectionPostgreSQLConverter">The statistical data collection PostgreSQL converter used to create and populate the table.</param>
        public UIPostgreSQLStatisticalDataCollectionCreateTableTask(StatisticalDataCollectionPostgreSQLConverter statisticalDataCollectionPostgreSQLConverter)
            : base(statisticalDataCollectionPostgreSQLConverter)
        {
            this.statisticalDataCollectionPostgreSQLConverter = statisticalDataCollectionPostgreSQLConverter ?? throw new ArgumentNullException(nameof(statisticalDataCollectionPostgreSQLConverter));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIPostgreSQLStatisticalDataCollectionCreateTableTask"/> class from a manager.
        /// </summary>
        /// <param name="gISPostgreSQLConverterManager">The GIS PostgreSQL converter manager containing the statistical data collection converter.</param>
        public UIPostgreSQLStatisticalDataCollectionCreateTableTask(GISPostgreSQLConverterManager gISPostgreSQLConverterManager)
            : base(gISPostgreSQLConverterManager)
        {
            if (gISPostgreSQLConverterManager is null)
            {
                throw new ArgumentNullException(nameof(gISPostgreSQLConverterManager));
            }

            statisticalDataCollectionPostgreSQLConverter = gISPostgreSQLConverterManager.GetPostgreSQLConverter<StatisticalDataCollectionPostgreSQLConverter>() ?? throw new InvalidOperationException($"{nameof(StatisticalDataCollectionPostgreSQLConverter)} not registered in converter manager.");
        }

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync()
        {
            if (System.Windows.Application.Current is not System.Windows.Application application)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "No WPF application is running - the statistical data collection options cannot be asked for");
                return false;
            }

            string? directory = null;

            application.Dispatcher.Invoke(() =>
            {
                OpenFolderDialog openFolderDialog = new()
                {
                    Title = "Select directory containing *.sdcf files"
                };

                if (openFolderDialog.ShowDialog() is true)
                {
                    directory = openFolderDialog.FolderName;
                }
            });

            if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
            {
                return false;
            }

            bool tableCreated = await base.ExecuteAsync();
            if (!tableCreated)
            {
                return false;
            }

            return await statisticalDataCollectionPostgreSQLConverter.PopulateAsync(directory, clear: false, commandTimeout: 600);
        }
    }
}
