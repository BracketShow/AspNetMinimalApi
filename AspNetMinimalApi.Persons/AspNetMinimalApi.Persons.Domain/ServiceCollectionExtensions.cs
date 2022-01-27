using AspNetMinimalApi.Persons.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetMinimalApi.Persons.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersonsDomain(this IServiceCollection services)
            => services.AddSingleton<IPersonService, PersonService>();
    }
}
