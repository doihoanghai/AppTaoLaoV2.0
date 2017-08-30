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
    public partial class FrmDMDanhGiaChatLuongMau : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMDanhGiaChatLuongMau()
        {
            InitializeComponent();
        }

        private void FrmDMDanhGiaChatLuongMau_Load(object sender, EventArgs e)
        {
            gridControl_DanhGiaChatLuongMau.DataSource = BioBLL.GetListDanhGia();
        }

        private void gridView_DanhGiaChatLuongMau_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_IDDanhGiaChatLuongMau))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_IDDanhGiaChatLuongMau, "Mã đánh giá không được để trống!");
                }
                if (view.GetRowCellValue(rowfocus, col_th_IDDanhGiaChatLuongMau).ToString().Length > 5)
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_IDDanhGiaChatLuongMau, "Mã đánh giá không quá 5 ký tự!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_ChatLuongMau))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_ChatLuongMau, "Chất lượng mẫu không được để trống!");
                }
                if (e.Valid)
                {
                    PSDanhMucDanhGiaChatLuongMau danhGia = new PSDanhMucDanhGiaChatLuongMau();
                    if (string.IsNullOrEmpty(gridView_DanhGiaChatLuongMau.GetRowCellValue(e.RowHandle, "RowIDChatLuongMau").ToString()))
                        danhGia.RowIDChatLuongMau = 0;
                    else
                        danhGia.RowIDChatLuongMau = Convert.ToByte(gridView_DanhGiaChatLuongMau.GetRowCellValue(e.RowHandle, "RowIDChatLuongMau").ToString());
                    danhGia.IDDanhGiaChatLuongMau = gridView_DanhGiaChatLuongMau.GetRowCellValue(e.RowHandle, "IDDanhGiaChatLuongMau").ToString();
                    danhGia.ChatLuongMau = gridView_DanhGiaChatLuongMau.GetRowCellValue(e.RowHandle, "ChatLuongMau").ToString();
                    if (string.IsNullOrEmpty(gridView_DanhGiaChatLuongMau.GetRowCellValue(e.RowHandle, "isLocked").ToString()))
                        danhGia.isLocked = false;
                    else
                        danhGia.isLocked = Convert.ToBoolean(gridView_DanhGiaChatLuongMau.GetRowCellValue(e.RowHandle, "isLocked").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (!BioBLL.CheckExistMaDanhGia(danhGia.IDDanhGiaChatLuongMau))
                        {
                            XtraMessageBox.Show("Đã tồn tại mã đánh giá!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.gridControl_DanhGiaChatLuongMau.DataSource = BioBLL.GetListDanhGia();
                            return;
                        }
                        if (BioBLL.InsDanhGia(danhGia))
                        {
                            XtraMessageBox.Show("Thêm mới đánh giá chất lượng mẫu thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm mới đánh giá chất lượng mẫu thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (BioBLL.GetDanhGiaById(Convert.ToInt32(danhGia.RowIDChatLuongMau)).IDDanhGiaChatLuongMau != danhGia.IDDanhGiaChatLuongMau)
                        {
                            if (!BioBLL.CheckExistMaDanhGia(danhGia.IDDanhGiaChatLuongMau))
                            {
                                XtraMessageBox.Show("Đã tồn tại mã đánh giá!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.gridControl_DanhGiaChatLuongMau.DataSource = BioBLL.GetListDanhGia();
                                return;
                            }
                        }
                        if (BioBLL.UpdDanhGia(danhGia))
                        {
                            XtraMessageBox.Show("Cập nhật đánh giá thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật đánh giá thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_DanhGiaChatLuongMau.DataSource = BioBLL.GetListDanhGia();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thao tác thất bại thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gridControl_DanhGiaChatLuongMau.DataSource = BioBLL.GetListDanhGia();
            }
        }

        private void gridControl_DanhGiaChatLuongMau_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_DanhGiaChatLuongMau.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa danh mục này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (BioBLL.DelDanhGia(Convert.ToInt32(gridView_DanhGiaChatLuongMau.GetRowCellValue(gridView_DanhGiaChatLuongMau.FocusedRowHandle, "RowIDChatLuongMau").ToString())))
                            this.gridControl_DanhGiaChatLuongMau.DataSource = BioBLL.GetListDanhGia();
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