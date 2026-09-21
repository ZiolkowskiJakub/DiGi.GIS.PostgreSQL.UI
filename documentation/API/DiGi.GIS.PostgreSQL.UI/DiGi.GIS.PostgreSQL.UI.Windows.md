#### [DiGi\.GIS\.PostgreSQL\.UI](DiGi.GIS.PostgreSQL.UI.Overview.md 'DiGi\.GIS\.PostgreSQL\.UI\.Overview')

## DiGi\.GIS\.PostgreSQL\.UI\.Windows Namespace
### Classes

<a name='DiGi.GIS.PostgreSQL.UI.Windows.BuildingModelsFromDatabaseOptionsWindow'></a>

## BuildingModelsFromDatabaseOptionsWindow Class

Interaction logic for BuildingModelsFromDatabaseOptionsWindow\.xaml

Asks what decides the reach of a BuildingModel regeneration from the database: which county polygon parts are walked, whether the checkpoint of an earlier run is honoured, and where the checkpoint and the failed-county list are written. The request pacing stays with the task - it is tuning nobody changes between runs, and is set where the task is registered.

No county selected means every county, which is what the task has always meant.

The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.

```csharp
public class BuildingModelsFromDatabaseOptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → BuildingModelsFromDatabaseOptionsWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.BuildingModelsFromDatabaseOptionsWindow.BuildingModelsFromDatabaseOptionsWindow(DiGi.GIS.PostgreSQL.UI.Classes.BuildingModelsFromDatabaseOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_)'></a>

## BuildingModelsFromDatabaseOptionsWindow\(BuildingModelsFromDatabaseOptions, IEnumerable\<AdministrativeAreal2DReference\>\) Constructor

Initializes a new instance of the [BuildingModelsFromDatabaseOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.BuildingModelsFromDatabaseOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.BuildingModelsFromDatabaseOptionsWindow') class\.

```csharp
public BuildingModelsFromDatabaseOptionsWindow(DiGi.GIS.PostgreSQL.UI.Classes.BuildingModelsFromDatabaseOptions? buildingModelsFromDatabaseOptions, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference>? administrativeAreal2DReferences);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.BuildingModelsFromDatabaseOptionsWindow.BuildingModelsFromDatabaseOptionsWindow(DiGi.GIS.PostgreSQL.UI.Classes.BuildingModelsFromDatabaseOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).buildingModelsFromDatabaseOptions'></a>

`buildingModelsFromDatabaseOptions` [BuildingModelsFromDatabaseOptions](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.BuildingModelsFromDatabaseOptions 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.BuildingModelsFromDatabaseOptions')

The options the controls are filled from\. When null the defaults are used\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.BuildingModelsFromDatabaseOptionsWindow.BuildingModelsFromDatabaseOptionsWindow(DiGi.GIS.PostgreSQL.UI.Classes.BuildingModelsFromDatabaseOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).administrativeAreal2DReferences'></a>

`administrativeAreal2DReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The counties to choose from\. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.BuildingModelsFromDatabaseOptionsWindow.BuildingModelsFromDatabaseOptions'></a>

## BuildingModelsFromDatabaseOptionsWindow\.BuildingModelsFromDatabaseOptions Property

Gets the options the window holds\. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with\.

```csharp
public DiGi.GIS.PostgreSQL.UI.Classes.BuildingModelsFromDatabaseOptions BuildingModelsFromDatabaseOptions { get; }
```

#### Property Value
[BuildingModelsFromDatabaseOptions](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.BuildingModelsFromDatabaseOptions 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.BuildingModelsFromDatabaseOptions')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.BuildingModelsFromDatabaseOptionsWindow.InitializeComponent()'></a>

## BuildingModelsFromDatabaseOptionsWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow'></a>

## MainWindow Class

MainWindow

```csharp
public class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → MainWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Nullable_DiGi.GIS.PostgreSQL.UI.Enums.Mode_)'></a>

## MainWindow\(GISPostgreSQLConverterManager, UserPostgreSQLConverterManager, GISWebAPIManager, Nullable\<Mode\>\) Constructor

Initializes a new instance of the [MainWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.MainWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.MainWindow') class\.

```csharp
public MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager? gISPostgreSQLConverterManager, DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager? userPostgreSQLConverterManager, DiGi.GIS.WebAPI.Classes.GISWebAPIManager? GISWebAPIManager, System.Nullable<DiGi.GIS.PostgreSQL.UI.Enums.Mode> mode=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Nullable_DiGi.GIS.PostgreSQL.UI.Enums.Mode_).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The manager responsible for GIS PostgreSQL conversion processes\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Nullable_DiGi.GIS.PostgreSQL.UI.Enums.Mode_).userPostgreSQLConverterManager'></a>

`userPostgreSQLConverterManager` [DiGi\.User\.PostgreSQL\.Classes\.UserPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.user.postgresql.classes.userpostgresqlconvertermanager 'DiGi\.User\.PostgreSQL\.Classes\.UserPostgreSQLConverterManager')

The manager holding the converter for the user database, or null where no User\_PostgreSQL\_Main\.conf names one\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Nullable_DiGi.GIS.PostgreSQL.UI.Enums.Mode_).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager responsible for GIS PostgreSQL Web API interactions\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Nullable_DiGi.GIS.PostgreSQL.UI.Enums.Mode_).mode'></a>

`mode` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Mode](DiGi.GIS.PostgreSQL.UI.Enums.md#DiGi.GIS.PostgreSQL.UI.Enums.Mode 'DiGi\.GIS\.PostgreSQL\.UI\.Enums\.Mode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The operational mode of the application\. If null, it is determined based on converter availability\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.Mode'></a>

## MainWindow\.Mode Property

Gets the current operational mode of the application\.

```csharp
public DiGi.GIS.PostgreSQL.UI.Enums.Mode Mode { get; }
```

#### Property Value
[Mode](DiGi.GIS.PostgreSQL.UI.Enums.md#DiGi.GIS.PostgreSQL.UI.Enums.Mode 'DiGi\.GIS\.PostgreSQL\.UI\.Enums\.Mode')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.VisualBackgroundTasks_Client'></a>

## MainWindow\.VisualBackgroundTasks\_Client Property

Gets or sets the collection of visual background tasks associated with the client operational mode\.

```csharp
public System.Collections.ObjectModel.ObservableCollection<DiGi.UI.WPF.Interfaces.IVisualBackgroundTask>? VisualBackgroundTasks_Client { get; set; }
```

#### Property Value
[System\.Collections\.ObjectModel\.ObservableCollection&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1 'System\.Collections\.ObjectModel\.ObservableCollection\`1')[DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.wpf.interfaces.ivisualbackgroundtask 'DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1 'System\.Collections\.ObjectModel\.ObservableCollection\`1')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.VisualBackgroundTasks_Server'></a>

## MainWindow\.VisualBackgroundTasks\_Server Property

Gets or sets the collection of visual background tasks associated with the server operational mode\.

```csharp
public System.Collections.ObjectModel.ObservableCollection<DiGi.UI.WPF.Interfaces.IVisualBackgroundTask>? VisualBackgroundTasks_Server { get; set; }
```

#### Property Value
[System\.Collections\.ObjectModel\.ObservableCollection&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1 'System\.Collections\.ObjectModel\.ObservableCollection\`1')[DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.wpf.interfaces.ivisualbackgroundtask 'DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1 'System\.Collections\.ObjectModel\.ObservableCollection\`1')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.InitializeComponent()'></a>

## MainWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuilding2DRefreshOptionsWindow'></a>

## PostgreSQLBuilding2DRefreshOptionsWindow Class

Interaction logic for PostgreSQLBuilding2DRefreshOptionsWindow\.xaml

Asks for what decides the cost and the reach of a Building2D refresh: whether buildings that already carry a `subdivision_id` are re-derived, whether the run is limited to the counties whose subdivision layer nests, and which counties are walked at all. Unscoped and overriding, the run re-derives every building in the country.

No county selected means every county - the scope the refresh has always had. The nested-layer box names the counties where the previous tie-break produced an arbitrary value (DiGi.GIS.PostgreSQL#77); expect it to exclude very little, because a village and its named parts nest as a city and its districts do. The county list is what makes a trial run small.

The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.

```csharp
public class PostgreSQLBuilding2DRefreshOptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → PostgreSQLBuilding2DRefreshOptionsWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuilding2DRefreshOptionsWindow.PostgreSQLBuilding2DRefreshOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuilding2DRefreshOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_)'></a>

## PostgreSQLBuilding2DRefreshOptionsWindow\(PostgreSQLBuilding2DRefreshOptions, IEnumerable\<AdministrativeAreal2DReference\>\) Constructor

Initializes a new instance of the [PostgreSQLBuilding2DRefreshOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuilding2DRefreshOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLBuilding2DRefreshOptionsWindow') class\.

```csharp
public PostgreSQLBuilding2DRefreshOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuilding2DRefreshOptions? postgreSQLBuilding2DRefreshOptions, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference>? administrativeAreal2DReferences);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuilding2DRefreshOptionsWindow.PostgreSQLBuilding2DRefreshOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuilding2DRefreshOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).postgreSQLBuilding2DRefreshOptions'></a>

`postgreSQLBuilding2DRefreshOptions` [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuilding2DRefreshOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlbuilding2drefreshoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuilding2DRefreshOptions')

The options the controls are filled from\. When null the defaults are used\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuilding2DRefreshOptionsWindow.PostgreSQLBuilding2DRefreshOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuilding2DRefreshOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).administrativeAreal2DReferences'></a>

`administrativeAreal2DReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The counties to choose from\. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuilding2DRefreshOptionsWindow.PostgreSQLBuilding2DRefreshOptions'></a>

## PostgreSQLBuilding2DRefreshOptionsWindow\.PostgreSQLBuilding2DRefreshOptions Property

Gets the options the window holds\. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with\.

```csharp
public DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuilding2DRefreshOptions PostgreSQLBuilding2DRefreshOptions { get; }
```

#### Property Value
[DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuilding2DRefreshOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlbuilding2drefreshoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuilding2DRefreshOptions')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuilding2DRefreshOptionsWindow.InitializeComponent()'></a>

## PostgreSQLBuilding2DRefreshOptionsWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow'></a>

## PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow Class

Interaction logic for PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow\.xaml

Asks for the two settings that decide what a run touches and how long a statement may take - which counties, and the command timeout. The run reads the stored building models of the counties in scope, so the counties decide its reach and its cost; left unscoped it walks every county part in the country.

Every county is selected by default, so opening the dialog confirms the national scope rather than inviting it; deselecting everything is still refused at OK, because an empty selection is not the same as no selection and neither is a safe thing to leave this window with by accident.

The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.

```csharp
public class PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataExternalComponentsUpdateOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_)'></a>

## PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow\(PostgreSQLBuildingDataExternalComponentsUpdateOptions, IEnumerable\<AdministrativeAreal2DReference\>\) Constructor

Initializes a new instance of the [PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow') class\.

```csharp
public PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataExternalComponentsUpdateOptions? postgreSQLBuildingDataExternalComponentsUpdateOptions, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference>? administrativeAreal2DReferences);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataExternalComponentsUpdateOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).postgreSQLBuildingDataExternalComponentsUpdateOptions'></a>

`postgreSQLBuildingDataExternalComponentsUpdateOptions` [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataExternalComponentsUpdateOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlbuildingdataexternalcomponentsupdateoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataExternalComponentsUpdateOptions')

The options the controls are filled from\. When null the defaults are used\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataExternalComponentsUpdateOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).administrativeAreal2DReferences'></a>

`administrativeAreal2DReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The counties to choose from\. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own\. All of them are selected when the options carry no county set\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow.PostgreSQLBuildingDataExternalComponentsUpdateOptions'></a>

## PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow\.PostgreSQLBuildingDataExternalComponentsUpdateOptions Property

Gets the options the window holds\. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with\.

```csharp
public DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataExternalComponentsUpdateOptions PostgreSQLBuildingDataExternalComponentsUpdateOptions { get; }
```

#### Property Value
[DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataExternalComponentsUpdateOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlbuildingdataexternalcomponentsupdateoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataExternalComponentsUpdateOptions')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow.InitializeComponent()'></a>

## PostgreSQLBuildingDataExternalComponentsUpdateOptionsWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataUpdateOptionsWindow'></a>

## PostgreSQLBuildingDataUpdateOptionsWindow Class

Interaction logic for PostgreSQLBuildingDataUpdateOptionsWindow\.xaml

Asks for the three settings that decide what a run costs and touches - which counties, which kinds of column, and how long a statement may take. The radiuses are carried over from the instance it was given untouched: each one names its own pair of stored columns, so changing them from a dialog would change the shape of the table rather than the numbers in it.

The counties matter most. Left unscoped the run walks every subdivision in the country, which is the pass nobody wants to start by accident while trying one county.

The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.

```csharp
public class PostgreSQLBuildingDataUpdateOptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → PostgreSQLBuildingDataUpdateOptionsWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataUpdateOptionsWindow.PostgreSQLBuildingDataUpdateOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataUpdateOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_)'></a>

## PostgreSQLBuildingDataUpdateOptionsWindow\(PostgreSQLBuildingDataUpdateOptions, IEnumerable\<AdministrativeAreal2DReference\>\) Constructor

Initializes a new instance of the [PostgreSQLBuildingDataUpdateOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataUpdateOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLBuildingDataUpdateOptionsWindow') class\.

```csharp
public PostgreSQLBuildingDataUpdateOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataUpdateOptions? postgreSQLBuildingDataUpdateOptions, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference>? administrativeAreal2DReferences);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataUpdateOptionsWindow.PostgreSQLBuildingDataUpdateOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataUpdateOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).postgreSQLBuildingDataUpdateOptions'></a>

`postgreSQLBuildingDataUpdateOptions` [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataUpdateOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlbuildingdataupdateoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataUpdateOptions')

The options the controls are filled from\. When null the defaults are used\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataUpdateOptionsWindow.PostgreSQLBuildingDataUpdateOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataUpdateOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).administrativeAreal2DReferences'></a>

`administrativeAreal2DReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The counties to choose from\. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataUpdateOptionsWindow.PostgreSQLBuildingDataUpdateOptions'></a>

## PostgreSQLBuildingDataUpdateOptionsWindow\.PostgreSQLBuildingDataUpdateOptions Property

Gets the options the window holds\. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with\.

```csharp
public DiGi.GIS.PostgreSQL.Classes.PostgreSQLBuildingDataUpdateOptions PostgreSQLBuildingDataUpdateOptions { get; }
```

#### Property Value
[DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataUpdateOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlbuildingdataupdateoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLBuildingDataUpdateOptions')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLBuildingDataUpdateOptionsWindow.InitializeComponent()'></a>

## PostgreSQLBuildingDataUpdateOptionsWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointCreateTableOptionsWindow'></a>

## PostgreSQLTerrainPointCreateTableOptionsWindow Class

Interaction logic for PostgreSQLTerrainPointCreateTableOptionsWindow\.xaml

Asks for the three settings that decide what a terrain point run costs and covers - the spacing of the sampling grid, whether points already stored are sampled again, and the counties to sample. Every other option of the instance it was given is carried over untouched, which is deliberate: the origin of the grid and the tile size are what let separate runs share their points, and they are not settings to change from a dialog.

The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.

```csharp
public class PostgreSQLTerrainPointCreateTableOptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → PostgreSQLTerrainPointCreateTableOptionsWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointCreateTableOptionsWindow.PostgreSQLTerrainPointCreateTableOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointCreateTableOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult_)'></a>

## PostgreSQLTerrainPointCreateTableOptionsWindow\(PostgreSQLTerrainPointCreateTableOptions, IEnumerable\<AdministrativeAreal2DReference\>, IEnumerable\<TerrainPointDensityResult\>\) Constructor

Initializes a new instance of the [PostgreSQLTerrainPointCreateTableOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointCreateTableOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLTerrainPointCreateTableOptionsWindow') class\.

```csharp
public PostgreSQLTerrainPointCreateTableOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointCreateTableOptions? postgreSQLTerrainPointCreateTableOptions, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference>? administrativeAreal2DReferences, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult>? terrainPointDensityResults=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointCreateTableOptionsWindow.PostgreSQLTerrainPointCreateTableOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointCreateTableOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult_).postgreSQLTerrainPointCreateTableOptions'></a>

`postgreSQLTerrainPointCreateTableOptions` [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointCreateTableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlterrainpointcreatetableoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointCreateTableOptions')

The options the controls are filled from\. When null the defaults are used\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointCreateTableOptionsWindow.PostgreSQLTerrainPointCreateTableOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointCreateTableOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult_).administrativeAreal2DReferences'></a>

`administrativeAreal2DReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The counties to choose from\. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointCreateTableOptionsWindow.PostgreSQLTerrainPointCreateTableOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointCreateTableOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult_).terrainPointDensityResults'></a>

`terrainPointDensityResults` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.TerrainPointDensityResult](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.terrainpointdensityresult 'DiGi\.GIS\.PostgreSQL\.Classes\.TerrainPointDensityResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The density measurements of the county partitions\. When provided, point count, density and equivalent spacing are shown for each county\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointCreateTableOptionsWindow.PostgreSQLTerrainPointCreateTableOptions'></a>

## PostgreSQLTerrainPointCreateTableOptionsWindow\.PostgreSQLTerrainPointCreateTableOptions Property

Gets the options the window holds\. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with\.

```csharp
public DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointCreateTableOptions PostgreSQLTerrainPointCreateTableOptions { get; }
```

#### Property Value
[DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointCreateTableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlterrainpointcreatetableoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointCreateTableOptions')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointCreateTableOptionsWindow.InitializeComponent()'></a>

## PostgreSQLTerrainPointCreateTableOptionsWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointFillGapsOptionsWindow'></a>

## PostgreSQLTerrainPointFillGapsOptionsWindow Class

Interaction logic for PostgreSQLTerrainPointFillGapsOptionsWindow\.xaml

Asks for the two settings that decide what a repair covers - the spacing the counties were sampled at, and the counties to measure. Every other option of the instance it was given is carried over untouched: the origin of the lattice and the tile size are what let this agree with the run it is repairing, and they are not settings to change from a dialog.

The spacing is the one that has to be right. Set finer than a county actually holds, every node in between reads as a gap and the repair turns into a densification of the whole country, so the equivalent spacing measured for each county is shown beside it.

The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.

```csharp
public class PostgreSQLTerrainPointFillGapsOptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → PostgreSQLTerrainPointFillGapsOptionsWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointFillGapsOptionsWindow.PostgreSQLTerrainPointFillGapsOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointFillGapsOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult_)'></a>

## PostgreSQLTerrainPointFillGapsOptionsWindow\(PostgreSQLTerrainPointFillGapsOptions, IEnumerable\<AdministrativeAreal2DReference\>, IEnumerable\<TerrainPointDensityResult\>\) Constructor

Initializes a new instance of the [PostgreSQLTerrainPointFillGapsOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointFillGapsOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLTerrainPointFillGapsOptionsWindow') class\.

```csharp
public PostgreSQLTerrainPointFillGapsOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointFillGapsOptions? postgreSQLTerrainPointFillGapsOptions, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference>? administrativeAreal2DReferences, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult>? terrainPointDensityResults=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointFillGapsOptionsWindow.PostgreSQLTerrainPointFillGapsOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointFillGapsOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult_).postgreSQLTerrainPointFillGapsOptions'></a>

`postgreSQLTerrainPointFillGapsOptions` [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointFillGapsOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlterrainpointfillgapsoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointFillGapsOptions')

The options the controls are filled from\. When null the defaults are used\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointFillGapsOptionsWindow.PostgreSQLTerrainPointFillGapsOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointFillGapsOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult_).administrativeAreal2DReferences'></a>

`administrativeAreal2DReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The counties to choose from\. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointFillGapsOptionsWindow.PostgreSQLTerrainPointFillGapsOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointFillGapsOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.TerrainPointDensityResult_).terrainPointDensityResults'></a>

`terrainPointDensityResults` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.TerrainPointDensityResult](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.terrainpointdensityresult 'DiGi\.GIS\.PostgreSQL\.Classes\.TerrainPointDensityResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The density measurements of the county partitions\. When provided, point count, density and equivalent spacing are shown for each county\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointFillGapsOptionsWindow.PostgreSQLTerrainPointFillGapsOptions'></a>

## PostgreSQLTerrainPointFillGapsOptionsWindow\.PostgreSQLTerrainPointFillGapsOptions Property

Gets the options the window holds\. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with\.

```csharp
public DiGi.GIS.PostgreSQL.Classes.PostgreSQLTerrainPointFillGapsOptions PostgreSQLTerrainPointFillGapsOptions { get; }
```

#### Property Value
[DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointFillGapsOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlterrainpointfillgapsoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLTerrainPointFillGapsOptions')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLTerrainPointFillGapsOptionsWindow.InitializeComponent()'></a>

## PostgreSQLTerrainPointFillGapsOptionsWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUpdateOccupancyOptionsWindow'></a>

## PostgreSQLUpdateOccupancyOptionsWindow Class

Interaction logic for PostgreSQLUpdateOccupancyOptionsWindow\.xaml

Asks which side of the occupancy update runs - the administrative roll-up, the per-building distribution, or both - whether the stored rows are cleared first, and which counties the building side is limited to. The roll-up is a sum over the whole hierarchy and stays nationwide whatever counties are selected.

No county selected means every county, which is what the task has always meant; with counties selected a clear removes only their buildings' rows, so the rest of the table is left as it stands.

The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were.

```csharp
public class PostgreSQLUpdateOccupancyOptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → PostgreSQLUpdateOccupancyOptionsWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUpdateOccupancyOptionsWindow.PostgreSQLUpdateOccupancyOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLUpdateOccupancyOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_)'></a>

## PostgreSQLUpdateOccupancyOptionsWindow\(PostgreSQLUpdateOccupancyOptions, IEnumerable\<AdministrativeAreal2DReference\>\) Constructor

Initializes a new instance of the [PostgreSQLUpdateOccupancyOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUpdateOccupancyOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLUpdateOccupancyOptionsWindow') class\.

```csharp
public PostgreSQLUpdateOccupancyOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLUpdateOccupancyOptions? postgreSQLUpdateOccupancyOptions, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference>? administrativeAreal2DReferences);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUpdateOccupancyOptionsWindow.PostgreSQLUpdateOccupancyOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLUpdateOccupancyOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).postgreSQLUpdateOccupancyOptions'></a>

`postgreSQLUpdateOccupancyOptions` [DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLUpdateOccupancyOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlupdateoccupancyoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLUpdateOccupancyOptions')

The options the controls are filled from\. When null the defaults are used\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUpdateOccupancyOptionsWindow.PostgreSQLUpdateOccupancyOptionsWindow(DiGi.GIS.PostgreSQL.Classes.PostgreSQLUpdateOccupancyOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).administrativeAreal2DReferences'></a>

`administrativeAreal2DReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The counties to choose from\. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUpdateOccupancyOptionsWindow.PostgreSQLUpdateOccupancyOptions'></a>

## PostgreSQLUpdateOccupancyOptionsWindow\.PostgreSQLUpdateOccupancyOptions Property

Gets the options the window holds\. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with\.

```csharp
public DiGi.GIS.PostgreSQL.Classes.PostgreSQLUpdateOccupancyOptions PostgreSQLUpdateOccupancyOptions { get; }
```

#### Property Value
[DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLUpdateOccupancyOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.postgresqlupdateoccupancyoptions 'DiGi\.GIS\.PostgreSQL\.Classes\.PostgreSQLUpdateOccupancyOptions')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUpdateOccupancyOptionsWindow.InitializeComponent()'></a>

## PostgreSQLUpdateOccupancyOptionsWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUserCreateOptionsWindow'></a>

## PostgreSQLUserCreateOptionsWindow Class

Interaction logic for PostgreSQLUserCreateOptionsWindow\.xaml

Asks for the user to be created: the email it is keyed by, its optional name, the password it is
            authenticated with and the permission level it is granted.

The email and the password are each asked for twice. Neither can be corrected afterwards by anything
            this application offers - the email is the natural key of the row, and the password is never stored in a form
            anything can read back - so a typo in either produces an account nobody can use.

Unlike the other options windows this one carries no options object. The password reaches it as text,
            and an options instance would keep that text alive on the task for the life of the process; the values live
            here instead, on a window the task creates, reads and closes within one run.

```csharp
public class PostgreSQLUserCreateOptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → PostgreSQLUserCreateOptionsWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUserCreateOptionsWindow.PostgreSQLUserCreateOptionsWindow()'></a>

## PostgreSQLUserCreateOptionsWindow\(\) Constructor

Initializes a new instance of the [PostgreSQLUserCreateOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUserCreateOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.PostgreSQLUserCreateOptionsWindow') class\.

```csharp
public PostgreSQLUserCreateOptionsWindow();
```
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUserCreateOptionsWindow.Email'></a>

## PostgreSQLUserCreateOptionsWindow\.Email Property

Gets the email of the user to create\. It carries the value of the control only once the dialog has been closed with OK; until then, and after a cancellation, it is null\.

```csharp
public string? Email { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUserCreateOptionsWindow.FirstName'></a>

## PostgreSQLUserCreateOptionsWindow\.FirstName Property

Gets the optional first name of the user to create, or null when the field was left blank\.

```csharp
public string? FirstName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUserCreateOptionsWindow.LastName'></a>

## PostgreSQLUserCreateOptionsWindow\.LastName Property

Gets the optional last name of the user to create, or null when the field was left blank\.

```csharp
public string? LastName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUserCreateOptionsWindow.Password'></a>

## PostgreSQLUserCreateOptionsWindow\.Password Property

Gets the plain text password the credential is to be derived from\. It exists only between the dialog being closed with OK and the credential being derived, and is never written to the database or to a log\.

```csharp
public string? Password { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUserCreateOptionsWindow.UserLevel'></a>

## PostgreSQLUserCreateOptionsWindow\.UserLevel Property

Gets the permission level to grant the user\.

```csharp
public DiGi.User.Enums.UserLevel UserLevel { get; }
```

#### Property Value
[DiGi\.User\.Enums\.UserLevel](https://learn.microsoft.com/en-us/dotnet/api/digi.user.enums.userlevel 'DiGi\.User\.Enums\.UserLevel')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.PostgreSQLUserCreateOptionsWindow.InitializeComponent()'></a>

## PostgreSQLUserCreateOptionsWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')

<a name='DiGi.GIS.PostgreSQL.UI.Windows.YearBuiltPredictionsOptionsWindow'></a>

## YearBuiltPredictionsOptionsWindow Class

Interaction logic for YearBuiltPredictionsOptionsWindow\.xaml

Asks for the scope of one Year Built prediction run and nothing else: the counties, where its imagery goes, which interpreter runs the detector, and how hard the export leans on the server.

<b>A tray run has one shape - the full six step flow - and it writes.</b> The steps are not offered because they are not a choice here: ZiolkowskiJakub/DiGi.GIS.YOLO.UI#8 made export, detector, detection write, score, history write and column write a single run per county precisely so that no step could be left out of sequence, and it decided that the granular flags stay on the options class and the console app for hand-driven diagnostics while the tray driven flow collapses them. Eight checkboxes offered two hundred and fifty six combinations, of which three were real - and the rest failed late, after the half hour of export and the hour and a half of inference had already been paid for. The OK handler writes all six on, so the run the operator gets is the run the standing recipe describes.

<b>What settles the model is deliberately not here either.</b> The weights, the confidence threshold, the year range and the radiuses all decide what the regressor is handed, and a value that disagrees with what it was trained on scores without failing - the predictions are worse by an amount nothing measures (ZiolkowskiJakub/DiGi.GIS.ML#6). They belong to the deployment and to the options file rather than to a dialog opened before every run. The working directory and the two batch sizes are out for a different reason: none of the three is a choice - see the comment in the OK handler.

The scratch cleanup is the one flag that survives, because its reason is about this run rather than about the sequence: a cancelled county is cleaned, so a run that is meant to be interrupted has to be able to say so beforehand.

The window works on a copy, so a cancelled dialog leaves the settings of an earlier run exactly as they were, and every member the window has no control for carries through untouched.

```csharp
public class YearBuiltPredictionsOptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → YearBuiltPredictionsOptionsWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.YearBuiltPredictionsOptionsWindow.YearBuiltPredictionsOptionsWindow(DiGi.GIS.YOLO.UI.Classes.YearBuiltPredictionPipelineOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_)'></a>

## YearBuiltPredictionsOptionsWindow\(YearBuiltPredictionPipelineOptions, IEnumerable\<AdministrativeAreal2DReference\>\) Constructor

Initializes a new instance of the [YearBuiltPredictionsOptionsWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.YearBuiltPredictionsOptionsWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.YearBuiltPredictionsOptionsWindow') class\.

```csharp
public YearBuiltPredictionsOptionsWindow(DiGi.GIS.YOLO.UI.Classes.YearBuiltPredictionPipelineOptions? yearBuiltPredictionPipelineOptions, System.Collections.Generic.IEnumerable<DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference>? administrativeAreal2DReferences);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.YearBuiltPredictionsOptionsWindow.YearBuiltPredictionsOptionsWindow(DiGi.GIS.YOLO.UI.Classes.YearBuiltPredictionPipelineOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).yearBuiltPredictionPipelineOptions'></a>

`yearBuiltPredictionPipelineOptions` [DiGi\.GIS\.YOLO\.UI\.Classes\.YearBuiltPredictionPipelineOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.classes.yearbuiltpredictionpipelineoptions 'DiGi\.GIS\.YOLO\.UI\.Classes\.YearBuiltPredictionPipelineOptions')

The options the controls are filled from\. When null the defaults are used\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.YearBuiltPredictionsOptionsWindow.YearBuiltPredictionsOptionsWindow(DiGi.GIS.YOLO.UI.Classes.YearBuiltPredictionPipelineOptions,System.Collections.Generic.IEnumerable_DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DReference_).administrativeAreal2DReferences'></a>

`administrativeAreal2DReferences` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dreference 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReference')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The counties to choose from\. A county whose territory is in several pieces is one entry per piece, each with its own identifier, and each has to be selectable on its own \- a run names every part of a county so that each written row is filed under the part its reference belongs to\.
### Properties

<a name='DiGi.GIS.PostgreSQL.UI.Windows.YearBuiltPredictionsOptionsWindow.YearBuiltPredictionPipelineOptions'></a>

## YearBuiltPredictionsOptionsWindow\.YearBuiltPredictionPipelineOptions Property

Gets the options the window holds\. They carry the values of the controls only once the dialog has been closed with OK; until then, and after a cancellation, they are the values it was opened with\.

```csharp
public DiGi.GIS.YOLO.UI.Classes.YearBuiltPredictionPipelineOptions YearBuiltPredictionPipelineOptions { get; }
```

#### Property Value
[DiGi\.GIS\.YOLO\.UI\.Classes\.YearBuiltPredictionPipelineOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.yolo.ui.classes.yearbuiltpredictionpipelineoptions 'DiGi\.GIS\.YOLO\.UI\.Classes\.YearBuiltPredictionPipelineOptions')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Windows.YearBuiltPredictionsOptionsWindow.InitializeComponent()'></a>

## YearBuiltPredictionsOptionsWindow\.InitializeComponent\(\) Method

InitializeComponent

```csharp
public void InitializeComponent();
```

Implements [InitializeComponent\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector.initializecomponent 'System\.Windows\.Markup\.IComponentConnector\.InitializeComponent')