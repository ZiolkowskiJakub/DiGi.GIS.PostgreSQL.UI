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