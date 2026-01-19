using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Esnafim_1.WebUI.Areas.BusinessOwner.Controllers
{
    [Area("BusinessOwner")]
    [Route("BusinessOwner/BusinessOwnerHome")]
    public class BusinessOwnerHomeController : BusinessOwnerBaseController
    {
        private readonly HttpClient _httpClient;

        public BusinessOwnerHomeController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EsnafimApi");
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
