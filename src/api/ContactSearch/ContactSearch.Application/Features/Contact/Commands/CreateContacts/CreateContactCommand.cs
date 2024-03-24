using MediatR;

namespace ContactSearch.Application.Features.Contacts.Commands.CreateContacts
{
    public class CreateContactCommand : IRequest<CreateContactCommandResponse>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
