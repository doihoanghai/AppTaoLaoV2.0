using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
   public class ClassDieuKienLocBaoCao
    {
        public class GioiTinh
        {
            public int idGT { get; set; }
            public string NameGioiTinh { get; set; }
        }
        public class NguyCo
        {   
            public int idNC { get; set; }
            public string TenNguyCo { get; set; }
        }
        public class PPSinh
        {
            public int idPPS { get; set; }
            public string PhuongPhapSinh { get; set; }
        }
        public class ChatLuongMau
        {
            public int idCLM { get; set; }
            public string CLM { get; set; }
        }
        public class ChiTietChatLuongMauKhongDat
        {
            public int idCLMKhongDat { get; set; }
            public string TenCLM { get; set; }
        }
        public class LoaiMau
        {
            public int idLoai { get; set; }
            public string NameLoai { get; set; }
        }
        public class ChanDoan
        {
            public int idChanDoan { get; set; }
            public string ChanDoanBenh { get; set; }
        }
        public class ViTriLayMau
        {
            public int idViTri { get; set; }
            public string TenViTriLayMau { get; set; }
        }
    }
}
