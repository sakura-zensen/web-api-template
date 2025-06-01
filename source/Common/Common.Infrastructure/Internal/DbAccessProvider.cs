using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text;
using System.Text.Json;

namespace Common.Infrastructure.Services;

public partial class DbAccessProvider
{
    private string? GetConnectionString() => configuration.GetConnectionString("connection-string-property");
    private static SqlCommand CreateCommand(string storedProcedure, SqlConnection connection, params SqlParameter[]? parameters)
    {
        SqlCommand command = new(storedProcedure, connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        if (parameters is not null || parameters?.Length > 0)
        {
            command.Parameters.AddRange(parameters);
        }
        return command;
    }
    private async Task<ResponseDto<T>> ExecuteDatabaseOperationAsync<T>(DatabaseOperation<T> executeQuery, string storedProcedure, params SqlParameter[]? parameters) where T : class
    {
        using SqlConnection con = new(GetConnectionString());
        await con.OpenAsync();
        try
        {
            using SqlCommand cmd = CreateCommand(storedProcedure, con, parameters);
            dynamic data = await executeQuery(cmd);

            return new() { Succeeded = true, ResponseMessage = "successful", Data = JsonSerializer.Deserialize<T>(data ?? "[]") };
        }
        catch (Exception ex)
        {
            return new() { Succeeded = false, ResponseMessage = ex.Message };
        }
    }
    private static async Task<string> GetResultsInJsonStringAsync(SqlCommand command)
    {
        using var reader = await command.ExecuteReaderAsync();
        var result = new StringBuilder();
        do
        {
            while (await reader.ReadAsync())
            {
                result.Append(reader.GetString(0));
            }
        } while (await reader.NextResultAsync());
        return result.Length > 0 ? result.ToString() : "[]";
    }
}
public record ResponseDto<T>
{
    public bool Succeeded { get; set; }
    public string? ResponseMessage { get; set; }
    public T? Data { get; set; }
}
