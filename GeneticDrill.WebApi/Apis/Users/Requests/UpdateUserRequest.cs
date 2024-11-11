namespace GeneticDrill.WebApi.Apis.Users.Requests;

public record UpdateUserRequest(Guid Id, string FirstName, string MiddleName, string LastName, string FrontendTheme);