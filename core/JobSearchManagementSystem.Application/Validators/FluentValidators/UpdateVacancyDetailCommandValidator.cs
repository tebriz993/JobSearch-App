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

            RuleFor(x => x.EndDate)
                .NotNull();
            RuleFor(x => x.AnnouncementNumber)
                .GreaterThan(0);
            

            RuleFor(x => x.MinExperience)
                .NotNull();

            RuleFor(x => x.MaxExperience)
                .NotNull();

               
        }
    }
}
