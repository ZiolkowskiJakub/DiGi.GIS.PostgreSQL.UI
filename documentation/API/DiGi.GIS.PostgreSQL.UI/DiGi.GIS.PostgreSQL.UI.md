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

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode)'></a>

## Create\.VisualBackgroundTasks\(GISPostgreSQLConverterManager, GISWebAPIManager, Mode\) Method

Creates and returns a sorted list of visual background tasks based on the specified operation mode and available managers\.

```csharp
public static System.Collections.Generic.List<DiGi.UI.WPF.Interfaces.IVisualBackgroundTask>? VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager? gISPostgreSQLConverterManager, DiGi.GIS.WebAPI.Classes.GISWebAPIManager? GISWebAPIManager, DiGi.GIS.PostgreSQL.UI.Enums.Mode mode);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The manager responsible for PostgreSQL conversion operations\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode).GISWebAPIManager'></a>

`GISWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager responsible for interacting with the PostgreSQL Web API\.

<a name='DiGi.GIS.PostgreSQL.UI.Create.VisualBackgroundTasks(DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager,DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.UI.Enums.Mode).mode'></a>

`mode` [Mode](DiGi.GIS.PostgreSQL.UI.Enums.md#DiGi.GIS.PostgreSQL.UI.Enums.Mode 'DiGi\.GIS\.PostgreSQL\.UI\.Enums\.Mode')

The operation mode \(Server, Client, or both\) that determines which tasks are instantiated\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.wpf.interfaces.ivisualbackgroundtask 'DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.ui.wpf.interfaces.ivisualbackgroundtask 'DiGi\.UI\.WPF\.Interfaces\.IVisualBackgroundTask') objects sorted by name, or null if not applicable\.