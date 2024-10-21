using System.Text.Json.Serialization;

namespace PDKS_UserInterface.Dtos.VeliDtos
{
    public class ResultVeliDto
    {
        public int veli_id { get; set; }
        public string veli_ad { get; set; }
        public string veli_soyad { get; set; }
        public string veli_telefon_no { get; set; }
        public string veli_mail { get; set; }
        public string veli_adres { get; set; }
        public string veli_cinsiyet { get; set; }

        [JsonIgnore]
        public DateTime veli_dogum_tarihi { get; set; }

        [JsonPropertyName("dogum_tarihi")]
        public string FormattedDogumTarihi
        {
            get
            {
                return veli_dogum_tarihi.ToString("yyyy-MM-dd");
            }
        }
    }
}
