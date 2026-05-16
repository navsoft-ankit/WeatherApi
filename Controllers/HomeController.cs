using Microsoft.AspNetCore.Mvc;
using Test.Models;
namespace Test.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return"Home Page";
        }
        [HttpPost]
        public ActionResult AddHome([FromBody]Home home)
        {
            if(home == null)
            {
                return BadRequest("Invalid");
            }
            return Created("api/home",home);
        }
    }
}