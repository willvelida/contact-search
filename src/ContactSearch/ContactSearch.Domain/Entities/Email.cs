using ContactSearch.Domain.Common;

namespace ContactSearch.Domain.Entities
{
    public class Email : AuditableEntity
    {
        public Guid EmailId { get; set; }
        public string EmailAddress { get; set; }
        public Guid ContactId { get; set; }
        public EmailType EmailType { get; set; }
    }

    public enum EmailType
    {
        Work,
        Personal
    }
}
