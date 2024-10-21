namespace webvl2024_BacNinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        public int NV_ID { get; set; }

        [StringLength(500)]
        public string NV_HoTen { get; set; }

        public DateTime? NV_NgaySinh { get; set; }

        public int? NV_GioiTinhID { get; set; }

        [StringLength(500)]
        public string NV_Avatar { get; set; }

        [StringLength(500)]
        public string NV_CMND { get; set; }

        public DateTime? NV_CMND_NgayCap { get; set; }

        [StringLength(500)]
        public string NV_CMND_NoiCap { get; set; }

        [StringLength(500)]
        public string NV_CCCD { get; set; }

        public DateTime? NV_CCCD_NgayCap { get; set; }

        [StringLength(500)]
        public string NV_CCCD_NoiCap { get; set; }

        [StringLength(500)]
        public string NV_HoChieu { get; set; }

        public DateTime? NV_HoChieu_NgayCap { get; set; }

        [StringLength(500)]
        public string NV_HoChieu_NoiCap { get; set; }

        [StringLength(500)]
        public string NV_SoDienThoai { get; set; }

        [StringLength(500)]
        public string NV_Email { get; set; }

        [StringLength(500)]
        public string NV_DiaChi { get; set; }

        public int? NV_DiaChi_TinhID { get; set; }

        public int? NV_DiaChi_HuyenID { get; set; }

        public int? NV_DiaChi_XaID { get; set; }

        public int? NV_DiaChi_KhuPhoID { get; set; }

        public int? NV_DiaChi_ToID { get; set; }

        public bool? NV_KichHoat { get; set; }

        public DateTime? NV_NgayTao { get; set; }

        public int? NV_NguoiTao { get; set; }

        public string NV_GhiChu { get; set; }
    }
}
