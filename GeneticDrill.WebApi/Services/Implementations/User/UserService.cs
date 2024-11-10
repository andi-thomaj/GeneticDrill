using Dapper;
using GeneticDrill.WebApi.Apis.Users.Requests;
using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Helpers;
using GeneticDrill.WebApi.Services.Abstractions;

namespace GeneticDrill.WebApi.Services.Implementations.User;

public class UserService(DapperContext dapperContext) : IUserService
{
    public async Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email)
    {
        try
        {
            var connection = dapperContext.CreateConnection();
            var user = await connection.QueryFirstAsync<Data.Entities.User>("select * from get_user_by_email(@email)",
                new { email });

            if (user is null)
            {
                return new Result<GetUserByEmailResponse>(null, false,
                    Error.NotFound(nameof(GetUserByEmailAsync), $"User with email {email} not found"));
            }

            return new Result<GetUserByEmailResponse>(new GetUserByEmailResponse(user), true, Error.None);
        }
        catch (Exception e)
        {
            return new Result<GetUserByEmailResponse>(null, false,
                Error.Failure(nameof(GetUserByEmailAsync), e.Message));
        }
    }

    public async Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
    {
        try
        {
            var connection = dapperContext.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@first_name", request.FirstName);
            parameters.Add("@last_name", request.LastName);
            parameters.Add("@email", request.Email);
            parameters.Add("@frontend_theme", request.FrontendTheme);
            parameters.Add("@password", request.Password);
            parameters.Add("@middle_name", request.MiddleName);
            parameters.Add("@google_picture_url", request.GooglePictureUrl);
            var user = await connection.QuerySingleOrDefaultAsync<Data.Entities.User>(
                "select * from create_user(@first_name, @last_name, @email, @frontend_theme, @password, @middle_name, @google_picture_url)",
                parameters);

            if (user is null)
            {
                return new Result<CreateUserResponse>(null, false,
                    Error.NotFound(nameof(CreateUserAsync),
                        $"User with email {request.Email} couldn't be created"));
            }

            if (user.status == "conflict")
            {
                return new Result<CreateUserResponse>(new CreateUserResponse(user), false,
                    Error.Conflict(nameof(CreateUserAsync),
                        $"User with email {request.Email} already in use"));
            }

            return new Result<CreateUserResponse>(new CreateUserResponse(user), true, Error.None);
        }
        catch (Exception e)
        {
            return new Result<CreateUserResponse>(null, false,
                Error.Failure(nameof(CreateUserAsync), e.Message));
        }
    }

    // public async Task<Result> UpdateUser()
    // {
    //     
    // }
    //
    // public async Task<Result> DeleteUserById(Guid id)
    // {
    //     
    // }
}