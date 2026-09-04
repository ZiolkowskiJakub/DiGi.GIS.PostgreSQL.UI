using DiGi.Core.Classes;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.Enums;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.PostgreSQL.UI.Windows;
using DiGi.GIS.WebAPI.Classes;
using DiGi.GIS.YOLO.UI.Classes;
using DiGi.GIS.YOLO.UI.Enums;
using DiGi.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// A Year Built prediction run that is scoped from the user interface: the counties, the interpreter and weights that score the imagery, which of the pipeline's steps run, and how the run talks to the server - the request concurrency and the two batch sizes - are asked for through <see cref="YearBuiltPredictionsOptionsWindow"/> each time the task is started.
    /// <para><b>The run happens in another process.</b> The pipeline needs a regressor, and the only implementation of it carries the machine learning closure - about a gigabyte of native libraries, against an application that publishes self-contained and single-file. The <c>IYearBuiltPredictor</c> seam exists to keep that weight out of hosts that only need to start a run, so this task writes the options out and hands them to <c>DiGi.GIS.YOLO.UI.ConsoleApp</c>, which already hosts the pipeline and is already exercised end to end.</para>
    /// <para>Two consequences of that are worth knowing before a run. <b>The runner authorizes with its own key</b>, read from the <c>GIS_WebAPI_Client.conf</c> beside its executable rather than from this application's - a run that ends in <see cref="YearBuiltPredictionExitCode.Authorization"/> is usually that file rather than the one this application uses. And <b>stopping the task kills the run rather than winding it down</b>: the whole process tree goes, the detector included, so a batch that was being written may be half written. Every step of the pipeline is idempotent and a stopped run is re-runnable, but its tallies are not a record of what was stored.</para>
    /// <para>The environment preflight runs here, before anything is launched, so a machine with no CPython carrying ultralytics says so in front of whoever opened the dialog instead of an hour later as an exit code. The pipeline repeats the check inside the run; that costs one interpreter start and is what makes the reason legible.</para>
    /// </summary>
    public class UIYearBuiltPredictionsTask : ReportableBackgroundTask<long>, IGISPostgreSQLUIObject
    {
        private readonly GISWebAPIManager GISWebAPIManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIYearBuiltPredictionsTask"/> class.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="WebAPI.Classes.GISWebAPIManager"/> instance the county rows behind the dialog are read with. The run itself authorizes with the runner's own key, not with this one.</param>
        public UIYearBuiltPredictionsTask(GISWebAPIManager GISWebAPIManager)
        {
            this.GISWebAPIManager = GISWebAPIManager;
        }

        /// <summary>
        /// Gets or sets the path of the headless runner. When null it is resolved by <see cref="Query.YearBuiltPredictionConsoleAppPath"/>, which probes this application's own output, the runner's folder beside it, and the runner's build output in a workspace checkout.
        /// </summary>
        public string? ConsoleAppPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the options the dialog opens with, and which it writes back to when it is closed with OK. When null the defaults are used, which name no county and therefore ask for nothing.
        /// </summary>
        public YearBuiltPredictionPipelineOptions? YearBuiltPredictionPipelineOptions { get; set; } = null;

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            // Asked before the dialog rather than after it: without the runner nothing can be started at all, and
            // discovering that after the counties have been chosen wastes the only part of this the operator does.
            string? path_ConsoleApp = Query.YearBuiltPredictionConsoleAppPath(ConsoleAppPath);
            if (string.IsNullOrWhiteSpace(path_ConsoleApp))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "{FileName} was not found beside this application or in the workspace - the Year Built prediction run cannot be started", Constants.FileName.YearBuiltPredictionConsoleApp);
                return false;
            }

            // The dialog is a window, and this runs on a thread pool thread, where a window cannot be created at
            // all. Without an application there is no user interface thread to move it to.
            if (System.Windows.Application.Current is not System.Windows.Application application)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "No WPF application is running - the Year Built prediction options cannot be asked for");
                return false;
            }

            HttpClient? httpClient_AdministrativeAreal2D = GISWebAPIManager.CreateHttpClient<AdministrativeAreal2DController>(nameof(AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync), out string? path_AdministrativeAreal2D);
            if (httpClient_AdministrativeAreal2D is null || string.IsNullOrWhiteSpace(path_AdministrativeAreal2D))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "County references could not be requested - the Year Built prediction run cannot be scoped");
                return false;
            }

            PostOptions postOptions = new() { RequestResult = true };

            // The endpoint is a HttpGet action and its administrativearealtype parameter is not nullable - omitting it binds to Country, not County.
            string requestUri_AdministrativeAreal2D = new UrlBuilder(path_AdministrativeAreal2D).AddParameter("administrativearealtype", (int)AdministrativeArealType.County).ToString();

            PostResponse<List<AdministrativeAreal2DReference>?> postResponse_AdministrativeAreal2DReferences = await DiGi.WebAPI.Query.GetAsync<List<AdministrativeAreal2DReference>>(httpClient_AdministrativeAreal2D, requestUri_AdministrativeAreal2D, postOptions);
            if (postResponse_AdministrativeAreal2DReferences is null || !postResponse_AdministrativeAreal2DReferences.Succeeded || postResponse_AdministrativeAreal2DReferences.Result is not List<AdministrativeAreal2DReference> administrativeAreal2DReferences || administrativeAreal2DReferences.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "County references could not be retrieved - the Year Built prediction run cannot be scoped");
                return false;
            }

            // Read on this thread, shown on the user interface thread. Reading inside the callback below would
            // hold the interface still for the whole of the query.
            YearBuiltPredictionPipelineOptions? yearBuiltPredictionPipelineOptions = null;

            application.Dispatcher.Invoke(() =>
            {
                YearBuiltPredictionsOptionsWindow yearBuiltPredictionsOptionsWindow = new(YearBuiltPredictionPipelineOptions, administrativeAreal2DReferences);

                if (yearBuiltPredictionsOptionsWindow.ShowDialog() is not bool dialogResult || !dialogResult)
                {
                    return;
                }

                yearBuiltPredictionPipelineOptions = yearBuiltPredictionsOptionsWindow.YearBuiltPredictionPipelineOptions;
            });

            // A cancelled dialog leaves the options of an earlier run as they were - the window works on a copy -
            // and ends the run here rather than starting one nobody scoped.
            if (yearBuiltPredictionPipelineOptions is null)
            {
                Serilog.Modify.Log("Year built prediction options were cancelled - nothing was run");
                return false;
            }

            // The two processes do not share a working directory - this one runs from wherever the tray application
            // was started, the runner from beside its own executable - so a relative path names a different folder
            // on each side, and neither would report anything wrong. The committed template ships a relative scratch
            // directory, so this is the ordinary case rather than a corner of one. Made absolute before anything
            // reads them, and written back, so the dialog says next time where the run actually went.
            // ModelPath is deliberately left alone: the weights sit beside the runner, and resolving them against
            // this application would be resolving them against the wrong thing.
            yearBuiltPredictionPipelineOptions.ScratchDirectory = FullPath(yearBuiltPredictionPipelineOptions.ScratchDirectory);
            yearBuiltPredictionPipelineOptions.WorkingDirectory = FullPath(yearBuiltPredictionPipelineOptions.WorkingDirectory);

            YearBuiltPredictionPipelineOptions = yearBuiltPredictionPipelineOptions;

            if (yearBuiltPredictionPipelineOptions.RunPrediction)
            {
                // The weights are named relative to the runner, not to this application, so the path in the options
                // is not one this process can probe. It is resolved against the runner below and handed to the
                // preflight only when it is actually found: the preflight counts a model it cannot open as a reason
                // not to run at all, so passing a path this process simply cannot see would refuse a run that would
                // have worked. Not finding it here says nothing about the run - the runner repeats the preflight
                // with its own resolution, which is the one that decides.
                string? modelPath = ModelPath(path_ConsoleApp!, yearBuiltPredictionPipelineOptions.ModelPath);
                if (modelPath is null && !string.IsNullOrWhiteSpace(yearBuiltPredictionPipelineOptions.ModelPath))
                {
                    Serilog.Modify.Log("The weights at {ModelPath} could not be found from here, so only the interpreter was checked - the runner checks the model itself", yearBuiltPredictionPipelineOptions.ModelPath);
                }

                // Gated here rather than left to the runner: this application is where the operator is standing, so
                // a machine with no interpreter carrying ultralytics can say why in front of them instead of
                // exporting a county of imagery first and then answering with an exit code.
                DiGi.YOLO.Classes.YOLOEnvironmentResult yOLOEnvironmentResult = DiGi.YOLO.Query.YOLOEnvironmentResult(yearBuiltPredictionPipelineOptions.PythonPath, modelPath, yearBuiltPredictionPipelineOptions.WorkingDirectory, cancellationToken);
                if (!yOLOEnvironmentResult.Runnable)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "This machine cannot run the detector - {Messages}", string.Join("; ", yOLOEnvironmentResult.Messages ?? []));
                    return false;
                }
            }

            string? path_Options = WriteOptions(yearBuiltPredictionPipelineOptions);
            if (string.IsNullOrWhiteSpace(path_Options))
            {
                return false;
            }

            return await RunAsync(path_ConsoleApp!, path_Options!, progress, cancellationToken);
        }

        private static string? FullPath(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            try
            {
                return System.IO.Path.GetFullPath(path!);
            }
            catch
            {
                // A path this machine cannot even form is left exactly as it was typed, so that the run fails
                // naming what the operator wrote rather than something this method invented from it.
                return path;
            }
        }

        private static string? ModelPath(string path_ConsoleApp, string? modelPath)
        {
            if (string.IsNullOrWhiteSpace(modelPath))
            {
                return null;
            }

            string? Existing(string? candidate)
            {
                if (string.IsNullOrWhiteSpace(candidate))
                {
                    return null;
                }

                try
                {
                    return File.Exists(candidate) ? System.IO.Path.GetFullPath(candidate!) : null;
                }
                catch
                {
                    return null;
                }
            }

            if (Existing(modelPath) is string path_Given)
            {
                return path_Given;
            }

            string? directory = System.IO.Path.GetDirectoryName(path_ConsoleApp);
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            if (Existing(System.IO.Path.Combine(directory!, modelPath!)) is string path_Runner)
            {
                return path_Runner;
            }

            // CopyUserFiles flattens the git-ignored "user files" folder into the output root, so weights named
            // through it sit one segment shallower once deployed. The runner's own resolver strips the segment the
            // same way; this mirrors it rather than guessing.
            const string prefix = "user files";
            if (modelPath!.StartsWith(prefix + "/", StringComparison.OrdinalIgnoreCase) || modelPath.StartsWith(prefix + "\\", StringComparison.OrdinalIgnoreCase))
            {
                return Existing(System.IO.Path.Combine(directory!, modelPath.Substring(prefix.Length + 1)));
            }

            return null;
        }

        private static string? WriteOptions(YearBuiltPredictionPipelineOptions yearBuiltPredictionPipelineOptions)
        {
            // Beside the run's own imagery rather than in a temporary folder: it is the only record of what a run
            // was asked to do, it is worth having when the answer looks wrong, and one file per scratch directory
            // needs no cleaning up. It carries no key - the options class deliberately declares none.
            string? directory = yearBuiltPredictionPipelineOptions.ScratchDirectory;
            if (string.IsNullOrWhiteSpace(directory))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "No scratch directory - the Year Built prediction options have nowhere to be written");
                return null;
            }

            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (yearBuiltPredictionPipelineOptions.ToJsonObject() is not JsonObject jsonObject)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "The Year Built prediction options could not be serialized");
                    return null;
                }

                string path = System.IO.Path.Combine(directory, DiGi.GIS.YOLO.UI.Constants.FileName.YearBuiltPredictionPipelineOptions);
                File.WriteAllText(path, jsonObject.ToString());

                return path;
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "The Year Built prediction options could not be written into {Directory}", directory);
                return null;
            }
        }

        private static async Task<bool> RunAsync(string path_ConsoleApp, string path_Options, IProgress<long> progress, CancellationToken cancellationToken)
        {
            ProcessStartInfo processStartInfo = new()
            {
                FileName = path_ConsoleApp,
                WorkingDirectory = System.IO.Path.GetDirectoryName(path_ConsoleApp) ?? string.Empty,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            // Through ArgumentList rather than a quoted string: a scratch path ending in a separator would
            // otherwise escape its own closing quote and hand the runner an argument nobody typed.
            processStartInfo.ArgumentList.Add(path_Options);

            using Process process = new() { StartInfo = processStartInfo, EnableRaisingEvents = true };

            // Both streams are read as they arrive. A child whose output nobody drains blocks on a full pipe, and
            // this one talks for hours.
            process.OutputDataReceived += (sender, args) =>
            {
                if (args.Data is not string line)
                {
                    return;
                }

                Serilog.Modify.Log("{Line}", line);

                // Through the shared reader rather than a format literal. A progress format that ever drifts costs
                // the progress reporting and nothing else - every line is logged above either way.
                if (DiGi.GIS.YOLO.UI.Query.ProgressCount(line) is long count)
                {
                    progress?.Report(count);
                }
            };

            process.ErrorDataReceived += (sender, args) =>
            {
                if (args.Data is string line)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "{Line}", line);
                }
            };

            Serilog.Modify.Log("Year built prediction run started - {FileName} {Options}", path_ConsoleApp, path_Options);

            // Starting is separated from waiting so that a runner which never started is not also reported as one
            // that could not be killed - Process.HasExited throws on an instance no process was ever attached to,
            // and a failure to start is the likeliest failure of the two.
            try
            {
                process.Start();
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Year built prediction run could not be started - {FileName}", path_ConsoleApp);
                return false;
            }

            try
            {
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync(cancellationToken);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                // The whole tree, because the interpreter is a grandchild: killing only the runner leaves the
                // detector holding a graphics card and a county of imagery with nothing waiting for it.
                Kill(process);

                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Year built prediction run was stopped - the run was killed, so a batch it was writing may be half written");
                return false;
            }
            catch (Exception exception)
            {
                Kill(process);

                Serilog.Modify.Log(exception, "Year built prediction run failed while it was being watched - {FileName}", path_ConsoleApp);
                return false;
            }

            YearBuiltPredictionExitCode yearBuiltPredictionExitCode = (YearBuiltPredictionExitCode)process.ExitCode;

            // Named rather than numbered, and read off the runner's own enumeration - an exit code this application
            // does not recognise is reported as the number it is rather than as a failure of a known kind.
            string description = Enum.IsDefined(typeof(YearBuiltPredictionExitCode), yearBuiltPredictionExitCode)
                ? Core.Query.Description(yearBuiltPredictionExitCode) ?? yearBuiltPredictionExitCode.ToString()
                : string.Format(System.Globalization.CultureInfo.InvariantCulture, "Unrecognised exit code {0}", process.ExitCode);

            if (yearBuiltPredictionExitCode == YearBuiltPredictionExitCode.Succeeded)
            {
                Serilog.Modify.Log("Year built prediction run finished - {Description}", description);
                return true;
            }

            Serilog.Modify.Log(
                yearBuiltPredictionExitCode == YearBuiltPredictionExitCode.Cancelled ? Serilog.Enums.LogEventLevel.Warning : Serilog.Enums.LogEventLevel.Error,
                "Year built prediction run did not finish - {Description}",
                description);

            return false;

            static void Kill(Process process)
            {
                try
                {
                    if (!process.HasExited)
                    {
                        process.Kill(entireProcessTree: true);

                        // Bounded, because the point is to be able to say the run has actually stopped rather than
                        // that stopping it has been asked for - and an unbounded wait would hand a hung detector the
                        // power to hold the task row open indefinitely.
                        process.WaitForExit(5000);
                    }
                }
                catch (Exception exception)
                {
                    Serilog.Modify.Log(exception, "The Year Built prediction run could not be killed");
                }
            }
        }
    }
}
