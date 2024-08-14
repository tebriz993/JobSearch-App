using FluentValidation;
using JobSearchManagementSystem.Application.Features.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Validators.FluentValidators
{
    public class DeleteCategoryCommandValidator:AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id is not found");
        }
    }
}
