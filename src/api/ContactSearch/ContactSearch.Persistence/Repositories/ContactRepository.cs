using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;

namespace ContactSearch.Persistence.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactSearchDbContext dbContext) : base(dbContext)
        {

        }
    }
}
