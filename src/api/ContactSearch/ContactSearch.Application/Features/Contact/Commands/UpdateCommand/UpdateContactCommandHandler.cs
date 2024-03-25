using AutoMapper;
using ContactSearch.Application.Features.Contact.Commands.UpdateCommand;
using ContactSearch.Application.Persistence;
using MediatR;
using mdl = ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Features.Contacts.Commands.UpdateCommand
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdateContactCommandResponse>
    {
        private readonly IAsyncRepository<mdl.Contact> _contactRepository;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(IAsyncRepository<mdl.Contact> contactRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<UpdateContactCommandResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var updateContactCommandResponse = new UpdateContactCommandResponse();
            var validator = new UpdateContactCommandValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateContactCommandResponse.Success = false;
                updateContactCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateContactCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (updateContactCommandResponse.Success)
            {
                var contactToUpdate = await _contactRepository.GetByIdAsync(request.ContactId);

                _mapper.Map(request, contactToUpdate, typeof(UpdateContactCommand), typeof(mdl.Contact));

                await _contactRepository.UpdateAsync(contactToUpdate);
                updateContactCommandResponse.Contact = _mapper.Map<UpdateContactDto>(contactToUpdate);
            }

            return updateContactCommandResponse;
        }
    }
}
