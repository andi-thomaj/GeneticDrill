using GeneticDrill.WebApi.Apis.Users.Responses;
using GeneticDrill.WebApi.Helpers;

namespace GeneticDrill.WebApi.Services.Abstractions;

public interface IUserService
{
    public Task<Result<GetUserByEmailResponse>> GetUserByEmailAsync(string email,
        CancellationToken cancellationToken = default);
}