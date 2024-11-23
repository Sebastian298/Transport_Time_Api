using Dapper;
using System.Data;
using Transport_Time.Data;
using Transport_Time.Models;

namespace Transport_Time.Services
{
    public class DapperService : IDapperService
    {
        private readonly DapperContext _dapperContext;

        public DapperService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<DapperServiceResponse> ExecuteQueryAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (IDbConnection connection = _dapperContext.CreateConnection())
                {
                    var results = await connection.QueryAsync<T>(query, parameters);
                    return new DapperServiceResponse
                    {
                        HasError = false,
                        Results = results
                    };
                }
            }
            catch (Exception ex)
            {
                return new DapperServiceResponse
                {
                    HasError = true,
                    InnerException = ex.Message
                };

            }
        }

        public async Task<DapperServiceResponse> ExecuteStoredProcedureAsync<T>(string storedProcedureName, DynamicParameters? parameters = null, bool hasArray = false)
        {
            try
            {
                using (IDbConnection connection = _dapperContext.CreateConnection())
                {
                    dynamic? response = hasArray
                        ? await connection.QueryAsync<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure)
                        : await connection.QuerySingleOrDefaultAsync<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                    return new DapperServiceResponse
                    {
                        HasError = false,
                        Results = response
                    };
                }
            }
            catch (Exception ex)
            {
                return new DapperServiceResponse
                {
                    HasError = true,
                    InnerException = ex.Message
                };
            }
        }
    }
}
