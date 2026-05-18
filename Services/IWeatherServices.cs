using Test.Models;

namespace Test.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<Weather>> GetForecastAsync();

        Task AddWeatherAsync(Weather weather);

        Task DeleteWeatherAsync(int id);

        Task UpdateWeatherAsync(int id, Weather weather);
    }
}