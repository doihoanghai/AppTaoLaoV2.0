using Bionet.API.Models;
using Bionet.Web.Models;
using System;
using BioNetModel.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class ChiTietGoiDichVuViewModel
    {
        public string IDGoiDichVuChung { get; set; }
        public List<PSDanhMucDichVu> lstDanhMucDichVu { get; set; }
    }
}