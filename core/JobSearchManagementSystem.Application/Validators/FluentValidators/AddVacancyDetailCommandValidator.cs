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
            RuleFor(x => x.Image)
               .NotEmpty().WithMessage("Image cannot be empty");

            RuleFor(x => x.VacancyId)
                .NotEmpty().WithMessage("VacancyName cannot be empty");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company Name cannot be empty");

            RuleFor(x => x.EndDate)
               .NotEmpty().WithMessage("EndDate cannot be empty");

            RuleFor(x => x.AnnouncementNumber)
                .NotEmpty().WithMessage("AnnouncementNumber cannot be empty");

            RuleFor(x => x.JobInformationId)
                .NotEmpty().WithMessage("JobInformationId Name cannot be empty");

            RuleFor(x => x.AddressId)
                .NotEmpty().WithMessage("Address Name cannot be empty");

            RuleFor(x => x.MinExperience)
                .NotEmpty().WithMessage("MinExperienceId Name cannot be empty");

            RuleFor(x => x.MaxExperience)
                .NotEmpty().WithMessage("MaxExperienceId Name cannot be empty");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("CategoryId Name cannot be empty");

            RuleFor(x => x.JobTypesId)
                .NotEmpty().WithMessage("JobTypesId Name cannot be empty");
        }
    }
}
