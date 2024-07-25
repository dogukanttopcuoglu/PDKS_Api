using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDKS_Api.Tools;

namespace PDKS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenCreateController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateToken(GetCheckAppUserViewModel model)
        {
            var values = JwtTokenGenerator.GenerateToken(model);
            return Ok(values);
        }
    }
}
