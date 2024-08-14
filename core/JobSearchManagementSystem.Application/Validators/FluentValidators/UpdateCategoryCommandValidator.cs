using FluentValidation;
using FluentValidation.Validators;
using JobSearchManagementSystem.Application.Features.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Invalid company ID");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name cannot be empty");
        }
    }
}
