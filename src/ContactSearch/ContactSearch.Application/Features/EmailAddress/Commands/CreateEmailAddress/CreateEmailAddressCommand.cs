using MediatR;

namespace ContactSearch.Application.Features.EmailAddress.Commands.CreateEmailAddress
{
    public class CreateEmailAddressCommand : IRequest<CreateEmailAddressCommandResponse>
    {
        public string EmailAddress { get; set; } = string.Empty;
    }
}
