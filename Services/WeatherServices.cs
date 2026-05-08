using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeather _repo;

        private static readonly string[] Summaries =
        {
            "Freezing","Bracing","Chilly","Cool","Mild",
            "Warm","Balmy","Hot","Sweltering","Scorching"
        };

        public WeatherService(IWeather repo)
        {
            _repo = repo;
        }

        public IEnumerable<Weather> GetForecast()
        {
            var data = Enumerable.Range(1, 5)
                .Select(i => new Weather
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i)).ToString(),
                    Temp = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();

            return data;
        }

        public void AddWeather(Weather weather)
        {
            //_repo.Add(weather);
        }
    }
}