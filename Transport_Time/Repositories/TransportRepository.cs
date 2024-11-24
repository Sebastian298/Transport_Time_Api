﻿using Transport_Time.Models;
using Transport_Time.Services;

namespace Transport_Time.Repositories
{
    public class TransportRepository : ITransportRepository
    {
        private readonly DapperService _dapperService;

        public TransportRepository(DapperService dapperService)
        {
            _dapperService = dapperService;
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