using Dapper;
using PDKS_Api.Dtos.OgrenciDtos;
using PDKS_Api.Dtos.VeliDtos;
using PDKS_Api.Models.DapperContext;

namespace PDKS_Api.Repositories.VeliRepository
{
    public class VeliRepository : IVeliRepository
    {
        private readonly Context _context;

        public VeliRepository(Context context)
        {
            _context = context;
        }

        public async void CreateVeli(CreateVeliDto veliDto)
        {
            string query = "insert into Veli (veli_ad,veli_soyad,veli_telefon_no,veli_mail,veli_adres,veli_cinsiyet,veli_dogum_tarihi) values (@veli_ad,@veli_soyad,@veli_telefon_no,@veli_mail,@veli_adres,@veli_cinsiyet,@veli_dogum_tarihi)";
            var parameters = new DynamicParameters();
            parameters.Add("@veli_ad", veliDto.veli_ad);
            parameters.Add("@veli_soyad", veliDto.veli_soyad);
            parameters.Add("@veli_telefon_no", veliDto.veli_telefon_no);
            parameters.Add("@veli_mail", veliDto.veli_mail);
            parameters.Add("@veli_adres", veliDto.veli_adres);
            parameters.Add("@veli_cinsiyet", veliDto.veli_cinsiyet);
            parameters.Add("@veli_dogum_tarihi", veliDto.veli_dogum_tarihi);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
         
        }

        public async void DeleteVeli(int id)
        {
            string query = "Delete From Veli Where veli_id=@veli_id";
            var parameters = new DynamicParameters();
            parameters.Add("@veli_id", id);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultVeliDto>> GetAllVeliAsync()
        {
            string query = "Select * From Veli";
            using (var connection = _context.CreateConnection())
            {
                {
                    var values = await connection.QueryAsync<ResultVeliDto>(query);
                    return values.ToList();
                }
            }
        }

        public async Task<GetByIDVeliDto> GetVeli(int id)
        {
            string query = "Select * From Veli Where veli_id=@veli_id";
            var parameters = new DynamicParameters();
            parameters.Add("@veli_id", id);
            using(var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetByIDVeliDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateVeli(UpdateVeliDto veliDto)
        {
            string query = "Update Veli Set veli_ad=@veli_ad,veli_soyad=@veli_soyad,veli_telefon_no=@veli_telefon_no,veli_mail=@veli_mail,veli_adres=@veli_adres,veli_cinsiyet=@veli_cinsiyet,veli_dogum_tarihi=@veli_dogum_tarihi where veli_id=@veli_id";
            var parameters = new DynamicParameters();
            parameters.Add("@veli_ad", veliDto.veli_ad);
            parameters.Add("@veli_soyad", veliDto.veli_soyad);
            parameters.Add("@veli_telefon_no", veliDto.veli_telefon_no);
            parameters.Add("@veli_mail", veliDto.veli_mail);
            parameters.Add("@veli_adres", veliDto.veli_adres);
            parameters.Add("@veli_cinsiyet", veliDto.veli_cinsiyet);
            parameters.Add("@veli_dogum_tarihi", veliDto.veli_dogum_tarihi);
            parameters.Add("@veli_id", veliDto.veli_id);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);    
            }
        }



    }
}
