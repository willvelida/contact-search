using ContactSearch.Domain.Common;

namespace ContactSearch.Domain.Entities
{
    public class Phone : AuditableEntity
    {
        public Guid PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ContactId { get; set; }
        public PhoneType PhoneType { get; set; }
    }

    public enum PhoneType
    {
        Mobile,
        Home,
        Work
    }
}
