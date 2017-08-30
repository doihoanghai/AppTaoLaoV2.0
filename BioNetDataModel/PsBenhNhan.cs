using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
   public class PsBenhNhan
    {
        public long rowIDBenhNhan { get; set; }
        public string maBenhNhan { get; set; }
        public string maKhachHang { get; set; }
        public string tenCha { get; set; }
        public string tenMe { get; set; }
        public DateTime namSinhCha { get; set; }
        public DateTime namSinhMe { get; set; }
        public string soDienThoaiCha { get; set; }
        public string soDienThoaiMe { get; set; }
        public string maThongTinBenhNhan { get; set; }
        public string diaChi { get; set; }
        public string Para { get; set; }
        public PsNguoi ThongTinNguoi { get; set; }

    }
}
