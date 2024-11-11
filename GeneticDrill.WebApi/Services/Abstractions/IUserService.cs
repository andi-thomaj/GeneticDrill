using GeneticDrill.WebApi.Apis.Users.Requests;
using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.Services.Abstractions;

public interface IUserService
{
    Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email);
    Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);
    Task<Result<UpdateUserResponse>> UpdateUserAsync(UpdateUserRequest request);
    Task<Result> DeleteUserById(Guid id);
}