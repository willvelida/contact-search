using ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Features.Contact.Queries.GetContactById
{
    public class GetContactByIdViewModel
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
