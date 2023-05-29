using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog;

namespace SerilogWithMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        SetupSerilog();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


        builder.Logging.AddSerilog(dispose: true);
        
        return builder.Build();
    }

    private static void SetupSerilog()
    {
        var flushInterval = new TimeSpan(0, 0, 1);
        //var file = Path.Combine(FileSystem.AppDataDirectory, "MyApp.log");
        //var file = Path.Combine(@"\\Monalik-VD2\Users\monalik\Documents\SiriLogs\SiriLogsFile.log");
        var file = Path.Combine(@"\\vivekpaw\seriallog\VivekSiriLogsFile.log");

        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.File(file, flushToDiskInterval: flushInterval, encoding: System.Text.Encoding.UTF8, rollingInterval: RollingInterval.Minute, retainedFileCountLimit:22,fileSizeLimitBytes:512)
        .CreateLogger();
    }

   
}
