using MediatR;

namespace ContactSearch.Application.Features.PhoneNumbers.Commands
{
    public class CreatePhoneNumberCommand : IRequest<CreatePhoneNumberCommandResponse>
    {
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
