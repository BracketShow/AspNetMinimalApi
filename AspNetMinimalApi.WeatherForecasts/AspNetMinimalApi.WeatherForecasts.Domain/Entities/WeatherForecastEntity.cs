using System;

namespace AspNetMinimalApi.WeatherForecasts.Domain.Entities
{
    public record WeatherForecastEntity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; } = string.Empty;
    }
}
