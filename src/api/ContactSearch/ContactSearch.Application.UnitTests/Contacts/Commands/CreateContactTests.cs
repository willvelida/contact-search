using AutoMapper;
using ContactSearch.Application.Features.Contacts.Commands.CreateContacts;
using ContactSearch.Application.Persistence;
using ContactSearch.Application.Profiles;
using ContactSearch.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSearch.Application.UnitTests.Contacts.Commands
{
    public class CreateContactTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Contact>> _mockContactRepository;
        private readonly CreateContactCommandHandler _createContactCommandHandler;

        public CreateContactTests()
        {
            _mockContactRepository = new Mock<IAsyncRepository<Contact>>();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _createContactCommandHandler = new CreateContactCommandHandler(_mapper, _mockContactRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new CreateContactCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1991, 1, 1)
            };
            var contactGuid = new Guid();
            var contact = new Contact() { ContactId = contactGuid, FirstName = command.FirstName, LastName = command.LastName, DateOfBirth = command.DateOfBirth };     

            _mockContactRepository.Setup(repo => repo.AddAsync(It.IsAny<Contact>())).ReturnsAsync(contact);

            // Act
            var response = await _createContactCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Success.ShouldBeTrue();
            response.Contact.ShouldNotBeNull();
            response.Contact.ContactId.ShouldBe(contactGuid);
            response.Contact.FirstName.ShouldBe(command.FirstName);
            response.Contact.LastName.ShouldBe(command.LastName);
            response.Contact.DateOfBirth.ShouldBe(command.DateOfBirth);
            response.ValidationErrors.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var command = new CreateContactCommand();

            // Act
            var response = await _createContactCommandHandler.Handle(command, CancellationToken.None);

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
