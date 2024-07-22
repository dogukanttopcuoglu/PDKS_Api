using PDKS_Api.Dtos.DevamlılıkDtos;

namespace PDKS_Api.Repositories.DevamlılıkRepository
{
    public interface IDevamlılıkRepository
    {
        Task<List<ResultDevamlılıkDto>> GetAllDevamlılıkAsync();
    }
}
