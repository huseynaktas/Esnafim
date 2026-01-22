using Esnafim_1.Dto.UserDtos;
using Esnafim_1.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Esnafim_1.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IPasswordHasher<UserRegisterViewModel> _passwordHasher;

        public AuthController(IHttpClientFactory httpClientFactory,
                              IPasswordHasher<UserRegisterViewModel> passwordHasher)
        {
            _httpClientFactory = httpClientFactory;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Şifreyi hash'le (DB'ye düz şifre gitmesin)
            var passwordHash = _passwordHasher.HashPassword(model, model.Password);

            // API'nin beklediği payload (User tablosu kolonlarına göre)
            var payload = new
            {
                userId = 0,
                name = model.Name,
                phone = model.Phone,
                city = model.City,
                district = model.District,
                neighborhood = model.Neighborhood,
                address = model.Address,
                email = model.Email,
                password = passwordHash,
                isActive = true,
                registrationDate = DateTime.Now
            };

            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync("https://localhost:7028/api/Users", payload);

            if (!response.IsSuccessStatusCode)
            {
                // API hata döndürdüyse ekrana basit bir mesaj verelim
                ModelState.AddModelError(string.Empty, "Kayıt işlemi başarısız. Lütfen bilgileri kontrol edip tekrar deneyin.");
                return View(model);
            }

            // Başarılı: Login sayfasına yönlendir
            TempData["Success"] = "Kayıt başarılı! Şimdi giriş yapabilirsin.";
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            // ✅ Email'e göre kullanıcıyı çek (endpoint örneği)
            var response = await client.GetAsync($"api/Users/GetByEmail?email={WebUtility.UrlEncode(model.Email)}");

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Email veya şifre hatalı.");
                return View(model);
            }

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<GetUserDtoForLogin>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (user == null || !user.IsActive)
            {
                ModelState.AddModelError("", "Email veya şifre hatalı.");
                return View(model);
            }

            // ✅ Hash doğrula (Register’da ürettiğin hash'i verify edeceğiz)
            // Senin hasher'ın UserRegisterViewModel türünde kayıtlı, onu kullanarak doğrulayabiliriz:
            var dummy = new UserRegisterViewModel { Password = model.Password, Email = model.Email, Name = "x", Phone = "x", City = "x", District = "x", Neighborhood = "x", Address = "x" };

            var verify = _passwordHasher.VerifyHashedPassword(dummy, user.Password, model.Password);

            if (verify == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Email veya şifre hatalı.");
                return View(model);
            }

            // ✅ Session'a giriş bilgisi yaz (Navbar için)
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("UserName", user.Name);

            return RedirectToAction("UserProfile", "User");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }

    }
}
