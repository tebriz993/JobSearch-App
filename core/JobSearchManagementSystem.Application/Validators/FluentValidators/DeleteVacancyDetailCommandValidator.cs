using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class DeleteVacancyDetailCommandValidator : AbstractValidator<DeleteVacancyDetailCommand>
    {
        public DeleteVacancyDetailCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id is not found");
        }
    }
}
