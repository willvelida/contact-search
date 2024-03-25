using MediatR;

namespace ContactSearch.Application.Features.Contacts.Commands.DeleteContactById
{
    public class DeleteContactCommand : IRequest
    {
        public Guid ContactId { get; set; }
    }
}
