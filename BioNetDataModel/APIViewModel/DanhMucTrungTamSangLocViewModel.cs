using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class DanhMucTrungTamSangLocViewModel
    {
        public Int16 RowIDTTSL { get; set; }

        public string MaTTSL { get; set; }

        public string TenTTSL { get; set; }

        public string DiaChiTTSL { get; set; }

        public string SDTTTSL { get; set; }

        public bool? isLocked { get; set; }

        public byte[] Logo { get; set; }

        public byte[] HeaderReport { get; set; }

        public byte? Stt { get; set; }

        public byte? MaTongCuc { get; set; }

        public string ID { get; set; }

        public string LicenseKey { get; set; }
    }
}