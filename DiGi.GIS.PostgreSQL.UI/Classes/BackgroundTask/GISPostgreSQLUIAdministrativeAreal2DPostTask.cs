using DiGi.GIS.Classes;
using DiGi.GIS.Constants;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    public class GISPostgreSQLUIAdministrativeAreal2DPostTask : GISPostgreSQLWebAPIAdministrativeAreal2DPostTask, IGISPostgreSQLUIObject
    {
        public GISPostgreSQLUIAdministrativeAreal2DPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        /// <summary>
        /// Concrete implementation of the background work.
        /// </summary>
        protected override async Task<bool> ExecuteAsync()
        {
            bool clear = false;

            if(AdministrativeAreal2Ds is null)
            {
                bool? dialogResult;

                OpenFileDialog openFileDialog = new()
                {
                    Title = "Select GIS Model file",
                    Filter = string.Format("{0} (*.{1})|*.{1}|All files (*.*)|*.*", FileTypeName.GISModelFile, FileExtension.GISModelFile)
                };
                dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == null || !dialogResult.HasValue || !dialogResult.Value)
                {
                    return false;
                }

                string path_GISModel = openFileDialog.FileName;

                if(string.IsNullOrWhiteSpace(path_GISModel) || !System.IO.File.Exists(path_GISModel))
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

                    AdministrativeAreal2Ds = administrativeAreal2Ds;
                }

                clear = true;
            }

            if(AdministrativeAreal2Ds is null)
            {
                return false;
            }

            bool result =  await base.ExecuteAsync();
            if(clear)
            {
                AdministrativeAreal2Ds = null;
            }

            return result;
        }
    }
}