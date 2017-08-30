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
    public partial class FrmDMThongSoXN : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMThongSoXN()
        {
            InitializeComponent();
        }

        private void FrmDMThongSoXN_Load(object sender, EventArgs e)
        {
            this.repositoryItemLookUpEdit_nhom.DataSource = BioBLL.GetListNhom();
            this.repositoryItemLookUpEdit_nhom.ValueMember = "RowIDNhom";
            this.repositoryItemLookUpEdit_nhom.DisplayMember = "TenNhom";

            this.gridControl_thongso.DataSource = BioBLL.GetListThongSoXN();
        }

        private void gridView_thongso_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_IDThongSoXN))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_IDThongSoXN, "Mã thông số xét nghiệm không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_TenThongSo))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_TenThongSo, "Tên thông số xét nghiệm không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_MaNhom))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_MaNhom, "Mã nhóm không được để trống!");
                }
                if (e.Valid)
                {
                    PSDanhMucThongSoXN thongSo = new PSDanhMucThongSoXN();
                    if (string.IsNullOrEmpty(gridView_thongso.GetRowCellValue(e.RowHandle, "RowIDThongSo").ToString()))
                        thongSo.RowIDThongSo = 0;
                    else
                        thongSo.RowIDThongSo = Convert.ToInt32(gridView_thongso.GetRowCellValue(e.RowHandle, "RowIDThongSo").ToString());
                    thongSo.IDThongSoXN = gridView_thongso.GetRowCellValue(e.RowHandle, "IDThongSoXN").ToString();
                    thongSo.TenThongSo = gridView_thongso.GetRowCellValue(e.RowHandle, "TenThongSo").ToString();
                    if (!string.IsNullOrEmpty(gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMinNu").ToString()))
                        thongSo.GiaTriMinNu = Convert.ToDouble(gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMinNu").ToString());
                    else
                        thongSo.GiaTriMinNu = 0;
                    if (!string.IsNullOrEmpty(gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMaxNu").ToString()))
                        thongSo.GiaTriMaxNu = Convert.ToDouble(gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMaxNu").ToString());
                    else
                        thongSo.GiaTriMaxNu = 0;
                    thongSo.GiaTriTrungBinhNu = gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriTrungBinhNu").ToString();
                    thongSo.GiaTriMacDinh = gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMacDinh").ToString();
                    if (!string.IsNullOrEmpty(gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMinNam").ToString()))
                        thongSo.GiaTriMinNam = Convert.ToDouble(gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMinNam").ToString());
                    else
                        thongSo.GiaTriMinNam = 0;
                    if (!string.IsNullOrEmpty(gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMaxNam").ToString()))
                        thongSo.GiaTriMaxNam = Convert.ToDouble(gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMaxNam").ToString());
                    else
                        thongSo.GiaTriMaxNam = 0;
                    thongSo.GiaTriTrungBinhNam = gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriTrungBinhNam").ToString();
                    thongSo.MaNhom = Convert.ToByte(gridView_thongso.GetRowCellValue(e.RowHandle, "MaNhom").ToString());
                    if (!string.IsNullOrEmpty(gridView_thongso.GetRowCellValue(e.RowHandle, "Stt").ToString()))
                        thongSo.Stt = Convert.ToByte(gridView_thongso.GetRowCellValue(e.RowHandle, "Stt").ToString());
                    else
                        thongSo.Stt = 0;
                    thongSo.GiaTri = gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTri").ToString();
                    thongSo.DonViTinh = gridView_thongso.GetRowCellValue(e.RowHandle, "DonViTinh").ToString();
                    if (string.IsNullOrEmpty(gridView_thongso.GetRowCellValue(e.RowHandle, "isLocked").ToString()))
                        thongSo.isLocked = false;
                    else
                        thongSo.isLocked = Convert.ToBoolean(gridView_thongso.GetRowCellValue(e.RowHandle, "isLocked").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (!BioBLL.CheckExistThongSo(thongSo.IDThongSoXN))
                        {
                            XtraMessageBox.Show("Đã tồn tại mã thông số xét nghiệm!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.gridControl_thongso.DataSource = BioBLL.GetListThongSoXN();
                            return;
                        }
                        if (BioBLL.InsThongSoXN(thongSo))
                        {
                            XtraMessageBox.Show("Thêm mới thông số xét nghiệm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm mới thông số xét nghiệm thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (BioBLL.GetThongSoXNById(Convert.ToInt32(thongSo.RowIDThongSo)).IDThongSoXN != thongSo.IDThongSoXN)
                        {
                            if (!BioBLL.CheckExistThongSo(thongSo.IDThongSoXN))
                            {
                                XtraMessageBox.Show("Đã tồn tại mã thông số xét nghiệm!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.gridControl_thongso.DataSource = BioBLL.GetListThongSoXN();
                                return;
                            }
                        }
                        if (BioBLL.UpdThongSo(thongSo))
                        {
                            XtraMessageBox.Show("Cập nhật thông số xét nghiệm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật thông số xét nghiệm thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_thongso.DataSource = BioBLL.GetListThongSoXN();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thao tác thất bại thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gridControl_thongso.DataSource = BioBLL.GetListThongSoXN();
            }
        }

        private void gridControl_thongso_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_thongso.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                XtraMessageBox.Show("Danh mục không thể xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}