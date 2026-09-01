#### [DiGi\.GIS\.PostgreSQL\.UI](DiGi.GIS.PostgreSQL.UI.Overview.md 'DiGi\.GIS\.PostgreSQL\.UI\.Overview')

## DiGi\.GIS\.PostgreSQL\.UI\.Classes Namespace
### Classes

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile'></a>

## GISPostgreSQLConverterManagerConfigurationFile Class

Represents a configuration file specifically for the GIS PostgreSQL converter manager settings, extending the base configuration file functionality\.

```csharp
public class GISPostgreSQLConverterManagerConfigurationFile : DiGi.Core.Classes.ConfigurationFile, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.ConfigurationFile](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.configurationfile 'DiGi\.Core\.Classes\.ConfigurationFile') → GISPostgreSQLConverterManagerConfigurationFile

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile.GISPostgreSQLConverterManagerConfigurationFile()'></a>

## GISPostgreSQLConverterManagerConfigurationFile\(\) Constructor

Initializes a new empty instance of the [GISPostgreSQLConverterManagerConfigurationFile](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.GISPostgreSQLConverterManagerConfigurationFile') class\.

```csharp
public GISPostgreSQLConverterManagerConfigurationFile();
```

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile.GISPostgreSQLConverterManagerConfigurationFile(DiGi.Core.Classes.ConfigurationFile)'></a>

## GISPostgreSQLConverterManagerConfigurationFile\(ConfigurationFile\) Constructor

Initializes a new instance of the [GISPostgreSQLConverterManagerConfigurationFile](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.GISPostgreSQLConverterManagerConfigurationFile') class by copying settings from another [DiGi\.Core\.Classes\.ConfigurationFile](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.configurationfile 'DiGi\.Core\.Classes\.ConfigurationFile')\.

```csharp
public GISPostgreSQLConverterManagerConfigurationFile(DiGi.Core.Classes.ConfigurationFile? configurationFile);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile.GISPostgreSQLConverterManagerConfigurationFile(DiGi.Core.Classes.ConfigurationFile).configurationFile'></a>

`configurationFile` [DiGi\.Core\.Classes\.ConfigurationFile](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.configurationfile 'DiGi\.Core\.Classes\.ConfigurationFile')

The source configuration file to copy settings from\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile.GISPostgreSQLConverterManagerConfigurationFile(System.Text.Json.Nodes.JsonObject)'></a>

## GISPostgreSQLConverterManagerConfigurationFile\(JsonObject\) Constructor

Initializes a new instance of the [GISPostgreSQLConverterManagerConfigurationFile](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.GISPostgreSQLConverterManagerConfigurationFile') class from a [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')\.

```csharp
public GISPostgreSQLConverterManagerConfigurationFile(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile.GISPostgreSQLConverterManagerConfigurationFile(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the configuration data\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile.Key'></a>

## GISPostgreSQLConverterManagerConfigurationFile\.Key Property

Gets or sets the API authorization key used for authenticating requests to protected Web API endpoints\.

```csharp
public string? Key { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLTrayApplicationContext'></a>

## GISPostgreSQLTrayApplicationContext Class

Provides the application context for the GIS PostgreSQL tray application, managing its lifecycle and dependencies\.

```csharp
public class GISPostgreSQLTrayApplicationContext : DiGi.UI.Windows.Classes.TrayApplicationContext<DiGi.GIS.PostgreSQL.UI.Windows.MainWindow>
```

Inheritance [System\.Windows\.Forms\.ApplicationContext](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.applicationcontext 'System\.Windows\.Forms\.ApplicationContext') → [DiGi\.UI\.Windows\.Classes\.TrayApplicationContext&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.windows.classes.trayapplicationcontext-1 'DiGi\.UI\.Windows\.Classes\.TrayApplicationContext\`1')[MainWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.MainWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.MainWindow')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.windows.classes.trayapplicationcontext-1 'DiGi\.UI\.Windows\.Classes\.TrayApplicationContext\`1') → GISPostgreSQLTrayApplicationContext
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLTrayApplicationContext.GISPostgreSQLTrayApplicationContext()'></a>

## GISPostgreSQLTrayApplicationContext\(\) Constructor

Initializes a new instance of the [GISPostgreSQLTrayApplicationContext](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLTrayApplicationContext 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.GISPostgreSQLTrayApplicationContext') class\.

```csharp
public GISPostgreSQLTrayApplicationContext();
```
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLTrayApplicationContext.GetWindow()'></a>

## GISPostgreSQLTrayApplicationContext\.GetWindow\(\) Method

Creates and returns the main window associated with this application context\.

```csharp
protected override DiGi.GIS.PostgreSQL.UI.Windows.MainWindow GetWindow();
```

#### Returns
[MainWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.MainWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.MainWindow')  
An instance of the [MainWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.MainWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.MainWindow') class\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask'></a>

## PostgreSQLBuildingModelCleanupTask Class

Removes the [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') rows whose building no longer exists under the county part holding them\.

An orphan is a model held under a part whose `building_2d` no longer holds the building it describes, which is what a county part repair run can leave behind when it re-files a building under the part its footprint lies in.

<b>Reports by default and writes nothing.</b>[DryRun](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.DryRun 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.PostgreSQLBuildingModelCleanupTask\.DryRun') has to be turned off deliberately, and the counts it reports first are what the delete should be reviewed against - the rows removed here have no undo.

The report is written as files into [ReportDirectory](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.ReportDirectory 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.PostgreSQLBuildingModelCleanupTask\.ReportDirectory') as well as to the log: `BuildingModels_Cleanup.csv` naming every orphaned reference, and `BuildingModels_Cleanup_Summary.txt` carrying the totals. The files are what the decision to delete should rest on - a log is shared with whatever else the application is doing and rolls by day.

```csharp
public class PostgreSQLBuildingModelCleanupTask : DiGi.Core.Classes.ReportableBackgroundTask<long>, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → PostgreSQLBuildingModelCleanupTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.PostgreSQLBuildingModelCleanupTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager)'></a>

## PostgreSQLBuildingModelCleanupTask\(GISPostgreSQLConverterManager\) Constructor

Initializes a new instance of the [PostgreSQLBuildingModelCleanupTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.PostgreSQLBuildingModelCleanupTask') class\.

```csharp
public PostgreSQLBuildingModelCleanupTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager gISPostgreSQLConverterManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.PostgreSQLBuildingModelCleanupTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The manager holding the PostgreSQL converters\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.CountyIds'></a>

## PostgreSQLBuildingModelCleanupTask\.CountyIds Property

Gets or sets the identifiers of the county rows to clean\. When null every county row is examined\.

These are polygon parts, not counties - a multi-part county holds one row per part and each is cleaned on its own.

```csharp
public System.Collections.Generic.IEnumerable<int>? CountyIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.DryRun'></a>

## PostgreSQLBuildingModelCleanupTask\.DryRun Property

Gets or sets a value indicating whether the task only reports what it would do\. Defaults to [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'); nothing is written until it is turned off\.

```csharp
public bool DryRun { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.ReportDirectory'></a>

## PostgreSQLBuildingModelCleanupTask\.ReportDirectory Property

Gets or sets the directory the two report files are written into\. When null the directory the application was launched from is used\.

Deliberately not a folder dialog: this runs on a thread pool thread, where a WPF common dialog needs an STA apartment and throws instead of opening.

```csharp
public string? ReportDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.VoivodeshipCodes'></a>

## PostgreSQLBuildingModelCleanupTask\.VoivodeshipCodes Property

Gets or sets the two\-digit voivodeship codes to be cleaned\. A county row is in scope when its code starts with one of them\. When null every voivodeship is cleaned\. Combined with [CountyIds](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.CountyIds 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.PostgreSQLBuildingModelCleanupTask\.CountyIds') both filters have to admit the row\.

This is what makes the national regeneration affordable: a voivodeship is regenerated and then cleaned before the next one starts, so the storage tablespace only ever carries a second copy of one voivodeship rather than of the whole country.

```csharp
public System.Collections.Generic.IEnumerable<string>? VoivodeshipCodes { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.ReferencesOrphanedAsync(DiGi.GIS.PostgreSQL.Classes.BuildingModelPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,int,System.Threading.CancellationToken)'></a>

## PostgreSQLBuildingModelCleanupTask\.ReferencesOrphanedAsync\(BuildingModelPostgreSQLConverter, Building2DPostgreSQLConverter, int, CancellationToken\) Method

Returns the references a county row holds a model for but no longer holds a building for\.

```csharp
private static System.Threading.Tasks.Task<System.Collections.Generic.List<string>> ReferencesOrphanedAsync(DiGi.GIS.PostgreSQL.Classes.BuildingModelPostgreSQLConverter buildingModelPostgreSQLConverter, DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter, int countyId, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.ReferencesOrphanedAsync(DiGi.GIS.PostgreSQL.Classes.BuildingModelPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,int,System.Threading.CancellationToken).buildingModelPostgreSQLConverter'></a>

`buildingModelPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.BuildingModelPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.buildingmodelpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.BuildingModelPostgreSQLConverter')

The converter reading the model table\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.ReferencesOrphanedAsync(DiGi.GIS.PostgreSQL.Classes.BuildingModelPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,int,System.Threading.CancellationToken).building2DPostgreSQLConverter'></a>

`building2DPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.Building2DPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2dpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DPostgreSQLConverter')

The converter reading the building table, which lives in a different database\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.ReferencesOrphanedAsync(DiGi.GIS.PostgreSQL.Classes.BuildingModelPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,int,System.Threading.CancellationToken).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The identifier of the county row to compare\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask.ReferencesOrphanedAsync(DiGi.GIS.PostgreSQL.Classes.BuildingModelPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') to observe while waiting for the task to complete\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result contains the orphaned references, empty when either side could not be read\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIAdministrativeAreal2DFromFilePostTask'></a>

## UIAdministrativeAreal2DFromFilePostTask Class

Provides functionality to post administrative areal 2D objects to a PostgreSQL database by selecting GIS model files through the user interface\.

```csharp
public class UIAdministrativeAreal2DFromFilePostTask : DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DsPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.AdministrativeAreal2DsPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.administrativeareal2dsposttask 'DiGi\.GIS\.WebAPI\.Classes\.AdministrativeAreal2DsPostTask') → UIAdministrativeAreal2DFromFilePostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIAdministrativeAreal2DFromFilePostTask.UIAdministrativeAreal2DFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIAdministrativeAreal2DFromFilePostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIAdministrativeAreal2DFromFilePostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIAdministrativeAreal2DFromFilePostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIAdministrativeAreal2DFromFilePostTask') class\.

```csharp
public UIAdministrativeAreal2DFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIAdministrativeAreal2DFromFilePostTask.UIAdministrativeAreal2DFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager used to communicate with the GIS PostgreSQL Web API\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIAdministrativeAreal2DFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIAdministrativeAreal2DFromFilePostTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Concrete implementation of the background work\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIAdministrativeAreal2DFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The provider for a value and elapsed time to report progress\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIAdministrativeAreal2DFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token to observe while waiting for the task to complete\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result is true if the operation succeeded; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuilding2DsFromFilePostTask'></a>

## UIBuilding2DsFromFilePostTask Class

Represents a task for posting Building 2D objects to a PostgreSQL database from GIS model files selected through the user interface\.

```csharp
public class UIBuilding2DsFromFilePostTask : DiGi.GIS.WebAPI.Classes.Building2DsPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.Building2DsPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.building2dsposttask 'DiGi\.GIS\.WebAPI\.Classes\.Building2DsPostTask') → UIBuilding2DsFromFilePostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuilding2DsFromFilePostTask.UIBuilding2DsFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIBuilding2DsFromFilePostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIBuilding2DsFromFilePostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuilding2DsFromFilePostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuilding2DsFromFilePostTask') class\.

```csharp
public UIBuilding2DsFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuilding2DsFromFilePostTask.UIBuilding2DsFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager used to communicate with the GIS PostgreSQL Web API\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuilding2DsFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIBuilding2DsFromFilePostTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Concrete implementation of the background work\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuilding2DsFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The provider for reporting progress of the operation\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuilding2DsFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result is true if the operation succeeded; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask'></a>

## UIBuildingModelsFromDatabasePostTask Class

A post task that generates [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') instances entirely from data already held on the server \- the CityGML [DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building') records stored in the database are used instead of CityGML archives read from a local directory\.

For every county in scope the task pages through the county's [DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference') records and, per page, downloads the [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D') data, so a whole county's buildings are never held in memory at once.

Each [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D') is then processed individually: its single best ranked CityGML [DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building') is pulled by reference through [DiGi\.GIS\.WebAPI\.Classes\.BuildingController\.GetItemByReferenceAsync\(System\.String,System\.Nullable\{System\.Int32\},System\.Nullable\{System\.Double\},System\.Nullable\{System\.Double\},System\.Nullable\{System\.Double\},System\.Nullable\{System\.Double\},System\.Threading\.CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.buildingcontroller.getitembyreferenceasync#digi-gis-webapi-classes-buildingcontroller-getitembyreferenceasync(system-string-system-nullable{system-int32}-system-nullable{system-double}-system-nullable{system-double}-system-nullable{system-double}-system-nullable{system-double}-system-threading-cancellationtoken) 'DiGi\.GIS\.WebAPI\.Classes\.BuildingController\.GetItemByReferenceAsync\(System\.String,System\.Nullable\{System\.Int32\},System\.Nullable\{System\.Double\},System\.Nullable\{System\.Double\},System\.Nullable\{System\.Double\},System\.Nullable\{System\.Double\},System\.Threading\.CancellationToken\)') and refined into storeys by the matching `Analytical.Create.BuildingModel` overload. A 2D building whose reference has no stored CityGML building, no reference at all, or whose pull fails is modelled from an extruded footprint instead.

<b>"County" here means one polygon part.</b> The county listing returns 406 references for 380 codes, because a county whose territory is disconnected is stored as one row per part. The task reads and uploads by `Id`, so each part is filled from its own `building_2d` rows; uploading by `Code` instead would let the server file every part's models under a single one, which is what left three counties reading back empty. The county code is still written onto each model as descriptive metadata.

Because `building_2d` holds the same building under every part it was imported under, a building shared by two parts is modelled once per part. That is inherent to keying by part and is not a duplicate to suppress here - it mirrors the underlying table.

<b>A national pass takes days, so a county is the unit of both failure and progress.</b> A county whose pages cannot be read or uploaded is named, recorded in `BuildingModels_Regeneration_Failed.txt` and skipped, rather than ending the run and discarding every county after it. A county that completes in full is appended to `BuildingModels_Regeneration_Checkpoint.txt`, which [Resume](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.Resume 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsFromDatabasePostTask\.Resume') reads on the next run - so an interrupted pass continues where it stopped, and a county interrupted part way is simply redone.

```csharp
public class UIBuildingModelsFromDatabasePostTask : DiGi.GIS.WebAPI.Classes.BuildingModelsPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.BuildingModelsPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.buildingmodelsposttask 'DiGi\.GIS\.WebAPI\.Classes\.BuildingModelsPostTask') → UIBuildingModelsFromDatabasePostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.UIBuildingModelsFromDatabasePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIBuildingModelsFromDatabasePostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIBuildingModelsFromDatabasePostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsFromDatabasePostTask') class\.

```csharp
public UIBuildingModelsFromDatabasePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.UIBuildingModelsFromDatabasePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') instance used to communicate with the server\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.CountyIds'></a>

## UIBuildingModelsFromDatabasePostTask\.CountyIds Property

Gets or sets the identifiers of the counties to be processed\. When null every county held on the server is processed\.

```csharp
public System.Collections.Generic.IEnumerable<int>? CountyIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.MaxConcurrentRequests'></a>

## UIBuildingModelsFromDatabasePostTask\.MaxConcurrentRequests Property

Gets or sets how many CityGML and terrain requests are allowed to be in flight at once\.

One CityGML request per building at roughly 60 ms each makes a national pass a matter of weeks when they are issued one after another. The requests are independent, so they are issued in groups of this size. Lower it if the server or the terrain service starts refusing.

```csharp
public int MaxConcurrentRequests { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.PageSize'></a>

## UIBuildingModelsFromDatabasePostTask\.PageSize Property

Gets or sets the number of [DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference') items requested per page while downloading a county's buildings\.

```csharp
public int PageSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.ReportDirectory'></a>

## UIBuildingModelsFromDatabasePostTask\.ReportDirectory Property

Gets or sets the directory the checkpoint and the list of failed counties are written into\. When null the directory the application was launched from is used\.

Deliberately not a folder dialog: this runs on a thread pool thread, where a WPF common dialog needs an STA apartment and throws instead of opening.

```csharp
public string? ReportDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.Resume'></a>

## UIBuildingModelsFromDatabasePostTask\.Resume Property

Gets or sets a value indicating whether counties named in the checkpoint of an earlier run are skipped\. Defaults to [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

A national pass is a matter of days, so it has to survive being interrupted. Turning this off starts from the first county in scope and truncates the checkpoint, which is what a deliberate re-run of an already-completed scope needs.

```csharp
public bool Resume { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.VoivodeshipCodes'></a>

## UIBuildingModelsFromDatabasePostTask\.VoivodeshipCodes Property

Gets or sets the two\-digit voivodeship codes to be processed\. A county is in scope when its code starts with one of them\. When null every voivodeship is processed\. Combined with [CountyIds](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.CountyIds 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsFromDatabasePostTask\.CountyIds') both filters have to admit the county\.

Regenerating one voivodeship at a time is what keeps the storage tablespace within reach: a county's models are written beside the ones they supersede until [PostgreSQLBuildingModelCleanupTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.PostgreSQLBuildingModelCleanupTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.PostgreSQLBuildingModelCleanupTask') removes them, so a national pass in one go would need room for a second copy of the whole table.

```csharp
public System.Collections.Generic.IEnumerable<string>? VoivodeshipCodes { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDirectoryPostTask'></a>

## UIBuildingModelsFromDirectoryPostTask Class

A UI\-driven post task that prompts the user to select a directory containing CityGML archives, enumerates the counties held on the server, and for every county whose code matches a CityGML archive in that directory downloads the county's [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D') data page by page, generates [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') instances and uploads them\.

Both the CityGML archives and the Building2D data are processed one county - and within a county one page - at a time, so neither the whole country's CityGML nor a whole county's buildings are ever held in memory at once.

```csharp
public class UIBuildingModelsFromDirectoryPostTask : DiGi.GIS.WebAPI.Classes.BuildingModelsPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.BuildingModelsPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.buildingmodelsposttask 'DiGi\.GIS\.WebAPI\.Classes\.BuildingModelsPostTask') → UIBuildingModelsFromDirectoryPostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDirectoryPostTask.UIBuildingModelsFromDirectoryPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIBuildingModelsFromDirectoryPostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIBuildingModelsFromDirectoryPostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDirectoryPostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsFromDirectoryPostTask') class\.

```csharp
public UIBuildingModelsFromDirectoryPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDirectoryPostTask.UIBuildingModelsFromDirectoryPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') instance used to communicate with the server\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDirectoryPostTask.PageSize'></a>

## UIBuildingModelsFromDirectoryPostTask\.PageSize Property

Gets or sets the number of [DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference') items requested per page while downloading a county's buildings\.

```csharp
public int PageSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask'></a>

## UIBuildingModelsVerificationTask Class

A UI\-driven task that reads the [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') records already stored on the server and reports how complete and how sound they are\.

Read-only. Nothing is uploaded, nothing is repaired - the task exists to say what the stored data looks like, which is the state the upload path itself never reported: a model whose spaces are not enclosed is accepted by the server today and stored without a word.

For every county in scope a sample of [SampleSize](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.SampleSize 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsVerificationTask\.SampleSize') 2D building references is drawn with [RandomSeed](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.RandomSeed 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsVerificationTask\.RandomSeed'), so a run is reproducible and two runs can be compared. The models behind those references are pulled in batches and each one is passed through `Analytical.Create.BuildingModelValidationResult`. A reference the server holds no model for is recorded as missing, which is the completeness half of the answer.

The seed is combined with the county row identifier rather than shared across counties, so a county draws the same sample whether it is verified on its own, with its voivodeship, or nationally. A single generator advanced across counties made every county's draw depend on how many references each preceding county held, which the 2026-08-14 county part repair changed - and with it the sample of every county after the repaired three.

Two files are written into [ReportDirectory](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.ReportDirectory 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsVerificationTask\.ReportDirectory'): one row per reference in `BuildingModels_Verification.csv`, and per county plus national totals in `BuildingModels_Verification_Summary.txt`. The row file is flushed county by county, so a run interrupted late still leaves everything it had already measured.

```csharp
public class UIBuildingModelsVerificationTask : DiGi.Core.Classes.ReportableBackgroundTask<long>, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → UIBuildingModelsVerificationTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.UIBuildingModelsVerificationTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIBuildingModelsVerificationTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIBuildingModelsVerificationTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsVerificationTask') class\.

```csharp
public UIBuildingModelsVerificationTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.UIBuildingModelsVerificationTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsVerificationTask\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.ui.classes.uibuildingmodelsverificationtask.giswebapimanager 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsVerificationTask\.GISWebAPIManager') instance used to communicate with the server\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.BatchSize'></a>

## UIBuildingModelsVerificationTask\.BatchSize Property

Gets or sets the number of references asked for in a single request\. The references travel in the query string, so a batch far above this risks the URL length limit of the server\.

```csharp
public int BatchSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.CountyIds'></a>

## UIBuildingModelsVerificationTask\.CountyIds Property

Gets or sets the identifiers of the counties to be processed\. When null every county held on the server is processed\.

```csharp
public System.Collections.Generic.IEnumerable<int>? CountyIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.RandomSeed'></a>

## UIBuildingModelsVerificationTask\.RandomSeed Property

Gets or sets the seed of the sampling\. Two runs sharing a seed draw the same references, which is what lets a run before a change be compared with one after it\. The seed is combined per county by [DiGi\.GIS\.PostgreSQL\.Query\.RandomSeed\(System\.Int32,System\.Int32\)](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.query.randomseed#digi-gis-postgresql-query-randomseed(system-int32-system-int32) 'DiGi\.GIS\.PostgreSQL\.Query\.RandomSeed\(System\.Int32,System\.Int32\)'), so a county's draw does not depend on the scope of the run or on what any other county holds\.

```csharp
public int RandomSeed { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.ReportDirectory'></a>

## UIBuildingModelsVerificationTask\.ReportDirectory Property

Gets or sets the directory the two report files are written into\. When null the user is asked for one\.

```csharp
public string? ReportDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.SampleSize'></a>

## UIBuildingModelsVerificationTask\.SampleSize Property

Gets or sets the number of references drawn per county\. A value of zero or less takes every reference of the county\.

```csharp
public int SampleSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.Tolerance'></a>

## UIBuildingModelsVerificationTask\.Tolerance Property

Gets or sets the distance tolerance the enclosure of a space is required to hold at\.

```csharp
public double Tolerance { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.VoivodeshipCodes'></a>

## UIBuildingModelsVerificationTask\.VoivodeshipCodes Property

Gets or sets the two\-digit voivodeship codes to be processed\. A county is in scope when its code starts with one of them\. When null every voivodeship is processed\. Combined with [CountyIds](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.CountyIds 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingModelsVerificationTask\.CountyIds') both filters have to admit the county\.

```csharp
public System.Collections.Generic.IEnumerable<string>? VoivodeshipCodes { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.Text(double)'></a>

## UIBuildingModelsVerificationTask\.Text\(double\) Method

Formats a value for the report, writing an empty cell rather than the word for not a number\.

```csharp
private static string Text(double value);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsVerificationTask.Text(double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The value to format\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The formatted value, or an empty string when it is not a number\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask'></a>

## UIBuildingsFromDirectoryPostTask Class

A UI\-driven post task that prompts the user to select a directory, reads CityGML city models from it, extracts [DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building') instances, determines the county code from the file path, and uploads them to the server in batches\.

```csharp
public class UIBuildingsFromDirectoryPostTask : DiGi.GIS.WebAPI.Classes.BuildingsPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.BuildingsPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.buildingsposttask 'DiGi\.GIS\.WebAPI\.Classes\.BuildingsPostTask') → UIBuildingsFromDirectoryPostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.UIBuildingsFromDirectoryPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIBuildingsFromDirectoryPostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIBuildingsFromDirectoryPostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingsFromDirectoryPostTask') class\.

```csharp
public UIBuildingsFromDirectoryPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.UIBuildingsFromDirectoryPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') instance used to communicate with the server\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.LatestSourceAsync(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIBuildingsFromDirectoryPostTask\.LatestSourceAsync\(GISWebAPIManager\) Method

Asynchronously reads the source path recorded on the most recently written building\.

```csharp
private static System.Threading.Tasks.Task<string?> LatestSourceAsync(DiGi.GIS.WebAPI.Classes.GISWebAPIManager? GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.LatestSourceAsync(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager used to reach the server\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task whose result is the recorded source path, or null when the server holds no buildings or the path was not recorded\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ProduceAsync(string,System.Threading.Channels.ChannelWriter_DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch_,DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter,System.Threading.CancellationToken)'></a>

## UIBuildingsFromDirectoryPostTask\.ProduceAsync\(string, ChannelWriter\<BuildingsBatch\>, ResumeFilter, CancellationToken\) Method

Walks the directory, parses each city model and publishes its tagged buildings to the channel\.

```csharp
private static System.Threading.Tasks.Task<bool> ProduceAsync(string directory, System.Threading.Channels.ChannelWriter<DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch> channelWriter, DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter? resumeFilter, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ProduceAsync(string,System.Threading.Channels.ChannelWriter_DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch_,DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter,System.Threading.CancellationToken).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory to walk\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ProduceAsync(string,System.Threading.Channels.ChannelWriter_DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch_,DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter,System.Threading.CancellationToken).channelWriter'></a>

`channelWriter` [System\.Threading\.Channels\.ChannelWriter&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.channels.channelwriter-1 'System\.Threading\.Channels\.ChannelWriter\`1')[BuildingsBatch](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingsFromDirectoryPostTask\.BuildingsBatch')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.channels.channelwriter-1 'System\.Threading\.Channels\.ChannelWriter\`1')

The writer the parsed batches are published to\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ProduceAsync(string,System.Threading.Channels.ChannelWriter_DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch_,DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter,System.Threading.CancellationToken).resumeFilter'></a>

`resumeFilter` [ResumeFilter](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingsFromDirectoryPostTask\.ResumeFilter')

An optional filter that skips files preceding a recorded resume point, or null to walk everything\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ProduceAsync(string,System.Threading.Channels.ChannelWriter_DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch_,DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token observed before each file is parsed\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result is true if the walk completed successfully; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch'></a>

## UIBuildingsFromDirectoryPostTask\.BuildingsBatch Class

A parsed city model's buildings together with the county code derived from its file path\.

```csharp
private sealed class UIBuildingsFromDirectoryPostTask.BuildingsBatch
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → BuildingsBatch
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch.BuildingsBatch(System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,string)'></a>

## BuildingsBatch\(IEnumerable\<Building\>, string\) Constructor

Initializes a new instance of the [BuildingsBatch](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingsFromDirectoryPostTask\.BuildingsBatch') class\.

```csharp
public BuildingsBatch(System.Collections.Generic.IEnumerable<DiGi.CityGML.Classes.Building> buildings, string? code);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch.BuildingsBatch(System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,string).buildings'></a>

`buildings` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The buildings parsed from a single city model\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch.BuildingsBatch(System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The county code derived from the source file path, or null when it could not be determined\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch.Buildings'></a>

## UIBuildingsFromDirectoryPostTask\.BuildingsBatch\.Buildings Property

Gets the buildings parsed from a single city model\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.CityGML.Classes.Building> Buildings { get; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.BuildingsBatch.Code'></a>

## UIBuildingsFromDirectoryPostTask\.BuildingsBatch\.Code Property

Gets the county code derived from the source file path\.

```csharp
public string? Code { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter'></a>

## UIBuildingsFromDirectoryPostTask\.ResumeFilter Class

Skips walked files until a recorded source path is reached, then admits everything from that file onward\.

The recorded file is admitted rather than skipped: the run that wrote it was interrupted, so it was probably only partly uploaded. Re-importing it is safe because the server upserts on (county, reference, lod, year).

```csharp
private sealed class UIBuildingsFromDirectoryPostTask.ResumeFilter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ResumeFilter
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter.ResumeFilter(string)'></a>

## ResumeFilter\(string\) Constructor

Initializes a new instance of the [ResumeFilter](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIBuildingsFromDirectoryPostTask\.ResumeFilter') class\.

```csharp
public ResumeFilter(string source);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter.ResumeFilter(string).source'></a>

`source` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The recorded source path, relative to the walked directory, to resume from\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter.Matched'></a>

## UIBuildingsFromDirectoryPostTask\.ResumeFilter\.Matched Property

Gets a value indicating whether the recorded source path was ever reached during the walk\.

```csharp
public bool Matched { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter.Admit(string)'></a>

## UIBuildingsFromDirectoryPostTask\.ResumeFilter\.Admit\(string\) Method

Decides whether a walked file should be parsed\.

```csharp
public bool Admit(string path);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingsFromDirectoryPostTask.ResumeFilter.Admit(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The walked file's path, relative to the walked directory\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True once the recorded source path has been reached; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIEPWFileFromFilePostTask'></a>

## UIEPWFileFromFilePostTask Class

Represents a task for posting [DiGi\.EPW\.Classes\.EPWFile](https://learn.microsoft.com/en-us/dotnet/api/digi.epw.classes.epwfile 'DiGi\.EPW\.Classes\.EPWFile') objects to a PostgreSQL database from EPW files selected through the user interface\.

```csharp
public class UIEPWFileFromFilePostTask : DiGi.GIS.WebAPI.Classes.EPWFilesPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.EPW\.Classes\.EPWFile](https://learn.microsoft.com/en-us/dotnet/api/digi.epw.classes.epwfile 'DiGi\.EPW\.Classes\.EPWFile')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.EPWFilesPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.epwfilesposttask 'DiGi\.GIS\.WebAPI\.Classes\.EPWFilesPostTask') → UIEPWFileFromFilePostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIEPWFileFromFilePostTask.UIEPWFileFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIEPWFileFromFilePostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIEPWFileFromFilePostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIEPWFileFromFilePostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIEPWFileFromFilePostTask') class\.

```csharp
public UIEPWFileFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIEPWFileFromFilePostTask.UIEPWFileFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager used to communicate with the GIS PostgreSQL Web API\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIEPWFileFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIEPWFileFromFilePostTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Concrete implementation of the background work\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIEPWFileFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The provider for reporting progress of the operation\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIEPWFileFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result is true if the operation succeeded; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOccupancyDatasFromFilePostTask'></a>

## UIOccupancyDatasFromFilePostTask Class

Represents a task that handles the process of posting occupancy data extracted from GIS model files to the PostgreSQL database through the user interface\.

```csharp
public class UIOccupancyDatasFromFilePostTask : DiGi.GIS.WebAPI.Classes.OccupancyDatasPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.OccupancyDatasPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.occupancydatasposttask 'DiGi\.GIS\.WebAPI\.Classes\.OccupancyDatasPostTask') → UIOccupancyDatasFromFilePostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOccupancyDatasFromFilePostTask.UIOccupancyDatasFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIOccupancyDatasFromFilePostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIOccupancyDatasFromFilePostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIOccupancyDatasFromFilePostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIOccupancyDatasFromFilePostTask') class\.

```csharp
public UIOccupancyDatasFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOccupancyDatasFromFilePostTask.UIOccupancyDatasFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager used to interact with the GIS PostgreSQL Web API\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOccupancyDatasFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIOccupancyDatasFromFilePostTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Concrete implementation of the background work\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOccupancyDatasFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The provider for reporting progress of the operation\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOccupancyDatasFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result is true if the operation completed successfully; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOrtoDatasFromFilePostTask'></a>

## UIOrtoDatasFromFilePostTask Class

Represents a task for posting orthodata from files to a PostgreSQL database, specifically designed for use within the UI layer\.

```csharp
public class UIOrtoDatasFromFilePostTask : DiGi.GIS.WebAPI.Classes.OrtoDatasPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.GIS\.Classes\.OrtoDatas](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.ortodatas 'DiGi\.GIS\.Classes\.OrtoDatas')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.OrtoDatasPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.ortodatasposttask 'DiGi\.GIS\.WebAPI\.Classes\.OrtoDatasPostTask') → UIOrtoDatasFromFilePostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOrtoDatasFromFilePostTask.UIOrtoDatasFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIOrtoDatasFromFilePostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIOrtoDatasFromFilePostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIOrtoDatasFromFilePostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIOrtoDatasFromFilePostTask') class\.

```csharp
public UIOrtoDatasFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOrtoDatasFromFilePostTask.UIOrtoDatasFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager used to communicate with the GIS PostgreSQL Web API\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOrtoDatasFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIOrtoDatasFromFilePostTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Concrete implementation of the background work\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOrtoDatasFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The progress reporter used to track the operation's completion percentage\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIOrtoDatasFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token used to observe while writing the task to stop executing\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result is true if the operation succeeded; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLBuildingDataUpdateTask'></a>

## UIPostgreSQLBuildingDataUpdateTask Class

A building data run that is scoped from the user interface: the counties, the kinds of column to write and the statement timeout are asked for through [PostgreSQLBuildingDataUpdateOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataUpdateOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLBuildingDataUpdateOptionsWindow') each time the task is started, and only then is the run handed to [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataUpdateTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlbuildingdataupdatetask 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataUpdateTask')\.

That is what the counties are worth asking for. Unscoped the run walks every subdivision in the country - around a hundred thousand of them - reading each subdivision's buildings and writing a row per building; over one named county it is minutes. Neither is a default the other would tolerate, and the base task takes an unset county collection as the whole country.

```csharp
public class UIPostgreSQLBuildingDataUpdateTask : DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataUpdateTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataUpdateTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlbuildingdataupdatetask 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataUpdateTask') → UIPostgreSQLBuildingDataUpdateTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLBuildingDataUpdateTask.UIPostgreSQLBuildingDataUpdateTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager)'></a>

## UIPostgreSQLBuildingDataUpdateTask\(GISPostgreSQLConverterManager\) Constructor

Initializes a new instance of the [UIPostgreSQLBuildingDataUpdateTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLBuildingDataUpdateTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIPostgreSQLBuildingDataUpdateTask') class\.

```csharp
public UIPostgreSQLBuildingDataUpdateTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager GISPostgreSQLConverterManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLBuildingDataUpdateTask.UIPostgreSQLBuildingDataUpdateTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).GISPostgreSQLConverterManager'></a>

`GISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The GIS PostgreSQL converter manager used to read the areas and buildings and write the building data\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLBuildingDataUpdateTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIPostgreSQLBuildingDataUpdateTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Executes the background task to update building data from AdministrativeAreal2D and Building2D sources\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLBuildingDataUpdateTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

A progress reporter for reporting the number of processed items\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLBuildingDataUpdateTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation\. Returns true when the run could be attempted and every subdivision in scope was updated without error; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionCreateTableTask'></a>

## UIPostgreSQLStatisticalDataCollectionCreateTableTask Class

Represents a task for creating the statistical data collection table in PostgreSQL and populating it from \.sdcf files in a directory selected through the user interface\.

```csharp
public class UIPostgreSQLStatisticalDataCollectionCreateTableTask : DiGi.GIS.PostgreSQL.Classes.PostgreSQLStatisticalDataCollectionCreateTableTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLStatisticalDataCollectionCreateTableTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlstatisticaldatacollectioncreatetabletask 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLStatisticalDataCollectionCreateTableTask') → UIPostgreSQLStatisticalDataCollectionCreateTableTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionCreateTableTask.UIPostgreSQLStatisticalDataCollectionCreateTableTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager)'></a>

## UIPostgreSQLStatisticalDataCollectionCreateTableTask\(GISPostgreSQLConverterManager\) Constructor

Initializes a new instance of the [UIPostgreSQLStatisticalDataCollectionCreateTableTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionCreateTableTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIPostgreSQLStatisticalDataCollectionCreateTableTask') class from a manager\.

```csharp
public UIPostgreSQLStatisticalDataCollectionCreateTableTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager gISPostgreSQLConverterManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionCreateTableTask.UIPostgreSQLStatisticalDataCollectionCreateTableTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The GIS PostgreSQL converter manager containing the statistical data collection converter\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionCreateTableTask.UIPostgreSQLStatisticalDataCollectionCreateTableTask(DiGi.GIS.PostgreSQL.Classes.StatisticalDataCollectionPostgreSQLConverter)'></a>

## UIPostgreSQLStatisticalDataCollectionCreateTableTask\(StatisticalDataCollectionPostgreSQLConverter\) Constructor

Initializes a new instance of the [UIPostgreSQLStatisticalDataCollectionCreateTableTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionCreateTableTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIPostgreSQLStatisticalDataCollectionCreateTableTask') class with a statistical data collection PostgreSQL converter\.

```csharp
public UIPostgreSQLStatisticalDataCollectionCreateTableTask(DiGi.GIS.PostgreSQL.Classes.StatisticalDataCollectionPostgreSQLConverter statisticalDataCollectionPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionCreateTableTask.UIPostgreSQLStatisticalDataCollectionCreateTableTask(DiGi.GIS.PostgreSQL.Classes.StatisticalDataCollectionPostgreSQLConverter).statisticalDataCollectionPostgreSQLConverter'></a>

`statisticalDataCollectionPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.StatisticalDataCollectionPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.statisticaldatacollectionpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.StatisticalDataCollectionPostgreSQLConverter')

The statistical data collection PostgreSQL converter used to create and populate the table\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionCreateTableTask.ExecuteAsync()'></a>

## UIPostgreSQLStatisticalDataCollectionCreateTableTask\.ExecuteAsync\(\) Method

Executes the background task to create the statistical data collection table in PostgreSQL\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync();
```

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation\. Returns true if the table was created successfully; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask'></a>

## UIPostgreSQLStatisticalDataCollectionPopulateTask Class

Represents a task for populating statistical data collections into PostgreSQL from \.sdcf files in a directory selected through the user interface\.

```csharp
public class UIPostgreSQLStatisticalDataCollectionPopulateTask : DiGi.GIS.PostgreSQL.Classes.PostgreSQLStatisticalDataCollectionPopulateTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLStatisticalDataCollectionPopulateTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlstatisticaldatacollectionpopulatetask 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLStatisticalDataCollectionPopulateTask') → UIPostgreSQLStatisticalDataCollectionPopulateTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask.UIPostgreSQLStatisticalDataCollectionPopulateTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager)'></a>

## UIPostgreSQLStatisticalDataCollectionPopulateTask\(GISPostgreSQLConverterManager\) Constructor

Initializes a new instance of the [UIPostgreSQLStatisticalDataCollectionPopulateTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIPostgreSQLStatisticalDataCollectionPopulateTask') class from a manager\.

```csharp
public UIPostgreSQLStatisticalDataCollectionPopulateTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager gISPostgreSQLConverterManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask.UIPostgreSQLStatisticalDataCollectionPopulateTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The GIS PostgreSQL converter manager containing the statistical data collection converter\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask.UIPostgreSQLStatisticalDataCollectionPopulateTask(DiGi.GIS.PostgreSQL.Classes.StatisticalDataCollectionPostgreSQLConverter)'></a>

## UIPostgreSQLStatisticalDataCollectionPopulateTask\(StatisticalDataCollectionPostgreSQLConverter\) Constructor

Initializes a new instance of the [UIPostgreSQLStatisticalDataCollectionPopulateTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIPostgreSQLStatisticalDataCollectionPopulateTask') class with a converter\.

```csharp
public UIPostgreSQLStatisticalDataCollectionPopulateTask(DiGi.GIS.PostgreSQL.Classes.StatisticalDataCollectionPostgreSQLConverter statisticalDataCollectionPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask.UIPostgreSQLStatisticalDataCollectionPopulateTask(DiGi.GIS.PostgreSQL.Classes.StatisticalDataCollectionPostgreSQLConverter).statisticalDataCollectionPostgreSQLConverter'></a>

`statisticalDataCollectionPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.StatisticalDataCollectionPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.statisticaldatacollectionpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.StatisticalDataCollectionPostgreSQLConverter')

The statistical data collection PostgreSQL converter used to populate the table\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIPostgreSQLStatisticalDataCollectionPopulateTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Executes the background task to read statistical data collections from \.sdcf files and insert them into PostgreSQL\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

A progress reporter for reporting the number of processed items\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLStatisticalDataCollectionPopulateTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation\. Returns true if the population was successful; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointCreateTableTask'></a>

## UIPostgreSQLTerrainPointCreateTableTask Class

A terrain point run that is scoped from the user interface: the counties, the spacing of the sampling grid and whether points already stored are sampled again are asked for through [PostgreSQLTerrainPointCreateTableOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointCreateTableOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLTerrainPointCreateTableOptionsWindow') each time the task is started, and only then is the run handed to [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointCreateTableTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlterrainpointcreatetabletask 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointCreateTableTask')\.

That is what the settings are worth asking for: a national pass at 50 m is about 125 million points and one request to the elevation service each, while the same task over a named county at 10 m is an afternoon. Neither is a default the other would tolerate.

```csharp
public class UIPostgreSQLTerrainPointCreateTableTask : DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointCreateTableTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointCreateTableTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlterrainpointcreatetabletask 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointCreateTableTask') → UIPostgreSQLTerrainPointCreateTableTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointCreateTableTask.UIPostgreSQLTerrainPointCreateTableTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager)'></a>

## UIPostgreSQLTerrainPointCreateTableTask\(GISWebAPIManager, GISPostgreSQLConverterManager\) Constructor

Initializes a new instance of the [UIPostgreSQLTerrainPointCreateTableTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointCreateTableTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIPostgreSQLTerrainPointCreateTableTask') class\.

```csharp
public UIPostgreSQLTerrainPointCreateTableTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager? GISWebAPIManager, DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager? GISPostgreSQLConverterManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointCreateTableTask.UIPostgreSQLTerrainPointCreateTableTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager the elevation service client is built from\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointCreateTableTask.UIPostgreSQLTerrainPointCreateTableTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).GISPostgreSQLConverterManager'></a>

`GISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The GIS PostgreSQL converter manager used to read the areas and write the points\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointCreateTableTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIPostgreSQLTerrainPointCreateTableTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Executes the background task, sampling elevations county by county and writing them to the terrain point table\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointCreateTableTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

A progress reporter carrying the running total of points stored\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointCreateTableTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation\. Returns true unless the run was cancelled\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointFillGapsTask'></a>

## UIPostgreSQLTerrainPointFillGapsTask Class

A terrain point repair that is scoped from the user interface: the counties and the spacing they were sampled at are asked for through [PostgreSQLTerrainPointFillGapsOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointFillGapsOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLTerrainPointFillGapsOptionsWindow') each time the task is started, and only then is the run handed to [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointFillGapsTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlterrainpointfillgapstask 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointFillGapsTask')\.

The spacing is why the dialog is worth showing at all. It is what decides which nodes count as missing, and a value finer than a county actually holds turns a repair of a few thousand points into a densification of the whole country - so the measured spacing of each county is put in front of whoever is choosing it.

```csharp
public class UIPostgreSQLTerrainPointFillGapsTask : DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointFillGapsTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointFillGapsTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlterrainpointfillgapstask 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointFillGapsTask') → UIPostgreSQLTerrainPointFillGapsTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointFillGapsTask.UIPostgreSQLTerrainPointFillGapsTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager)'></a>

## UIPostgreSQLTerrainPointFillGapsTask\(GISWebAPIManager, GISPostgreSQLConverterManager\) Constructor

Initializes a new instance of the [UIPostgreSQLTerrainPointFillGapsTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointFillGapsTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIPostgreSQLTerrainPointFillGapsTask') class\.

```csharp
public UIPostgreSQLTerrainPointFillGapsTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager? GISWebAPIManager, DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager? GISPostgreSQLConverterManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointFillGapsTask.UIPostgreSQLTerrainPointFillGapsTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager the elevation service client is built from\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointFillGapsTask.UIPostgreSQLTerrainPointFillGapsTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).GISPostgreSQLConverterManager'></a>

`GISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The GIS PostgreSQL converter manager used to read the areas and write the points\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointFillGapsTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIPostgreSQLTerrainPointFillGapsTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Executes the background task, measuring each county against the lattice and sampling only the nodes it is short of\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointFillGapsTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

A progress reporter carrying the running total of points stored\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLTerrainPointFillGapsTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation\. Returns true unless the run was cancelled\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask'></a>

## UIPostgreSQLUnitInsertFromFileTask Class

Represents a task for populating territorial units into a PostgreSQL database from a JSON file selected through the user interface\.

```csharp
public class UIPostgreSQLUnitInsertFromFileTask : DiGi.GIS.PostgreSQL.Classes.PostgreSQLUnitInsertFromFileTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLUnitInsertFromFileTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlunitinsertfromfiletask 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLUnitInsertFromFileTask') → UIPostgreSQLUnitInsertFromFileTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask.UIPostgreSQLUnitInsertFromFileTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager)'></a>

## UIPostgreSQLUnitInsertFromFileTask\(GISPostgreSQLConverterManager\) Constructor

Initializes a new instance of the [UIPostgreSQLUnitInsertFromFileTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIPostgreSQLUnitInsertFromFileTask') class from a manager\.

```csharp
public UIPostgreSQLUnitInsertFromFileTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager gISPostgreSQLConverterManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask.UIPostgreSQLUnitInsertFromFileTask(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The GIS PostgreSQL converter manager containing the unit converter\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask.UIPostgreSQLUnitInsertFromFileTask(DiGi.GIS.PostgreSQL.Classes.UnitPostgreSQLConverter)'></a>

## UIPostgreSQLUnitInsertFromFileTask\(UnitPostgreSQLConverter\) Constructor

Initializes a new instance of the [UIPostgreSQLUnitInsertFromFileTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIPostgreSQLUnitInsertFromFileTask') class with a unit PostgreSQL converter\.

```csharp
public UIPostgreSQLUnitInsertFromFileTask(DiGi.GIS.PostgreSQL.Classes.UnitPostgreSQLConverter unitPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask.UIPostgreSQLUnitInsertFromFileTask(DiGi.GIS.PostgreSQL.Classes.UnitPostgreSQLConverter).unitPostgreSQLConverter'></a>

`unitPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.UnitPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.unitpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.UnitPostgreSQLConverter')

The unit PostgreSQL converter used to populate the table\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIPostgreSQLUnitInsertFromFileTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Executes the background task to read territorial units from JSON file\(s\) and insert them into PostgreSQL\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

A progress reporter for reporting the number of processed items\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIPostgreSQLUnitInsertFromFileTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation\. Returns true if the population was successful; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIUpdateFromFilePostTask'></a>

## UIUpdateFromFilePostTask Class

Represents a task that handles the process of updating GIS data from a file via user interface interactions\.

```csharp
public class UIUpdateFromFilePostTask : DiGi.GIS.WebAPI.Classes.Building2DsPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.Building2DsPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.building2dsposttask 'DiGi\.GIS\.WebAPI\.Classes\.Building2DsPostTask') → UIUpdateFromFilePostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIUpdateFromFilePostTask.UIUpdateFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIUpdateFromFilePostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIUpdateFromFilePostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIUpdateFromFilePostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIUpdateFromFilePostTask') class\.

```csharp
public UIUpdateFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIUpdateFromFilePostTask.UIUpdateFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager used to handle PostgreSQL Web API communications\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIUpdateFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIUpdateFromFilePostTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Concrete implementation of the background work\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIUpdateFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The provider for reporting progress of the operation\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIUpdateFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result is true if the update was successful; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIYearBuiltDatasFromFilePostTask'></a>

## UIYearBuiltDatasFromFilePostTask Class

Represents a task that extracts year built data from GIS model files and posts it to the PostgreSQL database\.

```csharp
public class UIYearBuiltDatasFromFilePostTask : DiGi.GIS.WebAPI.Classes.YearBuiltDatasPostTask, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1')[DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.serializableobjectsposttask-1 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.YearBuiltDatasPostTask](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.yearbuiltdatasposttask 'DiGi\.GIS\.WebAPI\.Classes\.YearBuiltDatasPostTask') → UIYearBuiltDatasFromFilePostTask

Implements [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIYearBuiltDatasFromFilePostTask.UIYearBuiltDatasFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## UIYearBuiltDatasFromFilePostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [UIYearBuiltDatasFromFilePostTask](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.UIYearBuiltDatasFromFilePostTask 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.UIYearBuiltDatasFromFilePostTask') class\.

```csharp
public UIYearBuiltDatasFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIYearBuiltDatasFromFilePostTask.UIYearBuiltDatasFromFilePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager used to handle communication with the PostgreSQL Web API\.
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIYearBuiltDatasFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## UIYearBuiltDatasFromFilePostTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Concrete implementation of the background work\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIYearBuiltDatasFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The provider for reporting progress of the operation\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIYearBuiltDatasFromFilePostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result is true if the process succeeded; otherwise, false\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions'></a>

## YearBuiltPredictionPipelineOptions Class

Provides the settings one unattended run of the Year Built prediction pipeline needs: which counties it covers, where it keeps its scratch files, which weights and interpreter score the imagery, and which of its steps actually run\.

Every step carries its own flag so a run can be resumed without repeating the expensive ones. Turning the write steps off is also how a first pass over a county is made harmless - the run reads everything, scores everything and stores nothing.

There is deliberately no member for the Web API key. These options are written to disk as JSON and the key is a secret, so it travels on [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager\.Key](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager.key 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager\.Key'), which the host reads from a git-ignored configuration file.

```csharp
public class YearBuiltPredictionPipelineOptions : DiGi.Core.Classes.SerializableOptions, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUISerializableObject, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → YearBuiltPredictionPipelineOptions

Implements [IGISPostgreSQLUISerializableObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUISerializableObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUISerializableObject'), [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.YearBuiltPredictionPipelineOptions()'></a>

## YearBuiltPredictionPipelineOptions\(\) Constructor

Initializes a new instance of the [YearBuiltPredictionPipelineOptions](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionPipelineOptions') class with default values\.

```csharp
public YearBuiltPredictionPipelineOptions();
```

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.YearBuiltPredictionPipelineOptions(DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions)'></a>

## YearBuiltPredictionPipelineOptions\(YearBuiltPredictionPipelineOptions\) Constructor

Initializes a new instance of the [YearBuiltPredictionPipelineOptions](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionPipelineOptions') class by copying an existing options instance\.

```csharp
public YearBuiltPredictionPipelineOptions(DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions? yearBuiltPredictionPipelineOptions);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.YearBuiltPredictionPipelineOptions(DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions).yearBuiltPredictionPipelineOptions'></a>

`yearBuiltPredictionPipelineOptions` [YearBuiltPredictionPipelineOptions](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionPipelineOptions')

The source options instance to copy from\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.YearBuiltPredictionPipelineOptions(System.Text.Json.Nodes.JsonObject)'></a>

## YearBuiltPredictionPipelineOptions\(JsonObject\) Constructor

Initializes a new instance of the [YearBuiltPredictionPipelineOptions](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionPipelineOptions') class using a JSON object\.

```csharp
public YearBuiltPredictionPipelineOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.YearBuiltPredictionPipelineOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the configuration settings\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.BatchSize'></a>

## YearBuiltPredictionPipelineOptions\.BatchSize Property

Gets or sets the number of buildings whose detections or predictions are sent in one request\.

A county carries ninety-odd detection columns over tens of thousands of buildings, so the writes are batched rather than sent as one body.

```csharp
public int BatchSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.Confidence'></a>

## YearBuiltPredictionPipelineOptions\.Confidence Property

Gets or sets the confidence threshold a detection has to reach to be reported, passed to the prediction script as \-\-conf\.

The default matches the script's own default. The weights are frozen, so this is the only knob over how much the detector reports.

```csharp
public double Confidence { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.CountyIds'></a>

## YearBuiltPredictionPipelineOptions\.CountyIds Property

Gets or sets the county rows the run covers, by identifier\.

Identifiers rather than codes, and each identifier is a polygon part: a county whose territory is in several pieces is held as one row per piece. Name every part of a county, so the parts are recognised as siblings and each written row is filed under the part its reference belongs to.

There is no run-everything default. The pipeline writes deployed data, so the scope is always stated.

```csharp
public System.Collections.Generic.HashSet<int>? CountyIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.HashSet&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.ExportImages'></a>

## YearBuiltPredictionPipelineOptions\.ExportImages Property

Gets or sets whether the orthophoto imagery is exported to the scratch directory before the detector runs\.

Turn it off to score imagery a previous run already wrote. With [Resume](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.Resume 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionPipelineOptions\.Resume') set the export skips what is on disk anyway, so leaving it on costs one listing request per county.

```csharp
public bool ExportImages { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.MaxConcurrentRequests'></a>

## YearBuiltPredictionPipelineOptions\.MaxConcurrentRequests Property

Gets or sets how many Web API requests may be in flight at once\.

```csharp
public int MaxConcurrentRequests { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.ModelPath'></a>

## YearBuiltPredictionPipelineOptions\.ModelPath Property

Gets or sets the path of the trained weights the detector scores with\.

Left null the script falls back to its own search, which picks whichever training run is newest on disk. Name the file, so a run is reproducible.

```csharp
public string? ModelPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.PythonPath'></a>

## YearBuiltPredictionPipelineOptions\.PythonPath Property

Gets or sets the path of the CPython interpreter that runs the prediction script, or the name of one on PATH\.

This has to be CPython with ultralytics and torch installed. The IronPython engine in DiGi.Scripting.Python can host neither.

```csharp
public string? PythonPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.ReferenceBatchSize'></a>

## YearBuiltPredictionPipelineOptions\.ReferenceBatchSize Property

Gets or sets how many references the feature table is asked for in one request\.

The endpoint refuses more than ten thousand references at a time and a county is thirty to a hundred and fifty thousand buildings, so the read is paged. A larger value is clamped down to the cap while the run works.

```csharp
public int ReferenceBatchSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.Resume'></a>

## YearBuiltPredictionPipelineOptions\.Resume Property

Gets or sets whether work a previous run already did is skipped rather than repeated\.

Governs the image export, which is the expensive step: an image already on disk is neither fetched nor re-encoded.

```csharp
public bool Resume { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.RunPrediction'></a>

## YearBuiltPredictionPipelineOptions\.RunPrediction Property

Gets or sets whether the detector is run over the exported imagery\.

Turn it off to re-use the detections a previous run wrote to the scratch directory. The results file is opened for writing rather than appending, so a repeated run replaces the previous answer instead of doubling it.

```csharp
public bool RunPrediction { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.Score'></a>

## YearBuiltPredictionPipelineOptions\.Score Property

Gets or sets whether the building features are read and scored into predicted construction years\.

Requires an implementation of [DiGi\.GIS\.IO\.Interfaces\.IYearBuiltPredictor](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.io.interfaces.iyearbuiltpredictor 'DiGi\.GIS\.IO\.Interfaces\.IYearBuiltPredictor'). With it off the run stops after the detections, which is the shape of a detection-only pass.

```csharp
public bool Score { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.ScratchDirectory'></a>

## YearBuiltPredictionPipelineOptions\.ScratchDirectory Property

Gets or sets the directory the run keeps its imagery and its detection results in\.

Each county gets its own folder underneath, named after the county identifier, so two counties cannot score each other's imagery and a resumed run finds what it left behind.

```csharp
public string? ScratchDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.UpdateDetections'></a>

## YearBuiltPredictionPipelineOptions\.UpdateDetections Property

Gets or sets whether the detection features are written into the stored building data\.

```csharp
public bool UpdateDetections { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.UpdatePredictedYearBuilt'></a>

## YearBuiltPredictionPipelineOptions\.UpdatePredictedYearBuilt Property

Gets or sets whether the latest predicted construction year is written into the building data column\.

Written from the same merged year built data the history step builds, so the column and the history cannot disagree.

```csharp
public bool UpdatePredictedYearBuilt { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.UpdateYearBuiltData'></a>

## YearBuiltPredictionPipelineOptions\.UpdateYearBuiltData Property

Gets or sets whether the dated prediction is written into the year built data, preserving the history\.

The stored entry is read back and added to rather than replaced, because a year built datum built fresh carries a new identifier and would be stored alongside the building's existing one rather than in place of it.

```csharp
public bool UpdateYearBuiltData { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.WorkingDirectory'></a>

## YearBuiltPredictionPipelineOptions\.WorkingDirectory Property

Gets or sets the directory the prediction process runs in, which is also where the runner keeps the Python scripts\.

The prediction script imports its helper module from the directory it sits in, so the two files have to stay together. Ultralytics also writes its own caches here.

```csharp
public string? WorkingDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionPipelineOptions.Years'></a>

## YearBuiltPredictionPipelineOptions\.Years Property

Gets or sets the range of years the detection and temporal features cover\.

Has to match the range the regressor was trained on, because it decides which columns the feature projection asks for. Null means the same default the column list itself applies.

```csharp
public DiGi.Core.Classes.Range<int>? Years { get; set; }
```

#### Property Value
[DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult'></a>

## YearBuiltPredictionResult Class

What one run of the Year Built prediction pipeline did: how much it read, how much it scored, how much it stored, and what it could not finish\.

[FailedStepNames](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.FailedStepNames 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionResult\.FailedStepNames') is what says whether a run did everything it set out to do. A step that fails is logged and stepped over so the steps behind it still run, so a result that came back at all is not by itself evidence of a complete run.

[RunTimestamp](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.RunTimestamp 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionResult\.RunTimestamp') is the stamp every prediction of the run carries into the year built data. One stamp for the whole run is deliberate: the stored entries are keyed by it, so a stamp taken per building would write one history entry per building instead of one per run.

```csharp
public class YearBuiltPredictionResult : DiGi.Core.Classes.SerializableResult, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUISerializableObject, DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → YearBuiltPredictionResult

Implements [IGISPostgreSQLUISerializableObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUISerializableObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUISerializableObject'), [IGISPostgreSQLUIObject](DiGi.GIS.PostgreSQL.UI.Interfaces.md#DiGi.GIS.PostgreSQL.UI.Interfaces.IGISPostgreSQLUIObject 'DiGi\.GIS\.PostgreSQL\.UI\.Interfaces\.IGISPostgreSQLUIObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult)'></a>

## YearBuiltPredictionResult\(YearBuiltPredictionResult\) Constructor

Initializes a new instance of the [YearBuiltPredictionResult](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionResult') class by copying an existing one\.

```csharp
public YearBuiltPredictionResult(DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult? yearBuiltPredictionResult);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult).yearBuiltPredictionResult'></a>

`yearBuiltPredictionResult` [YearBuiltPredictionResult](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionResult')

The [YearBuiltPredictionResult](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionResult') to copy from\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool)'></a>

## YearBuiltPredictionResult\(IEnumerable\<int\>, Nullable\<DateTimeOffset\>, Nullable\<DateTimeOffset\>, Nullable\<DateTimeOffset\>, long, long, long, long, long, long, long, IEnumerable\<string\>, IEnumerable\<string\>, bool\) Constructor

Initializes a new instance of the [YearBuiltPredictionResult](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionResult') class\.

```csharp
public YearBuiltPredictionResult(System.Collections.Generic.IEnumerable<int>? countyIds, System.Nullable<System.DateTimeOffset> runTimestamp, System.Nullable<System.DateTimeOffset> start, System.Nullable<System.DateTimeOffset> end, long imageCount, long detectionCount, long buildingCount, long featureRowCount, long predictionCount, long yearBuiltDataUpdatedCount, long buildingDataUpdatedCount, System.Collections.Generic.IEnumerable<string>? failedStepNames, System.Collections.Generic.IEnumerable<string>? messages, bool cancelled);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).countyIds'></a>

`countyIds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The county rows the run covered, or null for none\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).runTimestamp'></a>

`runTimestamp` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The stamp every prediction of the run carries, or null when nothing was scored\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).start'></a>

`start` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

When the run started\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).end'></a>

`end` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

When the run ended\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).imageCount'></a>

`imageCount` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The number of orthophoto images the detector was given\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).detectionCount'></a>

`detectionCount` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The number of detections the detector reported\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).buildingCount'></a>

`buildingCount` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The number of buildings carrying at least one detection\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).featureRowCount'></a>

`featureRowCount` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The number of building data rows read for scoring\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).predictionCount'></a>

`predictionCount` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The number of construction years the regressor returned\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).yearBuiltDataUpdatedCount'></a>

`yearBuiltDataUpdatedCount` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The number of year built data entries written\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).buildingDataUpdatedCount'></a>

`buildingDataUpdatedCount` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The number of building data rows written\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).failedStepNames'></a>

`failedStepNames` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The steps that reported a failure, or null for none\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

What the run has to say beyond its tallies, or null for nothing\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Collections.Generic.IEnumerable_int_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,long,long,long,long,long,long,long,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool).cancelled'></a>

`cancelled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the run was stopped before it covered everything it was given\.

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Text.Json.Nodes.JsonObject)'></a>

## YearBuiltPredictionResult\(JsonObject\) Constructor

Initializes a new instance of the [YearBuiltPredictionResult](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.YearBuiltPredictionResult') class from a [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')\.

```csharp
public YearBuiltPredictionResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltPredictionResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the serialized data\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.BuildingCount'></a>

## YearBuiltPredictionResult\.BuildingCount Property

Gets the number of buildings carrying at least one detection\.

Lower than the number of images, because one building is imaged once per year of orthophoto coverage, and lower than the number of buildings in the county, because a building the detector found nothing on in any year is not counted.

```csharp
public long BuildingCount { get; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.BuildingDataUpdatedCount'></a>

## YearBuiltPredictionResult\.BuildingDataUpdatedCount Property

Gets the number of building data rows written, counting the detection write and the predicted year column separately\.

```csharp
public long BuildingDataUpdatedCount { get; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.Cancelled'></a>

## YearBuiltPredictionResult\.Cancelled Property

Gets whether the run was stopped before it covered everything it was given\.

```csharp
public bool Cancelled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.CountyIds'></a>

## YearBuiltPredictionResult\.CountyIds Property

Gets the county rows the run covered\.

Each identifier is a polygon part rather than a county, so a multi-part county appears here once per part.

```csharp
public System.Collections.Generic.List<int> CountyIds { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.DetectionCount'></a>

## YearBuiltPredictionResult\.DetectionCount Property

Gets the number of detections the detector reported, across every building and every year\.

```csharp
public long DetectionCount { get; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.Duration'></a>

## YearBuiltPredictionResult\.Duration Property

Gets the duration of the run, or null when it did not record both ends\.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.End'></a>

## YearBuiltPredictionResult\.End Property

Gets when the run ended\.

```csharp
public System.Nullable<System.DateTimeOffset> End { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.FailedStepNames'></a>

## YearBuiltPredictionResult\.FailedStepNames Property

Gets the steps that reported a failure and were stepped over\.

Empty is the only evidence that a run did everything it set out to do - the result comes back either way.

```csharp
public System.Collections.Generic.List<string> FailedStepNames { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.FeatureRowCount'></a>

## YearBuiltPredictionResult\.FeatureRowCount Property

Gets the number of building data rows read for scoring\.

```csharp
public long FeatureRowCount { get; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.ImageCount'></a>

## YearBuiltPredictionResult\.ImageCount Property

Gets the number of orthophoto images the detector was given\.

```csharp
public long ImageCount { get; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.Messages'></a>

## YearBuiltPredictionResult\.Messages Property

Gets what the run has to say beyond its tallies, such as why the machine could not run the detector at all\.

```csharp
public System.Collections.Generic.List<string> Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.PredictionCount'></a>

## YearBuiltPredictionResult\.PredictionCount Property

Gets the number of construction years the regressor returned\.

```csharp
public long PredictionCount { get; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.RunTimestamp'></a>

## YearBuiltPredictionResult\.RunTimestamp Property

Gets the stamp every prediction of the run carries into the year built data, or null when nothing was scored\.

One stamp for the whole run. The stored entries are keyed by it, so re-running with the same stamp replaces the run rather than adding to the history, and a stamp taken per building would write one entry per building.

```csharp
public System.Nullable<System.DateTimeOffset> RunTimestamp { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.Start'></a>

## YearBuiltPredictionResult\.Start Property

Gets when the run started\.

```csharp
public System.Nullable<System.DateTimeOffset> Start { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Classes.YearBuiltPredictionResult.YearBuiltDataUpdatedCount'></a>

## YearBuiltPredictionResult\.YearBuiltDataUpdatedCount Property

Gets the number of year built data entries written, preserving each building's history\.

```csharp
public long YearBuiltDataUpdatedCount { get; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')