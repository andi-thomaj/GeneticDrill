using FluentValidation;
using GeneticDrill.WebApi.Apis.Users.Requests;

namespace GeneticDrill.WebApi.Apis.Users.Validations;

public class GetUserByEmailRequestValidator : AbstractValidator<GetUserByEmailRequest>
{
    public GetUserByEmailRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}