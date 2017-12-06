using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class DanhMucDonViCoSoViewModel
    {
        public Int16 RowIDDVCS { get; set; }

        public string MaDVCS { get; set; }

        public string TenDVCS { get; set; }

        public string DiaChiDVCS { get; set; }

        public string SDTCS { get; set; }

        public bool? isLocked { get; set; }

        public byte[] Logo { get; set; }

        public byte[] HeaderReport { get; set; }

        public int? Stt { get; set; }

        public string MaChiCuc { get; set; }

        public string TenChiCuc { get; set; }
        public string Email { get; set; }

    }
}