using pinpoint_app.Services;
using pinpoint_app.Interfaces;

namespace pinpoint_app.ViewModel;

public partial class EventsViewModel : BaseEventViewModel
{
    public ObservableCollection<Event> Events { get; } = new(); // notifies the UI when items are added or removed; updates Events automatically.

     //

    IEventService eventService; // Service to get events from the API
    IConnectivity connectivity; // Connectivity service to check network status
    IGeolocation geolocation; // Geolocation service to get the user's location

    public EventsViewModel(IEventService eventService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Event Finder";
        this.eventService = eventService; // binds the event service
        this.connectivity = connectivity; // binds the connectivity service
        this.geolocation = geolocation; // binds the geolocation service
    }

    [RelayCommand]
    async Task GoToDetails(Event eventItem)
    {
        if (eventItem == null)
            return; // If the event item is null, do nothing
        await Shell.Current.GoToAsync(nameof(EventDetailsPage), true, new Dictionary<string, object>
        {
            {"Event", eventItem } // Passes the event item to the EventDetailsPage
        });
    }

    [RelayCommand]
    async Task GetEventsAsync()
    {
        try 
        { 
            if (IsBusy) // Prevents duplicate calls if IsBusy is true
            return;

            IsBusy = true;
            var events = await eventService.GetEventsAsync(); // Gets events from the service
            if (Events.Count != 0)
                Events.Clear(); // Clears the existing list before adding new events
            foreach (var eventItem in events)
                Events.Add(eventItem);
        }
        catch (Exception ex) // catches exceptions and logs them to the debug console
        {
            Debug.WriteLine($"Unable to get events: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false; // Sets IsBusy to false after the operation is complete
        }
    }

   [RelayCommand]
    async Task GoToMap()
    // Navigates to the MapPage to display closest events
    {
        await Shell.Current.GoToAsync("mapPage");
    }
}
