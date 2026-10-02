using DiGi.YOLO.Classes;
using System.IO;
using System.Threading;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Query
    {
        /// <summary>
        /// Returns what an interrupted training run named by <paramref name="projectDirectory"/> and <paramref name="runName"/> holds when it can be resumed, or <c>null</c> when there is nothing to offer.
        /// <para>A run is interruptible when its folder exists, holds <c>weights\last.pt</c>, has no completed <c>&lt;RunName&gt;.pt</c>, and the checkpoint can be read and is unfinished. <see cref="DiGi.YOLO.Query.YOLOCheckpointInformation(string?, string?, string?, CancellationToken)"/> reads the epoch, the ceiling and the recorded arguments; the caller decides what to do with them.</para>
        /// <para>This is the detection <see cref="Windows.YOLOTrainingOptionsWindow"/> offers and the task's preflight repeats, so both agree on which folders are interruptible. It runs the interpreter, so a machine that cannot read a checkpoint simply offers nothing.</para>
        /// </summary>
        /// <param name="projectDirectory">The absolute directory the run folder is created in.</param>
        /// <param name="runName">The run name: the name of its folder under <paramref name="projectDirectory"/>.</param>
        /// <param name="pythonPath">The path of the CPython interpreter, a command name on PATH, or <c>null</c> to search PATH.</param>
        /// <param name="workingDirectory">The directory the checkpoint script is written to and run in, or <c>null</c> to use <paramref name="projectDirectory"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe.</param>
        /// <returns>The checkpoint information of the interrupted run, or <c>null</c> when it is not one.</returns>
        public static YOLOCheckpointInformation? InterruptedYOLOTrainingRun(string? projectDirectory, string? runName, string? pythonPath, string? workingDirectory, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(projectDirectory) || string.IsNullOrWhiteSpace(runName))
            {
                return null;
            }

            string runDirectory = Path.Combine(projectDirectory, runName);
            if (!Directory.Exists(runDirectory))
            {
                return null;
            }

            // The runner writes <RunName>.pt only after a completed training, so it marks a run that is not interrupted.
            if (File.Exists(Path.Combine(runDirectory, string.Concat(runName, ".pt"))))
            {
                return null;
            }

            string path_Last = Path.Combine(runDirectory, DiGi.GIS.YOLO.UI.Constants.DirectoryName.Weights, DiGi.GIS.YOLO.UI.Constants.FileName.LastWeights);
            if (!File.Exists(path_Last))
            {
                return null;
            }

            YOLOCheckpointInformation? result = DiGi.YOLO.Query.YOLOCheckpointInformation(path_Last, pythonPath, workingDirectory ?? projectDirectory, cancellationToken);

            return result is null || result.Finished ? null : result;
        }
    }
}
