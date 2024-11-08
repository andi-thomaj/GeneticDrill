using GeneticDrill.WebApi.Apis.Users.Requests;
using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.DataAccess.Abstractions;

public interface IUserRepository
{
    public Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email);
    Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);
}