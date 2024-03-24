using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactSearch.Persistence.Repositories
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(ContactSearchDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Phone>> GetPhoneNumberByContactId(Guid contactId)
        {
            return await _dbContext.Phones.Where(c => c.ContactId == contactId)
                .ToListAsync();
        }
    }
}
