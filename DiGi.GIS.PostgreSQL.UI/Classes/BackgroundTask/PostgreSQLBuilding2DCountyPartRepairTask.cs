using DiGi.Core.Classes;
using DiGi.Geometry.Planar.Interfaces;
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
    /// Repairs the county part each <see cref="GIS.Classes.Building2D"/> of a multi-part county is filed under.
    /// <para>A county code names one <c>administrative_areal_2d</c> row per polygon part. Imports that resolved a code to a single part filed a whole county's buildings there, and imports that resolved it differently filed them again somewhere else - so the same reference is held under several parts at once. Three codes carry roughly 86 000 such rows today.</para>
    /// <para>Each affected building is re-filed under the part its footprint actually lies in, using the same decision the import now makes (<c>Query.CountyId</c>), and the copies left under the other parts are deleted. A reference held by exactly one part is left untouched, so running this over a healthy county does nothing.</para>
    /// <para><b>Reports by default and writes nothing.</b> <see cref="DryRun"/> has to be turned off deliberately, and the report it produces first is what the delete should be reviewed against - the buildings removed here have no undo.</para>
    /// </summary>
    public class PostgreSQLBuilding2DCountyPartRepairTask : ReportableBackgroundTask<long>, IGISPostgreSQLUIObject
    {
        private readonly GISPostgreSQLConverterManager gISPostgreSQLConverterManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSQLBuilding2DCountyPartRepairTask"/> class.
        /// </summary>
        /// <param name="gISPostgreSQLConverterManager">The manager holding the PostgreSQL converters.</param>
        public PostgreSQLBuilding2DCountyPartRepairTask(GISPostgreSQLConverterManager gISPostgreSQLConverterManager)
        {
            this.gISPostgreSQLConverterManager = gISPostgreSQLConverterManager;
        }

        /// <summary>
        /// Gets or sets the county codes to repair. When null every code holding more than one part is examined.
        /// </summary>
        public IEnumerable<string>? Codes { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether the task only reports what it would do. Defaults to <see langword="true"/>; nothing is written until it is turned off.
        /// </summary>
        public bool DryRun { get; set; } = true;

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            AdministrativeAreal2DPostgreSQLConverter? administrativeAreal2DPostgreSQLConverter = gISPostgreSQLConverterManager?.GetPostgreSQLConverter<AdministrativeAreal2DPostgreSQLConverter>();
            Building2DPostgreSQLConverter? building2DPostgreSQLConverter = gISPostgreSQLConverterManager?.GetPostgreSQLConverter<Building2DPostgreSQLConverter>();

            if (administrativeAreal2DPostgreSQLConverter is null || building2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "PostgreSQL converters could not be resolved");
                return false;
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByAdministrativeArealType(AdministrativeArealType.County, cancellationToken: cancellationToken);
            if (administrativeAreal2Ds is null || administrativeAreal2Ds.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "County rows could not be retrieved");
                return false;
            }

            HashSet<string>? codes = Codes is null ? null : [.. Codes];

            Dictionary<string, List<AdministrativeAreal2D>> administrativeAreal2Ds_ByCode = [];
            foreach (AdministrativeAreal2D administrativeAreal2D in administrativeAreal2Ds)
            {
                string? code = administrativeAreal2D?.Code;
                if (string.IsNullOrWhiteSpace(code) || (codes is not null && !codes.Contains(code!)))
                {
                    continue;
                }

                if (!administrativeAreal2Ds_ByCode.TryGetValue(code!, out List<AdministrativeAreal2D>? administrativeAreal2Ds_Code))
                {
                    administrativeAreal2Ds_Code = [];
                    administrativeAreal2Ds_ByCode[code!] = administrativeAreal2Ds_Code;
                }

                administrativeAreal2Ds_Code.Add(administrativeAreal2D!);
            }

            LongProgressWrapper? longProgressWrapper = Core.Create.LongProgressWrapper(progress);

            Serilog.Modify.Log("{Type} started. DryRun: {DryRun}. Codes examined: {Count}", nameof(PostgreSQLBuilding2DCountyPartRepairTask), DryRun, administrativeAreal2Ds_ByCode.Count);

            long count_Kept = 0;
            long count_Moved = 0;
            long count_Deleted = 0;

            foreach (KeyValuePair<string, List<AdministrativeAreal2D>> keyValuePair in administrativeAreal2Ds_ByCode)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string code = keyValuePair.Key;

                List<AdministrativeAreal2D> administrativeAreal2Ds_Code = [.. keyValuePair.Value.OrderBy(x => x.Id)];
                if (administrativeAreal2Ds_Code.Count < 2)
                {
                    continue;
                }

                // Every part's buildings, kept by part so a reference held twice is visible as such.
                Dictionary<int, List<Building2D>> building2Ds_ByCountyId = [];
                Dictionary<string, List<int>> countyIds_ByReference = [];

                foreach (AdministrativeAreal2D administrativeAreal2D in administrativeAreal2Ds_Code)
                {
                    List<Building2D>? building2Ds = await building2DPostgreSQLConverter.GetBuilding2DsByCountyIdAsync(administrativeAreal2D.Id, cancellationToken);
                    if (building2Ds is null || building2Ds.Count == 0)
                    {
                        continue;
                    }

                    building2Ds_ByCountyId[administrativeAreal2D.Id] = building2Ds;

                    foreach (Building2D building2D in building2Ds)
                    {
                        string? reference = building2D?.Reference;
                        if (string.IsNullOrWhiteSpace(reference))
                        {
                            continue;
                        }

                        if (!countyIds_ByReference.TryGetValue(reference!, out List<int>? countyIds_Reference))
                        {
                            countyIds_Reference = [];
                            countyIds_ByReference[reference!] = countyIds_Reference;
                        }

                        countyIds_Reference.Add(administrativeAreal2D.Id);
                    }
                }

                if (building2Ds_ByCountyId.Count < 2)
                {
                    Serilog.Modify.Log("Code {Code}: {Parts} parts but only {Populated} holding buildings - nothing to repair", code, administrativeAreal2Ds_Code.Count, building2Ds_ByCountyId.Count);
                    continue;
                }

                Dictionary<int, List<string>> references_Delete_ByCountyId = [];

                // Derived once per code: a part's polygon is the same for every building tested against it,
                // and deriving it deserializes a county-sized geometry. Handing the rows themselves to
                // Query.CountyId would repeat that for each of the tens of thousands of duplicated references.
                Dictionary<int, IPolygonal2D> polygonal2Ds_ByCountyId = administrativeAreal2Ds_Code.Polygonal2DsByCountyId();

                int count_Kept_Code = 0;
                int count_Moved_Code = 0;

                foreach (KeyValuePair<string, List<int>> keyValuePair_Reference in countyIds_ByReference)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string reference = keyValuePair_Reference.Key;
                    List<int> countyIds_Reference = keyValuePair_Reference.Value;

                    if (countyIds_Reference.Count < 2)
                    {
                        // Held by one part only - whether that is the right part is a question for the import,
                        // not for a repair that exists to remove copies.
                        continue;
                    }

                    Building2D? building2D = building2Ds_ByCountyId[countyIds_Reference[0]].Find(x => x.Reference == reference);

                    IPolygonal2D? polygonal2D = building2D?.ToDiGi()?.PolygonalFace2D?.ExternalEdge;

                    int? countyId_Resolved = Query.CountyId(polygonal2Ds_ByCountyId, polygonal2D);
                    if (countyId_Resolved is null || !countyIds_Reference.Contains(countyId_Resolved.Value))
                    {
                        // The part the footprint belongs to holds no copy to keep, so moving it would mean
                        // writing a building rather than removing a duplicate. Left alone and reported.
                        Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Code {Code}: reference {Reference} is held by {Count} parts but belongs to {CountyId}, which holds no copy - left untouched", code, reference, countyIds_Reference.Count, countyId_Resolved?.ToString() ?? "none");
                        continue;
                    }

                    if (countyId_Resolved.Value == countyIds_Reference[0])
                    {
                        count_Kept_Code++;
                    }
                    else
                    {
                        count_Moved_Code++;
                    }

                    foreach (int countyId in countyIds_Reference)
                    {
                        if (countyId == countyId_Resolved.Value)
                        {
                            continue;
                        }

                        if (!references_Delete_ByCountyId.TryGetValue(countyId, out List<string>? references_Delete))
                        {
                            references_Delete = [];
                            references_Delete_ByCountyId[countyId] = references_Delete;
                        }

                        references_Delete.Add(reference);
                    }
                }

                long count_Delete_Code = references_Delete_ByCountyId.Values.Sum(x => (long)x.Count);

                Serilog.Modify.Log("Code {Code}: parts {Parts}, references held by more than one part {Duplicated}, staying where they are {Kept}, belonging to another part {Moved}, copies to delete {Delete}", code, string.Join(", ", administrativeAreal2Ds_Code.ConvertAll(x => x.Id)), count_Kept_Code + count_Moved_Code, count_Kept_Code, count_Moved_Code, count_Delete_Code);

                foreach (KeyValuePair<int, List<string>> keyValuePair_Delete in references_Delete_ByCountyId)
                {
                    Serilog.Modify.Log("Code {Code}: {Count} copies would be deleted from part {CountyId}", code, keyValuePair_Delete.Value.Count, keyValuePair_Delete.Key);
                }

                count_Kept += count_Kept_Code;
                count_Moved += count_Moved_Code;

                if (DryRun)
                {
                    longProgressWrapper?.Increment(count_Delete_Code);
                    continue;
                }

                foreach (KeyValuePair<int, List<string>> keyValuePair_Delete in references_Delete_ByCountyId)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    HashSet<long>? ids = await building2DPostgreSQLConverter.RemoveAsync(keyValuePair_Delete.Value, keyValuePair_Delete.Key, cancellationToken);

                    int count = ids?.Count ?? 0;
                    count_Deleted += count;

                    if (count != keyValuePair_Delete.Value.Count)
                    {
                        Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Code {Code}: {Deleted}/{Requested} copies deleted from part {CountyId} - the table did not hold what the report was built from", code, count, keyValuePair_Delete.Value.Count, keyValuePair_Delete.Key);
                    }

                    longProgressWrapper?.Increment(count);
                }
            }

            Serilog.Modify.Log("{Type} ended. DryRun: {DryRun}. References staying {Kept}, belonging elsewhere {Moved}, copies deleted {Deleted}", nameof(PostgreSQLBuilding2DCountyPartRepairTask), DryRun, count_Kept, count_Moved, count_Deleted);

            return true;
        }
    }
}
