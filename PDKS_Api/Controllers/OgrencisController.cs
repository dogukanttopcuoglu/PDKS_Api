using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDKS_Api.Dtos.OgrenciDtos;
using PDKS_Api.Repositories.OgrenciRepository;

namespace PDKS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrencisController : ControllerBase
    {
        private readonly IOgrenciRepository _ogrenciRepository;

        public OgrencisController(IOgrenciRepository ogrenciRepository)
        {
            _ogrenciRepository = ogrenciRepository;
        }
        [HttpGet]

        public async Task<IActionResult> OgrenciList()
        {
            var values = await _ogrenciRepository.GetAllOgrenciAsync();
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateOgrenci(CreateOgrenciDto createOgrenciDto)
        {
            _ogrenciRepository.CreateOgrenci(createOgrenciDto);
            return Ok("Öğrenci Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOgrenci(int id)
        {
            _ogrenciRepository.DeleteOgrenci(id);
            return Ok("Öğrenci Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOgrenci(UpdateOgrenciDto updateOgrenciDto)
        {
            _ogrenciRepository.UpdateOgrenci(updateOgrenciDto);
            return Ok("Öğrenci Başarılı Bir Şekilde Güncellendi");
        }
    }   
}
