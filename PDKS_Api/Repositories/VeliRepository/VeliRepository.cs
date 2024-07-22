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
            string query = "insert into Veli (ad,soyad,telefon_no,mail,adres,cinsiyet,dogum_tarihi) values (@ad,@soyad,@telefon_no,@mail,@adres,@cinsiyet,@dogum_tarihi)";
            var parameters = new DynamicParameters();
            parameters.Add("@ad", veliDto.ad);
            parameters.Add("@soyad", veliDto.soyad);
            parameters.Add("@telefon_no", veliDto.telefon_no);
            parameters.Add("@mail", veliDto.mail);
            parameters.Add("@adres", veliDto.adres);
            parameters.Add("@cinsiyet", veliDto.cinsiyet);
            parameters.Add("@dogum_tarihi", veliDto.dogum_tarihi);
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
            string query = "Update Veli Set ad=@ad,soyad=@soyad,telefon_no=@telefon_no,mail=@mail,adres=@adres,cinsiyet=@cinsiyet,dogum_tarihi=@dogum_tarihi where veli_id=@veli_id";
            var parameters = new DynamicParameters();
            parameters.Add("@ad", veliDto.ad);
            parameters.Add("@soyad", veliDto.soyad);
            parameters.Add("@telefon_no", veliDto.telefon_no);
            parameters.Add("@mail", veliDto.mail);
            parameters.Add("@adres", veliDto.adres);
            parameters.Add("@cinsiyet", veliDto.cinsiyet);
            parameters.Add("@dogum_tarihi", veliDto.dogum_tarihi);
            parameters.Add("@veli_id", veliDto.veli_id);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);    
            }
        }



    }
}
