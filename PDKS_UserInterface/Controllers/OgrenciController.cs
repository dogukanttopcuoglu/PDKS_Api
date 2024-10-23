using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PDKS_UserInterface.Dtos.OgrenciDtos;
using System.Text;


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
        [HttpGet]

        public IActionResult CreateOgrenci()
        {
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> CreateOgrenci(CreateOgrenciDto createOgrenci)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOgrenci);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:44317/api/Ogrencis", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error occurred while creating the Veli.");
            return View();

        }
        public async Task<IActionResult> DeleteOgrenci(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44317/api/Ogrencis/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOgrenci(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44317/api/Ogrencis/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOgrenciDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOgrenci(UpdateOgrenciDto updateOgrenciDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateOgrenciDto);
            StringContent stringContent=new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44317/api/Ogrencis/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
