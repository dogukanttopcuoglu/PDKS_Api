using Dapper;
using PDKS_Api.Dtos.OgretmenDtos;
using PDKS_Api.Dtos.SınıfDtos;
using PDKS_Api.Models.DapperContext;

namespace PDKS_Api.Repositories.SınıfRepository
{
    public class SınıfRepository : ISınıfRepository
    {
        private readonly Context _context;

        public SınıfRepository(Context context)
        {
            _context = context;
        }

        public async void DeleteSınıf(int id)
        {
            string query = "Delete From Sınıf Where sınıf_id=@sınıf_id";
            var parameters = new DynamicParameters();
            parameters.Add("@sınıf_id", id);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);   
            }
        }

        public async Task<List<ResultSınıfDto>> GetAllSınıfAsync()
        {
            string query = "Select * From Sınıf";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSınıfDto>(query);
                return values.ToList();


            }
        }
    }
}
