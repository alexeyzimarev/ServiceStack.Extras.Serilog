# ServiceStack.Extras.Serilog

Provides Serilog logging adapter for ServiceStack 4 projects.

### Usage

```csharp
var logger = new LoggerConfiguration()
    .WriteTo.ColoredConsole()
    .MinimumLevel.Debug()
    .CreateLogger();

LogManager.LogFactory = new SerilogFactory(logger);
```

or just
```csharp
Log.Manager.LogFactory = new SerilogFactory();
```
to use the global Log.Logger instance.