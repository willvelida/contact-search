using ContactSearch.Application.Responses;

namespace ContactSearch.Application.Features.Contact.Commands.UpdateCommand
{
    public class UpdateContactCommandResponse : BaseResponse
    {
        public UpdateContactCommandResponse() : base()
        {

        }

        public UpdateContactDto Contact { get; set; } = default!;
    }
}
