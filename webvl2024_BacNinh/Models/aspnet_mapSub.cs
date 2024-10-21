namespace webvl2024_BacNinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class aspnet_mapSub
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Substr { get; set; }

        public int mapautoId { get; set; }

        public DateTime? Ngay { get; set; }
    }
}
