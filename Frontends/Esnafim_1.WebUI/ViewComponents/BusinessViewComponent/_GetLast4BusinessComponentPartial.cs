using Esnafim_1.Dto.BusinessDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Esnafim_1.WebUI.ViewComponents.BusinessViewComponent
{
    public class _GetLast4BusinessComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetLast4BusinessComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var apiConnectedUrl = "https://localhost:7028/api/Businesses/GetLast4BusinessList";
            var responseMesage = await client.GetAsync(apiConnectedUrl);
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetLast4BusinessDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
