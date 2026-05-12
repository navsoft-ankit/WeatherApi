using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;
namespace Test.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeather _repo;
    public WeatherController(IWeather repo)
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
    [HttpDelete]
    public IActionResult Delete(Weather weather)
    {
        bool data = _repo.Delete(weather);

        if (data)
            return Ok("Deleted Successfully");

        return BadRequest("Delete Failed");
    }
}