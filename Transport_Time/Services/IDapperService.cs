using Dapper;
using Transport_Time.Models;

namespace Transport_Time.Services
{
    public interface IDapperService
    {
        Task<DapperServiceResponse> ExecuteQueryAsync<T>(string query, DynamicParameters? parameters = null);
        Task<DapperServiceResponse> ExecuteStoredProcedureAsync<T>(string storedProcedureName, DynamicParameters? parameters = null, bool hasArray = false);
    }
}
