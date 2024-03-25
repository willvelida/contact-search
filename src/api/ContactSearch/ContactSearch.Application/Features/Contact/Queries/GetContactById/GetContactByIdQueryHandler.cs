using AutoMapper;
using ContactSearch.Application.Persistence;
using MediatR;
using mdl = ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Features.Contact.Queries.GetContactById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdViewModel>
    {
        private readonly IAsyncRepository<mdl.Contact> _contactRepository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IMapper mapper, IAsyncRepository<mdl.Contact> contactRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<GetContactByIdViewModel> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.contactId);
            return _mapper.Map<GetContactByIdViewModel>(contact);
        }
    }
}
