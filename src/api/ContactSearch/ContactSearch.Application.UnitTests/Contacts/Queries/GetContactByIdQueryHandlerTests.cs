using AutoMapper;
using ContactSearch.Application.Features.Contact.Queries.GetContactById;
using ContactSearch.Application.Persistence;
using ContactSearch.Application.Profiles;
using ContactSearch.Domain.Entities;
using Moq;
using Shouldly;

namespace ContactSearch.Application.UnitTests.Contacts.Queries
{
    public class GetContactByIdQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Contact>> _mockContactRepository;
        private readonly Mock<IAddressRepository> _mockAddressRepository;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;

        public GetContactByIdQueryHandlerTests()
        {
            _mockContactRepository = Mocks.ContactRepositoryMock.GetContactRepository();
            _mockAddressRepository = new Mock<IAddressRepository>();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

            _getContactByIdQueryHandler = new GetContactByIdQueryHandler(_mapper, _mockContactRepository.Object, _mockAddressRepository.Object);
        }

        [Fact]
        public async Task Handle_ReturnsCorrectViewModel()
        {
            // Arrange
            var contact = new Contact()
            {
                ContactId = new Guid(),
                FirstName = "Will",
                LastName = "Velida",
                DateOfBirth = new DateTime(1991, 3, 5),
            };

            var query = new GetContactByIdQuery(contact.ContactId);

            _mockContactRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(contact);

            // Act
            var result = await _getContactByIdQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<GetContactByIdViewModel>();
            result.ContactId.ShouldBe(contact.ContactId);
            result.FirstName.ShouldBe(contact.FirstName);
            result.LastName.ShouldBe(contact.LastName);
            result.DateOfBirth.ShouldBe(contact.DateOfBirth);
        }
    }
}
