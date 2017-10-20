using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class XN_KetQuaViewModel
    {
        public long RowIDKetQua { get; set; }

        public DateTime? NgayTraKQ { get; set; }

        public string UserTraKQ { get; set; }

        public DateTime? NgayLamXetNghiem { get; set; }

        public string MaPhieu { get; set; }

        public string MaChiDinh { get; set; }

        public string MaDonVi { get; set; }

        public string MaKetQua { get; set; }

        public string MaXetNghiem { get; set; }

        public string MaTiepNhan { get; set; }

        public bool isCoKQ { get; set; }

        public DateTime? NgayChiDinh { get; set; }

        public DateTime? NgayTiepNhan { get; set; }

        public string GhiChu { get; set; }

        public bool? isDongBo { get; set; }

        public bool? isXoa { get; set; }

        public string MaGoiXN { get; set; }

        public string IDNhanVienXoa { get; set; }

        public DateTime? NgayGioXoa { get; set; }

        public string LyDoXoa { get; set; }

        public string MaDVCS { get; set; }

        public string MaTrungTam { get; set; }

        public List<XN_KetQua_ChiTietViewModel> lstKetQuaChiTiet { get; set; }
    }
}