using AutoMapper;
using ContactSearch.Application.Persistence;
using MediatR;
using mdl = ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Features.Contact.Queries.GetContactById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdViewModel>
    {
        private readonly IAsyncRepository<mdl.Contact> _contactRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IMapper mapper, 
            IAsyncRepository<mdl.Contact> contactRepository,
            IAddressRepository addressRepository)
        {
            _contactRepository = contactRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetContactByIdViewModel> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.contactId);
            contact.Addresses = await _addressRepository.GetAddressesForContact(contact.ContactId);
            return _mapper.Map<GetContactByIdViewModel>(contact);
        }
    }
}
