using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class AddAddressCommandValidator : AbstractValidator<AddAddressCommand>
    {
        public AddAddressCommandValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country cannot be empty");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City cannot be empty");

            RuleFor(x => x.AddressName)
                .NotEmpty().WithMessage("Address Name cannot be empty");
        }
    }
}
