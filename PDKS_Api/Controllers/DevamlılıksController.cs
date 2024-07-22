using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDKS_Api.Repositories.DevamlılıkRepository;

namespace PDKS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevamlılıksController : ControllerBase
    {
        private readonly IDevamlılıkRepository _veliRepository;

        public DevamlılıksController(IDevamlılıkRepository veliRepository)
        {
            _veliRepository = veliRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDevamlılıkAsync()
        {
            var values = await _veliRepository.GetAllDevamlılıkAsync();
            return Ok(values);
        }
    }
}
