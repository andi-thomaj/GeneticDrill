using System.Data;
using Npgsql;

namespace GeneticDrill.WebApi.Helpers;

public class DapperContext(string connectionString)
{
    public IDbConnection CreateConnection() => new NpgsqlConnection(connectionString);
}