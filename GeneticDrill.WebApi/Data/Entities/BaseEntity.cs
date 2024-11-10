using System.ComponentModel.DataAnnotations.Schema;

namespace GeneticDrill.WebApi.Data.Entities;

public class BaseEntity
{
    [Column("id")] public Guid id { get; set; }

    [Column("created_at")] public DateTimeOffset created_at { get; set; }

    [Column("created_by")] public string created_by { get; set; } = string.Empty;

    [Column("updated_at")] public DateTimeOffset updated_at { get; set; }

    [Column("updated_by")] public string updated_by { get; set; } = string.Empty;
}