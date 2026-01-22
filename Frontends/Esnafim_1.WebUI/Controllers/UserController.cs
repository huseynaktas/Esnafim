using Esnafim_1.Dto.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Esnafim_1.WebUI.Controllers
{
    public class UserController : Controller
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId <= 0)
            {
                context.Result = RedirectToAction("Login", "Auth");
                return;
            }

            base.OnActionExecuting(context);
        }


        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            // Login olmadan profile girilmesin
            if (userId == null || userId <= 0)
                return RedirectToAction("Login", "Auth");

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            // Senin API: [HttpGet("{id}")]
            var response = await client.GetAsync($"api/Users/{userId.Value}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Login", "Auth"); // istersen hata sayfasına da gönderebiliriz

            var json = await response.Content.ReadAsStringAsync();

            // Bu DTO'nun API response alanlarıyla uyumlu olması lazım
            var user = JsonSerializer.Deserialize<GetUserDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (user == null)
                return RedirectToAction("Login", "Auth");

            return View(user);
        }
    }
}
