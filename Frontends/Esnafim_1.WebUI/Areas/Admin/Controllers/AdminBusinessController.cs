using Esnafim_1.Dto.BusinessDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Esnafim_1.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBusiness")]
    public class AdminBusinessController : Controller
    {
        private readonly HttpClient _client;
        public string apiConnectedUrl = "https://localhost:7028/api/Businesses";

        public AdminBusinessController(IHttpClientFactory httpClientFactory)
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
                var values = JsonConvert.DeserializeObject<List<ResultBusinessDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateBusiness")]
        public IActionResult CreateBusiness()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateBusiness")]
        public async Task<IActionResult> CreateBusiness(CreateBusinessDto createBusinessDto)
        {
            var jsonData = JsonConvert.SerializeObject(createBusinessDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync(apiConnectedUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBusiness", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateBusiness/{id}")]
        public async Task<IActionResult> UpdateBusiness(int id)
        {
            var responseMesage = await _client.GetAsync($"https://localhost:7028/api/Businesses/{id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBusinessDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateBusiness/{id}")]
        public async Task<IActionResult> UpdateBusiness(UpdateBusinessDto updateBusinessDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateBusinessDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PutAsync(apiConnectedUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBusiness", new { area = "Admin" });
            }
            return View();
        }
    }
}
