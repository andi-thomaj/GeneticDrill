using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.Core.Services.Abstractions;

public interface IUserService
{
    Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email);
    //Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);
}