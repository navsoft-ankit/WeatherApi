using Test.Models;

namespace Test.Repositories;

public interface IWeather
{
    IEnumerable<Weather> GetAll();
    bool Add(Weather weather);
    bool Delete(Weather weather);

}