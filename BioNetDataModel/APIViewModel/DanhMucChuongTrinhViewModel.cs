using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class DanhMucChuongTrinhViewModel
    {
        public long RowIDChuongTrinh { get; set; }

        public string IDChuongTrinh { get; set; }

        public string TenChuongTrinh { get; set; }

        public string Ngaytao { get; set; }

        public string NgayHetHieuLuc { get; set; }

        public bool? isLocked { get; set; }
    }
}