using GeneticDrill.WebApi.Apis.Users.Requests;
using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Apis.Users.Validations;
using GeneticDrill.WebApi.Helpers;
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
        routeGroupBuilder.MapPut(string.Empty, UpdateUser);
        routeGroupBuilder.MapDelete("{id:guid}", DeleteUserById);

        return builder;
    }

    private static async Task<Results<Ok<GetUserByEmailResponse>, NotFound<Error>, BadRequest<Error>, Conflict<Error>>> GetUserByEmail(string email,
        IUserService userService)
    {
        GetUserByEmailRequestValidator validator = new();
        var validationResult = await validator.ValidateAsync(new GetUserByEmailRequest(email));
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest(Error.FluentValidationError(nameof(GetUserByEmail), validationResult.Errors));
        }
        
        var result = await userService.GetUserByEmailAsync(email);

        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.Conflict => TypedResults.Conflict(result.Error),
                ErrorType.NotFound => TypedResults.NotFound(result.Error),
                _ => TypedResults.BadRequest(result.Error)
            };
        }

        return TypedResults.Ok(result.Value);
    }
    
    private static async Task<Results<Ok<CreateUserResponse>, NotFound<Error>, BadRequest<Error>, Conflict<Error>>> CreateUser(CreateUserRequest request,
        IUserService userService)
    {
        CreateUserRequestValidator validator = new();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest(Error.FluentValidationError(nameof(CreateUser), validationResult.Errors));
        }
        
        var result = await userService.CreateUserAsync(request);

        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.Conflict => TypedResults.Conflict(result.Error),
                ErrorType.NotFound => TypedResults.NotFound(result.Error),
                _ => TypedResults.BadRequest(result.Error)
            };
        }

        return TypedResults.Ok(result.Value);
    }

    private static async Task<Results<Ok<UpdateUserResponse>, NotFound<Error>, BadRequest<Error>>> UpdateUser(
        UpdateUserRequest request, IUserService userService)
    {
        UpdateUserRequestValidator validator = new();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest(Error.FluentValidationError(nameof(UpdateUser), validationResult.Errors));
        }
        
        var result = await userService.UpdateUserAsync(request);
        
        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.NotFound => TypedResults.NotFound(result.Error),
                _ => TypedResults.BadRequest(result.Error)
            };
        }

        return TypedResults.Ok(result.Value);
    }

    private static async Task<Results<Ok, NotFound<Error>, BadRequest<Error>>> DeleteUserById(Guid id,
        IUserService userService)
    {
        var result = await userService.DeleteUserById(id);
        
        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.NotFound => TypedResults.NotFound(result.Error),
                _ => TypedResults.BadRequest(result.Error)
            };
        }
        
        return TypedResults.Ok();
    }
}