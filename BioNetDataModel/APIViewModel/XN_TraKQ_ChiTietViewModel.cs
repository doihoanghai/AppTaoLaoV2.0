using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class XN_TraKQ_ChiTietViewModel
    {
        public long RowIDXN_TraKetQua_ChiTiet { get; set; }

        public string MaDichVu { get; set; }

        public string IDThongSoXN { get; set; }

        public string TenThongSo { get; set; }

        public string TenKyThuat { get; set; }

        public string IDKyThuat { get; set; }

        public string GiaTri1 { get; set; }

        public double? GiaTriMin { get; set; }

        public double? GiaTriMax { get; set; }

        public string DonViTinh { get; set; }

        public bool isNguyCo { get; set; }

        public string GiaTriTrungBinh { get; set; }

        public string GiaTri2 { get; set; }

        public string GiaTriCuoi { get; set; }

        public int? IDDonViTinh { get; set; }

        public string KetLuan { get; set; }

        public string MaTiepNhan { get; set; }

        public string MaPhieu { get; set; }

        public bool isDaDuyetKQ { get; set; }

        public bool isMauXNLai { get; set; }

        public byte? Stt { get; set; }

        public bool? isDongBo { get; set; }

        public bool? isXoa { get; set; }

        public string IDNhanVienXoa { get; set; }

        public DateTime? NgayGioXoa { get; set; }

        public string MaDVCS { get; set; }

        public string MaTrungTam { get; set; }

        public List<XN_TraKQ_ChiTietViewModel> lstKetQuaChiTiet { get; set; }

    }
}