namespace webvl2024_BacNinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quyen")]
    public partial class Quyen
    {
        [Key]
        public int quyen_id { get; set; }

        [StringLength(500)]
        public string quyen_maquyen { get; set; }

        [StringLength(500)]
        public string quyen_ten { get; set; }

        public bool? quyen_kichhoat { get; set; }

        public string quyen_ghichu { get; set; }

        public DateTime? ngaytao { get; set; }
    }
}
