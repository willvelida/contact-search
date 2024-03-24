using FluentValidation;

namespace ContactSearch.Application.Features.Contacts.Commands.CreateContacts
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters");

            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
