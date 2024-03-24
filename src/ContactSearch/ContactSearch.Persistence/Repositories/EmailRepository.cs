using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactSearch.Persistence.Repositories
{
    public class EmailRepository : BaseRepository<Email>, IEmailRepository
    {
        public EmailRepository(ContactSearchDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Email>> GetEmailsForContact(Guid contactId)
        {
            return await _dbContext.Emails.Where(x => x.ContactId == contactId)
                .ToListAsync();
        }
    }
}
