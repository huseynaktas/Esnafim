using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminHome")]
    public class AdminHomeController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
