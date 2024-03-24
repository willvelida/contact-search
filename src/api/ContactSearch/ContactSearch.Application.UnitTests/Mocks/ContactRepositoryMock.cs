using ContactSearch.Application.Persistence;
using ContactSearch.Domain.Entities;
using Moq;

namespace ContactSearch.Application.UnitTests.Mocks
{
    public class ContactRepositoryMock
    {
        public static Mock<IAsyncRepository<Contact>> GetContactRepository()
        {
            var willGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");

            var contacts = new List<Contact>
            {
                new Contact
                {
                    ContactId = willGuid,
                    FirstName = "Will",
                    LastName = "Velida",
                    DateOfBirth = new DateTime(1991,3,5)
                }
            };

            var mockContactRepository = new Mock<IAsyncRepository<Contact>>();
            mockContactRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(contacts);

            mockContactRepository.Setup(repo => repo.AddAsync(It.IsAny<Contact>())).ReturnsAsync(
                (Contact contact) =>
                {
                    contacts.Add(contact);
                    return contact;
                });

            return mockContactRepository;
        }
    }
}
