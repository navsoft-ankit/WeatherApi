using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeather _repo;

    public WeatherController(IWeather repo)
    {
        _repo = repo;
    }

    // GET: api/weather
    [HttpGet]
    public IActionResult Get()
    {
        var data = _repo.GetAll();

        return Ok(data);
    }

    // POST: api/weather
    [HttpPost]
    public IActionResult Add(Weather weather)
    {
        bool saved = _repo.Add(weather);

        if (saved)
            return Ok("Data stored successfully");

        return BadRequest("Data not stored");
    }
}