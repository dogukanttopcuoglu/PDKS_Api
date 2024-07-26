using PDKS_Api.Dtos.OgrenciDtos;

namespace PDKS_Api.Repositories.OgrenciRepository
{
    public interface IOgrenciRepository
    {
        Task<List<ResultOgrenciDto>> GetAllOgrenciAsync();
        Task<List<ResultOgrenciListWithSınıfByOgretmenDto>> GetOgrenciListByOgretmenAsync(int id);
        void CreateOgrenci(CreateOgrenciDto ogrenciDto);
        void DeleteOgrenci(int id );

        void UpdateOgrenci(UpdateOgrenciDto ogrenciDto );


    }
}
