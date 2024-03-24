using AutoMapper;
using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;
using MediatR;

namespace ContactSearch.Application.Features.EmailAddress.Commands.CreateEmailAddress
{
    public class CreateEmailAddressCommandHandler : IRequestHandler<CreateEmailAddressCommand, CreateEmailAddressCommandResponse>
    {
        private readonly IAsyncRepository<Email> _emailRepository;
        private readonly IMapper _mapper;

        public CreateEmailAddressCommandHandler(IMapper mapper, IAsyncRepository<Email> emailRepository)
        {
            _mapper = mapper;
            _emailRepository = emailRepository;
        }

        public async Task<CreateEmailAddressCommandResponse> Handle(CreateEmailAddressCommand request, CancellationToken cancellationToken)
        {
            var createEmailCommandResponse = new CreateEmailAddressCommandResponse();

            var validator = new CreateEmailAddressCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createEmailCommandResponse.Success = false;
                createEmailCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createEmailCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createEmailCommandResponse.Success)
            {
                var email = new Email() { EmailAddress = request.EmailAddress };
                email = await _emailRepository.AddAsync(email);
                createEmailCommandResponse.Email = _mapper.Map<CreateEmailAddressDto>(email);
            }

            return createEmailCommandResponse;
        }
    }
}
