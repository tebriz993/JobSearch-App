using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class AddVacancyDetailCommandValidator:AbstractValidator<AddVacancyDetailCommand>
    {
        public AddVacancyDetailCommandValidator()
        {
            

            RuleFor(x => x.EndDate)
               .NotEmpty().WithMessage("EndDate cannot be empty");

            RuleFor(x => x.AnnouncementNumber)
                .NotEmpty().WithMessage("AnnouncementNumber cannot be empty");

            
            RuleFor(x => x.MinExperience)
                .NotEmpty().WithMessage("MinExperienceId cannot be empty");

            RuleFor(x => x.MaxExperience)
                .NotEmpty().WithMessage("MaxExperienceId cannot be empty");

           
        }
    }
}
