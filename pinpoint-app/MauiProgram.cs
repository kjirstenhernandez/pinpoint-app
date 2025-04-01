using Microsoft.Extensions.Logging;
using pinpoint_app.View;
using pinpoint_app.Services;

namespace pinpoint_app;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<EventsViewModel>();
        builder.Services.AddSingleton<EventService>();
        builder.Services.AddTransient<EventDetailsViewModel>();
        builder.Services.AddTransient<EventDetailsPage>();

        return builder.Build();
    }
}
