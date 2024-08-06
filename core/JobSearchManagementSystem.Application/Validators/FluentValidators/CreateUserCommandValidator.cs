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
                     .CheckNull();

            RuleFor(x => x.FirstName)
                     .NotEmpty()
                     .CheckNull();

            RuleFor(x => x.LastName)
                     .NotEmpty()
                     .CheckNull();


            RuleFor(x => x.Password)
                     .NotEmpty()
                     .CheckNull();
        }
    }
}
