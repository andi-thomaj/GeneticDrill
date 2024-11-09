using GeneticDrill.WebApi.Core.DataAccess.Entities;

namespace GeneticDrill.WebApi.Apis.Users.Responses;

public record GetUserByEmailResponse(User User)
{
    public Guid Id { get; init; } = User.id;
    public string FirstName { get; init; } = User.first_name;
    public string MiddleName { get; init; } = User.middle_name ?? string.Empty;
    public string LastName { get; init; } = User.last_name;
    public string Email { get; init; } = User.email;
    public string GooglePictureUrl { get; init; } = User.google_picture_url ?? string.Empty;
    public string FrontendTheme { get; init; } = User.frontend_theme ?? string.Empty;
    public bool IsBlocked { get; init; } = User.is_blocked;
    public bool IsDeleted { get; init; } = User.is_deleted;
    public DateTimeOffset CreatedAt { get; init; } = User.created_at;
};