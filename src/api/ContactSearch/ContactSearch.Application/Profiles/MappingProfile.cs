using AutoMapper;
using ContactSearch.Application.Features.Addresses.Commands.CreateAddress;
using ContactSearch.Application.Features.Contact.Commands.UpdateCommand;
using ContactSearch.Application.Features.Contact.Queries.GetContactById;
using ContactSearch.Application.Features.Contacts.Commands.CreateContacts;
using ContactSearch.Application.Features.Contacts.Commands.UpdateCommand;
using ContactSearch.Application.Features.Contacts.Queries.GetContactsList;
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
            CreateMap<Contact, ContactListViewModel>();
            CreateMap<Contact, GetContactByIdViewModel>();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            CreateMap<Phone, CreatePhoneNumberDto>().ReverseMap();

            CreateMap<Address, CreateAddressDto>().ReverseMap();
        }
    }
}
