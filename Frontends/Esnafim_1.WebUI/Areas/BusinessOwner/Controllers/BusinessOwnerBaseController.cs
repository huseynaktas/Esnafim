using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    public abstract class BusinessOwnerBaseController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        protected BusinessOwnerBaseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // ✅ Login ekranı kilitlenmesin (FakeAuthController serbest)
            var controllerName = context.RouteData.Values["controller"]?.ToString();

            if (!string.Equals(controllerName, "FakeAuth", StringComparison.OrdinalIgnoreCase))
            {
                var ownerId = HttpContext.Session.GetInt32("BusinessOwnerId");

                if (ownerId is null || ownerId <= 0)
                {
                    context.Result = new RedirectToActionResult(
                        actionName: "Index",
                        controllerName: "FakeAuth",
                        routeValues: new { area = "BusinessOwner" }
                    );
                    return;
                }
            }

            base.OnActionExecuting(context);
        }

        protected HttpClient CreateApiClientWithOwnerHeader()
        {
            var client = _httpClientFactory.CreateClient("EsnafimApi");

            var ownerId = HttpContext.Session.GetInt32("BusinessOwnerId");

            if (ownerId is not null && ownerId > 0)
            {
                if (client.DefaultRequestHeaders.Contains("X-BusinessOwner-Id"))
                    client.DefaultRequestHeaders.Remove("X-BusinessOwner-Id");

                client.DefaultRequestHeaders.Add("X-BusinessOwner-Id", ownerId.Value.ToString());
            }

            return client;
        }

        protected int GetOwnerIdOrZero()
            => HttpContext.Session.GetInt32("BusinessOwnerId") ?? 0;
    }
}
