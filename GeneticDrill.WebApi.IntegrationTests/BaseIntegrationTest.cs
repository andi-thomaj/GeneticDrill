using Microsoft.Extensions.DependencyInjection;

namespace GeneticDrill.WebApi.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    protected readonly IntegrationTestWebApplicationFactory _factory;
    public BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        _factory = factory;
        _scope = _factory.s
    }
}