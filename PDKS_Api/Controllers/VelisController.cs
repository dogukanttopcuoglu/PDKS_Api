using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDKS_Api.Dtos.VeliDtos;
using PDKS_Api.Repositories.VeliRepository;

namespace PDKS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VelisController : ControllerBase
    {
        private readonly IVeliRepository _veliRepository;

        public VelisController(IVeliRepository veliRepository)
        {
            _veliRepository = veliRepository;
        }
        [HttpGet]
        public async Task<IActionResult> VeliList()
        {
            var values = await _veliRepository.GetAllVeliAsync();
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateVeli(CreateVeliDto createVeliDto)
        {
            _veliRepository.CreateVeli(createVeliDto);
            return Ok("Veli Başarılı Bir Şekilde Eklendi");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeli(int id)
        {
            _veliRepository.DeleteVeli(id);
            return Ok("Veli Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVeli(UpdateVeliDto updateVeliDto)
        {
            _veliRepository.UpdateVeli(updateVeliDto);
            return Ok("Veli Başarılı Bir Şekilde Güncellendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeli(int id)
        {
            var value = await _veliRepository.GetVeli(id);
            return Ok(value);
        }
    }
}
