using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Common.Infrastructure.Services;

public delegate Task<dynamic> DatabaseOperation<T>(SqlCommand command) where T : class;
public partial class DbAccessProvider(IConfiguration configuration) : IDbAccessProvider
{
    public async Task<ResponseDto<List<T>>?> GetEntityResults<T>(string procedure, params SqlParameter[]? parameters)
    {
        DatabaseOperation<List<T>> operation = async cmd => await GetResultsInJsonStringAsync(cmd);
        return await ExecuteDatabaseOperationAsync(operation, procedure, parameters);
    }
}
