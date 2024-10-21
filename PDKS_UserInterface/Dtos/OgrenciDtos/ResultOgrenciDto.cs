using System.Text.Json.Serialization;

namespace PDKS_UserInterface.Dtos.OgrenciDtos
{
    public class ResultOgrenciDto
    {
        public int ögrenci_id { get; set; }
        public string ogrenci_ad { get; set; }
        public string ogrenci_soyad { get; set; }
        public string ogrenci_telefon_no { get; set; }
        public string ogrenci_adres { get; set; }
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

        public int ogrenci_veli_id { get; set; }
        public int ogrenci_sınıf_id { get; set; }
        public int ogrenci_ögretmen_id { get; set; }
    }
}


