using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDKS_Api.Repositories.SınıfRepository;

namespace PDKS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SınıfsController : ControllerBase
    {
        private readonly ISınıfRepository _sınıfRepository;

        public SınıfsController(ISınıfRepository sınıfRepository)
        {
            _sınıfRepository = sınıfRepository;
        }
        [HttpGet]
        public async Task<IActionResult> SınıfList()
        {
            var values = await _sınıfRepository.GetAllSınıfAsync();
            return Ok(values);  
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSınıf(int id)
        {
            _sınıfRepository.DeleteSınıf(id);
            return Ok("Sınıf Başarılı Bir Şekilde Silindi");
        }
    }
}
