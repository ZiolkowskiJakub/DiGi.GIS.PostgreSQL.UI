using System.ComponentModel;

namespace DiGi.GIS.PostgreSQL.UI.Enums
{
    /// <summary>
    /// Specifies where a YOLO detector training run started from the tray starts: from the detector already in use, or from the pretrained base checkpoint.
    /// <para>The scenario decides only the defaults <see cref="Create.YOLOTrainingRunOptions(YOLOTrainingScenario, string?, GIS.YOLO.UI.Classes.YOLOTrainingRunOptions?)"/> applies - the start weights, the epoch ceiling and whether the dataset folder is appended to - and every one of them can still be changed in the dialog.</para>
    /// </summary>
    [Description("YOLOTrainingScenario")]
    public enum YOLOTrainingScenario
    {
        /// <summary>
        /// Continues the existing training: starts from the deployed model.pt and appends the chosen counties to the existing dataset folder, whose builder is resumable and keyed by reference.
        /// </summary>
        [Description("Re-train")] Retrain = 0,

        /// <summary>
        /// Starts from the pretrained yolo26x.pt: the dataset is built fresh into a new folder, and a folder that already holds a dataset is refused.
        /// </summary>
        [Description("Start from yolo26x.pt")] Fresh = 1,
    }
}
