using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetBLL;
using BioNetModel.Data;
using BioNetModel;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
//using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Base;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmDanhMaXetNghiem : DevExpress.XtraEditors.XtraForm
    {
        public FrmDanhMaXetNghiem()
        {
            InitializeComponent();
        }
        private List<string> lstCDCanDanhMa = new List<string>();
        private List<PSChiDinhDichVu> lstCho = new List<PSChiDinhDichVu>();
        private List<PSChiDinhDichVu> lstCanDanhMa = new List<PSChiDinhDichVu>();
        private List<PSChiDinhDichVu> lstCanDanhMaFull = new List<PSChiDinhDichVu>();
        private List<PsDanhSachCapMa> lstCapMaTheoDonVi = new List<PsDanhSachCapMa>();
        private List<string> lstDonViCanCapMa = new List<string>();
        private List<PSXN_KetQua> lstDaDanhMaXN = new List<PSXN_KetQua>();
        private List<PSDanhMucDonViCoSo> lstDonVi = new List<PSDanhMucDonViCoSo>();
        private List<PSDanhMucDonViCoSo> lstDonVireponsitory = new List<PSDanhMucDonViCoSo>();
       
        private long maKT;
        private string maGoiXNFocusHandle;
        private string maPhieuFocusHandle;
        private string maDonviFocusHandle;
        private string maChiDinhFocusHandle;
        private string maTiepNhanFocusHandle;
        private DateTime ngayChiDinhFocusHandle;
        private DateTime ngayTiepNhanFocusHandle;
        private void FrmDanhMaXetNghiem_Load(object sender, EventArgs e)
        {
            this.LoadFrm();
        }
        private List<PSDanhMucGoiDichVuChung> lstgoiXN = new List<PSDanhMucGoiDichVuChung>();
        private void LoadGoiDichVuXetNGhiem()
        {
            try
            {
                this.lstgoiXN = BioNet_Bus.GetDanhsachGoiDichVuChung();
                this.LookUpGoiXN.DataSource = this.lstgoiXN;
            }
            catch { }
        }
        private void LoadFrm()
        {
            this.LoadLookupDonVi();
            this.LoadGoiDichVuXetNGhiem();
            this.searchLookUpDonViCoSo.EditValue = "ALL";
            this.txtTuNgay_ChuaKQ.EditValue = DateTime.Now;
            this.txtDenNgay_ChuaKQ.EditValue = DateTime.Now;
            this.LoadListDSCho();
            this.LoadGCDanhSachCho();
        }
        private void LoadListDonViSearchLookup()
        {
            this.lstDonVi.Clear();
            this.lstDonVi = BioNet_Bus.GetDanhSachDonVi_Searchlookup();
            this.searchLookUpDonViCoSo.Properties.DataSource = null;
            this.searchLookUpDonViCoSo.Properties.DataSource = this.lstDonVi;
        }
        private void LoadGCDanhSachDaDanhMa()
        {
            this.LookUpMaXetNghiem.DataSource = null;
            this.LookUpMaXetNghiem.DataSource = this.lstDaDanhMaXN;
            //this.SearchLookUpMaXetNghiem.DataSource = null;
            //this.SearchLookUpMaXetNghiem.DataSource = this.lstDaDanhMaXN;
            this.GCDanhSachDaCapMa.DataSource = null;
            this.GCDanhSachDaCapMa.DataSource = this.lstDaDanhMaXN; 
        }
        private void LoadListDSCho()
        {
            if (this.KiemTraDieuKienLamMoiDanhSach())
            {
                this.lstCho.Clear();
                this.lstCho = BioNet_Bus.GetDanhSachChiDinhChuaDuocCapMa(this.searchLookUpDonViCoSo.EditValue.ToString(), (DateTime)this.txtTuNgay_ChuaKQ.EditValue, (DateTime)this.txtDenNgay_ChuaKQ.EditValue);
                this.LoadGCDanhSachCho();
            }
            else
            {
                XtraMessageBox.Show("Đưa danh sách đã cấp mã vào phòng xét nghiệm hoặc hủy danh sách đã cấp mã và làm lại từ đầu", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool KiemTraDieuKienLamMoiDanhSach()
        {
            if (this.GVDanhSachDaCapMa.RowCount > 0)
                return false; // nếu danh sách đã cấp mã mà chưa đưa vào xn thì ko đc làm mới ds
            else return true;
        }
        private void LoadLookupDonVi()
        {
            this.LoadListDonViSearchLookup();
            this.LoadRepositoryLookupDonViCoSo();
            this.repositoryItemLookUpDonVi_GCDaCapMau.DataSource = this.lstDonVi;
            this.repositoryItemLookUpDonVu_GCDanhSachCho.DataSource = this.lstDonVi;
        }
        private void LoadGCDanhSachCho()
        {
            this.GCDanhSachCho.DataSource = null;
            this.GCDanhSachCho.DataSource = this.lstCho;
           // this.GVDanhSachCho.ExpandAllGroups();
        }
        private void LoadRepositoryLookupDonViCoSo()
        {
            try
            {
                this.lstDonVireponsitory = BioNet_Bus.GetDanhSachDonViCoSo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lấy danh sách đơn vị cơ sở \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CapMa()
        {
            foreach( var cd in this.lstCapMaTheoDonVi)
            {
                long maDB = cd.soBatDau;
                foreach(var row in this.lstCanDanhMaFull)
                {
                    if(row.MaDonVi == cd.maDonVi)
                    {if (row.MaChiDinh.Substring(0,2).Equals("XN"))
                        {
                            PSXN_KetQua ds = new PSXN_KetQua();
                            ds.MaChiDinh = row.MaChiDinh;
                            ds.MaDonVi = cd.maDonVi;
                            ds.MaPhieu = row.MaPhieu;
                            ds.NgayLamXetNghiem = DateTime.Now.Date;
                            ds.MaTiepNhan = row.MaTiepNhan;
                            ds.NgayChiDinh = row.NgayChiDinhLamViec;
                            ds.NgayTiepNhan = row.NgayTiepNhan;
                            ds.MaXetNghiem = BioNet_Bus.GetMaXN(row.MaTiepNhan)+"_L2";
                            ds.MaGoiXN = row.IDGoiDichVu;
                            this.lstDaDanhMaXN.Add(ds);
                        }
                        else
                        {
                            PSXN_KetQua ds = new PSXN_KetQua();
                            ds.MaChiDinh = row.MaChiDinh;
                            ds.MaDonVi = cd.maDonVi;
                            ds.MaPhieu = row.MaPhieu;
                            ds.NgayLamXetNghiem = DateTime.Now.Date;
                            ds.MaTiepNhan = row.MaTiepNhan;
                            ds.NgayChiDinh = row.NgayChiDinhLamViec;
                            ds.NgayTiepNhan = row.NgayTiepNhan;
                            ds.MaXetNghiem = maDB.ToString();
                            ds.MaGoiXN = row.IDGoiDichVu; ;
                            this.lstDaDanhMaXN.Add(ds);
                            maDB += 1;
                           
                        }
                    }
                    else
                    {
                        if (row.MaChiDinh.Substring(0, 2).Equals("XN"))
                        {
                            var phieutontai = this.lstDaDanhMaXN.FirstOrDefault(p => p.MaChiDinh == row.MaChiDinh);
                            if (phieutontai == null)
                            {
                                PSXN_KetQua ds = new PSXN_KetQua();
                                ds.MaChiDinh = row.MaChiDinh;
                                ds.MaDonVi = row.MaDonVi;
                                ds.MaPhieu = row.MaPhieu;
                                ds.NgayLamXetNghiem = DateTime.Now.Date;
                                ds.MaTiepNhan = row.MaTiepNhan;
                                ds.NgayChiDinh = row.NgayChiDinhLamViec;
                                ds.NgayTiepNhan = row.NgayTiepNhan;
                                ds.MaXetNghiem = BioNet_Bus.GetMaXN(row.MaTiepNhan) + "_L2";
                                ds.MaGoiXN = row.IDGoiDichVu; ;
                                this.lstDaDanhMaXN.Add(ds);
                            }
                        }
                    }
                }
                foreach( var phieu in lstDaDanhMaXN)
                {
                    var result = this.lstCho.FirstOrDefault(p => p.MaPhieu == phieu.MaPhieu && p.MaTiepNhan == phieu.MaTiepNhan);
                    if(result!=null)
                    {
                        try
                        {
                            this.lstCho.Remove(result);
                        }
                        catch(Exception ex) {
                            XtraMessageBox.Show("Lỗi khi cập nhật lại danh sách chờ! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                     }
            }
            this.LoadGCDanhSachCho();
            this.LoadGCDanhSachDaDanhMa();
        }
        private void LayDanhSachCacPhieuCanCapMa()
        {
            this.lstCanDanhMa.Clear();
            this.lstDonViCanCapMa.Clear();
            this.lstCanDanhMaFull.Clear();
            int[] lstChecked = this.GVDanhSachCho.GetSelectedRows();
            foreach( var index in lstChecked)
            {
                if( index >=0)
                {
                    string maChiDinh = this.GVDanhSachCho.GetRowCellValue(index, this.col_MaChiDinh_GCDanhSachCho).ToString();
                    string maGoiXN = this.GVDanhSachCho.GetRowCellValue(index, this.col_MaGoiXN).ToString();
                    var cd = BioNet_Bus.GetThongTinhChiDinh(maChiDinh);
                    if (cd != null) {
                        this.lstCanDanhMaFull.Add(cd);
                        if (!maChiDinh.Substring(0, 2).Equals("XN"))
                        {
                            this.lstCanDanhMa.Add(cd);
                        }
                    }
                }
            }
            if(this.lstCanDanhMa.Count>0)
            {
               var lst = this.lstCanDanhMa.GroupBy(p => p.MaDonVi).Select(r=>new {maDonVi = r.Key, soLuong = r.Count(),soBatDau =0 }).ToList();
                this.lstCapMaTheoDonVi.Clear();
                int bd = 1;
                try
                {
                    bd = int.Parse(BioNet_Bus.GetMaXNTrongBangGhi())+1;
                }
                catch
                {
                }
                foreach(var item in lst)
                {
                    PsDanhSachCapMa cm = new PsDanhSachCapMa();
                    cm.maDonVi = item.maDonVi;
                    cm.soLuong = item.soLuong;
                    cm.soBatDau = bd;
                    cm.soKetThuc = bd + item.soLuong-1;
                    bd += item.soLuong;
                    this.lstDonViCanCapMa.Add(item.maDonVi);
                    this.lstCapMaTheoDonVi.Add(cm);
                }
                this.maKT = bd-1;
            }
            //for (int i = 0; i < this.GVDanhSachCho.RowCount; i++)
            //{
            //        try
            //        {
            //           // if(this.GVDanhSachCho.GetRowCellValue(i))
            //        }
            //        catch { }
            //    }
        }
        private void LuuDanhSachDaCapMa()
        {
            bool ok = true;
            foreach (var item in this.lstDaDanhMaXN)
            {
                var res = BioNet_Bus.InsertMauDaDanhMaXN(item);
                if (!res.Result)
                {
                    ok = false;
                    XtraMessageBox.Show("Lỗi khi lưu phiếu :" + item.MaPhieu.ToString() +"\r\n Lỗi chi tiết :"+res.StringError, "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            if (ok)
            {

                BioNet_Bus.UpdateMaXNVaoBangGhi(this.maKT.ToString());
                XtraMessageBox.Show("Lưu danh sách phiếu thành công", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (var phieu in this.lstDaDanhMaXN)
                {
                    var result = this.lstCho.FirstOrDefault(p => p.MaPhieu == phieu.MaPhieu && p.MaTiepNhan == phieu.MaTiepNhan);
                    if (result != null)
                    {
                        try
                        {
                            this.lstCho.Remove(result);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Lỗi khi lấy cập nhật lại danh sách chờ! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                this.lstDaDanhMaXN.Clear();
                this.lstCanDanhMa.Clear();
                this.LoadGCDanhSachCho();
                this.LoadGCDanhSachDaDanhMa();
            }
        }
        private void btnCapToanBo_Click(object sender, EventArgs e)
        {
            if(this.GVDanhSachDaCapMa.RowCount>0)
            this.LuuDanhSachDaCapMa();
            else
            {
                XtraMessageBox.Show("Vui lòng chọn tính năng cấp mã tự động trước khi đưa mẫu vào phòng xét nghiệm!", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.KiemTraDieuKienLamMoiDanhSach())
            {
                if (this.GVDanhSachCho.SelectedRowsCount > 0)
                {
                    this.LayDanhSachCacPhieuCanCapMa();
                    var tttrungtam = BioNet_Bus.GetThongTinTrungTam();
                    if (tttrungtam.isCapMaXNTheoMaPhieu ?? true)
                    {
                        this.CapMaXNTheoMaPhieu();
                    }
                    else
                    {
                        // DiaglogFrm.FrmDiaglogCapMaTuDong frm = new DiaglogFrm.FrmDiaglogCapMaTuDong();
                        DiaglogFrm.FrmDiaglogCapMaXNTuDong frm = new DiaglogFrm.FrmDiaglogCapMaXNTuDong();
                        frm.lstCapMaTheoDonVi = this.lstCapMaTheoDonVi;
                        frm.lstDonViCanCapMa = this.lstDonViCanCapMa;
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            this.lstCapMaTheoDonVi = frm.lstCapMaTheoDonVi;
                            this.CapMa();
                        }
                        else { this.lstCapMaTheoDonVi.Clear();
                            this.lstCanDanhMa.Clear();
                        }
                    }
                }

            }
            else
            {
                XtraMessageBox.Show("Đưa danh sách đã cấp mã vào phòng xét nghiệm hoặc hủy danh sách đã cấp mã và làm lại từ đầu", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void CapMaXNTheoMaPhieu()
        {
            if (this.lstCanDanhMaFull.Count > 0)
            {
                foreach (var mau in this.lstCanDanhMaFull)
                {
                    if (mau.MaChiDinh.Substring(0, 2).Equals("XN"))
                    {
                        PSXN_KetQua ds = new PSXN_KetQua();
                        ds.MaChiDinh = mau.MaChiDinh;
                        ds.MaDonVi = mau.MaDonVi;
                        ds.MaPhieu = mau.MaPhieu;
                        ds.NgayLamXetNghiem = DateTime.Now.Date;
                        ds.MaTiepNhan = mau.MaTiepNhan;
                        ds.NgayChiDinh = mau.NgayChiDinhLamViec;
                        ds.NgayTiepNhan = mau.NgayTiepNhan;
                        ds.MaGoiXN = mau.IDGoiDichVu;
                        ds.MaXetNghiem = string.IsNullOrEmpty(BioNet_Bus.GetMaXN(mau.MaTiepNhan)) == true? mau.MaPhieu + "_L2": BioNet_Bus.GetMaXN(mau.MaTiepNhan)+"_L2"; 
                        this.lstDaDanhMaXN.Add(ds);
                    }
                    else
                    {
                        PSXN_KetQua ds = new PSXN_KetQua();
                        ds.MaChiDinh = mau.MaChiDinh;
                        ds.MaDonVi = mau.MaDonVi;
                        ds.MaPhieu = mau.MaPhieu;
                        ds.NgayLamXetNghiem = DateTime.Now.Date;
                        ds.MaTiepNhan = mau.MaTiepNhan;
                        ds.NgayChiDinh = mau.NgayChiDinhLamViec;
                        ds.NgayTiepNhan = mau.NgayTiepNhan;
                        ds.MaXetNghiem = mau.MaPhieu;
                        ds.MaGoiXN = mau.IDGoiDichVu;
                        this.lstDaDanhMaXN.Add(ds);
                    }
                }
                foreach (var phieu in lstDaDanhMaXN)
                {
                    var result = this.lstCho.FirstOrDefault(p => p.MaPhieu == phieu.MaPhieu && p.MaTiepNhan == phieu.MaTiepNhan);
                    if (result != null)
                    {
                        try
                        {
                            this.lstCho.Remove(result);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Lỗi khi cập nhật lại danh sách chờ! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                this.LoadGCDanhSachCho();
                this.LoadGCDanhSachDaDanhMa();
            }
        }
        private void GVDanhSachCho_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string MaCD = View.GetRowCellValue(e.RowHandle, this.col_MaChiDinh_GCDanhSachCho) == null ? string.Empty : View.GetRowCellValue(e.RowHandle, this.col_MaChiDinh_GCDanhSachCho).ToString();
                    if (!string.IsNullOrEmpty(MaCD))
                    {
                        if (MaCD.Substring(0, 2).Equals("XN"))
                        {
                            e.Appearance.BackColor = Color.Salmon;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.Aqua;
                            e.Appearance.BackColor2 = Color.AliceBlue;
                        }
                    }
                }
            }
            catch { }
        }
        private void GVDanhSachDaCapMa_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string MaCD = View.GetRowCellValue(e.RowHandle, this.col_MaChiDinh_GCDaCapMau) == null ? string.Empty : View.GetRowCellValue(e.RowHandle, this.col_MaChiDinh_GCDaCapMau).ToString();
                    if (!string.IsNullOrEmpty(MaCD))
                    {
                        if (MaCD.Substring(0, 2).Equals("XN"))
                        {
                            e.Appearance.BackColor = Color.Salmon;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.Aqua;
                            e.Appearance.BackColor2 = Color.AliceBlue;
                        }
                    }
                }
            }
            catch { }
        }
        private void searchLookUpDonViCoSo_EditValueChanged(object sender, EventArgs e)
        {

            if (this.txtDenNgay_ChuaKQ.EditValue != null && this.txtTuNgay_ChuaKQ.EditValue != null)
                    this.LoadListDSCho();
                
                
        }
        private void txtTuNgay_ChuaKQ_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtDenNgay_ChuaKQ.EditValue != null)
                this.LoadListDSCho();
        }
        private void txtDenNgay_ChuaKQ_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtTuNgay_ChuaKQ.EditValue != null)
                this.LoadListDSCho();
        }
        private void CapMaXetNghiemCho1PhieuTuDong()
        {
            if (this.KiemTraDieuKienLamMoiDanhSach())
            {
                if (this.lstCanDanhMa.Count <= 0 && this.GVDanhSachDaCapMa.RowCount <= 0)
                {
                    int bd = 1;
                    try
                    {
                        bd = int.Parse(BioNet_Bus.GetMaXNTrongBangGhi()) + 1;
                    }
                    catch { }
                    this.lstDaDanhMaXN.Clear();
                    if (this.maChiDinhFocusHandle.Substring(0, 2).Equals("XN"))
                    {
                        PSXN_KetQua ds = new PSXN_KetQua();
                        ds.MaChiDinh = this.maChiDinhFocusHandle;
                        ds.MaDonVi = this.maDonviFocusHandle;
                        ds.MaPhieu = this.maPhieuFocusHandle;
                        ds.NgayTiepNhan = this.ngayTiepNhanFocusHandle;
                        ds.NgayChiDinh = this.ngayChiDinhFocusHandle;
                        ds.NgayLamXetNghiem = DateTime.Now.Date;
                        ds.MaTiepNhan = this.maTiepNhanFocusHandle;
                        ds.MaGoiXN = this.maGoiXNFocusHandle;
                        ds.MaXetNghiem = BioNet_Bus.GetMaXN(this.maTiepNhanFocusHandle) + "_L2";
                        this.lstDaDanhMaXN.Add(ds);
                        this.maKT = bd - 1;
                        this.LuuDanhSachDaCapMa();

                    }
                    else
                    {

                        if (bd < 10)
                        {
                            XtraMessageBox.Show("Lỗi khi cấp mã xét nghiệm: không lấy được mã phiếu tự động. Vui lòng thử lại.", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            var tttrungtam = BioNet_Bus.GetThongTinTrungTam();
                            if (tttrungtam != null)
                            {
                                if (!tttrungtam.isCapMaXNTheoMaPhieu ?? true) //chọn cấp mã tự động
                                {
                                    PSXN_KetQua ds = new PSXN_KetQua();
                                    ds.MaChiDinh = this.maChiDinhFocusHandle;
                                    ds.MaDonVi = this.maDonviFocusHandle;
                                    ds.MaPhieu = this.maPhieuFocusHandle;
                                    ds.NgayLamXetNghiem = DateTime.Now.Date;
                                    ds.NgayTiepNhan = this.ngayTiepNhanFocusHandle;
                                    ds.NgayChiDinh = this.ngayChiDinhFocusHandle;
                                    ds.MaTiepNhan = this.maTiepNhanFocusHandle;
                                    ds.MaGoiXN = this.maGoiXNFocusHandle;
                                    ds.MaXetNghiem = bd.ToString();
                                    this.lstDaDanhMaXN.Add(ds);
                                    this.maKT = bd;
                                    this.LuuDanhSachDaCapMa();
                                }
                                else //cấp mã xét nghiệm = mã phiếu
                                {
                                    PSXN_KetQua ds = new PSXN_KetQua();
                                    ds.MaChiDinh = this.maChiDinhFocusHandle;
                                    ds.MaDonVi = this.maDonviFocusHandle;
                                    ds.MaPhieu = this.maPhieuFocusHandle;
                                    ds.NgayLamXetNghiem = DateTime.Now.Date;
                                    ds.NgayTiepNhan = this.ngayTiepNhanFocusHandle;
                                    ds.NgayChiDinh = this.ngayChiDinhFocusHandle;
                                    ds.MaTiepNhan = this.maTiepNhanFocusHandle;
                                    ds.MaXetNghiem = this.maPhieuFocusHandle;
                                    ds.MaGoiXN = this.maGoiXNFocusHandle;
                                    this.lstDaDanhMaXN.Add(ds);
                                    this.maKT = bd - 1;
                                    this.LuuDanhSachDaCapMa();
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("Lỗi khi cấp mã xét nghiệm: Không lấy được thông tin cấu hình của trung tâm.\r\n Vui lòng thử lại  hoặc liên hệ với quản trị viên kiểm tra lại thông tin cấu hình!", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Đưa danh sách đã cấp mã vào phòng xét nghiệm hoặc hủy danh sách đã cấp mã và làm lại từ đầu", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void CapMaXetNghiemCho1PhieuTuyChon()
        {
            //DiaglogFrm.FrmDiaglogCapMaTuChon frm = new DiaglogFrm.FrmDiaglogCapMaTuChon();
            //frm.ShowDialog();
            
        }
        private void btnCapMaCho1Phieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           if(XtraMessageBox.Show("Cấp mã xét nghiệm cho một phiếu có 2 lựa chọn. \r\n TỰ ĐỘNG và TÙY CHỌN \r\n Bạn có muốn cấp TỰ ĐỘNG không?", "BioNet - Chương trình sàng lọc sơ sinh!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.CapMaXetNghiemCho1PhieuTuDong();
            }
            else
            {
                this.CapMaXetNghiemCho1PhieuTuyChon();
            }
        }
       
        private void GVDanhSachCho_MouseDown(object sender, MouseEventArgs e)
        {
            string maPhieu = string.Empty;
            string maDonVi = string.Empty;
            string maChiDinh = string.Empty;
            string maTiepNhan = string.Empty;
            string maGoiXN = string.Empty;
            DateTime ngayTiepNhan = DateTime.Now;
            DateTime ngayChiDinh = DateTime.Now;
            GridView view = sender as GridView;
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.InRow &&hitInfo.InRowCell)
            {
                try
                {
                    maGoiXN = view.GetRowCellValue(hitInfo.RowHandle, view.Columns["IDGoiDichVu"]).ToString();
                    maPhieu = view.GetRowCellValue(hitInfo.RowHandle, view.Columns["MaPhieu"]).ToString();
                    
                    maDonVi = view.GetRowCellValue(hitInfo.RowHandle, view.Columns["MaDonVi"]).ToString();
                   
                    maChiDinh = view.GetRowCellValue(hitInfo.RowHandle, view.Columns["MaChiDinh"]).ToString();
                    
                    maTiepNhan =view.GetRowCellValue(hitInfo.RowHandle, view.Columns["MaTiepNhan"]).ToString();
                    try { ngayTiepNhan = (DateTime)(view.GetRowCellValue(hitInfo.RowHandle, view.Columns["NgayTiepNhan"]) ?? DateTime.Now); } catch { ngayTiepNhan = DateTime.Now; }
                    ngayChiDinh = (DateTime)(view.GetRowCellValue(hitInfo.RowHandle, view.Columns["NgayChiDinh"]) ?? DateTime.Now);
                }
                catch { ngayChiDinh = DateTime.Now; }
            }
                this.maGoiXNFocusHandle = maGoiXN;
                this.maPhieuFocusHandle = maPhieu;
                this.maDonviFocusHandle = maDonVi;
                this.maChiDinhFocusHandle = maChiDinh;
                this.maTiepNhanFocusHandle = maTiepNhan;
                this.ngayTiepNhanFocusHandle = ngayTiepNhan;
                this.ngayChiDinhFocusHandle = ngayChiDinh;
        }
        private void GVDanhSachCho_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell)
            {
                e.Allow = false;
                popUpMenuDanhSachCho.ShowPopup(GCDanhSachCho.PointToScreen(e.Point));
            }
        }
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            this.LoadListDSCho();
        }
        private void btnHuyDanhSachDaCapMa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn hủy danh sách muốn hủy danh sách này không", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
                {
                this.lstCanDanhMa.Clear();
                this.lstCanDanhMaFull.Clear();
                this.lstCapMaTheoDonVi.Clear();
                this.lstDaDanhMaXN.Clear();
                this.lstDonViCanCapMa.Clear();
                this.LoadGCDanhSachDaDanhMa();
                this.LoadListDSCho();
            }
        }
        private void GVDanhSachDaCapMa_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if(this.GVDanhSachDaCapMa.RowCount>0)
            {
                    e.Allow = false;
                    popupMenuDanhSachDaCapMa.ShowPopup(GCDanhSachDaCapMa.PointToScreen(e.Point));
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            List<PsRptDanhSachDaCapMaXetNghiem> data = new List<PsRptDanhSachDaCapMaXetNghiem>();
            try
            {
                data = BioNet_Bus.GetDanhSachDaCapMaXetNghiem( (DateTime)this.txtTuNgay_ChuaKQ.EditValue, (DateTime)this.txtDenNgay_ChuaKQ.EditValue, this.searchLookUpDonViCoSo.EditValue.ToString());
                if (data.Count > 0)
                {
                    Reports.rptDanhSachDaCapMaXetNghiem rp = new Reports.rptDanhSachDaCapMaXetNghiem();
                    rp.DataSource = data;
                    rp.CreateDocument();
                    rp.ShowRibbonPreviewDialog();
                }
                else
                    XtraMessageBox.Show("Không có phiếu nào được cấp mã xét nghiệm trong khoảng thời gian bạn đã chọn!", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex) { XtraMessageBox.Show("Lỗi khi export danh sách! \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void GVDanhSachDaCapMa_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            var columnHandle = e.Column.ColumnHandle;
            var rowHandle = e.RowHandle;
            var maDonvi = view.GetRowCellValue(rowHandle, this.col_MaDonVi_GCDaCapMau);
            var maXN = view.GetRowCellValue(rowHandle, this.col_MaXetNghiem_GCDaCapMau);
            //int sLuong = view.GetRowCellValue(rowHandle, this.col_SoLuong) == null ? 1 : int.Parse(view.GetRowCellValue(rowHandle, this.col_SoLuong).ToString());
            //var GtriBatDau = view.GetRowCellValue(rowHandle, this.col_MaBatDau) == null ? string.Empty : view.GetRowCellValue(rowHandle, this.col_MaBatDau).ToString();
            //var GtriKetThuc = view.GetRowCellValue(rowHandle, this.col_MaKetThuc) == null ? string.Empty : view.GetRowCellValue(rowHandle, this.col_MaKetThuc).ToString();
            if (rowHandle < view.RowCount)
            {
                if (columnHandle == this.col_MaXetNghiem_GCDaCapMau.ColumnHandle)
                {
                    var rs = this.lstDaDanhMaXN.FirstOrDefault(p => p.MaXetNghiem == maXN.ToString());
                    var valueOld = view.ActiveEditor.OldEditValue;
                    if (rs != null)
                    {
                        if (!string.IsNullOrEmpty(valueOld.ToString()))
                        {
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                if (view.GetRowCellValue(i, this.col_MaXetNghiem_GCDaCapMau).Equals(maXN) && !i.Equals(rowHandle))
                                {
                                    view.SetRowCellValue(i, this.col_MaXetNghiem_GCDaCapMau, valueOld.ToString());
                                    break;
                                }
                            }
                        }
                        
                    }
                }
            }
                }
        private void GVDanhSachDaCapMa_ShownEditor(object sender, EventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            // LookUpEdit lku = (LookUpEdit);
            // string category = lku.GetColumnValue("CategoryCode").ToString();

            if (view.FocusedColumn.FieldName == "MaXetNghiem")
            {
                try
                {
                    LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
                    string _maDonvi = Convert.ToString(view.GetFocusedRowCellValue("MaDonVi"));
                    var listMa = this.lstDaDanhMaXN.Where(p => p.MaDonVi == _maDonvi && !p.MaChiDinh.Substring(0, 2).Equals("XN")).ToList();
                    editor.Properties.DataSource = listMa;
                }
                catch { }
            }

        }
    }
}