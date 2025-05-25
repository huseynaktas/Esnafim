using Esnafim_1.Dto.BusinessCategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Esnafim_1.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBusinessCategory")]
    public class AdminBusinessCategoryController : Controller
    {
        private readonly HttpClient _client;
        public string apiConnectedUrl = "https://localhost:7028/api/BusinessCategories";

        public AdminBusinessCategoryController(IHttpClientFactory httpClientFactory)
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
                var values = JsonConvert.DeserializeObject<List<ResultBusinessCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateBusinessCategory")]
        public IActionResult CreateBusinessCategory()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateBusinessCategory")]
        public async Task<IActionResult> CreateBusinessCategory(CreateBusinessCategoryDto createBusinessCategoryDto)
        {
            var jsonData = JsonConvert.SerializeObject(createBusinessCategoryDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync(apiConnectedUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBusinessCategory", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateBusinessCategory/{id}")]
        public async Task<IActionResult> UpdateBusinessCategory(int id)
        {
            var responseMesage = await _client.GetAsync($"https://localhost:7028/api/BusinessCategories/{id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBusinessCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateBusinessCategory/{id}")]
        public async Task<IActionResult> UpdateBusinessCategory(UpdateBusinessCategoryDto updateBusinessCategoryDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateBusinessCategoryDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PutAsync(apiConnectedUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBusinessCategory", new { area = "Admin" });
            }
            return View();
        }
    }
}
