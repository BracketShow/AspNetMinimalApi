namespace AspNetMinimalApi.Persons;

public class PersonPostTests : IClassFixture<MinimalApiApplicationFixture<Program>>, IAsyncLifetime
{
    private readonly MinimalApiApplicationFixture<Program> fixture;
    private HttpResponseMessage responseMessage = default!;
    private readonly Guid personId = Guid.NewGuid();

    public PersonPostTests(MinimalApiApplicationFixture<Program> fixture) => this.fixture = fixture;

    public Task DisposeAsync() => Task.CompletedTask;
    public async Task InitializeAsync()
    {
        await fixture.AuthenticateClient();
        responseMessage = await fixture.HttpClient.PostAsJsonAsync("/api/person", new Person { Id = personId, FirstName = "Bruno", LastName = "Barrette" });
    }

    [Fact]
    public void Post_ShouldReturnCreatedResult() => responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);

    [Fact]
    public async Task PostPerson_ShouldAddThePerson() =>
        (await fixture.HttpClient.GetFromJsonAsync<Person>($"/api/person/{personId}"))!.FirstName.Should().Be("Bruno");

    [Fact]
    public async Task PostPerson_ShouldAddThePerson_WhenNoIdWasSpecified() =>
        (await fixture.HttpClient.PostAsJsonAsync("/api/person", new Person { FirstName = "TestFirstName", LastName = "TestLastName" }))!.StatusCode.Should().Be(HttpStatusCode.Created);
}
