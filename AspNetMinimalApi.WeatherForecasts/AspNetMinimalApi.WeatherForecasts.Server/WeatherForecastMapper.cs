using AspNetMinimalApi.WeatherForecasts.Shared;
using AspNetMinimalApi.WeatherForecasts.Domain.Entities;

namespace AspNetMinimalApi.WeatherForecasts.Server
{
    public static class WeatherForecastMapper
    {
        public static WeatherForecast ToWeatherForecast(this WeatherForecastEntity entity) => new()
        {
            Date = entity.Date,
            TemperatureC = entity.TemperatureC,
            Summary = entity.Summary
        };
    }
}
