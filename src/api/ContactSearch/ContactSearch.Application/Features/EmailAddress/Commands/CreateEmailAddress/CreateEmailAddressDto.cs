namespace ContactSearch.Application.Features.EmailAddress.Commands.CreateEmailAddress
{
    public class CreateEmailAddressDto
    {
        public Guid EmailAddressId { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
    }
}
