using ContactSearch.Domain.Common;

namespace ContactSearch.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public Guid AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public Guid ContactId { get; set; }
        public AddressType AddressType { get; set; }
    }

    public enum AddressType
    {
        Home,
        Work
    }
}
