using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
    public class TTPhieuCB
    {
        public int? TongSoPhieu { get; set; }
        public int? PhieuThuMoi { get; set; }
        public int? PhieuThuLai { get; set; }
        public int? Nam { get; set; }
        public int? Nu { get; set; }
        public int? GTKhac { get; set; }
        public int? PPSinhThuong { get; set; }
        public int? PPSinhMo { get; set; }
        public int? PPSinhKhac { get; set; }
        public int? MauDat { get; set; }
        public int? MauKoDat { get; set; }
        public List<rptBaoCaoSLPhieu> slphieu { get; set; }
    }
}
