# Implementation Plan — DiGi.GIS.PostgreSQL.UI #13

**Estate-wide regeneration of the building models whose courtyard the storey split filled solid**

- Issue: https://github.com/ZiolkowskiJakub/DiGi.GIS.PostgreSQL.UI/issues/13 (open, `type: maintenance`, `priority: medium`, `ai: standard`, assignee `ZiolkowskiJakub`)
- Code blockers (both **closed**): DiGi.Geometry#7 → `0b37f1c` (`0.8.9`), DiGi.Analytical#4 → `eeb797f` (`0.8.8`)
- Symptom (closed): DiGi.GIS.WebAPI.UI#45 — closed on 2026-09-21 on the single-building evidence
- **Status: v1 — created 2026-09-21 after verifying every premise of the issue against the code. Part A (audit task + registration + predicate test) is implemented and green.**

---

## 1. Validity assessment

The issue is **still valid — but only for its estate-wide scope.** The single-building slice of it is already done (recorded in the two comments on #13):

| Step (from the issue body) | State on 2026-09-21 |
|---|---|
| 1. Deploy `DiGi.Geometry 0.8.9` + `DiGi.Analytical 0.8.8` to the WebAPI host | ✅ Done — host restarted 2026-09-21, fixed DLLs live |
| 2. Estate audit (per-county tally of "courtyard in source, none in stored outline") | ⬜ **Not done** |
| 3. Regenerate the *affected* references (idempotency: row count per reference unchanged) | ⬜ **Not done** (only county `1465`'s one building was regenerated) |
| 4. Reference check on the served model + browser DoD | ✅ Done **for one model** — `38F62224-C903…` (county `1465`); #45 closed on it |
| 5. Close #45, post the audit tally here | ⬜ **Not done** (tally not posted; #45 is closed, #13 is not) |

So the remaining, still-valid work is exactly the three unchecked boxes in the last comment: **the estate audit, the rest of the regeneration (with the idempotency proof), and a second reference check.** Nothing here is a code change in the split itself — that shipped in the two closed blockers. This plan is the *run*.

---

## 2. Premises verified against code (with evidence)

Per the `GitHub - Issues` guideline §2 ("an issue's problem statement is a hypothesis — confirm each claim against the code"), every load-bearing premise was checked. Four are load-bearing for the work that remains.

### 2.1 The defect signal is real and reproducible in the fixed code
✅ **Confirmed.** `DiGi.Test/DiGi.GIS.Analytical.xUnit/Facts/BuildingModelFromCityGML1465Courtyard.cs` loads the raw fixture `DiGi.Test/files/1465_38F62224-C903_CityGML.gml` (one `bldg:GroundSurface`, 10 002 m² outer ring + 4 664 m² interior ring) and asserts `buildingModel.Footprints(Constants.Tolerance.Coordinate)` keeps the courtyard as an **internal edge** (outline ≈ 5 338 m²). `DiGi.Test/DiGi.GIS.Analytical.xUnit/Facts/BuildingModelFootprints.cs` exercises the same `Footprints` overloads. So "the fixed code produces the hole" is measured, not asserted.

### 2.2 The stored `building_model` rows are keyed by a *random* GUID, not by reference — the code comment that justifies re-running is wrong
⚠️ **Corrected — this is the finding that changes the idempotency step.**

The regeneration task carries this comment (`UIBuildingModelsFromDatabasePostTask.cs`, checkpoint block):

> "A county interrupted part way is therefore redone in full on the next run, which is safe: **the upsert is keyed on the building reference, so regenerating replaces rather than inserts.**"

That is not what the code does. The actual write path is:

- `DiGi.Core/DiGi.Core.Parameter/Classes/ParametrizedGuidObject.cs`: `private Guid guid = Guid.NewGuid();` — `BuildingModel : ParametrizedGuidObject`, so **every freshly built model mints a fresh random GUID at construction.**
- `DiGi.GIS.PostgreSQL/…/Building2DReferencedObjectPostgreSQLConverter.cs` (upsert):
  ```sql
  INSERT INTO {TableName} (county_id, unique_id, reference, object)
  VALUES (@county_id, @unique_id, @reference, @object)
  ON CONFLICT (county_id, unique_id)
  DO UPDATE SET object = EXCLUDED.object, reference = EXCLUDED.reference
  ```
  The conflict key is **`(county_id, unique_id)`**, and `unique_id` is that fresh random GUID. `reference` is a **deliberately non-unique index** (`idx_…_county_id_reference`, not unique — `DiGi.GIS.PostgreSQL/Create/TableAsync.cs`).

**Consequence:** a regenerated (freshly built) model's `unique_id` matches no existing row, so `ON CONFLICT` is a no-op and the statement **INSERTs a second row** for the same building — exactly the "first regeneration doubled `building_model` rows" the issue reports. There is **no replace-by-reference anywhere** in the write path. The *only* thing that made a re-run appear idempotent is the **county checkpoint skip** (`countyIds_Completed` / `Resume`), which skips an already-checkpointed county entirely; a deliberate re-run with the checkpoint cleared would add *yet another* row.

This is why the estate regeneration must be done the way the national pass (issue #2) was done — the registration comment for that very task says it:

> "It runs against a **truncated `building_model_component`**, so every row it writes is the only row for its building and no cleanup follows it." (`VisualBackgroundTasks.cs`, lines 175–178)

**Decision:** the idempotency acceptance ("row count per reference unchanged by the run") is met by **clearing each affected county's `building_model_component` rows before regenerating that county** (partition-level truncate), so the regenerated county holds exactly one — the fixed — row per building. See Part B.

### 2.3 County scoping is by `id`, never `code`
✅ **Confirmed** against `Coding - GIS Administrative Data.md` and both task sources: 406 county rows for 380 codes, 18 multi-part codes; the tasks read/upload by `administrativeAreal2DReference.Id`; `PostgreSQL.Query.IsInScope(countyId, code, countyIds, voivodeshipCodes)` is the scope predicate. Any `LIMIT`/`FirstOrDefault` over `administrative_areal_2d`/`building_2d` needs an explicit `ORDER BY`. The audit and the regeneration both scope by county **id**.

### 2.4 The read path already serves the fixed model (so "served model carries the courtyard" is checkable without re-doing #45)
✅ **Confirmed** from the #13 progress comment: the served GUID changed `ec265c2a… → a07569fd…`, and `Footprints` of the served model carries the courtyard (0 of 375 component projections cover the courtyard centre). The browser DoD (Playwright, courtyard pixel terrain-coloured, not the `(23,26,33)` background — `Coding - Browser Testing.md` §5) is the #45 acceptance, already met for that one building. Part C repeats it for a *second* building.

---

## 3. Scope

**In scope (this issue — the estate run):**

- `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Classes/BackgroundTask/UIBuildingModelsCourtyardAuditTask.cs` (new, read-only report task)
- One registration row in `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Create/VisualBackgroundTasks.cs` (Server mode, beside the existing *Create/Verify BuildingModels* rows)
- A small pure predicate (source-ring vs. footprint-internal-edge) + a unit test in `DiGi.Test/DiGi.GIS.PostgreSQL.UI.xUnit/Facts/`
- The **run**: audit → per-county tally → clear + regenerate the affected counties → before/after row-count proof → second reference check
- Closing #13 with a structured resolution comment, and a **premise-correction comment** for §2.2

**Out of scope:**

- The split fix itself — shipped in DiGi.Geometry#7 / DiGi.Analytical#4 (closed)
- DiGi.GIS.WebAPI.UI#45 — already closed; Part C only re-confirms the DoD on a second building, it does not re-open it
- Any new `building_model` table DDL / unique constraints — the non-unique `reference` index is *deliberate* (the design holds one row per *version*, per the `Building2DReferencedObject` doc: "Do not key a row on the reference to make writes idempotent")
- The tray app build — already deployed (step 1)

---

## 4. Part A — Estate-wide courtyard audit (new read-only report task)

**Goal:** per county, the tally of models whose *source* CityGML `GroundSurface` carries an interior ring while the *stored* `BuildingModel`'s `Footprints` carry no internal edge (the affected set), plus the unaffected and no-courtyard counts. Read-only; nothing is uploaded.

**File:** `DiGi.GIS.PostgreSQL.UI/Classes/BackgroundTask/UIBuildingModelsCourtyardAuditTask.cs`

**Shape:** mirror `UIBuildingModelsVerificationTask.cs` (same base `ReportableBackgroundTask<long>, IGISPostgreSQLUIObject`; same `GISWebAPIManager` ctor; same county enumeration + `IsInScope` + batched pull + per-county CSV flush). Differences that make it the audit rather than the verification:

- **Exhaustive, not sampled.** The verification task draws `SampleSize` per county for a *comparison* baseline. The audit must enumerate **every** reference of every county in scope, because its output scopes the regeneration — a sample that misses a building's courtyard would leave that county out of the regenerate set. (A cheap "is this county affected at all?" pre-pass can use a sample, but the tally that is posted must be the exhaustive one.)
- **Two pulls per reference** (both already in the WebAPI surface, no new endpoint):
  1. `BuildingModelController.GetItemsByReferencesAsync` → the stored `DiGi.Analytical.Building.Classes.BuildingModel` (what `Footprints` runs on).
  2. `BuildingController.GetItemByReferenceAsync` → the stored `CityGML.Classes.Building` (what `UIBuildingModelsFromDatabasePostTask` reads; source of the `GroundSurface` ring).
- **The predicate** (a small private static, pure, unit-testable — the task stays I/O + tally):
  ```csharp
  // affected = the source GroundSurface carries an interior ring AND the stored model's footprint has no internal edge.
  static bool CourtyardLost(CityGML.Classes.Building? source, DiGi.Analytical.Building.Classes.BuildingModel? stored)
  {
      if (source is null || stored is null) { return false; }
      bool sourceHasRing  = source.Surfaces.OfType<CityGML.Classes.GroundSurface>().Any(g => Query.HasInternalRing(g));   // ≥1 interior ring
      bool storedHasHole  = stored.Footprints(Constants.Tolerance.Coordinate) is List<PolygonalFace2D> f && f.Any(p => p.InternalEdges is { Count: > 0 });
      return sourceHasRing && !storedHasHole;
  }
  ```
  - `sourceHasRing`/`storedHasHole` are the two halves the issue names. `Footprints` is the existing `DiGi.Analytical.Building.Query.Footprints` (see §2.1). `HasInternalRing` is the source-side accessor — confirm the exact `GroundSurface` → `PolygonalFace2D.InternalEdges` accessor against `DiGi.CityGML`/`DiGi.GIS` (the test `BuildingModelFromCityGML1465Courtyard` already proves the ring is present on the source, so the accessor exists; the plan pins the name at implementation).
  - **Where it lives:** the combined predicate straddles `DiGi.Analytical.Building` and `DiGi.CityGML` types, both referenced by *this* repo, so a private static in the task is the right home (no service/manager class, per `Coding - General` §2). If it is ever needed elsewhere, its natural home is `DiGi.Analytical.Building.Query` beside `Footprints` — but that is a separate-repo change and not required here.

**Properties** (mirror the verification task's): `CountyIds` (null = all), `VoivodeshipCodes` (null = all), `BatchSize` (default 50, URL-length bound), `Tolerance` (default `Analytical.Constants.Tolerance.Coordinate`), `ReportDirectory` (null → folder dialog, per the verification task), and a `Resume`/checkpoint (county id per line) so an estate-wide pass survives interruption, exactly like `UIBuildingModelsFromDatabasePostTask` does.

**Output** (into `ReportDirectory`, i.e. `user files/reports/`):
- `BuildingModels_CourtyardAudit.csv` — one row per reference: `Code;CountyId;Reference;SourceHasRing;StoredFootprintHasInternalEdge;Affected`.
- `BuildingModels_CourtyardAudit_Summary.txt` — per county + national: `Code;CountyId;Total;Affected;Ok(both);NoCourtyard`; plus a `AffectedCountyIds:` line — the ready-to-paste `CountyIds` scope for Part B.

**Registration** (`Create/VisualBackgroundTasks.cs`, Server mode, next to the existing two rows at lines 192 and 208):
```csharp
result.Add(Visual(new UIBuildingModelsCourtyardAuditTask(GISWebAPIManager),
    "Audit BuildingModels for filled courtyards",
    "Read-only: per county, models whose source CityGML GroundSurface has an interior ring but whose stored Footprints have no internal edge. Writes the affected set for the regeneration scope"));
```

**Test** (`DiGi.Test/DiGi.GIS.PostgreSQL.UI.xUnit/Facts/`): a `CourtyardAuditPredicate.cs` Facts class covering the three classifications using the `1465_38F62224-C903_CityGML.gml` fixture as the ring-bearing source — affected (ring + solid cap), ok (ring + hole), no-courtyard (no ring). The solid-cap "stored" model is the pre-fix shape the issue describes; build it from the same fixture by flattening the interior ring, or assert against the `Footprints` the defect produced. Report lines go to `DiGi.Test/user files/reports/` per `Coding - Automatic Tests.md`.

### Part A — as implemented (green)

- **Task:** `DiGi.GIS.PostgreSQL.UI/Classes/BackgroundTask/UIBuildingModelsCourtyardAuditTask.cs` — `ReportableBackgroundTask<long>, IGISPostgreSQLUIObject`, exhaustive per county, checkpointed (`BuildingModels_CourtyardAudit_Checkpoint.txt`), source pulls parallelised (`MaxConcurrentRequests`), stored-model pulls batched and only for source-bearing references.
- **Predicate (public static, unit-tested):** `SourceHasRing(CityGML.Classes.Building?)` (a `GroundSurface` whose `Geometry.InternalEdges` is non-empty), `StoredHasHole(DiGi.Analytical.Building.Classes.BuildingModel?, double)` (a `Footprints` face with a non-empty `InternalEdges`), and `IsAffected(source, stored, tolerance) = SourceHasRing && stored != null && !StoredHasHole`. Classifications: **Affected** / **Ok** / **Missing** (source ring, no stored model) / **NoCourtyard**.
- **Output:** `BuildingModels_CourtyardAudit.csv` (per reference) + `BuildingModels_CourtyardAudit_Summary.txt` (per-county + national totals and an `AffectedCountyIds:` line that is the ready-to-paste `CountyIds` scope for Part B).
- **Registration:** one row in `Create/VisualBackgroundTasks.cs` (Server mode, beside the existing Create/Verify rows) — *Audit BuildingModels for filled courtyards*.
- **Test:** `DiGi.Test/DiGi.GIS.PostgreSQL.UI.xUnit/Facts/UIBuildingModelsCourtyardAuditTask.cs` — pins all four classifications. The ring source is the `1465_…` courtyard fixture; the hole-less model is a plain box from `Buildings.json` (self-checked to carry no ring), paired with the courtyard source to pin **Affected = true**. `dotnet build` is clean (0 warnings) and the full `DiGi.GIS.PostgreSQL.UI.xUnit` suite is green (15/15).

> The audit is a read-only national pass and safe to run against the live host (no uploads). Scope it to one county first (`CountyIds = [1465]`) to sanity-check the output before the estate-wide run.

---

## 5. Part B — Idempotent regeneration of the affected counties

**Goal:** regenerate the affected references so the served model carries the courtyard, with **`building_model` row count per reference unchanged by the run** (the §2.2 finding: the write path adds a row per fresh build, so "just regenerate" would double every affected row).

**Mechanism (per affected county, in `CountyIds` order):**

1. **Snapshot before.** Read-only, per affected reference: `COUNT(*)` of `building_model_component` rows for that `county_id` + `reference` (and the distinct `unique_id`s). This is the "row count per reference before" evidence. Batched `ANY(@references)` per county, `commandTimeout` standard, no per-row loop — `Coding - PostgreSQL` §3.
2. **Clear the county's `building_model_component` partition** for that `county_id` (partition-level `TRUNCATE … FOR PARTITION (county_id = X)`; the table is `PARTITION BY LIST (county_id)`). This is the issue-#2 pattern — it makes the regeneration the *only* writer, so each building ends with exactly one row. Confirm the exact truncate form against `DiGi.GIS.PostgreSQL/Create/TableAsync.cs` DDL before running (or use the existing `RemoveAsync(references, countyId)` over the county's full reference list, which deletes by `(county_id, reference)`).
3. **Regenerate the county** with the existing `UIBuildingModelsFromDatabasePostTask`, scoped `CountyIds = [that county id]`, **with `BuildingModels_Regeneration_Checkpoint.txt` cleared** for that run (per the issue-#2 note: a stale checkpoint would skip the just-truncated county). Fixed build is live (step 1 done), so the split now keeps the ring.
4. **Snapshot after.** Same read-only count. **Acceptance gate:** for every affected reference, `after == before` (1 → 1), and the served model is the fixed one. If any reference shows `after > before`, the clear in step 2 did not cover it — stop and reconcile before moving to the next county.

**Why clear-then-regenerate rather than "regenerate and hope":** §2.2 shows the write path cannot replace-by-reference; the checkpoint only hides the problem by skipping. Clearing the partition is the only way to guarantee the "row count unchanged" acceptance and to avoid leaving a dead defective row beside the fixed one (a dead row is what `Query.Footprints`/`GetItemsByReferences` could still serve for an ambiguous read).

**Blast radius / safety:** clearing a partition removes *all* models for that county, not just the affected ones. That is acceptable because (a) the source `CityGML.Building` + `Building2D` rows are untouched, so re-running the regeneration rebuilds every one, and (b) the regeneration is checkpointed and resumable, so an interrupted county is redone in full. The source data is the ground truth; the table is a derived cache.

---

## 6. Part C — Second reference check + posted tally

1. **Pick a second affected building** — any `Affected` reference from the Part A CSV in a county *other than* `1465` (a different part, ideally a different voivodeship, so the check is not an artifact of one building). If the audit finds none outside `1465`, take the next-highest-county affected reference and say so — the point is "not just `38F62224-C903`."
2. **Re-fetch the served model** (`gis/buildingmodel/itemsbycircle?…` or `itemsbyreferences`) and run `Footprints` on it: **≥1 internal edge**, area ≈ the source interior ring. This is the single-building check already proven for #45, repeated on the second building. (`Coding - Deployed WebAPI` — swagger as the source of truth, manual curl, never added to `DiGi.Test`.)
3. **Browser DoD on that building** (only if #45-style visual proof is wanted for the second building): Playwright screenshot of `buildingmodel/itemsbyradius`, courtyard pixel terrain-coloured, not the `(23,26,33)` background — `Coding - Browser Testing` §5. #45 itself stays closed; this is the #13 evidence.
4. **Post the Part A per-county tally** as a comment on #13 (the acceptance item "Audit tally posted … per county").

---

## 7. Part D — Close #13 (structured + premise correction)

Two comments, both via `--body-file` (UTF-8, no BOM, `newline='\n'` — `GitHub - Issues` §1), then `gh issue close 13`.

1. **Premise-correction comment** (the §2.2 finding, with the code evidence): the "upsert is keyed on the building reference, so regenerating replaces rather than inserts" comment in `UIBuildingModelsFromDatabasePostTask.cs` is inaccurate — the conflict key is `(county_id, unique_id)` and `unique_id` is a fresh `Guid.NewGuid()`, so a regenerated model **inserts**; the safe re-run property comes from the county checkpoint and from the issue-#2 truncate-then-regenerate pattern. Offer to fix the code comment as a follow-up (it is a comment in a file in *this* repo, so it is in reach; do it as a small separate commit, not folded into the run).
2. **Resolution comment** (`GitHub - Issues` §3 structure): resolution & commits (SHA, branch `0.8.x`, this repo); summary (audit task added + registered, the affected counties cleared+regenerated); automated tests (the predicate Facts + the two existing `Footprints`/courtyard Facts); live verification (Part C second-building `Footprints` + browser DoD, and the before/after row-count proof). Then the acceptance checklist with all four boxes checked and the per-county tally inline.

---

## 8. Acceptance-criteria traceability

| #13 acceptance criterion | Met by |
|---|---|
| Audit tally posted (courtyard in source, none in stored outline), per county | Part A (exhaustive audit + `…_Summary.txt`) → Part C.4 (posted) |
| Affected models regenerated; `building_model` row count per reference unchanged by the run | Part B (clear-then-regenerate + before/after snapshot gate) |
| `Footprints` of the served `38F62224-C903…` model carries the courtyard | Already met (progress comment); re-confirmed by Part C on a second building |
| DiGi.GIS.WebAPI.UI#45 browser DoD met and the issue closed | #45 already closed; Part C.3 re-proves the DoD on a second building for #13's evidence |

---

## 9. Risks & mitigations

- **§2.2 — "regenerate" doubles rows.** *Mitigation:* Part B clears the county partition first (issue-#2 pattern) and gates on `after == before`.
- **Stale checkpoint skips the just-cleared county.** *Mitigation:* clear `BuildingModels_Regeneration_Checkpoint.txt` for each regenerated county (Part B step 3) — the issue-#2 registration comment says exactly this.
- **Audit is a national pass (slow).** *Mitigation:* checkpointed + resumable county-by-county; run voivodeship-by-voivodeship if the storage or GUGiK load is a concern (same `MaxConcurrentRequests`/`BatchSize` knobs as the sibling tasks).
- **Partition clear is destructive.** *Mitigation:* source `CityGML.Building` + `Building2D` are untouched; regeneration is the rebuild and is resumable; do it county-by-county with the before/after gate, never a bulk national truncate in one shot.
- **`ORDER BY` on county reads.** *Mitigation:* reuse `PostgreSQL.Query.IsInScope` / the existing reference paging (already ordered by cursor), per `Coding - GIS Administrative Data` §2.
- **Line endings on any file edit.** *Mitigation:* the only file edits are new `.cs` + one registration line + a code-comment fix; follow `Coding - General` §14 (edit bytes, detect the blob's convention).

---

## 10. Guidelines alignment

- **`Coding - General` §2 (anemic models + Query/Modify/Create/Convert):** the audit predicate is a pure `Query`-shaped static (no state, no service/manager); the task is I/O orchestration only. No `var`, block-scoped namespaces, `CancellationToken` last and by name, zero warnings (XML docs on the new public task).
- **`Coding - GIS Administrative Data`:** all scoping and reads by county **id**; multi-part counties handled by the existing per-part enumeration; `ORDER BY` respected on any county/reference read.
- **`Coding - PostgreSQL`:** before/after counts use batched `ANY(@references)` + `commandTimeout`, no per-row loop; the partition clear is an identifier-bearing statement resolved against the known `building_model_component` DDL (no dynamic user identifiers).
- **`Coding - Automatic Tests`:** the new predicate has a dedicated Facts class in `DiGi.Test/DiGi.GIS.PostgreSQL.UI.xUnit/Facts/`; report lines to `DiGi.Test/user files/reports/`; the existing `BuildingModel_Footprints_Courtyard` / `BuildingModelFromCityGML1465Courtyard` already pin the source-of-truth behaviour the audit relies on.
- **`Coding - Deployed WebAPI` / `Coding - Browser Testing`:** the second-building `Footprints` + screenshot DoD are manual curl/Playwright against the live host, never added to `DiGi.Test`.
- **`GitHub - Issues`:** §2 (verify premises — surfaced the §2.2 correction), §3 (structured resolution comment), §1 (`--body-file`, UTF-8/no BOM, no inline backtick markdown).
- **`Coding - General` §12 (temporary code):** the code-comment fix in Part D.1 is a permanent correction, not a `TODO [Marker]` — it removes an inaccurate justification, so no marker is attached.

---

*Open question for the owner before running Part B:* confirm the preferred "clear" form for the affected counties — **partition `TRUNCATE … FOR PARTITION (county_id = X)`** (recommended, matches issue #2) vs. **`RemoveAsync(affectedReferences, countyId)`** (smaller blast radius, only the affected references, but the whole-county regeneration would then also re-add the non-affected ones, so it must be paired with a whole-county clear). If the answer is "only the affected references should change," then Part B needs a reference-scoped regeneration, which is a small addition to `UIBuildingModelsFromDatabasePostTask` — flag it as a sub-task rather than doing it inline.
