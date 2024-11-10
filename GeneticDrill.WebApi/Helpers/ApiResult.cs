namespace GeneticDrill.WebApi.Helpers;

public class ApiResult
{
    public string ErrorMessage { get; set; }
    public List<string> ValidationErrors { get; set; }
}