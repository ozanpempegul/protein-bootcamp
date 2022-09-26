using System.Data;
using Dapper;
using Npgsql;

namespace DatabaseHomework.DbProvider;

public class DapperDbProvider : IDapperDbProvider
{
    private readonly string? _connectionString;
    
    public DapperDbProvider(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MyWebApiConnection");
    }
    
    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }

    public async Task ExecuteAsync(IDbConnection connection, string command, object? param = null)
    {
        await connection.ExecuteAsync(command, param);
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, string command, object? param = null)
    {
        return await connection.QueryFirstOrDefaultAsync<T>(command, param);
    }
        
    public async Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string command, object? param = null)
    {
        return await connection.QueryAsync<T>(command, param);
    }
}