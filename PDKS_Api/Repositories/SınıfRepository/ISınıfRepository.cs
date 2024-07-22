using PDKS_Api.Dtos.SınıfDtos;

namespace PDKS_Api.Repositories.SınıfRepository
{
    public interface ISınıfRepository
    {
        Task<List<ResultSınıfDto>> GetAllSınıfAsync();
        void DeleteSınıf(int id);   
    }
}
