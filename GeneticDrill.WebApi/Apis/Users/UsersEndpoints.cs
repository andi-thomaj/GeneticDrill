using GeneticDrill.WebApi.Apis.Users.Requests;
using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Apis.Users.Validations;
using GeneticDrill.WebApi.Services.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GeneticDrill.WebApi.Apis.Users;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder builder)
    {
        var routeGroupBuilder = builder.MapGroup("api/users");

        routeGroupBuilder.MapGet("{email}", GetUserByEmail);
        routeGroupBuilder.MapPost(string.Empty, CreateUser);

        return builder;
    }

    private static async Task<Results<Ok<GetUserByEmailResponse>, NotFound, BadRequest<List<FluentValidation.Results.ValidationFailure>>>> GetUserByEmail(string email,
        IUserService userService)
    {
        GetUserByEmailRequestValidator validator = new();
        var validationResult = await validator.ValidateAsync(new GetUserByEmailRequest(email));
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest(validationResult.Errors);
        }
        
        var result = await userService.GetUserByEmailAsync(email);

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound();
    }
    
    private static async Task<Results<Ok<CreateUserResponse>, NotFound, BadRequest<List<FluentValidation.Results.ValidationFailure>>>> CreateUser(CreateUserRequest request,
        IUserService userService)
    {
        CreateUserRequestValidator validator = new();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest(validationResult.Errors);
        }
        
        var result = await userService.CreateUserAsync(request);

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound();
    }
}