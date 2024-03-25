using MediatR;

namespace ContactSearch.Application.Features.Contacts.Queries.GetContactsList
{
    public record GetContactListQuery : IRequest<List<ContactListViewModel>>;
}
