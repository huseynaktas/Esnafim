using Esnafim_1.Dto.BusinessDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Esnafim_1.WebUI.ViewComponents.BusinessViewComponent
{
    public class _AllBusinessComponentPartial: ViewComponent 
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AllBusinessComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var apiConnectionLink = "https://localhost:7028/api/Businesses";
            var responseMesage = await client.GetAsync(apiConnectionLink);
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBusinessDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
