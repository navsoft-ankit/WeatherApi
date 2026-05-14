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
    [HttpDelete("{id}")]
    public IActionResult Delete(int Id)
    {
        var Weather = _repo.GetById(Id);
        if (Weather == null)
            return NotFound();
        
        bool data = _repo.Delete(Id);
        if (data)
            return Ok("Deleted Successfully");

        return BadRequest("Delete Failed");
    }
    [HttpPut("{id}")]
    public IActionResult Update(int Id, Weather weather)
    {
        var existingWeather = _repo.GetById(Id);
        if (existingWeather == null)
            return NotFound();
        string ab = "Update";
    
        bool data = _repo.update(Id, weather, ab);
        if (data)
            return Ok("Updated Successfully");

        return BadRequest("Update Failed");
    }
}