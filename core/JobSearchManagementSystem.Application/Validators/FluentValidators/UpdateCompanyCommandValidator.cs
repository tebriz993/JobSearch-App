using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Invalid company Id");

            

            

            
        }
    }
}
