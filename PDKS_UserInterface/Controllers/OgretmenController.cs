using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PDKS_UserInterface.Dtos.ÖgretmenDtos;
using System.Text;

namespace PDKS_UserInterface.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OgretmenController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44317/api/Ogretmens");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOgretmenDtos>>(jsonData);
                return View(values);
            }
            return View();  
        }
        [HttpGet]

        public IActionResult createOgretmen()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> createOgretmen(CreateOgretmenDtos createOgretmen)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOgretmen);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44317/api/Ogretmens", stringContent);

         
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occurred while creating the Veli.");
            return View(); // Return the view with the model to preserve entered data
        }
        
        public async Task<IActionResult> DeleteOgretmen(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44317/api/Ogretmens/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOgretmen(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44317/api/Ogretmens/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOgretmenDtos>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpOptions]
        public async Task<IActionResult> UpdateOgretmen(UpdateOgretmenDtos updateOgretmen)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateOgretmen);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44317/api/Ogretmens/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
