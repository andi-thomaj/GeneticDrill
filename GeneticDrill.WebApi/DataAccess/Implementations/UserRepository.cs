using Dapper;
using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.DataAccess.Abstractions;
using GeneticDrill.WebApi.DataAccess.Entities;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.DataAccess.Implementations;

public class UserRepository(DapperContext dapperContext) : IUserRepository
{
    public async Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email,
        CancellationToken cancelationToken = default)
    {
        var connection = dapperContext.CreateConnection();

        await connection.ExecuteAsync("""
                                            INSERT INTO
                                                PUBLIC.USERS (
                                                ID,
                                                FIRST_NAME,
                                                MIDDLE_NAME,
                                                LAST_NAME,
                                                EMAIL,
                                                PASSWORD,
                                                IS_BLOCKED,
                                                IS_DELETED,
                                                LOGIN_ATTEMPTS_COUNT,
                                                TOKEN,
                                                REFRESH_TOKEN,
                                                GOOGLE_TOKEN,
                                                GOOGLE_PICTURE_URL,
                                                FRONTEND_THEME,
                                                GENETIC_DATA_ID,
                                                CREATED_AT,
                                                CREATED_BY,
                                                UPDATED_AT,
                                                UPDATED_BY
                                            )
                                            VALUES
                                                (
                                                    UUID_GENERATE_V4 (),
                                                    'Andi',
                                                    NULL,
                                                    'Thomaj',
                                                    'andi.dev94@gmail.com',
                                                    'test',
                                                    FALSE,
                                                    FALSE,
                                                    1,
                                                    'token',
                                                    'refresh_token',
                                                    'google_token',
                                                    'picture_url',
                                                    'black',
                                                    NULL,
                                                    NOW(),
                                                    'created_by',
                                                    NULL,
                                                    'updated_by'
                                                );
                                            """);
        var user = await connection.QueryFirstAsync<User>("""
                                                              select top 1 from users
                                                          """);

        return new Result<GetUserByEmailResponse>(new GetUserByEmailResponse(user), true, Error.None);
    }
}