using Transport_Time.Models;

namespace Transport_Time.Repositories
{
    public interface ITransportRepository
    {
        Task<GenericResponse<IEnumerable<ModelToDropdown>>> GetUnnasignedTrucks();
        Task<GenericResponse<IEnumerable<ModelToDropdown>>> GetUnnasignedRoutes();
        Task<GenericResponse<CrudResponse>> AssignRuteToTruckAsync(InsertBusRute insertBusRute);
        Task<GenericResponse<IEnumerable<ModelToDropdown>>> GetAssignedRoutesAsync();
        Task<GenericResponse<DetailInfoRoute>> GetDetailRouteByRouteId(string routeId);
        Task<GenericResponse<CrudResponse>> RemoveTruckFromRouteAsync(string busId,string routeId);
        Task<GenericResponse<RoutingInfo>> GetInfoForCurrentRouteAsync(string originCoordinates);
        Task<GenericResponse<CrudResponse>> CreateUserAsync(InsertUser insertUser);
        Task<GenericResponse<LogInUser>> GetLogInUsersAsync(InsertUser insertUser);
        Task<GenericResponse<IEnumerable<RoutesWithCoordinate>>> GetRoutesWithCoordinates();
    }
}
