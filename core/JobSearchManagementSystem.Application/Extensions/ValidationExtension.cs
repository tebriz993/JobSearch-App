using FluentValidation;
using JobSearchManagementSystem.Application.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Extensions
{
    public static class ValidationExtension
    {
        public static IRuleBuilderOptions<T, TProperty> CheckNull<T,
           TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.WithMessage($"{nameof(TProperty)} is required");
        }
        public static async Task ThrowIfValidationFailAsync<T>(this IValidator<T> validator, T instance)
        {
            var validationResult = await validator.ValidateAsync(instance);
            if (!validationResult.IsValid)
            {
                throw new JobSearchValidationException(validationResult.Errors);
            }
        }
    }
}
