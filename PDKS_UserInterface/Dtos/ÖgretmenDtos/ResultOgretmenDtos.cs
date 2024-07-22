using System.Text.Json.Serialization;

namespace PDKS_UserInterface.Dtos.ÖgretmenDtos
{
    public class ResultOgretmenDtos
    {
        public int ögretmen_id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon_no { get; set; }
        public string mail { get; set; }
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



    }
}
