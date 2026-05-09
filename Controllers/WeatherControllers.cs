using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;
namespace test.Conrollers;
[ApiController]
[Route("Controller")]
public class WeatherContoller : ControllerBase
{
    private readonly IWeather _repo;
    public WeatherContoller(IWeather repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var Result = _repo.GetAll();
        return Ok(Result);
    }

    [HttpPost]
    public IActionResult Add(Weather weather)
    {
        bool data = _repo.Add(weather);
        if(data)
        {
            return Ok("Data Inserted");
        }
        else
        {
            return BadRequest("Data Not Inserted");
        }
    }
}