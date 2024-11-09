using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Core.DataAccess.Abstractions;
using GeneticDrill.WebApi.Core.Services.Abstractions;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.Core.Services.Implementations;

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

    // public Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
    // {
    //     try
    //     {
    //         return userRepository.CreateUserAsync(request);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw;
    //     }
    // }
}