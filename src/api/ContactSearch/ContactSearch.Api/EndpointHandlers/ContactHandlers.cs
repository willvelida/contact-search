﻿using ContactSearch.Application.Features.Contact.Commands.UpdateCommand;
using ContactSearch.Application.Features.Contact.Queries.GetContactById;
using ContactSearch.Application.Features.Contacts.Commands.CreateContacts;
using ContactSearch.Application.Features.Contacts.Commands.DeleteContactById;
using ContactSearch.Application.Features.Contacts.Commands.UpdateCommand;
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

        public static async Task<Results<NotFound, Ok<GetContactByIdViewModel>>> GetContactById(IMediator mediator, Guid contactId)
        {
            var getContactByIdQuery = new GetContactByIdQuery(contactId);
            var contact = await mediator.Send(getContactByIdQuery);

            if (contact == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(contact);
        }

        public static async Task<Results<NotFound, NoContent>> UpdateContactAsync(
            IMediator mediator,
            Guid contactId,
            UpdateContactDto updateContactDto)
        {
            var getContactByIdQuery = new GetContactByIdQuery(contactId);
            var contact = await mediator.Send(getContactByIdQuery);

            if (contact == null)
            {
                return TypedResults.NotFound();
            }

            var updateContactCommand = new UpdateContactCommand
            {
                ContactId = contactId,
                FirstName = updateContactDto.FirstName,
                LastName = updateContactDto.LastName,
                DateOfBirth = updateContactDto.DateOfBirth,
            };

            await mediator.Send(updateContactCommand);
            return TypedResults.NoContent();
        }

        public static async Task<Results<NotFound, NoContent>> DeleteContactAsync(IMediator mediator, Guid contactId)
        {
            var getContactByIdQuery = new GetContactByIdQuery(contactId);
            var contact = await mediator.Send(getContactByIdQuery);

            if (contact == null)
            {
                return TypedResults.NotFound();
            }

            var deleteCommand = new DeleteContactCommand() { ContactId = contactId };
            await mediator.Send(deleteCommand);
            return TypedResults.NoContent();
        }
    }
}
