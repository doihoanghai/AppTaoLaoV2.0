using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
    public class ObjectChartReport
    {
        public string Name { get; set; }
        public int Values { get; set; }
    }
    public class rptBaoCaoTongHop
    {
     
       public PsThongTinTrungTam TrungTam { get; set; }
        public PsThongTinDonVi Donvi { get; set; }
        public DateTime tuNgay { get; set; }
        public DateTime denNgay { get; set; }
        public int SoLuongMau { get; set; }
        public GoiBenh goiBenh{ get; set; }
        public GioiTinh gioiTinh { get; set; }
        public PhuongPhapSinh phuongPhapSinh { get; set; }
        public ChuongTrinh chuongTrinh { get; set; }
        public ChatLuongMau chatLuongMau { get; set; }
        public G6PD g6PD { get; set; }
        public CH cH { get; set; }
        public CAH cAH { get; set; }
        public PKU pKU { get; set; }
        public GAL gAL { get; set; }
        public TKPhieu tkphieu { get; set; }

        public class GoiBenh
        {
            public int sl2Benh { get; set; }
            public int sl3Benh { get; set; }
            public int sl5Benh { get; set; }
            public int slThuLai { get; set; }
        }
        public class GioiTinh
        {
            public int GTNam { get; set; }
            public int GTNu { get; set; }
            public int GTNa { get; set; }
        }
        public class PhuongPhapSinh
        {
            public int SinhThuong { get; set; }
            public int SinhMo { get; set; }
            public int SinhNa { get; set; }
        }
        public class ChuongTrinh
        {
            public int QuocGia { get; set; }
            public int XaHoiHoa { get; set; }
        }
        public class ChatLuongMau
        {
            public int Dat { get; set; }
            public int KhongDat { get; set; }
        }
        public class G6PD
        {
            public int G6PDTong { get; set; }
            public int G6PDBinhThuong { get; set; }
            public int G6PDNguyCo { get; set; }
            public string G6PDBinhThuong_Tong { get; set; }
            public string G6PDNguyCo_Tong { get; set; }
        }
        public class CH
        {
            public int CHTong { get; set; }
            public int CHNguyCo { get; set; }
            public int CHBinhThuong { get; set; }
            public string CHNguyCo_Tong { get; set; }
            public string CHBinhThuong_Tong { get; set; }
        }
        public class CAH
        {
            public int CAHTong { get; set; }
            public int CAHNguyCo { get; set; }
            public int CAHBinhThuong { get; set; }
            public string CAHNguyCo_Tong { get; set; }
            public string CAHBinhThuong_Tong { get; set; }
        }
        public class PKU
        {
            public int PKUNguyCo { get; set; }
            public int PKUTong { get; set; }
            public int PKUBinhThuong { get; set; }
            public string PUKNguyCo_Tong { get; set; }
            public string PUKBinhThuong_Tong { get; set; }

        }
        public class GAL
        {
            public int GALTong { get; set; }
            public int GALNguyCo { get; set; }
            public int GALBinhThuong { get; set; }
            public string GALNguyCo_Tong { get; set; }
            public string GALBinhThuong_Tong { get; set; }
        }
        public class TKPhieu
        {
            public int Thang { get; set; }
            public int SLphieu { get; set; }
        }
    }
   
}
