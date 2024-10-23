using PDKS_Api.Dtos.OgrenciDtos;
using PDKS_Api.Models.DapperContext;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PDKS_Api.Dtos.OgretmenDtos;

namespace PDKS_Api.Repositories.OgrenciRepository
{
    public class OgrenciRepository : IOgrenciRepository
    {
        private readonly Context _context;

        public OgrenciRepository(Context context)
        {
            _context = context;
            
        }

        public async void CreateOgrenci(CreateOgrenciDto ogrenciDto)
        {
            string query = "insert into Ogrenci (ogrenci_ad,ogrenci_soyad,ogrenci_telefon_no,ogrenci_adres,ogrenci_cinsiyet,ogrenci_dogum_tarihi,ogrenci_veli_id,ogrenci_sınıf_id,ogrenci_ögretmen_id) values (@ogrenci_ad,@ogrenci_soyad,@ogrenci_telefon_no,@ogrenci_adres,@ogrenci_cinsiyet,@ogrenci_dogum_tarihi,@ogrenci_veli_id,@ogrenci_sınıf_id,@ogrenci_ögretmen_id)";
            var parameters = new DynamicParameters();
            parameters.Add("@ogrenci_ad", ogrenciDto.ogrenci_ad);
            parameters.Add("@ogrenci_soyad", ogrenciDto.ogrenci_soyad);
            parameters.Add("@ogrenci_telefon_no", ogrenciDto.ogrenci_telefon_no);
            parameters.Add("@ogrenci_adres", ogrenciDto.ogrenci_adres);
            parameters.Add("@ogrenci_cinsiyet", ogrenciDto.ogrenci_cinsiyet);
            parameters.Add("@ogrenci_dogum_tarihi", ogrenciDto.ogrenci_dogum_tarihi);
            parameters.Add("@ogrenci_veli_id", ogrenciDto.ogrenci_veli_id);
            parameters.Add("@ogrenci_sınıf_id", ogrenciDto.ogrenci_sınıf_id);
            parameters.Add("@ogrenci_ögretmen_id", ogrenciDto.ogrenci_ögretmen_id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }



        }

        public async void DeleteOgrenci(int id)
        {
            string query = "Delete From Ogrenci Where ögrenci_id=@ögrenci_id";
            var parameters = new DynamicParameters();
            parameters.Add("@ögrenci_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<List<ResultOgrenciDto>> GetAllOgrenciAsync()
        {
            string query = "Select * From Ogrenci";
            using(var connection = _context.CreateConnection()) 
            {
                {
                    var values = await connection.QueryAsync<ResultOgrenciDto>(query);
                    return values.ToList();
                }
            }
        }

        public async Task<List<ResultOgrenciWithVSODto>> GetAllOgrenciWithVSOAsync()
        {
            string query = "Select ögrenci_id,ogrenci_ad,ogrenci_soyad,ogrenci_telefon_no,ogrenci_adres,ogrenci_cinsiyet,ogrenci_dogum_tarihi,veli_ad,sınıf_ad,ogretmen_ad From Ogrenci inner join Veli on Ogrenci.ogrenci_veli_id=Veli.veli_id inner join Sınıf on Ogrenci.ogrenci_sınıf_id=Sınıf.sınıf_id inner join Ogretmen on Ogrenci.ogrenci_ögretmen_id=Ogretmen.ögretmen_id";
            using (var connection = _context.CreateConnection())
            {
                {
                    var values = await connection.QueryAsync<ResultOgrenciWithVSODto>(query);
                    return values.ToList();
                }
            }
        }

        public async Task<GetByIDOgrenciDto> GetOgrenci(int id)
        {
            string query = "Select * From Ogrenci Where ögrenci_id=@ögrenci_id";
            var parameters = new DynamicParameters();
            parameters.Add("@ögrenci_id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDOgrenciDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultOgrenciListWithSınıfByOgretmenDto>> GetOgrenciListByOgretmenAsync(int id)
        {
            string query = "Select ögrenci_id,ogrenci_ad,ogrenci_soyad,ogrenci_telefon_no,ogrenci_adres,ogrenci_cinsiyet,ogretmen_ad From Ogrenci inner join Ogretmen on Ogrenci.ogrenci_ögretmen_id=Ogretmen.ögretmen_id where ögretmen_id=@ögretmen_id";
            var parameters = new DynamicParameters();
            parameters.Add("ögretmen_id", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultOgrenciListWithSınıfByOgretmenDto>(query, parameters);
                return values.ToList();
            }
        }

       

        public async void UpdateOgrenci(UpdateOgrenciDto ogrenciDto)
        {
            string query = "Update Ogrenci Set ogrenci_ad=@ogrenci_ad,ogrenci_soyad=@ogrenci_soyad,ogrenci_telefon_no=@ogrenci_telefon_no,ogrenci_adres=@ogrenci_adres,ogrenci_cinsiyet=@ogrenci_cinsiyet,ogrenci_dogum_tarihi=@ogrenci_dogum_tarihi,ogrenci_veli_id=@ogrenci_veli_id,ogrenci_sınıf_id=@ogrenci_sınıf_id,ogrenci_ögretmen_id=@ogrenci_ögretmen_id where ögrenci_id=@ögrenci_id";
            var parameters = new DynamicParameters();
            parameters.Add("@ogrenci_ad", ogrenciDto.ogrenci_ad);
            parameters.Add("@ogrenci_soyad", ogrenciDto.ogrenci_soyad);
            parameters.Add("@ogrenci_telefon_no", ogrenciDto.ogrenci_telefon_no);
            parameters.Add("@ogrenci_adres", ogrenciDto.ogrenci_adres);
            parameters.Add("@ogrenci_cinsiyet", ogrenciDto.ogrenci_cinsiyet);
            parameters.Add("@ogrenci_dogum_tarihi", ogrenciDto.ogrenci_dogum_tarihi);
            parameters.Add("@ogrenci_veli_id", ogrenciDto.ogrenci_veli_id); 
            parameters.Add("@ogrenci_sınıf_id", ogrenciDto.ogrenci_sınıf_id);
            parameters.Add("@ogrenci_ögretmen_id", ogrenciDto.ogrenci_ögretmen_id);
            parameters.Add("@ögrenci_id", ogrenciDto.ögrenci_id);
            
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }       
}
