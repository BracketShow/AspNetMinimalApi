using AspNetMinimalApi.Persons.Domain.Entities;

namespace AspNetMinimalApi.Persons.Domain.Abstractions;

public interface IPersonService
{
    IEnumerable<PersonEntity> GetPersons();
    PersonEntity? GetPerson(Guid id);
    bool Delete(Guid id);
    void Add(PersonEntity person);
}
