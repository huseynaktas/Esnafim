using Esnafim_1.Dto.RoleDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Esnafim_1.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminRole")]
    public class AdminRoleController : Controller
    {
        private readonly HttpClient _client;
        public string apiConnectedUrl = "https://localhost:7028/api/Roles";

        public AdminRoleController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var responseMesage = await _client.GetAsync(apiConnectedUrl);
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoleDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateRole")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            var jsonData = JsonConvert.SerializeObject(createRoleDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync(apiConnectedUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminRole", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var responseMesage = await _client.GetAsync($"https://localhost:7028/api/Roles/{id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRoleDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateRoleDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PutAsync(apiConnectedUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminRole", new { area = "Admin" });
            }
            return View();
        }
    }
}
