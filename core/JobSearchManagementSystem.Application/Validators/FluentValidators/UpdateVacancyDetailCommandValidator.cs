using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class UpdateVacancyDetailCommandValidator : AbstractValidator<UpdateVacancyDetailCommand>
    {
        public UpdateVacancyDetailCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThan(0);
            RuleFor(x => x.Image)
                .NotEmpty();
            RuleFor(x => x.VacancyId)
                .NotNull();
            RuleFor(x => x.CompanyId)
                .GreaterThan(0);
            RuleFor(x => x.EndDate)
                .NotNull();
            RuleFor(x => x.AnnouncementNumber)
                .GreaterThan(0);
            RuleFor(x => x.JobInformationId)
                .GreaterThan(0);
            RuleFor(x => x.AddressId)
                .GreaterThan(0);
            RuleFor(x => x.MinExperience);
            RuleFor(x => x.MaxExperience);
                
            RuleFor(x => x.CategoryId)
                .GreaterThan(0);
            RuleFor(x => x.JobTypesId)
                .GreaterThan(0);
            RuleFor(x => x.SpecialtiesId)
                .GreaterThan(0);
        }
    }
}
