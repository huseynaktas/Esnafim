using Esnafim_1.Dto.BusinessEmployeesDtos;
using Esnafim_1.WebUI.Areas.BusinessEmployee.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessEmployee.Controllers
{
    [Area("BusinessEmployee")]
    [Route("BusinessEmployee/BusinessEmployeeAuth")]
    public class BusinessEmployeeAuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BusinessEmployeeAuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View(new BusinessEmployeeLoginViewModel());
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(BusinessEmployeeLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            // TODO: endpoint yolu sende neyse ona göre düzelt:
            // örn: "api/fakeauth2/login"
            var response = await client.PostAsJsonAsync("api/fakeauth2/login", new
            {
                email = model.Email,
                password = model.Password
            });

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Giriş başarısız. Email/şifre kontrol et.");
                return View(model);
            }

            var result = await response.Content.ReadFromJsonAsync<BusinessEmployeeLoginResponseDto>();

            if (result == null || result.EmployeeId <= 0)
            {
                ModelState.AddModelError("", "Giriş başarısız. (EmployeeId alınamadı)");
                return View(model);
            }

            // Session’a yaz (BusinessOwner ile karışmasın diye anahtarlar farklı!)
            HttpContext.Session.SetInt32("BusinessEmployeeId", result.EmployeeId);
            HttpContext.Session.SetInt32("BusinessEmployeeBusinessId", result.BusinessId);
            HttpContext.Session.SetString("BusinessEmployeeName", result.Name ?? "");

            // Çalışan panelinin giriş sayfası neresiyse ona yolla:
            // HomeController/Index varsayımı:
            return RedirectToAction("Index", "BusinessEmployeeHome", new { area = "BusinessEmployee" });
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("BusinessEmployeeId");
            HttpContext.Session.Remove("BusinessEmployeeBusinessId");
            HttpContext.Session.Remove("BusinessEmployeeName");

            return RedirectToAction("Login", "BusinessEmployeeAuth", new { area = "BusinessEmployee" });
        }
    }
}
