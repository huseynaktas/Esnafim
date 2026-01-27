using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.Controllers
{
    [Area("BusinessEmployee")]
    public abstract class BusinessEmployeeBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Login sayfasına erişimi engelleme (loop olmasın)
            var controller = (context.RouteData.Values["controller"]?.ToString()) ?? "";
            var action = (context.RouteData.Values["action"]?.ToString()) ?? "";

            if (controller.Equals("BusinessEmployeeAuth", StringComparison.OrdinalIgnoreCase) &&
                (action.Equals("Login", StringComparison.OrdinalIgnoreCase) ||
                 action.Equals("Logout", StringComparison.OrdinalIgnoreCase) ||
                 action.Equals("Index", StringComparison.OrdinalIgnoreCase)))
            {
                base.OnActionExecuting(context);
                return;
            }

            // Session kontrol
            var employeeId = HttpContext.Session.GetInt32("BusinessEmployeeId");
            if (employeeId == null || employeeId <= 0)
            {
                context.Result = RedirectToAction("Login", "BusinessEmployeeAuth", new { area = "BusinessEmployee" });
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}