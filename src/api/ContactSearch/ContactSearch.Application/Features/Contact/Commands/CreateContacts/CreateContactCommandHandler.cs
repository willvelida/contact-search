using AutoMapper;
using ContactSearch.Application.Persistence;
using MediatR;
using mdl = ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Features.Contacts.Commands.CreateContacts
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreateContactCommandResponse>
    {
        private readonly IAsyncRepository<mdl.Contact> _contactRepository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IMapper mapper, IAsyncRepository<mdl.Contact> contactRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<CreateContactCommandResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var createContactCommandRepsonse = new CreateContactCommandResponse();
            var validator = new CreateContactCommandValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createContactCommandRepsonse.Success = false;
                createContactCommandRepsonse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createContactCommandRepsonse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createContactCommandRepsonse.Success)
            {
                var contact = new mdl.Contact() { FirstName = request.FirstName, LastName = request.LastName, DateOfBirth = request.DateOfBirth };
                contact = await _contactRepository.AddAsync(contact);
                createContactCommandRepsonse.Contact = _mapper.Map<CreateContactDto>(contact);
            }

            return createContactCommandRepsonse;
        }
    }
}
