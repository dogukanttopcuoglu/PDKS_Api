using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDKS_Api.Dtos.OgretmenDtos;
using PDKS_Api.Repositories.OgretmenRepository;

namespace PDKS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgretmensController : ControllerBase
    {
        private readonly IOgretmenRepository _ogretmenRepository;

        public OgretmensController(IOgretmenRepository ogretmenRepository)
        {
            _ogretmenRepository = ogretmenRepository;
        }

        [HttpGet]
        public async Task<IActionResult> OgretmenList()
        {
            var values = await _ogretmenRepository.GetAllOgretmenAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOgretmen(CreateOgretmenDto createOgretmenDto)
        {
            _ogretmenRepository.CreateOgretmen(createOgretmenDto);
            return Ok("Öğretmen Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOgretmen(int id )
        {
            _ogretmenRepository.DeleteOgretmen(id);
            return Ok("Öğretmen Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOgretmen(UpdateOgretmenDto updateOgretmenDto)
        {
            _ogretmenRepository.UpdateOgretmen(updateOgretmenDto);
            return Ok("Öğretmen Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOgretmen(int id)
        {
            var value = await _ogretmenRepository.GetOgretmen(id);
            return Ok(value);
        }
        
    }
}
