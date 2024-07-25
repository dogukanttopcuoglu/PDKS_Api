using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using PDKS_UserInterface.Dtos.LoginDtos;
using PDKS_UserInterface.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace PDKS_UserInterface.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        string tokenModelStr;
        DateTime tokenModelStr2;

        List<string> tokenModelList;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44317/api/Login", content);
            if (response.IsSuccessStatusCode)
            {
                //var jsonData = await response.Content.ReadAsStringAsync();
                string jsonData = await response.Content.ReadAsStringAsync();

                //var options = new JsonSerializerOptions
                //{
                //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //    WriteIndented = true
                //};


                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData);
                //tokenModelStr =  tokenModel.Token.ToString();
                //tokenModelStr2 = tokenModel.ExpireDate;








                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    if (token != null)
                    {
                        claims.Add(new Claim("pdkstoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true,

                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Ogretmen");
                    }
                }

            }
            return View();
        }
    }
}