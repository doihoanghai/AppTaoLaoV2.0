using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetModel.Data;
using BioNetModel;
using BioNetBLL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmNhapLieuDanhGiaMau : DevExpress.XtraEditors.XtraForm
    {
        public FrmNhapLieuDanhGiaMau(string maNhanVien)
        {
            InitializeComponent();
            this.MaNhanVienDangNhap = maNhanVien;
        }
        private List<PSDanhMucDonViCoSo> lstDVCS = new List<PSDanhMucDonViCoSo>(); //danh sách đơn vị cơ sở
        private List<PsDichVu> lstDichVu = new List<PsDichVu>();
        private List<PSTiepNhan> lstTiepNhan = new List<PSTiepNhan>(); //danh sach phieu được nhân viên tiếp nhận
        private List<PsDichVu> lstChiDinhDichVu = new List<PsDichVu>(); // các dịch vụ được chỉ định
   //   private List<PSTiepNhan> lstDaDanhGia = new List<PSTiepNhan>();
        private List<PSChiDinhDichVu> lstDaDanhGia = new List<PSChiDinhDichVu>();
        private List<PsDanhGiaMauSoBo> lstDanhGiaSoBo = new List<PsDanhGiaMauSoBo>();
        private List<PSChiTietDanhGiaChatLuong> lstDanhGiaChatLuong = new List<PSChiTietDanhGiaChatLuong>();
        private List<PSDanhMucGoiDichVuChung> lstgoiXN = new List<PSDanhMucGoiDichVuChung>();
        private string MaNhanVienDangNhap = "MaNVNLDG";
        private DateTime ngayGioSinh;
        private DateTime ngayGioLayMau;
        private DateTime ngayTiepNhan;
        private bool isMauThuLai = false;
        private int GiaTriNheCan = 2500;
        private int GiaTriSinhNon = 35;
       // private List<PsChiDinhvsDanhGia> lstDaDanhGia = new List<PsChiDinhvsDanhGia>();
        private List<PSTiepNhan> lstDSCanDanhGia = new List<PSTiepNhan>();
        private List<PSTiepNhan> lstTiepNhanSearch = new List<PSTiepNhan>();
        private List<PSChiDinhDichVu> lstDaDanhGiaSearch = new List<PSChiDinhDichVu>();
        private List<PSDanhMucDanhGiaChatLuongMau> sourceListDanhGiaChatLuong = new List<PSDanhMucDanhGiaChatLuongMau>();
        private List<PSChiDinhTrenPhieu> listdvcanlamlai = new List<PSChiDinhTrenPhieu>();
        private void FrmNhapLieuDanhGiaMau_Load(object sender, EventArgs e)
        {
            this.LoadFrom(); 
        }
        private void LoadListDanhGiaSoBo()
        {
            this.lstDanhGiaSoBo.Clear();
            PsDanhGiaMauSoBo dg1 = new PsDanhGiaMauSoBo();
            dg1.giaTri = false;
            dg1.maGiaTri = "islaymautruoc24h";
            dg1.noiDungChuThich = "Lấy mẫu trước 24h sau khi sinh";
            PsDanhGiaMauSoBo dg2 = new PsDanhGiaMauSoBo();
            dg2.giaTri = false;
            dg2.maGiaTri = "isSinhNon";
            dg2.noiDungChuThich = "Sinh non";
            PsDanhGiaMauSoBo dg3 = new PsDanhGiaMauSoBo();
            dg3.giaTri = false;
            dg3.maGiaTri = "isNheCan";
            dg3.noiDungChuThich = "Nhẹ cân";
            PsDanhGiaMauSoBo dg4 = new PsDanhGiaMauSoBo();
            dg4.giaTri = false;
            dg4.maGiaTri = "isGuiMauTre";
            dg4.noiDungChuThich = "Gửi mẫu trễ";
            this.lstDanhGiaSoBo.Add(dg1);
            this.lstDanhGiaSoBo.Add(dg2);
            this.lstDanhGiaSoBo.Add(dg3);
            this.lstDanhGiaSoBo.Add(dg4);
        }
        private void LoadGoiDichVuXetNGhiem()
        {
            try
            {
                this.lstgoiXN = BioNet_Bus.GetDanhsachGoiDichVuChung();
                this.lookupGoiXN.DataSource = this.lstgoiXN;
            }
            catch { }
        }
        private void LoadThongTinLuuY()
        {
            this.txtLuuY.ResetText();
            string str = string.Empty;
            foreach(var item in this.lstDanhGiaSoBo)
            {
                if(item.giaTri)
                {
                    str +="- "+item.noiDungChuThich + "\r\n";
                }
            }
            this.txtLuuY.Text = str;
        }
        private void LoadFrom()
        {
            this.lstDichVu.Clear();
            this.lstTiepNhan.Clear();
            //this.LoadDanhSachChuongTrinhSangLoc();
            //this.LoadRepositoryLookupDonViCoSo();
            //this.LoadSearchLookUpDoViCoSo();
            this.LoadsearchLookUpChiCuc();
            //this.LoadGoiDichVuXetNGhiem();
            //this.LoadDanhSachDichVu();
            //this.LoadLookupDanToc();
            //this.LoadLookupDonViCoSo();
            //this.LoadListDanhGiaSoBo();
            //this.searchLookUpDonViCoSo.EditValue = "ALL";
            this.txtTuNgay_DsCho.EditValue = DateTime.Now;
            this.txtDenNgay_DsCho.EditValue = DateTime.Now;
            //this.sourceListDanhGiaChatLuong = BioNet_Bus.GetDanhMucDanhGiaChatLuong();
            //  this.LoadGoiXetNghiem();
        }
       
        private void LoadDanhSachChuongTrinhSangLoc()
        {
            try
            {
                var chtr = BioNet_Bus.GetDanhSachChuongTrinh(false);

                this.lookupChuongTrinh.Properties.DataSource = chtr;
                if (chtr.Count > 1)
                    this.lookupChuongTrinh.ItemIndex = 1;
                else if(chtr.Count>0) this.lookupChuongTrinh.ItemIndex = 0;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lấy danh sách chương trình \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void LoadsearchLookUpChiCuc()
        {
            try
            {
                this.searchLookUpChiCuc.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChiCuc();
                this.searchLookUpChiCuc.EditValue = "all";               
                this.searchLookUpDonViCoSo.EditValue = "all";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi load danh sách chi cục \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.searchLookUpChiCuc.Focus();
            }
        }
        private void LoadLookupDanToc()
        {
            this.lookUpDanToc.Properties.DataSource = BioNet_Bus.GetDanhSachDanToc(-1);
        }
        private void LoadLookupQuocGia()
        {
        }
        private void LoadLookupDonViCoSo()
        {
            try
            {
                var lstdv = BioNet_Bus.GetDanhSachDonViCoSo();
                this.lookupDonVi.Properties.DataSource = lstdv;
                this.repositoryItemLookUpDonVi.DataSource = lstdv;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lấy danh sách đơn vị cơ sở \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void LoadDanhSachTiepNhan()
        {
            this.GCDanhSachTiepNhan.DataSource = null;
            this.GCDanhSachTiepNhan.DataSource = this.lstTiepNhan.Select(p => new {p.MaDonVi,p.isDaNhapLieu,p.MaPhieu,p.MaTiepNhan,p.NgayTiepNhan,p.RowIDTiepNhan,p.RowIDPhieu,p.isDaDanhGia }).ToList() ;
            this.GVDanhSachTiepNhan.Columns["MaDonVi"].Group();
            this.GVDanhSachTiepNhan.ExpandAllGroups();
            
        }
        private void LoadDanhSachDaDanhGia()
        {
            this.GCDanhSachDaTracking.DataSource = null;
            this.GCDanhSachDaTracking.DataSource = this.lstDaDanhGia;
            this.GVDanhSachDaTracking.Columns["MaDonVi"].Group();
           this.GVDanhSachDaTracking.ExpandAllGroups();
        }
        private void LoadDanhSachDaDanhGiaTheoDonVi(string maDonVi)
        {
            this.lstDaDanhGia.Clear();
            this.lstDaDanhGia = BioNet_Bus.GetDanhSachDaDuocChiDinh(maDonVi,(DateTime) txtTuNgay_DsCho.EditValue, (DateTime)txtDenNgay_DsCho.EditValue);
            this.LoadDanhSachDaDanhGia();
        }
        private void LoadDanhSachTiepNhanTheoDonVi(string maDonVi)
        {
            this.lstTiepNhan.Clear();
            this.lstTiepNhan = BioNet_Bus.GetDanhSachPhieuChuaDanhGia(maDonVi, (DateTime)txtTuNgay_DsCho.EditValue, (DateTime)txtDenNgay_DsCho.EditValue);
            this.LoadDanhSachTiepNhan();
        }
        private void LoadNew()
        {
            this.txtMaPhieuLan1.ResetText();
            this.txtNoiSinh.ResetText();
            this.txtMaChiDinh.ResetText();
            this.txtMaTiepNhan.ResetText();
            this.txtDiaChiBN.ResetText();
            this.isMauThuLai = false;
            this.txtMaTiepNhan.ResetText();
            this.txtMaThongTinTre.ResetText();
            this.txtMaBenhNhan.ResetText();
            this.txtCanNang.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtGioSinhBenhNhan.ResetText();
            this.txtNamSinhBenhNhan.ResetText();
            this.txtNamSinhCha.ResetText();
            this.txtNamSinhMe.ResetText();
            this.txtNgayTruyenMau.ResetText();
           // this.txtNoiSinh.ResetText();
            this.txtSDTCha.ResetText();
            this.txtSDTMe.ResetText();
            this.txtSoLuongTruyenMau.ResetText();
            this.txtTenBenhNhan.ResetText();
            this.txtTenCha.ResetText();
            this.txtTenMe.ResetText();
            this.RadioCheDoDD.EditValue = "0";
            this.radioGroupGoiXN.EditValue=null;
            this.radioGroupTinhTrangTre.EditValue = "0";
            this.radioGroupViTriLayMau.EditValue = "0";
            this.txtCanNang.ResetText();
            this.txtGioiTinh.ResetText();
            this.lookUpDanToc.ResetText();
            this.lookupChuongTrinh.ResetText();
            this.txtGioSinhBenhNhan.ResetText();
            this.txtGioLayMau.ResetText();
           this.txtDiaChiDonVi.ResetText();
          //  this.txtNguoiLayMau.ResetText();
            this.txtNoiLayMau.ResetText();
         //   this.txtSDTNguoiLayMau.ResetText();
          //  this.txtNgayLayMau.ResetText();
            this.txtGioSinhBenhNhan.ResetText();
           // this.txtGioLayMau.ResetText();
          //  this.cboPhuongPhapSinh.ResetText();
            this.checkedListBoxXN.Enabled = false;
            this.LoadListDanhGiaSoBo();
            this.txtLuuY.ResetText();
            this.lstChiDinhDichVu.Clear();
            this.lstDanhGiaChatLuong.Clear();
            this.radioDanhGia.SelectedIndex = 0;
        }
        private void ReadOnly(bool isreadonly)
        {
            this.txtNgayLayMau.ReadOnly = isreadonly;
            this.txtTuanTuoi.ReadOnly = isreadonly;
            this.txtPARA.ReadOnly = isreadonly;
            this.txtNgayLayMau.ReadOnly = isreadonly;
          
            this.txtMaPhieuLan1.ReadOnly = isreadonly;
            this.txtNoiSinh.ReadOnly = isreadonly;
            this.txtDiaChiBN.ReadOnly = isreadonly;
           // this.isMauThuLai.ReadOnly = isreadonly;
            this.txtMaTiepNhan.ReadOnly = isreadonly;
            this.txtMaThongTinTre.ReadOnly = isreadonly;
            this.txtMaBenhNhan.ReadOnly = isreadonly;
            this.txtCanNang.ReadOnly = isreadonly;
            this.txtGioiTinh.ReadOnly = isreadonly;
            this.txtGioSinhBenhNhan.ReadOnly = isreadonly;
            this.txtNamSinhBenhNhan.ReadOnly = isreadonly;
            this.txtNamSinhCha.ReadOnly = isreadonly;
            this.txtNamSinhMe.ReadOnly = isreadonly;
        //    this.txtNgayTruyenMau.ReadOnly = isreadonly;
            // this.txtNoiSinh.ResetText();
            this.txtSDTCha.ReadOnly = isreadonly;
            this.txtSDTMe.ReadOnly = isreadonly;
           // this.txtSoLuongTruyenMau.ReadOnly = isreadonly;
            this.txtTenBenhNhan.ReadOnly = isreadonly;
            this.txtTenCha.ReadOnly = isreadonly;
            this.txtTenMe.ReadOnly = isreadonly;
            this.RadioCheDoDD.ReadOnly = isreadonly;
            this.radioGroupGoiXN.ReadOnly = isreadonly;
            this.radioGroupTinhTrangTre.ReadOnly = isreadonly;
            this.radioGroupViTriLayMau.ReadOnly = isreadonly;
            this.checkedListBoxLydoKhongDat.Enabled = !isreadonly;
            this.txtGioiTinh.ReadOnly = isreadonly;
            this.lookUpDanToc.ReadOnly = isreadonly;
            this.lookupChuongTrinh.ReadOnly = isreadonly;
            this.txtGioSinhBenhNhan.ReadOnly = isreadonly;
            this.txtGioLayMau.ReadOnly = isreadonly;
            this.txtDiaChiDonVi.ReadOnly = isreadonly;
            //  this.txtNguoiLayMau.ResetText();
            this.txtNoiLayMau.ReadOnly = isreadonly;
            this.txtSDTNguoiLayMau.ReadOnly = isreadonly;
            this.txtNguoiLayMau.ReadOnly = isreadonly;
            //  this.txtNgayLayMau.ResetText();
            this.txtGioSinhBenhNhan.ReadOnly = isreadonly;
            // this.txtGioLayMau.ResetText();
            this.cboPhuongPhapSinh.ReadOnly = isreadonly;
           // this.checkedListBoxXN.Enabled = ;
            this.txtLuuY.ReadOnly = isreadonly;
            this.radioDanhGia.ReadOnly = isreadonly;
            if (this.radioGroupGoiXN.SelectedIndex >= 0)
            {
                if (this.radioGroupGoiXN.EditValue.Equals("DVGXN0001") && this.radioGroupGoiXN.ReadOnly == false)
                {
                    this.txtMaPhieuLan1.ReadOnly = false;
                }
            }
        }

        private void LoadRepositoryLookupDonViCoSo()
        {
            try
            {
                this.repositoryLookUpDonViGCTiepNhan.DataSource = BioNet_Bus.GetDanhSachDonViCoSo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lấy danh sách đơn vị cơ sở \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void HienThiThongTinPhieuCu(PsPhieu phieu)
        {
            try
            {
                if (phieu.BenhNhan != null)
                {
                    this.txtMaBenhNhan.Text = phieu.BenhNhan.MaBenhNhan;
                    if (string.IsNullOrEmpty(this.txtTenMe.Text))
                    this.txtTenMe.Text = phieu.BenhNhan.MotherName;
                    if (string.IsNullOrEmpty(this.txtTenCha.Text))
                        this.txtTenCha.Text = phieu.BenhNhan.FatherName;
                    if (string.IsNullOrEmpty(this.txtSDTMe.Text))
                        this.txtSDTMe.Text = phieu.BenhNhan.MotherPhoneNumber;
                    if (string.IsNullOrEmpty(this.txtSDTCha.Text))
                        this.txtSDTCha.Text = phieu.BenhNhan.FatherPhoneNumber;
                    if (string.IsNullOrEmpty(this.txtNamSinhMe.Text))
                        this.txtNamSinhMe.EditValue = phieu.BenhNhan.MotherBirthday;
                    if (string.IsNullOrEmpty(this.txtNamSinhCha.Text))
                        this.txtNamSinhCha.EditValue = phieu.BenhNhan.FatherBirthday;
                    if (string.IsNullOrEmpty(this.txtMaBenhNhan.Text))
                        this.txtMaBenhNhan.Text = phieu.maBenhNhan;
                    if (string.IsNullOrEmpty(this.txtDiaChiBN.Text.Trim()))
                        this.txtDiaChiBN.Text = phieu.BenhNhan.DiaChi;
                    if (string.IsNullOrEmpty(this.txtTenBenhNhan.Text))
                        this.txtTenBenhNhan.Text = phieu.BenhNhan.TenBenhNhan;
                    try
                    {
                        if (int.Parse(this.txtCanNang.EditValue.ToString()) <=0)
                            this.txtCanNang.EditValue = phieu.BenhNhan.CanNang??0;
                    }
                    catch
                    {
                        this.txtCanNang.EditValue = phieu.BenhNhan.CanNang.ToString();
                    }
           
                    if (string.IsNullOrEmpty(this.txtGioiTinh.Text))
                        this.txtGioiTinh.SelectedIndex = phieu.BenhNhan.GioiTinh??2;
                    if (string.IsNullOrEmpty(this.cboPhuongPhapSinh.Text))
                        this.cboPhuongPhapSinh.SelectedIndex = phieu.BenhNhan.PhuongPhapSinh??2;
                    if (string.IsNullOrEmpty(this.lookUpDanToc.Text))
                        this.lookUpDanToc.EditValue = phieu.BenhNhan.DanTocID;
                    if (string.IsNullOrEmpty(this.txtNoiSinh.Text))
                        this.txtNoiSinh.Text = phieu.BenhNhan.NoiSinh;
                    if (string.IsNullOrEmpty(this.txtGioSinhBenhNhan.Text))
                        this.txtGioSinhBenhNhan.EditValue = Convert.ToDateTime(phieu.BenhNhan.NgayGioSinh.Value.ToString("hh: mm:ss"));
                    if (string.IsNullOrEmpty(this.txtNamSinhBenhNhan.Text))
                        this.txtNamSinhBenhNhan.EditValue = phieu.BenhNhan.NgayGioSinh.Value.Date;
                        this.ngayGioSinh = phieu.BenhNhan.NgayGioSinh ?? DateTime.Now;
                    if (string.IsNullOrEmpty(this.txtTuanTuoi.Text))
                    try
                    {
                        this.txtTuanTuoi.EditValue = phieu.BenhNhan.TuanTuoiKhiSinh ?? 0;
                    }
                    catch
                    {
                        this.txtTuanTuoi.Text = phieu.BenhNhan.TuanTuoiKhiSinh.ToString();
                    }
                    this.checkedListBoxXN.Enabled = true;
                }
            }
            catch { }
            
            //this.txtMaPhieuLan1.Text = phieu.maPhieu;
            //this.barCodePhieu.Text = phieu.maPhieu;
            this.txtNgayTruyenMau.EditValue = phieu.ngayTruyenMau;
            this.txtSoLuongTruyenMau.Text = phieu.soLuongTruyenMau.ToString();
            this.RadioCheDoDD.EditValue = phieu.maCheDoDinhDuong.ToString();
            this.radioGroupViTriLayMau.EditValue = phieu.idViTriLayMau.ToString();
            this.lookupChuongTrinh.EditValue = phieu.maChuongTrinh;
            this.lookupDonVi.EditValue = phieu.maDonViCoSo;
            //this.txtGioLayMau.EditValue = Convert.ToDateTime(phieu.ngayGioLayMau.ToString("hh: mm:ss"));
            //this.txtNgayLayMau.EditValue = phieu.ngayGioLayMau.Date;
            if (string.IsNullOrEmpty(this.txtNguoiLayMau.Text))
                this.txtNguoiLayMau.Text = phieu.tenNVLayMau;
            this.txtNoiLayMau.Text = phieu.NoiLayMau;
            this.txtDiaChiDonVi.Text = phieu.DiaChiLayMau;
            //  this.txtNgayNhanMau.EditValue = phieu.ngayNhanMau;
            if (string.IsNullOrEmpty(this.txtSDTNguoiLayMau.Text))
                this.txtSDTNguoiLayMau.Text = phieu.SoDTNhanVienLayMau;
            // this.ngayGioLayMau = phieu.ngayGioLayMau;
            if (this.radioGroupGoiXN.EditValue.Equals("DVGXN0001"))
            {
                foreach (var dv in this.listdvcanlamlai)
                {
                    foreach (CheckedListBoxItem item in this.checkedListBoxXN.Items)
                    {
                        try
                        {
                            PsDichVu dichvu = item.Value as PsDichVu;
                            if (dichvu.IDDichVu == dv.MaDichVu)
                            {
                                item.CheckState = CheckState.Checked;
                            }
                        }
                        catch(Exception ex) { }
                    }
                }
                //this.checkedListBoxXN.DataSource = null;
                //this.checkedListBoxXN.DataSource = this.lstDichVu;
            }
            else
            {
                this.checkedListBoxXN.DataSource = null;
            }
        }
        private void LayDanhSachDanhGiaHangLoat()
        {
            this.lstDSCanDanhGia.Clear();
            int[] lstChecked = this.GVDanhSachTiepNhan.GetSelectedRows();
            foreach (var index in lstChecked)
            {
                if (index >= 0)
                {
                    try
                    {
                        long rowIDTiepNhan = long.Parse(this.GVDanhSachTiepNhan.GetRowCellValue(index, this.col_RowIDTiepNhan).ToString());
                        var Tn = BioNet_Bus.GetThongTinTiepNhan(rowIDTiepNhan);

                        if (Tn != null)
                            this.lstDSCanDanhGia.Add(Tn);
                    }
                    catch(Exception ex) {
                        XtraMessageBox.Show("Lỗi khi lấy thông tin tiếp nhận của phiếu \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void DienThongTinMacDinhCuaDonViLenPhieu(string maDonVi)
        {
            var dv = this.lstDVCS.FirstOrDefault(p => p.MaDVCS == maDonVi);
            if(dv!=null)
            {
                if (string.IsNullOrEmpty(this.txtDiaChiDonVi.Text.Trim())){
                    this.txtDiaChiDonVi.Text = dv.DiaChiDVCS;
                }
                if (string.IsNullOrEmpty(this.txtNoiLayMau.Text.Trim())){
                    this.txtNoiLayMau.Text = dv.TenDVCS;
                }
                if (string.IsNullOrEmpty(this.txtNoiSinh.Text.Trim()))
                {
                    this.txtNoiSinh.Text = dv.TenDVCS;
                }
               
            }
        }
        private bool KiemTraCacTruongDuLieuTruocKhiLuu()
        {
            if(string.IsNullOrEmpty(this.txtNgayLayMau.Text))
            {
                XtraMessageBox.Show("Vui lòng điền ngày lấy mẫu", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                try
                {
                    if(((DateTime) this.txtNgayLayMau.EditValue).Date > ((DateTime)txtNgayNhanMau.EditValue).Date)
                    {
                        XtraMessageBox.Show("Ngày lấy mẫu không được lớn hơn ngày nhận mẫu!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng nhập đúng định dạng ngày tháng năm của trường Ngày lấy mẫu!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(this.txtTenBenhNhan.Text.Trim()))
            {
                if (this.txtGioiTinh.SelectedIndex < 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn giới tính", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (string.IsNullOrEmpty(this.txtNamSinhBenhNhan.Text.Trim()))
                {
                    this.txtNamSinhBenhNhan.EditValue = this.txtNgayLayMau.EditValue;
                }
                if(string.IsNullOrEmpty(this.txtTenMe.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng không để trống tên Mẹ", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                try
                {
                    
                   if(int.Parse(this.txtCanNang.Text.ToString())<500)
                    {
                        XtraMessageBox.Show("cân nặng phải lớn hơn 500gram!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng điền đúng định dạng trường Cân nặng ( Tính bằng gram và lớn hơn 500gram)!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                try
                {
                    if(int.Parse(this.txtTuanTuoi.Text.ToString())<21)
                    {
                        XtraMessageBox.Show("Số tuần tuổi của trẻ lúc sinh phải lớn hơn 21 tuần!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng điền đúng định dạng trường Tuần tuổi! \r\n Số tuần tuổi của trẻ lúc sinh phải lớn hơn 21 tuần!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if(!this.txtSoLuongTruyenMau.ReadOnly && int.Parse(this.radioGroupTinhTrangTre.EditValue.ToString() ?? "0") > 3)
                {
                    try {
                        int sl = int.Parse(this.txtSoLuongTruyenMau.Text );
                        if(sl>1000 ||sl<10)
                        {
                            XtraMessageBox.Show("Vui lòng điền đúng định dạng trường số lượng truyền máu! \r\n Số lượng truyền phải nhỏ hơn 1000ml và lớn 10 ml", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                   }
                    catch
                    {
                        XtraMessageBox.Show("Vui lòng điền đúng định dạng trường số lượng truyền máu!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if(string.IsNullOrEmpty(this.txtNgayTruyenMau.Text))
                        {
                        XtraMessageBox.Show("Vui lòng không để trống trường Ngày truyền máu", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        try {
                            DateTime ngay = (DateTime)this.txtNgayTruyenMau.EditValue;
                            if(ngay.Date<this.txtNamSinhBenhNhan.DateTime.Date&&int.Parse(this.radioGroupTinhTrangTre.EditValue.ToString()??"0")>3)
                            {
                                XtraMessageBox.Show("Ngày truyền máu không được nhỏ hơn ngày sinh của trẻ", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        catch
                        {
                            XtraMessageBox.Show("Vui lòng kiểm tra lại ngày truyền máu và ngày sinh của trẻ", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            if(!string.IsNullOrEmpty(this.txtTenMe.Text.Trim()))
            {if (string.IsNullOrEmpty(this.txtNamSinhMe.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng điền năm sinh của mẹ", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    try
                    {
                        if (((DateTime)this.txtNamSinhMe.EditValue).Year < 1800 || ((DateTime)this.txtNamSinhMe.EditValue).Year > 2999)
                        {
                            XtraMessageBox.Show("Vui lòng điền đúng định dạng trường Năm sinh của mẹ", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    catch
                    {
                        XtraMessageBox.Show("Vui lòng điền đúng định dạng trường Năm sinh của mẹ", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if(string.IsNullOrEmpty(this.txtTenBenhNhan.Text.Trim()))
                    this.ValidateTxtTenBenhNhan();
                if (string.IsNullOrEmpty(this.txtDiaChiBN.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng không để trống địa chỉ liên hệ!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtDiaChiBN.Focus();
                    return false;
                } 
            }
            return true;
        }
        private void  HienThiThongTinChiDinh(string maPhieu, string maDonVi, string maTiepNhan,string maChiDinh, bool isSua)
        {
            this.listdvcanlamlai.Clear();
            PsPhieu phieu = BioNet_Bus.GetThongTinPhieu(maPhieu,maDonVi);
            PSChiDinhDichVu chdinh = BioNet_Bus.GetThongTinhChiDinh(maChiDinh);
            this.barCodePhieu.Text = maPhieu;
            this.LoadNew();
            if (chdinh != null)
            {
                this.txtMaChiDinh.Text = chdinh.MaChiDinh;
                this.radioGroupGoiXN.EditValue = chdinh.IDGoiDichVu;
                this.listdvcanlamlai = BioNet_Bus.GetChiDinhDichVuChiTiet(chdinh.MaChiDinh);
                this.btnHuy.Visible = true;
                this.btnHuy.Enabled = true;
            }
            this.txtMaPhieu.Text = maPhieu;
            this.txtMaTiepNhan.Text = maTiepNhan;
            this.lookupDonVi.EditValue = maDonVi;
            this.LoadGoiXetNghiem(maDonVi);
            this.LoadGCChiDinhDichVu();
           
            if (phieu != null)
            {
                try
                {

                    this.txtMaPhieu.Text = phieu.maPhieu;
                    this.barCodePhieu.Text = phieu.maPhieu;
                    this.txtNgayTruyenMau.EditValue = phieu.ngayTruyenMau;
                    this.txtSoLuongTruyenMau.Text = phieu.soLuongTruyenMau.ToString();
                    this.RadioCheDoDD.EditValue = phieu.maCheDoDinhDuong.ToString();
                    this.radioGroupTinhTrangTre.EditValue = phieu.maTinhTrangLucLayMau.ToString();
                    this.radioGroupViTriLayMau.EditValue = phieu.idViTriLayMau.ToString();
                    this.lookupChuongTrinh.EditValue = phieu.maChuongTrinh;
                    //this.radioGroupGoiXN.EditValue = phieu.maGoiXetNghiem;
                    this.txtGioLayMau.EditValue = Convert.ToDateTime(phieu.ngayGioLayMau.ToString("hh: mm:ss"));
                    this.txtNgayLayMau.EditValue = phieu.ngayGioLayMau.Date;
                    this.txtNgayGioNhanMau.EditValue = phieu.ngayGioLayMau;
                    this.txtNguoiLayMau.Text = phieu.tenNVLayMau;
                    this.txtDiaChiDonVi.Text = phieu.DonVi.DiaChiDVCS;
                    this.txtNoiLayMau.Text = phieu.NoiLayMau;
                    this.txtDiaChiDonVi.Text = phieu.DiaChiLayMau;
                   
                    this.radioDanhGia.SelectedIndex = (phieu.isKhongDat ?? false) == false ? 0 : 1;
                    if (!string.IsNullOrEmpty(phieu.maPhieuLan1))
                        this.txtMaPhieuLan1.Text = phieu.maPhieuLan1;
                    // this.radioDanhGia.SelectedIndex = phieu.isKhongDat == true ? 0 : 1;
                    // this.txtNgayNhanMau.EditValue = phieu.ngayNhanMau;
                    this.txtSDTNguoiLayMau.Text = phieu.SoDTNhanVienLayMau;
                    this.ngayGioLayMau = phieu.ngayGioLayMau;
                    this.txtMaTiepNhan.Text = maTiepNhan;
                    // this.lookupDonVi.EditValue = maDonVi;
                    try
                    {
                    //    this.ValidateGuiMauTre(phieu.ngayGioLayMau, (DateTime)this.txtNgayGioNhanMau.EditValue);
                    //    this.ValidateThuMauSom(phieu.BenhNhan.NgayGioSinh ?? DateTime.Now, (DateTime)txtNgayGioNhanMau.EditValue);
                    }
                    catch { }
                    //this.ValidateSinhNon();
                    //this.ValidateNheCan();
                    this.LoadDanhSachDichVu();

                    foreach (var dv in this.listdvcanlamlai)
                    {
                        foreach (CheckedListBoxItem item in this.checkedListBoxXN.Items)
                        {
                            try
                            {
                                PsDichVu dichvu = item.Value as PsDichVu;
                                if (dichvu.IDDichVu == dv.MaDichVu)
                                {
                                    item.CheckState = CheckState.Checked;
                                }
                            }
                            catch (Exception ex) { }
                        }
                    }

                    try
                    {
                        if (phieu.BenhNhan != null)
                        {
                            this.txtTenMe.Text = phieu.BenhNhan.MotherName;
                            this.txtTenCha.Text = phieu.BenhNhan.FatherName;
                            this.txtSDTMe.Text = phieu.BenhNhan.MotherPhoneNumber;
                            this.txtSDTCha.Text = phieu.BenhNhan.FatherPhoneNumber;
                            this.txtNamSinhMe.EditValue = phieu.BenhNhan.MotherBirthday;
                            this.txtNamSinhCha.EditValue = phieu.BenhNhan.FatherBirthday;
                            this.txtMaBenhNhan.Text = phieu.maBenhNhan;
                            this.txtDiaChiBN.Text = phieu.BenhNhan.DiaChi;
                            this.txtPARA.Text = phieu.BenhNhan.Para;
                            this.txtTenBenhNhan.Text = phieu.BenhNhan.TenBenhNhan;
                            try {
                                this.txtCanNang.EditValue = phieu.BenhNhan.CanNang ?? 0;
                            } catch
                            {
                                this.txtCanNang.Text = phieu.BenhNhan.CanNang.ToString();
                            }
                            
                            this.txtGioiTinh.SelectedIndex = phieu.BenhNhan.GioiTinh ?? 2;
                            this.cboPhuongPhapSinh.SelectedIndex = phieu.BenhNhan.PhuongPhapSinh ?? 2;
                            this.lookUpDanToc.EditValue = phieu.BenhNhan.DanTocID;
                            this.txtNoiSinh.Text = phieu.BenhNhan.NoiSinh;
                            this.txtGioSinhBenhNhan.EditValue = Convert.ToDateTime(phieu.BenhNhan.NgayGioSinh.Value.ToString("hh: mm:ss"));
                            this.txtNamSinhBenhNhan.EditValue = phieu.BenhNhan.NgayGioSinh.Value.Date;
                            this.ngayGioSinh = phieu.BenhNhan.NgayGioSinh ?? DateTime.Now;
                            try
                            {
                                this.txtTuanTuoi.EditValue = phieu.BenhNhan.TuanTuoiKhiSinh ?? 0;
                            }
                            catch
                            {
                                this.txtTuanTuoi.Text = phieu.BenhNhan.TuanTuoiKhiSinh.ToString();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                  //  this.ValidateThuMauSom(this.ngayGioSinh, this.ngayGioLayMau);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            if (isSua)
            {
                this.btnDuyet.Enabled = true;
                this.btnSua.Enabled = false;
            }
            else
            {
                this.btnDuyet.Enabled = false;
                this.btnSua.Enabled = true;
            }


            this.ReadOnly(!isSua);
            DienThongTinMacDinhCuaDonViLenPhieu(this.lookupDonVi.EditValue.ToString());
        }
        private void HienThiThongTinPhieu(string maPhieu, string maDonVi, string maTiepNhan, bool isSua)
        {
            PsPhieu phieu = BioNet_Bus.GetThongTinPhieu(maPhieu,maDonVi);
            this.barCodePhieu.Text = maPhieu;
            this.LoadNew();
            this.txtMaPhieu.Text = maPhieu;
            this.txtMaTiepNhan.Text = maTiepNhan;
            this.lookupDonVi.EditValue = maDonVi;
            this.btnHuy.Visible = true;
            this.btnHuy.Enabled = false;
            this.LoadGoiXetNghiem(maDonVi);
            this.LoadGCChiDinhDichVu();
            this.txtMaChiDinh.ResetText();
            if (phieu != null)
            {
                try
                {
                 
                    this.txtMaPhieu.Text = phieu.maPhieu;
                    this.barCodePhieu.Text = phieu.maPhieu;
                    this.txtNgayTruyenMau.EditValue = phieu.ngayTruyenMau;
                    this.txtSoLuongTruyenMau.Text = phieu.soLuongTruyenMau.ToString();
                    this.RadioCheDoDD.EditValue = phieu.maCheDoDinhDuong.ToString();
                    this.radioGroupTinhTrangTre.EditValue = phieu.maTinhTrangLucLayMau.ToString();
                    this.radioGroupViTriLayMau.EditValue = phieu.idViTriLayMau.ToString();
                    this.lookupChuongTrinh.EditValue = phieu.maChuongTrinh;
                    this.radioGroupGoiXN.EditValue = phieu.maGoiXetNghiem;
                    this.txtGioLayMau.EditValue = Convert.ToDateTime(phieu.ngayGioLayMau.ToString("hh: mm:ss"));
                    this.txtNgayLayMau.EditValue = phieu.ngayGioLayMau.Date;
                    this.txtNgayGioNhanMau.EditValue = phieu.ngayGioLayMau;
                    this.txtNguoiLayMau.Text = phieu.tenNVLayMau;
                    this.txtDiaChiDonVi.Text = phieu.DonVi.DiaChiDVCS;
                    this.txtNoiLayMau.Text = phieu.NoiLayMau;
                    this.txtDiaChiDonVi.Text = phieu.DiaChiLayMau;
                    this.radioDanhGia.SelectedIndex = (phieu.isKhongDat??false)==false?0:1 ;
                    if (!string.IsNullOrEmpty(phieu.maPhieuLan1))
                    this.txtMaPhieuLan1.Text = phieu.maPhieuLan1;
                   // this.radioDanhGia.SelectedIndex = phieu.isKhongDat == true ? 0 : 1;
                   // this.txtNgayNhanMau.EditValue = phieu.ngayNhanMau;
                    this.txtSDTNguoiLayMau.Text = phieu.SoDTNhanVienLayMau;
                    this.ngayGioLayMau = phieu.ngayGioLayMau;
                    this.txtMaTiepNhan.Text = maTiepNhan;
                    // this.lookupDonVi.EditValue = maDonVi;
                    try {
                        //this.ValidateGuiMauTre(phieu.ngayGioLayMau, (DateTime)this.txtNgayGioNhanMau.EditValue);
                      //  this.ValidateThuMauSom(phieu.BenhNhan.NgayGioSinh ?? DateTime.Now, (DateTime)txtNgayGioNhanMau.EditValue);
                    }
                    catch { }
                  //  this.ValidateSinhNon();
                  //  this.ValidateNheCan();
                    this.LoadDanhSachDichVu();

                    //if (phieu.maGoiXetNghiem.Equals("DVGXN0001"))
                    //{
                    //    foreach (var item in this.lstDichVu)
                    //    {
                    //        foreach (var dv in phieu.lstChiDinh)
                    //        {

                    //            if (item.IDDichVu == dv.MaDichVu)
                    //            {
                    //                item.isChecked = true;
                    //            }
                    //        }
                    //    }
                    //    this.checkedListBoxXN.DataSource = null;
                    //    this.checkedListBoxXN.DataSource = this.lstDichVu;
                    //}
                    //else
                    //{
                    //     this.checkedListBoxXN.DataSource = null;
                    //}

                    try
                    {
                        if (phieu.BenhNhan != null)
                        {
                            this.txtTenMe.Text = phieu.BenhNhan.MotherName;
                            this.txtTenCha.Text = phieu.BenhNhan.FatherName;
                            this.txtSDTMe.Text = phieu.BenhNhan.MotherPhoneNumber;
                            this.txtSDTCha.Text = phieu.BenhNhan.FatherPhoneNumber;
                            this.txtNamSinhMe.EditValue = phieu.BenhNhan.MotherBirthday;
                            this.txtNamSinhCha.EditValue = phieu.BenhNhan.FatherBirthday;
                            this.txtMaBenhNhan.Text = phieu.maBenhNhan;
                            this.txtDiaChiBN.Text = phieu.BenhNhan.DiaChi;

                            this.txtTenBenhNhan.Text = phieu.BenhNhan.TenBenhNhan;
                          
                            this.txtGioiTinh.SelectedIndex = phieu.BenhNhan.GioiTinh ?? 2;
                            this.cboPhuongPhapSinh.SelectedIndex = phieu.BenhNhan.PhuongPhapSinh ?? 2;
                            this.lookUpDanToc.EditValue = phieu.BenhNhan.DanTocID;
                            this.txtNoiSinh.Text = phieu.BenhNhan.NoiSinh;
                            this.txtGioSinhBenhNhan.EditValue = Convert.ToDateTime(phieu.BenhNhan.NgayGioSinh.Value.ToString("hh: mm:ss"));
                            this.txtNamSinhBenhNhan.EditValue = phieu.BenhNhan.NgayGioSinh.Value.Date;
                            this.ngayGioSinh = phieu.BenhNhan.NgayGioSinh ?? DateTime.Now;
                            try
                            {
                                this.txtCanNang.EditValue = phieu.BenhNhan.CanNang ?? 0;
                            }
                            catch
                            {
                                this.txtCanNang.Text = phieu.BenhNhan.CanNang.ToString();
                            }
                            try
                            {
                                this.txtTuanTuoi.EditValue = phieu.BenhNhan.TuanTuoiKhiSinh ?? 0;
                            }
                            catch
                            {
                                this.txtTuanTuoi.Text = phieu.BenhNhan.TuanTuoiKhiSinh.ToString();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                 //   this.ValidateThuMauSom (this.ngayGioSinh,this.ngayGioLayMau);
                }
                catch(Exception ex) {
                    XtraMessageBox.Show("Lỗi : "+ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            if (isSua)
            {
                this.btnDuyet.Enabled = true;
                this.btnSua.Enabled = false;
            }
            else
            {
                this.btnDuyet.Enabled = false;
                this.btnSua.Enabled = true;
            }


            this.ReadOnly(!isSua);
            DienThongTinMacDinhCuaDonViLenPhieu(this.lookupDonVi.EditValue.ToString());
        }
        private void ValidateTxtTenBenhNhan()
        {if(string.IsNullOrEmpty(this.txtTenBenhNhan.Text.Trim()))
            {
                if (string.IsNullOrEmpty(this.txtTenMe.Text.Trim()))
                {
                    XtraMessageBox.Show("Không được để trống trường tên của mẹ.", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTenMe.Focus();
                }
                else
                {
                    this.txtTenBenhNhan.Text = "CB_" + this.txtTenMe.Text.Trim();
                }
            }
            
        }
        private void ResetDuLieuTrenFrom( bool isSaved) // save = true  new = false
        {
            this.txtCanNang.ResetText();
            this.txtCanNang.ReadOnly = isSaved;
            this.txtDiaChiBN.ResetText();
            this.txtDiaChiBN.ReadOnly = isSaved;
            this.txtDiaChiDonVi.ResetText();
            this.txtDiaChiDonVi.ReadOnly = isSaved;
            this.txtGioiTinh.ResetText();
            this.txtGioiTinh.ReadOnly = isSaved;
            this.txtGioLayMau.ResetText();
            this.txtGioLayMau.ReadOnly = isSaved;
            this.txtGioSinhBenhNhan.ResetText();
            this.txtGioSinhBenhNhan.ReadOnly = isSaved;
            this.txtLuuY.ResetText();
            this.txtLuuY.ReadOnly = isSaved;
            this.txtMaBenhNhan.ResetText();
            this.txtMaBenhNhan.ReadOnly = isSaved;
            this.txtMaChiDinh.ResetText();
            this.txtMaPhieu.ResetText();
            this.txtMaPhieuLan1.ResetText();
            this.txtMaThongTinTre.ResetText();
            this.txtMaTiepNhan.ResetText();
           
        }
        private void LuuThongTinPhieu(bool isDuyet)
        {
            try
            {
                
                PsPhieu phieu = new PsPhieu();
              
                string lydokhongdat = string.Empty;
                PSPatient benhNhan = new PSPatient();
                benhNhan.GioiTinh = this.txtGioiTinh.SelectedIndex <0?2:this.txtGioiTinh.SelectedIndex;
                benhNhan.CanNang = int.Parse(this.txtCanNang.Text);
                benhNhan.DanTocID = this.lookUpDanToc.EditValue==null?1: int.Parse(this.lookUpDanToc.EditValue.ToString());
                benhNhan.TenBenhNhan = this.ChuyenSangChuHoa(this.txtTenBenhNhan.Text.Trim());
                benhNhan.NgayGioSinh = (this.ngayGioSinh.Year== new DateTime(0001,01,01).Year)==true? DateTime.Now : this.ngayGioSinh;
                benhNhan.NoiSinh = this.txtNoiSinh.Text;
                benhNhan.PhuongPhapSinh = this.cboPhuongPhapSinh.EditValue==null?2: this.cboPhuongPhapSinh.SelectedIndex;
                benhNhan.QuocTichID = 1;
                benhNhan.TuanTuoiKhiSinh = int.Parse(this.txtTuanTuoi.Text);
                benhNhan.MaBenhNhan = this.txtMaBenhNhan.Text;
                benhNhan.FatherBirthday = string.IsNullOrEmpty(this.txtNamSinhCha.EditValue.ToString()) ==true? DateTime.Now:(DateTime)this.txtNamSinhCha.EditValue;
                benhNhan.MotherBirthday = string.IsNullOrEmpty(this.txtNamSinhMe.EditValue.ToString()) == true  ? DateTime.Now : (DateTime)this.txtNamSinhMe.EditValue;
                benhNhan.FatherPhoneNumber = this.txtSDTCha.Text;
                benhNhan.MotherPhoneNumber = this.txtSDTMe.Text;
                benhNhan.FatherName = this.ChuyenSangChuHoa(this.txtTenCha.Text);
                benhNhan.MotherName = this.ChuyenSangChuHoa(this.txtTenMe.Text);
                benhNhan.DiaChi = this.txtDiaChiBN.Text;
                benhNhan.Para = this.txtPARA.Text;
                phieu.BenhNhan = benhNhan;
                phieu.maNVTaoPhieu = this.MaNhanVienDangNhap;
                phieu.maDonViCoSo = this.lookupDonVi.EditValue.ToString();
                phieu.idViTriLayMau = byte.Parse(this.radioGroupViTriLayMau.EditValue.ToString());
                phieu.isKhongDat = this.radioDanhGia.EditValue.ToString() != "1" ? true : false;
                phieu.lstChiDinhDichVu = this.lstChiDinhDichVu;
                phieu.lstLyDoKhongDat = this.lstDanhGiaChatLuong;
                if(!string.IsNullOrEmpty(this.txtMaPhieuLan1.Text.Trim()))
                phieu.isLayMauLan2 = true;
                else phieu.isLayMauLan2 = false;
                phieu.maBenhNhan = this.txtMaBenhNhan.Text.Trim();
                phieu.maCheDoDinhDuong = byte.Parse(this.RadioCheDoDD.EditValue.ToString());
                phieu.maChuongTrinh = this.lookupChuongTrinh.EditValue.ToString();
                phieu.maGoiXetNghiem = this.radioGroupGoiXN.EditValue.ToString();
                phieu.maPhieuLan1 = this.txtMaPhieuLan1.Text;
                phieu.maTinhTrangLucLayMau = byte.Parse(this.radioGroupViTriLayMau.EditValue.ToString());
                phieu.ngayGioLayMau = this.ngayGioLayMau==null||this.ngayGioLayMau.Date==new DateTime(0001,01,01)?DateTime.Now:this.ngayGioLayMau;
                phieu.ngayNhanMau = this.txtNgayNhanMau.DateTime;
                phieu.maPhieu = this.barCodePhieu.Text;
               // if (!string.IsNullOrEmpty(this.txtNgayTruyenMau.EditValue.ToString()))
                phieu.ngayTruyenMau = string.IsNullOrEmpty(this.txtNgayTruyenMau.EditValue.ToString()) == true ? DateTime.Now : (DateTime)this.txtNgayTruyenMau.EditValue;
                phieu.SoDTNhanVienLayMau = this.txtSDTNguoiLayMau.Text;
                if (!string.IsNullOrEmpty(this.txtSoLuongTruyenMau.Text))
                    phieu.soLuongTruyenMau = short.Parse(this.txtSoLuongTruyenMau.Text);
                phieu.TenNhanVienLayMau = this.ChuyenSangChuHoa(this.txtNguoiLayMau.Text);
                phieu.NoiLayMau = this.txtNoiLayMau.Text;
                phieu.DiaChiLayMau = this.txtDiaChiDonVi.Text;
                phieu.paRa = this.txtPARA.Text;
                phieu.ngayTaoPhieu = DateTime.Now;
                this.ValidateFrom();
                foreach ( var item in this.lstDanhGiaSoBo)
                {
                    if( item.maGiaTri.Equals("islaymautruoc24h"))
                    {
                        phieu.isTruoc24h = item.giaTri == true ? true : false;
                    }
                    if (item.maGiaTri.Equals("isSinhNon"))
                    {
                        phieu.isSinhNon = item.giaTri == true ? true : false;
                    }
                    if (item.maGiaTri.Equals("isNheCan"))
                    {
                        phieu.isNheCan = item.giaTri == true ? true : false;
                    }
                    if (item.maGiaTri.Equals("isGuiMauTre"))
                    {
                        phieu.isGuiMauTre = item.giaTri == true ? true : false;
                    }
                }
                if (phieu.lstLyDoKhongDat.Count > 0)
                {
                    List<PSDanhMucDanhGiaChatLuongMau> lstTTLyDo = BioNet_Bus.GetDanhMucDanhGiaChatLuong();
                    if (lstTTLyDo.Count > 0)
                    {
                        foreach (var ld in phieu.lstLyDoKhongDat)
                        {
                            var res = lstTTLyDo.FirstOrDefault(o => o.IDDanhGiaChatLuongMau == ld.IDDanhGiaChatLuongMau);
                            if (res != null)
                            {
                                    ld.TenLyDo = res.ChatLuongMau;
                                    if (string.IsNullOrEmpty(lydokhongdat))
                                    lydokhongdat += res.ChatLuongMau;
                                else lydokhongdat += ". " + res.ChatLuongMau;
                            }
                        }
                    }
                }
                phieu.lydokhongdat = lydokhongdat;

                PsChiDinhvsDanhGia DotchiDinh = new PsChiDinhvsDanhGia();
                DotchiDinh.MaNVChiDinh = this.MaNhanVienDangNhap;
                DotchiDinh.MaChiDinh = this.txtMaChiDinh.Text.Trim();
                DotchiDinh.MaDonVi = this.lookupDonVi.EditValue.ToString();
                DotchiDinh.MaGoiDichVu = this.radioGroupGoiXN.EditValue.ToString();
                DotchiDinh.MaNVChiDinh = this.MaNhanVienDangNhap;
                DotchiDinh.Phieu = phieu;
                DotchiDinh.MaTiepNhan = this.txtMaTiepNhan.Text.Trim();
                DotchiDinh.MaPhieu = this.txtMaPhieu.Text.Trim();
                DotchiDinh.MaPhieuLan1 = this.txtMaPhieuLan1.Text.Trim();
                DotchiDinh.NgayChiDinhHienTai = DateTime.Now.Date;
                DotchiDinh.NgayChiDinhLamViec = DateTime.Now.Date;
                DotchiDinh.NgayTiepNhan = this.ngayTiepNhan;
                DotchiDinh.SoLuong = 1;
               // DotchiDinh.TrangThaiChiDinh = 1;
              
                DotchiDinh.lstDichVu = this.lstChiDinhDichVu;
                if (!this.KiemTraCacTruongDuLieuTruocKhiLuu())
                    return;
                else
                {
                    SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.WaitingfromSave), true, true, false);
                    var result = BioNet_Bus.InsertDotChiDinhDichVu(DotchiDinh);
                    SplashScreenManager.CloseForm();
                    if (result.Result)
                    //string maCD = BioNet_Bus.InsertDotChiDinhDichVu(DotchiDinh);
                    //DotchiDinh.MaChiDinh = maCD;
                    //if (!string.IsNullOrEmpty(maCD))
                    {
                        XtraMessageBox.Show("Đã lưu!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // this.lstDaDanhGia.Add(DotchiDinh);
                        this.LoadGCDotChiDinh();
                        this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
                        this.LoadDanhSachDaDanhGiaTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
                        this.LoadNew();
                        this.ReadOnly(true);
                        this.LoadGCChiDinhDichVu();
                        this.btnDuyet.Enabled = false;
                        this.btnSua.Enabled = false;
                        this.GVDanhSachTiepNhan.Focus();
                        // this.LoadDanhSachTiepNhanTheoDonVi(this.lookUpDanToc.EditValue.ToString());
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi không thể lưu thông tin phiếu và đánh giá mẫu.\r\n Lỗi chi tiết" + result.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

           catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadGCDotChiDinh()
        {
            this.GCDanhSachDaTracking.DataSource = null;
            this.GCDanhSachDaTracking.DataSource = this.lstDaDanhGia;
        }

        private void LoadSearchLookUpDoViCoSo()
        {
            try
            {   this.lstDVCS.Clear();
                this.lstDVCS = BioNet_Bus.GetDanhSachDonVi_Searchlookup();
                this.searchLookUpDonViCoSo.Properties.DataSource = this.lstDVCS;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi load danh sách đơn vị cơ sở \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.searchLookUpDonViCoSo.Focus();
            }
        }
        private void LoadDanhSachDichVu()
        {
            this.lstDichVu.Clear();
            this.lstDichVu = BioNet_Bus.GetDanhSachDichVu(false);
            this.checkedListBoxXN.Items.Clear();

            foreach (PsDichVu v in this.lstDichVu)
            {
                this.checkedListBoxXN.Items.Add(v,v.TenDichVu);
            }
            //this.checkedListBoxXN.DataSource = this.lstDichVu;
        }
        private void LoadGoiXetNghiem(string maDonVi)
        {
            var list = BioNet_Bus.GetDanhsachGoiDichVuTrungTam(maDonVi);
            this.radioGroupGoiXN.Properties.Items.Clear();
            foreach (var item in list)
            {
                if(!item.IDGoiDichVuChung.Equals("DVGXNL2"))
                this.radioGroupGoiXN.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(item.IDGoiDichVuChung, item.TenGoiDichVuChung));
            }
        }
        private void LoadDichVuTheoGoi(string maGoiDichVu)
        {
            this.lstChiDinhDichVu.Clear();

        }
        private void LoadGCChiDinhDichVu()
        {
            this.GCChiDinhDichVu.DataSource = null;
            this.GCChiDinhDichVu.DataSource = this.lstChiDinhDichVu;
        }
        private void radioGroupTinhTrangTre_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                RadioGroup rd = sender as RadioGroup;
                var ts = rd.EditValue;
                if (int.Parse(ts.ToString()) == 4)
                {
                    this.txtSoLuongTruyenMau.Enabled = true;
                    this.txtNgayTruyenMau.Enabled = true;
                    this.txtSoLuongTruyenMau.ReadOnly = false;
                    this.txtNgayTruyenMau.ReadOnly = false;
                }
                else
                {
                    this.txtSoLuongTruyenMau.Enabled = false;
                    this.txtSoLuongTruyenMau.ResetText();
                    this.txtNgayTruyenMau.ResetText();
                    this.txtNgayTruyenMau.Enabled = false;
                }
            }
            catch
            {
            }
        }
        private void GVDanhSachTiepNhan_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    bool isDaNhapLieu = false;
                    try
                    {
                        isDaNhapLieu =(bool) View.GetRowCellValue(e.RowHandle, View.Columns["isDaNhapLieu"]);
                    }
                    catch { }
                    
                    if (!isDaNhapLieu)
                    {
                        e.Appearance.BackColor = Color.Salmon;
                        e.Appearance.BackColor2 = Color.SeaShell;
                    }
                    else
                    {   
                       // View.SelectRow(e.RowHandle);
                        e.Appearance.BackColor = Color.Aqua;
                        e.Appearance.BackColor2 = Color.AliceBlue;
                    }
                }
            }
            catch { }
        }

        private void radioGroupGoiXN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                RadioGroup rd = sender as RadioGroup;
                var ts = rd.EditValue;
                if (ts.Equals("DVGXN0001"))
                {       if(!string.IsNullOrEmpty(this.txtMaPhieuLan1.Text.Trim()))
                        this.checkedListBoxXN.Enabled = true;
                        this.lstChiDinhDichVu.Clear();
                        this.LoadGCChiDinhDichVu();
                        this.LoadDanhSachDichVu();
                        this.txtMaPhieuLan1.Enabled = true;
                    if(!string.IsNullOrEmpty(this.txtMaPhieuLan1.Text.Trim()))
                        this.isMauThuLai = true;
                    else  this.isMauThuLai = false;
                    //if (!string.IsNullOrEmpty(txtMaChiDinh.Text.Trim()))
                    //{
                    //    if (this.txtMaChiDinh.Text.Substring(0, 2) == "XN")
                    //        this.checkedListBoxXN.Enabled = true;
                    //    else this.checkedListBoxXN.Enabled = false;
                    //}
                    
                    
                }
                else
                {
                    this.txtMaPhieuLan1.ResetText();
                    this.isMauThuLai = false;
                    this.checkedListBoxXN.Enabled = false;
                    this.checkedListBoxXN.DataSource = null;
                    this.LoadDanhSachDichVuTheoGoi(ts.ToString());
                    this.txtMaPhieuLan1.Enabled = false;
                }
                    
            }
            catch {
                this.checkedListBoxXN.DataSource = null;
                this.LoadDanhSachDichVu();
                    this.txtMaPhieuLan1.Enabled = false;
            }
        }
        private void LoadDanhSachDichVuTheoGoi(string maGoi)
        {
            this.lstChiDinhDichVu.Clear();
            this.lstChiDinhDichVu = BioNet_Bus.GetDanhSachDichVuTheoMaGoi(maGoi, this.lookupDonVi.EditValue.ToString());
            this.LoadGCChiDinhDichVu();
        }
       
        //private void searchLookUpDonViCoSo_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        SearchLookUpEdit lkup = sender as SearchLookUpEdit;
        //        var madv = lkup.EditValue.ToString();

        //        if (string.IsNullOrEmpty(madv)) madv = "ALL";
        //        //    this.LoadDanhSachDaDanhGiaTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
        //        //    this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
        //    }
        //    catch(Exception ex)
        //    {
        //        // XtraMessageBox.Show("Lỗi khi load danh sách phiếu đã tiếp nhận theo đơn vị \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        this.searchLookUpDonViCoSo.EditValue= "ALL";
        //    }
        //}
        private void barCodePhieu_Click(object sender, EventArgs e)
        {

        }
        private void ThayDoiChiDinhDichVu(PsDichVu dv,bool isThem)
        {
            if (isThem)
            {
                if (this.lstChiDinhDichVu.Count ==0)
                {
                    this.lstChiDinhDichVu.Add(dv);
                    this.LoadGCChiDinhDichVu();
                }
                else
                {
                    if (this.lstChiDinhDichVu.FindAll(p => p.IDDichVu == dv.IDDichVu).Count < 1)
                    {
                        this.lstChiDinhDichVu.Add(dv);
                        this.LoadGCChiDinhDichVu();
                    }
                }
            }
            else
            {   if(this.lstChiDinhDichVu.Count>0)
                {
                    var deldv = this.lstChiDinhDichVu.FirstOrDefault(p => p.IDDichVu == dv.IDDichVu);
                    if (deldv != null)
                    {
                        this.lstChiDinhDichVu.Remove(deldv);
                        this.LoadGCChiDinhDichVu();
                    }
                }
            }
        }
        private void ThayDoiThongTinChiTietKhongDat(PSChiTietDanhGiaChatLuong LydoKhongDat,bool isThem)
        {
            if (isThem)
            {
                if (this.lstDanhGiaChatLuong.Count == 0)
                {
                    this.lstDanhGiaChatLuong.Add(LydoKhongDat);
                }
                else
                {
                    if (this.lstDanhGiaChatLuong.FindAll(p => p.IDDanhGiaChatLuongMau == LydoKhongDat.IDDanhGiaChatLuongMau).Count < 1)
                    {
                        this.lstDanhGiaChatLuong.Add(LydoKhongDat);
                    }
                }
            }
            else
            {
                if (this.lstDanhGiaChatLuong.Count > 0)
                {
                    var ld = this.lstDanhGiaChatLuong.FirstOrDefault(p => p.IDDanhGiaChatLuongMau == LydoKhongDat.IDDanhGiaChatLuongMau);
                    if(ld!=null)
                    {
                        this.lstDanhGiaChatLuong.Remove(ld);
                    }
                }
               
            }
        }
        private void checkedListBoxXN_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {try
            {
                CheckedListBoxControl obj = sender as CheckedListBoxControl;
                string check = obj.GetItemCheckState(e.Index).ToString();
                if (check.Equals("Checked"))
                {
                    PsDichVu value = obj.GetItemValue(e.Index) as PsDichVu;
                    PsDichVu dv = BioNet_Bus.GetThongTinDichVu(value.IDDichVu, this.lookupDonVi.EditValue.ToString());
                    if (!string.IsNullOrEmpty(this.txtMaPhieuLan1.Text.Trim()))
                    {
                        if (this.listdvcanlamlai.FirstOrDefault(p => p.MaDichVu == value.IDDichVu) == null)
                        {
                            XtraMessageBox.Show("Xét nghiệm vừa chọn không phải là xét nghiệm cần làm lại của phiếu lần 1", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            obj.SetItemCheckState(e.Index,CheckState.Unchecked);
                        }
                        else {
                            if (dv != null)
                            {
                                this.ThayDoiChiDinhDichVu(dv, true);
                            }
                        }
                    }
                    else
                    {
                        if (dv != null)
                        {
                            this.ThayDoiChiDinhDichVu(dv, true);
                        }
                    }
                }
                else
                {
                    PsDichVu value = obj.GetItemValue(e.Index) as PsDichVu;
                    PsDichVu dv = BioNet_Bus.GetThongTinDichVu(value.IDDichVu, this.lookupDonVi.EditValue.ToString());
                    if (dv != null)
                    {
                        this.ThayDoiChiDinhDichVu(dv, false);
                    }
                }
            }
            catch { }
        }
        
        private void checkedListBoxXN_DataSourceChanged(object sender, EventArgs e)
        {
            CheckedListBoxControl obj = sender as CheckedListBoxControl;
            if (obj.Enabled)
            {
                if (checkedListBoxXN.CheckedItemsCount > 0)
                {
                    for (int i = 0; i < this.checkedListBoxXN.ItemCount; i++)
                    {
                        var item = this.checkedListBoxXN.GetItemCheckState(i);
                        var value = this.checkedListBoxXN.GetItemValue(i);
                        if (item == CheckState.Checked)
                        {
                            PsDichVu dv = BioNet_Bus.GetThongTinDichVu(this.checkedListBoxXN.GetItemValue(i).ToString(), this.lookupDonVi.EditValue.ToString());
                            if (dv != null) this.lstChiDinhDichVu.Add(dv);
                        }
                    }
                }
                this.LoadGCChiDinhDichVu();
            }
        }
        private string ChuyenSangChuHoa(string chuoi)
        {
            if (!string.IsNullOrEmpty(chuoi))
                return chuoi.ToUpper();
            else return string.Empty;
        }
        private void radioDanhGia_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                RadioGroup rd = sender as RadioGroup;
                var value = rd.EditValue.ToString();
                if (!value.Equals("1"))
                {
                    //this.checkedListBoxLydoKhongDat.DataSource = null;
                    //this.checkedListBoxLydoKhongDat.DataSource = BioNet_Bus.GetDanhMucDanhGiaChatLuong();
                    foreach (PSDanhMucDanhGiaChatLuongMau v in this.sourceListDanhGiaChatLuong)
                    {
                        this.checkedListBoxLydoKhongDat.Items.Add(v.IDDanhGiaChatLuongMau, v.ChatLuongMau);
                    }
                    this.checkedListBoxLydoKhongDat.Enabled = true;
                    this.KiemtraChitietDanhGiaCuaPhieu();
                }
                else
                {
                    this.lstDanhGiaChatLuong.Clear();
                    //this.checkedListBoxLydoKhongDat.DataSource = null;
                    this.checkedListBoxLydoKhongDat.Items.Clear();
                    this.checkedListBoxLydoKhongDat.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi load dữ liệu ! \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void KiemTraNhapNgaySinh()
        {
            DateTime ngayhientai = BioNet_Bus.GetDateTime();
            if ((DateTime)txtNamSinhBenhNhan.EditValue == ngayhientai.Date)
            {
                this.txtNamSinhBenhNhan.EditValue = this.txtNgayLayMau.EditValue;
            }
        }
        private void txtNamSinhBenhNhan_Validated(object sender, EventArgs e)
        {
            try {
                if(string.IsNullOrEmpty(this.txtNamSinhBenhNhan.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng nhập ngày sinh của trẻ !", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNamSinhBenhNhan.Focus();
                    return;
                }
                this.KiemTraNhapNgaySinh();
                DateEdit obj = sender as DateEdit;
                DateTime date = (DateTime)obj.EditValue;
                if (!string.IsNullOrEmpty(date.ToString()))
                {
                    string txtgiosinh = this.txtGioSinhBenhNhan.EditValue == null ? "" : this.txtGioSinhBenhNhan.EditValue.ToString();
                    string txtngaylayMau = this.txtNgayLayMau.EditValue == null ? "" : this.txtNgayLayMau.EditValue.ToString();
                    string txtgiolaymau = this.txtGioLayMau.EditValue == null ? "" : this.txtGioLayMau.EditValue.ToString();
                    this.ngayGioSinh = Convert.ToDateTime(date).Date + new TimeSpan(ngayGioSinh.Hour, ngayGioSinh.Minute, ngayGioSinh.Second);
                    if (!string.IsNullOrEmpty(txtgiosinh) && !string.IsNullOrEmpty(txtngaylayMau) && !string.IsNullOrEmpty(txtgiolaymau))
                    {
                       this.ValidateThuMauSom(this.ngayGioSinh, this.ngayGioLayMau);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng nhập đúng ngày sinh!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNamSinhBenhNhan.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi kiểm tra toàn vẹn dữ liệu ! \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        

        private void txtGioSinhBenhNhan_Validated(object sender, EventArgs e)
        {
            TimeEdit obj = sender as TimeEdit;
            TimeSpan time = Convert.ToDateTime(obj.EditValue).TimeOfDay;
            if (!string.IsNullOrEmpty(time.ToString()))
            {
                string txtnamsinh = this.txtNamSinhBenhNhan.EditValue == null ? "" : this.txtNamSinhBenhNhan.EditValue.ToString();
                string txtngaylayMau = this.txtNgayLayMau.EditValue == null ? "" : this.txtNgayLayMau.EditValue.ToString();
                string txtgiolaymau = this.txtGioLayMau.EditValue == null ? "" : this.txtGioLayMau.EditValue.ToString();
                if (string.IsNullOrEmpty(txtnamsinh))
                {
                    this.ngayGioSinh = Convert.ToDateTime(obj.EditValue);
                    this.txtNamSinhBenhNhan.EditValue = this.ngayGioSinh;
                }
                else
                    this.ngayGioSinh = Convert.ToDateTime(txtNamSinhBenhNhan.EditValue).Date + new TimeSpan(time.Hours, time.Minutes, time.Seconds);
                if(!string.IsNullOrEmpty(txtnamsinh)&& !string.IsNullOrEmpty(txtngaylayMau)&& !string.IsNullOrEmpty(txtgiolaymau))
                {
                    this.ValidateThuMauSom(this.ngayGioSinh, this.ngayGioLayMau);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập đúng trường giờ sinh!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtGioSinhBenhNhan.Focus();
            }

        }

        private void txtNgayLayMau_Validated(object sender, EventArgs e)
                {
            try
            {
                DateEdit obj = sender as DateEdit;
                DateTime date = (DateTime)obj.EditValue;
                if (!string.IsNullOrEmpty(date.ToString()))
                {
                    string txtgiosinh = this.txtGioSinhBenhNhan.EditValue == null ? "" : this.txtGioSinhBenhNhan.EditValue.ToString();
                    string txtngaysinh = this.txtNamSinhBenhNhan.EditValue == null ? "" : this.txtNamSinhBenhNhan.EditValue.ToString();
                    string txtgiolaymau = this.txtGioLayMau.EditValue == null ? "" : this.txtGioLayMau.EditValue.ToString();
                    this.ngayGioLayMau = Convert.ToDateTime(date).Date + new TimeSpan(ngayGioLayMau.Hour, ngayGioLayMau.Minute, ngayGioLayMau.Second);
                    if (!string.IsNullOrEmpty(txtgiosinh) && !string.IsNullOrEmpty(txtngaysinh) && !string.IsNullOrEmpty(txtgiolaymau))
                    {
                        this.ValidateThuMauSom(this.ngayGioSinh, this.ngayGioLayMau);
                        this.ValidateGuiMauTre(this.ngayGioLayMau, this.ngayTiepNhan);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng nhập đúng ngày ngày lấy mẫu!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgayLayMau.Focus();
                }
            }catch(Exception ex)
            {
                XtraMessageBox.Show("Vui lòng nhập đúng ngày ngày lấy mẫu!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNgayLayMau.Focus();
            }
        }

        private void txtGioLayMau_Validated(object sender, EventArgs e)
        {
            TimeEdit obj = sender as TimeEdit;
            TimeSpan time = Convert.ToDateTime(obj.EditValue).TimeOfDay;
            if (!string.IsNullOrEmpty(time.ToString()))
            {
                string txtgiosinh = this.txtGioSinhBenhNhan.EditValue == null ? "" : this.txtGioSinhBenhNhan.EditValue.ToString();
                string txtngaylayMau = this.txtNgayLayMau.EditValue == null ? "" : this.txtNgayLayMau.EditValue.ToString();
                string txtngaysinh = this.txtNamSinhBenhNhan.EditValue == null ? "" : this.txtNamSinhBenhNhan.EditValue.ToString();
                if (string.IsNullOrEmpty(txtngaylayMau))
                {
                    this.ngayGioLayMau = Convert.ToDateTime(obj.EditValue);
                    this.txtNgayLayMau.EditValue = this.ngayGioLayMau;
                }
                else
                    this.ngayGioLayMau = Convert.ToDateTime(txtNgayLayMau.EditValue).Date + new TimeSpan(time.Hours, time.Minutes, time.Seconds);
                if (!string.IsNullOrEmpty(txtngaysinh) && !string.IsNullOrEmpty(txtngaylayMau) && !string.IsNullOrEmpty(txtgiosinh))
                {
                    this.ValidateThuMauSom(this.ngayGioSinh, this.ngayGioLayMau);
                    this.ValidateGuiMauTre(this.ngayGioLayMau, this.ngayTiepNhan);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập đúng trường giờ sinh!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtGioSinhBenhNhan.Focus();
            }
            
        }

        private void txtCanNang_Validated(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCanNang.Text.Trim()))
            {
                XtraMessageBox.Show("Vui lòng nhập đúng trường Cân nặng của trẻ!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCanNang.Focus();
            }
            else
            {
                this.ValidateNheCan();
            }
        }

        private void checkedListBoxLydoKhongDat_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                CheckedListBoxControl obj = sender as CheckedListBoxControl;
                string check = obj.GetItemCheckState(e.Index).ToString();
                if (check.Equals("Checked"))
                {
                    string value = obj.GetItemValue(e.Index).ToString();
                   
                    if (!string.IsNullOrEmpty(value))
                    {
                        PSChiTietDanhGiaChatLuong dg = new PSChiTietDanhGiaChatLuong();
                        dg.IDPhieu = this.txtMaPhieu.Text;
                        dg.IDDanhGiaChatLuongMau = value;
                        dg.MaTiepNhan = this.txtMaTiepNhan.Text.Trim();
                        
                        this.ThayDoiThongTinChiTietKhongDat(dg, true);
                    }
                }
                else
                {
                    string value = obj.GetItemValue(e.Index).ToString();

                    if (!string.IsNullOrEmpty(value))
                    {
                        PSChiTietDanhGiaChatLuong dg = new PSChiTietDanhGiaChatLuong();
                        dg.IDPhieu = this.txtMaPhieu.Text;
                        dg.IDDanhGiaChatLuongMau = value;
                        dg.MaTiepNhan = this.txtMaTiepNhan.Text.Trim();
                        this.ThayDoiThongTinChiTietKhongDat(dg, false);
                    }
                }
            }
            catch(Exception ex) {

            }
        }
        private void ValidateFrom ()
        {
            try
            {
                this.ValidateSinhNon();
                this.ValidateGuiMauTre(this.ngayGioLayMau, (DateTime)this.ngayTiepNhan);
                this.ValidateNheCan();
                this.ValidateThuMauSom(this.ngayGioSinh, this.ngayGioLayMau);
            }
            catch { }
        }
        private void ValidateSinhNon()
        {try
            {
                if (!string.IsNullOrEmpty(this.txtTuanTuoi.Text.Trim()))
                {
                    int tuan = int.Parse(this.txtTuanTuoi.EditValue.ToString());
                    if (tuan > 0 && tuan <= this.GiaTriSinhNon)
                    {
                        var tt = this.lstDanhGiaSoBo.FirstOrDefault(p => p.maGiaTri == "isSinhNon");
                        if (tt != null)
                        {
                            tt.giaTri = true;

                        }
                        else
                        {
                            PsDanhGiaMauSoBo dg1 = new PsDanhGiaMauSoBo();
                            dg1.giaTri = true;
                            dg1.maGiaTri = "isSinhNon";
                            dg1.noiDungChuThich = "Sinh non";
                            this.lstDanhGiaSoBo.Add(dg1);
                        }

                    }
                    else
                    {
                        var nc = this.lstDanhGiaSoBo.FirstOrDefault(p => p.maGiaTri == "isSinhNon");
                        if (nc != null)
                            nc.giaTri = false;
                        else
                        {
                            PsDanhGiaMauSoBo dg1 = new PsDanhGiaMauSoBo();
                            dg1.giaTri = false;
                            dg1.maGiaTri = "isSinhNon";
                            dg1.noiDungChuThich = "Sinh non";
                            this.lstDanhGiaSoBo.Add(dg1);
                        }
                    }
                    this.LoadThongTinLuuY();
                }
            }
            catch { }
        }
        private void ValidateNheCan()
        {try
            {
                if (!string.IsNullOrEmpty(this.txtCanNang.Text.Trim()))
                {
                    if (int.Parse(txtCanNang.EditValue.ToString()) < this.GiaTriNheCan)
                    {
                        var nc = this.lstDanhGiaSoBo.FirstOrDefault(p => p.maGiaTri == "isNheCan");
                        if (nc != null)
                            nc.giaTri = true;
                        else
                        {
                            PsDanhGiaMauSoBo dg1 = new PsDanhGiaMauSoBo();
                            dg1.giaTri = true;
                            dg1.maGiaTri = "isNheCan";
                            dg1.noiDungChuThich = "Nhẹ cân";
                            this.lstDanhGiaSoBo.Add(dg1);
                        }

                    }
                    else
                    {
                        var nc = this.lstDanhGiaSoBo.FirstOrDefault(p => p.maGiaTri == "isNheCan");
                        if (nc != null)
                            nc.giaTri = false;
                        else
                        {
                            PsDanhGiaMauSoBo dg1 = new PsDanhGiaMauSoBo();
                            dg1.giaTri = false;
                            dg1.maGiaTri = "isNheCan";
                            dg1.noiDungChuThich = "Nhẹ cân";
                            this.lstDanhGiaSoBo.Add(dg1);
                        }

                    }
                    this.LoadThongTinLuuY();
                }
            }
            catch { }
        }
        private void ValidateGuiMauTre(DateTime ngayGioLayMau,DateTime ngayNhanMau)
        {
            try
            {
                TimeSpan time = ngayNhanMau - ngayGioLayMau;
                if (time.TotalMinutes > 7200)
                {
                    var dg = this.lstDanhGiaSoBo.FirstOrDefault(p => p.maGiaTri == "isGuiMauTre");
                    if (dg != null)
                        dg.giaTri = true;
                    else
                    {
                        PsDanhGiaMauSoBo dg1 = new PsDanhGiaMauSoBo();
                        dg1.giaTri = true;
                        dg1.maGiaTri = "isGuiMauTre";
                        dg1.noiDungChuThich = "Gửi mẫu trễ";
                        this.lstDanhGiaSoBo.Add(dg1);
                    }
                }
                else
                {
                    var dg = this.lstDanhGiaSoBo.FirstOrDefault(p => p.maGiaTri == "isGuiMauTre");
                    if (dg != null)
                        dg.giaTri = false;
                    else
                    {
                        PsDanhGiaMauSoBo dg1 = new PsDanhGiaMauSoBo();
                        dg1.giaTri = false;
                        dg1.maGiaTri = "isGuiMauTre";
                        dg1.noiDungChuThich = "Gửi mẫu trễ";
                        this.lstDanhGiaSoBo.Add(dg1);
                    }
                }
                this.LoadThongTinLuuY();
            }
            catch { }
        }
        private void ValidateThuMauSom(DateTime ngayGioSinh, DateTime ngayGioLayMau)
        {
            try
            {
                TimeSpan time = ngayGioLayMau - ngayGioSinh;
                if (time.TotalHours < 24 && time.TotalHours > 0)
                {
                    var dg = this.lstDanhGiaSoBo.FirstOrDefault(p => p.maGiaTri == "islaymautruoc24h");
                    if (dg != null)
                        dg.giaTri = true;
                    else
                    {
                        PsDanhGiaMauSoBo dg1 = new PsDanhGiaMauSoBo();
                        dg1.giaTri = true;
                        dg1.maGiaTri = "islaymautruoc24h";
                        dg1.noiDungChuThich = "Lấy mẫu trước 24h sau khi sinh";
                        this.lstDanhGiaSoBo.Add(dg1);
                    }
                }
                else
                {
                    var dg = this.lstDanhGiaSoBo.FirstOrDefault(p => p.maGiaTri == "islaymautruoc24h");
                    if (dg != null)
                        dg.giaTri = false;
                    else
                    {
                        PsDanhGiaMauSoBo dg1 = new PsDanhGiaMauSoBo();
                        dg1.giaTri = false;
                        dg1.maGiaTri = "islaymautruoc24h";
                        dg1.noiDungChuThich = "Lấy mẫu trước 24h sau khi sinh";
                        this.lstDanhGiaSoBo.Add(dg1);
                    }
                }
                this.LoadThongTinLuuY();
            }
            catch { }
        }
        
        private void txtTuanTuoi_Validated(object sender, EventArgs e)
        {
            this.ValidateSinhNon();
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (this.lstChiDinhDichVu.Count <=0 )
            {
                XtraMessageBox.Show("Vui lòng chọn các dịch vụ xét nghiệm!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        if(this.lookupChuongTrinh.EditValue==null)
            {
                XtraMessageBox.Show("Vui lòng chọn chương trình", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.KiemTraCacTruongDuLieuTruocKhiLuu())
            {
                this.LuuThongTinPhieu(true);
            }
        }

        private void txtMaPhieuLan1_DelayedTextChanged(object sender, EventArgs e)
        {
            try {
                TextBox txt = sender as TextBox;
                string str = txt.Text.Trim();
                if (!string.IsNullOrEmpty(str) && str.Length > 5&&!this.txtTenBenhNhan.ReadOnly)
                {
                    PsPhieu phieu = BioNet_Bus.GetThongTinPhieu(str,this.lookupDonVi.EditValue.ToString());
                    if (phieu != null)
                    {
                        if (phieu.trangThaiMau == 6)
                        {
                            if (!BioNet_Bus.KiemTraPhieuThuMauLaiDaDuocChiDinhChua(str))
                            {
                                this.listdvcanlamlai.Clear();
                                this.listdvcanlamlai = BioNet_Bus.GetDichVuCanLamLaiCuaPhieu(phieu.maPhieu, phieu.maDonViCoSo);
                                if (listdvcanlamlai.Count > 0)
                                    HienThiThongTinPhieuCu(phieu);
                                else
                                    XtraMessageBox.Show("Phiếu " + str + "được chỉ định thu lại \r\n nhưng không tìm thấy danh sách thông số nguy cơ cao cần xét nghiệm lại. \r\n Vui lòng kiểm tra lại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                            }
                            else
                            {
                                XtraMessageBox.Show("Phiếu " + str + " đã được thu mẫu lại rồi", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.txtMaPhieuLan1.ResetText();
                            }
                        }
                        else
                            XtraMessageBox.Show("Phiếu " + str + " Không có được yêu cầu lấy mẫu lại. \r\n Vui lòng kiểm tra lại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    }

                    else XtraMessageBox.Show("Không tìm thấy thông tin cũ của phiếu " + str + " thuộc đơn vị "+this.lookupDonVi.Text.Trim() +". Vui lòng kiểm tra lại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DienThongTinMacDinhCuaDonViLenPhieu(this.lookupDonVi.EditValue.ToString());
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lấy thông tin phiếu cũ. Lỗi chi tiết \r\n" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void duyetTatCa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.LayDanhSachDanhGiaHangLoat();
                if (this.lstDSCanDanhGia.Count > 0)
                {
                    List<PsPhieuLoiKhiDanhGia> listphieuloi = new List<PsPhieuLoiKhiDanhGia>();
                    DiaglogFrm.FrmDiaglogChonGoiXetNghiem frm = new DiaglogFrm.FrmDiaglogChonGoiXetNghiem();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        string maGoiXN = frm.maGoiXn;
                    //    DiaglogFrm.WaitingfromSave frmsv = new DiaglogFrm.WaitingfromSave("Đang lưu dữ liệu, vui lòng đợi trong giây lát...");
                        SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.WaitingfromSave), true, true, false);
                        foreach (var item in this.lstDSCanDanhGia)
                        {
                            var result = BioNet_Bus.InsertChiDinhTheoDanhSachHangLoat(item, this.MaNhanVienDangNhap, maGoiXN);
                            if (!result.Result)
                            {
                               // XtraMessageBox.Show("Lưu thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               // this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
                            
                                PsPhieuLoiKhiDanhGia phieu = new PsPhieuLoiKhiDanhGia();
                                phieu.MaPhieu = item.MaPhieu;
                                phieu.ThongTinLoi = result.StringError;
                                listphieuloi.Add(phieu);
                              //  XtraMessageBox.Show("Lưu thất bại", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        SplashScreenManager.CloseForm();
                        if (listphieuloi.Count <1)
                        {
                            XtraMessageBox.Show("Lưu thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DiaglogFrm.FrmDiagLogShowPhieuLoi frmloi = new DiaglogFrm.FrmDiagLogShowPhieuLoi(listphieuloi);
                            frmloi.ShowDialog();
                        }
                        this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
                    }
                   

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            }

        private void GVDanhSachTiepNhan_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(GCDanhSachTiepNhan.PointToScreen(e.Point));
        }

        private void lookupDonVi_EditValueChanged(object sender, EventArgs e)
        {
            try
                {
                DevExpress.XtraEditors.LookUpEdit lk = sender as DevExpress.XtraEditors.LookUpEdit;
                var donvi = BioNet_Bus.GetThongTinDonViCoSo(lk.EditValue.ToString());
                if( donvi!=null)
                {
                    if (string.IsNullOrEmpty(this.txtNoiSinh.Text.Trim())) this.txtNoiSinh.Text = donvi.TenDVCS;
                    if (string.IsNullOrEmpty(this.txtNoiLayMau.Text.Trim())) this.txtNoiLayMau.Text = donvi.TenDVCS;
                    if (string.IsNullOrEmpty(this.txtDiaChiDonVi.Text.Trim())) this.txtDiaChiDonVi.Text = donvi.DiaChiDVCS;
                }
                this.txtNguoiLayMau.ResetText();
                this.txtSDTNguoiLayMau.ResetText();
            }
            catch { }
        }

        private void txtCanNang_Validated_1(object sender, EventArgs e)
        {
            this.ValidateNheCan();
        }

        private void txtTuanTuoi_Validated_1(object sender, EventArgs e)
        {
            this.ValidateSinhNon();
        }

        private void barButtonILoadDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                this.LoadDanhSachDaDanhGiaTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());

                this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
            
        }

        //private void txtTuNgay_DsCho_EditValueChanged(object sender, EventArgs e)
        //{if(this.txtDenNgay_DsCho.EditValue !=null)
        //    {
        //        this.LoadDanhSachDaDanhGiaTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());

        //        this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
        //    }
        //}

        //private void txtDenNgay_DsCho_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (this.txtTuNgay_DsCho.EditValue != null)
        //    {
        //        this.LoadDanhSachDaDanhGiaTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());

        //        this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
        //    }
        //}

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            this.LoadLookupDonViCoSo();
            this.LoadDanhSachChuongTrinhSangLoc();
            this.LoadLookupDanToc();
            this.LoadListDanhGiaSoBo();              
            this.sourceListDanhGiaChatLuong = BioNet_Bus.GetDanhMucDanhGiaChatLuong();
            this.LoadDanhSachDaDanhGiaTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
            this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
        }

        

        private void txtTenBenhNhan_Validated(object sender, EventArgs e)
        {
            if(!this.txtTenBenhNhan.ReadOnly)
            this.ValidateTxtTenBenhNhan();
        }

        private void txtTenMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtNamSinhMe.Focus();
            }
        }

        private void txtNamSinhMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtSDTMe.Focus();
            }
        }

        private void txtSDTMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtTenCha.Focus();
            }
        }

        private void txtTenCha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtNamSinhCha.Focus();
            }
        }

        private void txtNamSinhCha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtSDTCha.Focus();
            }
        }

        private void txtSDTCha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtDiaChiBN.Focus();
            }
        }

        private void txtDiaChiBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.cboPhuongPhapSinh.Focus();
            }
        }

        private void cboPhuongPhapSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtPARA.Focus();
            }
        }

        private void txtPARA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtNoiLayMau.Focus();
            }
        }

        private void txtNoiLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtDiaChiDonVi.Focus();
            }
        }

        private void txtDiaChiDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtNguoiLayMau.Focus();
            }
        }

        private void txtNguoiLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtSDTNguoiLayMau.Focus();
            }
        }

        private void txtSDTNguoiLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtNgayLayMau.Focus();
            }
        }

        private void txtNgayLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtGioLayMau.Focus();
            }
        }

        private void txtGioLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        

        private void radioGroupViTriLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtTenBenhNhan.Focus();
            }
        }

        private void txtTenBenhNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtGioiTinh.Focus();
            }
        }

        private void txtGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtNamSinhBenhNhan.Focus();
            }
        }

        private void txtNamSinhBenhNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtGioSinhBenhNhan.Focus();
            }
        }

        private void txtGioSinhBenhNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtCanNang.Focus();
            }
        }
        private void TimTrongGridView(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {

                this.GCDanhSachTiepNhan.DataSource = null;
                this.GCDanhSachTiepNhan.DataSource = this.lstTiepNhan;

                this.GCDanhSachDaTracking.DataSource = null;
                this.GCDanhSachDaTracking.DataSource = this.lstDaDanhGia;
            }
            else
            {

                if (this.lstTiepNhan.Count > 0)
                {
                    this.lstTiepNhanSearch.Clear();
                    this.lstTiepNhanSearch = this.lstTiepNhan.Where(p => p.MaPhieu.Contains(keyword)).ToList();
                    this.GCDanhSachTiepNhan.DataSource = null;
                    this.GCDanhSachTiepNhan.DataSource = this.lstTiepNhanSearch;
                    this.GVDanhSachTiepNhan.ExpandAllGroups();
                }

                if (this.lstDaDanhGia.Count > 0)
                {
                    this.lstDaDanhGiaSearch.Clear();
                    this.lstDaDanhGiaSearch = this.lstDaDanhGia.Where(p => p.MaPhieu.Contains(keyword)).ToList();
                    this.GCDanhSachDaTracking.DataSource = null;
                    this.GCDanhSachDaTracking.DataSource = this.lstDaDanhGiaSearch;
                    this.GVDanhSachDaTracking.ExpandAllGroups();
                }
            }
            
        }

        private void txtCanNang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtTuanTuoi.Focus();
            }
        }

        private void txtTuanTuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.lookUpDanToc.Focus();
            }
        }

        private void lookUpDanToc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtNoiSinh.Focus();
            }
        }

        private void txtNoiSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.radioGroupTinhTrangTre.Focus();
            }
        }

        private void radioGroupTinhTrangTre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.RadioCheDoDD.Focus();
            }
        }

        private void txtNgayTruyenMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.txtSoLuongTruyenMau.Focus();
            }
        }

        private void txtSoLuongTruyenMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.SelectNextControl((Control)this.RadioCheDoDD, true, true, true, true);
            }
        }

        private void RadioCheDoDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            var kchar = e.KeyChar.ToString();
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                if (this.radioGroupGoiXN.Controls.Count > 0)
                    this.radioGroupGoiXN.Focus();
                else
                    this.radioDanhGia.Focus();
            }
        }

        private void radioGroupGoiXN_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                if (this.checkedListBoxXN.Enabled)
                    this.checkedListBoxXN.Focus();
                else
                    this.radioDanhGia.Focus();
            }
        }

        private void checkedListBoxXN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.radioDanhGia.Focus();
            }
        }

        private void radioDanhGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.checkedListBoxLydoKhongDat.Focus();
            }
        }

        private void checkedListBoxLydoKhongDat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                this.btnDuyet.Focus();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.btnDuyet.Enabled = false;
        }

        private void GVDanhSachDaTracking_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (this.GVDanhSachDaTracking.RowCount > 0)
                {
                    if (this.GVDanhSachDaTracking.GetFocusedRow() != null)
                    {
                        string maPhieu = this.GVDanhSachDaTracking.GetRowCellValue(this.GVDanhSachDaTracking.FocusedRowHandle, this.col_maPhieu_GCDaTracking).ToString();
                        string maDonVi = this.GVDanhSachDaTracking.GetRowCellValue(this.GVDanhSachDaTracking.FocusedRowHandle, this.col_maDonVi_GCDaTracking).ToString();
                        string maChiDinh = this.GVDanhSachDaTracking.GetRowCellValue(this.GVDanhSachDaTracking.FocusedRowHandle, this.col_MaChiDinh).ToString();
                        DateTime _ngayTiepNhan = DateTime.Now;
                        string maTiepNhan = string.Empty;
                        try
                        {
                            _ngayTiepNhan = GVDanhSachTiepNhan.GetRowCellValue(this.GVDanhSachTiepNhan.FocusedRowHandle, this.col_NgayTiepNhan) == null ? DateTime.Now : (DateTime)GVDanhSachTiepNhan.GetRowCellValue(this.GVDanhSachTiepNhan.FocusedRowHandle, this.col_NgayTiepNhan);
                            maTiepNhan = this.GVDanhSachDaTracking.GetRowCellValue(this.GVDanhSachDaTracking.FocusedRowHandle, this.col_maTiepNhan).ToString();
                        }
                        catch { };
                        this.ngayTiepNhan = _ngayTiepNhan;
                        this.txtNgayNhanMau.EditValue = _ngayTiepNhan;
                        this.HienThiThongTinChiDinh(maPhieu, maDonVi, maTiepNhan,maChiDinh, false);
                        this.btnDuyet.Text = "Lưu";
                      //  this.btnDuyet.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lấy thông tin tiếp nhận của phiếu! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

      

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                TextEdit tb = sender as TextEdit;

                this.TimTrongGridView(tb.Text.Trim());
            }
            catch (Exception ex) { XtraMessageBox.Show("Lỗi khi thực hiện tìm kiếm! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    TextEdit tb = sender as TextEdit;
                    if (this.xtraTabControl1.SelectedTabPageIndex==0)
                    {
                        if (GVDanhSachTiepNhan.RowCount > 0)
                        {
                            int rowhandle = 0;
                            string madonvi = this.GVDanhSachTiepNhan.GetRowCellValue(rowhandle, this.col_DonViCoSo_GCTiepNhan).ToString();
                            string maPhieu = this.GVDanhSachTiepNhan.GetRowCellValue(rowhandle, this.col_MaPhieu_GCTiepNhan).ToString();
                            string maTiepNhan = this.GVDanhSachTiepNhan.GetRowCellValue(rowhandle, this.col_maTiepNhan).ToString();
                            DateTime _ngayhethong = BioNet_Bus.GetDateTime();
                            DateTime _ngayTiepNhan = _ngayhethong;
                            try
                            {
                                _ngayTiepNhan = GVDanhSachTiepNhan.GetRowCellValue(rowhandle, this.col_NgayTiepNhan) == null ? _ngayhethong : (DateTime)GVDanhSachTiepNhan.GetRowCellValue(rowhandle, this.col_NgayTiepNhan);
                            }
                            catch { };
                            this.ngayTiepNhan = _ngayTiepNhan;
                            this.txtNgayNhanMau.EditValue = _ngayTiepNhan;
                            if (!string.IsNullOrEmpty(maPhieu) && tb.Text.Trim().Equals(maPhieu))
                                this.HienThiThongTinPhieu(maPhieu, madonvi, maTiepNhan, true);
                            else
                            {
                                XtraMessageBox.Show("Không tìm thấy phiếu bạn vừa nhập!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        if (GVDanhSachDaTracking.RowCount > 0)
                        {
                            int rowhandle = 0;
                            string madonvi = this.GVDanhSachDaTracking.GetRowCellValue(rowhandle, this.col_maDonVi_GCDaTracking).ToString();
                            string maPhieu = this.GVDanhSachDaTracking.GetRowCellValue(rowhandle, this.col_maPhieu_GCDaTracking).ToString();
                            string maTiepNhan = this.GVDanhSachDaTracking.GetRowCellValue(rowhandle, this.col_maTiepNhan_GCDaTracking).ToString();
                            DateTime _ngayhethong = BioNet_Bus.GetDateTime();
                            DateTime _ngayTiepNhan = _ngayhethong;
                            try
                            {
                                _ngayTiepNhan = GVDanhSachDaTracking.GetRowCellValue(rowhandle, this.col_NgayTiepNhan) == null ? _ngayhethong : (DateTime)GVDanhSachDaTracking.GetRowCellValue(rowhandle, this.col_NgayTiepNhan);
                            }
                            catch { };
                            this.ngayTiepNhan = _ngayTiepNhan;
                            this.txtNgayNhanMau.EditValue = _ngayTiepNhan;
                            if (!string.IsNullOrEmpty(maPhieu) && tb.Text.Trim().Equals(maPhieu))
                                this.HienThiThongTinPhieu(maPhieu, madonvi, maTiepNhan, false);
                            else
                            {
                                XtraMessageBox.Show("Không tìm thấy phiếu bạn vừa nhập!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                    }
                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi thực hiện tìm kiếm! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.TimTrongGridView(this.txtSearch.Text.Trim());
        }

        private void checkedListBoxLydoKhongDat_DataSourceChanged(object sender, EventArgs e)
        {
            //var lstDanhGia = BioNet_Bus.GetChiTietDanhGiaMạuKhongDatTrenPhieu(this.txtMaPhieu.Text.Trim(), this.txtMaTiepNhan.Text.Trim());
            //if (lstDanhGia.Count > 0)
            //{
            //    var lstcheckbox = sender as CheckedListBoxControl;
            //    if (lstcheckbox.Items.Count > 0)
            //    {
            //       foreach(CheckedListBoxItem item in lstcheckbox.Items)
            //        {
            //            foreach (var kd in lstDanhGia)
            //            {
            //                if (item.Value.ToString() == kd.IDDanhGiaChatLuongMau)
            //                    item.CheckState = CheckState.Checked;
            //                else item.CheckState = CheckState.Unchecked;
            //                //lstcheckbox.SetItemCheckState(i, CheckState.Checked);
            //                //else lstcheckbox.SetItemCheckState(i, CheckState.Unchecked);
            //            }
            //        }

            //       for(int i = 0; i < this.checkedListBoxLydoKhongDat.ItemCount; i ++)
            //        {
            //            foreach (var kd in lstDanhGia)
            //            {
            //                if (this.checkedListBoxLydoKhongDat.Items[i].ToString() == kd.IDDanhGiaChatLuongMau)
            //                    this.checkedListBoxLydoKhongDat.SetItemChecked(i, true);
            //                else this.checkedListBoxLydoKhongDat.SetItemChecked(i, false);
            //                //lstcheckbox.SetItemCheckState(i, CheckState.Checked);
            //                //else lstcheckbox.SetItemCheckState(i, CheckState.Unchecked);
            //            }
            //        }
            //    }
            //}
        }
        private void KiemtraChitietDanhGiaCuaPhieu()
        {
            if (this.checkedListBoxLydoKhongDat.Items.Count > 0)
            {
                var lstDanhGia = BioNet_Bus.GetChiTietDanhGiaMạuKhongDatTrenPhieu(this.txtMaPhieu.Text.Trim(), this.txtMaTiepNhan.Text.Trim());
                if (lstDanhGia.Count > 0)
                {
                        foreach (CheckedListBoxItem item in this.checkedListBoxLydoKhongDat.Items)
                        {
                            foreach (var kd in lstDanhGia)
                            {
                                if (item.Value.ToString() == kd.IDDanhGiaChatLuongMau)
                                    item.CheckState = CheckState.Checked;
                              //  else item.CheckState = CheckState.Unchecked;
                                //lstcheckbox.SetItemCheckState(i, CheckState.Checked);
                                //else lstcheckbox.SetItemCheckState(i, CheckState.Unchecked);
                            }
                        }
                    
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {try
            {
            var trangthai = BioNet_Bus.KiemTraTrangThaiPhieu(this.txtMaPhieu.Text.Trim(), this.lookupDonVi.EditValue.ToString());
                if(trangthai<=0)
                {
                    XtraMessageBox.Show("Phiếu đã nằm ngoài quy trình nên không thể sửa! \r\n Vui lòng thử lại hoặc liên hệ với quản trị viên!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(trangthai==4)
                {
                    XtraMessageBox.Show("Mẫu đã trả kết quả nên không thể sửa", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.ReadOnly(false);
                this.btnDuyet.Enabled = true;
                this.btnDuyet.Text = "Lưu";
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi kiểm tra điều kiện được sửa. \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void radioGroupGoiXN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RadioGroup rd = sender as RadioGroup;
                string goi = rd.EditValue.ToString();
                if (goi.Equals("DVGXN0001"))
                {
                    if (string.IsNullOrEmpty(this.txtMaPhieuLan1.Text.Trim()) && this.txtMaPhieuLan1.ReadOnly == false)
                    {
                        var tt = BioNet_Bus.GetThongTinTrungTam();
                        if (tt != null)
                        {
                            if (!tt.isChoThuLaiMauLan2 ?? false)
                            {
                                XtraMessageBox.Show("Cấu hình trung tâm không cho phép thu mẫu lại! \r\n Vui lòng thử lại hoặc liên hệ với quản trị viên!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                rd.EditValue = rd.OldEditValue;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Cấu hình trung tâm không cho phép thu mẫu lại! \r\n Vui lòng thử lại hoặc liên hệ với quản trị viên!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            rd.EditValue = rd.OldEditValue;
                        }

                    }
                }
            }
            catch { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                var trangthai = BioNet_Bus.KiemTraTrangThaiPhieu(this.txtMaPhieu.Text.Trim(), this.lookupDonVi.EditValue.ToString());
                if (trangthai <= 0)
                {
                    XtraMessageBox.Show("Phiếu đã nằm ngoài quy trình nên không thể hủy! \r\n Vui lòng thử lại hoặc liên hệ với quản trị viên!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (trangthai == 4)
                {
                    XtraMessageBox.Show("Mẫu đã trả kết quả nên không thể hủy", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (trangthai == 6)
                {
                    XtraMessageBox.Show("Mẫu đã trả kết thực hiện thu mẫu lại nên không thể hủy", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (trangthai == 5)
                {
                    if (BioNet_Bus.KiemTraMauDaLamLaiXetNghiemLan2DaVaoQuyTrinhXetNghieHayChua(this.txtMaPhieu.Text.Trim(), this.lookupDonVi.EditValue.ToString()))
                        {
                        XtraMessageBox.Show("Mẫu đã vào quy trình xét nghiệm lại lần 2 nên không thể hủy", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                   
                }
                if ((XtraMessageBox.Show("Bạn có chắn chắn muốn hủy phiếu này không?", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    var res = BioNet_Bus.HuyChiDinhDichVu(this.txtMaChiDinh.Text.Trim(), this.MaNhanVienDangNhap, "Huy", this.txtMaPhieu.Text.Trim(), this.txtMaTiepNhan.Text.Trim());
                    if (res.Result)
                    {
                        XtraMessageBox.Show("Hủy chỉ định thành công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        this.LoadGCDotChiDinh();
                        this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
                        this.LoadDanhSachDaDanhGiaTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());
                        this.LoadNew();
                        this.LoadGCChiDinhDichVu();
                        this.btnDuyet.Enabled = false;
                    }
                    else XtraMessageBox.Show(res.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch ( Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi hủy : "+ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void GVDanhSachTiepNhan_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "MaPhieu")
                e.Cancel = true;
        }

        private void GVDanhSachTiepNhan_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView viewer = sender as GridView;
            int row = e.ControllerRow;
            int[] lstChecked = viewer.GetSelectedRows();
        }

        private void GVDanhSachTiepNhan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
                if (this.GVDanhSachTiepNhan.RowCount > 0)
                {
                    if (this.GVDanhSachTiepNhan.GetFocusedRow() != null)
                    {
                        if (hitInfo.InRowCell)
                        {
                            string maPhieu = this.GVDanhSachTiepNhan.GetRowCellValue(this.GVDanhSachTiepNhan.FocusedRowHandle, this.col_MaPhieu_GCTiepNhan).ToString();
                            string maDonVi = this.GVDanhSachTiepNhan.GetRowCellValue(this.GVDanhSachTiepNhan.FocusedRowHandle, this.col_DonViCoSo_GCTiepNhan).ToString();
                            DateTime _ngayTiepNhan = DateTime.Now;
                            string maTiepNhan = string.Empty;
                            try
                            {
                                maTiepNhan = this.GVDanhSachTiepNhan.GetRowCellValue(this.GVDanhSachTiepNhan.FocusedRowHandle, this.col_maTiepNhan).ToString();
                                _ngayTiepNhan = GVDanhSachTiepNhan.GetRowCellValue(this.GVDanhSachTiepNhan.FocusedRowHandle, this.col_NgayTiepNhan) == null ? DateTime.Now : (DateTime)GVDanhSachTiepNhan.GetRowCellValue(this.GVDanhSachTiepNhan.FocusedRowHandle, this.col_NgayTiepNhan);

                            }
                            catch { };
                            this.ngayTiepNhan = _ngayTiepNhan;
                            this.txtNgayNhanMau.EditValue = _ngayTiepNhan;
                            this.HienThiThongTinPhieu(maPhieu, maDonVi, maTiepNhan, true);
                            this.btnDuyet.Enabled = true;
                            this.btnDuyet.Text = "Duyệt";
                            // this.SetCheckedListbox("CL");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lấy thông tin tiếp nhận của phiếu! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void radioGroupGoiXN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            base.OnPreviewKeyDown(e);
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.checkedListBoxXN.Enabled)
                    this.checkedListBoxXN.Focus();
                else
                {
                    this.radioDanhGia.Focus();
                    this.SelectNextControl((Control)this.radioDanhGia, true, true, true, true);
                }
            }
        }

        private void radioGroupTinhTrangTre_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            base.OnPreviewKeyDown(e);
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (this.radioGroupTinhTrangTre.SelectedIndex == 4)
                {
                    this.txtNgayTruyenMau.Focus();
                    this.SelectNextControl((Control)this.txtNgayTruyenMau, true, true, true, true);
                }
                else
                {
                    this.RadioCheDoDD.Focus();
                    this.SelectNextControl((Control)this.RadioCheDoDD, true, true, true, true);
                }
            }
        }

        private void txtGioLayMau_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtTenBenhNhan.Focus();
            }
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchLookUpChiCuc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit sear = sender as SearchLookUpEdit;
                var value = sear.EditValue.ToString();
                this.searchLookUpDonViCoSo.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DonVi(value.ToString());
                this.searchLookUpDonViCoSo.EditValue = "all";
            }
            catch { }
        }








        //private void SetCheckedListbox(string id)
        //{
        //    for (int i = 0; i < this.checkedListBoxLydoKhongDat.Items.Count; i++)
        //    {
        //        if (this.checkedListBoxLydoKhongDat.Items[i].Value.ToString().Equals(id))
        //            this.checkedListBoxLydoKhongDat.SetItemChecked(i, true);
        //    }
        //}

    }
}