namespace ContactSearch.Application.Features.Contacts.Commands.CreateContacts
{
    public class CreateContactDto
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
