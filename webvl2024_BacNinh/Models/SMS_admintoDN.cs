namespace webvl2024_BacNinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SMS_admintoDN
    {
        public Guid Id { get; set; }

        [StringLength(200)]
        public string Tieude { get; set; }

        [Column("SMS_AdmintoDN")]
        [StringLength(2000)]
        public string SMS_AdmintoDN1 { get; set; }

        public int DNID { get; set; }

        public bool DaXem { get; set; }

        public DateTime Ngay { get; set; }
    }
}
