using ContactSearch.Application.Features.Addresses.Commands.CreateAddress;
using ContactSearch.Application.Features.Contact.Queries.GetContactById;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ContactSearch.Api.EndpointHandlers
{
    public static class AddressHandlers
    {
        public static async Task<Results<NotFound, Ok<CreateAddressCommandResponse>>> CreateAddressAsync(IMediator mediator, 
            Guid contactId,
            CreateAddressDto createAddressDto)
        {
            var getContactByIdQuery = new GetContactByIdQuery(contactId);
            var contact = await mediator.Send(getContactByIdQuery);

            if (contact == null)
            {
                return TypedResults.NotFound();
            }

            var createAddressCommand = new CreateAddressCommand
            {
                ContactId = contactId,
                AddressLine1 = createAddressDto.AddressLine1,
                AddressLine2 = createAddressDto.AddressLine2,
                City = createAddressDto.City,
                State = createAddressDto.State,
                ZipCode = createAddressDto.ZipCode,
                Country = createAddressDto.Country,
            };

            var response = await mediator.Send(createAddressCommand);
            return TypedResults.Ok(response);
        }
    }
}
