using Esnafim_1.Dto.BusinessOwnerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Esnafim_1.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBusinessOwner")]
    public class AdminBusinessOwnerController : Controller
    {
        private readonly HttpClient _client;
        public string apiConnectedUrl = "https://localhost:7028/api/BusinessOwners";

        public AdminBusinessOwnerController(IHttpClientFactory httpClientFactory)
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
                var values = JsonConvert.DeserializeObject<List<ResultBusinessOwnerDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateBusinessOwner")]
        public IActionResult CreateBusinessOwner()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateBusinessOwner")]
        public async Task<IActionResult> CreateBusinessOwner(CreateBusinessOwnerDto createBusinessOwnerDto)
        {
            var jsonData = JsonConvert.SerializeObject(createBusinessOwnerDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync(apiConnectedUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBusinessOwner", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateBusinessOwner/{id}")]
        public async Task<IActionResult> UpdateBusinessOwner(int id)
        {
            var responseMesage = await _client.GetAsync($"https://localhost:7028/api/BusinessOwners/{id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBusinessOwnerDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateBusinessOwner/{id}")]
        public async Task<IActionResult> UpdateBusinessOwner(UpdateBusinessOwnerDto updateBusinessOwnerDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateBusinessOwnerDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PutAsync(apiConnectedUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBusinessOwner", new { area = "Admin" });
            }
            return View();
        }
    }
}
