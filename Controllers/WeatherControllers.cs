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

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result =
            await _repo.GetAllAsync();

        return Ok(result);
    }

    // INSERT
    [HttpPost]
    public async Task<IActionResult> Add(
        Weather weather)
    {
        bool data =
            await _repo.AddAsync(weather);

        if (data)
        {
            return Ok("Data Inserted");
        }

        return BadRequest("Insert Failed");
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var weather =
            await _repo.GetByIdAsync(id);

        if (weather == -1)
        {
            return NotFound("Data Not Found");
        }

        bool data =
            await _repo.DeleteAsync(id);

        if (data)
        {
            return Ok("Deleted Successfully");
        }

        return BadRequest("Delete Failed");
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        Weather weather)
    {
        var existingWeather =
            await _repo.GetByIdAsync(id);

        if (existingWeather == -1)
        {
            return NotFound("Data Not Found");
        }

        bool data =
            await _repo.UpdateAsync(id, weather);

        if (data)
        {
            return Ok("Updated Successfully");
        }

        return BadRequest("Update Failed");
    }
}