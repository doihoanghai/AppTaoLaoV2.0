using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class XN_KetQua_ChiTietViewModel
    {
        public long RowIDKetQuaChiTiet { get; set; }

        public string MaKQ { get; set; }

        public string MaDichVu { get; set; }

        public string MaThongSoXN { get; set; }

        public string TenThongSo { get; set; }

        public string TenKyThuat { get; set; }

        public string MaKyThuat { get; set; }

        public string GiaTri { get; set; }

        public double? GiaTriMinNu { get; set; }

        public double? GiaTriMaxNu { get; set; }

        public string GiaTriTrungBinhNu { get; set; }

        public double? GiaTriMinNam { get; set; }

        public double? GiaTriMaxNam { get; set; }

        public string GiaTriTrungBinhNam { get; set; }

        public string DonViTinh { get; set; }

        public int? MaDonViTinh { get; set; }

        public bool isNguyCo { get; set; }

        public string MaXetNghiem { get; set; }

        public bool? isDongBo { get; set; }

        public bool? isXoa { get; set; }

        public string IDNhanVienXoa { get; set; }

        public DateTime? NgayGioXoa { get; set; }

        public string MaDVCS { get; set; }

        public string MaTrungTam { get; set; }

        public List<XN_KetQua_ChiTietViewModel> lstKetQuaChiTiet { get; set; }
    }
}