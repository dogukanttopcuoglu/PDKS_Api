namespace PDKS_Api.Dtos.OgrenciDtos
{
    public class UpdateOgrenciDto
    {
        public int ögrenci_id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon_no { get; set; }
        public string? adres { get; set; }
        public string cinsiyet { get; set; }
        public DateTime dogum_tarihi { get; set; }
        public int veli_id { get; set; }
        public int sınıf_id { get; set; }
        public int ögretmen_id { get; set; }
    }
}

