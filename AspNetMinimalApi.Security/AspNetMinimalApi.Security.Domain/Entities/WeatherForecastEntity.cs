using System;

namespace AspNetMinimalApi.Security.Domain.Entities
{
    public record WeatherForecastEntity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; } = string.Empty;
    }
}
