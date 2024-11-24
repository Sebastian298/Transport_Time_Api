using Dapper;
using Transport_Time.Models;
using Transport_Time.Services;

namespace Transport_Time.Repositories
{
    public class TransportRepository : ITransportRepository
    {
        private readonly IDapperService _dapperService;

        public TransportRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
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


    }
}
