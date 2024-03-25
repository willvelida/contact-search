using MediatR;

namespace ContactSearch.Application.Features.Contact.Queries.GetContactById
{
    public record GetContactByIdQuery(Guid contactId) : IRequest<GetContactByIdViewModel>;
}
