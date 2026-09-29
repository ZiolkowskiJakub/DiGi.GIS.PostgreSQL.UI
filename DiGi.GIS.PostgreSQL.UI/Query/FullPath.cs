namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Query
    {
        /// <summary>
        /// Returns the absolute form of a path this application hands to another process.
        /// <para>The two processes do not share a working directory - this one runs from wherever the tray application was started, a runner from beside its own executable - so a relative path names a different folder on each side, and neither would report anything wrong. Made absolute here, before it is written into an options file, it means the same thing to both.</para>
        /// <para>A path this machine cannot even form is returned exactly as it was typed, so that the run fails naming what the operator wrote rather than something this method invented from it.</para>
        /// </summary>
        /// <param name="path">The path to resolve against this process's current directory.</param>
        /// <returns>The absolute path; the path unchanged when it cannot be formed; or null when it is null or blank.</returns>
        public static string? FullPath(string? path)
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
                return path;
            }
        }
    }
}
