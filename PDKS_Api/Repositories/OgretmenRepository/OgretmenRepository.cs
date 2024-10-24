﻿using Dapper;
using Microsoft.IdentityModel.Tokens;
using PDKS_Api.Dtos.OgretmenDtos;
using PDKS_Api.Dtos.VeliDtos;
using PDKS_Api.Models.DapperContext;

namespace PDKS_Api.Repositories.OgretmenRepository
{
    public class OgretmenRepository : IOgretmenRepository
    {
        private readonly Context _context;

        public OgretmenRepository(Context context)
        {
            _context = context;
        }

        public async void CreateOgretmen(CreateOgretmenDto ogretmenDto)
        {
            string query = "insert into Ogretmen (ogretmen_ad,ogretmen_soyad,ogretmen_telefon_no,ogretmen_mail,ogretmen_adres,ogretmen_cinsiyet,ogretmen_dogum_tarihi) values (@ogretmen_ad,@ogretmen_soyad,@ogretmen_telefon_no,@ogretmen_mail,@ogretmen_adres,@ogretmen_cinsiyet,@ogretmen_dogum_tarihi)";
            var parameters = new DynamicParameters();
            parameters.Add("@ogretmen_ad", ogretmenDto.ogretmen_ad);
            parameters.Add("@ogretmen_soyad", ogretmenDto.ogretmen_soyad);
            parameters.Add("@ogretmen_telefon_no", ogretmenDto.ogretmen_telefon_no);
            parameters.Add("@ogretmen_mail", ogretmenDto.ogretmen_mail);
            parameters.Add("@ogretmen_adres", ogretmenDto.ogretmen_adres);
            parameters.Add("@ogretmen_cinsiyet", ogretmenDto.ogretmen_cinsiyet);
            parameters.Add("@ogretmen_dogum_tarihi", ogretmenDto.ogretmen_dogum_tarihi);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteOgretmen(int id)
        {
            string query = "Delete From Ogretmen Where ögretmen_id=@ögretmen_id";
            var parameters = new DynamicParameters();
            parameters.Add("@ögretmen_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultOgretmenDto>> GetAllOgretmenAsync()
        {
            string query = "Select * From Ogretmen";
            using(var connection=_context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultOgretmenDto>(query);
                return values.ToList();

               
            }
        }

        public async Task<GetByIDOgretmenDto> GetOgretmen(int id)
        {
            string query = "Select * From Ogretmen Where ögretmen_id=@ögretmen_id";
            var parameters = new DynamicParameters();
            parameters.Add("@ögretmen_id", id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDOgretmenDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateOgretmen(UpdateOgretmenDto ogretmenDto)
        { 
            string query = "Update Ogretmen Set ogretmen_ad=@ogretmen_ad,ogretmen_soyad=@ogretmen_soyad,ogretmen_telefon_no=@ogretmen_telefon_no,ogretmen_mail=@ogretmen_mail,ogretmen_adres=@ogretmen_adres,ogretmen_cinsiyet=@ogretmen_cinsiyet,ogretmen_dogum_tarihi=@ogretmen_dogum_tarihi where ögretmen_id=@ögretmen_id";
            var parameters = new DynamicParameters();
            parameters.Add("@ogretmen_ad", ogretmenDto.ogretmen_ad);
            parameters.Add("@ogretmen_soyad", ogretmenDto.ogretmen_soyad);
            parameters.Add("@ogretmen_telefon_no", ogretmenDto.ogretmen_telefon_no);
            parameters.Add("@ogretmen_mail", ogretmenDto.ogretmen_mail);
            parameters.Add("@ogretmen_adres", ogretmenDto.ogretmen_adres);
            parameters.Add("@ogretmen_cinsiyet", ogretmenDto.ogretmen_cinsiyet);
            parameters.Add("@ogretmen_dogum_tarihi", ogretmenDto.ogretmen_dogum_tarihi);
            parameters.Add("@ögretmen_id", ogretmenDto.ögretmen_id);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }


        }
    }
}
