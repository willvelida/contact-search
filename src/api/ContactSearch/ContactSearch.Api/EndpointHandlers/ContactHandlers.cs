using ContactSearch.Application.Features.Contacts.Commands.CreateContacts;
using ContactSearch.Application.Features.Contacts.Queries.GetContactsList;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ContactSearch.Api.EndpointHandlers
{
    public static class ContactHandlers
    {
        public static async Task<Ok<CreateContactCommandResponse>> CreateContactAsync(IMediator mediator, CreateContactCommand createContactCommand)
        {
            var response = await mediator.Send(createContactCommand);
            return TypedResults.Ok(response);
        }

        public static async Task<Ok<List<ContactListViewModel>>> GetAllContacts(IMediator mediator)
        {
            var contacts = await mediator.Send(new GetContactListQuery());
            return TypedResults.Ok(contacts);
        }
    }
}
