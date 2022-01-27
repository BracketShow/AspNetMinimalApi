using AspNetMinimalApi.WeatherForecasts.Domain.Abstractions;
using AspNetMinimalApi.WeatherForecasts.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace AspNetMinimalApi.WeatherForecasts.Server;

public static class EndpointRouteBuilderExtensions
{
    public static void AddWeatherForecastEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder
            .MapGet(
                Routes.WeatherForecast,
                async (IWeatherForecastService weatherForecastService) =>
                    (await weatherForecastService.GetForecasts()).Select(f => f.ToWeatherForecast()))
            .AllowAnonymous();
    }
}
