using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class DanhMucKyThuatXNViewModel
    {
        public int RowIDKyThuatXn { get; set; }

        public string IDKyThuatXN { get; set; }

        public byte? STT { get; set; }

        public bool? isLocked { get; set; }

        public string TenKyThuat { get; set; }

        public string TenHienThiKyThuat { get; set; }

    }
}