using System.Data;
using System.Data.SqlClient;
using GeneticDrill.WebApi.Helpers.Configurations;
using Microsoft.Extensions.Options;

namespace GeneticDrill.WebApi.Helpers;

public class DapperContext(IOptions<DapperConfiguration> dapperConfiguration)
{
    private readonly string _connectionString = dapperConfiguration.Value.ConnectionString;

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}