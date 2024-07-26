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
            string query = "insert into Ogrenci (ad,soyad,telefon_no,adres,cinsiyet,dogum_tarihi,veli_id,sınıf_id,ögretmen_id) values (@ad,@soyad,@telefon_no,@adres,@cinsiyet,@dogum_tarihi,@veli_id,@sınıf_id,@ögretmen_id)";
            var parameters = new DynamicParameters();
            parameters.Add("@ad", ogrenciDto.ad);
            parameters.Add("@soyad", ogrenciDto.soyad);
            parameters.Add("@telefon_no", ogrenciDto.telefon_no);
            parameters.Add("@adres", ogrenciDto.adres);
            parameters.Add("@cinsiyet", ogrenciDto.cinsiyet);
            parameters.Add("@dogum_tarihi", ogrenciDto.dogum_tarihi);
            parameters.Add("@veli_id", ogrenciDto.veli_id);
            parameters.Add("@sınıf_id", ogrenciDto.sınıf_id);
            parameters.Add("@ögretmen_id", ogrenciDto.ögretmen_id);
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
            string query = @"
        SELECT 
            Ogrenci.ögrenci_id,
            Ogrenci.ad AS ogrenci_ad,
            Ogrenci.soyad,
            Ogrenci.telefon_no,
            Ogrenci.adres,
            Ogrenci.cinsiyet,
            Ogrenci.dogum_tarihi,
            Ogretmen.ad AS ogretmen_ad
        FROM 
            Ogrenci 
        INNER JOIN 
            Ogretmen ON Ogrenci.ögretmen_id = Ogretmen.ögretmen_id 
        WHERE 
            Ogretmen.ögretmen_id = @ögretmen_id";

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
            string query = "Update Ogrenci Set ad=@ad,soyad=@soyad,telefon_no=@telefon_no,adres=@adres,cinsiyet=@cinsiyet,dogum_tarihi=@dogum_tarihi,veli_id=@veli_id,sınıf_id=@sınıf_id,ögretmen_id=@ögretmen_id where ögrenci_id=@ögrenci_id";
            var parameters = new DynamicParameters();
            parameters.Add("@ad", ogrenciDto.ad);
            parameters.Add("@soyad", ogrenciDto.soyad);
            parameters.Add("@telefon_no", ogrenciDto.telefon_no);
            parameters.Add("@adres", ogrenciDto.adres);
            parameters.Add("@cinsiyet", ogrenciDto.cinsiyet);
            parameters.Add("@dogum_tarihi", ogrenciDto.dogum_tarihi);
            parameters.Add("@veli_id", ogrenciDto.veli_id); 
            parameters.Add("@sınıf_id", ogrenciDto.sınıf_id);
            parameters.Add("@ögretmen_id", ogrenciDto.ögretmen_id);
            parameters.Add("ögrenci_id", ogrenciDto.ögrenci_id);
            
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }       
}
