namespace PDKS_Api.Dtos.DevamlılıkDtos
{
    public class ResultDevamlılıkDto
    {
        public int devam_id{ get; set; }
        public DateTime giris { get; set; }
        public DateTime cikis { get; set; }
        public int? devamlılık_ögrenci_id { get; set; }
        public int? devamlılık_ögretmen_id { get; set; }
    }

}
