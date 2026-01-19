using Esnafim_1.WebUI.Areas.BusinessOwner.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/FakeAuth")]
    public class FakeAuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FakeAuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View(new FakeLoginViewModel());
        }

        [HttpPost("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FakeLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            var response = await client.PostAsJsonAsync("api/fakeauth/login", new
            {
                email = model.Email,
                password = model.Password
            });

            if (!response.IsSuccessStatusCode)
            {
                model.ErrorMessage = "Email veya şifre hatalı.";
                return View(model);
            }

            var login = await response.Content.ReadFromJsonAsync<FakeLoginApiResponse>();

            if (login is null || login.BusinessOwnerId <= 0)
            {
                model.ErrorMessage = "Giriş sırasında beklenmeyen bir hata oluştu.";
                return View(model);
            }

            // ✅ Session’a yaz
            HttpContext.Session.SetInt32("BusinessOwnerId", login.BusinessOwnerId);
            HttpContext.Session.SetString("BusinessOwnerName", login.FullName ?? "");

            // Örn: Panel ana sayfasına yönlendir
            return RedirectToAction("Index", "BusinessOwnerHome", new { area = "BusinessOwner" });
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            // 🔥 Fake login için tüm session bilgilerini temizle
            HttpContext.Session.Clear();

            // İleride JWT / Cookie kullanırsan diye hazır
            Response.Cookies.Delete("AccessToken");

            // Login ekranına geri dön
            return RedirectToAction("Index", "FakeAuth", new { area = "BusinessOwner" });
        }


        private sealed class FakeLoginApiResponse
        {
            public int BusinessOwnerId { get; set; }
            public string? Email { get; set; }
            public string? FullName { get; set; }
        }
    }
}
