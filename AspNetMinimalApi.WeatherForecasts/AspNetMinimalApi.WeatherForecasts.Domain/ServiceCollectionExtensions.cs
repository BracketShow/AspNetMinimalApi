using AspNetMinimalApi.WeatherForecasts.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetMinimalApi.WeatherForecasts.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeatherForecastsDomain(this IServiceCollection services)
            => services.AddScoped<IWeatherForecastService, WeatherForecastService>();
    }
}
