using PDKS_Api.Dtos.OgrenciDtos;
using PDKS_Api.Models.DapperContext;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;

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
            string query = "insert into Ogrenci (ogrenci_ad,ogrenci_soyad,ogrenci_telefon_no,ogrenci_adres,ogrenci_cinsiyet,ogrenci_dogum_tarihi,ogrenci_veli_id,ogrenci_sınıf_id,ogrenci_ögretmen_id) values (@ad,@soyad,@telefon_no,@adres,@cinsiyet,@dogum_tarihi,@veli_id,@sınıf_id,@ögretmen_id)";
            var parameters = new DynamicParameters();
            parameters.Add("@ad", ogrenciDto.ogrenci_ad);
            parameters.Add("@soyad", ogrenciDto.ogrenci_soyad);
            parameters.Add("@telefon_no", ogrenciDto.ogrenci_telefon_no);
            parameters.Add("@adres", ogrenciDto.ogrenci_adres);
            parameters.Add("@cinsiyet", ogrenciDto.ogrenci_cinsiyet);
            parameters.Add("@dogum_tarihi", ogrenciDto.ogrenci_dogum_tarihi);
            parameters.Add("@veli_id", ogrenciDto.ogrenci_veli_id);
            parameters.Add("@sınıf_id", ogrenciDto.ogrenci_sınıf_id);
            parameters.Add("@ögretmen_id", ogrenciDto.ogrenci_ögretmen_id);
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
            string query = "Update Ogrenci Set ogrenci_ad=@ad,ogrenci_soyad=@soyad,ogrenci_telefon_no=@telefon_no,ogrenci_adres=@adres,ogrenci_cinsiyet=@cinsiyet,ogrenci_dogum_tarihi=@dogum_tarihi,ogrenci_veli_id=@veli_id,ogrenci_sınıf_id=@sınıf_id,ogrenci_ögretmen_id=@ögretmen_id where ögrenci_id=@ögrenci_id";
            var parameters = new DynamicParameters();
            parameters.Add("@ad", ogrenciDto.ogrenci_ad);
            parameters.Add("@soyad", ogrenciDto.ogrenci_soyad);
            parameters.Add("@telefon_no", ogrenciDto.ogrenci_telefon_no);
            parameters.Add("@adres", ogrenciDto.ogrenci_adres);
            parameters.Add("@cinsiyet", ogrenciDto.ogrenci_cinsiyet);
            parameters.Add("@dogum_tarihi", ogrenciDto.ogrenci_dogum_tarihi);
            parameters.Add("@veli_id", ogrenciDto.ogrenci_veli_id); 
            parameters.Add("@sınıf_id", ogrenciDto.ogrenci_ögretmen_id);
            parameters.Add("@ögretmen_id", ogrenciDto.ogrenci_ögretmen_id);
            parameters.Add("@ögrenci_id", ogrenciDto.ögrenci_id);
            
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }       
}
