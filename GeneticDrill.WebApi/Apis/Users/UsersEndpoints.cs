using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Core.Services.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GeneticDrill.WebApi.Apis.Users;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder builder)
    {
        var routeGroupBuilder = builder.MapGroup("api/users");

        routeGroupBuilder.MapGet("{email}", GetUserByEmail);

        return builder;
    }

    private static async Task<Results<Ok<GetUserByEmailResponse>, NotFound>> GetUserByEmail(string email,
        IUserService userService)
    {
        var result = await userService.GetUserByEmailAsync(email);

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound();
    }
}