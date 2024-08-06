using FluentValidation.Results;

namespace JobSearchManagementSystem.Application.Exception;

public class JobSearchValidationException : ApplicationException
{
    public List<ValidationFailure> ValidationFailures { get; set; }
    public JobSearchValidationException(List<ValidationFailure> validationFailures)
        : base("Validation Exception")
    {
        ValidationFailures = validationFailures;
    }
}