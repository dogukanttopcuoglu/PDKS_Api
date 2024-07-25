using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PDKS_UserInterface.Dtos.SınıfDtos;

namespace PDKS_UserInterface.Controllers
{
    public class SınıfController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SınıfController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44317/api/Sınıfs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSınıfDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
