using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.API.Models
{
 
    public class ChiDinhDichVuViewModel
    {

        public long RowIDChiDinh { get; set; }

        public string IDNhanVienChiDinh { get; set; }

        public string MaChiDinh { get; set; }

        public DateTime? NgayChiDinhLamViec { get; set; }

        public DateTime? NgayChiDinhHienTai { get; set; }

        public string IDGoiDichVu { get; set; }

        public string MaDonVi { get; set; }

        public string MaPhieu { get; set; }

        public decimal DonGia { get; set; }

        public byte? SoLuong { get; set; }

        public byte? TrangThai { get; set; }

        public string MaPhieuLan1 { get; set; }

        public bool isLayMauLai { get; set; }

        public string MaNVChiDinh { get; set; }

        public string MaTiepNhan { get; set; }

        public DateTime? NgayTiepNhan { get; set; }

        public bool isNhapLieu { get; set; }

        public List<ChiDinhDichVuChiTietViewModel> listCDDVCTVM { get; set; }

    }
}
