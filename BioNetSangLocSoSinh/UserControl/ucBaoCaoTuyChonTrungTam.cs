using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetModel;
using BioNetBLL;
using DevExpress.XtraGrid.Localization;
using BioNetModel.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BioNetSangLocSoSinh.UserControl
{
    public partial class ucBaoCaoTuyChonTrungTam : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoTuyChonTrungTam()
        {
            InitializeComponent();
            GridLocalizer.Active = new CustomLayouts.CustomGridDropDownSearchLookup();
            this.txtDenNgay.EditValue = DateTime.Now.Date;
            this.txtTuNgay.EditValue = DateTime.Now.Date;
        }

        private void LoadDuLieuDieuKienLoc()
        {
            this.txtChanDoan.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChanDoan();
            this.txtChatLuongMau.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChatLuongMau();
            this.txtGioiTinh.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_GioiTinh();
            this.txtBenh.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_Benh();
            this.txtChatLuongMau.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChatLuongMau();
            this.txtGoiXetNghiem.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_GoiXN();
            this.txtDanToc.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DanToc();
            this.txtChuongTrinh.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChuongTrinh();
            this.txtChiCuc.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChiCuc();
            this.txtDonVi.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DonVi("all");
            this.txtViTriLayMau.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ViTriLayMau();
            this.txtNguyCo.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_NguyCo();
            this.txtLoaiMau.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_LoaiMau();
        }

        private void ucBaoCaoTuyChonTrungTam_Load(object sender, EventArgs e)
        {
            this.LoadDuLieuDieuKienLoc();
        }

        private void lookUpEdit7_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void ExportDataToExcelFile()
        {
            SaveFileDialog ofd = new SaveFileDialog();
           // ofd.Multiselect = false;
            ofd.Filter = "Excel File(*.xls)|*.xls";
            ofd.FileName = "BaoCaoTuyChon" + DateTime.Now.Date.ToString("yyyy/MM/dd")+".xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Length > 0)
                {
                    try
                    {
                        this.advBandedGridView1.ExportToXls(ofd.FileName);
                    }
                    catch
                    {
                        XtraMessageBox.Show("Không thể lưu file này! Vui lòng chọn đường dẫn khác.", "BioNet - Sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void AddFilterGridView()
        {
            this.advBandedGridView1.ActiveFilterCriteria = null;
            if (this.txtGioiTinh.ItemIndex > 0)
            {
                object name = this.txtGioiTinh.Properties.GetDisplayText(this.txtGioiTinh.EditValue);

                GridColumn col_GioiTinh = this.advBandedGridView1.Columns["GioiTinh"];
                col_GioiTinh.FilterInfo = new ColumnFilterInfo(this.col_GioiTinh, name);
            }
            if (this.txtGoiXetNghiem.ItemIndex > 0)
            {
                object name = this.txtGoiXetNghiem.Properties.GetDisplayText(this.txtGoiXetNghiem.EditValue);
                GridColumn col_GoiXN = this.advBandedGridView1.Columns["TenGoiDichVuChung"];
                col_GoiXN.FilterInfo = new ColumnFilterInfo(this.col_TenGoiDichVu, name);
            }
            if (this.txtChanDoan.ItemIndex > 0)
            {
                object name = this.txtChanDoan.Properties.GetDisplayText(this.txtChanDoan.EditValue);
                GridColumn col_txtChanDoan = this.advBandedGridView1.Columns["ChanDoan"];
                col_txtChanDoan.FilterInfo = new ColumnFilterInfo(this.col_ChanDoan, name);
            }
            if (this.txtChatLuongMau.ItemIndex > 0)
            {
                object name = this.txtChatLuongMau.Properties.GetDisplayText(this.txtChatLuongMau.EditValue);
                GridColumn col_txtChatLuongMau = this.advBandedGridView1.Columns["isKhongDat"];
                col_txtChatLuongMau.FilterInfo = new ColumnFilterInfo(this.col_ChatLuong, name);
            }
            if (this.txtChuongTrinh.ItemIndex > 0)
            {
                object name = this.txtChuongTrinh.Properties.GetDisplayText(this.txtChuongTrinh.EditValue);
                GridColumn col_txtChuongTrinh = this.advBandedGridView1.Columns["TenChuongTrinh"];
                col_txtChuongTrinh.FilterInfo = new ColumnFilterInfo(this.col_ChuongTrinh, name);
            }
            if (this.txtDanToc.EditValue != null && (int)this.txtDanToc.EditValue != 0)
            {
                object name = this.txtDanToc.Properties.GetDisplayText(this.txtDanToc.EditValue);
                GridColumn col_txtDanToc = this.advBandedGridView1.Columns["TenDanToc"];
                col_txtDanToc.FilterInfo = new ColumnFilterInfo(this.col_DanToc_GV, name);
            }
            if (this.txtChiCuc.EditValue != null && !this.txtChiCuc.EditValue.ToString().Equals("all"))
            {
                object name = this.txtChiCuc.Properties.GetDisplayText(this.txtChiCuc.EditValue);
                GridColumn col_txtChiCuc = this.advBandedGridView1.Columns["TenChiCuc"];
                col_txtChiCuc.FilterInfo = new ColumnFilterInfo(this.col_TenChiCuc_GV, name);
            }
            if (this.txtDonVi.EditValue != null && !this.txtDonVi.EditValue.ToString().Equals("all"))
            {
                object name = this.txtDonVi.Properties.GetDisplayText(this.txtDonVi.EditValue);
                GridColumn col_txtDonVi = this.advBandedGridView1.Columns["TenChiCuc"];
                col_txtDonVi.FilterInfo = new ColumnFilterInfo(this.col_TenDonVi_GV, name);
            }
            if (this.txtLoaiMau.ItemIndex > 0)
            {
                object name = this.txtLoaiMau.Properties.GetDisplayText(this.txtLoaiMau.EditValue);
                GridColumn col_txtLoaiMau = this.advBandedGridView1.Columns["LoaiMau"];
                col_txtLoaiMau.FilterInfo = new ColumnFilterInfo(this.col_LoaiMau, name);
            }
            if (this.txtNguyCo.ItemIndex > 0)
            {
                object name = this.txtNguyCo.Properties.GetDisplayText(this.txtNguyCo.EditValue);
                GridColumn col_txtNguyCo = this.advBandedGridView1.Columns["NguyCo"];
                col_txtNguyCo.FilterInfo = new ColumnFilterInfo(this.col_NguyCo, name);
            }
            if (this.txtBenh.ItemIndex > 0)
            {
                string name = this.txtBenh.EditValue.ToString() ;
                if(! string.IsNullOrEmpty(name))
                switch(name)
                {
                        case "G6PD":
                            {
                                string strformat = @"[G6PD_L1] != '0.00'";
                               // GridColumn col_ = this.advBandedGridView1.Columns["G6PD_L1"];
                                col_G6PDL1.FilterInfo = new ColumnFilterInfo(strformat);
                                break;
                            }
                        case "CAH":
                            {
                                string strformat = @"[CAH_L1] != '0.00'";
                                col_CAHL1.FilterInfo = new ColumnFilterInfo(strformat);
                                break;
                            }
                        case "CH":
                            {
                                string strformat = @"[CH_L1] != '0.00'";
                                col_CHL1.FilterInfo = new ColumnFilterInfo(strformat);
                                break;
                            }
                        case "GAL":
                            {
                                string strformat = @"[GAL_L1] != '0.00'";
                                col_GALL1.FilterInfo = new ColumnFilterInfo(strformat);
                                break;
                            }
                        case "PKU":
                            {
                                string strformat = @"[PKU_L1] != '0.00'";
                                col_PKUL1.FilterInfo = new ColumnFilterInfo(strformat);
                                break;
                            }


                    }
                
            }
            if (this.txtViTriLayMau.ItemIndex > 0)
            {
                object name = this.txtViTriLayMau.Properties.GetDisplayText(this.txtViTriLayMau.EditValue);
                GridColumn col_txtViTriLayMau = this.advBandedGridView1.Columns["ViTriLayMau"];
                col_txtViTriLayMau.FilterInfo = new ColumnFilterInfo(this.col_ViTriLayMau, name);
            }
            if (!string.IsNullOrEmpty(this.txtCanNangTu.Text.Trim()) && !string.IsNullOrEmpty(this.txtCanNangDen.Text.Trim()) && float.Parse(this.txtCanNangTu.Text) > 0 && float.Parse(this.txtCanNangDen.Text) > 0)
            {
                string strformat = @"[CanNang] >= '{0}' And[CanNang] <= '{1}'";
                GridColumn col_txtCanNang = this.advBandedGridView1.Columns["CanNang"];
                col_txtCanNang.FilterInfo = new ColumnFilterInfo(string.Format(strformat, this.txtCanNangTu.Text.Trim(), this.txtCanNangDen.Text.Trim()));
                //this.advBandedGridView1.ActiveFilterString = string.Format(strformat, this.txtCanNangTu.Text.Trim(), this.txtCanNangDen.Text.Trim());
            }
        }
        private void btnXem_Click(object sender, EventArgs e)
        {if (!string.IsNullOrEmpty(this.txtTuNgay.Text) && !string.IsNullOrEmpty(this.txtDenNgay.Text))
          { var db = new BioNetDBContextDataContext(DataContext.connectionString);
                this.GCBaoCaoTuyChon.DataSource = db.pro_Report_BaoCaoTuyChonTrungTam(txtTuNgay.DateTime.Date, txtDenNgay.DateTime.Date);
                this.AddFilterGridView(); }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn khoảng thời gian trước khi lấy dữ liệu báo cáo", "BioNet - Sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!string.IsNullOrEmpty(this.txtTuNgay.Text))
                    this.txtTuNgay.Focus();
                else this.txtDenNgay.Focus();

            }

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            this.AddFilterGridView();
        }

        private void txtChiCuc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit sear = sender as SearchLookUpEdit;
                var value = sear.EditValue.ToString();
                this.txtDonVi.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DonVi(value.ToString());
                this.txtDonVi.EditValue = "all";
            }
            catch { }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (this.advBandedGridView1.RowCount > 0)
            {
                this.ExportDataToExcelFile();
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu, vui lòng lấy dữ liệu lại và kiểm tra điều kiện lọc.", "BioNet - Sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void advBandedGridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "G6PD_L1")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_G6PD_L1"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }
            if (e.Column.FieldName == "G6PD_L2")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_G6PD_L2"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }
            if (e.Column.FieldName == "CH_L1")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_CH_L1"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }
            if (e.Column.FieldName == "CH_L2")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_CH_L2"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }

            if (e.Column.FieldName == "CAH_L1")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_CAH_L1"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }
            if (e.Column.FieldName == "CAH_L2")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_CAH_L2"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }
            if (e.Column.FieldName == "GAL_L1")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_GAL_L1"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }
            if (e.Column.FieldName == "GAL_L2")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_GAL_L2"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }
            if (e.Column.FieldName == "PKU_L1")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_PKU_L1"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }
            if (e.Column.FieldName == "PKU_L2")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["isNguyCo_PKU_L2"]);
                // string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Priority"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.BackColor2 = Color.FromArgb(150, Color.Salmon);
                }
            }

        }
    }
}
