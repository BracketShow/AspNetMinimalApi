using AspNetMinimalApi.Security.Shared;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;

namespace AspNetMinimalApi;

public class MinimalApiApplicationFixture<TProgram> where TProgram : class
{
    public MinimalApiApplicationFixture() =>
        HttpClient = new AspNetMinimalApiApplication().CreateClient();

    public HttpClient HttpClient { get; }

    public async Task AuthenticateClient()
    {
        HttpResponseMessage loginResponse = await HttpClient.PostAsJsonAsync("/api/login", new UserLogin { Username = "bbarrette" });
        LoginResult? loginResult = await loginResponse.Content.ReadFromJsonAsync<LoginResult>();

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult?.Token ?? string.Empty);
    }

    private class AspNetMinimalApiApplication : WebApplicationFactory<TProgram>
    {
        protected override IHost CreateHost(IHostBuilder builder) => base.CreateHost(builder);
    }
}
