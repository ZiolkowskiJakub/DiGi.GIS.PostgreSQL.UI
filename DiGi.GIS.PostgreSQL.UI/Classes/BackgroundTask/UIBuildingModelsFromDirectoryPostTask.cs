using DiGi.CityGML.Classes;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// A UI-driven post task that prompts the user to select a directory, reads CityGML city models from it, fetches building 2D data per county from the server, generates <see cref="DiGi.Analytical.Building.Classes.BuildingModel"/> instances, and uploads them in batches.
    /// </summary>
    public class UIBuildingModelsFromDirectoryPostTask : BuildingModelsPostTask, IGISPostgreSQLUIObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIBuildingModelsFromDirectoryPostTask"/> class.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to communicate with the server.</param>
        public UIBuildingModelsFromDirectoryPostTask(GISWebAPIManager GISWebAPIManager)
            : base(GISWebAPIManager)
        {
        }

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            if (Values is not null)
            {
                return await base.ExecuteAsync(progress, cancellationToken);
            }

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

            List<CityModel>? cityModels = CityGML.Create.CityModels(directory);
            if(cityModels is null || cityModels.Count == 0)
            {
                return false;
            }

            HttpClient? httpClient_AdministrativeAreal2D = GISWebAPIManager.CreateHttpClient<AdministrativeAreal2DController>(nameof(AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync), out string? path_AdministrativeAreal2D);
            if (httpClient_AdministrativeAreal2D is null || string.IsNullOrWhiteSpace(path_AdministrativeAreal2D))
            {
                return false;
            }

            string requestUri_AdministrativeAreal2D = new UrlBuilder(path_AdministrativeAreal2D).ToString();

            PostOptions postOptions = new() { RequestResult = true };

            PostResponse<List<AdministrativeAreal2DReference>?> postResponse_AdministrativeAreal2DReferences = await DiGi.WebAPI.Modify.PostAsync<List<AdministrativeAreal2DReference>>(httpClient_AdministrativeAreal2D, requestUri_AdministrativeAreal2D, null, postOptions);
            if (postResponse_AdministrativeAreal2DReferences is null || !postResponse_AdministrativeAreal2DReferences.Succeeded || postResponse_AdministrativeAreal2DReferences.Result is not List<AdministrativeAreal2DReference> administrativeAreal2DReferences)
            {
                return false;
            }

            HttpClient? httpClient_Building2D = GISWebAPIManager.CreateHttpClient<Building2DController>(nameof(Building2DController.GetItemsByCountyIdAsync), out string? path_Building2D);
            if (httpClient_Building2D is null || string.IsNullOrWhiteSpace(path_Building2D))
            {
                return false;
            }

            Core.Classes.LongProgressWrapper? longProgressWrapper = Core.Create.LongProgressWrapper(progress);

            foreach (AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences)
            {
                if (administrativeAreal2DReference.CountryId is not int countyId)
                {
                    continue;
                }

                string requestUri_Building2D = new UrlBuilder(path_Building2D).AddParameter("countyid", countyId).ToString();

                PostResponse<List<GIS.Classes.Building2D>?> postResponse_Building2D = await DiGi.WebAPI.Modify.PostAsync<List<GIS.Classes.Building2D>>(httpClient_Building2D, requestUri_Building2D, null, postOptions);
                if (postResponse_Building2D is null || !postResponse_Building2D.Succeeded || postResponse_Building2D.Result is not List<GIS.Classes.Building2D> building2Ds)
                {
                    continue;
                }

                List<DiGi.Analytical.Building.Classes.BuildingModel>? buildingModels = Analytical.Create.BuildingModels(building2Ds, cityModels);
                if(buildingModels is null || buildingModels.Count == 0)
                {
                    continue;
                }

                List<DiGi.Analytical.Building.Classes.BuildingModel>? buildingModels_Split;

                Core.Classes.SizeSplitter<DiGi.Analytical.Building.Classes.BuildingModel> sizeSplitter = new(buildingModels);
                while ((buildingModels_Split = sizeSplitter.Next(100)) is not null)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    bool succeeded = false;
                    try
                    {
                        succeeded = await ExecuteAsync(buildingModels_Split, longProgressWrapper, cancellationToken);
                    }
                    catch
                    {
                        throw;
                    }

                    if (!succeeded)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
