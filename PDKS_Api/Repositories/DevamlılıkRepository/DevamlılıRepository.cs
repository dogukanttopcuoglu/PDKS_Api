using Dapper;
using PDKS_Api.Dtos.DevamlılıkDtos;
using PDKS_Api.Models.DapperContext;

namespace PDKS_Api.Repositories.DevamlılıkRepository
{
    public class DevamlılıRepository : IDevamlılıkRepository
    {
        private readonly Context _context;

        public DevamlılıRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultDevamlılıkDto>> GetAllDevamlılıkAsync()
        {
            string query = "Select * From Devamlılık";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDevamlılıkDto>(query);   
                return values.ToList();
            }
        }
    }
}
