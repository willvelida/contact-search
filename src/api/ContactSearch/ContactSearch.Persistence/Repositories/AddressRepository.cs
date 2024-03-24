using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactSearch.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ContactSearchDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Address>> GetAddressesForContact(Guid contactId)
        {
            return await _dbContext.Addresses.Where(x => x.ContactId == contactId)
                .ToListAsync();
        }
    }
}
