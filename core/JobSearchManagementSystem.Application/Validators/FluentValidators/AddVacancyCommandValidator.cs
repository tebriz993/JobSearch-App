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
    public class AddVacancyCommandValidator : AbstractValidator<AddVacancyCommand>
    {
        public AddVacancyCommandValidator()
        {
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Image cannot be empty");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty");

            
        }
    }
}
