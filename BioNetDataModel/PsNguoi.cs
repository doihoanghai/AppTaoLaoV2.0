using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
    public class PsNguoi
    {
        public long rowIDNguoi { get; set; }
        public string maThongTinNguoi { get; set; }
        public string hoTen { get; set; }
        public Boolean GioiTinh { get; set; }
        public DateTime? ngayGioSinh { get; set; }
        public string noiSinh { get; set; }
        public string idCard { get; set; }
        public int? idQuocTich { get; set; }
        public int? idDanToc { get; set; }
        public string DiaChi { get; set; }
        public string soDienThoai { get; set; }
        public byte? soTuanThaiLucSinh { get; set; }
        public short? CanNangLucSinh { get; set; }
        public Boolean? phuongPhapSinh { get; set; }
    }
}
