 using PDKS_Api.Dtos.OgrenciDtos;
using PDKS_Api.Dtos.VeliDtos;

namespace PDKS_Api.Repositories.VeliRepository
{
    public interface IVeliRepository
    {
        Task<List<ResultVeliDto>> GetAllVeliAsync();
        void CreateVeli(CreateVeliDto veliDto);
        void DeleteVeli(int id);
        void UpdateVeli(UpdateVeliDto veliDto);
        Task<GetByIDVeliDto> GetVeli(int id);
    }
}
