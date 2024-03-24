using AutoMapper;
using ContactSearch.Application.Features.PhoneNumbers.Commands;
using ContactSearch.Application.Persistence;
using ContactSearch.Application.Profiles;
using ContactSearch.Domain.Entities;
using Moq;
using Shouldly;

namespace ContactSearch.Application.UnitTests.Phones.Commands
{
    public class CreatePhoneNumberTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Phone>> _mockPhoneRepository;
        private readonly CreatePhoneNumberCommandHandler _createPhoneNumberCommandHandler;

        public CreatePhoneNumberTests()
        {
            _mockPhoneRepository = new Mock<IAsyncRepository<Phone>>();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _createPhoneNumberCommandHandler = new CreatePhoneNumberCommandHandler(_mapper, _mockPhoneRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new CreatePhoneNumberCommand { PhoneNumber = "0123456789" };

            _mockPhoneRepository.Setup(repo => repo.AddAsync(It.IsAny<Phone>())).ReturnsAsync(new Phone { PhoneNumberId = Guid.NewGuid(), PhoneNumber = "0123456789" });

            // Act
            var response = await _createPhoneNumberCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Success.ShouldBeTrue();
            response.PhoneNumber.ShouldNotBeNull();
            response.PhoneNumber.PhoneNumber.ShouldBe(command.PhoneNumber);
            response.ValidationErrors.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_InvalidCommand_ReturnsValidationError_NoPhoneNumber()
        {
            // Arrange
            var command = new CreatePhoneNumberCommand();

            // Act
            var response = await _createPhoneNumberCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Success.ShouldBeFalse();
            response.PhoneNumber.ShouldBeNull();
            response.ValidationErrors.ShouldNotBeNull();
            response.ValidationErrors.ShouldContain("Phone Number is required");
        }
    }
}
