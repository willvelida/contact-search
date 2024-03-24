using FluentValidation;

namespace ContactSearch.Application.Features.PhoneNumbers.Commands
{
    public class CreatePhoneNumberCommandValidator : AbstractValidator<CreatePhoneNumberCommand>
    {
        public CreatePhoneNumberCommandValidator()
        {
            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        }
    }
}
