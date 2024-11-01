using AutoBogus;
using GeneticDrill.WebApi.Services.Implementations;

namespace GeneticDrill.WebApi.IntegrationTests.User;

public class UsersWebApiTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task GetByEmail_ShouldReturnUser_WhenUserExists()
    {
        var user = new AutoFaker<DataAccess.Entities.User>()
            .RuleFor(f => f.email, f => f.Internet.Email())
            .Generate();

        var result = await _userService.GetUserByEmailAsync("andi.dev94@gmail.com");
    }
}