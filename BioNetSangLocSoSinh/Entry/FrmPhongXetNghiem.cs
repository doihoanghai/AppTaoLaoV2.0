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
using BioNetModel;
using BioNetModel.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using MsExcel = Microsoft.Office.Interop.Excel;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmPhongXetNghiem : DevExpress.XtraEditors.XtraForm
    {
        public FrmPhongXetNghiem(string maNhanVien)
        {
            InitializeComponent();
            this.MaNhanVien = maNhanVien;
        }
        private List<PSDanhMucDonViCoSo> lstDonVi = new List<PSDanhMucDonViCoSo>();
        private List<PSDanhMucDonViCoSo> lstDonViResponsitory = new List<PSDanhMucDonViCoSo>();
        private List<PSXN_KetQua> lstMauChoKQ = new List<PSXN_KetQua>();
        private List<PSXN_KetQua> lstMauDaCoKQ = new List<PSXN_KetQua>();
        private List<PsKetQua_ChiTiet> lstChiTietKQ = new List<PsKetQua_ChiTiet>();
        public string MaNhanVien = "NVPhongXN";
        public bool GVChuaCoKQFocus = true;
        public bool validateData = true;
        private string MaKQfocus = string.Empty;
        private List<PSDanhMucGoiDichVuChung> lstgoiXN = new List<PSDanhMucGoiDichVuChung>();
        private void LoadGoiDichVuXetNGhiem()
        {
            try
            {
                this.lstgoiXN = BioNet_Bus.GetDanhsachGoiDichVuChung();
                this.lookUpGoiXN_GCChuaCoKQ.DataSource = this.lstgoiXN;
                this.LookUpGoiXN_GCDaCoKQ.DataSource = this.lstgoiXN;
            }
            catch { }
        }

        private void FrmPhongXetNghiem_Load(object sender, EventArgs e)
        {
            this.LoadFrm();
        }
        private void LoadFrm()
        {
            this.LoadSearchLookupDonVi();
            this.LoadGoiDichVuXetNGhiem();
            this.searchLookUpDonViCoSo.EditValue = "ALL";
            this.txtTuNgay_ChuaKQ.EditValue = DateTime.Now.Date;
            this.txtDenNgay_ChuaKQ.EditValue = DateTime.Now.Date;
            this.LoadLookDonViGC();
            this.LoadLstChuaKetQua();
            this.LoadGCDSChuaCoKQ();
        }

       
        private void LoadGCDSDaCoKQ()
        {
            this.GCDaCoKetQua.DataSource = null;
            this.GCDaCoKetQua.DataSource = this.lstMauDaCoKQ;
            this.GVDaCoKetQua.ExpandAllGroups();
        }
        private void LoadLstChuaKetQua()
        {
            this.lstMauChoKQ.Clear();
            DateTime tu = this.txtTuNgay_ChuaKQ.EditValue == null ? DateTime.Now.Date : (DateTime)this.txtTuNgay_ChuaKQ.EditValue;
            DateTime den = this.txtDenNgay_ChuaKQ.EditValue == null ? DateTime.Now.Date : (DateTime)this.txtDenNgay_ChuaKQ.EditValue;
            string madv = this.searchLookUpDonViCoSo.EditValue == null ? string.Empty : this.searchLookUpDonViCoSo.EditValue.ToString(); ;
            this.lstMauChoKQ = BioNet_Bus.GetDanhSachChoKetQuaXN(tu.Date, den.Date, madv);
            this.LoadGCDSChuaCoKQ();
        }
        private void LoadLstDaCoKetQua()
        {
            this.lstMauDaCoKQ.Clear();
            DateTime tu = this.txtTuNgay_ChuaKQ.EditValue == null ? DateTime.Now.Date : (DateTime)this.txtTuNgay_ChuaKQ.EditValue;
            DateTime den = this.txtDenNgay_ChuaKQ.EditValue == null ? DateTime.Now.Date : (DateTime)this.txtDenNgay_ChuaKQ.EditValue;
            string madv = this.searchLookUpDonViCoSo.EditValue == null ? string.Empty : this.searchLookUpDonViCoSo.EditValue.ToString(); ;
            this.lstMauDaCoKQ = BioNet_Bus.GetDanhSachDaCoKetQuaXN(tu.Date, den.Date, madv);
            this.LoadGCDSDaCoKQ();
        }
        private void LoadGCDSChuaCoKQ()
        {
            this.GCChuaKQ.DataSource = null;
            this.GCChuaKQ.DataSource = this.lstMauChoKQ;
            this.GVChuaKQ.ExpandAllGroups();
        }
        private void LoadGCThongTinKQ()
        {
            this.GCThongTinKQ.DataSource = null;
            this.GCThongTinKQ.DataSource = this.lstChiTietKQ;
        }
        private void HienThiChitietKQ(bool tuGCChuaCoKQ, string maKQ, string maPhieu)
        {if (tuGCChuaCoKQ)
            { this.btnLuu.Enabled= true;
            } else this.btnLuu.Enabled = false;
            this.lstChiTietKQ.Clear();
            this.lstChiTietKQ = BioNet_Bus.GetDanhSachKetQuaChiTiet(maKQ, maPhieu);
            this.LoadGCThongTinKQ();
        }
        private void LuuKetQua()
        {
            if (validateData)
            {
                try
                {
                    KetQua_XetNghiem KQ = new KetQua_XetNghiem();
                    string MaPhieu = string.Empty;
                    string MaDonVi = string.Empty;
                    string MaTiepNhan = string.Empty;
                    string MaChiDinh = string.Empty;
                    string MaKQ = string.Empty;
                    string MaXN = string.Empty;
                    string MaGoiXN = string.Empty;
                    DateTime NgayChiDinh = DateTime.Now;
                    DateTime NgayTiepNhan = DateTime.Now;
                    if (this.GVChuaCoKQFocus)
                    {
                        int[] rowselect = this.GVChuaKQ.GetSelectedRows();
                        if (rowselect.ToList().Count > 0)
                        {
                            MaPhieu = this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_MaPhieu_GCChuaCoKQ).ToString();
                            MaDonVi = this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_MaDonVi_GCChuaCoKQ).ToString();
                            MaTiepNhan = this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_MaTiepNhan_GCChuaCoKQ).ToString();
                            MaChiDinh = this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_MaChiDinh_GCChuaCoKQ).ToString();
                            MaKQ = this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_MaKQ_GCChuaCoKQ).ToString();
                            MaXN = this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_MaXN_GCChuaCoKQ).ToString();
                            NgayChiDinh = this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_NgayChiDinh) == null ? DateTime.Now : (DateTime)(this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_NgayChiDinh));
                            NgayTiepNhan = this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_NgayTiepNhan) == null ? DateTime.Now : (DateTime)(this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_NgayTiepNhan));
                            MaGoiXN = this.GVChuaKQ.GetRowCellValue(rowselect[0], this.col_MaGoiXN_GCChuaCoKQ).ToString();
                            KQ.maGoiXetNghiem = MaGoiXN;
                            KQ.maPhieu = MaPhieu;
                            KQ.maTiepNhan = MaTiepNhan;
                            KQ.maDonVi = MaDonVi;
                            KQ.maChiDinh = MaChiDinh;
                            KQ.maKetQua = MaKQ;
                            KQ.ngayTiepNhan = NgayTiepNhan;
                            KQ.ngayChiDinh = NgayChiDinh;
                            KQ.maXetNghiem = MaXN;
                            KQ.ngayXetNghiem = DateTime.Now;
                            KQ.maNhanVienTraKQ = this.MaNhanVien;
                        }
                    }
                    else
                    {
                        int[] rowselect = this.GVDaCoKetQua.GetSelectedRows();
                        if (rowselect.ToList().Count > 0)
                        {
                            MaPhieu = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_maPhieu_DacoKQ).ToString();
                            MaDonVi = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_maDonVi_DacoKQ).ToString();
                            MaTiepNhan = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_MaTiepNhan_DaCoKQ).ToString();
                            MaChiDinh = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_maChiDinh_DacoKQ).ToString();
                            MaKQ = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_MaKQ_DacoKQ).ToString();
                            MaXN = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_MaXN_DacoKQ).ToString();
                            NgayChiDinh = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_NgayChiDinh_DaCoKQ) == null ? DateTime.Now : (DateTime)(this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_NgayChiDinh_DaCoKQ));
                            NgayTiepNhan = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_NgayTiepNhan_DaCoKQ) == null ? DateTime.Now : (DateTime)(this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_NgayTiepNhan_DaCoKQ));
                            MaGoiXN = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_MaGoiXN_DaCoKQ).ToString();
                            KQ.maGoiXetNghiem = MaGoiXN;
                            KQ.maPhieu = MaPhieu;
                            KQ.maTiepNhan = MaTiepNhan;
                            KQ.maDonVi = MaDonVi;
                            KQ.maChiDinh = MaChiDinh;
                            KQ.maKetQua = MaKQ;
                            KQ.ngayTiepNhan = NgayTiepNhan;
                            KQ.ngayChiDinh = NgayChiDinh;
                            KQ.maXetNghiem = MaXN;
                            KQ.ngayXetNghiem = DateTime.Now;
                            KQ.maNhanVienTraKQ = this.MaNhanVien;
                        }
                    }
                    List<PsKetQua_ChiTiet> lst = new List<PsKetQua_ChiTiet>();
                    for (int i = 0; i < this.GVThongTinKQ.RowCount; i++)
                    {
                        PsKetQua_ChiTiet CTKQ = new PsKetQua_ChiTiet();
                        string MaThongSo = this.GVThongTinKQ.GetRowCellValue(i, this.col_MaThongSo).ToString();
                        string TenThongSo = this.GVThongTinKQ.GetRowCellValue(i, this.col_TenThongSo).ToString();
                        string GiaTri = this.GVThongTinKQ.GetRowCellValue(i, this.col_GiaTri) == null ? string.Empty : this.GVThongTinKQ.GetRowCellValue(i, this.col_GiaTri).ToString();
                        string GiaTriTB = this.GVThongTinKQ.GetRowCellValue(i, this.col_GiaTriTrungBinh).ToString();
                        string DonviTinh = this.GVThongTinKQ.GetRowCellValue(i, this.col_donviTinh) == null ? string.Empty : this.GVThongTinKQ.GetRowCellValue(i, this.col_donviTinh).ToString();
                        bool isNguyCo = this.GVThongTinKQ.GetRowCellValue(i, this.col_NguyCo) == null ? false : (bool)this.GVThongTinKQ.GetRowCellValue(i, this.col_NguyCo);
                        string MaKyThuat = this.GVThongTinKQ.GetRowCellValue(i, this.col_MaKThuat).ToString();
                        float Min = this.GVThongTinKQ.GetRowCellValue(i, this.col_GiaTriMin) == null ? 0 : float.Parse(this.GVThongTinKQ.GetRowCellValue(i, this.col_GiaTriMin).ToString());
                        float Max = this.GVThongTinKQ.GetRowCellValue(i, this.col_GiaTriMax) == null ? 0 : float.Parse(this.GVThongTinKQ.GetRowCellValue(i, this.col_GiaTriMax).ToString());
                        string MaDichVu = this.GVThongTinKQ.GetRowCellValue(i, this.col_MaDichVu).ToString();
                        //string MaKetQ = this.GVThongTinKQ.GetRowCellValue(i, this.col_MaKQ).ToString();
                        //string MaXN = this.GVThongTinKQ.GetRowCellValue(i, this.col_maXN).ToString();
                        string TenKyThuat = this.GVThongTinKQ.GetRowCellValue(i, this.col_TenKyThuat).ToString();

                        CTKQ.DonViTinh = DonviTinh;
                        CTKQ.GiaTri = GiaTri;
                        CTKQ.GiaTriTrungBinh = GiaTriTB;
                        CTKQ.isNguyCoCao = isNguyCo;
                        CTKQ.GiaTriMin = Min;
                        CTKQ.GiaTriMax = Max;
                        CTKQ.MaDichVu = MaDichVu;
                        CTKQ.MaKQ = MaKQ;
                        CTKQ.MaKyThuat = MaKyThuat;
                        CTKQ.MaThongSo = MaThongSo;
                        CTKQ.MaXN = MaXN;
                        CTKQ.TenKyThuat = TenKyThuat;
                        CTKQ.TenThongSo = TenThongSo;
                        CTKQ.MaKQ = MaKQ;
                        CTKQ.MaXN = MaXN;
                        lst.Add(CTKQ);
                    }
                    KQ.KetQuaChiTiet = lst;
                    var res = BioNet_Bus.LuuKetQuaXN(KQ);
                    if (res.Result)
                    {
                        XtraMessageBox.Show("Lưu thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadLstChuaKetQua();
                        this.GCThongTinKQ.DataSource = null;
                        this.btnLuu.Enabled = false;
                        this.btnSua.Enabled = false;
                    }
                    else XtraMessageBox.Show("Lưu không thành công! \r\n Lý do : "+res.StringError.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi lưu kết quả \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else XtraMessageBox.Show("Một số giá trị của thông số chưa đúng, vui lòng kiểm tra lại", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void LoadLookDonViGC()
        {
            this.lstDonViResponsitory.Clear();
            this.lstDonViResponsitory = BioNet_Bus.GetDanhSachDonViCoSo();
            this.repositoryItemLookUpDonVi.DataSource = this.lstDonViResponsitory;
            this.repositoryItemLookUpDonVi_GCChuaCoKQ.DataSource = this.lstDonViResponsitory;
        }
        private void LoadSearchLookupDonVi()
        {
            this.lstDonVi.Clear();
            this.lstDonVi = BioNet_Bus.GetDanhSachDonVi_Searchlookup();
            this.searchLookUpDonViCoSo.Properties.DataSource = this.lstDonVi;
        }
        private void GVChuaKQ_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (this.GVChuaKQ.RowCount > 0)
                {
                    if (this.GVChuaKQ.GetFocusedRow() != null)
                    {
                        string maKQ = this.GVChuaKQ.GetRowCellValue(this.GVChuaKQ.FocusedRowHandle, this.col_MaKQ_GCChuaCoKQ).ToString();
                        string maPhieu = this.GVChuaKQ.GetRowCellValue(this.GVChuaKQ.FocusedRowHandle, this.col_MaPhieu_GCChuaCoKQ).ToString();
                        this.HienThiChitietKQ(true, maKQ, maPhieu);
                        this.btnLuu.Enabled = true;
                        this.GVChuaCoKQFocus = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi hiển thị chi tiết kết quả ! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(this.validateData)
            this.LuuKetQua();
            
        }

        private void GVThongTinKQ_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            var columnHandle = e.Column.ColumnHandle;
            var rowHandle = e.RowHandle;
            var MaThongSo = view.GetRowCellValue(rowHandle, this.col_MaThongSo) == null ? string.Empty : view.GetRowCellValue(rowHandle, this.col_MaThongSo).ToString();
            var tenThongSo = view.GetRowCellValue(rowHandle, this.col_TenThongSo) == null ? string.Empty : view.GetRowCellValue(rowHandle, this.col_TenThongSo).ToString();
            var valueMin = view.GetRowCellValue(rowHandle, this.col_GiaTriMin) == null ? 0 : view.GetRowCellValue(rowHandle, this.col_GiaTriMin);
            var valueMax = view.GetRowCellValue(rowHandle, this.col_GiaTriMax) == null ? 0 : view.GetRowCellValue(rowHandle, this.col_GiaTriMax);
            var valueGT = view.GetRowCellValue(rowHandle, this.col_GiaTri) == null ? string.Empty : view.GetRowCellValue(rowHandle, this.col_GiaTri).ToString();
            bool nguyCo = view.GetRowCellValue(rowHandle, this.col_NguyCo) == null ? false : (bool)view.GetRowCellValue(rowHandle, this.col_NguyCo);
            if (columnHandle == this.col_GiaTri.ColumnHandle)
            {
                try
                {
                    float gT = float.Parse(valueGT);
                    float gTMax = float.Parse(valueMax.ToString());
                    float gTMin = float.Parse(valueMin.ToString());
                    if (gT > gTMax||gT<gTMin) view.SetRowCellValue(rowHandle, this.col_NguyCo, true);
                    else view.SetRowCellValue(rowHandle, this.col_NguyCo, false);
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng nhập đúng giá trị", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                }
            }
        }

        
       
        private void txtTuNgay_ChuaKQ_EditValueChanged(object sender, EventArgs e)
        {
            if(this.txtDenNgay_ChuaKQ.EditValue!=null)
            {
                this.LoadLstChuaKetQua();
                this.LoadLstDaCoKetQua();
            }
        }

        private void txtDenNgay_ChuaKQ_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtTuNgay_ChuaKQ.EditValue != null)
            {
                this.LoadLstChuaKetQua();
                this.LoadLstDaCoKetQua();
            }
        }

        private void GVDaCoKetQua_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (this.GVDaCoKetQua.RowCount > 0)
                {
                    if (this.GVDaCoKetQua.GetFocusedRow() != null)
                    {
                        string maKQ = this.GVDaCoKetQua.GetRowCellValue(this.GVDaCoKetQua.FocusedRowHandle, this.col_MaKQ_DacoKQ).ToString();
                        string maPhieu = this.GVDaCoKetQua.GetRowCellValue(this.GVDaCoKetQua.FocusedRowHandle, this.col_maPhieu_DacoKQ).ToString();
                        this.HienThiChitietKQ(false, maKQ, maPhieu);
                        this.btnSua.Enabled = true;
                        this.GVChuaCoKQFocus = false;

                        
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi hiển thị chi tiết kết quả ! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GVDaCoKetQua_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string MaCD = View.GetRowCellValue(e.RowHandle, this.col_maChiDinh_DacoKQ) == null ? string.Empty : View.GetRowCellValue(e.RowHandle, this.col_maChiDinh_DacoKQ).ToString();
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

        private void GVChuaKQ_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string MaCD = View.GetRowCellValue(e.RowHandle, this.col_MaChiDinh_GCChuaCoKQ) == null ? string.Empty : View.GetRowCellValue(e.RowHandle, this.col_MaChiDinh_GCChuaCoKQ).ToString();
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
            {
                this.LoadLstChuaKetQua();
                this.LoadLstDaCoKetQua();
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
                this.LoadLstChuaKetQua();
                this.LoadLstDaCoKetQua();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel File|*.xls;*.xlsx";
            if (of.ShowDialog() == DialogResult.OK)
            {

                try
                {

                    List<PsDuLieuThongSo_G6PD_GAL_PUK> lst3b = new List<PsDuLieuThongSo_G6PD_GAL_PUK>();
                    List<PsDuLieuThongSo_CAH> lstCAH = new List<PsDuLieuThongSo_CAH>();
                    List<PsDuLieuThongSo_CH> lstCH = new List<PsDuLieuThongSo_CH>();
                    #region Đọc file Excel
                    MsExcel.Application app = new MsExcel.Application();
                    MsExcel.Workbook wb = app.Workbooks.Open(of.FileName);
                    try
                    {

                        int sheetCount = wb.Sheets.Count;

                        for (int s = 1; s <= sheetCount; s++) //đọc từng sheet
                        {
                            MsExcel._Worksheet sheet = wb.Sheets[s];
                            MsExcel.Range range = sheet.UsedRange;
                            int rows = range.Rows.Count;
                            int cols = range.Columns.Count;
                            int pMaXN = 0;
                            int pG6PD = 0;
                            int pPKU = 0;
                            int pGAL = 0;
                            int pCAH = 0;
                            int pCH = 0;
                            //đọc cột tiêu đề
                            for (int i = 1; i <= cols; i++)
                            {
                                string TenCot = range.Cells[1, i].Value.ToString();
                                if (TenCot.Equals("MAXN"))
                                    pMaXN = i;
                                if (TenCot.Equals("G6PD"))
                                    pG6PD = i;
                                if (TenCot.Equals("PKU"))
                                    pPKU = i;
                                if (TenCot.Equals("GAL"))
                                    pGAL = i;
                                if (TenCot.Equals("CAH"))
                                    pCAH = i;
                                if (TenCot.Equals("CH"))
                                    pCH = i;
                            }
                            #region lấy dữ liệu 3 Bệnh
                            if (pMaXN > 0 && pG6PD > 0 && pGAL > 0 && pPKU > 0) //đọc sheet chứa giá trị của 3 bệnh
                            {
                                for (int row = 2; row <= rows; row++)
                                {
                                    PsDuLieuThongSo_G6PD_GAL_PUK data = new PsDuLieuThongSo_G6PD_GAL_PUK();
                                    for (int col = 1; col <= cols; col++)
                                    {
                                        if (col == pMaXN)
                                            data.MaXN = range.Cells[row, col].Value.ToString();
                                        if (col == pG6PD)
                                        {
                                            string value = string.Empty;
                                            try
                                            {
                                                var re = range.Cells[row, col].Value.ToString();
                                                value = re;
                                            }
                                            catch { }
                                            if (string.IsNullOrEmpty(value))
                                                value = string.Empty;
                                            else
                                            {
                                                if (value.Contains("-"))
                                                {
                                                    value = value.Replace("-", "");
                                                }
                                                try
                                                {
                                                    float testvalue = float.Parse(value.Trim());

                                                }
                                                catch { value = string.Empty; }
                                            }
                                            data.G6PD = value;
                                        }
                                        if (col == pGAL)
                                        {
                                            string value = string.Empty;
                                            try
                                            {
                                                var re = range.Cells[row, col].Value.ToString();
                                                value = re;
                                            }
                                            catch { }
                                            if (string.IsNullOrEmpty(value))
                                                value = string.Empty;
                                            else
                                            {
                                                if (value.Contains("-"))
                                                {
                                                    value = value.Replace("-", "");
                                                }
                                                try
                                                {
                                                    float testvalue = float.Parse(value.Trim());

                                                }
                                                catch { value = string.Empty; }
                                            }
                                            data.GAL = value;
                                        }
                                        if (col == pPKU)
                                        {
                                            string value = string.Empty;
                                            try
                                            {
                                                var re = range.Cells[row, col].Value.ToString();
                                                value = re;
                                            }
                                            catch { }
                                            if (string.IsNullOrEmpty(value))
                                                value = string.Empty;
                                            else
                                            {
                                                if (value.Contains("-"))
                                                {
                                                    value = value.Replace("-", "");
                                                }
                                                try
                                                {
                                                    float testvalue = float.Parse(value.Trim());
                                                }
                                                catch { value = string.Empty; }
                                            }
                                            data.PKU = value;
                                        }
                                    }
                                    lst3b.Add(data); //add vô lst3b sau khi quét hết 1 hàng

                                }
                            }
                            #endregion lấy dữ liệu 3 Bệnh
                            #region lấy dữ liệu CAH
                            else if (pMaXN > 0 && pCAH > 0) //Đọc sheet chưa dữ liệu của CAH
                            {
                                for (int row = 2; row <= rows; row++)
                                {
                                    PsDuLieuThongSo_G6PD_GAL_PUK data = new PsDuLieuThongSo_G6PD_GAL_PUK();
                                    for (int col = 1; col <= cols; col++)
                                    {
                                        if (col == pMaXN)
                                            data.MaXN = range.Cells[row, col].Value.ToString();
                                        if (col == pCAH)
                                        {
                                            string value = string.Empty;
                                            try
                                            {
                                                var re = range.Cells[row, col].Value.ToString();
                                                value = re;
                                            }
                                            catch { }
                                            if (string.IsNullOrEmpty(value))
                                                value = string.Empty;
                                            else
                                            {
                                                if (value.Contains("<"))
                                                { value = "0"; }
                                                else
                                                   if (value.Contains("-"))
                                                {
                                                    value = value.Replace("-", "");
                                                }
                                                try
                                                {
                                                    float testvalue = float.Parse(value.Trim());
                                                }
                                                catch { value = string.Empty; }
                                            }
                                            data.CAH = value;
                                        }
                                    }
                                    // lstCAH.Add(data); //add vô lstCAH sau khi quét hết 1 hàng
                                    var dulieu = lst3b.FirstOrDefault(p => p.MaXN == data.MaXN);
                                    if (dulieu != null)
                                    {
                                        dulieu.CAH = data.CAH;
                                    }
                                    else lst3b.Add(data);

                                }
                                #endregion lấy dữ liệu CAH
                                #region lấy dữ liệu CH
                            }
                            else if (pMaXN > 0 && pCH > 0)
                            {
                                for (int row = 2; row <= rows; row++)
                                {
                                    PsDuLieuThongSo_G6PD_GAL_PUK data = new PsDuLieuThongSo_G6PD_GAL_PUK();
                                    for (int col = 1; col <= cols; col++)
                                    {
                                        if (col == pMaXN)
                                            data.MaXN = range.Cells[row, col].Value.ToString();
                                        if (col == pCH)
                                        {
                                            string value = string.Empty;
                                            try
                                            {
                                                var re = range.Cells[row, col].Value.ToString();
                                                value = re;
                                            }
                                            catch { }
                                            if (string.IsNullOrEmpty(value))
                                                value = string.Empty;
                                            else
                                            {
                                                if (value.Contains("<"))
                                                { value = "0"; }
                                                else
                                                   if (value.Contains("-"))
                                                {
                                                    value = value.Replace("-", "");
                                                }
                                                try
                                                {
                                                    float testvalue = float.Parse(value.Trim());
                                                }
                                                catch { value = string.Empty; }
                                            }
                                            data.CH = value;
                                        }
                                    }
                                    //   lstCAH.Add(data); //add vô lstCAH sau khi quét hết 1 hàng
                                    var dulieu = lst3b.FirstOrDefault(p => p.MaXN == data.MaXN);
                                    if (dulieu != null)
                                    {
                                        dulieu.CH = data.CH;
                                    }
                                    else lst3b.Add(data);
                                }
                            }
                            #endregion lấy dữ liệu CH
                        }
                    }
                    catch (Exception ex)
                    {
                        app.Workbooks.Close();
                        XtraMessageBox.Show("Lỗi khi đọc file! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally { app.Workbooks.Close(); }
                    #endregion Đọc file excel
                    #region Add dữ liệu vào DB
                    if (this.lstMauChoKQ.Count > 0)
                    {
                        if (lst3b.Count > 0)
                        {
                            //  List<string> lstMa = this.lstMauChoKQ.Select(x => x.MaXetNghiem).ToList();
                            //   var listDataKQtemp = lst3b.Where(x => this.lstMauChoKQ.Any(p => p.MaXetNghiem == x.MaXN));
                            //     var listDSCanDienKQ = lstMauChoKQ.Where(x => listDataKQtemp.Any(p => p.MaXN == x.MaXetNghiem));
                            List<PsPhieuLoiKhiDanhGia> listphieuloi = new List<PsPhieuLoiKhiDanhGia>();
                            foreach (var mau in this.lstMauChoKQ)
                            {
                                var TsKQ = lst3b.FirstOrDefault(p => p.MaXN == mau.MaXetNghiem);
                                if (TsKQ != null)
                                {
                                    KetQua_XetNghiem KQ = new KetQua_XetNghiem();
                                    KQ.maPhieu = mau.MaPhieu;
                                    KQ.maDonVi = mau.MaDonVi;
                                    KQ.maTiepNhan = mau.MaTiepNhan;
                                    KQ.maChiDinh = mau.MaChiDinh;
                                    KQ.maGoiXetNghiem = mau.MaGoiXN;
                                    KQ.maKetQua = mau.MaKetQua;
                                    KQ.maXetNghiem = mau.MaXetNghiem;
                                    KQ.ngayChiDinh = mau.NgayChiDinh ?? DateTime.Now;
                                    KQ.ngayTiepNhan = mau.NgayTiepNhan ?? DateTime.Now;
                                    KQ.ngayTraKQ = mau.NgayTraKQ ?? DateTime.Now;
                                    KQ.ngayXetNghiem = mau.NgayLamXetNghiem ?? DateTime.Now;
                                    var thongsoChiTiet = BioNet_Bus.GetDanhSachKetQuaChiTiet(mau.MaKetQua, mau.MaPhieu);
                                    List<PsKetQua_ChiTiet> lstKQCT = new List<PsKetQua_ChiTiet>();
                                    foreach (var ts in thongsoChiTiet)
                                    {
                                        bool nguyco = false;
                                        string GiaTri = string.Empty;
                                        if (ts.MaThongSo.Equals("G6PD"))
                                            GiaTri = TsKQ.G6PD??string.Empty;
                                        else if (ts.MaThongSo.Equals("PKU"))
                                            GiaTri = TsKQ.PKU ?? string.Empty;
                                        else if (ts.MaThongSo.Equals("GAL"))
                                            GiaTri = TsKQ.GAL ?? string.Empty;
                                        else if (ts.MaThongSo.Equals("CAH"))
                                            GiaTri = TsKQ.CAH ?? string.Empty;
                                        else if (ts.MaThongSo.Equals("CH"))
                                            GiaTri = TsKQ.CH ?? string.Empty;
                                        try
                                        {
                                            double Gt = double.Parse(GiaTri);
                                            if (Gt > ts.GiaTriMax || Gt < ts.GiaTriMin)
                                                nguyco = true;
                                            else nguyco = false;
                                        }
                                        catch { }
                                        PsKetQua_ChiTiet CTKQ = new PsKetQua_ChiTiet();
                                        CTKQ.DonViTinh = ts.DonViTinh;
                                        CTKQ.GiaTri = GiaTri;
                                        CTKQ.GiaTriTrungBinh = ts.GiaTriTrungBinh;
                                        CTKQ.isNguyCoCao = nguyco;
                                        CTKQ.GiaTriMin = ts.GiaTriMin;
                                        CTKQ.GiaTriMax = ts.GiaTriMax;
                                        CTKQ.MaDichVu = ts.MaDichVu;
                                        CTKQ.MaKQ = ts.MaKQ;
                                        CTKQ.MaKyThuat = ts.MaKyThuat;
                                        CTKQ.MaThongSo = ts.MaThongSo;
                                        CTKQ.MaXN = mau.MaXetNghiem;
                                        CTKQ.TenKyThuat = ts.TenKyThuat;
                                        CTKQ.TenThongSo = ts.TenThongSo;
                                        lstKQCT.Add(CTKQ);
                                    }
                                    KQ.KetQuaChiTiet = lstKQCT;
                                    var result = BioNet_Bus.LuuKetQuaXN(KQ);
                                    if (!result.Result)
                                    {
                                        // XtraMessageBox.Show("Lưu thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        // this.LoadDanhSachTiepNhanTheoDonVi(this.searchLookUpDonViCoSo.EditValue.ToString());

                                        PsPhieuLoiKhiDanhGia phieu = new PsPhieuLoiKhiDanhGia();
                                        phieu.MaPhieu = mau.MaPhieu;
                                        phieu.ThongTinLoi = result.StringError;
                                        listphieuloi.Add(phieu);
                                        //  XtraMessageBox.Show("Lưu thất bại", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            if (listphieuloi.Count < 1)
                            {
                                XtraMessageBox.Show("Lưu thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DiaglogFrm.FrmDiagLogShowPhieuLoi frmloi = new DiaglogFrm.FrmDiagLogShowPhieuLoi(listphieuloi);
                                frmloi.ShowDialog();
                            }
                            this.LoadLstChuaKetQua();
                            this.GCThongTinKQ.DataSource = null;
                        }

                        #endregion Add dữ liệu vào DB
                    }
                    else
                    {
                        XtraMessageBox.Show("Không có mẫu nào trong danh sách chờ!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi đọc file! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // var res =  BioNet_Bus.ReadExcelContents(of.FileName);
            }
        }
        private bool KiemTraKQDaDuocSuaChua()
        {
            string MaPhieu = string.Empty;
            string MaTiepNhan = string.Empty;
            try
            {
                int[] rowselect = this.GVDaCoKetQua.GetSelectedRows();
                if (rowselect.ToList().Count > 0)
                {
                    MaPhieu = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_maPhieu_DacoKQ).ToString();
                    MaTiepNhan = this.GVDaCoKetQua.GetRowCellValue(rowselect[0], this.col_MaTiepNhan_DaCoKQ).ToString();
                    return BioNet_Bus.KiemTraKetQuaDaDuocDuyetHayChua(MaPhieu, MaTiepNhan);
                }
                else return true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi kiểm tra điều kiện được sửa kết quả! \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return true;
            }
        }
            
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!this.KiemTraKQDaDuocSuaChua())
            {
                this.btnLuu.Enabled = true;
                this.btnSua.Enabled = false;
                this.col_GiaTri.OptionsColumn.AllowEdit = true;
            }
            else XtraMessageBox.Show("Phiếu này đã được duyệt nên không được phép sửa!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void xtraTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraTab.XtraTabControl tab = sender as DevExpress.XtraTab.XtraTabControl;
                if( tab.SelectedTabPageIndex ==1)
                    this.col_GiaTri.OptionsColumn.AllowEdit = false;
                else this.col_GiaTri.OptionsColumn.AllowEdit = true;
            }
            catch { }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                DevExpress.XtraTab.XtraTabControl tab = sender as DevExpress.XtraTab.XtraTabControl;
                if (tab.SelectedTabPageIndex == 1)
                { this.col_GiaTri.OptionsColumn.AllowEdit = false;
                    this.LoadLstDaCoKetQua();
                    this.btnLuu.Enabled = false;
                }
                else { this.col_GiaTri.OptionsColumn.AllowEdit = true;
                    this.LoadLstChuaKetQua();
                }
                this.lstChiTietKQ.Clear();
                this.LoadGCThongTinKQ();
                this.btnLuu.Enabled = false;
                this.btnSua.Enabled = false;
            }
            catch { }
        }

        private void GVThongTinKQ_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            GridView view = sender as GridView;
            GridColumn columnGiaTri = view.Columns["GiaTri"];
            try
            {
                var temp = view.GetRowCellValue(e.RowHandle, view.Columns["GiaTri"]).ToString();
                float _giaTri = float.Parse(temp.ToString());
                this.validateData = true;
            }
            catch
            {
                this.validateData = false;
                e.Valid = false;
                view.SetColumnError(columnGiaTri, "Giá trị nhập này không phải là số");
            }

        }

        private void GVThongTinKQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.MaKQfocus))
            {
                DiaglogFrm.FrmDiaglogGhiChuXetNghiem frm = new DiaglogFrm.FrmDiaglogGhiChuXetNghiem(this.MaKQfocus);
                frm.Show();
            }
            else
            {
                XtraMessageBox.Show("Không tìm thấy nội dung nội dung ghi chú của phiếu. Vui lòng thử l", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void GVChuaKQ_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell)
            {
                e.Allow = false;
                popupMenu1.ShowPopup(GCChuaKQ.PointToScreen(e.Point));
            }
        }

        private void GVChuaKQ_MouseDown(object sender, MouseEventArgs e)
        {
            string maKQua = string.Empty;
            GridView view = sender as GridView;
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.InRowCell)/*(hitInfo.InRowCell&&hitInfo.InColumn)*/
            {
                try
                {
                    maKQua = view.GetRowCellValue(hitInfo.RowHandle, view.Columns["MaKetQua"]).ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi xảy ra, vui lòng thử lại!" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            this.MaKQfocus = maKQua;
        }

        private void GVChuaKQ_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.IsTotalSummary && e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {

                GridView view = sender as GridView;

                if (e.Item == view.Columns["MaPhieu"].SummaryItem)
                {
                }
            }
        }

        private void btnHuyMau_Click(object sender, EventArgs e)
        {

        }
    }
}