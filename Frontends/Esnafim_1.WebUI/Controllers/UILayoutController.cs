using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
