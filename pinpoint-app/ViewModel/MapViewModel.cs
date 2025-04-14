
using pinpoint_app.Services;
using pinpoint_app.Interfaces;
using System.Globalization;

namespace pinpoint_app.ViewModel;

public partial class MapViewModel : BaseEventViewModel
{
    public ObservableCollection<Event> ClosestEvents { get; } = new(); // notifies the UI when items are added or removed; updates Events automatically.

    IEventService eventService;
    IConnectivityService connectivityService;
    ILocationService locationService;

    public MapViewModel(IEventService eventService, IConnectivityService connectivityService, ILocationService locationService)
    {
        Title = "Closest Events";
        this.eventService = eventService;
        this.connectivityService = connectivityService;
        this.locationService = locationService;
    }

    [RelayCommand]
    public async Task GetClosestEvents()
    // This method is used to get the closest events to the user's location
    {
        if (!connectivityService.HasInternetAccess()) // Check if the device has internet access
        {
            await Shell.Current.DisplayAlert("No Internet","Please check your connection", "OK");
            return;
        }
        
        try
        {
            // For activity indicator
            if (IsBusy)
                return;

            // If it wasn't busy before, it will be now
            IsBusy = true;

            var events = await eventService.GetEventsAsync(); // populates the event list
            var userLocation = await locationService.GetCurrentLocationAsync(); // gets the user's location


            if (events == null || events.Count == 0) // If no events are found, display a message to the user
            {
                await Shell.Current.DisplayAlert("Error", "No events found.", "OK");
                return;
            }

            if (ClosestEvents.Count != 0)
                ClosestEvents.Clear(); //Clears existing list before adding new events

            // Orders the events by distance from the user's location and gets the first one
            var closest = events.OrderBy(m => userLocation.CalculateDistance(new Location(m.lat, m.lon), DistanceUnits.Miles)).Take(20);
            if (closest == null)
            {
                // if there are no Events, then display a message to the user
                await Shell.Current.DisplayAlert("No Events", "No events found near your location", "OK");
                return;
            }
            foreach (var closestItem in closest) // Adds the closest events to the list
            {
                ClosestEvents.Add(closestItem);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get events: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false; // Clear the activity indicator
        }
    }

    public async Task<(Location userLocation, double maxDistance)> GetLocationAndSpanData(){
        // This method is used to get the user's location and the maximum distance to the closest events
        // It returns a tuple containing the user's location and the maximum distance

        await GetClosestEvents();

        var userLocation = await locationService.GetCurrentLocationAsync();

        if (userLocation == null || ClosestEvents.Count == 0)  // if there is no user location or no events, then no map data is needed
        {
            return (null, 0);
        }

        var maxDistance = ClosestEvents.Max(ev => userLocation.CalculateDistance(new Location(ev.lat, ev.lon), DistanceUnits.Miles)); // extends the map to the furthest event

        return (userLocation, maxDistance);
    }
}
