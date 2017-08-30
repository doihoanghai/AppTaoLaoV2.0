using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class PhieuSangLocViewModel
    {
        public long RowIDPhieu { get; set; }

        public string IDPhieu { get; set; }

        public string MaBenhNhan { get; set; }

        public DateTime? NgayTaoPhieu { get; set; }

        public string IDNhanVienTaoPhieu { get; set; }

        public string IDCoSo { get; set; }

        public string NgayGioLayMau { get; set; }

        public DateTime? NgayGioLayMauTime { get; set; }

        public byte? IDViTriLayMau { get; set; }

        public string Username { get; set; }
        public string IDNhanVienLayMau { get; set; }

        public bool isLayMauLan2 { get; set; }

        public string IDPhieuLan1 { get; set; }

        public byte? TinhTrangLucLayMau { get; set; }

        public Int16? SLTruyenMau { get; set; }

        public string NgayTruyenMau { get; set; }

        public byte? CheDoDinhDuong { get; set; }

        public bool TrangThaiPhieu { get; set; }

        public byte? TrangThaiMau { get; set; }

        public bool isKhongDat { get; set; }

        public DateTime? NgayNhanMau { get; set; }

        public string MaXetNghiem { get; set; }

        public string Para { get; set; }

        public bool isTruoc24h { get; set; }

        public bool isSinhNon { get; set; }

        public bool isNheCan { get; set; }

        public bool isGuiMauTre { get; set; }

        public string IDChuongTrinh { get; set; }

        public string MaGoiXN { get; set; }

        public string TenNhanVienLayMau { get; set; }

        public string SDTNhanVienLayMau { get; set; }

        public string NoiLayMau { get; set; }

        public bool isHuyMau { get; set; }

        public string LyDoKhongDat { get; set; }

        public bool? isDongBo { get; set; }

        public bool? isXoa { get; set; }

        public string DiaChiLayMau { get; set; }

        public bool? isXNLan2 { get; set; }

        public string IDNhanVienXoa { get; set; }

        public DateTime? NgayGioXoa { get; set; }

        public string MaDVCS { get; set; }

        public string MaTrungTam { get; set; }

        //

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string FatherBirthday { get; set; }

        public string MotherBirthday { get; set; }

        public string FatherPhoneNumber { get; set; }

        public string MotherPhoneNumber { get; set; }

        public string MaKhachHang { get; set; }

        public string DiaChi { get; set; }

        public string TenBenhNhan { get; set; }

        public string NgayGioSinh { get; set; }
        public DateTime? NgayGioSinhTime { get; set; }

        public int CanNang { get; set; }

        public int TuanTuoiKhiSinh { get; set; }

        public string NoiSinh { get; set; }

        public int QuocTichID { get; set; }

        public int DanTocID { get; set; }

        public int PhuongPhapSinh { get; set; }

        public int GioiTinh { get; set; }

        public string IDThaiPhuTienSoSinh { get; set; }

        //
        public bool CheckAccountAuthen { get; set; }
    }
}