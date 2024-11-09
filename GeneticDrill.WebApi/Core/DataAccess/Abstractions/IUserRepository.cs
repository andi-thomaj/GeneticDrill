using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.Core.DataAccess.Abstractions;

public interface IUserRepository
{
    Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email);
    //Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);
}