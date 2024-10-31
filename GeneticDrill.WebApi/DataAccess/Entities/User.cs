using System.ComponentModel.DataAnnotations.Schema;

namespace GeneticDrill.WebApi.DataAccess.Entities;

public class User : BaseEntity
{
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;
    
    [Column("middle_name")]
    public string MiddleName { get; set; } = string.Empty;
    
    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;
    
    [Column("email")]
    public string Email { get; set; } = string.Empty;
    
    [Column("password")]
    public string Password { get; set; } = string.Empty;
    
    [Column("is_blocked")]
    public bool IsBlocked { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
    
    [Column("login_attempts_count")]
    public int LoginAttemptsCount { get; set; }
    
    [Column("token")]
    public string Token { get; set; } = string.Empty;
    
    [Column("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;
    
    [Column("google_picture_url")]
    public string GooglePictureUrl { get; set; } = string.Empty;
    
    [Column("frontend_theme")]
    public string FrontendTheme { get; set; } = string.Empty;
    
    [Column("genetic_data_id")]
    public Guid GeneticDataId { get; set; }
}