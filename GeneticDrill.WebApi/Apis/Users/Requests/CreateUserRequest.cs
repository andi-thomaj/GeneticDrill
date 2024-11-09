namespace GeneticDrill.WebApi.Apis.Users.Requests;

public record CreateUserRequest(
    string FirstName,
    string MiddleName,
    string LastName,
    string Email,
    string Password,
    string GooglePictureUrl,
    string FrontendTheme);