using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.API.Models
{
  
    public class ChiDinhDichVuChiTietViewModel
    {

        public long RowIDDichVuChiTiet { get; set; }

        public string MaChiDinh { get; set; }

        public string MaPhieu { get; set; }

        public string MaDonVi { get; set; }

        public string MaGoiDichVu { get; set; }

        public string MaDichVu { get; set; }

        public decimal? GiaTien { get; set; }

        public byte? SoLuong { get; set; }

        public bool isXetNghiemLan2 { get; set; }
    }
}
