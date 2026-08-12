using DiGi.Core.Classes;
using DiGi.GIS.Analytical.Enums;
using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.Enums;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// A UI-driven task that reads the <see cref="DiGi.Analytical.Building.Classes.BuildingModel"/> records already stored on the server and reports how complete and how sound they are.
    /// <para>Read-only. Nothing is uploaded, nothing is repaired - the task exists to say what the stored data looks like, which is the state the upload path itself never reported: a model whose spaces are not enclosed is accepted by the server today and stored without a word.</para>
    /// <para>For every county in scope a sample of <see cref="SampleSize"/> 2D building references is drawn with <see cref="RandomSeed"/>, so a run is reproducible and two runs can be compared. The models behind those references are pulled in batches and each one is passed through <c>Analytical.Create.BuildingModelValidationResult</c>. A reference the server holds no model for is recorded as missing, which is the completeness half of the answer.</para>
    /// <para>Two files are written into <see cref="ReportDirectory"/>: one row per reference in <c>BuildingModels_Verification.csv</c>, and per county plus national totals in <c>BuildingModels_Verification_Summary.txt</c>. The row file is flushed county by county, so a run interrupted late still leaves everything it had already measured.</para>
    /// </summary>
    public class UIBuildingModelsVerificationTask : ReportableBackgroundTask<long>, IGISPostgreSQLUIObject
    {
        private readonly GISWebAPIManager GISWebAPIManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIBuildingModelsVerificationTask"/> class.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to communicate with the server.</param>
        public UIBuildingModelsVerificationTask(GISWebAPIManager GISWebAPIManager)
        {
            this.GISWebAPIManager = GISWebAPIManager;
        }

        /// <summary>
        /// Gets or sets the number of references asked for in a single request. The references travel in the query string, so a batch far above this risks the URL length limit of the server.
        /// </summary>
        public int BatchSize { get; set; } = 50;

        /// <summary>
        /// Gets or sets the identifiers of the counties to be processed. When null every county held on the server is processed.
        /// </summary>
        public IEnumerable<int>? CountyIds { get; set; } = null;

        /// <summary>
        /// Gets or sets the seed of the sampling. Two runs sharing a seed draw the same references, which is what lets a run before a change be compared with one after it.
        /// </summary>
        public int RandomSeed { get; set; } = 0;

        /// <summary>
        /// Gets or sets the directory the two report files are written into. When null the user is asked for one.
        /// </summary>
        public string? ReportDirectory { get; set; } = null;

        /// <summary>
        /// Gets or sets the number of references drawn per county. A value of zero or less takes every reference of the county.
        /// </summary>
        public int SampleSize { get; set; } = 200;

        /// <summary>
        /// Gets or sets the distance tolerance the enclosure of a space is required to hold at.
        /// </summary>
        public double Tolerance { get; set; } = Analytical.Constants.Tolerance.Enclosure;

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            string? directory = ReportDirectory;
            if (string.IsNullOrWhiteSpace(directory))
            {
                OpenFolderDialog openFolderDialog = new();
                bool? dialogResult = openFolderDialog.ShowDialog();
                if (dialogResult is null || !dialogResult.HasValue || !dialogResult.Value)
                {
                    return false;
                }

                directory = openFolderDialog.FolderName;
            }

            if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Report directory does not exist");
                return false;
            }

            HttpClient? httpClient_AdministrativeAreal2D = GISWebAPIManager.CreateHttpClient<AdministrativeAreal2DController>(nameof(AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync), out string? path_AdministrativeAreal2D);
            if (httpClient_AdministrativeAreal2D is null || string.IsNullOrWhiteSpace(path_AdministrativeAreal2D))
            {
                return false;
            }

            HttpClient? httpClient_References = GISWebAPIManager.CreateHttpClient<Building2DController>(nameof(Building2DController.GetReferencesByCountyIdAsync), out string? path_References);
            if (httpClient_References is null || string.IsNullOrWhiteSpace(path_References))
            {
                return false;
            }

            HttpClient? httpClient_BuildingModel = GISWebAPIManager.CreateHttpClient<BuildingModelController>(nameof(BuildingModelController.GetItemsByReferencesAsync), out string? path_BuildingModel);
            if (httpClient_BuildingModel is null || string.IsNullOrWhiteSpace(path_BuildingModel))
            {
                return false;
            }

            PostOptions postOptions = new() { RequestResult = true };

            // The endpoint is a HttpGet action and its administrativearealtype parameter is not nullable - omitting it binds to Country, not County.
            string requestUri_AdministrativeAreal2D = new UrlBuilder(path_AdministrativeAreal2D).AddParameter("administrativearealtype", (int)AdministrativeArealType.County).ToString();

            PostResponse<List<AdministrativeAreal2DReference>?> postResponse_AdministrativeAreal2DReferences = await DiGi.WebAPI.Query.GetAsync<List<AdministrativeAreal2DReference>>(httpClient_AdministrativeAreal2D, requestUri_AdministrativeAreal2D, postOptions);
            if (postResponse_AdministrativeAreal2DReferences is null || !postResponse_AdministrativeAreal2DReferences.Succeeded || postResponse_AdministrativeAreal2DReferences.Result is not List<AdministrativeAreal2DReference> administrativeAreal2DReferences)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "County references could not be retrieved");
                return false;
            }

            HashSet<int>? countyIds = null;
            if (CountyIds is not null)
            {
                countyIds = [.. CountyIds];
                if (countyIds.Count == 0)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "CountyIds is empty - nothing to verify");
                    return false;
                }
            }

            int batchSize = BatchSize < 1 ? 1 : BatchSize;

            Random random = new(RandomSeed);

            LongProgressWrapper? longProgressWrapper = Core.Create.LongProgressWrapper(progress);

            List<string> summaryLines =
            [
                "=== BUILDING MODEL VERIFICATION ===",
                $"Started: {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                $"Enclosure tolerance: {Tolerance.ToString(System.Globalization.CultureInfo.InvariantCulture)}",
                $"Sample size per county: {(SampleSize < 1 ? "all" : SampleSize.ToString())}",
                $"Random seed: {RandomSeed}",
                string.Empty,
                "Code;CountyId;Requested;Missing;Valid;Invalid;NotEnclosed;SeaLevel;SpacePointOutsideShell",
            ];

            Dictionary<BuildingModelValidationCode, int> counts_ByValidationCode = [];
            Dictionary<double, int> counts_ByMinEnclosingTolerance = [];

            long count_Requested = 0;
            long count_Missing = 0;
            long count_Valid = 0;
            long count_Invalid = 0;

            using StreamWriter streamWriter = new(System.IO.Path.Combine(directory, "BuildingModels_Verification.csv"), false, Encoding.UTF8);
            await streamWriter.WriteLineAsync("Code;CountyId;Reference;Status;SpaceCount;ComponentCount;ShellCount;EnclosedShellCount;MinEnclosingTolerance;MinZ;MaxZ;ValidationCodes");

            foreach (AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Id identifies the county itself - CountryId/VoivodeshipId/CountyId are the parent chain.
                int countyId = administrativeAreal2DReference.Id;
                if (countyId < 0)
                {
                    continue;
                }

                if (countyIds is not null && !countyIds.Contains(countyId))
                {
                    continue;
                }

                string code = administrativeAreal2DReference.Code ?? string.Empty;

                string requestUri_References = new UrlBuilder(path_References).AddParameter("countyid", countyId).ToString();

                List<string>? references = null;

                try
                {
                    PostResponse<List<string>?> postResponse_References = await DiGi.WebAPI.Query.GetAsync<List<string>>(httpClient_References, requestUri_References, postOptions);
                    references = postResponse_References is not null && postResponse_References.Succeeded ? postResponse_References.Result : null;
                }
                catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                {
                    Serilog.Modify.Log(exception, "Building2D references request failed for county {CountyId}", countyId);
                }

                if (references is null || references.Count == 0)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "No Building2D references for county {Code} (id {CountyId})", code, countyId);
                    summaryLines.Add($"{code};{countyId};0;0;0;0;0;0;0");
                    continue;
                }

                List<string> references_Sample = Sample(references, SampleSize, random);

                Serilog.Modify.Log("County {Code} (id {CountyId}) verification started. References: {Sampled}/{Total}", code, countyId, references_Sample.Count, references.Count);

                int count_Requested_County = 0;
                int count_Missing_County = 0;
                int count_Valid_County = 0;
                int count_Invalid_County = 0;
                int count_NotEnclosed_County = 0;
                int count_SeaLevel_County = 0;
                int count_SpacePointOutsideShell_County = 0;

                for (int i = 0; i < references_Sample.Count; i += batchSize)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    List<string> references_Batch = references_Sample.GetRange(i, Math.Min(batchSize, references_Sample.Count - i));

                    // References repeat in the query string and UrlBuilder holds one value per name, so this
                    // part of the query is written directly rather than through it.
                    StringBuilder stringBuilder = new(path_BuildingModel);
                    stringBuilder.Append("?countyid=").Append(countyId);
                    foreach (string reference in references_Batch)
                    {
                        stringBuilder.Append("&references=").Append(WebUtility.UrlEncode(reference));
                    }

                    List<DiGi.Analytical.Building.Classes.BuildingModel>? buildingModels = null;

                    try
                    {
                        PostResponse<List<DiGi.Analytical.Building.Classes.BuildingModel>?> postResponse_BuildingModels = await DiGi.WebAPI.Query.GetAsync<List<DiGi.Analytical.Building.Classes.BuildingModel>>(httpClient_BuildingModel, stringBuilder.ToString(), postOptions);

                        // A batch matching nothing answers 404, which is a valid outcome here and leaves every
                        // reference of the batch to be recorded as missing.
                        buildingModels = postResponse_BuildingModels is not null && postResponse_BuildingModels.Succeeded ? postResponse_BuildingModels.Result : null;
                    }
                    catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                    {
                        Serilog.Modify.Log(exception, "BuildingModels request failed for county {CountyId}", countyId);
                    }

                    Dictionary<string, BuildingModelValidationResult> buildingModelValidationResults_ByReference = [];

                    foreach (DiGi.Analytical.Building.Classes.BuildingModel buildingModel in buildingModels ?? [])
                    {
                        BuildingModelValidationResult? buildingModelValidationResult = Analytical.Create.BuildingModelValidationResult(buildingModel, Tolerance);
                        if (buildingModelValidationResult is null || string.IsNullOrWhiteSpace(buildingModelValidationResult.Reference))
                        {
                            // Rows are keyed by the reference the model carries, so one without it cannot be
                            // matched to the reference it was asked for and would otherwise be counted as a
                            // reference the database holds nothing for. The two are not the same failure.
                            Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "BuildingModel returned by county {CountyId} carries no reference and cannot be matched to the reference it was requested by", countyId);
                            continue;
                        }

                        buildingModelValidationResults_ByReference[buildingModelValidationResult.Reference!] = buildingModelValidationResult;
                    }

                    foreach (string reference in references_Batch)
                    {
                        count_Requested_County++;

                        if (!buildingModelValidationResults_ByReference.TryGetValue(reference, out BuildingModelValidationResult? buildingModelValidationResult))
                        {
                            count_Missing_County++;
                            await streamWriter.WriteLineAsync($"{code};{countyId};{reference};Missing;;;;;;;;");
                            continue;
                        }

                        List<BuildingModelValidationCode>? buildingModelValidationCodes = buildingModelValidationResult.ValidationCodes;

                        if (buildingModelValidationResult.IsValid)
                        {
                            count_Valid_County++;
                        }
                        else
                        {
                            count_Invalid_County++;
                        }

                        foreach (BuildingModelValidationCode buildingModelValidationCode in buildingModelValidationCodes ?? [])
                        {
                            counts_ByValidationCode.TryGetValue(buildingModelValidationCode, out int count);
                            counts_ByValidationCode[buildingModelValidationCode] = count + 1;

                            if (buildingModelValidationCode == BuildingModelValidationCode.NotEnclosed)
                            {
                                count_NotEnclosed_County++;
                            }
                            else if (buildingModelValidationCode == BuildingModelValidationCode.SeaLevel)
                            {
                                count_SeaLevel_County++;
                            }
                            else if (buildingModelValidationCode == BuildingModelValidationCode.SpacePointOutsideShell)
                            {
                                count_SpacePointOutsideShell_County++;
                            }
                        }

                        double minEnclosingTolerance = buildingModelValidationResult.MinEnclosingTolerance;
                        counts_ByMinEnclosingTolerance.TryGetValue(minEnclosingTolerance, out int count_Tolerance);
                        counts_ByMinEnclosingTolerance[minEnclosingTolerance] = count_Tolerance + 1;

                        await streamWriter.WriteLineAsync($"{code};{countyId};{reference};{(buildingModelValidationResult.IsValid ? "Valid" : "Invalid")};{buildingModelValidationResult.SpaceCount};{buildingModelValidationResult.ComponentCount};{buildingModelValidationResult.ShellCount};{buildingModelValidationResult.EnclosedShellCount};{Text(minEnclosingTolerance)};{Text(buildingModelValidationResult.MinZ)};{Text(buildingModelValidationResult.MaxZ)};{string.Join(' ', buildingModelValidationCodes ?? [])}");
                    }

                    longProgressWrapper?.Increment(references_Batch.Count);
                }

                await streamWriter.FlushAsync(cancellationToken);

                count_Requested += count_Requested_County;
                count_Missing += count_Missing_County;
                count_Valid += count_Valid_County;
                count_Invalid += count_Invalid_County;

                Serilog.Modify.Log("County {Code} (id {CountyId}) verified. Valid: {Valid}/{Requested}, missing: {Missing}, not enclosed: {NotEnclosed}", code, countyId, count_Valid_County, count_Requested_County, count_Missing_County, count_NotEnclosed_County);

                summaryLines.Add($"{code};{countyId};{count_Requested_County};{count_Missing_County};{count_Valid_County};{count_Invalid_County};{count_NotEnclosed_County};{count_SeaLevel_County};{count_SpacePointOutsideShell_County}");
            }

            summaryLines.Add(string.Empty);
            summaryLines.Add("=== TOTALS ===");
            summaryLines.Add($"Requested references: {count_Requested}");
            summaryLines.Add($"Missing models: {count_Missing}");
            summaryLines.Add($"Valid models: {count_Valid}");
            summaryLines.Add($"Invalid models: {count_Invalid}");

            summaryLines.Add(string.Empty);
            summaryLines.Add("=== VALIDATION CODES ===");
            foreach (BuildingModelValidationCode buildingModelValidationCode in Enum.GetValues<BuildingModelValidationCode>())
            {
                counts_ByValidationCode.TryGetValue(buildingModelValidationCode, out int count);
                summaryLines.Add($"{buildingModelValidationCode};{count}");
            }

            summaryLines.Add(string.Empty);
            summaryLines.Add("=== SMALLEST TOLERANCE CLOSING THE WHOLE MODEL ===");
            List<double> minEnclosingTolerances = [.. counts_ByMinEnclosingTolerance.Keys];
            minEnclosingTolerances.Sort();
            foreach (double minEnclosingTolerance in minEnclosingTolerances)
            {
                summaryLines.Add($"{Text(minEnclosingTolerance)};{counts_ByMinEnclosingTolerance[minEnclosingTolerance]}");
            }

            summaryLines.Add(string.Empty);
            summaryLines.Add($"Ended: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            await File.WriteAllLinesAsync(System.IO.Path.Combine(directory, "BuildingModels_Verification_Summary.txt"), summaryLines, cancellationToken);

            Serilog.Modify.Log("Verification ended. Valid: {Valid}/{Requested}, invalid: {Invalid}, missing: {Missing}", count_Valid, count_Requested, count_Invalid, count_Missing);

            return true;
        }

        /// <summary>
        /// Draws a reproducible sample of the given size from a list of references.
        /// </summary>
        /// <param name="references">The references to draw from.</param>
        /// <param name="sampleSize">The number of references to draw. A value of zero or less takes them all.</param>
        /// <param name="random">The random source, seeded by the caller so the draw can be repeated.</param>
        /// <returns>The drawn references.</returns>
        private static List<string> Sample(List<string> references, int sampleSize, Random random)
        {
            if (sampleSize < 1 || sampleSize >= references.Count)
            {
                return [.. references];
            }

            // A partial Fisher-Yates shuffle over a copy: every reference is equally likely to be drawn and
            // none is drawn twice, without shuffling a list that can hold tens of thousands of entries in full.
            List<string> references_Temp = [.. references];

            List<string> result = new(sampleSize);
            for (int i = 0; i < sampleSize; i++)
            {
                int index = random.Next(i, references_Temp.Count);

                result.Add(references_Temp[index]);

                references_Temp[index] = references_Temp[i];
                references_Temp[i] = result[i];
            }

            return result;
        }

        /// <summary>
        /// Formats a value for the report, writing an empty cell rather than the word for not a number.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>The formatted value, or an empty string when it is not a number.</returns>
        private static string Text(double value)
        {
            return double.IsNaN(value) ? string.Empty : value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
