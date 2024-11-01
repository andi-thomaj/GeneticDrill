using GeneticDrill.WebApi.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace GeneticDrill.WebApi.IntegrationTests;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("development_genetic_drill")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var dapperContextDescriptor = services
                .SingleOrDefault(x => x.ServiceType == typeof(DapperContext));
            
            if (dapperContextDescriptor is not null)
            {
                services.Remove(dapperContextDescriptor);
            }

            services.AddSingleton(new DapperContext(_dbContainer.GetConnectionString()));
        });
    }

    public Task InitializeAsync() => _dbContainer.StartAsync();

    public new Task DisposeAsync() => _dbContainer.StopAsync();
}