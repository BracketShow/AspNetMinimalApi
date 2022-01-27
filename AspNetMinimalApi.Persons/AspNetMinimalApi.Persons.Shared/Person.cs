namespace AspNetMinimalApi.Persons.Shared;

public record Person
{
    public Guid? Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
}
