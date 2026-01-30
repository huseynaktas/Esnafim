using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSupport")]
    public class AdminSupportController : Controller
    {
        [Route("Help")]
        public IActionResult Help()
        {
            return View();
        }
        [Route("Faq")]
        public IActionResult Faq()
        {
            return View();
        }
        [Route("Feedback")]
        public IActionResult Feedback()
        {
            return View();
        }
    }
}
