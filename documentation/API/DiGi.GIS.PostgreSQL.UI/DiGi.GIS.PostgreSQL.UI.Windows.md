#### [DiGi\.GIS\.PostgreSQL\.UI](DiGi.GIS.PostgreSQL.UI.Overview.md 'DiGi\.GIS\.PostgreSQL\.UI\.Overview')

## DiGi\.GIS\.PostgreSQL\.UI\.Windows Namespace
### Classes

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow'></a>

## MainWindow Class

MainWindow

```csharp
public class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.DependencyObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dependencyobject 'System\.Windows\.DependencyObject') → [System\.Windows\.Media\.Visual](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visual 'System\.Windows\.Media\.Visual') → [System\.Windows\.UIElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.uielement 'System\.Windows\.UIElement') → [System\.Windows\.FrameworkElement](https://learn.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement 'System\.Windows\.FrameworkElement') → [System\.Windows\.Controls\.Control](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.control 'System\.Windows\.Controls\.Control') → [System\.Windows\.Controls\.ContentControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol 'System\.Windows\.Controls\.ContentControl') → [System\.Windows\.Window](https://learn.microsoft.com/en-us/dotnet/api/system.windows.window 'System\.Windows\.Window') → MainWindow

Implements [System\.Windows\.Markup\.IComponentConnector](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.icomponentconnector 'System\.Windows\.Markup\.IComponentConnector')
### Constructors

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Nullable_DiGi.GIS.PostgreSQL.UI.Enums.Mode_)'></a>

## MainWindow\(GISPostgreSQLConverterManager, GISWebAPIManager, Nullable\<Mode\>\) Constructor

Initializes a new instance of the [MainWindow](DiGi.GIS.PostgreSQL.UI.Windows.md#DiGi.GIS.PostgreSQL.UI.Windows.MainWindow 'DiGi\.GIS\.PostgreSQL\.UI\.Windows\.MainWindow') class\.

```csharp
public MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager? gISPostgreSQLConverterManager, DiGi.GIS.WebAPI.Classes.GISWebAPIManager? GISWebAPIManager, System.Nullable<DiGi.GIS.PostgreSQL.UI.Enums.Mode> mode=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Nullable_DiGi.GIS.PostgreSQL.UI.Enums.Mode_).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The manager responsible for GIS PostgreSQL conversion processes\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Nullable_DiGi.GIS.PostgreSQL.UI.Enums.Mode_).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager responsible for GIS PostgreSQL Web API interactions\.

<a name='DiGi.GIS.PostgreSQL.UI.Windows.MainWindow.MainWindow(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Nullable_DiGi.GIS.PostgreSQL.UI.Enums.Mode_).mode'></a>

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