using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PDKS_UserInterface.Dtos.OgrenciDtos;


namespace PDKS_UserInterface.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OgrenciController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44317/api/Ogrencis");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOgrenciDto>>(jsonData);   
                return View(values);
            }
            return View();
        }
    }
}
