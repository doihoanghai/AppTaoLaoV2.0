using Bionet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Model.Models
{
    public class MapsXetNghiem_ThongSoViewModel
    {
        public string idKyThuat { get; set; }
        public List<ThongSoKyThuatViewModel> mapxnts { get; set; }
    }
}
