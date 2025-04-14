using Microsoft.Maui.Devices.Sensors;

namespace pinpoint_app.ViewModel;

[QueryProperty(nameof(EventItem ), "Event")]
public partial class EventDetailsViewModel : BaseEventViewModel // for shell navigation, passes an event object
{

    [ObservableProperty]
    Event eventItem;
    // Sets the event item to the event passed in.

    [RelayCommand]
    async Task OpenMap()
    // Opens the user's detault maps app with directions to the event's location
    {
        var location = new Location(EventItem.lat, EventItem.lon); // creates a new location object with the event's latitude and longitude
        var options = new MapLaunchOptions { Name = EventItem.title, NavigationMode = NavigationMode.Driving }; // sets the name of the location to the event's title and navigation via car

        try
        {
            // opens the user's default maps app with directions to the event's location
            await Map.Default.OpenAsync(location, options); // Corrected to use Map.Default.OpenAsync
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to launch maps: {ex.Message}");
            await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
        }
    }
}