using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class DanhMucChiCucViewModel
    {
        public int RowIDChiCuc { get; set; }

        public string MaChiCuc { get; set; }

        public string TenChiCuc { get; set; }

        public string DiaChiChiCuc { get; set; }

        public string SdtChiCuc { get; set; }

        public bool? isLocked { get; set; }

        public byte[] Logo { get; set; }

        public byte[] HeaderReport { get; set; }

        public Int16? Stt { get; set; }

        public string MaTrungTam { get; set; }

        public string TenTTSL { get; set; }

    }
}