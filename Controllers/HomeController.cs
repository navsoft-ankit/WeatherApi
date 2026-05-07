using Microsoft.AspNetCore.Mvc;
namespace Test.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return"Home Page";
        }
    }
}