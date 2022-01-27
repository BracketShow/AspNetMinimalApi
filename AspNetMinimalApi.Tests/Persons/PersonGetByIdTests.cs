namespace AspNetMinimalApi.Persons;

public class PersonGetByIdTests : IClassFixture<MinimalApiApplicationFixture<Program>>, IAsyncLifetime
{
    private readonly MinimalApiApplicationFixture<Program> fixture;
    private HttpResponseMessage responseMessage = default!;
    private readonly Guid personId = Guid.NewGuid();

    public PersonGetByIdTests(MinimalApiApplicationFixture<Program> fixture) => this.fixture = fixture;

    public Task DisposeAsync() => Task.CompletedTask;
    public async Task InitializeAsync()
    {
        await fixture.AuthenticateClient();
        await fixture.HttpClient.PostAsJsonAsync("/api/person", new Person { Id = personId, FirstName = "Bruno", LastName = "Barrette" });

        responseMessage = await fixture.HttpClient.GetAsync($"/api/person/{personId}");
    }

    [Fact]
    public void Get_ShouldReturnOkResult() => responseMessage.StatusCode.Should().Be(HttpStatusCode.OK);

    [Fact]
    public async Task Get_ShouldReturnThePerson() =>
        (await responseMessage.Content.ReadFromJsonAsync<Person>())!.FirstName.Should().Be("Bruno");

    [Fact]
    public async Task Get_ShouldReturnANotFoundResponse_WhenThePersonDoesNotExist() =>
        (await fixture.HttpClient.GetAsync($"/api/person/{Guid.NewGuid()}"))!.StatusCode.Should().Be(HttpStatusCode.NotFound);
}
