using AspNetMinimalApi.WeatherForecasts.Domain.Entities;
using System.Collections.Generic;

namespace AspNetMinimalApi.WeatherForecasts.Domain.Abstractions
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecastEntity>> GetForecasts();
    }
}
