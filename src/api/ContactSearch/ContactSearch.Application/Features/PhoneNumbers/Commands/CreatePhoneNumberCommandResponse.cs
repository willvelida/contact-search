using ContactSearch.Application.Responses;

namespace ContactSearch.Application.Features.PhoneNumbers.Commands
{
    public class CreatePhoneNumberCommandResponse : BaseResponse
    {
        public CreatePhoneNumberCommandResponse() : base()
        {

        }

        public CreatePhoneNumberDto PhoneNumber { get; set; } = default!;
    }
}
