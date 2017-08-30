using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Linq;
using System.IO;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmThongTinTrungTam : DevExpress.XtraEditors.XtraForm
    {
        public FrmThongTinTrungTam()
        {
            InitializeComponent();
        }
        BioNetModel.Data.PSThongTinTrungTam tt = new BioNetModel.Data.PSThongTinTrungTam();
        private bool isloaded = false;
        private void LoadThongTinTrungTam()
        {
            this.tt = BioNetBLL.BioNet_Bus.GetThongTinTrungTam();
            if (tt != null)
            {
                try {
                    MemoryStream ms = new MemoryStream(this.tt.Logo.ToArray());
                    pictureEdit1.Image = Image.FromStream(ms);
                }
                catch {  }
                txtTrungTam.Text = this.tt.TenTrungTam;
                txtSoDT.Text = this.tt.DienThoai;
                txtMaVietTat.Text = this.tt.MaVietTat;
                txtDiaChi.Text = this.tt.Diachi;
                checkChoPhepNghiNgo.Checked = this.tt.isChoXNLan2??false;
                checkChoPhepThuMauLai.Checked = this.tt.isChoThuLaiMauLan2??false;
                checkBoxCapMaXnTheoMaPhieu.Checked = this.tt.isCapMaXNTheoMaPhieu ?? false;
            }
        }
        private void FrmThongTinTrungTam_Load(object sender, EventArgs e)
        {
            this.LoadThongTinTrungTam();
            this.LoadThongTinGCGhiChu();
            this.isloaded = true;
        }

        private DataTable hienThi()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("Id", typeof(bool));
            tb.Rows.Add("Trước", true);
            tb.Rows.Add("Sau", false);
            return tb;
        }

        private void LoadThongTinGCGhiChu()
        {
            var lstGc = BioNetBLL.BioNet_Bus.GetListCauHinhGhiChu();
            this.GCGhiChu.DataSource = lstGc;
            this.repositoryItemLookUp_HienThi.DataSource = hienThi();
            this.repositoryItemLookUp_HienThi.ValueMember = "Id";
            this.repositoryItemLookUp_HienThi.DisplayMember = "Name";
        }
        private void checkChoPhepNghiNgo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit chk = sender as CheckEdit;
                if (this.isloaded)
                {
                    this.tt.isChoXNLan2 = chk.Checked;
                    this.btnLuu.Enabled = true;
                }
            }
            catch { }
            
        }

        private void checkChoPhepThuMauLai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit chk = sender as CheckEdit;
                if (this.isloaded)
                {
                    this.tt.isChoThuLaiMauLan2 = chk.Checked;
                    this.btnLuu.Enabled = true;
                }
            }
            catch { }
        }

        private void GvGhiChu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    GridView view = sender as GridView;
            //    var rowHandle = e.RowHandle;
            //    if (rowHandle > 0)
            //    {
            //        BioNetModel.Data.PSDanhMucGhiChu ghichu = new BioNetModel.Data.PSDanhMucGhiChu();
            //        ghichu.isNoiDungDatTruoc = view.GetRowCellValue(rowHandle, this.col_KieuHienThi) == null ? true : (bool)view.GetRowCellValue(rowHandle, this.col_KieuHienThi);
            //        ghichu.MaGhiChu = view.GetRowCellValue(rowHandle, this.col_MaGChu).ToString();
            //        ghichu.ThongTinHienThiGhiChu = view.GetRowCellValue(rowHandle, this.col_NoidungGhiChu).ToString();
            //       var res =  BioNetBLL.BioNet_Bus.UpdateDanhMucGhiChu(ghichu);
            //        if(!res.Result)
            //        {
            //            XtraMessageBox.Show("Lỗi phát sinh khi lưu \r\n Lỗi chi tiết :" + res.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //       this.LoadThongTinGCGhiChu(); 
            //    }
            //}
            //catch(Exception ex)
            //{
            //    XtraMessageBox.Show("Lỗi phát sinh khi lấy dữ liệu để lưu \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
       
        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image File|*.jpg;*.jpeg;*.png";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.pictureEdit1.Image = (Image)Image.FromFile(of.FileName);
                    var fileBytes = File.ReadAllBytes(of.FileName);
                    var image = new Binary(fileBytes);
                    this.tt.Logo =image;
                    this.btnLuu.Enabled = true;
                }
                catch (Exception ex) { }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.tt.TenTrungTam = txtTrungTam.Text.Trim();
            this.tt.Diachi = txtDiaChi.Text.Trim();
            this.tt.DienThoai = txtSoDT.Text.Trim();
            this.tt.isChoThuLaiMauLan2 = this.checkChoPhepThuMauLai.Checked;
            this.tt.isChoXNLan2 = this.checkChoPhepNghiNgo.Checked;
            this.tt.isCapMaXNTheoMaPhieu = this.checkBoxCapMaXnTheoMaPhieu.Checked;
           var rss =BioNetBLL.BioNet_Bus.UpdateThongTinTrungTam(this.tt);
            if (rss.Result)
            {
                this.btnLuu.Enabled = false;
                this.isloaded = false;
                this.LoadThongTinTrungTam();
                this.isloaded = true;
            }
            else
            {
                XtraMessageBox.Show("Lỗi phát sinh khi lấy dữ liệu để lưu \r\n Lỗi chi tiết :" +rss.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTrungTam_Validated(object sender, EventArgs e)
        {   if(isloaded)
            this.btnLuu.Enabled = true;
        }

        private void txtDiaChi_Validated(object sender, EventArgs e)
        {
            if (isloaded)
                this.btnLuu.Enabled = true;
        }

        private void txtSoDT_Validated(object sender, EventArgs e)
        {
            if (isloaded)
                this.btnLuu.Enabled = true;
        }

        private void checkBoxCapMaXnTheoMaPhieu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit chk = sender as CheckEdit;
                if (this.isloaded)
                {
                    this.tt.isCapMaXNTheoMaPhieu = chk.Checked;
                    this.btnLuu.Enabled = true;
                }
            }
            catch { }
        }

        private void GvGhiChu_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            try
            {
                GridView view = sender as GridView;
                var rowHandle = e.RowHandle;
                if (rowHandle > 0)
                {
                    BioNetModel.Data.PSDanhMucGhiChu ghichu = new BioNetModel.Data.PSDanhMucGhiChu();
                    ghichu.isNoiDungDatTruoc = view.GetRowCellValue(rowHandle, this.col_KieuHienThi) == null ? true : (bool)view.GetRowCellValue(rowHandle, this.col_KieuHienThi);
                    ghichu.MaGhiChu = view.GetRowCellValue(rowHandle, this.col_MaGChu).ToString();
                    ghichu.ThongTinHienThiGhiChu = view.GetRowCellValue(rowHandle, this.col_NoidungGhiChu).ToString();
                    var res = BioNetBLL.BioNet_Bus.UpdateDanhMucGhiChu(ghichu);
                    if (!res.Result)
                    {
                        XtraMessageBox.Show("Lỗi phát sinh khi lưu \r\n Lỗi chi tiết :" + res.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.LoadThongTinGCGhiChu();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi lấy dữ liệu để lưu \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}