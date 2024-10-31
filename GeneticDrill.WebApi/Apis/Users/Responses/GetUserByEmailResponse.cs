using GeneticDrill.WebApi.DataAccess.Entities;

namespace GeneticDrill.WebApi.Apis.Users.Responses;

public record GetUserByEmailResponse(User User)
{
    public string FirstName { get; init; } = User.FirstName;
    public string MiddleName { get; init; } = User.MiddleName;
    public string LastName { get; init; } = User.LastName;
    public string Email { get; init; } = User.Email;
    public string GooglePictureUrl { get; init; } = User.GooglePictureUrl;
    public string FrontendTheme { get; init; } = User.FrontendTheme;
};