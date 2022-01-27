namespace AspNetMinimalApi.Persons;

public class PersonGetTests : IClassFixture<MinimalApiApplicationFixture<Program>>, IAsyncLifetime
{
    private readonly MinimalApiApplicationFixture<Program> fixture;
    private HttpResponseMessage responseMessage = default!;

    public PersonGetTests(MinimalApiApplicationFixture<Program> fixture) => this.fixture = fixture;

    public Task DisposeAsync() => Task.CompletedTask;

    public async Task InitializeAsync()
    {
        await fixture.AuthenticateClient();
        await fixture.HttpClient.PostAsJsonAsync("/api/person", new Person { Id = Guid.NewGuid(), FirstName = "Bruno", LastName = "Barrette" });

        responseMessage = await fixture.HttpClient.GetAsync("/api/person");
    }

    [Fact]
    public void Get_ShouldReturnOkResult() => responseMessage.StatusCode.Should().Be(HttpStatusCode.OK);

    [Fact]
    public async Task Get_ShouldReturnTheListOfPerson() => (await responseMessage.Content.ReadFromJsonAsync<Person[]>())!.Should().NotBeEmpty();
}
