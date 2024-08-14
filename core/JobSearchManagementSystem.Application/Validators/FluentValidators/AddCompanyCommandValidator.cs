using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class AddCompanyCommandValidator : AbstractValidator<AddCompanyCommand>
    {
        public AddCompanyCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Company name is required.");
        }
    }
}
