using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.DataAccess.Implementations;
using GeneticDrill.WebApi.Helpers;
using GeneticDrill.WebApi.Services.Abstractions;

namespace GeneticDrill.WebApi.Services.Implementations;

public class UserService(UserRepository userRepository) : IUserService
{
    public Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}