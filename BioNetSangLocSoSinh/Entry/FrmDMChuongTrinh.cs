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
    public partial class FrmDMChuongTrinh : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMChuongTrinh()
        {
            InitializeComponent();
        }

        private void FrmDMChuongTrinh_Load(object sender, EventArgs e)
        {
            gridControl_ChuongTrinh.DataSource = BioBLL.GetListChuongTrinh();
        }

        private void gridView_ChuongTrinh_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_IDChuongTrinh))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_IDChuongTrinh, "Mã chương trình không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_TenChuongTrinh))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_TenChuongTrinh, "Tên chương trình không được để trống!");
                }
                if (e.Valid)
                {
                    PSDanhMucChuongTrinh chuongTrinh = new PSDanhMucChuongTrinh();
                    if (string.IsNullOrEmpty(gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "RowIDChuongTrinh").ToString()))
                        chuongTrinh.RowIDChuongTrinh = 0;
                    else
                        chuongTrinh.RowIDChuongTrinh = Convert.ToInt32(gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "RowIDChuongTrinh").ToString());
                    chuongTrinh.IDChuongTrinh = gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "IDChuongTrinh").ToString();
                    chuongTrinh.TenChuongTrinh = gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "TenChuongTrinh").ToString();
                    if (string.IsNullOrEmpty(gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "Ngaytao").ToString()))
                        chuongTrinh.Ngaytao = null;
                    else
                        chuongTrinh.Ngaytao = Convert.ToDateTime(gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "Ngaytao").ToString());
                    if (string.IsNullOrEmpty(gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "isLocked").ToString()))
                        chuongTrinh.isLocked = false;
                    else
                        chuongTrinh.isLocked = Convert.ToBoolean(gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "isLocked").ToString());
                    if (string.IsNullOrEmpty(gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "NgayHetHieuLuc").ToString()))
                        chuongTrinh.NgayHetHieuLuc = null;
                    else
                        chuongTrinh.NgayHetHieuLuc = Convert.ToDateTime(gridView_ChuongTrinh.GetRowCellValue(e.RowHandle, "NgayHetHieuLuc").ToString());
                    if (e.RowHandle < 0)
                    {
                        if(!BioBLL.CheckExistMaCT(chuongTrinh.IDChuongTrinh))
                        {
                            XtraMessageBox.Show("Đã tồn tại mã chương trình!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.gridControl_ChuongTrinh.DataSource = BioBLL.GetListChuongTrinh();
                            return;
                        }
                        if (BioBLL.InsChuongTrinh(chuongTrinh))
                        {
                            XtraMessageBox.Show("Thêm mới chương trình thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm mới chương trình thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if(BioBLL.GetChuongTrinhById(Convert.ToInt32(chuongTrinh.RowIDChuongTrinh)).IDChuongTrinh != chuongTrinh.IDChuongTrinh)
                        {
                            if (!BioBLL.CheckExistMaCT(chuongTrinh.IDChuongTrinh))
                            {
                                XtraMessageBox.Show("Đã tồn tại mã chương trình!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.gridControl_ChuongTrinh.DataSource = BioBLL.GetListChuongTrinh();
                                return;
                            }
                        }
                        if (BioBLL.UpdChuongTrinh(chuongTrinh))
                        {
                            XtraMessageBox.Show("Cập nhật chương trình thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật chương trình thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_ChuongTrinh.DataSource = BioBLL.GetListChuongTrinh();
                }
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Thao tác thất bại thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gridControl_ChuongTrinh.DataSource = BioBLL.GetListChuongTrinh();
            }
        }

        private void gridControl_ChuongTrinh_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_ChuongTrinh.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa danh mục này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (BioBLL.DelChuongTrinh(Convert.ToInt32(gridView_ChuongTrinh.GetRowCellValue(gridView_ChuongTrinh.FocusedRowHandle, "RowIDChuongTrinh").ToString())))
                            this.gridControl_ChuongTrinh.DataSource = BioBLL.GetListChuongTrinh();
                        else
                            XtraMessageBox.Show("Xóa danh mục thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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