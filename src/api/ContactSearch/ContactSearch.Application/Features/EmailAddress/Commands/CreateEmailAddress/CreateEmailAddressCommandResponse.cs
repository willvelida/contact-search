using ContactSearch.Application.Responses;

namespace ContactSearch.Application.Features.EmailAddress.Commands.CreateEmailAddress
{
    public class CreateEmailAddressCommandResponse : BaseResponse
    {
        public CreateEmailAddressCommandResponse() : base()
        {

        }

        public CreateEmailAddressDto Email { get; set; } = default!;
    }
}
