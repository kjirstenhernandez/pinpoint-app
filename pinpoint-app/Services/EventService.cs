using System.Net.Http.Json;


namespace pinpoint_app.Services;

public class EventService
{
    List<Event> eventList = new();
    HttpClient httpClient;

    public EventService()
    // Initializes a new http client 
    {
        this.httpClient = new HttpClient();
    }
    public async Task<List<Event>> GetEvents()
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