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

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmKhamBenh : DevExpress.XtraEditors.XtraForm
    {
        public FrmKhamBenh()
        {
            InitializeComponent();
        }
        private List<PSDanhMucDonViCoSo> lstDMDonViCoSo = new List<PSDanhMucDonViCoSo>();
        private List<PSBenhNhanNguyCoCao> lstBenhNhan = new List<PSBenhNhanNguyCoCao>();
        private List<PSBenhNhanNguyCoCao> lstBenhNhanNguyCoGia = new List<PSBenhNhanNguyCoCao>();
        private List<PSXN_TraKQ_ChiTiet> lstChiTietKQ = new List<PSXN_TraKQ_ChiTiet>();
        private List<PSXN_TraKQ_ChiTiet> lstChiTietKQCu = new List<PSXN_TraKQ_ChiTiet>();
        private List<PSDotChuanDoan> lstDotChanDoan = new List<PSDotChuanDoan>();
        private List<PSDanhMucDonViCoSo> lstDonVi = new List<PSDanhMucDonViCoSo>();
        private List<PSDanhMucDonViCoSo> lstDVCS = new List<PSDanhMucDonViCoSo>();
        private void Load_Frm()
        {
            this.txtDenNgay_ChuaKQ.EditValue = DateTime.Now;
            this.txtTuNgay_ChuaKQ.EditValue = DateTime.Now;
            this.LoadsearchLookUpChiCuc();
            this.LoadRespositoryDonVi();
            //this.LoadSearchLookUpDoViCoSo();
            this.LoadDanhSachCho();
            this.loadDanhSachBNNguyCoGia();
            
        }
        private void LoadSearchLookUpDoViCoSo()
        {
            try
            {
                this.lstDVCS.Clear();
                this.lstDVCS = BioNet_Bus.GetDanhSachDonVi_Searchlookup();
                this.searchLookUpDonViCoSo.Properties.DataSource = this.lstDVCS;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi load danh sách đơn vị cơ sở \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.searchLookUpDonViCoSo.Focus();
            }
        }
        private void LoadRespositoryDonVi()
        {
            this.lstDMDonViCoSo.Clear();
            this.lstDMDonViCoSo = BioNet_Bus.GetDanhSachDonViCoSo();
            this.txtMaDonVi.Properties.DataSource = null;
            this.repositoryLookupDonVi.DataSource = null;
           this.repositoryLookupDonVi.DataSource = this.lstDMDonViCoSo;
            this.txtMaDonVi.Properties.DataSource = this.lstDMDonViCoSo;
            this.repositoryItemLookUpDonVi.DataSource = null;
            this.repositoryItemLookUpDonVi.DataSource = this.lstDMDonViCoSo;

        }
        private void LoadGCBenhNhanNguyCoGia()
        {
            this.GCDanhSachBenhNhanNguyCoGia.DataSource = null;
            this.GCDanhSachBenhNhanNguyCoGia.DataSource = this.lstBenhNhanNguyCoGia;
            this.GVDanhSachBenhNhanNguyCoGia.Columns["MaDonVi"].Group();
            this.GVDanhSachBenhNhanNguyCoGia.ExpandAllGroups();
        }
        private void LoadGCBenhNhanNguyCoCao()
        {
            this.GCDanhSachBenhNhanCho.DataSource = null;
            this.GCDanhSachBenhNhanCho.DataSource = this.lstBenhNhan;
            this.GVDanhSachBenhNhanCho.Columns["MaDonVi"].Group();
            this.GVDanhSachBenhNhanCho.ExpandAllGroups();
          
        }
        private void loadDanhSachBNNguyCoGia()
        {
            this.lstBenhNhanNguyCoGia.Clear();
            var dv = this.searchLookUpDonViCoSo.EditValue ?? string.Empty;
            this.lstBenhNhanNguyCoGia = BioNet_Bus.GetDanhSachBenhNhanNguyCoGia(dv.ToString(),txtTuNgay_ChuaKQ.DateTime,txtDenNgay_ChuaKQ.DateTime);
            this.LoadGCBenhNhanNguyCoGia();
        }
        private void LoadDanhSachCho()
        {
            this.lstBenhNhan.Clear();
            var dv = this.searchLookUpDonViCoSo.EditValue ?? string.Empty;
            this.lstBenhNhan = BioNet_Bus.GetDanhSachBenhNhanNguyCoCao(dv.ToString(),txtTuNgay_ChuaKQ.DateTime, txtDenNgay_ChuaKQ.DateTime);
            this.LoadGCBenhNhanNguyCoCao();
        }
        private void txtTuNgay_ChuaKQ_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtDenNgay_ChuaKQ.EditValue != null)
                this.LoadDanhSachCho();
        }
        private void txtDenNgay_ChuaKQ_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtTuNgay_ChuaKQ.EditValue != null)
                this.LoadDanhSachCho();
        }
        private void LoadListDonViSearchLookup()
        {
            this.lstDonVi.Clear();
            this.lstDonVi = BioNet_Bus.GetDanhSachDonVi_Searchlookup();
            this.searchLookUpDonViCoSo.Properties.DataSource = null;
            this.searchLookUpDonViCoSo.Properties.DataSource = this.lstDonVi;
        }
        private void FrmKhamBenh_Load(object sender, EventArgs e)
        {
            this.Load_Frm();
        }
        private void LoadGCKQChiTietCu()
        {
            this.GCChiTietKQCu.DataSource = null;
            this.GCChiTietKQCu.DataSource = this.lstChiTietKQCu;
        }
        private void LoadGCKQChiTiet()
        {
            this.GCChiTietKetQua.DataSource = null;
            this.GCChiTietKetQua.DataSource = this.lstChiTietKQ;
        }
        private void LoadListTreeView()
        {
            this.treeviewDotKham.Nodes.Clear();
            TreeNode rootNode = new TreeNode("Lịch sử khám bệnh");
            rootNode.ExpandAll();
            if (this.lstDotChanDoan.Count > 0)
            {
                foreach (var item in this.lstDotChanDoan)
                {
                    TreeNode childNode = new TreeNode(item.NgayChanDoan.ToString());
                    childNode.Tag = item.rowIDDotChanDoan;
                    rootNode.Nodes.Add(childNode);
                }
                this.treeviewDotKham.Nodes.Add(rootNode);
            }
            else
            {
                MessageBox.Show("Bệnh nhân chưa có chẩn đoán trước đó.", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
            }
           
        }
        private void HienThiThongTinBenhNhan(string maBenhNhan, string maDonVi, string maKhachHang, string maTiepNhan,string rowID,string maTiepNhan2,bool isBNNguyCo)
        {
            try
            {
                this.txtMaBenhNhan.Text = maBenhNhan;
                this.txtMaKhachHang.Text = maKhachHang;
                this.txtRowIDBenhNhanNguyCo.Text = rowID;
                if (isBNNguyCo)
                {
                    this.btnMoi.Enabled = true;
                    this.btnNguyCoGia.Enabled = true;
                    this.btnNguyCoGia.Text = "Nguy cơ giả";
                }
                else
                {
                    this.btnNguyCoGia.Enabled = true;
                    this.btnMoi.Enabled = false;
                    this.btnNguyCoGia.Text = "Nguy cơ cao";
                }
                PSPatient bn = BioNet_Bus.GetThongTinBenhNhan(maBenhNhan);
                this.lstDotChanDoan.Clear();
                try
                {
                    this.lstDotChanDoan = BioNet_Bus.GetDanhSachDotChanDoanCuaBenhNhan(long.Parse(rowID));
                    this.LoadListTreeView();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi khi danh sách đợt chẩn đoán! \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.lstChiTietKQ.Clear();
                this.lstChiTietKQCu.Clear();
                if (!string.IsNullOrEmpty(maTiepNhan2))
                {
                    this.lstChiTietKQ = BioNet_Bus.GetDanhSachTraKetQuaChiTiet(maTiepNhan2);
                    this.lstChiTietKQCu = BioNet_Bus.GetDanhSachTraKetQuaChiTiet(maTiepNhan);
                    this.xtraTabKQChiTietCu.PageVisible = true;
                    this.LoadGCKQChiTiet();
                    this.LoadGCKQChiTietCu();
                }
                else
                {
                    this.lstChiTietKQ = BioNet_Bus.GetDanhSachTraKetQuaChiTiet(maTiepNhan);
                    this.xtraTabKQChiTietCu.PageVisible = false;  this.LoadGCKQChiTiet();
                }
                if (bn != null)
                {
                    this.txtDiaChi.Text = bn.DiaChi;
                    this.txtGioiTinh.SelectedIndex = bn.GioiTinh??2;
                    this.txtMaDonVi.EditValue = maDonVi;
                    
                    this.txtNgaySinh.EditValue = bn.NgayGioSinh;
                    this.txtSDT.Text = string.IsNullOrEmpty(bn.MotherPhoneNumber.ToString()) ? bn.FatherPhoneNumber.ToString() : bn.MotherPhoneNumber.ToString();
                    this.txtTenBN.Text = string.IsNullOrEmpty(bn.TenBenhNhan.ToString()) ? "CB_" + bn.MotherName: bn.TenBenhNhan.ToString();
                    this.txtTenMe.Text = bn.MotherName;
                }
              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin bệnh nhân \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GVDanhSachBenhNhanCho_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (this.GVDanhSachBenhNhanCho.RowCount > 0)
                {
                    if (this.GVDanhSachBenhNhanCho.GetFocusedRow() != null)
                    {   string rowID = this.GVDanhSachBenhNhanCho.GetRowCellValue(this.GVDanhSachBenhNhanCho.FocusedRowHandle, this.col_rowID).ToString();
                        string maBenhNhan = this.GVDanhSachBenhNhanCho.GetRowCellValue(this.GVDanhSachBenhNhanCho.FocusedRowHandle, this.col_MaBenhNhan).ToString();
                        string maDonVi = this.GVDanhSachBenhNhanCho.GetRowCellValue(this.GVDanhSachBenhNhanCho.FocusedRowHandle, this.col_DonVi).ToString();
                        
                        string maKhachHang = this.GVDanhSachBenhNhanCho.GetRowCellValue(this.GVDanhSachBenhNhanCho.FocusedRowHandle, this.col_MaKhachHang).ToString();
                     //   string maThongTin = this.GVDanhSachBenhNhanCho.GetRowCellValue(this.GVDanhSachBenhNhanCho.FocusedRowHandle, this.col_MaThongTin).ToString();
                        string maTiepNhan = this.GVDanhSachBenhNhanCho.GetRowCellValue(this.GVDanhSachBenhNhanCho.FocusedRowHandle, this.col_MaTiepNhan).ToString();
                        string maTiepNhan2 = this.GVDanhSachBenhNhanCho.GetRowCellValue(this.GVDanhSachBenhNhanCho.FocusedRowHandle, this.col_MaTiepNhan2)==null? string.Empty: this.GVDanhSachBenhNhanCho.GetRowCellValue(this.GVDanhSachBenhNhanCho.FocusedRowHandle, this.col_MaTiepNhan2).ToString();
                        this.HienThiThongTinBenhNhan(maBenhNhan, maDonVi, maKhachHang, maTiepNhan,rowID,maTiepNhan2,true);
                        this.txtGhiChu.ResetText();
                        this.txtKetQua.ResetText();
                        this.txtChanDoan.ResetText();

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin bệnh nhân \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.Luu();
        }

      
        private void KhamDotMoi()
        {
            this.txtRowIDDotKham.ResetText();
            this.txtGhiChu.ResetText();
            this.txtChanDoan.ResetText();this.txtKetQua.ResetText();
            this.btnSua.Enabled = false;
            this.btnNguyCoGia.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnNguyCoGia.Enabled = false;
        }
        private void Reset()
        {
            this.txtChanDoan.ResetText();
            this.txtDiaChi.ResetText();
            this.txtGhiChu.ResetText();
            this.txtGioiTinh.SelectedIndex = -1;
            this.txtKetQua.ResetText();
            this.txtMaBenhNhan.ResetText();
            this.txtMaDonVi.EditValue = string.Empty;
            this.txtMaKhachHang.ResetText();
            this.txtRowIDBenhNhanNguyCo.ResetText();
            this.txtRowIDDotKham.ResetText();
            this.treeviewDotKham.Nodes.Clear();
            this.lstChiTietKQCu.Clear();
            this.lstChiTietKQ.Clear();
            this.txtSDT.ResetText();
            this.txtTenBN.ResetText();
            this.txtTenMe.ResetText();
        }
        private void Luu()
        {
            try
            {
                PSDotChuanDoan dot = new PSDotChuanDoan();
                dot.RowIDBNCanTheoDoi = long.Parse(this.txtRowIDBenhNhanNguyCo.Text.Trim());
                dot.MaBenhNhan = this.txtMaBenhNhan.Text.Trim() ;
                dot.MaKhachHang = this.txtMaKhachHang.Text.Trim();
                dot.NgayChanDoan = DateTime.Now;
                dot.ChanDoan = this.txtChanDoan.Text;
                dot.GhiChu = this.txtGhiChu.Text;
                dot.KetQua = this.txtKetQua.Text;
                dot.isDongBo = false;
                dot.isXoa = false;
                dot.rowIDDotChanDoan = string.IsNullOrEmpty(this.txtRowIDDotKham.Text) == true ? 0 : long.Parse(this.txtRowIDDotKham.Text);
                var result = BioNet_Bus.InsertDotChanDoan(dot);
                if (result.Result)
                {
                    MessageBox.Show("Lưu thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.btnLuu.Enabled = false;
                    this.Reset();
                    this.btnMoi.Enabled = true;
                    this.LoadGCKQChiTiet();
                    this.LoadGCKQChiTietCu();
                   // this.LoadListTreeView();

                }
                else MessageBox.Show("Lưu không thành công! \r\n Lỗi chi tiết : " + result.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu! \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            KhamDotMoi();
        }
        private void HienThiChanDoanCu(long rowID)
        {
           try
            {
                var dot = BioNet_Bus.GetThongTinDotChanDoan(rowID);
                if(dot!=null)
                {
                    this.txtGhiChu.Text = dot.GhiChu;
                    this.txtChanDoan.Text = dot.ChanDoan;
                    this.txtKetQua.Text = dot.KetQua;
                    this.txtRowIDDotKham.Text = dot.rowIDDotChanDoan.ToString();
                    this.btnNguyCoGia.Enabled = true;
                    this.btnLuu.Enabled = false;this.btnSua.Enabled = true;

                }
            }
            catch { }
        }
        private void treeviewDotKham_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeView nodeselect = (TreeView)sender;
                string maLK = string.Empty;
                maLK = nodeselect.SelectedNode.Tag.ToString();
                if (!string.IsNullOrEmpty(maLK))
                {
                    this.HienThiChanDoanCu(long.Parse(maLK));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị kết quả chẩn đoán! \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnNguyCoGia_Click(object sender, EventArgs e)
        {
            try
            { if (btnNguyCoGia.Text.Trim().Equals("Nguy cơ giả"))
                     {
                    if (XtraMessageBox.Show("Bạn có chắc chắn phát hiện bệnh nhân này là trường hợp nguy cơ giả không?", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var res = BioNet_Bus.BenhNhanNguyCoGia(long.Parse(this.txtRowIDBenhNhanNguyCo.Text.Trim()));
                        if (res.Result)
                        {
                            XtraMessageBox.Show("Cập nhật thành công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadDanhSachCho();
                            this.loadDanhSachBNNguyCoGia();
                            this.GCChiTietKetQua.DataSource = null;
                            this.GCChiTietKQCu.DataSource = null;
                            this.Reset();
                            this.btnMoi.Enabled = false;
                            this.btnNguyCoGia.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi loại bệnh nhân ra khỏi danh sách cần theo dõi! \r\n Lỗi chi tiết : " + res.StringError.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có chắc chắn bệnh nhân này là nguy cơ cao không?", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var res = BioNet_Bus.BenhNhanNguyCoCao(long.Parse(this.txtRowIDBenhNhanNguyCo.Text.Trim()));
                        if (res.Result)
                        {
                            XtraMessageBox.Show("Cập nhật thành công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadDanhSachCho();
                            this.loadDanhSachBNNguyCoGia();
                            this.GCChiTietKetQua.DataSource = null;
                            this.GCChiTietKQCu.DataSource = null;
                            this.Reset();
                            this.btnMoi.Enabled = false;
                            this.btnNguyCoGia.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi đưa bệnh nhân vào danh sách cần theo dõi! \r\n Lỗi chi tiết : " + res.StringError.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi loại bệnh nhân ra khỏi danh sách cần theo dõi! \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.btnLuu.Enabled = true;
            this.btnSua.Enabled = false;this.btnMoi.Enabled = false;
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            this.LoadDanhSachCho();
            this.loadDanhSachBNNguyCoGia();
        }

        private void GVDanhSachBenhNhanNguyCoGia_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (this.GVDanhSachBenhNhanNguyCoGia.RowCount > 0)
                {
                    if (this.GVDanhSachBenhNhanNguyCoGia.GetFocusedRow() != null)
                    {
                        string rowID = this.GVDanhSachBenhNhanNguyCoGia.GetRowCellValue(this.GVDanhSachBenhNhanNguyCoGia.FocusedRowHandle, this.col_RowID_Gia).ToString();
                        string maBenhNhan = this.GVDanhSachBenhNhanNguyCoGia.GetRowCellValue(this.GVDanhSachBenhNhanNguyCoGia.FocusedRowHandle, this.col_MaBenhNhan_Gia).ToString();
                        string maDonVi = this.GVDanhSachBenhNhanNguyCoGia.GetRowCellValue(this.GVDanhSachBenhNhanNguyCoGia.FocusedRowHandle, this.col_MaDonVi_Gia).ToString();
                        string maKhachHang = this.GVDanhSachBenhNhanNguyCoGia.GetRowCellValue(this.GVDanhSachBenhNhanNguyCoGia.FocusedRowHandle, this.col_MaKhachHang_Gia).ToString();
                        //   string maThongTin = this.GVDanhSachBenhNhanCho.GetRowCellValue(this.GVDanhSachBenhNhanCho.FocusedRowHandle, this.col_MaThongTin).ToString();
                        string maTiepNhan = this.GVDanhSachBenhNhanNguyCoGia.GetRowCellValue(this.GVDanhSachBenhNhanNguyCoGia.FocusedRowHandle, this.col_MaTiepNhan_Gia).ToString();
                        string maTiepNhan2 = this.GVDanhSachBenhNhanNguyCoGia.GetRowCellValue(this.GVDanhSachBenhNhanNguyCoGia.FocusedRowHandle, this.col_MaTiepNhan2_Gia) == null ? string.Empty : this.GVDanhSachBenhNhanNguyCoGia.GetRowCellValue(this.GVDanhSachBenhNhanNguyCoGia.FocusedRowHandle, this.col_MaTiepNhan2_Gia).ToString();
                        this.HienThiThongTinBenhNhan(maBenhNhan, maDonVi, maKhachHang, maTiepNhan, rowID, maTiepNhan2, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin bệnh nhân \r\n Lỗi chi tiết : " + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
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

     
    }
}