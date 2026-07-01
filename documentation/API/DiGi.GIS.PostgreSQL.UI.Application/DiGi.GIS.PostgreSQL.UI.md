## DiGi\.GIS\.PostgreSQL\.UI Namespace
### Classes

<a name='DiGi.GIS.PostgreSQL.UI.App'></a>

## App Class

Interaction logic for App\.xaml

```csharp
public class App : System.Windows.Application
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Windows\.Threading\.DispatcherObject](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherobject 'System\.Windows\.Threading\.DispatcherObject') → [System\.Windows\.Application](https://learn.microsoft.com/en-us/dotnet/api/system.windows.application 'System\.Windows\.Application') → App
### Fields

<a name='DiGi.GIS.PostgreSQL.UI.App.gISPostgreSQLTrayApplicationContext'></a>

## App\.gISPostgreSQLTrayApplicationContext Field

The application context instance for the GIS PostgreSQL tray application\.

```csharp
private GISPostgreSQLTrayApplicationContext? gISPostgreSQLTrayApplicationContext;
```

#### Field Value
[DiGi\.GIS\.PostgreSQL\.UI\.Classes\.GISPostgreSQLTrayApplicationContext](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.ui.classes.gispostgresqltrayapplicationcontext 'DiGi\.GIS\.PostgreSQL\.UI\.Classes\.GISPostgreSQLTrayApplicationContext')
### Methods

<a name='DiGi.GIS.PostgreSQL.UI.App.App_DispatcherUnhandledException(object,System.Windows.Threading.DispatcherUnhandledExceptionEventArgs)'></a>

## App\.App\_DispatcherUnhandledException\(object, DispatcherUnhandledExceptionEventArgs\) Method

Handles unhandled exceptions that occur on the main UI dispatcher thread\.

```csharp
private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.App.App_DispatcherUnhandledException(object,System.Windows.Threading.DispatcherUnhandledExceptionEventArgs).sender'></a>

`sender` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The source of the event\.

<a name='DiGi.GIS.PostgreSQL.UI.App.App_DispatcherUnhandledException(object,System.Windows.Threading.DispatcherUnhandledExceptionEventArgs).e'></a>

`e` [System\.Windows\.Threading\.DispatcherUnhandledExceptionEventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.windows.threading.dispatcherunhandledexceptioneventargs 'System\.Windows\.Threading\.DispatcherUnhandledExceptionEventArgs')

The event arguments containing the exception details\.

<a name='DiGi.GIS.PostgreSQL.UI.App.CurrentDomain_UnhandledException(object,System.UnhandledExceptionEventArgs)'></a>

## App\.CurrentDomain\_UnhandledException\(object, UnhandledExceptionEventArgs\) Method

Handles unhandled exceptions that occur on non\-UI threads within the current application domain\.

```csharp
private void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.App.CurrentDomain_UnhandledException(object,System.UnhandledExceptionEventArgs).sender'></a>

`sender` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The source of the event\.

<a name='DiGi.GIS.PostgreSQL.UI.App.CurrentDomain_UnhandledException(object,System.UnhandledExceptionEventArgs).e'></a>

`e` [System\.UnhandledExceptionEventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.unhandledexceptioneventargs 'System\.UnhandledExceptionEventArgs')

The event arguments containing the exception details\.

<a name='DiGi.GIS.PostgreSQL.UI.App.Main()'></a>

## App\.Main\(\) Method

Application Entry Point\.

```csharp
public static void Main();
```

<a name='DiGi.GIS.PostgreSQL.UI.App.OnStartup(System.Windows.StartupEventArgs)'></a>

## App\.OnStartup\(StartupEventArgs\) Method

Overrides the OnStartup method to initialize application\-wide settings and exception handling\.

```csharp
protected override void OnStartup(System.Windows.StartupEventArgs e);
```
#### Parameters

<a name='DiGi.GIS.PostgreSQL.UI.App.OnStartup(System.Windows.StartupEventArgs).e'></a>

`e` [System\.Windows\.StartupEventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.windows.startupeventargs 'System\.Windows\.StartupEventArgs')

The event data for the startup event\.