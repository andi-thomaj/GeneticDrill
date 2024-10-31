using FluentValidation;
using GeneticDrill.WebApi.Apis.Users.Requests;

namespace GeneticDrill.WebApi.Apis.Users.Validations;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(request => request.Password).NotEmpty().WithMessage("Password is required");
    }
}