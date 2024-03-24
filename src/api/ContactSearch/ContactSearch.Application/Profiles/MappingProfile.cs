using AutoMapper;
using ContactSearch.Application.Features.Addresses.Commands.CreateAddress;
using ContactSearch.Application.Features.Contacts.Commands.CreateContacts;
using ContactSearch.Application.Features.EmailAddress.Commands.CreateEmailAddress;
using ContactSearch.Application.Features.PhoneNumbers.Commands;
using ContactSearch.Domain.Entities;

namespace ContactSearch.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Email, CreateEmailAddressDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Phone, CreatePhoneNumberDto>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();
        }
    }
}
