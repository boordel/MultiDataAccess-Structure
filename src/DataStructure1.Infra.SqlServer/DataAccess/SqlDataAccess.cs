using Dapper;
using DataStructure1.Infra.DataAccess;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataStructure1.Infra.SqlServer.DataAccess;

public class SqlDataAccess : IDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure,
                                                     U parameters,
                                                     string connectionId = "DefaultCnn")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure,
                                  T parameters,
                                  DataChangeType changeType = DataChangeType.Command,
                                  string connectionId = "DefaultCnn")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
