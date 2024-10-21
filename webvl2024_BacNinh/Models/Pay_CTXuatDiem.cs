namespace webvl2024_BacNinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pay_CTXuatDiem
    {
        public Guid Id { get; set; }

        public int DNID { get; set; }

        [Required]
        [StringLength(50)]
        public string Idsp { get; set; }

        public int ID_giaSP { get; set; }

        public DateTime? Ngay { get; set; }
    }
}
