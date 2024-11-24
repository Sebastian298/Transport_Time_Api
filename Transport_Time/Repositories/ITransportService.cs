using Transport_Time.Models;

namespace Transport_Time.Repositories
{
    public interface ITransportService
    {
        Task<IEnumerable<ModelToDropdown>> GetUnnasignedTrucks();
        Task<IEnumerable<ModelToDropdown>> GetUnnasignedRoutes();
    }
}
