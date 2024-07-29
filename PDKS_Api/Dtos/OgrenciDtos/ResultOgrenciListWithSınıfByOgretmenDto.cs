using PDKS_Api.Dtos.OgretmenDtos;
using System;
using System.Text.Json.Serialization;

namespace PDKS_Api.Dtos.OgrenciDtos
{
    public class ResultOgrenciListWithSınıfByOgretmenDto
    {
        public int ögrenci_id { get; set; }

       
        public string ogrenci_ad { get; set; }


        public string ogrenci_soyad { get; set; }
        public string ogrenci_telefon_no { get; set; }
        public string? ogrenci_adres { get; set; }
        public string ogrenci_cinsiyet { get; set; }

        [JsonIgnore]
        public DateTime ogrenci_dogum_tarihi { get; set; }

        [JsonPropertyName("dogum_tarihi")]
        public string FormattedDogumTarihi
        {
            get
            {
                return ogrenci_dogum_tarihi.ToString("yyyy-MM-dd");
            }
        }

        //public ResultOgretmenDto ogretmenAd { get; set; }
        public string ogretmen_ad { get; set; }


    }
}
