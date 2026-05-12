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

        public IEnumerable<Weather> GetForecast()
        {
            return _repo.GetAll();
        }

        public void AddWeather(Weather weather)
        {
            _repo.Add(weather);
        }
    }
}