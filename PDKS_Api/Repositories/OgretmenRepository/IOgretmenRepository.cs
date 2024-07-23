using PDKS_Api.Dtos.OgretmenDtos;
using PDKS_Api.Dtos.VeliDtos;

namespace PDKS_Api.Repositories.OgretmenRepository
{
    public interface IOgretmenRepository
    {
        Task<List<ResultOgretmenDto>> GetAllOgretmenAsync();
        void CreateOgretmen(CreateOgretmenDto ogretmenDto);
        void DeleteOgretmen(int id);
        void UpdateOgretmen(UpdateOgretmenDto ogretmenDto);
        Task<GetByIDOgretmenDto> GetOgretmen(int id);
    }
}
