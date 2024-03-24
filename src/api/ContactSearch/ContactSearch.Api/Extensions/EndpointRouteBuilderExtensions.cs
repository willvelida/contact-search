using ContactSearch.Api.EndpointHandlers;
using ContactSearch.Application.Features.Contacts.Commands.CreateContacts;

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
        }
    }
}
