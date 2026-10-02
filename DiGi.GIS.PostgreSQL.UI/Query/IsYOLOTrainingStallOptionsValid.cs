using System;
using System.Globalization;

namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Query
    {
        /// <summary>
        /// Returns whether the automatic-resume count and the stall limit are usable, and the reason when they are not, so the dialog and the task's preflight refuse with the same words.
        /// <para>The count has to be 0 to <see cref="Count_AutoResumeMax"/>: 0 keeps the runner's behaviour of no retries, and above the ceiling a run would retry a fault indefinitely rather than report it. The limit, when given, has to be at least one minute; empty means the runner's default of 15 minutes and is not validated here. A limit of zero would disable the stall detection, which is the opposite of what the box asks for, so it is refused.</para>
        /// </summary>
        /// <param name="autoResumeCount">The number of automatic resumes allowed in one run.</param>
        /// <param name="inactivityTimeout">The span without output after which the training is treated as stalled, or null for the runner's default.</param>
        /// <param name="reason">The reason the pair cannot be used, or null when it can.</param>
        /// <returns>True when the pair can be used; otherwise false.</returns>
        public static bool IsYOLOTrainingStallOptionsValid(int autoResumeCount, TimeSpan? inactivityTimeout, out string? reason)
        {
            if (autoResumeCount < 0 || autoResumeCount > Count_AutoResumeMax)
            {
                reason = string.Format(CultureInfo.InvariantCulture, "Automatic resumes has to be a whole number from 0 to {0}.", Count_AutoResumeMax);
                return false;
            }

            if (inactivityTimeout is TimeSpan inactivityTimeout_Value && inactivityTimeout_Value < TimeSpan.FromMinutes(1))
            {
                reason = "The stall limit has to be at least one minute, or empty to use the default of 15 minutes.";
                return false;
            }

            reason = null;
            return true;
        }

        /// <summary>
        /// Gets the largest number of automatic resumes a tray run may ask for.
        /// </summary>
        private const int Count_AutoResumeMax = 10;
    }
}
