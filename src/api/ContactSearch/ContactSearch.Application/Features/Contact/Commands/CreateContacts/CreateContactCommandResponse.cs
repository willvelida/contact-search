using ContactSearch.Application.Responses;

namespace ContactSearch.Application.Features.Contacts.Commands.CreateContacts
{
    public class CreateContactCommandResponse : BaseResponse
    {
        public CreateContactCommandResponse() : base()
        {

        }

        public CreateContactDto Contact { get; set; } = default!;
    }
}
