using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BioNetModel
{
   public class PsThongTinTrungTam
    {
        public string MaTrungTam { get; set; }
        public string TenTrungTam { get; set; }
        public string DiaChi { get; set; }
        public string  MaVietTat { get; set; }
        public Image  Logo { get; set; }
        public string DienThoai { get; set; }
        public bool isChoXetNghiemLan2 { get; set; }
        public bool isChoThuMauLai { get; set; }
        public Image Hearder { get; set; }
        public Image ChuKiTT { get; set; }
        public Image ChuKiXN { get; set; }

    }
}
