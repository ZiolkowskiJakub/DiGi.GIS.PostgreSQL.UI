using DiGi.GIS.Classes;
using DiGi.GIS.Constants;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    public class UIBuilding2DsPostTask : Building2DsPostTask, IGISPostgreSQLUIObject
    {
        public UIBuilding2DsPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        /// <summary>
        /// Concrete implementation of the background work.
        /// </summary>
        protected override async Task<bool> ExecuteAsync()
        {
            if (Values is not null)
            {
                return await base.ExecuteAsync();
            }

            string? code = Code;

            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want select single GIS Model file?", "Selection", MessageBoxButton.YesNoCancel);
            if (messageBoxResult == MessageBoxResult.Cancel)
            {
                return false;
            }

            List<string> paths_GISModel = [];
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                OpenFileDialog openFileDialog = new()
                {
                    Title = "Select GIS Model file",
                    Filter = string.Format("{0} (*.{1})|*.{1}|All files (*.*)|*.*", FileTypeName.GISModelFile, FileExtension.GISModelFile)
                };

                bool? dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == null || !dialogResult.HasValue || !dialogResult.Value)
                {
                    return false;
                }

                paths_GISModel.Add(openFileDialog.FileName);
            }
            else
            {
                OpenFolderDialog openFolderDialog = new();
                bool? dialogResult = openFolderDialog.ShowDialog();
                if (dialogResult == null || !dialogResult.HasValue || !dialogResult.Value)
                {
                    return false;
                }

                string directory = openFolderDialog.FolderName;
                if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
                {
                    return false;
                }

                string[] paths_Input = Directory.GetFiles(directory, "*." + FileExtension.GISModelFile, SearchOption.AllDirectories);
                if (paths_Input == null || paths_Input.Length == 0)
                {
                    return false;
                }

                paths_GISModel = [.. paths_Input];
            }

            if (paths_GISModel is null || paths_GISModel.Count == 0)
            {
                return true;
            }

            foreach (string path_GISModel in paths_GISModel)
            {
                if (string.IsNullOrWhiteSpace(path_GISModel) || !System.IO.File.Exists(path_GISModel))
                {
                    return false;
                }

                using GISModelFile gISModelFile = new(path_GISModel);

                gISModelFile.Open();

                GISModel? gISModel = gISModelFile.Value;

                List<Building2D>? building2Ds = gISModel?.GetObjects<Building2D>();

                if (building2Ds is null || building2Ds.Count == 0)
                {
                    continue;
                }

                string? code_GISModel = gISModel!.Reference;
                if (!string.IsNullOrWhiteSpace(code_GISModel))
                {
                    code_GISModel = code_GISModel.ToUpper();
                    int index = code_GISModel.IndexOf('_');
                    if (index != -1)
                    {
                        code_GISModel = code_GISModel[..index];
                    }
                }

                Values = building2Ds;
                Code = code_GISModel;

                bool succeeded = false;
                try
                {
                    succeeded = await base.ExecuteAsync();
                }
                catch
                {
                    Code = code;
                    Values = null;
                    throw;
                }

                if (!succeeded)
                {
                    return false;
                }
            }

            Code = code;
            Values = null;
            return true;
        }
    }
}