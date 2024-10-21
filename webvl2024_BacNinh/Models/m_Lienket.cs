namespace webvl2024_BacNinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_Lienket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(505)]
        public string Tenweb { get; set; }

        [Required]
        [StringLength(500)]
        public string link { get; set; }

        public int loaiId { get; set; }

        [StringLength(500)]
        public string Gioithieu { get; set; }

        public DateTime? Ngay { get; set; }
    }
}
