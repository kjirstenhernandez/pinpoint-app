using Microsoft.Extensions.Logging;
using pinpoint_app.View;
using pinpoint_app.Services;
using pinpoint_app.Interfaces;
using CommunityToolkit.Maui;

namespace pinpoint_app;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
        .UseMauiMaps().ConfigureFonts(fonts =>
        {
            fonts.AddFont("NationalPark-Light.ttf", "NationalParkLight");
            fonts.AddFont("NationalPark-Medium.ttf", "NationalParkMedium");
            fonts.AddFont("NationalPark-Regular.ttf", "NationalParkRegular");
            fonts.AddFont("NationalPark-SemiBold.ttf", "NationalParkSemiBold");
            fonts.AddFont("NationalPark-Bold.ttf", "NationalParkBold");
        }).UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<IEventService, EventService>();
        builder.Services.AddSingleton<IConnectivityService, ConnectivityService>();
        builder.Services.AddSingleton<ILocationService, LocationService>();
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddTransient<EventsViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<EventDetailsViewModel>();
        builder.Services.AddTransient<EventDetailsPage>();
        builder.Services.AddTransient<MapViewModel>();
        builder.Services.AddTransient<MapPage>();
        builder.Services.AddSingleton<DateTimeConversionService>();
        return builder.Build();
    }
}