using GeneticDrill.WebApi.Apis.Users.Requests;
using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.DataAccess.Abstractions;
using GeneticDrill.WebApi.Helpers;
using GeneticDrill.WebApi.Services.Abstractions;

namespace GeneticDrill.WebApi.Services.Implementations;

public class UserService(IUserRepository userRepository) : IUserService
{
    public Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email)
    {
        try
        {
            return userRepository.GetUserByEmailAsync(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
    {
        try
        {
            return userRepository.CreateUserAsync(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}