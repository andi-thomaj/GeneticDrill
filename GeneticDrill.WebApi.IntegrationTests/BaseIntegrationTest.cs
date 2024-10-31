using GeneticDrill.WebApi.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GeneticDrill.WebApi.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    protected readonly IUserService _userService;
    public BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();

        _userService = _scope.ServiceProvider.GetRequiredService<IUserService>();
        
    }
}