using DiGi.GIS.Constants;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.PostgreSQL.WebAPI;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    public class UIUpdateFromFilePostTask : Building2DsPostTask, IGISPostgreSQLUIObject
    {
        public UIUpdateFromFilePostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        /// <summary>
        /// Concrete implementation of the background work.
        /// </summary>
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            bool? result;

            OpenFileDialog openFileDialog = new()
            {
                Filter = "zip files (*.zip)|*.zip|All files (*.*)|*.*"
            };
            result = openFileDialog.ShowDialog();
            if (result == null || !result.HasValue || !result.Value)
            {
                return false;
            }

            string path = openFileDialog.FileName;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return false;
            }

            DiGi.UI.WPF.Windows.ListBoxWindow listBoxWindow = new("File types")
            {
                SelectionMode = System.Windows.Controls.SelectionMode.Multiple
            };

            listBoxWindow.SetItems([FileNameSufix.OT_ADJA_A, FileNameSufix.OT_ADMS_A, FileNameSufix.OT_BUBD_A]);

            bool? dialogResult = listBoxWindow.ShowDialog();
            if (dialogResult is null || !dialogResult.Value)
            {
                return false;
            }

            List<string>? sufixes = listBoxWindow.GetItems<string>();
            if (sufixes is null || sufixes.Count == 0)
            {
                return false;
            }

            return await GISPostgreSQLWebAPIManager.UpdateItemsAsync(path, sufixes.Contains(FileNameSufix.OT_ADJA_A), sufixes.Contains(FileNameSufix.OT_ADMS_A), sufixes.Contains(FileNameSufix.OT_BUBD_A), new PostOptions(), progress, cancellationToken);
        }
    }
}