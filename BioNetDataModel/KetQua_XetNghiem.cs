using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
    public class KetQua_XetNghiem
    {
        public DateTime ngayTraKQ { get; set; }
        public string  maNhanVienTraKQ { get; set; }
        public string maPhieu { get; set; }
        public string  KetLuanTong { get; set; }
        public  string GhiChu { get; set; }
        public string  maDonVi { get; set; }
        public string maTiepNhan { get; set; }
        public string maChiDinh { get; set; }
        public string  maKetQua { get; set; }
        public string maGoiXetNghiem { get; set; }
        public string maXetNghiem { get; set; }
        public DateTime ngayXetNghiem { get; set; }
        public DateTime ngayTiepNhan { get; set; }
        public DateTime ngayChiDinh { get; set; }
        public List<PsKetQua_ChiTiet> KetQuaChiTiet { get; set; }
    }
}
