using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Controllers
{
    public class SupportController : Controller
    {
        [HttpGet]
        public IActionResult Terms() => View();

        [HttpGet]
        public IActionResult Privacy() => View();

        [HttpGet]
        public IActionResult Faq() => View();

        [HttpGet]
        public IActionResult HelpCenter() => View();

        [HttpGet]
        public IActionResult Feedback() => View();
    }
}
