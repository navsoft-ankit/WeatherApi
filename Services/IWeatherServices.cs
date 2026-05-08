using Test.Models;

namespace Test.Services
{
    public interface IWeatherService
    {
        IEnumerable<Weather> GetForecast();
        void AddWeather(Weather weather);
    }
}