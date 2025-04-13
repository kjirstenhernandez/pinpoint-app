
namespace pinpoint_app.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync();
    }
}
