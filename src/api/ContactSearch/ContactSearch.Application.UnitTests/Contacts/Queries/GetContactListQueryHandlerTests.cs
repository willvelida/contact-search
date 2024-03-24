using AutoMapper;
using ContactSearch.Application.Features.Contacts.Queries.GetContactsList;
using ContactSearch.Application.Persistence;
using ContactSearch.Application.Profiles;
using ContactSearch.Domain.Entities;
using Moq;
using Shouldly;

namespace ContactSearch.Application.UnitTests.Contacts.Queries
{
    public class GetContactListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Contact>> _mockContactRepository;
        private readonly GetContactListQueryHandler _getContactListQueryHandler;

        public GetContactListQueryHandlerTests()
        {
            _mockContactRepository = Mocks.ContactRepositoryMock.GetContactRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

            _getContactListQueryHandler = new GetContactListQueryHandler(_mapper, _mockContactRepository.Object);
        }

        [Fact]
        public async Task GetContactsListTest()
        {
            // Act
            var result = await _getContactListQueryHandler.Handle(new GetContactListQuery(), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<ContactListViewModel>>();
            result.Count.ShouldBe(1);
        }
    }
}
