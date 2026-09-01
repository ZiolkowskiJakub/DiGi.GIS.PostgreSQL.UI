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

<a name='DiGi.GIS.PostgreSQL.UI.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.Modify.ExportPredictionImagesAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,string,int,bool,System.Threading.CancellationToken)'></a>

## Modify\.ExportPredictionImagesAsync\(this GISWebAPIManager, int, string, int, bool, CancellationToken\) Method

Exports orthophoto prediction images from the database for a specified county to the designated output directory\.

Decodes binary payloads from [DiGi\.GIS\.Classes\.OrtoData\.Bytes](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.ortodata.bytes 'DiGi\.GIS\.Classes\.OrtoData\.Bytes') and re-encodes them as JPEG files named `{reference}_{year}.jpeg`.

```csharp
public static System.Threading.Tasks.Task<bool> ExportPredictionImagesAsync(this DiGi.GIS.WebAPI.Classes.GISWebAPIManager? gisWebAPIManager, int countyId, string? destinationDirectory, int maxConcurrentRequests=8, bool resume=true, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Modify.ExportPredictionImagesAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,string,int,bool,System.Threading.CancellationToken).gisWebAPIManager'></a>

`gisWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') instance used to communicate with the WebAPI\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.ExportPredictionImagesAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,string,int,bool,System.Threading.CancellationToken).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer identifier of the county partition to export images for\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.ExportPredictionImagesAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,string,int,bool,System.Threading.CancellationToken).destinationDirectory'></a>

`destinationDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The target directory path on disk where JPEG files will be saved\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.ExportPredictionImagesAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,string,int,bool,System.Threading.CancellationToken).maxConcurrentRequests'></a>

`maxConcurrentRequests` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of concurrent WebAPI requests allowed during image fetching\. Defaults to 8\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.ExportPredictionImagesAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,string,int,bool,System.Threading.CancellationToken).resume'></a>

`resume` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), skips downloading or re\-encoding images already present on disk\. Defaults to [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.ExportPredictionImagesAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,string,int,bool,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token to observe while performing the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task returning [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the export completed successfully; otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string)'></a>

## Modify\.UpdateBuildingDataYearBuiltPredictionsAsync\(this GISWebAPIManager, int, IEnumerable\<Building2DYearBuiltPredictions\>, int, PostOptions, string\) Method

Writes the year built detection features of a run into the stored building data through the Web API, for one explicitly identified county row\.

Where a county is stored as several polygon parts, call the [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') overload with every part instead - naming one part files the whole batch there whether or not the buildings belong to it.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateBuildingDataYearBuiltPredictionsAsync(this DiGi.GIS.WebAPI.Classes.GISWebAPIManager? gisWebAPIManager, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2DYearBuiltPredictions>? building2DYearBuiltPredictions, int batchSize=5000, DiGi.WebAPI.Classes.PostOptions? postOptions=null, string? key=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).gisWebAPIManager'></a>

`gisWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') instance used to communicate with the WebAPI\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The identifier of the county row the buildings belong to\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).building2DYearBuiltPredictions'></a>

`building2DYearBuiltPredictions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2dyearbuiltpredictions 'DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The detections to write, one instance per building\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of buildings sent in one request\. Defaults to 5000\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the POST request\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).key'></a>

`key` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional API authorization key\. Falls back to the key carried by [postOptions](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).postOptions 'DiGi\.GIS\.PostgreSQL\.UI\.Modify\.UpdateBuildingDataYearBuiltPredictionsAsync\(this DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager, int, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions\>, int, DiGi\.WebAPI\.Classes\.PostOptions, string\)\.postOptions') and then by the manager\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task returning [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') when every batch was accepted; otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Collections.Generic.IEnumerable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string)'></a>

## Modify\.UpdateBuildingDataYearBuiltPredictionsAsync\(this GISWebAPIManager, IEnumerable\<int\>, IEnumerable\<Building2DYearBuiltPredictions\>, int, PostOptions, string\) Method

Writes the year built detection features of a run into the stored building data through the Web API\.

The detections are turned into building data rows by [DiGi\.GIS\.IO\.Modify\.Update\_Building2D\_YearBuiltPredictions\(DiGi\.Core\.IO\.Table\.Classes\.Table,System\.Int32,System\.Collections\.Generic\.IEnumerable\{DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions\}\)](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.io.modify.update_building2d_yearbuiltpredictions#digi-gis-io-modify-update_building2d_yearbuiltpredictions(digi-core-io-table-classes-table-system-int32-system-collections-generic-ienumerable{digi-gis-classes-building2dyearbuiltpredictions}) 'DiGi\.GIS\.IO\.Modify\.Update\_Building2D\_YearBuiltPredictions\(DiGi\.Core\.IO\.Table\.Classes\.Table,System\.Int32,System\.Collections\.Generic\.IEnumerable\{DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions\}\)') and posted to the building data update endpoint. Only the reference, the county and the detection columns travel, and the endpoint upserts on the columns it is given, so the rest of a building's row is left as it stands.

This is where the detections are written from. The database side cannot do it: nothing in PostgreSQL stores a [DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2dyearbuiltpredictions 'DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions'), so the run that produced them is the only thing that holds them (ZiolkowskiJakub/DiGi.GIS.PostgreSQL#57).

A county is tens of thousands of buildings against ninety-odd detection columns, so the predictions are sent in batches rather than as one request.

```csharp
public static System.Threading.Tasks.Task<bool> UpdateBuildingDataYearBuiltPredictionsAsync(this DiGi.GIS.WebAPI.Classes.GISWebAPIManager? gisWebAPIManager, System.Collections.Generic.IEnumerable<int>? countyIds, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2DYearBuiltPredictions>? building2DYearBuiltPredictions, int batchSize=5000, DiGi.WebAPI.Classes.PostOptions? postOptions=null, string? key=null);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Collections.Generic.IEnumerable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).gisWebAPIManager'></a>

`gisWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') instance used to communicate with the WebAPI\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Collections.Generic.IEnumerable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).countyIds'></a>

`countyIds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The identifiers of the county rows the buildings belong to\. Normally every polygon part of one county \- the endpoint files each row under the part its reference belongs to\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Collections.Generic.IEnumerable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).building2DYearBuiltPredictions'></a>

`building2DYearBuiltPredictions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2dyearbuiltpredictions 'DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The detections to write, one instance per building\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Collections.Generic.IEnumerable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of buildings sent in one request\. Defaults to 5000\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Collections.Generic.IEnumerable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the POST request\.

<a name='DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Collections.Generic.IEnumerable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).key'></a>

`key` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional API authorization key\. Falls back to the key carried by [postOptions](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Modify.UpdateBuildingDataYearBuiltPredictionsAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,System.Collections.Generic.IEnumerable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,int,DiGi.WebAPI.Classes.PostOptions,string).postOptions 'DiGi\.GIS\.PostgreSQL\.UI\.Modify\.UpdateBuildingDataYearBuiltPredictionsAsync\(this DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager, System\.Collections\.Generic\.IEnumerable\<int\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions\>, int, DiGi\.WebAPI\.Classes\.PostOptions, string\)\.postOptions') and then by the manager\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task returning [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') when every batch was accepted; otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.