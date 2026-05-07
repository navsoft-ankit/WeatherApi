using Microsoft.AspNetCore.Mvc;
using Test.Models;
namespace Test.Controllers
{
    [ApiController]
    [Route("api/Weather")]
    public class WeatherForcast : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        [HttpGet]
        public ActionResult<IEnumerable<Weather>>Get()
        {
                var data = Enumerable.Range(1, 5)
                .Select(index => new Weather
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Temp = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
            return Ok(data);
        }
        [HttpPost]
        public ActionResult AddWeather([FromBody]Weather weather)
        {
            if(weather == null)
            {
                return BadRequest("Invalid");
            }
            return Created("api/Weather",weather);
        }

    }
}