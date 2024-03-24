using ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Persistence
{
    public interface IEmailRepository : IAsyncRepository<Email>
    {
        Task<List<Email>> GetEmailsForContact(Guid contactId);
    }
}
