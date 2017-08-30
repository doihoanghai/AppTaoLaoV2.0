using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
  public  class rptChiTietTrungTam
    {
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public List<rptChiTietTrungTam_ChiTiet> ChiTietCacChiCuc { get; set; }
        public PsThongTinTrungTam ThongTinTrungTam { get; set; }
    }
}
