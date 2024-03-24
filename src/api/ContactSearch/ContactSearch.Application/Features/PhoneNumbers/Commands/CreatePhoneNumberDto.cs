namespace ContactSearch.Application.Features.PhoneNumbers.Commands
{
    public class CreatePhoneNumberDto
    {
        public Guid PhoneNumberId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
