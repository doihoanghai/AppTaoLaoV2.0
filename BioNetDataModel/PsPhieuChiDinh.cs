using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
    class PsPhieuChiDinh
    {
        public long RowIDChiDinh;

        public string IDNhanVienChiDinh;

        public string MaChiDinh;

        public DateTime NgayChiDinhLamViec;

        public DateTime NgayChiDinhHienTai;

        public string IDGoiDichVu;

        public string MaDonVi;

        public string MaPhieu;

        public decimal DonGia;

        public byte SoLuong;

        public byte TrangThai;

        public string MaPhieuLan1;

        public  bool isLayMauLai;

        public string MaNVChiDinh;

        public string MaTiepNhan;

        public DateTime? NgayTiepNhan;

        public bool? isDongBo;

        public bool? isXoa;

        public string IDNhanVienXoa;

        public DateTime NgayGioXoa;

        public string lyDoXoa;

        public bool isDaNhapLieu;

        public List<PSChiDinhDichVuChiTiet> PSChiDinhDichVuChiTiets;

    }
}
