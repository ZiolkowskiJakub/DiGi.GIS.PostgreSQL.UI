using System;
using System.IO;
using System.Reflection;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Query
    {
        /// <summary>
        /// Finds the headless Year Built prediction runner this application hands a run to.
        /// <para>The runner is a separate deployment unit rather than an assembly this application loads, because hosting the pipeline here would mean referencing the machine learning closure - about a gigabyte of native libraries against an application that publishes self-contained and single-file. The cost of that choice is that the executable has to be found rather than linked, which is what this answers.</para>
        /// <para>Four candidates in order: the path given, then beside this application's own output, then the runner's own folder beside this one's, then the runner's build output in a workspace checkout. The last is what makes the task runnable from a development machine without deploying anything.</para>
        /// <para>A candidate that does not exist is not returned. A path that only looks resolved would be discovered as a failure to start a process, after the counties had been chosen and the imagery scoped.</para>
        /// </summary>
        /// <param name="path">An explicit path to the runner, or null to search the candidates below it.</param>
        /// <param name="baseDirectory">The directory the candidates are resolved against, or null to use this application's own output. A test supplies one to probe a laid-out folder without deploying.</param>
        /// <returns>The full path of an executable that exists, or null when none of the candidates does.</returns>
        public static string? YearBuiltPredictionConsoleAppPath(string? path = null, string? baseDirectory = null)
        {
            string? Existing(string? candidate)
            {
                if (string.IsNullOrWhiteSpace(candidate))
                {
                    return null;
                }

                try
                {
                    return File.Exists(candidate) ? Path.GetFullPath(candidate!) : null;
                }
                catch
                {
                    // An unrooted or malformed candidate is simply not a candidate. Probing the next one says more
                    // than an exception naming a path nobody typed.
                    return null;
                }
            }

            if (Existing(path) is string path_Given)
            {
                return path_Given;
            }

            string? directory = baseDirectory;

            if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
            {
                try
                {
                    string? location = Assembly.GetExecutingAssembly().Location;
                    if (!string.IsNullOrWhiteSpace(location))
                    {
                        directory = Path.GetDirectoryName(location);
                    }
                }
                catch
                {
                    // An assembly bundled into a single file application reports no location. The application base
                    // directory below answers for it.
                }

                if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
                {
                    directory = AppDomain.CurrentDomain.BaseDirectory;
                }
            }

            if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
            {
                return null;
            }

            if (Existing(Path.Combine(directory!, Constants.FileName.YearBuiltPredictionConsoleApp)) is string path_Deployed)
            {
                return path_Deployed;
            }

            // Deployed layout: the runner is its own folder beside this application's, under the software directory.
            if (Existing(Path.Combine(directory!, "..", "DiGi.GIS.YOLO.UI", Constants.FileName.YearBuiltPredictionConsoleApp)) is string path_Sibling)
            {
                return path_Sibling;
            }

            // The workspace layout every DiGi repository builds into: ..\..\<Repo>\bin\. Reached from this
            // application's own bin, so it holds on a checkout and simply finds nothing on a deployed machine.
            return Existing(Path.Combine(directory!, "..", "..", "DiGi.GIS.YOLO.UI", "bin", Constants.FileName.YearBuiltPredictionConsoleApp));
        }
    }
}
