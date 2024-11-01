namespace GeneticDrill.WebApi.DataAccess.Entities;

public class User : BaseEntity
{
    public string first_name { get; init; } = string.Empty;
    
    public string middle_name { get; init; } = string.Empty;
    
    public string last_name { get; init; } = string.Empty;
    
    public string email { get; init; } = string.Empty;
    
    public string password { get; init; } = string.Empty;
    
    public bool is_blocked { get; init; }
    
    public bool is_deleted { get; init; }
    
    public int login_attempts_count { get; init; }
    
    public string token { get; init; } = string.Empty;
    
    public string refresh_token { get; init; } = string.Empty;
    
    public string google_picture_url { get; init; } = string.Empty;
    
    public string frontend_theme { get; init; } = string.Empty;
    
    public Guid genetic_data_id { get; init; }
}