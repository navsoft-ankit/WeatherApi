using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeather _repo;

        public WeatherService(IWeather repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Weather>> GetForecastAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task AddWeatherAsync(Weather weather)
        {
            await _repo.AddAsync(weather);
        }

        public async Task DeleteWeatherAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task UpdateWeatherAsync(int id, Weather weather)
        {
            await _repo.UpdateAsync(id, weather);
        }
    }
}