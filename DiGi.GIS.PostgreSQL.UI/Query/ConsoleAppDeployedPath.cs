using System;
using System.IO;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Query
    {
        /// <summary>
        /// Returns the absolute path a headless runner will use for a path named relative to it, whether or not anything exists there yet - a folder it writes into, such as <c>user files/reports</c>, or a file whose absence a preflight has to name.
        /// <para>A rooted path is returned through <see cref="FullPath(string?)"/>. A relative one is placed under the runner's folder with a leading <see cref="Constants.DirectoryName.UserFiles"/> segment removed, which is the layout the build deploys: the git-ignored folder is flattened into the output root, both in a workspace <c>bin</c> and on a deployed machine.</para>
        /// <para>Resolved here rather than left to the runner, so that the path written into an options file is the one this application checked and named back - not one the other process resolves against a different directory.</para>
        /// </summary>
        /// <param name="consoleAppPath">The full path of the runner's executable.</param>
        /// <param name="path">The path, absolute or relative to the runner.</param>
        /// <returns>The absolute path; the path as <see cref="FullPath(string?)"/> returns it when there is no runner folder to place it under; or null when it is null or blank.</returns>
        public static string? ConsoleAppDeployedPath(string? consoleAppPath, string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            bool rooted;
            try
            {
                rooted = Path.IsPathRooted(path);
            }
            catch
            {
                rooted = false;
            }

            string? directory = string.IsNullOrWhiteSpace(consoleAppPath) ? null : Path.GetDirectoryName(consoleAppPath);
            if (rooted || string.IsNullOrWhiteSpace(directory))
            {
                return FullPath(path);
            }

            string path_Relative = path!;

            string prefix = Constants.DirectoryName.UserFiles;
            if (path_Relative.StartsWith(prefix + "/", StringComparison.OrdinalIgnoreCase) || path_Relative.StartsWith(prefix + "\\", StringComparison.OrdinalIgnoreCase))
            {
                path_Relative = path_Relative[(prefix.Length + 1)..];
            }

            return FullPath(Path.Combine(directory!, path_Relative));
        }
    }
}
