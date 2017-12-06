using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BioNetModel.Data;

namespace BioNetModel
{
    public class TraKetQua_XetNghiem
    {
        public DateTime  ngayTraKQ { get; set; }
        public string userTraKQ { get; set; }
        public string maPhieu { get; set; }
        public string ketLuan { get; set; }
        public string ghiChu { get; set; }
        public string maDonVi { get; set; }
        public string maTiepNhan { get; set; }
        public bool isDaDuyet { get; set; }
        public DateTime? ngayCoKQ { get; set; }
        public bool isTraKQ { get; set; }
        public string MaPhieuLan1 { get; set; }
        public DateTime ngayDuyetKQ { get; set; }
        public List< PSXN_TraKQ_ChiTiet >chiTietKQ { get; set; }
        public bool isNguyCo { get; set; }
    }
}
