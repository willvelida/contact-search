using AutoMapper;
using ContactSearch.Application.Features.Contacts.Commands.CreateContacts;
using ContactSearch.Application.Features.EmailAddress.Commands.CreateEmailAddress;
using ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Email, CreateEmailAddressDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
        }
    }
}
