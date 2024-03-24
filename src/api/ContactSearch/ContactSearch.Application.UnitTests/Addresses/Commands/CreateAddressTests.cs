using AutoMapper;
using ContactSearch.Application.Features.Addresses.Commands.CreateAddress;
using ContactSearch.Application.Persistence;
using ContactSearch.Application.Profiles;
using ContactSearch.Domain.Entities;
using Moq;
using Shouldly;

namespace ContactSearch.Application.UnitTests.Addresses.Commands
{
    public class CreateAddressTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Address>> _mockAddressRepository;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;

        public CreateAddressTests()
        {
            _mockAddressRepository = new Mock<IAsyncRepository<Address>>();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _createAddressCommandHandler = new CreateAddressCommandHandler(_mapper, _mockAddressRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new CreateAddressCommand()
            {
                AddressLine1 = "1 Wonder Way",
                AddressLine2 = "Smartsville",
                City = "Melbourne",
                State = "VIC",
                Country = "Australia",
                ZipCode = "3000"
            };
            var addressGuid = new Guid();
            var address = new Address() { ContactId = addressGuid, AddressLine1 = command.AddressLine1, AddressLine2 = command.AddressLine2, City = command.City, State = command.State, Country = command.Country, ZipCode = command.ZipCode };

            _mockAddressRepository.Setup(repo => repo.AddAsync(It.IsAny<Address>())).ReturnsAsync(address);

            // Act
            var response = await _createAddressCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Success.ShouldBeTrue();
            response.Address.ShouldNotBeNull();
            response.Address.AddressId.ShouldBe(addressGuid);
            response.Address.AddressLine1.ShouldBe(command.AddressLine1);
            response.Address.AddressLine2.ShouldBe(command.AddressLine2);
            response.Address.City.ShouldBe(command.City);
            response.Address.State.ShouldBe(command.State);
            response.Address.Country.ShouldBe(command.Country);
            response.Address.ZipCode.ShouldBe(command.ZipCode);
            response.ValidationErrors.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var command = new CreateAddressCommand();

            // Act
            var response = await _createAddressCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Success.ShouldBeFalse();
            response.Address.ShouldBeNull();
            response.ValidationErrors.ShouldNotBeNull();
            response.ValidationErrors.ShouldContain("Address Line1 is required");
            response.ValidationErrors.ShouldContain("Address Line2 is required");
            response.ValidationErrors.ShouldContain("City is required");
            response.ValidationErrors.ShouldContain("State is required");
            response.ValidationErrors.ShouldContain("Country is required");
            response.ValidationErrors.ShouldContain("Zip Code is required");
        }
    }
}
