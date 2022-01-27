using AspNetMinimalApi.Persons.Server;
using AspNetMinimalApi.Security.Server;
using AspNetMinimalApi.WeatherForecasts.Server;

namespace AspNetMinimalApi.Server.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void AddApplicationEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.AddWeatherForecastEndpoints();
            endpointRouteBuilder.AddPersonEndpoints();
            endpointRouteBuilder.AddSecurityEndpoints();
        }
    }
}
