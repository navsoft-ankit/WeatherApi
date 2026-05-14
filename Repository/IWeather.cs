using Test.Models;

namespace Test.Repositories;

public interface IWeather
{
    IEnumerable<Weather> GetAll();
    int GetById(int id);
    bool Add(Weather weather);
    bool Delete(int Id);
    bool update(Weather weather);

}