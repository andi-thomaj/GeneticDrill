namespace GeneticDrill.WebApi.Apis.Users.Requests;

public record CreateUserRequest(
    string Email,
    string Password,
    string FirstName,
    string MiddleName,
    string LastName,
    string GooglePictureUrl,
    string FrontendTheme);