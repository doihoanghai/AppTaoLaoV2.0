using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class TiepNhanViewModel
    {
      
        public long RowIDTiepNhan { get; set; }

        public DateTime? NgayTiepNhan { get; set; }

      
        public string MaNVTiepNhan { get; set; }

       
        public string MaPhieu { get; set; }

      
        public string MaDonVi { get; set; }

        public bool isDaDanhGia { get; set; }

      
        public string MaTiepNhan { get; set; }

      
        public long? RowIDPhieu { get; set; }

        public bool? isDaNhapLieu { get; set; }

      
        public string MaDVCS { get; set; }

       
        public string MaTrungTam { get; set; }

        public List<TiepNhanViewModel> lstTiepNhanVM { get; set; }
    }
}