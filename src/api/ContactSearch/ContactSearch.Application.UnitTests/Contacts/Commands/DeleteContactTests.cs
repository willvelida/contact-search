using ContactSearch.Application.Features.Contacts.Commands.DeleteContactById;
using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;
using Moq;
using Shouldly;

namespace ContactSearch.Application.UnitTests.Contacts.Commands
{
    public class DeleteContactTests
    {
        private readonly Mock<IAsyncRepository<Contact>> _mockContactRepository;
        private readonly DeleteContactCommandHandler _deleteContactCommandHandler;

        public DeleteContactTests()
        {
            _mockContactRepository = Mocks.ContactRepositoryMock.GetContactRepository();

            _deleteContactCommandHandler = new DeleteContactCommandHandler(_mockContactRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_DeletesContact()
        {
            // Arrange
            var contactId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            _mockContactRepository.Setup(repo => repo.GetByIdAsync(contactId)).ReturnsAsync(It.IsAny<Contact>());

            var deleteRequest = new DeleteContactCommand() { ContactId = contactId };

            // Act
            await _deleteContactCommandHandler.Handle(deleteRequest, CancellationToken.None);

            // Assert
            _mockContactRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Contact>()), Times.Once);
        }        
    }
}
