using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.Web.Models
{
    public class DanhMucGoiDichVuChungViewModel
    {
        public int RowIDGoiDichVuChung { get; set; }

        public string IDGoiDichVuChung { get; set; }

        public string TenGoiDichVuChung { get; set; }

        public double? ChietKhau { get; set; }

        public decimal? DonGia { get; set; }
    }
}