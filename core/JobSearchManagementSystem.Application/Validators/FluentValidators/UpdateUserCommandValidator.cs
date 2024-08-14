using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        //RuleFor(x => x.Id)
        //    .GreaterThan(0)
        //    .WithMessage("Invalid user ID");

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .WithMessage("Email format is invalid");

        RuleFor(x => x.FirstName)
            .MinimumLength(3)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.FirstName))
            .WithMessage("First name must be between 3 and 50 characters");

        RuleFor(x => x.LastName)
            .MinimumLength(3)
            .MaximumLength(80)
            .When(x => !string.IsNullOrWhiteSpace(x.LastName))
            .WithMessage("Last name must be between 3 and 80 characters");

        RuleFor(x => x.Password)
            .MinimumLength(8)
            .Matches("[A-Z]")
            .Matches("[a-z]")
            .Matches("[0-9]")
            .When(x => !string.IsNullOrWhiteSpace(x.Password))
            .WithMessage("Password must be at least 8 characters long and include uppercase, lowercase, and a number");
    }
}
