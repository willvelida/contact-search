using FluentValidation;

namespace ContactSearch.Application.Features.EmailAddress.Commands.CreateEmailAddress
{
    public class CreateEmailAddressCommandValidator : AbstractValidator<CreateEmailAddressCommand>
    {
        public CreateEmailAddressCommandValidator()
        {
            RuleFor(p => p.EmailAddress)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        }
    }
}
