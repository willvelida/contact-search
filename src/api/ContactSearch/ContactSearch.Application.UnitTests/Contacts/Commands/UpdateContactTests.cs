using AutoMapper;
using ContactSearch.Application.Features.Contacts.Commands.UpdateCommand;
using ContactSearch.Application.Persistence;
using ContactSearch.Application.Profiles;
using ContactSearch.Domain.Entities;
using Moq;
using Shouldly;

namespace ContactSearch.Application.UnitTests.Contacts.Commands
{
    public class UpdateContactTests
    {
        private readonly Mock<IAsyncRepository<Contact>> _mockContactRepository;
        private readonly IMapper _mapper;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;

        public UpdateContactTests()
        {
            _mockContactRepository = Mocks.ContactRepositoryMock.GetContactRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _updateContactCommandHandler = new UpdateContactCommandHandler(_mockContactRepository.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ValidRequest_UpdatesContact()
        {
            // Arrange
            var request = new UpdateContactCommand
            {
                ContactId = Guid.NewGuid(),
                FirstName = "William",
                LastName = "Velida",
                DateOfBirth = new DateTime(1991, 3, 5)
            };

            var contactToUpdate = new Contact
            {
                ContactId = request.ContactId,
                FirstName = "Will",
                LastName = "Velida",
                DateOfBirth = new DateTime(1991, 3, 5)
            };

            _mockContactRepository.Setup(repo => repo.GetByIdAsync(request.ContactId)).ReturnsAsync(contactToUpdate);

            // Act
            var result = await _updateContactCommandHandler.Handle(request, CancellationToken.None);

            // Assert
            _mockContactRepository.Verify(repo => repo.UpdateAsync(contactToUpdate), Times.Once());
            result.Success.ShouldBeTrue();
            result.Contact.FirstName.ShouldBe(request.FirstName);
            result.ValidationErrors.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_InvalidRequest_ReturnsValidationErrors()
        {
            // Arrange
            var command = new UpdateContactCommand();

            // Act
            var response = await _updateContactCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Success.ShouldBeFalse();
            response.Contact.ShouldBeNull();
            response.ValidationErrors.ShouldNotBeNull();
            response.ValidationErrors.ShouldContain("First Name is required");
            response.ValidationErrors.ShouldContain("First Name must be at least 2 characters");
            response.ValidationErrors.ShouldContain("Last Name is required");
            response.ValidationErrors.ShouldContain("Last Name must be at least 2 characters");
            response.ValidationErrors.ShouldContain("Date Of Birth is required");
        }
    }
}
