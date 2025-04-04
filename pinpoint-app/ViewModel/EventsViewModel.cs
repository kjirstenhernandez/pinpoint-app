using pinpoint_app.Services;

namespace pinpoint_app.ViewModel;

public partial class EventsViewModel : BaseEventViewModel
{
	public ObservableCollection<Event> Events { get; } = new();  // notifies the UI when items are added or removed; updates Events automaticall.

	public Command GetEventsCommand { get; } // Command to load events when triggered
    EventService eventService; // Service to get events from the API
    public EventsViewModel(EventService eventService)
	{
        Title = "Event Finder";
        this.eventService = eventService;
        GetEventsCommand = new Command(async () => await GetEventsAsync());  //initializes GetEventsCommand and binds it to GetEventsAsync.
    }

    async Task GetEventsAsync()
    {
        if (IsBusy) // Prevents duplicate calls if IsBusy is true
            return;
        try
        {
            IsBusy = true; 
            var events = await eventService.GetEvents(); // Gets events from the service
            if (Events.Count != 0)
                Events.Clear(); // Clears the existing list before adding new events
            foreach (var eventItem in events)
                Events.Add(eventItem);

        }
        catch (Exception ex) // catches exceptions and logs them to the debug console
        {
            Debug.WriteLine($"Unable to get events: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        { IsBusy = false; } // Sets IsBusy to false after the operation is complete
    }
}