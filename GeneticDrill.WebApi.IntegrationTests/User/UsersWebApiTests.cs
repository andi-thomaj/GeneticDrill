using AutoBogus;
using GeneticDrill.WebApi.Services.Implementations;

namespace GeneticDrill.WebApi.IntegrationTests.User;

public class UsersWebApiTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task GetByEmail_ShouldReturnUser_WhenUserExists()
    {
        var user = AutoFaker.Generate<DataAccess.Entities.User>();

        var result = await _userService.GetUserByEmailAsync(user.Email);
    }
}