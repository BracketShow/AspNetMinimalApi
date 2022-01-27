using AspNetMinimalApi.Security.Domain.Abstractions;
using AspNetMinimalApi.Security.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace AspNetMinimalApi.Security.Server;

public static class EndpointRouteBuilderExtensions
{
    public static void AddSecurityEndpoints(this IEndpointRouteBuilder endpointRouteBuilder) =>
        endpointRouteBuilder.MapPost(Routes.Login, (IJwtTokenGenerator jwtTokenGenerator, UserLogin userLogin) =>
        {
            var token = jwtTokenGenerator.GenerateTokenAsync(userLogin.Username);

            return LoginResult.ValidLogin(token);
        }).AllowAnonymous();
}
