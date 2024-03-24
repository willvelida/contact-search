using MediatR;

namespace ContactSearch.Application.Features.Contacts.Queries.GetContactsList
{
    public class GetContactListQuery : IRequest<List<ContactListViewModel>>
    {
    }
}
