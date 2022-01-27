using AspNetMinimalApi.Security.Server;

namespace AspNetMinimalApi.Server.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApplicationModules(this IApplicationBuilder app) =>
        app.UseServerAuthentication();
}