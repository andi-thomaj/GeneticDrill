using System.ComponentModel.DataAnnotations.Schema;

namespace GeneticDrill.WebApi.DataAccess.Entities;

public class BaseEntity
{
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [Column("created_by")]
    public string CreatedBy { get; set; } = string.Empty;
    
    [Column("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }
    
    [Column("updated_by")]
    public string UpdatedBy { get; set; } = string.Empty;
}