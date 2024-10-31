using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.DataAccess.Abstractions;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.DataAccess.Implementations;

public class UserRepository(DapperContext dapperContext) : IUserRepository
{
    public Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email, CancellationToken cancelationToken = default)
    {
        throw new NotImplementedException();
    }
}