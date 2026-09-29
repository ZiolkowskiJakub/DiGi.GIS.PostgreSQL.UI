#### [DiGi\.GIS\.PostgreSQL\.UI](DiGi.GIS.PostgreSQL.UI.Overview.md 'DiGi\.GIS\.PostgreSQL\.UI\.Overview')

## DiGi\.GIS\.PostgreSQL\.UI Namespace
### Classes

<a name='DiGi.GIS.PostgreSQL.UI.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Create.GISPostgreSQLConverterManagerConfigurationFile(string)'></a>

## Create\.GISPostgreSQLConverterManagerConfigurationFile\(string\) Method

Creates a new instance of a [GISPostgreSQLConverterManagerConfigurationFile\(string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Create.GISPostgreSQLConverterManagerConfigurationFile(string) 'DiGi\.GIS\.PostgreSQL\.UI\.Create\.GISPostgreSQLConverterManagerConfigurationFile\(string\)') from the specified path or default location\.

```csharp
public static DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile? GISPostgreSQLConverterManagerConfigurationFile(string? path=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Create.GISPostgreSQLConverterManagerConfigurationFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional path to the configuration file\. If omitted, resolves from the executing assembly's location\.

#### Returns
[GISPostgreSQLConverterManagerConfigurationFile](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.GISPostgreSQLConverterManagerConfigurationFile')  
A [GISPostgreSQLConverterManagerConfigurationFile\(string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Create.GISPostgreSQLConverterManagerConfigurationFile(string) 'DiGi\.GIS\.PostgreSQL\.UI\.Create\.GISPostgreSQLConverterManagerConfigurationFile\(string\)') instance if successful; otherwise, null\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string)'></a>

## Create\.VisualBackgroundTasks\(GISPostgreSQLConverterManager, UserPostgreSQLConverterManager, GISWebAPIManager, Mode, string\) Method

Creates and returns a sorted list of visual background tasks based on the specified operation mode and available managers\.

```csharp
public static System.Collections.Generic.List<DiGi.UI.WPF.Interfaces.IVisualBackgroundTask>? VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager? gISPostgreSQLConverterManager, DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager? userPostgreSQLConverterManager, DiGi.GIS.WebAPI.Classes.GISWebAPIManager? GISWebAPIManager, DiGi.GIS.PostgreSQL.UI.Enums.Mode mode, string? yearBuiltPredictionConsoleAppPath=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The manager responsible for PostgreSQL conversion operations\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string).userPostgreSQLConverterManager'></a>

`userPostgreSQLConverterManager` [DiGi\.User\.PostgreSQL\.Classes\.UserPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.user.postgresql.classes.userpostgresqlconvertermanager 'DiGi\.User\.PostgreSQL\.Classes\.UserPostgreSQLConverterManager')

The manager holding the converter for the user database, or null where no User\_PostgreSQL\_Main\.conf names one\. Users live in their own database rather than in the one the rest of this application works against\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager responsible for interacting with the PostgreSQL Web API\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string).mode'></a>

`mode` [Mode](DiGi.GIS.PostgreSQL.UI.Enums.md#DiGi.GIS.PostgreSQL.UI.Enums.Mode 'DiGi\.GIS\.PostgreSQL\.UI\.Enums\.Mode')

The operation mode \(Server, Client, or both\) that determines which tasks are instantiated\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string).yearBuiltPredictionConsoleAppPath'></a>

`yearBuiltPredictionConsoleAppPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An explicit path to the headless Year Built prediction runner, or null to let [YearBuiltPredictionConsoleAppPath\(string, string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Query.YearBuiltPredictionConsoleAppPath(string,string) 'DiGi\.GIS\.PostgreSQL\.UI\.Query\.YearBuiltPredictionConsoleAppPath\(string, string\)') probe for it\. A test supplies one to decide whether that task is offered without deploying the runner, the same seam its resolver already carries\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.wpf.interfaces.ivisualbackgroundtask 'DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.wpf.interfaces.ivisualbackgroundtask 'DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask') objects sorted by name, or null if not applicable\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.YOLOTrainingRunOptions(DiGi.GIS.PostgreSQL.UI.Enums.YOLOTrainingScenario,string,DiGi.GIS.YOLO.UI.Classes.YOLOTrainingRunOptions)'></a>

## Create\.YOLOTrainingRunOptions\(YOLOTrainingScenario, string, YOLOTrainingRunOptions\) Method

Creates the options of a tray YOLO detector training run with the defaults of the given scenario applied\.

Starts from a copy of [yOLOTrainingRunOptions](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Create.YOLOTrainingRunOptions(DiGi.GIS.PostgreSQL.UI.Enums.YOLOTrainingScenario,string,DiGi.GIS.YOLO.UI.Classes.YOLOTrainingRunOptions).yOLOTrainingRunOptions 'DiGi\.GIS\.PostgreSQL\.UI\.Create\.YOLOTrainingRunOptions\(DiGi\.GIS\.PostgreSQL\.UI\.Enums\.YOLOTrainingScenario, string, DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingRunOptions\)\.yOLOTrainingRunOptions') - the run the operator had before - or from the class defaults, and overwrites only what the scenario decides, so the counties, the folders, the device and the interpreter survive a switch between scenarios:

[Retrain](DiGi.GIS.PostgreSQL.UI.Enums.md#DiGi.GIS.PostgreSQL.UI.Enums.YOLOTrainingScenario.Retrain 'DiGi\.GIS\.PostgreSQL\.UI\.Enums\.YOLOTrainingScenario\.Retrain'): the start weights are the deployed model.pt, the epoch ceiling is 150, and the dataset folder is resumed ([DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingDatasetOptions\.Resume](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.classes.yolotrainingdatasetoptions.resume 'DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingDatasetOptions\.Resume') on), so the chosen counties are appended to it.

[Fresh](DiGi.GIS.PostgreSQL.UI.Enums.md#DiGi.GIS.PostgreSQL.UI.Enums.YOLOTrainingScenario.Fresh 'DiGi\.GIS\.PostgreSQL\.UI\.Enums\.YOLOTrainingScenario\.Fresh'): the start weights are the pretrained yolo26x.pt, the epoch ceiling is 300, and the dataset folder is not resumed, so the runner refuses a folder that already holds a dataset and the dataset is built fresh.

Both weights files are named relative to the runner and resolved against it here ([ConsoleAppFilePath\(string, string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppFilePath(string,string) 'DiGi\.GIS\.PostgreSQL\.UI\.Query\.ConsoleAppFilePath\(string, string\)')), because the runner resolves a relative start path against its own directory and this application would otherwise check a different file. A file that is not found keeps the absolute path the runner's deployed layout gives it ([ConsoleAppDeployedPath\(string, string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppDeployedPath(string,string) 'DiGi\.GIS\.PostgreSQL\.UI\.Query\.ConsoleAppDeployedPath\(string, string\)')), so the preflight names the place it looked rather than a relative name.

The dialog offers no control for most dataset members, and their class defaults are this surface's answer: the confidence, the split, the label check sizes, the legacy cut-off and the request sizes are the values the runner's README describes. Two defaults are set here rather than taken: [DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingDatasetOptions\.CountOnly](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.classes.yolotrainingdatasetoptions.countonly 'DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingDatasetOptions\.CountOnly') is forced off, because the committed runner template ships it on and a counting run trains nothing; and an empty [DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingRunOptions\.Steps](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.classes.yolotrainingrunoptions.steps 'DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingRunOptions\.Steps') is replaced by all five steps written out, because the runner reads an empty list as "all steps" and the dialog would otherwise show no step ticked for a run that runs every one. [DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingDatasetOptions\.WeightsPaths](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.classes.yolotrainingdatasetoptions.weightspaths 'DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingDatasetOptions\.WeightsPaths') defaults to the incumbent model.pt; the runner adds the candidate itself.

```csharp
public static DiGi.GIS.YOLO.UI.Classes.YOLOTrainingRunOptions YOLOTrainingRunOptions(DiGi.GIS.PostgreSQL.UI.Enums.YOLOTrainingScenario yOLOTrainingScenario, string? consoleAppPath, DiGi.GIS.YOLO.UI.Classes.YOLOTrainingRunOptions? yOLOTrainingRunOptions=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Create.YOLOTrainingRunOptions(DiGi.GIS.PostgreSQL.UI.Enums.YOLOTrainingScenario,string,DiGi.GIS.YOLO.UI.Classes.YOLOTrainingRunOptions).yOLOTrainingScenario'></a>

`yOLOTrainingScenario` [YOLOTrainingScenario](DiGi.GIS.PostgreSQL.UI.Enums.md#DiGi.GIS.PostgreSQL.UI.Enums.YOLOTrainingScenario 'DiGi\.GIS\.PostgreSQL\.UI\.Enums\.YOLOTrainingScenario')

The scenario whose defaults are applied\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.YOLOTrainingRunOptions(DiGi.GIS.PostgreSQL.UI.Enums.YOLOTrainingScenario,string,DiGi.GIS.YOLO.UI.Classes.YOLOTrainingRunOptions).consoleAppPath'></a>

`consoleAppPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the runner's executable the weights are resolved against, or null to leave relative names as they are\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.YOLOTrainingRunOptions(DiGi.GIS.PostgreSQL.UI.Enums.YOLOTrainingScenario,string,DiGi.GIS.YOLO.UI.Classes.YOLOTrainingRunOptions).yOLOTrainingRunOptions'></a>

`yOLOTrainingRunOptions` [DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingRunOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.classes.yolotrainingrunoptions 'DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingRunOptions')

The options to start from, which are copied rather than changed; or null to start from the class defaults\.

#### Returns
[DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingRunOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.classes.yolotrainingrunoptions 'DiGi\.GIS\.YOLO\.UI\.Classes\.YOLOTrainingRunOptions')  
A new options instance carrying the scenario's defaults\.

<a name='DiGi.GIS.PostgreSQL.UI.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppDeployedPath(string,string)'></a>

## Query\.ConsoleAppDeployedPath\(string, string\) Method

Returns the absolute path a headless runner will use for a path named relative to it, whether or not anything exists there yet \- a folder it writes into, such as `user files/reports`, or a file whose absence a preflight has to name\.

A rooted path is returned through [FullPath\(string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Query.FullPath(string) 'DiGi\.GIS\.PostgreSQL\.UI\.Query\.FullPath\(string\)'). A relative one is placed under the runner's folder with a leading [UserFiles](DiGi.GIS.PostgreSQL.UI.Constants.md#DiGi.GIS.PostgreSQL.UI.Constants.DirectoryName.UserFiles 'DiGi\.GIS\.PostgreSQL\.UI\.Constants\.DirectoryName\.UserFiles') segment removed, which is the layout the build deploys: the git-ignored folder is flattened into the output root, both in a workspace `bin` and on a deployed machine.

Resolved here rather than left to the runner, so that the path written into an options file is the one this application checked and named back - not one the other process resolves against a different directory.

```csharp
public static string? ConsoleAppDeployedPath(string? consoleAppPath, string? path);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppDeployedPath(string,string).consoleAppPath'></a>

`consoleAppPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the runner's executable\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppDeployedPath(string,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path, absolute or relative to the runner\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The absolute path; the path as [FullPath\(string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Query.FullPath(string) 'DiGi\.GIS\.PostgreSQL\.UI\.Query\.FullPath\(string\)') returns it when there is no runner folder to place it under; or null when it is null or blank\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppExitCodeAsync(string,System.Collections.Generic.IEnumerable_string_,string,System.IProgress_long_,System.Threading.CancellationToken)'></a>

## Query\.ConsoleAppExitCodeAsync\(string, IEnumerable\<string\>, string, IProgress\<long\>, CancellationToken\) Method

Runs the headless `DiGi.GIS.YOLO.UI.ConsoleApp` with the given arguments, logs everything it prints, reports its progress lines and returns the exit code it ended with\.

Both output streams are read as they arrive - a child whose output nobody drains blocks on a full pipe, and these runs talk for hours. Every standard output line is logged, and a `[PROGRESS]` line is read through the runner's own [DiGi\.GIS\.YOLO\.UI\.Query\.ProgressCount\(System\.String\)](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.query.progresscount#digi-gis-yolo-ui-query-progresscount(system-string) 'DiGi\.GIS\.YOLO\.UI\.Query\.ProgressCount\(System\.String\)') rather than a format literal, so a format that ever drifts costs the progress reporting and nothing else. Standard error lines are logged as warnings.

The exit code is named rather than numbered, read off the runner's own [DiGi\.GIS\.YOLO\.UI\.Enums\.YearBuiltPredictionExitCode](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.enums.yearbuiltpredictionexitcode 'DiGi\.GIS\.YOLO\.UI\.Enums\.YearBuiltPredictionExitCode'); a code this application does not recognise is logged as the number it is and still returned.

<b>Cancelling kills the whole process tree</b> rather than winding the run down: the interpreter is a grandchild, and killing only the runner would leave it holding a graphics card with nothing waiting for it. Whatever the run was writing may be half written. A cancelled wait returns [DiGi\.GIS\.YOLO\.UI\.Enums\.YearBuiltPredictionExitCode\.Cancelled](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.enums.yearbuiltpredictionexitcode.cancelled 'DiGi\.GIS\.YOLO\.UI\.Enums\.YearBuiltPredictionExitCode\.Cancelled').

```csharp
public static System.Threading.Tasks.Task<System.Nullable<DiGi.GIS.YOLO.UI.Enums.YearBuiltPredictionExitCode>> ConsoleAppExitCodeAsync(string consoleAppPath, System.Collections.Generic.IEnumerable<string>? arguments, string name, System.IProgress<long>? progress=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppExitCodeAsync(string,System.Collections.Generic.IEnumerable_string_,string,System.IProgress_long_,System.Threading.CancellationToken).consoleAppPath'></a>

`consoleAppPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the runner's executable\. Its folder is the working directory the runner starts in\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppExitCodeAsync(string,System.Collections.Generic.IEnumerable_string_,string,System.IProgress_long_,System.Threading.CancellationToken).arguments'></a>

`arguments` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The arguments, each passed through [System\.Diagnostics\.ProcessStartInfo\.ArgumentList](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.processstartinfo.argumentlist 'System\.Diagnostics\.ProcessStartInfo\.ArgumentList') rather than a quoted string, so a path ending in a separator cannot escape its own closing quote\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppExitCodeAsync(string,System.Collections.Generic.IEnumerable_string_,string,System.IProgress_long_,System.Threading.CancellationToken).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the run the log lines are headed with, for example "Year built prediction"\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppExitCodeAsync(string,System.Collections.Generic.IEnumerable_string_,string,System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The receiver of the processed item counts the runner reports, or null\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppExitCodeAsync(string,System.Collections.Generic.IEnumerable_string_,string,System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that stops the run by killing its process tree\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.YOLO\.UI\.Enums\.YearBuiltPredictionExitCode](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.enums.yearbuiltpredictionexitcode 'DiGi\.GIS\.YOLO\.UI\.Enums\.YearBuiltPredictionExitCode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The exit code the runner ended with; [DiGi\.GIS\.YOLO\.UI\.Enums\.YearBuiltPredictionExitCode\.Cancelled](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.enums.yearbuiltpredictionexitcode.cancelled 'DiGi\.GIS\.YOLO\.UI\.Enums\.YearBuiltPredictionExitCode\.Cancelled') when the token stopped it; or null when it could not be started, or failed while it was being watched\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppFilePath(string,string)'></a>

## Query\.ConsoleAppFilePath\(string, string\) Method

Finds an existing file named relative to a headless runner rather than to this application \- the weights and data files the runner's defaults name, such as `user files/YOLO/models/model.pt`\.

Three candidates in order: the path as given when it is absolute, then the path under the runner's folder, then the path under the runner's folder with a leading [UserFiles](DiGi.GIS.PostgreSQL.UI.Constants.md#DiGi.GIS.PostgreSQL.UI.Constants.DirectoryName.UserFiles 'DiGi\.GIS\.PostgreSQL\.UI\.Constants\.DirectoryName\.UserFiles') segment removed. The build flattens that git-ignored folder into the output root, so a file named through it sits one segment shallower once deployed; the runner's own resolver strips the segment the same way, and this mirrors it rather than guessing.

A relative path is never tried against this application's own current directory: the runner starts in its own folder, so that is the only directory a relative name means anything in, and a file found beside this application would be a different file with the same name.

Only an existing file is returned. A caller that needs a path to write into, or a path to name in a refusal, uses [ConsoleAppDeployedPath\(string, string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppDeployedPath(string,string) 'DiGi\.GIS\.PostgreSQL\.UI\.Query\.ConsoleAppDeployedPath\(string, string\)').

```csharp
public static string? ConsoleAppFilePath(string? consoleAppPath, string? path);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppFilePath(string,string).consoleAppPath'></a>

`consoleAppPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the runner's executable\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.ConsoleAppFilePath(string,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path, absolute or relative to the runner\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The absolute path of the file found, or null when the path is blank or no candidate exists\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.FullPath(string)'></a>

## Query\.FullPath\(string\) Method

Returns the absolute form of a path this application hands to another process\.

The two processes do not share a working directory - this one runs from wherever the tray application was started, a runner from beside its own executable - so a relative path names a different folder on each side, and neither would report anything wrong. Made absolute here, before it is written into an options file, it means the same thing to both.

A path this machine cannot even form is returned exactly as it was typed, so that the run fails naming what the operator wrote rather than something this method invented from it.

```csharp
public static string? FullPath(string? path);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Query.FullPath(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to resolve against this process's current directory\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The absolute path; the path unchanged when it cannot be formed; or null when it is null or blank\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.YearBuiltPredictionConsoleAppPath(string,string)'></a>

## Query\.YearBuiltPredictionConsoleAppPath\(string, string\) Method

Finds the headless Year Built prediction runner this application hands a run to\.

The runner is a separate deployment unit rather than an assembly this application loads, because hosting the pipeline here would mean referencing the machine learning closure - about a gigabyte of native libraries against an application that publishes self-contained and single-file. The cost of that choice is that the executable has to be found rather than linked, which is what this answers.

Five candidates in order: the path given, then beside this application's own output, then the optional extensions folder inside it, then the runner's own folder beside this one's, then the runner's build output in a workspace checkout. The last is what makes the task runnable from a development machine without deploying anything.

A candidate that does not exist is not returned. A path that only looks resolved would be discovered as a failure to start a process, after the counties had been chosen and the imagery scoped.

```csharp
public static string? YearBuiltPredictionConsoleAppPath(string? path=null, string? baseDirectory=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Query.YearBuiltPredictionConsoleAppPath(string,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An explicit path to the runner, or null to search the candidates below it\.

<a name='DiGi.GIS.PostgreSQL.UI.Query.YearBuiltPredictionConsoleAppPath(string,string).baseDirectory'></a>

`baseDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the candidates are resolved against, or null to use this application's own output\. A test supplies one to probe a laid\-out folder without deploying\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The full path of an executable that exists, or null when none of the candidates does\.