namespace AspNetMinimalApi.Persons.Domain.Entities;

public record PersonEntity
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
}
