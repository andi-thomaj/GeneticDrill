using GeneticDrill.WebApi.DataAccess.Entities;

namespace GeneticDrill.WebApi.Apis.Users.Responses;

public record GetUserByEmailResponse(User User)
{
    public string FirstName { get; init; } = User.first_name;
    public string MiddleName { get; init; } = User.middle_name ?? string.Empty;
    public string LastName { get; init; } = User.last_name;
    public string Email { get; init; } = User.email;
    public string GooglePictureUrl { get; init; } = User.google_picture_url ?? string.Empty;
    public string FrontendTheme { get; init; } = User.frontend_theme ?? string.Empty;
};