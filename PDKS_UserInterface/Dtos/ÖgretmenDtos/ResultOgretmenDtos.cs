using System.Text.Json.Serialization;

namespace PDKS_UserInterface.Dtos.ÖgretmenDtos
{
    public class ResultOgretmenDtos
    {
        public int ögretmen_id { get; set; }
        public string ogretmen_ad { get; set; }
        public string ogretmen_soyad { get; set; }
        public string ogretmen_telefon_no { get; set; }
        public string ogretmen_mail { get; set; }
        public string ogretmen_adres { get; set; }
        public string ogretmen_cinsiyet { get; set; }

        [JsonIgnore]
        public DateTime ogretmen_dogum_tarihi { get; set; }

        [JsonPropertyName("ogretmen_dogum_tarihi")]
        public string FormattedDogumTarihi
        {
            get
            {
                return ogretmen_dogum_tarihi.ToString("yyyy-MM-dd");
            }
        }



    }
}
