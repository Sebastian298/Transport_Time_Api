using Transport_Time.Models;

namespace Transport_Time.Repositories
{
    public interface ITransportRepository
    {
        Task<GenericResponse<IEnumerable<ModelToDropdown>>> GetUnnasignedTrucks();
        Task<GenericResponse<IEnumerable<ModelToDropdown>>> GetUnnasignedRoutes();
        Task<GenericResponse<CrudResponse>> AssignRuteToTruckAsync(InsertBusRute insertBusRute);
        Task<GenericResponse<IEnumerable<ModelToDropdown>>> GetAssignedRoutesAsync();
    }
}
