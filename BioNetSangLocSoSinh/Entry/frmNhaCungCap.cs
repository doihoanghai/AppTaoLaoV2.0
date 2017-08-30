using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class frmNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        string codeTemp = string.Empty;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            //this.gridControl_Vendor.DataSource = VendorBLL.DTVendorList(string.Empty);
        }
        private void gridView_Vendor_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            //e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            //e.WindowCaption = "Bệnh viện điện tử .NET";
            //e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo danh mục nhà cung cấp!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Vendor_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //try
            //{
            //    GridView view = sender as GridView;
            //    int rowfocus = e.RowHandle;
            //    if (Convert.ToString(view.GetRowCellValue(rowfocus, col_VendorName)).ToString() == string.Empty)
            //    {
            //        e.Valid = false;
            //        view.SetColumnError(col_VendorName, "Tên nhà cung cấp không được để trống !");
            //    }
            //    if (e.Valid)
            //    {
            //        VendorInf inf = new VendorInf();
            //        inf.VendorCode = gridView_Vendor.GetRowCellValue(e.RowHandle, "VendorCode").ToString();
            //        inf.VendorName = gridView_Vendor.GetRowCellValue(e.RowHandle, "VendorName").ToString();
            //        inf.Salesman = gridView_Vendor.GetRowCellValue(e.RowHandle, "Salesman").ToString();
            //        inf.Address = gridView_Vendor.GetRowCellValue(e.RowHandle, "Address").ToString();
            //        inf.Phone = gridView_Vendor.GetRowCellValue(e.RowHandle, "Phone").ToString();
            //        inf.Email = gridView_Vendor.GetRowCellValue(e.RowHandle, "Email").ToString();
            //        if (gridView_Vendor.GetRowCellValue(e.RowHandle, "Status").ToString() != "")
            //            inf.Status = int.Parse(gridView_Vendor.GetRowCellValue(e.RowHandle, "Status").ToString());
            //        else
            //            inf.Status = 0;
            //        inf.VendorTaxNo = gridView_Vendor.GetRowCellValue(e.RowHandle, "VendorTaxNo").ToString();
            //        inf.VendorFax = gridView_Vendor.GetRowCellValue(e.RowHandle, "VendorFax").ToString();
            //        inf.VendorBankName = gridView_Vendor.GetRowCellValue(e.RowHandle, "VendorBankName").ToString();

            //        if (e.RowHandle < 0)
            //        {
            //            if (VendorBLL.InsVendor(inf) == 1)
            //            {
            //                XtraMessageBox.Show("Thêm mới nhà cung cấp thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                //gridControl_Vendor.DataSource = VendorBLL.DTVendorList("");
            //            }
            //            else
            //            {
            //                XtraMessageBox.Show("Thêm nhà cung cấp thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                //gridView_Vendor.DeleteRow(rowfocus);
            //            }
            //        }
            //        else
            //        {
            //            if (VendorBLL.InsVendor(inf) == 1)
            //            {
            //                XtraMessageBox.Show("Cập nhật nhà cung cấp thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                //gridControl_Vendor.DataSource = VendorBLL.DTVendorList("");
            //            }
            //            else
            //            {
            //                XtraMessageBox.Show("Cập nhật nhà cung cấp thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //        }
            //        this.LoadData();
            //    }

            //}
            //catch (Exception) { }
        }

        private void gridControl_Vendor_ProcessGridKey(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Delete && gridView_Vendor.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            //    {
            //        if (XtraMessageBox.Show("Bạn có muốn xóa nhân viên này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            //        {
            //            if (VendorBLL.DelVendor(gridView_Vendor.GetRowCellValue(gridView_Vendor.FocusedRowHandle, "VendorCode").ToString()) == 1)
            //                this.LoadData();
            //        }
            //    }
            //}
            //catch { return; }
        }
    }
}