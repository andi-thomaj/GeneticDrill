using Dapper;
using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.DataAccess.Abstractions;
using GeneticDrill.WebApi.DataAccess.Entities;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.DataAccess.Implementations;

public class UserRepository(DapperContext dapperContext) : IUserRepository
{
    public async Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email, CancellationToken cancelationToken = default)
    {
        var connection = dapperContext.CreateConnection();
        
        var user = await connection.QueryFirstAsync<User>("""
                                                                select top 1 from users
                                                            """);

        return new Result<GetUserByEmailResponse>(new GetUserByEmailResponse(user), true, Error.None);
    }
}