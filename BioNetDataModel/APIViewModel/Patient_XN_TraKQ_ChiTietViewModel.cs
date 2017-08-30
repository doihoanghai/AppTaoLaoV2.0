using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class Patient_XN_TraKQ_ChiTietViewModel
    {
        public string TenThongSo { get; set; }

        public string TenKyThuat { get; set; }

        public string GiaTri1 { get; set; }

        public double? GiaTriMin { get; set; }

        public double? GiaTriMax { get; set; }

        public string DonViTinh { get; set; }

        public bool isNguyCo { get; set; }

        public string GiaTriTrungBinh { get; set; }

        public string GiaTri2 { get; set; }

        public string GiaTriCuoi { get; set; }

        public int? IDDonViTinh { get; set; }

        public string KetLuan { get; set; }

        public bool isDaDuyetKQ { get; set; }

        public bool isMauXNLai { get; set; }

    }
}