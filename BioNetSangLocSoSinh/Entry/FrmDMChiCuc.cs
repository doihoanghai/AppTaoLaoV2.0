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
using System.Data.Linq;
using System.IO;
using DevExpress.XtraEditors.Controls;
using BioNetSangLocSoSinh.DiaglogFrm;
using DevExpress.XtraGrid.Columns;


namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmDMChiCuc : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMChiCuc()
        {
            InitializeComponent();
        }

        private void FrmDMChiCuc_Load(object sender, EventArgs e)
        {
            this.gridControl_ChiCuc.DataSource = BioBLL.GetListChiCuc();
        }

        private void gridView_ChiCuc_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_TenChiCuc))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_TenChiCuc, "Tên chi cục không được để trống!");
                }
                if (e.Valid)
                {
                    byte[] byteNull = ASCIIEncoding.ASCII.GetBytes("");
                    PSDanhMucChiCuc chiCuc = new PSDanhMucChiCuc();
                    if (string.IsNullOrEmpty(gridView_ChiCuc.GetRowCellValue(e.RowHandle, "RowIDChiCuc").ToString()))
                        chiCuc.RowIDChiCuc = 0;
                    else
                        chiCuc.RowIDChiCuc = Convert.ToInt32(gridView_ChiCuc.GetRowCellValue(e.RowHandle, "RowIDChiCuc").ToString());
                    chiCuc.MaChiCuc = gridView_ChiCuc.GetRowCellValue(e.RowHandle, "MaChiCuc").ToString();
                    chiCuc.TenChiCuc = gridView_ChiCuc.GetRowCellValue(e.RowHandle, "TenChiCuc").ToString();
                    chiCuc.DiaChiChiCuc = gridView_ChiCuc.GetRowCellValue(e.RowHandle, "DiaChiChiCuc").ToString();
                    chiCuc.SdtChiCuc = gridView_ChiCuc.GetRowCellValue(e.RowHandle, "SdtChiCuc").ToString();
                    if (string.IsNullOrEmpty(gridView_ChiCuc.GetRowCellValue(e.RowHandle, "Logo").ToString()))
                        chiCuc.Logo = new Binary(byteNull);
                    else
                        chiCuc.Logo = (Binary)gridView_ChiCuc.GetRowCellValue(e.RowHandle, "Logo");
                    if (string.IsNullOrEmpty(gridView_ChiCuc.GetRowCellValue(e.RowHandle, "HeaderReport").ToString()))
                        chiCuc.HeaderReport = new Binary(byteNull);
                    else
                        chiCuc.HeaderReport = (Binary)gridView_ChiCuc.GetRowCellValue(e.RowHandle, "HeaderReport");
                    if (string.IsNullOrEmpty(gridView_ChiCuc.GetRowCellValue(e.RowHandle, "Stt").ToString()))
                        chiCuc.Stt = 0;
                    else
                        chiCuc.Stt = Convert.ToInt16(gridView_ChiCuc.GetRowCellValue(e.RowHandle, "Stt").ToString());
                    if (string.IsNullOrEmpty(gridView_ChiCuc.GetRowCellValue(e.RowHandle, "isLocked").ToString()))
                        chiCuc.isLocked = false;
                    else
                        chiCuc.isLocked = Convert.ToBoolean(gridView_ChiCuc.GetRowCellValue(e.RowHandle, "isLocked").ToString());
                    if (e.RowHandle < 0)
                    {
                        string codeGen = BioBLL.GetCodeChiCuc();
                        if (XtraMessageBox.Show("Danh mục chi cục bạn thêm có mã tự động là " + codeGen + " bạn có muốn thay đổi không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            int result = 0;
                            do
                            {
                                codeGen = this.InputForm(codeGen);
                                if (CheckCodeExist(codeGen))
                                {
                                    chiCuc.MaChiCuc = codeGen;
                                    result = 0;
                                }
                                else
                                    result = 1;
                            } while (result == 1);
                        }
                        else
                            chiCuc.MaChiCuc = codeGen;
                        if (BioBLL.InsChiCuc(chiCuc))
                        {
                            XtraMessageBox.Show("Thêm mới chi cục thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm mới chi cục thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (BioBLL.UpdChiCuc(chiCuc))
                        {
                            XtraMessageBox.Show("Cập nhật chi cục thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật chi cục thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_ChiCuc.DataSource = BioBLL.GetListChiCuc();
                }
            }
            catch{ XtraMessageBox.Show("Thao tác thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool CheckCodeExist(string maChiCuc)
        {
            if (!BioBLL.CheckExistCode(maChiCuc))
            {
                XtraMessageBox.Show("Mã chi cục đã tồn tại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private string InputForm(string codeGen)
        {
            FrmInputCode frm = new FrmInputCode(codeGen.Substring(3, 2), codeGen.Substring(0, 3), 2);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                codeGen = frm.name + frm.code;
            return codeGen;
        }

        private void gridControl_ChiCuc_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_ChiCuc.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa danh mục này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (BioBLL.DelChiCuc(gridView_ChiCuc.GetRowCellValue(gridView_ChiCuc.FocusedRowHandle, "MaChiCuc").ToString()))
                            this.gridControl_ChiCuc.DataSource = BioBLL.GetListChiCuc();
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

        private void repositoryItemPictureEdit_logo_Click(object sender, EventArgs e)
        {
            fileLogo.ShowHelp = true;
            fileLogo.FileName = string.Empty;
            fileLogo.Filter = "Images (*.jpg)|*.jpg|All Files(*.*)|*.*";
            fileLogo.ShowDialog();
        }

        private void repositoryItemPictureEdit_Header_Click(object sender, EventArgs e)
        {
            fileHeader.ShowHelp = true;
            fileHeader.FileName = string.Empty;
            fileHeader.Filter = "Images (*.jpg)|*.jpg|All Files(*.*)|*.*";
            fileHeader.ShowDialog();
        }

        private void fileHeader_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                var fileBytes = File.ReadAllBytes(fileHeader.FileName);
                var image = new Binary(fileBytes);
                gridView_ChiCuc.SetFocusedRowCellValue(col_th_HeaderReport, image);
            }
            catch { }
        }

        private void fileLogo_FileOk(object sender, CancelEventArgs e)
        {
            try
            {

                var fileBytes = File.ReadAllBytes(fileLogo.FileName);
                var image = new Binary(fileBytes);
                gridView_ChiCuc.SetFocusedRowCellValue(col_th_Logo, image);
            }
            catch { }
        }



        private void gridView_ChiCuc_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                GridColumn column = e.Column;
                if (column.Name == this.col_th_MaChiCuc.Name)
                {
                    string code = e.CellValue.ToString();
                    if (XtraMessageBox.Show("Bạn có muốn thay đổi mã " + code + " không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        int result = 0;
                        do
                        {
                            FrmInputCode frm = new FrmInputCode(code.Substring(3, 2), code.Substring(0, 3), 2);
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                            {
                                code = frm.name + frm.code;
                                if (CheckCodeExist(code))
                                {
                                    result = 0;
                                    gridView_ChiCuc.SetRowCellValue(e.RowHandle, e.Column, code);
                                }
                                else
                                    result = 1;
                            }
                            else
                                result = 0;
                        } while (result == 1);
                    }
                }
            }
        }

        
    }
}