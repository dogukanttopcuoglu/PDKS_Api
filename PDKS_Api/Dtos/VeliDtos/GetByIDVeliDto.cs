
namespace PDKS_Api.Dtos.VeliDtos
{
    public class GetByIDVeliDto
    {
        public int veli_id { get; set; }
        public string veli_ad { get; set; }
        public string veli_soyad { get; set; }
        public string veli_telefon_no { get; set; }
        public string veli_mail { get; set; }
        public string veli_adres { get; set; }
        public string veli_cinsiyet { get; set; }
        public DateTime veli_dogum_tarihi { get; set; }
    }
}
