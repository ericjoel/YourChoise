using Microsoft.AspNetCore.Mvc;

namespace YourChoice.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello");
    }
}