namespace pinpoint_app.Services;

public class LocationService : Interfaces.ILocationService
{
    IGeolocation geolocation; // Geolocation service to get the user's location

    public LocationService(IGeolocation geolocation)
    {
        this.geolocation = geolocation;
    }

    public async Task<Location> GetCurrentLocationAsync()
    {
        var userLocation = await geolocation.GetLocationAsync(new GeolocationRequest {
            DesiredAccuracy = GeolocationAccuracy.High,
            Timeout = TimeSpan.FromSeconds(20)
        });

        return userLocation;
    }
}

