using GeneticDrill.WebApi.Data.Entities;

namespace GeneticDrill.WebApi.Apis.Users.Responses;

public record CreateUserResponse
{
    public CreateUserResponse(User user)
    {
        Id = user.id;
        FirstName = user.first_name;
        MiddleName = user.middle_name;
        LastName = user.last_name;
        Email = user.email;
        GooglePictureUrl = user.google_picture_url;
        FrontendTheme = user.frontend_theme;
        IsBlocked = user.is_blocked;
        IsDeleted = user.is_deleted;
        CreatedAt = user.created_at;
        
    }
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string? GooglePictureUrl { get; init; }
    public string? FrontendTheme { get; init; }
    public bool IsBlocked { get; init; }
    public bool IsDeleted { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
}