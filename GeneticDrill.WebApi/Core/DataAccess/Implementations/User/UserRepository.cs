using Dapper;
using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Core.DataAccess.Abstractions;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.Core.DataAccess.Implementations.User;

public class UserRepository(DapperContext dapperContext) : IUserRepository
{
    public async Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email)
    {
        var connection = dapperContext.CreateConnection();
        var user = await connection.QuerySingleAsync<Entities.User>($"select * from get_user_by_email({email})");

        if (user is null)
        {
            return new Result<GetUserByEmailResponse>(null, false,
                Error.NotFound(nameof(GetUserByEmailAsync), $"User with email {email} not found"));
        }

        return new Result<GetUserByEmailResponse>(new GetUserByEmailResponse(user), true, Error.None);
    }
}