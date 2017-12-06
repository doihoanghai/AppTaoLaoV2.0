using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
    public class PSXN_TraKetQuaDuyetNhanh
    {
        public long RowIDXN_TraKetQua { get; set; }

        public DateTime? NgayTraKQ { get; set; }

        public string UserTraKQ { get; set; }

        public string MaPhieu{ get; set; }

        public string KetLuanTongQuat{ get; set; }

        public string GhiChu{ get; set; }

        public string IDCoSo{ get; set; }

        public string MaTiepNhan{ get; set; }

        public bool? isDaDuyetKQ{ get; set; }

        public DateTime? NgayCoKQ{ get; set; }

        public DateTime? NgayTiepNhan{ get; set; }

        public DateTime? NgayChiDinh{ get; set; }

        public DateTime? NgayLamXetNghiem{ get; set; }

        public string MaXetNghiem{ get; set; }

        public bool isTraKQ{ get; set; }

        public string MaPhieuCu{ get; set; }

        public string GhiChuPhongXetNghiem{ get; set; }

        public bool? isDongBo{ get; set; }

        public bool? isXoa{ get; set; }

        public string IDNhanVienXoa{ get; set; }

        public DateTime? NgayGioXoa{ get; set; }

        private string LyDoXoa{ get; set; }

        public string MaGoiXN{ get; set; }

        public bool isNguyCoCao{ get; set; }
        public bool nguyCo{ get; set; }
        public bool xnLai { get; set; }

    }
}
