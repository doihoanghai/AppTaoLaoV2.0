using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
 public   class PsTinhTrangPhieu
    {
        public string  IDPhieu { get; set; }
        public string MaDonVi { get; set; }
        public string TenBenhNhan { get; set; }
        public string TenMe { get; set; }
        public DateTime NamSinhMe { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayNhanMau { get; set; }
        public int TinhTrangMau { get; set; }
        public string TinhTrangMau_Text { get; set; }
        public string MaBenhNhan { get; set; }
        public string TenDonVi { get; set; }
        public string MaKhachHang { get; set; }
        public string TenCha { get; set; }
        public string SdtMe { get; set; }
        public string SdtCha { get; set; }
        public DateTime  NamSinhCha { get; set; }
    }
}
