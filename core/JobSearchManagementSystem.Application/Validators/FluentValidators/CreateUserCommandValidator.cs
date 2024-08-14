using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobSearchManagementSystem.Application.Extensions;
using JobSearchManagementSystem.Application.Features.Command;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email cannot be empty")
                .EmailAddress()
                .WithMessage("Email format is fault")
                .CheckNull();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name cannot be empty")
                .MinimumLength(3)
                .MaximumLength(50)
                .CheckNull();

            RuleFor(x => x.LastName)
                .MinimumLength(3)
                .MaximumLength(80)
                .NotEmpty()
                .WithMessage("Last name cannot be empty")
                .CheckNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty")
                .CheckNull()
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long")
                .Matches("[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter")
                .Matches("[a-z]")
                .WithMessage("Password must contain at least one lowercase letter")
                .Matches("[0-9]")
                .WithMessage("Password must contain at least one number");

        }
    }
}
