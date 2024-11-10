using FluentValidation;
using GeneticDrill.WebApi.Apis.Users.Requests;

namespace GeneticDrill.WebApi.Apis.Users.Validations;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(request => request.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("First name is required")
            .MaximumLength(50)
            .MinimumLength(3)
            .WithMessage("First name must be between 3 and 50 characters");
        
        // RuleFor(request => request.MiddleName).e().WithMessage("Email is required");
        // RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required");
        // RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required");
        // RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required");
        // RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required");
        // RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required");
    }
}