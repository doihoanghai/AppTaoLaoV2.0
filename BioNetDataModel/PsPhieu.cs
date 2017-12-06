using System;
using System.Collections.Generic;
using BioNetModel.Data;

namespace BioNetModel
{
    public class PsPhieu
    {
        public long rowIDPhieu { get; set; }
        public string maPhieu { get; set; }
        public string maBenhNhan { get; set; }
        public DateTime ngayTaoPhieu { get; set; }
        public string maNVTaoPhieu { get; set; }
        public string maNVLayMau { get; set; }
        public string tenNVLayMau { get; set; }
        public string maDonViCoSo { get; set; }
        public string diaChi { get; set; }
        public DateTime ngayGioLayMau { get; set; }
        public byte idViTriLayMau { get; set; }
        public bool isLayMauLan2 { get; set; }
        public string maPhieuLan1 { get; set; }
        public byte maTinhTrangLucLayMau { get; set; }
        public short? soLuongTruyenMau { get; set; }
        public DateTime? ngayTruyenMau { get; set; }
        public byte maCheDoDinhDuong { get; set; }
        public bool trangThaiPhieu { get; set; }//đã gửi, chưa gửi
        public byte trangThaiMau { get; set; }//chưa nhận, đã nhận, đang làm xét nghiệm, đã có kết quả
        public bool? isKhongDat { get; set; }
        public DateTime ngayNhanMau { get; set; }
        public string maXetNghiem { get; set; }
        public string paRa { get; set; }
        public bool? isTruoc24h { get; set; }
        public bool? isSinhNon { get; set; }
        public bool? isNheCan { get; set; }
        public bool? isGuiMauTre { get; set; }
        public string maChuongTrinh { get; set; }
        public string maGoiXetNghiem { get; set; }
        public string NoiLayMau { get; set; }
        public string DiaChiLayMau { get; set; }
        public string TenNhanVienLayMau { get; set; }
        public string SoDTNhanVienLayMau { get; set; }
        public string LuuYPhieu { get; set; }
        public PSPatient BenhNhan { get; set; }
        public List<PSChiDinhTrenPhieu> lstChiDinh { get; set; }
        public PSDanhMucDonViCoSo DonVi { get; set; }
        public List<PSChiTietDanhGiaChatLuong> lstLyDoKhongDat { get; set; }
        public List<PsDichVu> lstChiDinhDichVu { get; set; }
        public string lydokhongdat{get;set;}

    }
}
