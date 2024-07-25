﻿using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace PDKS_Api.Dtos.VeliDtos
{
    public class CreateVeliDto
    {
        
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon_no { get; set; }
        public string mail { get; set; }
        public string adres { get; set; }
        public string cinsiyet { get; set; }
        public DateTime? dogum_tarihi { get; set; }

     
    }
}