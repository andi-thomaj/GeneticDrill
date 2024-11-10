using System.Data;
using Npgsql;

namespace GeneticDrill.WebApi.Services;

public class DapperContext(string connectionString)
{
    public IDbConnection CreateConnection() => new NpgsqlConnection(connectionString);
}