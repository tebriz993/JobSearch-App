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
    public class UpdateVacancyCommandValidator:AbstractValidator<UpdateVacancyCommand>
    {
        public UpdateVacancyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThan(0);
            RuleFor(x => x.Image)
                .NotEmpty();
            RuleFor(x=>x.Name)
                .NotEmpty();
            
        }
    }
}
