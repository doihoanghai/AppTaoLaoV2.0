using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
    public class PsChiDinhvsDanhGia
    {
        public decimal RowIDChiDinh { get; set; }
        public string  MaNVChiDinh { get; set; }
        public string MaChiDinh { get; set; }
        public DateTime NgayChiDinhLamViec { get; set; }
        public DateTime NgayChiDinhHienTai { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public string  MaGoiDichVu { get; set; }
        public string MaDonVi { get; set; }
        public PsPhieu Phieu { get; set; }
        public decimal DonGia { get; set; }
        public byte SoLuong { get; set; }
        public byte TrangThaiChiDinh { get; set; }
        public string MaPhieuLan1 { get; set; }
        public bool isLayMauLai { get; set; }
        public string MaPhieu { get; set; }
        public string MaTiepNhan { get; set; }
        public List<PsDichVu> lstDichVu { get; set; }


    }
}
