using DiGi.Core;
using DiGi.GIS.Classes;
using DiGi.GIS.Constants;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    public class GISPostgreSQLUIBuilding2DPostTask : GISPostgreSQLWebAPIBuilding2DPostTask, IGISPostgreSQLUIObject
    {
        public GISPostgreSQLUIBuilding2DPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        /// <summary>
        /// Concrete implementation of the background work.
        /// </summary>
        protected override async Task<bool> ExecuteAsync()
        {
            bool clear = false;

            if(Building2Ds is null)
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

                List<Building2D> building2Ds = [];

                HashSet<string>? references = gISModel?.GetReferences<Building2D>();
                if (references is not null)
                {
                    foreach (string reference in references)
                    {
                        Building2D? building2D = gISModel!.GetObject<Building2D>(reference);
                        if (building2D is not null)
                        {
                            building2Ds.Add(building2D);
                        }
                    }

                    Building2Ds = building2Ds;
                }

                clear = true;
            }

            if(Building2Ds is null)
            {
                return false;
            }

            bool result =  await base.ExecuteAsync();
            if(clear)
            {
                Building2Ds = null;
            }

            return result;
        }
    }
}