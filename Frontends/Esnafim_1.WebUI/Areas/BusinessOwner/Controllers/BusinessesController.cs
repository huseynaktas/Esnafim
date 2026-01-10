using Esnafim_1.Dto.BusinessOwnerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/Businesses")]
    public class BusinessesController : Controller
    {
        private readonly HttpClient _httpClient;
        public string apiConnectedUrl = "https://localhost:7028/api/BusinessOwners/GetBusinessByBusinessOwnerId";

        public BusinessesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var responseMesage = await _httpClient.GetAsync(apiConnectedUrl);
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBusinessesByOwnerIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
