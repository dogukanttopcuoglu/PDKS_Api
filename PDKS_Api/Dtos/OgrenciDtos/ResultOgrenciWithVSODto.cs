using System.Text.Json.Serialization;

namespace PDKS_Api.Dtos.OgrenciDtos
{
    public class ResultOgrenciWithVSODto
    {
        public int ögrenci_id { get; set; }
        public string ogrenci_ad { get; set; }
        public string ogrenci_soyad { get; set; }
        public string ogrenci_telefon_no { get; set; }
        public string? ogrenci_adres { get; set; }
        public string ogrenci_cinsiyet { get; set; }

        [JsonIgnore]
        public DateTime ogrenci_dogum_tarihi { get; set; }

        [JsonPropertyName("ogrenci_dogum_tarihi")]
        public string FormattedDogumTarihi
        {
            get
            {
                return ogrenci_dogum_tarihi.ToString("yyyy-MM-dd");
            }
        }

        public string veli_ad { get; set; }
        public string sınıf_ad { get; set; }
        //public virtual ResultOgretmenDto ResultOgretmenDto { get; set; }

        public string ogretmen_ad { get; set; }
    }
}
