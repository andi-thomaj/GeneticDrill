using Microsoft.AspNetCore.Authentication;
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
        .WithDatabase("modelgen")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // var descriptor = services
            //     .SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<ModelGenDbContext>));

            // if (descriptor is not null)
            // {
            //     services.Remove(descriptor);
            // }

            // services.AddDbContext<ModelGenDbContext>(options => options
            //     .UseNpgsql(_dbContainer.GetConnectionString()));

            // services.AddAuthentication(defaultScheme: "TestScheme")
            //     .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
            //         "TestScheme", options => { });
        });
    }
    public Task InitializeAsync()
    {
        throw new NotImplementedException();
    }

    public Task DisposeAsync()
    {
        throw new NotImplementedException();
    }
}