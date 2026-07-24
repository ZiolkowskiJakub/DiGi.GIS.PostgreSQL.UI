#### [DiGi\.GIS\.PostgreSQL\.UI](DiGi.GIS.PostgreSQL.UI.Overview.md 'DiGi\.GIS\.PostgreSQL\.UI\.Overview')

## DiGi\.GIS\.PostgreSQL\.UI\.Classes Namespace
### Classes

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

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDatabasePostTask.PageSize'></a>

## UIBuildingModelsFromDatabasePostTask\.PageSize Property

Gets or sets the number of [DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DReference') items requested per page while downloading a county's buildings\.

```csharp
public int PageSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

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