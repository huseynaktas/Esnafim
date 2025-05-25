using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
