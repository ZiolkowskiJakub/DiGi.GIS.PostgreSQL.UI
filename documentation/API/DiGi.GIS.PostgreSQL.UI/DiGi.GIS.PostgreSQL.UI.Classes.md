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

<a name='DiGi.GIS.PostgreSQL.UI.Classes.UIBuildingModelsFromDirectoryPostTask'></a>

## UIBuildingModelsFromDirectoryPostTask Class

A UI\-driven post task that prompts the user to select a directory, reads CityGML city models from it, fetches building 2D data per county from the server, generates [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') instances, and uploads them in batches\.

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