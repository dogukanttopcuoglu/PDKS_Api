using System.Text.Json.Serialization;

namespace PDKS_UserInterface.Dtos.OgrenciDtos
{
    public class ResultOgrenciDto
    {
        public int ögrenci_id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon_no { get; set; }
        public string adres { get; set; }
        public string cinsiyet { get; set; }

        [JsonIgnore]
        public DateTime dogum_tarihi { get; set; }

        [JsonPropertyName("dogum_tarihi")]
        public string FormattedDogumTarihi
        {
            get
            {
                return dogum_tarihi.ToString("yyyy-MM-dd");
            }
        }

        public int veli_id { get; set; }
        public int sınıf_id { get; set; }
        public int ögretmen_id { get; set; }
    }
}


