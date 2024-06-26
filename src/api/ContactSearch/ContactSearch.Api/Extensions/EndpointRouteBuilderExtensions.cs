﻿using ContactSearch.Api.EndpointHandlers;
using ContactSearch.Application.Features.Contacts.Commands.CreateContacts;
using ContactSearch.Application.Features.Contacts.Commands.UpdateCommand;

namespace ContactSearch.Api.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterContactEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var contactEndpoints = endpointRouteBuilder.MapGroup("/contact");

            // CREATE
            contactEndpoints.MapPost("", ContactHandlers.CreateContactAsync)
                .WithName("CreateContact")
                .Accepts<CreateContactCommand>("application/json")
                .Produces(StatusCodes.Status201Created)
                .WithOpenApi()
                .WithSummary("Create a contact");

            // GET
            contactEndpoints.MapGet("", ContactHandlers.GetAllContacts)
                .WithName("GetAllContacts")
                .Produces(StatusCodes.Status200OK)
                .WithOpenApi()
                .WithSummary("Retrieves all contacts");

            // GET : ID
            contactEndpoints.MapGet("/{contactId:guid}", ContactHandlers.GetContactById)
                .WithName("GetContact")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithOpenApi()
                .WithSummary("Retrieves a contact by a given ID");

            // DELETE : ID
            contactEndpoints.MapDelete("/{contactId:guid}", ContactHandlers.DeleteContactAsync)
                .WithName("DeleteContact")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithOpenApi()
                .WithName("Deletes a Contact by a given ID");

            // UPDATE
            contactEndpoints.MapPut("/{contactId:guid}", ContactHandlers.UpdateContactAsync)
                .WithName("UpdateContact")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithOpenApi()
                .WithName("Updates a contact by a given ID");

        }

        public static void RegisterAddressEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var addressEndpoints = endpointRouteBuilder.MapGroup("/contact/{contactId:guid}/address");

            // CREATE
            addressEndpoints.MapPost("", AddressHandlers.CreateAddressAsync)
                .WithName("CreateAddress")
                .Accepts<UpdateContactCommand>("application/json")
                .Produces(StatusCodes.Status201Created)
                .WithOpenApi()
                .WithSummary("Create an address for a contact");
        }
    }
}
