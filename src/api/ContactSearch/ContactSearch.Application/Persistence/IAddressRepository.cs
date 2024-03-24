using ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Persistence
{
    public interface IAddressRepository : IAsyncRepository<Address>
    {
        Task<List<Address>> GetAddressesForContact(Guid contactId);
    }
}
