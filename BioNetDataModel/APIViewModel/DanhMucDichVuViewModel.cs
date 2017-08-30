using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class DanhMucDichVuViewModel
    {
        public int RowIDDichVu { get; set; }

        public string IDDichVu { get; set; }

        public string TenDichVu { get; set; }

        public decimal? GiaDichVu { get; set; }

        public int MaNhom { get; set; }

        public bool isLocked { get; set; }

        public bool isGoiXn { get; set; }

        public string TenHienThiDichVu { get; set; }

        public string TenNhom { get; set; }
    }
}