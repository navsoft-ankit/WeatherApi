using Test.Models;

namespace Test.Repositories;

public interface IWeather
{
    Task<IEnumerable<Weather>> GetAllAsync();

    Task<bool> AddAsync(Weather weather);

    Task<bool> DeleteAsync(int id);

    Task<bool> UpdateAsync(int id, Weather weather);

    Task<Weather> GetByIdAsync(int id, Weather weather);
}