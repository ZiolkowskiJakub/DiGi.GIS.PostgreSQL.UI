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
    public class UIAdministrativeAreal2DPostTask : AdministrativeAreal2DsPostTask, IGISPostgreSQLUIObject
    {
        public UIAdministrativeAreal2DPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
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
                if (string.IsNullOrWhiteSpace(path_GISModel) || !File.Exists(path_GISModel))
                {
                    return false;
                }

                using GISModelFile gISModelFile = new(path_GISModel);

                gISModelFile.Open();

                GISModel? gISModel = gISModelFile.Value;

                List<AdministrativeAreal2D> administrativeAreal2Ds = [];

                HashSet<string>? references = gISModel?.GetReferences<AdministrativeAreal2D>();
                if (references is not null)
                {
                    foreach (string reference in references)
                    {
                        AdministrativeAreal2D? administrativeAreal2D = gISModel!.GetObject<AdministrativeAreal2D>(reference);
                        if (administrativeAreal2D is not null)
                        {
                            administrativeAreal2Ds.Add(administrativeAreal2D);
                        }
                    }

                    Values = administrativeAreal2Ds;

                    bool succeeded = await base.ExecuteAsync();
                    if (!succeeded)
                    {
                        return false;
                    }
                }
            }

            Values = null;
            return true;
        }
    }
}