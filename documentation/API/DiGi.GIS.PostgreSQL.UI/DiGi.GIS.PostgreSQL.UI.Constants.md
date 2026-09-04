#### [DiGi\.GIS\.PostgreSQL\.UI](DiGi.GIS.PostgreSQL.UI.Overview.md 'DiGi\.GIS\.PostgreSQL\.UI\.Overview')

## DiGi\.GIS\.PostgreSQL\.UI\.Constants Namespace
### Classes

<a name='DiGi.GIS.PostgreSQL.UI.Constants.Count'></a>

## Count Class

Provides constant counts and limits observed by the GIS PostgreSQL UI\.

```csharp
public static class Count
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Count
### Fields

<a name='DiGi.GIS.PostgreSQL.UI.Constants.Count.BuildingDataReference_Maximum'></a>

## Count\.BuildingDataReference\_Maximum Field

Gets the largest number of references the building data table endpoint accepts in one request\.

Mirrors the cap the endpoint enforces. A county is thirty to a hundred and fifty thousand buildings, so a feature read is always paged; asking for more than this fails the whole request rather than merely being slower.

```csharp
public const int BuildingDataReference_Maximum = 10000;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.PostgreSQL.UI.Constants.DirectoryName'></a>

## DirectoryName Class

Provides constant directory names used within the GIS PostgreSQL UI\.

```csharp
public static class DirectoryName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DirectoryName
### Fields

<a name='DiGi.GIS.PostgreSQL.UI.Constants.DirectoryName.Extensions'></a>

## DirectoryName\.Extensions Field

Gets the name of the folder beside this application's executable that standalone tools are deployed into\.

```csharp
public const string Extensions = "extensions";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

### Remarks
Not the same convention as `DiGi.WebAPI.WindowsService`'s `extensions` folder, which holds plugin assemblies loaded into the host process through an `AssemblyLoadContext`\. Nothing under this one is loaded into this application at all \- each subfolder is a self contained executable started as its own process, with its own dependency closure and its own configuration files\.

<a name='DiGi.GIS.PostgreSQL.UI.Constants.DirectoryName.PredictionImages'></a>

## DirectoryName\.PredictionImages Field

Gets the name of the folder a county's exported orthophoto prediction images are written to\.

```csharp
public const string PredictionImages = "images";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Constants.DirectoryName.YearBuiltPredictionExtension'></a>

## DirectoryName\.YearBuiltPredictionExtension Field

Gets the name of the folder under [Extensions](DiGi.GIS.PostgreSQL.UI.Constants.md#DiGi.GIS.PostgreSQL.UI.Constants.DirectoryName.Extensions 'DiGi\.GIS\.PostgreSQL\.UI\.Constants\.DirectoryName\.Extensions') that the headless Year Built prediction runner is deployed into\.

```csharp
public const string YearBuiltPredictionExtension = "DiGi.GIS.YOLO.UI.ConsoleApp";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

### Remarks
Assembled by `DiGi.Maintenance/Scripts/SyncDirectories.ps1` when `IncludeYearBuiltPredictionExtension` is set, into this application's own build output, so that the deployment carries it as part of this application rather than as a folder of its own\. A machine that will never score a building is deployed without it and simply does not offer the task\.

<a name='DiGi.GIS.PostgreSQL.UI.Constants.FileName'></a>

## FileName Class

Provides constant values for configuration file names used within the GIS PostgreSQL UI\.

```csharp
public static class FileName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FileName
### Fields

<a name='DiGi.GIS.PostgreSQL.UI.Constants.FileName.GISWebAPIClientConfigurationFile'></a>

## FileName\.GISWebAPIClientConfigurationFile Field

Gets the default filename of the configuration file for the Web API client\.

```csharp
public const string GISWebAPIClientConfigurationFile = "GIS_WebAPI_Client.conf";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.PostgreSQL.UI.Constants.FileName.YearBuiltPredictionConsoleApp'></a>

## FileName\.YearBuiltPredictionConsoleApp Field

Gets the file name of the headless Year Built prediction runner\.

```csharp
public const string YearBuiltPredictionConsoleApp = "DiGi.GIS.YOLO.UI.ConsoleApp.exe";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

### Remarks
The pipeline itself is not hosted in this application \- it carries the machine learning closure, which is about a gigabyte of native libraries against an application that publishes self\-contained and single\-file\. The run is handed to this executable instead, and [YearBuiltPredictionConsoleAppPath\(string, string\)](DiGi.GIS.PostgreSQL.UI.md#DiGi.GIS.PostgreSQL.UI.Query.YearBuiltPredictionConsoleAppPath(string,string) 'DiGi\.GIS\.PostgreSQL\.UI\.Query\.YearBuiltPredictionConsoleAppPath\(string, string\)') is what finds it\.

<a name='DiGi.GIS.PostgreSQL.UI.Constants.Names'></a>

## Names Class

Provides constant key names for configuration file settings within the GIS PostgreSQL UI\.

```csharp
public static class Names
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Names

<a name='DiGi.GIS.PostgreSQL.UI.Constants.Names.GISPostgreSQLConverterManagerConfigurationFile'></a>

## Names\.GISPostgreSQLConverterManagerConfigurationFile Class

Provides constant key names for [GISPostgreSQLConverterManagerConfigurationFile](DiGi.GIS.PostgreSQL.UI.Classes.md#DiGi.GIS.PostgreSQL.UI.Classes.GISPostgreSQLConverterManagerConfigurationFile 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.GISPostgreSQLConverterManagerConfigurationFile') settings\.

```csharp
public static class Names.GISPostgreSQLConverterManagerConfigurationFile
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → GISPostgreSQLConverterManagerConfigurationFile
### Fields

<a name='DiGi.GIS.PostgreSQL.UI.Constants.Names.GISPostgreSQLConverterManagerConfigurationFile.Key'></a>

## Names\.GISPostgreSQLConverterManagerConfigurationFile\.Key Field

Gets the configuration key name for the API authorization key\.

```csharp
public const string Key = "Key";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')