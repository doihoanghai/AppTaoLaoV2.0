using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
   public class PsDsDaTiepNhan
    {
        public DateTime NgayTiepNhan { get; set; }
        public string MaNVTiepNhan { get; set; }
        public string MaPhieu { get; set; }
        public string MaDonVi { get; set; }
        public bool isDaDanhGia { get; set; }
        public string MaTiepNhan { get; set; }
        public bool isDaNhapLieu { get; set; }
    }
}
