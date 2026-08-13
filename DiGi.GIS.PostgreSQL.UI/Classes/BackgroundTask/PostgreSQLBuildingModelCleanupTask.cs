using DiGi.Core.Classes;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.Enums;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// Removes the <see cref="DiGi.Analytical.Building.Classes.BuildingModel"/> rows a regeneration leaves behind.
    /// <para>A model row is keyed on the reference of the building it describes. Rows written before that were keyed on the model's own identifier, which is a fresh <see cref="Guid"/> on every model created, so the upsert never matched one and inserted a second model for the same building instead of replacing it. Regenerating a county therefore does not replace its models - it adds to them - and this is what takes the old rows out afterwards.</para>
    /// <para>A row is deleted only when a row keyed on the same building's reference exists beside it, so the building keeps a model either way and a part that has never been regenerated is left untouched rather than emptied. That makes the order this runs in irrelevant.</para>
    /// <para><see cref="RemoveOrphans"/> additionally takes out models whose building no longer exists under the part, which is what a <see cref="PostgreSQLBuilding2DCountyPartRepairTask"/> run can leave behind. It is off by default because it is decided by a different question - whether the building moved - and should only be turned on once the repair report says buildings moved away from the part holding their models.</para>
    /// <para><b>Reports by default and writes nothing.</b> <see cref="DryRun"/> has to be turned off deliberately, and the counts it reports first are what the delete should be reviewed against - the rows removed here have no undo.</para>
    /// </summary>
    public class PostgreSQLBuildingModelCleanupTask : ReportableBackgroundTask<long>, IGISPostgreSQLUIObject
    {
        private readonly GISPostgreSQLConverterManager gISPostgreSQLConverterManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSQLBuildingModelCleanupTask"/> class.
        /// </summary>
        /// <param name="gISPostgreSQLConverterManager">The manager holding the PostgreSQL converters.</param>
        public PostgreSQLBuildingModelCleanupTask(GISPostgreSQLConverterManager gISPostgreSQLConverterManager)
        {
            this.gISPostgreSQLConverterManager = gISPostgreSQLConverterManager;
        }

        /// <summary>
        /// Gets or sets the identifiers of the county rows to clean. When null every county row is examined.
        /// <para>These are polygon parts, not counties - a multi-part county holds one row per part and each is cleaned on its own.</para>
        /// </summary>
        public IEnumerable<int>? CountyIds { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether the task only reports what it would do. Defaults to <see langword="true"/>; nothing is written until it is turned off.
        /// </summary>
        public bool DryRun { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether models whose building no longer exists under the part are removed as well. Defaults to <see langword="false"/>.
        /// </summary>
        public bool RemoveOrphans { get; set; } = false;

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            AdministrativeAreal2DPostgreSQLConverter? administrativeAreal2DPostgreSQLConverter = gISPostgreSQLConverterManager?.GetPostgreSQLConverter<AdministrativeAreal2DPostgreSQLConverter>();
            BuildingModelPostgreSQLConverter? buildingModelPostgreSQLConverter = gISPostgreSQLConverterManager?.GetPostgreSQLConverter<BuildingModelPostgreSQLConverter>();

            if (administrativeAreal2DPostgreSQLConverter is null || buildingModelPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "PostgreSQL converters could not be resolved");
                return false;
            }

            // building_2d and building_model live in different databases, so the two reference sets cannot be
            // compared in one statement - the buildings have to be read through their own converter.
            Building2DPostgreSQLConverter? building2DPostgreSQLConverter = RemoveOrphans ? gISPostgreSQLConverterManager?.GetPostgreSQLConverter<Building2DPostgreSQLConverter>() : null;
            if (RemoveOrphans && building2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building2D converter could not be resolved and RemoveOrphans is on");
                return false;
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByAdministrativeArealType(AdministrativeArealType.County, cancellationToken: cancellationToken);
            if (administrativeAreal2Ds is null || administrativeAreal2Ds.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "County rows could not be retrieved");
                return false;
            }

            HashSet<int>? countyIds = CountyIds is null ? null : [.. CountyIds];

            List<int> countyIds_Cleaned = [];
            foreach (AdministrativeAreal2D administrativeAreal2D in administrativeAreal2Ds)
            {
                int countyId = administrativeAreal2D.Id;
                if (countyIds is null || countyIds.Contains(countyId))
                {
                    countyIds_Cleaned.Add(countyId);
                }
            }

            countyIds_Cleaned.Sort();

            LongProgressWrapper? longProgressWrapper = Core.Create.LongProgressWrapper(progress);

            Serilog.Modify.Log("{Type} started. DryRun: {DryRun}. RemoveOrphans: {RemoveOrphans}. County rows examined: {Count}", nameof(PostgreSQLBuildingModelCleanupTask), DryRun, RemoveOrphans, countyIds_Cleaned.Count);

            long count_Superseded = 0;
            long count_Orphaned = 0;
            long count_Deleted = 0;

            foreach (int countyId in countyIds_Cleaned)
            {
                cancellationToken.ThrowIfCancellationRequested();

                long count_Superseded_County = await buildingModelPostgreSQLConverter.GetSupersededCountAsync(countyId, cancellationToken);
                if (count_Superseded_County < 0)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Part {CountyId}: superseded rows could not be counted - skipped", countyId);
                    continue;
                }

                List<string> references_Orphaned = [];
                if (RemoveOrphans)
                {
                    references_Orphaned = await ReferencesOrphanedAsync(buildingModelPostgreSQLConverter, building2DPostgreSQLConverter!, countyId, cancellationToken);
                }

                if (count_Superseded_County == 0 && references_Orphaned.Count == 0)
                {
                    continue;
                }

                Serilog.Modify.Log("Part {CountyId}: superseded models {Superseded}, references without a building {Orphaned}", countyId, count_Superseded_County, references_Orphaned.Count);

                count_Superseded += count_Superseded_County;
                count_Orphaned += references_Orphaned.Count;

                if (DryRun)
                {
                    longProgressWrapper?.Increment(count_Superseded_County + references_Orphaned.Count);
                    continue;
                }

                if (count_Superseded_County != 0)
                {
                    HashSet<long>? ids = await buildingModelPostgreSQLConverter.RemoveSupersededAsync(countyId, cancellationToken);

                    int count = ids?.Count ?? 0;
                    count_Deleted += count;

                    if (count != count_Superseded_County)
                    {
                        Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Part {CountyId}: {Deleted}/{Counted} superseded models deleted - the table did not hold what was counted", countyId, count, count_Superseded_County);
                    }

                    longProgressWrapper?.Increment(count);
                }

                if (references_Orphaned.Count != 0)
                {
                    HashSet<long>? ids = await buildingModelPostgreSQLConverter.RemoveAsync(references_Orphaned, countyId, cancellationToken);

                    int count = ids?.Count ?? 0;
                    count_Deleted += count;

                    // More rows than references is the normal case rather than a fault - a reference the upsert could
                    // not match holds one row per run that wrote it. Fewer means the table no longer holds what was read.
                    if (count < references_Orphaned.Count)
                    {
                        Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Part {CountyId}: {Deleted} rows deleted for {Counted} references without a building - the table did not hold what was read", countyId, count, references_Orphaned.Count);
                    }

                    longProgressWrapper?.Increment(count);
                }
            }

            Serilog.Modify.Log("{Type} ended. DryRun: {DryRun}. Superseded models {Superseded}, references without a building {Orphaned}, rows deleted {Deleted}", nameof(PostgreSQLBuildingModelCleanupTask), DryRun, count_Superseded, count_Orphaned, count_Deleted);

            return true;
        }

        /// <summary>
        /// Returns the references a county row holds a model for but no longer holds a building for.
        /// </summary>
        /// <param name="buildingModelPostgreSQLConverter">The converter reading the model table.</param>
        /// <param name="building2DPostgreSQLConverter">The converter reading the building table, which lives in a different database.</param>
        /// <param name="countyId">The identifier of the county row to compare.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the orphaned references, empty when either side could not be read.</returns>
        private static async Task<List<string>> ReferencesOrphanedAsync(BuildingModelPostgreSQLConverter buildingModelPostgreSQLConverter, Building2DPostgreSQLConverter building2DPostgreSQLConverter, int countyId, CancellationToken cancellationToken)
        {
            HashSet<string>? references_Model = await buildingModelPostgreSQLConverter.GetReferencesAsync(countyId, cancellationToken);
            if (references_Model is null || references_Model.Count == 0)
            {
                return [];
            }

            // GetBuilding2DReferencesByAdministrativeAreal2DIdsAsync resolves through Subdivision children and
            // answers empty for a part with none, which is not the same thing as the part holding no buildings.
            // The excluded set is declared rather than passed inline: the paging overload is otherwise an equally
            // good match for a bare null and the call does not compile.
            IEnumerable<string>? references_Excluded = null;

            List<Building2DReference>? building2DReferences = await building2DPostgreSQLConverter.GetBuilding2DReferencesByCountyIdAsync(countyId, null, references_Excluded, cancellationToken: cancellationToken);
            if (building2DReferences is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Part {CountyId}: Building2D references could not be read - orphans not looked for", countyId);
                return [];
            }

            HashSet<string> references_Building2D = [];
            foreach (Building2DReference building2DReference in building2DReferences)
            {
                string? reference = building2DReference?.Reference;
                if (!string.IsNullOrWhiteSpace(reference))
                {
                    references_Building2D.Add(reference!);
                }
            }

            // An empty building side would condemn every model of the part, which is far more likely to mean the
            // read went wrong than that the part really lost all its buildings.
            if (references_Building2D.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Part {CountyId}: holds {Count} models and no buildings at all - left alone rather than emptied", countyId, references_Model.Count);
                return [];
            }

            return [.. references_Model.Where(x => !references_Building2D.Contains(x))];
        }
    }
}
