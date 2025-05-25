using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
