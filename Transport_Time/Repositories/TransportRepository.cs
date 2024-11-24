using Dapper;
using Transport_Time.Models;
using Transport_Time.Services;

namespace Transport_Time.Repositories
{
    public class TransportRepository : ITransportRepository
    {
        private readonly IDapperService _dapperService;
        private readonly RoutingService _routingService;

        public TransportRepository(IDapperService dapperService,RoutingService routingService)
        {
            _dapperService = dapperService;
            _routingService = routingService;
        }

        public async Task<GenericResponse<CrudResponse>> AssignRuteToTruckAsync(InsertBusRute insertBusRute)
        {
            try
            {
                var storedProcedureName = "InsertBusRout";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@BusId", insertBusRute.BusId);
                dynamicParameters.Add("@RoutId", insertBusRute.RuteId);
                var dapperResponse = await _dapperService.ExecuteStoredProcedureAsync<CrudResponse>(
                    storedProcedureName, dynamicParameters
                );

                return new GenericResponse<CrudResponse>
                {
                    StatusCode = dapperResponse.HasError ? 500 : 200,
                    Content = dapperResponse.HasError ? null : dapperResponse.Results,
                    InnerException = dapperResponse.HasError ? dapperResponse.InnerException : null
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<CrudResponse>
                {
                    StatusCode = 500,
                    InnerException = ex.Message
                };
            }
        }

        public async Task<GenericResponse<IEnumerable<ModelToDropdown>>> GetAssignedRoutesAsync()
        {
            try
            {
                var storedProcedureName = "Routs_GetAssignedRouts";
                var dapperResponse = await _dapperService.ExecuteStoredProcedureAsync<ModelToDropdown>(
                    storedProcedureName,
                    hasArray: true
                );
                return new GenericResponse<IEnumerable<ModelToDropdown>>
                {
                    StatusCode = dapperResponse.HasError ? 500 : 200,
                    Content = dapperResponse.HasError ? null : dapperResponse.Results,
                    InnerException = dapperResponse.HasError ? dapperResponse.InnerException : null
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<IEnumerable<ModelToDropdown>>
                {
                    StatusCode = 500,
                    InnerException = ex.Message
                };
            }
        }

        public async Task<GenericResponse<DetailInfoRoute>> GetDetailRouteByRouteId(string routeId)
        {
            try
            {
                var storedProcedureName = "BussesRoutes_GetRoutAndAssginedTruck";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@RouteId", routeId);
                var dapperResponse = await _dapperService.ExecuteStoredProcedureAsync<DetailInfoRoute>(
                    storedProcedureName, dynamicParameters
                );
                return new GenericResponse<DetailInfoRoute>
                {
                    StatusCode = dapperResponse.HasError ? 500 : 200,
                    Content = dapperResponse.HasError ? null : dapperResponse.Results,
                    InnerException = dapperResponse.HasError ? dapperResponse.InnerException : null
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<DetailInfoRoute>
                {
                    StatusCode = 500,
                    InnerException = ex.Message
                };
            }
        }

        public async Task<GenericResponse<RoutingInfo>> GetInfoForCurrentRouteAsync(string originCoordinates)
        {
            try
            {
                var routingServiceResponse = await _routingService.CalculateRouteAsync(originCoordinates);
                if (routingServiceResponse.Success)
                {
                    var data = routingServiceResponse.Content;
                    var objRoutes = data!.Routes;
                    var objRoute = objRoutes[0];
                    return new GenericResponse<RoutingInfo>
                    {
                        StatusCode = 200,
                        Content = new RoutingInfo
                        {
                            Summary = objRoute.Summary,
                            Points = objRoute.Legs[0].Points
                        }
                    };
                }
                else
                {
                    return new GenericResponse<RoutingInfo>
                    {
                        StatusCode = 500,
                        InnerException = routingServiceResponse.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new GenericResponse<RoutingInfo>
                {
                    StatusCode = 500,
                    InnerException = ex.Message
                };
            }
        }

        public async Task<GenericResponse<IEnumerable<ModelToDropdown>>> GetUnnasignedRoutes()
        {
            try
            {
                var storedProcedureName = "Routs_GetUnnasignedRouts";

                var dapperResponse = await _dapperService.ExecuteStoredProcedureAsync<ModelToDropdown>(
                    storedProcedureName,
                    hasArray: true
                );

                return new GenericResponse<IEnumerable<ModelToDropdown>>
                {
                    StatusCode = dapperResponse.HasError ? 500 : 200,
                    Content = dapperResponse.HasError ? null : dapperResponse.Results,
                    InnerException = dapperResponse.HasError ? dapperResponse.InnerException : null
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<IEnumerable<ModelToDropdown>>
                {
                    StatusCode = 500,
                    InnerException = ex.Message
                };
            }
        }

        public async Task<GenericResponse<IEnumerable<ModelToDropdown>>> GetUnnasignedTrucks()
        {
            try
            {
                var storedProcedureName = "Busses_GetUnnasignedBusses";

                var dapperResponse = await _dapperService.ExecuteStoredProcedureAsync<ModelToDropdown>(
                    storedProcedureName,
                    hasArray: true
                );

                return new GenericResponse<IEnumerable<ModelToDropdown>>
                {
                    StatusCode = dapperResponse.HasError ? 500 : 200,
                    Content = dapperResponse.HasError ? null : dapperResponse.Results,
                    InnerException = dapperResponse.HasError ? dapperResponse.InnerException : null
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<IEnumerable<ModelToDropdown>>
                {
                    StatusCode = 500,
                    InnerException = ex.Message
                };
            }
        }

        public async Task<GenericResponse<CrudResponse>> RemoveTruckFromRouteAsync(string busId, string routeId)
        {
            try
            {
                var storedProcedureName = "RemoveBusFromRoute";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@BusId", busId);
                dynamicParameters.Add("@RouteId", routeId);
                var dapperResponse = await _dapperService.ExecuteStoredProcedureAsync<CrudResponse>(
                    storedProcedureName, dynamicParameters
                );
                return new GenericResponse<CrudResponse>
                {
                    StatusCode = dapperResponse.HasError ? 500 : 200,
                    Content = dapperResponse.HasError ? null : dapperResponse.Results,
                    InnerException = dapperResponse.HasError ? dapperResponse.InnerException : null
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<CrudResponse>
                {
                    StatusCode = 500,
                    InnerException = ex.Message
                };
            }
        }
    }
}
