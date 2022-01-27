namespace AspNetMinimalApi.Persons;

public class PersonDeleteTests : IClassFixture<MinimalApiApplicationFixture<Program>>, IAsyncLifetime
{
    private readonly MinimalApiApplicationFixture<Program> fixture;
    private HttpResponseMessage responseMessage = default!;
    private readonly Guid personId = Guid.NewGuid();

    public PersonDeleteTests(MinimalApiApplicationFixture<Program> fixture) => this.fixture = fixture;
    public async Task InitializeAsync()
    {
        await fixture.AuthenticateClient();
        await fixture.HttpClient.PostAsJsonAsync("/api/person", new Person { Id = personId, FirstName = "Bruno", LastName = "Barrette" });

        responseMessage = await fixture.HttpClient.DeleteAsync($"/api/person/{personId}");
    }

    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public void Delete_ShouldReturnAnOkStatusCode_WhenPersonDeleted() => responseMessage.StatusCode.Should().Be(HttpStatusCode.OK);

    [Fact]
    public async Task Delete_ShouldDeleteThePerson_WhenThePersonExists() =>
        (await fixture.HttpClient.GetAsync($"/api/person/{personId}"))!.StatusCode.Should().Be(HttpStatusCode.NotFound);

    [Fact]
    public async Task Delete_ShouldReturnNotFound_WhenThePersonDoesNotExist() =>
        (await fixture.HttpClient.DeleteAsync($"/api/person/{Guid.NewGuid()}")).StatusCode.Should().Be(HttpStatusCode.NotFound);
}
