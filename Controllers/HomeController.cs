using Microsoft.AspNetCore.Mvc;
using Test.Models;
namespace Test.Controllers
{
    [ApiController]
    [Route("api/Home")]
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
                return BadRequest("Invlaid");
            }
            return Created("api/Home",home);
        }
    }
}