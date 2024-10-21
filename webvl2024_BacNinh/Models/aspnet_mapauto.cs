namespace webvl2024_BacNinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class aspnet_mapauto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Keystr { get; set; }

        [StringLength(500)]
        public string Giaithich { get; set; }

        public DateTime? Ngay { get; set; }
    }
}
