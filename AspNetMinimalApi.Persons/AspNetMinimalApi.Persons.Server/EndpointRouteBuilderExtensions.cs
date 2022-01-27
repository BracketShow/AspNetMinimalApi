using AspNetMinimalApi.Persons.Domain.Abstractions;
using AspNetMinimalApi.Persons.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AspNetMinimalApi.Persons.Server;

public static class EndpointRouteBuilderExtensions
{
    public static void AddPersonEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder
            .MapGet(
                Routes.Person,
                (IPersonService personService) => personService.GetPersons().Select(f => f.ToPerson()))
            .AllowAnonymous()
            .WithTags("Person");

        endpointRouteBuilder
            .MapGet(
                $"{Routes.Person}/{{id}}",
                (IPersonService personService, Guid id) =>
                {
                    var person = personService.GetPerson(id);
                    return person is not null ? Results.Ok(person.ToPerson()) : Results.NotFound();
                })
            .AllowAnonymous()
            .WithTags("Person");

        endpointRouteBuilder
            .MapPost(
                Routes.Person,
                (IPersonService personService, Person person) =>
                {
                    personService.Add(person.ToPersonEntity());
                    return Results.Created($"{Routes.Person}/{person.Id}", person);
                })
            .RequireAuthorization()
            .WithTags("Person")
            .WithName("AddPerson")
            .ProducesValidationProblem()
            .Produces<Person>(StatusCodes.Status201Created);

        endpointRouteBuilder
            .MapDelete(
                $"{Routes.Person}/{{id}}",
                (IPersonService personService, Guid id) => personService.Delete(id) ? Results.Ok() : Results.NotFound())
            .RequireAuthorization("CanDeletePersonPolicy")
            .WithTags("Person")
            .ExcludeFromDescription();
    }
}
