using AutoMapper;
using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;
using MediatR;

namespace ContactSearch.Application.Features.PhoneNumbers.Commands
{
    public class CreatePhoneNumberCommandHandler : IRequestHandler<CreatePhoneNumberCommand, CreatePhoneNumberCommandResponse>
    {
        private readonly IAsyncRepository<Phone> _phoneRepository;
        private readonly IMapper _mapper;

        public CreatePhoneNumberCommandHandler(IMapper mapper, IAsyncRepository<Phone> phoneRepository)
        {
            _mapper = mapper;
            _phoneRepository = phoneRepository;
        }

        public async Task<CreatePhoneNumberCommandResponse> Handle(CreatePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var createPhoneNumberCommandResponse = new CreatePhoneNumberCommandResponse();
            var validator = new CreatePhoneNumberCommandValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createPhoneNumberCommandResponse.Success = false;
                createPhoneNumberCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createPhoneNumberCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createPhoneNumberCommandResponse.Success)
            {
                var phoneNumber = new Phone() { PhoneNumber = request.PhoneNumber };
                phoneNumber = await _phoneRepository.AddAsync(phoneNumber);
                createPhoneNumberCommandResponse.PhoneNumber = _mapper.Map<CreatePhoneNumberDto>(phoneNumber);
            }

            return createPhoneNumberCommandResponse;
        }
    }
}
