using Esnafim_1.Dto.UserDtos;
using Esnafim_1.WebUI.ViewModels;
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
            if (userId == null || userId <= 0)
                return RedirectToAction("Login", "Auth");

            var client = _httpClientFactory.CreateClient("EsnafimApi");

            // 1) Profil bilgisi
            var userResponse = await client.GetAsync($"api/Users/{userId.Value}");
            if (!userResponse.IsSuccessStatusCode)
                return RedirectToAction("Login", "Auth");

            var userJson = await userResponse.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<GetUserDto>(userJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (user == null)
                return RedirectToAction("Login", "Auth");

            // 2) Randevular
            var apptResponse = await client.GetAsync($"api/Appointments/GetAppointmentsByUserId/{userId.Value}");
            var apptJson = await apptResponse.Content.ReadAsStringAsync();

            var appointments = new List<UserAppointmentDto>();
            if (apptResponse.IsSuccessStatusCode)
            {
                appointments = JsonSerializer.Deserialize<List<UserAppointmentDto>>(apptJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<UserAppointmentDto>();
            }

            var vm = new UserProfileViewModel
            {
                User = user,
                Appointments = appointments
            };

            return View(vm);
        }
    }
}
