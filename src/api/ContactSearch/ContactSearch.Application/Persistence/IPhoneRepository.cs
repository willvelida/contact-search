using ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Persistence
{
    public interface IPhoneRepository : IAsyncRepository<Phone>
    {
        Task<List<Phone>> GetPhoneNumberByContactId(Guid contactId);
    }
}
