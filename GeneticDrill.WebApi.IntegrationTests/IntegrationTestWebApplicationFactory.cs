using GeneticDrill.WebApi.Helpers;
using GeneticDrill.WebApi.Helpers.Configurations;
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
        .WithDatabase("development_genetic_drill")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // var descriptor = services
            //     .SingleOrDefault(x => x.ServiceType == typeof(DapperContext));
            //
            // if (descriptor is not null)
            // {
            //     services.Remove(descriptor);
            // }

            // services.AddDbContext<ModelGenDbContext>(options => options
            //     .UseNpgsql(_dbContainer.GetConnectionString()));

            // services.AddAuthentication(defaultScheme: "TestScheme")
            //     .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
            //         "TestScheme", options => { });
            
            // services.AddOptions<DapperConfiguration>()
            //     .Bind(configuration.GetSection(DapperConfiguration.SectionName))
            //     .ValidateDataAnnotations()
            //     .ValidateOnStart();
        });
    }
    public Task InitializeAsync() => _dbContainer.StartAsync();

    public new Task DisposeAsync() => _dbContainer.StopAsync();
}