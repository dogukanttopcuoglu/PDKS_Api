namespace PDKS_Api.Dtos.OgrenciDtos
{
    public class UpdateOgrenciDto
    {
        public int ögrenci_id { get; set; }
        public string ogrenci_ad { get; set; }
        public string ogrenci_soyad { get; set; }
        public string ogrenci_telefon_no { get; set; }
        public string? ogrenci_adres { get; set; }
        public string ogrenci_cinsiyet { get; set; }
        public DateTime ogrenci_dogum_tarihi { get; set; }
        public int ogrenci_veli_id { get; set; }
        public int ogrenci_sınıf_id { get; set; }
        public int ogrenci_ögretmen_id { get; set; }
    }
}

