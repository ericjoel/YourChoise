using Microsoft.AspNetCore.Mvc;

namespace YourChoise.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello");
    }
}