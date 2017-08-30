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
using DevExpress.XtraGrid.Views.Grid;
using BioNetModel.Data;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmDMDichVu : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMDichVu()
        {
            InitializeComponent();
        }

        private void FrmDMDichVu_Load(object sender, EventArgs e)
        {
            this.repositoryItemLookUpEdit_Nhom.DataSource = BioBLL.GetListNhom();
            this.repositoryItemLookUpEdit_Nhom.ValueMember = "RowIDNhom";
            this.repositoryItemLookUpEdit_Nhom.DisplayMember = "TenNhom";

            this.gridControl_DMDichVu.DataSource = BioBLL.GetListDichVu();
        }

        private void gridView_DMDichVu_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_TenDichVu))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_TenDichVu, "Tên dịch vụ không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_TenHienThiDichVu))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_TenHienThiDichVu, "Tên hiển thị không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_MaNhom))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_MaNhom, "Hãy chọn nhóm cho dịch vụ!");
                }
                if (e.Valid)
                {
                    PSDanhMucDichVu dichVu = new PSDanhMucDichVu();
                    dichVu.IDDichVu = gridView_DMDichVu.GetRowCellValue(e.RowHandle, "IDDichVu").ToString();
                    dichVu.TenDichVu = gridView_DMDichVu.GetRowCellValue(e.RowHandle, "TenDichVu").ToString();
                    dichVu.TenHienThiDichVu = gridView_DMDichVu.GetRowCellValue(e.RowHandle, "TenHienThiDichVu").ToString();
                    dichVu.MaNhom = gridView_DMDichVu.GetRowCellValue(e.RowHandle, "MaNhom").ToString()==string.Empty ? 0 :Convert.ToInt32(gridView_DMDichVu.GetRowCellValue(e.RowHandle, "MaNhom").ToString());
                    if (string.IsNullOrEmpty(gridView_DMDichVu.GetRowCellValue(e.RowHandle, "GiaDichVu").ToString()))
                        dichVu.GiaDichVu = 0;
                    else
                        dichVu.GiaDichVu = Convert.ToDecimal(gridView_DMDichVu.GetRowCellValue(e.RowHandle, "GiaDichVu").ToString());
                    if (string.IsNullOrEmpty(gridView_DMDichVu.GetRowCellValue(e.RowHandle, "isLocked").ToString()))
                        dichVu.isLocked = false;
                    else
                        dichVu.isLocked = Convert.ToBoolean(gridView_DMDichVu.GetRowCellValue(e.RowHandle, "isLocked").ToString());
                    if (string.IsNullOrEmpty(gridView_DMDichVu.GetRowCellValue(e.RowHandle, "isGoiXn").ToString()))
                        dichVu.isGoiXn = false;
                    else
                        dichVu.isGoiXn = Convert.ToBoolean(gridView_DMDichVu.GetRowCellValue(e.RowHandle, "isGoiXn").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (BioBLL.InsDichVu(dichVu))
                        {
                            XtraMessageBox.Show("Thêm mới dịch vụ thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm mới dịch vụ thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (BioBLL.UpdDichVu(dichVu))
                        {
                            XtraMessageBox.Show("Cập nhật dịch vụ thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật dịch vụ thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_DMDichVu.DataSource = BioBLL.GetListDichVu();
                }
            }
            catch(Exception ex) { }
        }
        private void gridControl_DMDichVu_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_DMDichVu.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa danh mục này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (BioBLL.DelDichVu(gridView_DMDichVu.GetRowCellValue(gridView_DMDichVu.FocusedRowHandle, "IDDichVu").ToString()))
                            this.gridControl_DMDichVu.DataSource = BioBLL.GetListDichVu();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Xóa danh mục thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
    }
}