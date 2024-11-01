using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Services.Abstractions;
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
        IUserService userService, CancellationToken cancellationToken)
    {
        var result = await userService.GetUserByEmailAsync(email, cancellationToken);

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound();
    }
}