using AspNetMinimalApi.Persons.Server;
using AspNetMinimalApi.Security.Server;
using AspNetMinimalApi.WeatherForecasts.Server;

namespace AspNetMinimalApi.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationModules(this IServiceCollection services)
        => services.AddWeatherForecastsModule()
            .AddPersonsModule()
            .AddSecurityModule();
}
