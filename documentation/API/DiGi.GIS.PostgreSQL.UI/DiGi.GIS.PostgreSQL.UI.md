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

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string)'></a>

## Create\.VisualBackgroundTasks\(GISPostgreSQLConverterManager, GISWebAPIManager, Mode, string\) Method

Creates and returns a sorted list of visual background tasks based on the specified operation mode and available managers\.

```csharp
public static System.Collections.Generic.List<DiGi.UI.WPF.Interfaces.IVisualBackgroundTask>? VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager? gISPostgreSQLConverterManager, DiGi.GIS.WebAPI.Classes.GISWebAPIManager? GISWebAPIManager, DiGi.GIS.PostgreSQL.UI.Enums.Mode mode, string? yearBuiltPredictionConsoleAppPath=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The manager responsible for PostgreSQL conversion operations\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager responsible for interacting with the PostgreSQL Web API\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string).mode'></a>

`mode` [Mode](DiGi.GIS.PostgreSQL.UI.Enums.md#DiGi.GIS.PostgreSQL.UI.Enums.Mode 'DiGi\.GIS\.PostgreSQL\.UI\.Enums\.Mode')

The operation mode \(Server, Client, or both\) that determines which tasks are instantiated\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode,string).yearBuiltPredictionConsoleAppPath'></a>

`yearBuiltPredictionConsoleAppPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An explicit path to the headless Year Built prediction runner, or null to let [YearBuiltPredictionConsoleAppPath\(string, string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Query.YearBuiltPredictionConsoleAppPath(string,string) 'DiGi\.GIS\.PostgreSQL\.UI\.Query\.YearBuiltPredictionConsoleAppPath\(string, string\)') probe for it\. A test supplies one to decide whether that task is offered without deploying the runner, the same seam its resolver already carries\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.wpf.interfaces.ivisualbackgroundtask 'DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.wpf.interfaces.ivisualbackgroundtask 'DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask') objects sorted by name, or null if not applicable\.

<a name='DiGi.GIS.PostgreSQL.UI.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

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