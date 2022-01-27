using Microsoft.AspNetCore.Builder;

namespace AspNetMinimalApi.Security.Server;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseServerAuthentication(this IApplicationBuilder app) =>
        app.UseAuthentication().UseAuthorization();
}
