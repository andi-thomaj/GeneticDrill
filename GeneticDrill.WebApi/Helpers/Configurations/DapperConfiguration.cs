namespace GeneticDrill.WebApi.Helpers.Configurations;

public class DapperConfiguration
{
    internal const string SectionName = nameof(DapperConfiguration);
    public string ConnectionString { get; set; } = string.Empty;
}