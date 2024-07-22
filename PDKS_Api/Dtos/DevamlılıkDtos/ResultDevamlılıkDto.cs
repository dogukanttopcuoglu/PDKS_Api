namespace PDKS_Api.Dtos.DevamlılıkDtos
{
    public class ResultDevamlılıkDto
    {
        public int devam_id{ get; set; }
        public DateTime giris { get; set; }
        public DateTime cikis { get; set; }
        public int? ögrenci_id { get; set; }
        public int? ögretmen_id { get; set; }
    }

}
