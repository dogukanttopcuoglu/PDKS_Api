namespace PDKS_Api.Dtos.OgretmenDtos
{
    public class GetByIDOgretmenDto
    {
        public int ögretmen_id { get; set; }
        public string ogretmen_ad { get; set; }
        public string ogretmen_soyad { get; set; }
        public string ogretmen_telefon_no { get; set; }
        public string ogretmen_mail { get; set; }
        public string ogretmen_adres { get; set; }
        public string ogretmen_cinsiyet { get; set; }
        public DateTime ogretmen_dogum_tarihi { get; set; }
    }
}
