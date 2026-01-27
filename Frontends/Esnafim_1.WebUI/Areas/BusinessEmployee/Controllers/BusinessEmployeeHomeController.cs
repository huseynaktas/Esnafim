using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.Controllers
{
    [Area("BusinessEmployee")]
    [Route("BusinessEmployee/BusinessEmployeeHome")]
    public class BusinessEmployeeHomeController : BusinessEmployeeBaseController
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
