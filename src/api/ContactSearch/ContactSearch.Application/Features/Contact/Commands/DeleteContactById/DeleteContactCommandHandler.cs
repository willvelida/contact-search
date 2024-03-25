using ContactSearch.Application.Persistence;
using MediatR;
using mdl = ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Features.Contacts.Commands.DeleteContactById
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IAsyncRepository<mdl.Contact> _contactRepository;

        public DeleteContactCommandHandler(IAsyncRepository<mdl.Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contactToDelete = await _contactRepository.GetByIdAsync(request.ContactId);

            await _contactRepository.DeleteAsync(contactToDelete);
        }
    }
}
