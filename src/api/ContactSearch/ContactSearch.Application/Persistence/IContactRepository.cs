using ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Persistence
{
    public interface IContactRepository : IAsyncRepository<Contact>
    {
    }
}
