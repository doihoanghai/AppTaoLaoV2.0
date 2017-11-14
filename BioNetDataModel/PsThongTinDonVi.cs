using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace BioNetModel
{
   public class PsThongTinDonVi
    {
        public string MaDonVi { get; set; }
        public string TenDonVi { get; set; }
        public string DiaChi { get; set; }
        public  string SoDt { get; set; }
        public bool  isLocked { get; set; }
        public Image LogoDonVi { get; set; }
        public Image Header { get; set; }
        public Image ChuKiDonVI { get; set; }
        public int KieuTraKetQua { get; set; }
        public int  Stt { get; set; }
        public string  MaChiCuc { get; set; }
    }
}
