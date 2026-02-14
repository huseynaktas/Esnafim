using Esnafim_1.Domain.Entities;
using Esnafim_1.Dto.BusinessDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Esnafim_1.WebUI.ViewComponents.BusinessDetailsViewComponents
{
    public class _BusinessDetailComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BusinessDetailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int businessId)
        {
            var client = _httpClientFactory.CreateClient();
            var apiLink = $"https://localhost:7028/api/Businesses/{businessId}";
            var responseMesage = await client.GetAsync(apiLink);
            if (responseMesage.IsSuccessStatusCode)
            {
                var JsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBusinessByIdDto>(JsonData);
                return View(values);
            }
            return View();
        }
    }
}
