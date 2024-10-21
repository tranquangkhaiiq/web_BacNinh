namespace webvl2024_BacNinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomQuyen")]
    public partial class NhomQuyen
    {
        [Key]
        public int nhomquyen_id { get; set; }

        [StringLength(500)]
        public string nhomquyen_manhomquyen { get; set; }

        [StringLength(500)]
        public string nhomquyen_ten { get; set; }

        public bool? nhomquyen_kichhoat { get; set; }

        public string nhomquyen_ghichu { get; set; }

        public DateTime? ngaytao { get; set; }
    }
}
