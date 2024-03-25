using ContactSearch.Application.Features.Contact.Commands.UpdateCommand;
using MediatR;

namespace ContactSearch.Application.Features.Contacts.Commands.UpdateCommand
{
    public class UpdateContactCommand : IRequest<UpdateContactCommandResponse>
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
