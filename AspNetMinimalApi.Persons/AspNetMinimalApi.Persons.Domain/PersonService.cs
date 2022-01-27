using AspNetMinimalApi.Persons.Domain.Abstractions;
using AspNetMinimalApi.Persons.Domain.Entities;

namespace AspNetMinimalApi.Persons.Domain;

internal class PersonService : IPersonService
{
    private List<PersonEntity> people = new();

    public void Add(PersonEntity person) => people.Add(person);

    public bool Delete(Guid id)
    {
        var canBeDeleted = people.SingleOrDefault(p => p.Id == id) != null;
        people = people.Where(p => p.Id != id).ToList();
        return canBeDeleted;
    }

    public PersonEntity? GetPerson(Guid id) => people.SingleOrDefault(p => p.Id == id);

    public IEnumerable<PersonEntity> GetPersons() => people;
}
