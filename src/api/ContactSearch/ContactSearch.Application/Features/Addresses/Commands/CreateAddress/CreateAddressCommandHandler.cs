using AutoMapper;
using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;
using MediatR;

namespace ContactSearch.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreateAddressCommandResponse>
    {
        private readonly IAsyncRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IMapper mapper, IAsyncRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var createAddressCommandResponse = new CreateAddressCommandResponse();
            var validator = new CreateAddressCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createAddressCommandResponse.Success = false;
                createAddressCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createAddressCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createAddressCommandResponse.Success)
            {
                var address = new Address() { AddressLine1 = request.AddressLine1, AddressLine2 = request.AddressLine2, City = request.City, Country = request.Country, ZipCode = request.ZipCode, State = request.State, ContactId = request.ContactId };
                address = await _addressRepository.AddAsync(address);
                createAddressCommandResponse.Address = _mapper.Map<CreateAddressDto>(address);
            }

            return createAddressCommandResponse;
        }
    }
}
