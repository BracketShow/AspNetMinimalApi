using AspNetMinimalApi.Security.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetMinimalApi.Security.Server;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSecurityModule(this IServiceCollection services) =>
        services.AddSecurityDomain();
}
