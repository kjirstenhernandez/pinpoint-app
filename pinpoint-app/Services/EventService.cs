using System.Net.Http.Json;


namespace pinpoint_app.Services;

public class EventService : Interfaces.IEventService
{
    // Create and initialize a new HTTP client
    HttpClient httpClient;

    public EventService()

    {
        this.httpClient = new HttpClient();
    }

    // Create a blank list of events and use the GetEvents method to populate it
    List<Event> eventList = new();
    public async Task<List<Event>> GetEventsAsync()
    // Sends a request to the PinPoint API to gather Event Info for display
    {
        if (eventList.Count > 0)
            return eventList;
     
        var response = await httpClient.GetAsync("https://67e8a30d20e3af747c41a7f7.mockapi.io/api/events"); // I plan on swapping out the URL for this mock API for my own once I fix my Azure deployment

        if (response.IsSuccessStatusCode)
        {
            eventList = await response.Content.ReadFromJsonAsync<List<Event>>();
        }
        return eventList;
    }
}