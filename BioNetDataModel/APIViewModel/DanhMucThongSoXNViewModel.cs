using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class DanhMucThongSoXNViewModel
    {
        public int RowIDThongSo { get; set; }

        public string IDThongSoXN { get; set; }

        public string TenThongSo { get; set; }

        public Int16? MaDonViTinh { get; set; }

        public double? GiaTriMinNu { get; set; }

        public double? GiaTriMaxNu { get; set; }

        public string GiaTriTrungBinhNu { get; set; }

        public string GiaTriMacDinh { get; set; }

        public double? GiaTriMinNam { get; set; }

        public double? GiaTriMaxNam { get; set; }

        public string GiaTriTrungBinhNam { get; set; }

        public byte? MaNhom { get; set; }

        public string TenNhom { get; set; }

        public byte? Stt { get; set; }

        public string GiaTri { get; set; }

        public bool? isLocked { get; set; }

        public string DonViTinh { get; set; }

        public string MaDVCS { get; set; }

        public string MaTrungTam { get; set; }
    }
}