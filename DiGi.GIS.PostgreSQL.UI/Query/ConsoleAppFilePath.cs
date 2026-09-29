using System;
using System.IO;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Query
    {
        /// <summary>
        /// Finds an existing file named relative to a headless runner rather than to this application - the weights and data files the runner's defaults name, such as <c>user files/YOLO/models/model.pt</c>.
        /// <para>Three candidates in order: the path as given, then the path under the runner's folder, then the path under the runner's folder with a leading <see cref="Constants.DirectoryName.UserFiles"/> segment removed. The build flattens that git-ignored folder into the output root, so a file named through it sits one segment shallower once deployed; the runner's own resolver strips the segment the same way, and this mirrors it rather than guessing.</para>
        /// <para>Only an existing file is returned. A caller that needs a path to write into, or a path to name in a refusal, uses <see cref="ConsoleAppDeployedPath(string?, string?)"/>.</para>
        /// </summary>
        /// <param name="consoleAppPath">The full path of the runner's executable.</param>
        /// <param name="path">The file path, absolute or relative to the runner.</param>
        /// <returns>The absolute path of the file found, or null when the path is blank or no candidate exists.</returns>
        public static string? ConsoleAppFilePath(string? consoleAppPath, string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            static string? Existing(string? candidate)
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
                    return null;
                }
            }

            if (Existing(path) is string path_Given)
            {
                return path_Given;
            }

            if (string.IsNullOrWhiteSpace(consoleAppPath))
            {
                return null;
            }

            string? directory = Path.GetDirectoryName(consoleAppPath);
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            if (Existing(Path.Combine(directory!, path!)) is string path_Runner)
            {
                return path_Runner;
            }

            string prefix = Constants.DirectoryName.UserFiles;
            if (path!.StartsWith(prefix + "/", StringComparison.OrdinalIgnoreCase) || path.StartsWith(prefix + "\\", StringComparison.OrdinalIgnoreCase))
            {
                return Existing(Path.Combine(directory!, path[(prefix.Length + 1)..]));
            }

            return null;
        }
    }
}
