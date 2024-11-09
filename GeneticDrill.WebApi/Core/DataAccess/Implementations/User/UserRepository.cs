using Dapper;
using GeneticDrill.WebApi.Apis.Users.Requests;
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

    public async Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
    {
        var connection = dapperContext.CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@first_name", request.FirstName);
        parameters.Add("@middle_name", request.MiddleName);
        parameters.Add("@last_name", request.LastName);
        parameters.Add("@email", request.Email);
        parameters.Add("@password", request.Password);
        parameters.Add("@google_picture_url", request.GooglePictureUrl);
        parameters.Add("@frontend_theme", request.FrontendTheme);
        var user = await connection.QuerySingleAsync<Entities.User>(
            "select * from create_user(@first_name, @middle_name, @last_name, @email, @password, @google_picture_url, @frontend_theme)",
            parameters);
        
        if (user is null)
        {
            return new Result<CreateUserResponse>(null, false,
                Error.NotFound(nameof(GetUserByEmailAsync), $"User with email {request.Email} couldn't be created"));
        }

        return new Result<CreateUserResponse>(new CreateUserResponse(user), true, Error.None);
    }
}