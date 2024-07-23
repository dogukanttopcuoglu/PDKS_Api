namespace PDKS_Api.Dtos.OgretmenDtos
{
    public class GetByIDOgretmenDto
    {
        public int ögretmen_id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon_no { get; set; }
        public string mail { get; set; }
        public string adres { get; set; }
        public string cinsiyet { get; set; }
        public DateTime dogum_tarihi { get; set; }
    }
}
