using AspNetMinimalApi.WeatherForecasts.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetMinimalApi.WeatherForecasts.Server
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeatherForecastsModule(this IServiceCollection services) =>
            services.AddWeatherForecastsDomain();
    }
}
