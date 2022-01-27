using AspNetMinimalApi.Persons.Domain.Entities;
using AspNetMinimalApi.Persons.Shared;

namespace AspNetMinimalApi.Persons.Server
{
    public static class PersonMapper
    {
        public static Person ToPerson(this PersonEntity entity) => new()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName
        };

        public static PersonEntity ToPersonEntity(this Person person) => new()
        {
            Id = person.Id ?? Guid.NewGuid(),
            FirstName = person.FirstName,
            LastName = person.LastName
        };
    }
}
