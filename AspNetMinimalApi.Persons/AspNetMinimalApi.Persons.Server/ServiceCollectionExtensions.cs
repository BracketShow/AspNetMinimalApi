using AspNetMinimalApi.Persons.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetMinimalApi.Persons.Server
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersonsModule(this IServiceCollection services) =>
            services.AddPersonsDomain();
    }
}
