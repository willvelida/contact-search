﻿using AutoMapper;
using ContactSearch.Application.Features.EmailAddress.Commands.CreateEmailAddress;
using ContactSearch.Application.Persistence;
using ContactSearch.Application.Profiles;
using ContactSearch.Domain.Entities;
using Moq;
using Shouldly;

namespace ContactSearch.Application.UnitTests.EmailAddress.Commands
{
    public class CreateEmailAddressTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Email>> _mockEmailRepository;
        private readonly CreateEmailAddressCommandHandler _createEmailAddressCommandHandler;

        public CreateEmailAddressTests()
        {
            _mockEmailRepository = new Mock<IAsyncRepository<Email>>();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _createEmailAddressCommandHandler = new CreateEmailAddressCommandHandler(_mapper, _mockEmailRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new CreateEmailAddressCommand { EmailAddress = "test@example.com" };

            _mockEmailRepository.Setup(repo => repo.AddAsync(It.IsAny<Email>())).ReturnsAsync(new Email { EmailId = Guid.NewGuid(), EmailAddress = "test@example.com" });

            // Act
            var response = await _createEmailAddressCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Success.ShouldBeTrue();
            response.Email.ShouldNotBeNull();
            response.Email.EmailAddress.ShouldBe(command.EmailAddress);
            response.ValidationErrors.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_InvalidCommand_ReturnsValidationError_NoEmailAddress()
        {
            // Arrange
            var command = new CreateEmailAddressCommand();

            // Act
            var response = await _createEmailAddressCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Success.ShouldBeFalse();
            response.Email.ShouldBeNull();
            response.ValidationErrors.ShouldNotBeNull();
            response.ValidationErrors.ShouldContain("Email Address is required");
        }
    }
}
