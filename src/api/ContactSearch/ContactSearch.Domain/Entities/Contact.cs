using ContactSearch.Domain.Common;

namespace ContactSearch.Domain.Entities
{
    public class Contact : AuditableEntity
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Phone> PhoneNumbers { get; set; }
        public List<Email> EmailAddress { get; set; }
    }
}
