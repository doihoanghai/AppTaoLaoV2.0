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
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmNhapKho : DevExpress.XtraEditors.XtraForm
    {
        public FrmNhapKho()
        {
            InitializeComponent();
        }

       private void LoadDanhMucNhaCungCap()
        {
            this.lkupNhacc.Properties.DataSource = BioNet_Bus.GetDanhMucNhaCungCap();
        }
        private void LoadDanhMucVatTu()
        {
            this.repSearch_VatTu.DataSource = BioNet_Bus.GetDanhMucVatTu();
        }
        private void LoadDataGridView()
        {
            DataTable dataTable = new DataTable(typeof(PSNhapKho_ChiTiet).Name);
            try
            {

                PropertyInfo[] Props = typeof(PSNhapKho_ChiTiet).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {

                    dataTable.Columns.Add(prop.Name);
                }
                this.gridControl_Detail.DataSource = dataTable;
            }
            catch { }
        }

        private void FrmNhapKho_Load(object sender, EventArgs e)
        {
            this.LoadDanhMucNhaCungCap();
            this.LoadDanhMucVatTu();
            this.LoadDataGridView();
        }

        private void repSearch_VatTu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                this.gridView_Detail.SetFocusedRowCellValue(this.col_DongGoi, searchEdit.Properties.View.GetFocusedRowCellValue("DongGoi"));
                this.gridView_Detail.SetFocusedRowCellValue(this.col_SLQuyDoi, searchEdit.Properties.View.GetFocusedRowCellValue("SoLuongQuyDoi"));
                this.gridView_Detail.SetFocusedRowCellValue(this.col_DonViTinh, searchEdit.Properties.View.GetFocusedRowCellValue("DonViTinh"));
                this.gridView_Detail.SetFocusedRowCellValue(this.col_MaPhieuNhap, this.txtSophieu.Text);
            }
            catch
            {}
            

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txtSophieu.Text = ("PN" + BioNet_Bus.GetMaPNTrongBangGhi() + 1).ToString();
        }

        private void gridView_Detail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "BioNet - Sàng lọc sơ sinh";
            e.ErrorText = " Vui lòng nhập đầy đủ thông tin phiếu nhập kho !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Detail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.KeyCode == Keys.Delete && gridView_Detail.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {

                    if (XtraMessageBox.Show("Bạn có muốn xóa thuốc này khỏi phiếu nhập?", "iHIS - Bệnh Viện Điện Tử.", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        try
                        {
                            if (view.RowCount > 0)
                            {
                                view.DeleteSelectedRows();
                            }
                        }
                        catch { return; }
                    }

                }
            }
            catch { }
        }

        private void gridView_Detail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_MaVatTu)).ToString() == string.Empty)
                {
                    e.Valid = false;

                    view.SetColumnError(col_MaVatTu, " Chưa chọn vật tư - hóa chất !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_HanSuDung)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_HanSuDung, " Không được để trống hạn sử dụng !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_SoLuong)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_SoLuong, " Chưa nhập số lượng !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_SoLuongNhap)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_SoLuongNhap, " Số lượng nhập không được để trống !");
                }
              
            }
            catch { return; }
        }

        private void gridView_Detail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                decimal soluong = 0;
                decimal soluongnhap = 0;
                decimal soluongquydoi = 1;
                if (view.GetFocusedRowCellValue(col_SLQuyDoi).ToString() != string.Empty)
                    soluongquydoi = Convert.ToDecimal(view.GetFocusedRowCellValue(col_SLQuyDoi));
                if (view.GetFocusedRowCellValue(col_SoLuong).ToString() != string.Empty)
                    soluong = Convert.ToDecimal(view.GetFocusedRowCellValue(col_SoLuong));
                if (view.GetFocusedRowCellValue(col_SoLuongNhap).ToString() != string.Empty)
                    soluongnhap = Convert.ToDecimal(view.GetFocusedRowCellValue(col_SoLuongNhap));
                if (view.FocusedColumn.FieldName == "SoLuong")
                {
                    soluongnhap = decimal.Parse(e.Value.ToString() ?? "0");
                    return;
                }
               if(view.FocusedColumn.FieldName=="SoLuongNhap")
                {

                }
                }
            catch(Exception ex)
            { }
            }
    }
}