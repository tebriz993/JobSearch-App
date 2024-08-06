using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class UpdateRoleCommandValidator:AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();

            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("Id cannot be empty");
        }
    }
}
