using AutoMapper;
using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;
using MediatR;

namespace ContactSearch.Application.Features.Contacts.Queries.GetContactsList
{
    public class GetContactListQueryHandler : IRequestHandler<GetContactListQuery, List<ContactListViewModel>>
    {
        private readonly IAsyncRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public GetContactListQueryHandler(IMapper mapper, IAsyncRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<List<ContactListViewModel>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
        {
            var allContacts = (await _contactRepository.ListAllAsync()).OrderBy(x => x.LastName);
            return _mapper.Map<List<ContactListViewModel>>(allContacts);
        }
    }
}
