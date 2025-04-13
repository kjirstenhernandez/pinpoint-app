
namespace pinpoint_app.Interfaces;

   public interface ILocationService
    {
        Task<Location?> GetCurrentLocationAsync();
    }

