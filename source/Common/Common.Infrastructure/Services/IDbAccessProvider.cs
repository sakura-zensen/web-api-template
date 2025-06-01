using Microsoft.Data.SqlClient;

namespace Common.Infrastructure.Services;

public interface IDbAccessProvider
{
    Task<ResponseDto<List<T>>?> GetEntityResults<T>(string procedure, params SqlParameter[]? parameters);
}