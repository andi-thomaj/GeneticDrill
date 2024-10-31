using GeneticDrill.WebApi.Helpers;
using GeneticDrill.WebApi.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GeneticDrill.WebApi.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    protected readonly IUserService _userService;
    protected readonly DapperContext _dapperContext;

    public BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();

        _userService = _scope.ServiceProvider.GetRequiredService<IUserService>();
        _dapperContext = _scope.ServiceProvider.GetRequiredService<DapperContext>();
    }
}