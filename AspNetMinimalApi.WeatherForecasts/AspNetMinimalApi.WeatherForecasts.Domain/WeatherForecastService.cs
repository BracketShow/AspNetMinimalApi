using AspNetMinimalApi.WeatherForecasts.Domain.Abstractions;
using AspNetMinimalApi.WeatherForecasts.Domain.Entities;

namespace AspNetMinimalApi.WeatherForecasts.Domain
{
    internal class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<IEnumerable<WeatherForecastEntity>> GetForecasts() =>
            Task.FromResult<IEnumerable<WeatherForecastEntity>>(
                Enumerable.Range(1, 5).Select(index => new WeatherForecastEntity
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray());
    }
}
