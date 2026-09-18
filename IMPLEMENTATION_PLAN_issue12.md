# Implementation Plan — DiGi.GIS.PostgreSQL.UI #12

**UI background task *Update external components area* for `building_data`**

- Issue: https://github.com/ZiolkowskiJakub/DiGi.GIS.PostgreSQL.UI/issues/12 (open, `type: feature`, `priority: high`, `ai: standard`)
- Parent tracking issue: DiGi.GIS.PostgreSQL #83 (*External Components Area*)
- Dependency DiGi.GIS.PostgreSQL #82 (domain task + options): **done** — code present in branch `0.8.10`
- Follow-up (in scope, separate step): `DiGi.GIS.PostgreSQL.UI` wiki, page *Loading from scratch*
- **Status: v1 — created 2026-09-18 after verifying every premise of the issue against the code.**

---

## 1. Validity assessment

The issue is **still valid and actionable**. None of its deliverables exist in this repository: a search for `ExternalComponents` under `DiGi.GIS.PostgreSQL.UI/` returns no code hits (the only hits are the guideline skill text quoting this issue's row in the #83 sub-issues table).

### Premises verified against code (with evidence)

| Issue claim | Status | Evidence |
|---|---|---|
| Domain task `PostgreSQLBuildingDataExternalComponentsUpdateTask` exists | ✅ | `DiGi.GIS.PostgreSQL/Classes/BackgroundTask/PostgreSQLBuildingDataExternalComponentsUpdateTask.cs` — `ReportableBackgroundTask<long>, IGISPostgreSQLObject`, ctor `(GISPostgreSQLConverterManager)`, counters `FailedCountyCount` / `ProcessedCountyCount` / `ProcessedModelCount` / `SkippedComponentCount` / `UpdatedRowCount` |
| Options class exists with `CommandTimeout` and `CountyIds` | ✅ | `DiGi.GIS.PostgreSQL/Classes/Options/PostgreSQLBuildingDataExternalComponentsUpdateOptions.cs` — `CommandTimeout` default **600** ("a value of 0 disables the timeout"), `CountyIds` default **null = all counties**, copy constructor present |
| The consumed `DiGi.GIS.PostgreSQL.dll` already contains both types | ✅ | The UI project references `..\..\DiGi.GIS.PostgreSQL\bin\DiGi.GIS.PostgreSQL.dll` (HintPath); a byte search of that DLL finds both type names; DLL rebuilt 2026-09-18, after the #84 commits on branch `0.8.10` |
| Wrapper pattern to mirror at `UIPostgreSQLBuildingDataUpdateTask.cs` lines 15–83 | ✅ | `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Classes/BackgroundTask/UIPostgreSQLBuildingDataUpdateTask.cs` — class at line 15, `ExecuteAsync` at line 27; Application check → converter check → county references → dispatcher dialog → cancelled-refusal → `base.ExecuteAsync` |
| Window pattern to mirror at `PostgreSQLBuildingDataUpdateOptionsWindow.xaml.cs` lines 60–96 | ✅ | `Button_OK_Click` at line 60; the `commandTimeout < 0` refusal at line 78; empty update-type and empty-county refusals in between |
| Registration point at `Create\VisualBackgroundTasks.cs` line 63, Server mode | ✅ | Line 63 is the *Update building data* row, inside `if (mode == Mode.Server || mode == Mode.ServerAndCient)` → `if (gISPostgreSQLConverterManager is not null)` |
| The `Visual(...)` helper already wires failure logging on `Stopped` | ✅ | Local function in `Create.VisualBackgroundTasks`, top of the method: subscribes `Stopped`, logs `backgroundTask.Exception` |
| No tray/`MainWindow` changes needed | ✅ | `MainWindow` binds the returned collections; the task list is built by `Create.VisualBackgroundTasks` and sorted by name at the end (`result.Sort((x, y) => x.Name!.CompareTo(y.Name))`) |
| `IGISPostgreSQLUIObject` is the marker interface to implement | ✅ | `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Interfaces/IGISPostgreSQLUIObject.cs` — empty marker interface, namespace `DiGi.GIS.PostgreSQL.UI.Interfaces` |
| County-read API used by the wrapper exists | ✅ | `AdministrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync(AdministrativeArealType, int? parentId = null, bool uniqueCode = false, int commandTimeout = 30, CancellationToken cancellationToken = default)` |
| Test project with direct analogs exists | ✅ | `DiGi.Test/DiGi.GIS.PostgreSQL.UI.xUnit/Facts/` — `PostgreSQLBuildingDataUpdateOptionsWindow.cs` (window-construction Fact), `VisualBackgroundTasks.cs` (registration Facts) |
| Wiki page for the follow-up exists | ✅ | `wiki/DiGi.GIS.PostgreSQL.UI.wiki/Loading-from-scratch.md` — task table currently numbered 0–7; the new step will be **8** |
| `ListBoxControl` supports the needed selection API | ✅ | `DiGi.UI.WPF/Controls/ListBoxControl.xaml.cs` — `SetItems<T>`, `GetItems<T>(selected = true)`, `SelectItems<T>(Func<T, bool>?)` (a `_ => true` selects all), `ItemAdding` event, built-in Select all / Select none buttons |

### Decisions the issue leaves open — resolved here

1. **"non-positive timeout" vs the established "0 disables" contract.** The issue says to refuse a "non-positive timeout"; the established contract in this exact area is different and documented in three places: the domain options `<summary>` ("A value of 0 disables the timeout"), the existing window's label ("Command timeout in seconds - 0 disables it") and its check (`commandTimeout < 0`, i.e. only negatives refused). **Decision: follow the established contract — refuse negative values, allow 0.** Refusing 0 would contradict the documented behaviour of the options class this dialog configures.
2. **"County multi-select (default: all)".** The existing window leaves the list unselected when the options carry no county set. **Decision: the new window pre-selects every county when the options carry no county set** (`SelectItems<AdministrativeAreal2DReference>(x => true)`); when the options carry a set, restore that selection matched by `Id`. An empty selection at OK time is still refused, so the all-counts default can be turned off only deliberately — the same guard against an accidental national pass the existing window has.
3. **Window shape.** Mirror the existing XAML minus the two *Update types* rows: counties label (28) / county list (`*`) / command-timeout box (60) / buttons (33). `Height="482" MinHeight="360"`, width unchanged.

---

## 2. Scope

**In scope (this issue):**

- `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Classes/BackgroundTask/UIPostgreSQLBuildingDataExternalComponentsUpdateTask.cs` (new)
- `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Windows/PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow.xaml` (+ `.xaml.cs`) (new)
- One registration row in `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Create/VisualBackgroundTasks.cs`
- Facts in `DiGi.Test/DiGi.GIS.PostgreSQL.UI.xUnit/Facts/`
- Wiki follow-up: `wiki/DiGi.GIS.PostgreSQL.UI.wiki/Loading-from-scratch.md` (step 8)

**Out of scope:**

- `BuildingDataUpdateType` / `PostgreSQLBuildingDataUpdateOptions` / the *Update building data* task — **not touched** (standalone task; a model-less county must not fail the shared task)
- Anything in `DiGi.GIS.PostgreSQL` (done by #82) or `DiGi.GIS.IO` (done by #11)
- `MainWindow`, `App`, the Application project — the returned task list is bound automatically
- Client-mode registration — the task reads the storage database directly, like *Update building data*

---

## 3. Part 1 — UI wrapper task

**File:** `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Classes/BackgroundTask/UIPostgreSQLBuildingDataExternalComponentsUpdateTask.cs`

Mirror `UIPostgreSQLBuildingDataUpdateTask.cs` (lines 15–83) line-for-line in structure. Usings identical to that file (drop none, add none — every one is used):

```cs
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.UI.Interfaces;
using DiGi.GIS.PostgreSQL.UI.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
```

```cs
namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    public class UIPostgreSQLBuildingDataExternalComponentsUpdateTask : PostgreSQLBuildingDataExternalComponentsUpdateTask, IGISPostgreSQLUIObject
    {
        public UIPostgreSQLBuildingDataExternalComponentsUpdateTask(GISPostgreSQLConverterManager GISPostgreSQLConverterManager)
            : base(GISPostgreSQLConverterManager)
        {
        }

        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            // 1. System.Windows.Application.Current check — no WPF application: log via Serilog.Modify, return false
            // 2. Resolve AdministrativeAreal2DPostgreSQLConverter from gISPostgreSQLConverterManager — null: log, return false
            // 3. List<AdministrativeAreal2DReference>? administrativeAreal2DReferences =
            //      await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync(
            //          PostgreSQL.Enums.AdministrativeArealType.County, parentId: null, uniqueCode: false,
            //          commandTimeout: PostgreSQLBuildingDataExternalComponentsUpdateOptions.CommandTimeout, cancellationToken: cancellationToken);
            //    null/empty: log, return false
            // 4. application.Dispatcher.Invoke(() => { show PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow(
            //        PostgreSQLBuildingDataExternalComponentsUpdateOptions, administrativeAreal2DReferences);
            //        on non-true ShowDialog() return; capture the window's options; });
            // 5. options null (dialog cancelled): log "options were cancelled - nothing was written", return false
            // 6. PostgreSQLBuildingDataExternalComponentsUpdateOptions = postgreSQLBuildingDataExternalComponentsUpdateOptions;
            //    return await base.ExecuteAsync(progress, cancellationToken);
        }
    }
}
```

Carry over from the reference implementation, adapted:

- The XML `<summary>` on the class and the inline comments explaining **why** the dialog must run on the dispatcher thread, **why** references (not ids) are read for the dialog (406 parts of 380 codes; bare integers are not selectable), and **why** `uniqueCode` stays `false` (a multi-part county collapsing to one part loses territory).
- The county-read timeout comes from `PostgreSQLBuildingDataExternalComponentsUpdateOptions.CommandTimeout` (default 600), matching how the reference reads from its own options.
- Zero compiler warnings: public members need XML docs (`GenerateDocumentationFile` is on); `CancellationToken` stays last and is passed by name.

---

## 4. Part 2 — options window

**Files:** `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Windows/PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow.xaml` and `.xaml.cs`

### 4.1 XAML

Mirror `PostgreSQLBuildingDataUpdateOptionsWindow.xaml` minus the two *Update types* rows. Same window chrome (`SingleBorderWindow`, `CenterScreen`, the `DiGi.GIS.ico` icon, `local` and `controls` xmlns), same `controls:ListBoxControl` / `controls:TextBoxControl` from `DiGi.UI.WPF`:

| Grid row | Height | Content |
|---|---|---|
| 0 | 28 | `Label_Counties` — "Counties - a multi-part county is one entry per piece; select them all" (carried over from the reference; the all-selected default is noted in the code-behind comment) |
| 1 | `*` | `controls:ListBoxControl x:Name="ListBoxControl_Counties" SelectionMode="Extended"` |
| 2 | 60 | `controls:TextBoxControl x:Name="TextBoxControl_CommandTimeout"` — "Command timeout in seconds - 0 disables it" (label carried over; the contract is the domain options' "0 disables the timeout") |
| 3 | 33 | `Button_OK` (IsDefault) / `Button_Cancel` (IsCancel), same sizes/margins as the reference |

`Height="482" MinHeight="360" Width="560" MinWidth="440"`, `Title="Update external components area"`.

### 4.2 Code-behind

Mirror `PostgreSQLBuildingDataUpdateOptionsWindow.xaml.cs`, minus the update-type members:

```cs
public partial class PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow : Window
{
    private readonly PostgreSQLBuildingDataExternalComponentsUpdateOptions postgreSQLBuildingDataExternalComponentsUpdateOptions;

    public PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow(
        PostgreSQLBuildingDataExternalComponentsUpdateOptions? postgreSQLBuildingDataExternalComponentsUpdateOptions,
        IEnumerable<AdministrativeAreal2DReference>? administrativeAreal2DReferences)
    {
        // copy the options — a cancelled dialog leaves the caller's instance untouched
        // TextBoxControl_CommandTimeout.Value = CommandTimeout.ToString()
        // subscribe ListBoxControl_Counties.ItemAdding BEFORE SetItems
        // SetCounties(administrativeAreal2DReferences)
    }

    public PostgreSQLBuildingDataExternalComponentsUpdateOptions PostgreSQLBuildingDataExternalComponentsUpdateOptions { get { ... } }
}
```

- **`SetCounties`:** carry the reference implementation's sort (ordinal by `Code`, then `Id` — the pieces of a multi-part county share code and name; the identifier is what separates them) and its item naming `e.Name = $"{Code} {Name} (id {Id})"`.
  - Selection restore: options carry `CountyIds` → `SelectItems<AdministrativeAreal2DReference>(x => countyIds.Contains(x.Id))` (matched on the identifier, never on reference identity — see §8); options carry none → **select all** (`SelectItems<AdministrativeAreal2DReference>(x => true)`), the issue's "default: all".
- **`Button_OK_Click`:**
  1. `GetItems<AdministrativeAreal2DReference>()` null/empty → `MessageBox` "At least one county has to be selected.", stay open.
  2. `!TextBoxControl_CommandTimeout.TryGetValue(out int commandTimeout) || commandTimeout < 0` → `MessageBox` "Command timeout has to be a whole number of seconds, zero or greater.", stay open. (Zero is legal — it disables the timeout; only negatives are refused. See decision 1.)
  3. Build `HashSet<int> countyIds` from the selected items' `Id`s; assign `CountyIds` + `CommandTimeout`; `DialogResult = true; Close();`
- **`Button_Cancel_Click`:** `DialogResult = false; Close();`
- XML `<summary>` on the class (what the window asks for and why scoping matters — carried in spirit from the reference) and on the public constructor/property with `<param>` tags mirroring the signature order.

No `.csproj` change: WPF auto-includes the new `.xaml`/`.xaml.cs`, and both `DiGi.UI.WPF` and `DiGi.GIS.PostgreSQL` are already referenced.

---

## 5. Part 3 — registration

**File:** `DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/Create/VisualBackgroundTasks.cs`

Insert the issue's row verbatim directly after line 63 (the *Update building data* row), inside the Server block, where `gISPostgreSQLConverterManager` is non-null:

```cs
result.Add(Visual(new UIPostgreSQLBuildingDataExternalComponentsUpdateTask(gISPostgreSQLConverterManager), "Update external components area", "Populates the External Components Area columns of building_data (external wall / roof / floor areas by direction and roof tilt) from BuildingModels stored in building_model_component."));
```

No gating: the row's preconditions (a storage converter manager, which the `Visual` block already guarantees) are the same as the neighbouring *Update building data* row. The failure-logging `Stopped` subscription comes from the `Visual` helper; the list is sorted by name at the end of the method, so the code position is organizational only.

---

## 6. Tests

Project: `DiGi.Test/DiGi.GIS.PostgreSQL.UI.xUnit` (global `Xunit` using, `public partial class Facts` under `Facts/`, XML docs on every Fact — per `Coding - Automatic Tests.md`).

### 6.1 `Facts/PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow.cs` (new file)

**`PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow_Construction`** — mirror of the existing `PostgreSQLBuildingDataUpdateOptionsWindow_Construction`:

- STA thread; construct the window with options `{ CountyIds = [4816], CommandTimeout = 600 }` and a county list that includes a multi-part pair (same code and name, two `Id`s) — the pair is what the `(id …)` naming exists for.
- Assert the held options carry the given `CountyIds` and `CommandTimeout`; assert the window works on a **copy** (`ReferenceEquals` false; mutating the held copy's `CommandTimeout` leaves the caller's instance untouched).
- The default-all pre-selection cannot be asserted from here (the controls are private and the selection is written back only on OK — the same limitation the reference Fact records in its `<summary>`). It is checked once visually in §7.

### 6.2 `Facts/VisualBackgroundTasks.cs` (append)

**`VisualBackgroundTasks_UIPostgreSQLBuildingDataExternalComponentsUpdateTask`** — mirror of `VisualBackgroundTasks_UIPostgreSQLUserCreateTask`:

- `Create.VisualBackgroundTasks(new GISPostgreSQLConverterManager(), null, null, Mode.Server)` → `Assert.Contains(..., x => x.TypeName == typeof(UIPostgreSQLBuildingDataExternalComponentsUpdateTask).Name)`, and the row's `Name` is exactly `Update external components area` (the acceptance criterion's visible label).
- Same call with `Mode.Client` → `Assert.DoesNotContain(...)` — Server mode only.
- `Create.VisualBackgroundTasks(null, null, null, Mode.Server)` → still empty (the existing Fact already asserts the empty case; the new row lives behind the non-null-manager check).
- Nothing in these calls touches a database: the task is registered, never started.

### 6.3 Build order (mandatory)

The xUnit project reaches the code under test through `<Reference><HintPath>`; `dotnet test` runs against whatever was last built into `DiGi.GIS.PostgreSQL.UI/bin`. **Build the UI project first, then test** (`Coding - Automatic Tests.md` §4):

```
dotnet build DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI/DiGi.GIS.PostgreSQL.UI.csproj -c Debug -m:1
dotnet test DiGi.Test/DiGi.GIS.PostgreSQL.UI.xUnit/DiGi.GIS.PostgreSQL.UI.xUnit.csproj -c Debug -m:1
```

---

## 7. Verification & acceptance

Mapping to the issue's acceptance criteria:

| Criterion | How it is met |
|---|---|
| Task appears in the Server tab as **Update external components area** with the description | §5 registration; §6.2 Fact asserts the name and mode; verified once visually in the tray app |
| Options dialog opens before execution, validates input, honours county selection + timeout | §3 wrapper (dialog on the dispatcher, cancellation refused with a log line); §4 window validation; §6.1 Fact covers construction/copy semantics |
| A run against a county with stored models updates exactly the 35 External Components Area columns (progress, counters); cancellation stops promptly | The domain task's contract (`DiGi.GIS.PostgreSQL #82`) — this wrapper only hands it scoped options and the token; run once against the dev database from the tray app and read the finish log (`ProcessedCountyCount`, `UpdatedRowCount`, `SkippedComponentCount`) rather than trusting the run's own verdict |
| Wiki *Loading from scratch* task table extended with the new step | §8 below |

Build gate: `dotnet build` of the UI project with **zero warnings** (`GenerateDocumentationFile` is on — every new public member is documented).

---

## 8. Wiki follow-up (separate step, after the code lands)

Per `GitHub Wiki - General.md` — `Loading-from-scratch.md` is a **hand-authored** page (CI sync only overwrites the auto-generated API pages), edited in the local clone and pushed to `master`:

```
cd wiki/DiGi.GIS.PostgreSQL.UI.wiki && git pull
```

Add a row after step 7 (the step that creates the building models this task reads — hence the issue's "once the numbering is known": it is **8**):

| # | Tray app task | Writes | Cost (Poland) |
|---|---|---|---|
| 8 | *Update external components area* - counties + statement timeout asked in a dialog | the 35 `External Components Area` columns of `building_data` (external wall / roof / floor areas by direction and roof tilt) from the stored `building_model_component` models | per county, minutes to an hour |

Add the one sentence the page's style calls for: it needs the building models of step 7 to exist, and a county without stored models is processed, not failed (its buildings keep their current values). Commit and `git push origin HEAD`.

---

## 9. Guideline compliance

| Guideline | Applied |
|---|---|
| `Coding - General.md` | English only; explicit typing, no `var`; block-scoped namespaces; XML docs on all public members; zero warnings; `CancellationToken` last, passed by name; parameter lists ≤ 7 stay single-line; naming with type prefix (`postgreSQLBuildingDataExternalComponentsUpdateOptions`); defaults are the contract (§4 — the window's defaults come from the options class and are labelled as such); line endings preserved — edits through the file tools, new files created with the repository's CRLF convention |
| `Coding - GIS Administrative Data.md` | County keying by **`id`, never `code`** (the selection is stored as `HashSet<int>` of ids; the list naming shows code + name + id because that is all a multi-part county's pieces share); 406 parts of 380 codes, `uniqueCode: false`, both pieces of a multi-part county selectable; no `LIMIT`/`FirstOrDefault` over `administrative_areal_2d` anywhere in the new code |
| `Coding - References.md` | No `==`/`!=` between `AdministrativeAreal2DReference` instances — selection restore matches on `x.Id`, exactly as the reference window does |
| `Coding - Automatic Tests.md` | `Facts` partial class, one file per subject, XML docs with `<para>`, STA thread for the WPF construction Fact, build-the-changed-assembly-before-test rule (§6.3) |
| `GitHub Wiki - General.md` | Hand-authored page only, pulled before edit, pushed to `master` (§8) |
| `AI Guidelines` README portability rule | This plan uses workspace-relative paths only |

---

## 10. Open risks

1. **The consumed DLL must stay current.** The UI project binds `DiGi.GIS.PostgreSQL.dll` by HintPath; if `DiGi.GIS.PostgreSQL` is rebuilt from an older branch the UI build fails loudly (missing type) — acceptable, but re-check the branch before building (§1 already verified `0.8.10` today).
2. **The visual pass is still human.** Both new Facts state in their docs what they cannot check (layout, the default-all selection, the dialog on screen) — the reference window shipped with exactly this convention. One manual open of the dialog against the dev database closes it.
3. **Acceptance criterion 3 is integration-level.** It runs the domain task against a real database; no Fact in this repository reaches that far. The dev-database run in §7 is the evidence, and the counters it logs are the assertion.
