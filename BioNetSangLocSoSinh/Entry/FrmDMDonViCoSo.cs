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
using BioNetSangLocSoSinh.DiaglogFrm;
using System.IO;
using DevExpress.XtraGrid.Columns;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmDMDonViCoSo : DevExpress.XtraEditors.XtraForm
    {
        private string codeGenOld = string.Empty;
        public FrmDMDonViCoSo()
        {
            InitializeComponent();
        }

        private void FrmDMDonViCoSo_Load(object sender, EventArgs e)
        {
            this.repositoryItemLookUpEdit_ChiCuc.DataSource = BioBLL.GetListChiCuc();
            this.repositoryItemLookUpEdit_ChiCuc.ValueMember = "MaChiCuc";
            this.repositoryItemLookUpEdit_ChiCuc.DisplayMember = "TenChiCuc";

            DataTable dtkq = new DataTable();
            dtkq.Columns.Add("id", typeof(int));
            dtkq.Columns.Add("name", typeof(string));
            dtkq.Rows.Add(1, "Theo trung tâm");
            dtkq.Rows.Add(2, "Theo đơn vị");
            dtkq.Rows.Add(3, "Theo đơn vị kiểu 2");
            this.repositoryItemLookUpEdit_KieuTraKetQua.DataSource = dtkq;
            this.repositoryItemLookUpEdit_KieuTraKetQua.DisplayMember = "name";
            this.repositoryItemLookUpEdit_KieuTraKetQua.ValueMember = "id";

            this.gridControl_DonViCoSo.DataSource = BioBLL.GetListDonViCoSo();
        }

        private void gridView_DonViCoSo_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_TenDVCS))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_TenDVCS, "Tên đơn vị cơ sở không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_MaChiCuc))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_th_MaChiCuc, "Chi cục không được để trống!");
                }
                if (e.Valid)
                {
                    byte[] byteNull = ASCIIEncoding.ASCII.GetBytes("");
                    PSDanhMucDonViCoSo donVi = new PSDanhMucDonViCoSo();
                    if (string.IsNullOrEmpty(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "RowIDDVCS").ToString()))
                        donVi.RowIDDVCS = 0;
                    else
                        donVi.RowIDDVCS = Convert.ToInt16(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "RowIDDVCS").ToString());
                    donVi.MaDVCS = gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "MaDVCS").ToString();
                    donVi.TenDVCS = gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "TenDVCS").ToString();
                    donVi.DiaChiDVCS = gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "DiaChiDVCS").ToString();
                    donVi.SDTCS = gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "SDTCS").ToString();
                    if (string.IsNullOrEmpty(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "Logo").ToString()))
                        donVi.Logo = new Binary(byteNull);
                    else
                        donVi.Logo = (Binary)gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "Logo");
                    if(string.IsNullOrEmpty(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "HeaderReport").ToString()))
                        donVi.HeaderReport = new Binary(byteNull);
                    else
                        donVi.HeaderReport = (Binary)gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "HeaderReport");
                    if (string.IsNullOrEmpty(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "Stt").ToString()))
                        donVi.Stt = 0;
                    else
                        donVi.Stt = Convert.ToInt16(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "Stt").ToString());
                    if (string.IsNullOrEmpty(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "isLocked").ToString()))
                        donVi.isLocked = false;
                    else
                        donVi.isLocked = Convert.ToBoolean(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "isLocked").ToString());
                    
                    donVi.MaChiCuc = gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "MaChiCuc").ToString();
                    if (string.IsNullOrEmpty(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "KieuTraKetQua").ToString()))
                        donVi.KieuTraKetQua = 1;
                    else
                        donVi.KieuTraKetQua = int.Parse(gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "KieuTraKetQua").ToString());
                                donVi.TenBacSiDaiDien = gridView_DonViCoSo.GetRowCellValue(e.RowHandle, "TenBacSiDaiDien").ToString();
                    donVi.isDongBo = false;
                    if (e.RowHandle < 0)
                    {
                        string codeGen = BioBLL.GetCodeDonViCoSo(donVi.MaChiCuc);
                        this.codeGenOld = codeGen.ToString();
                        if (XtraMessageBox.Show("Danh mục đơn vị cs bạn thêm có mã tự động là " + codeGen + " bạn có muốn thay đổi không?", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            int result = 0;
                            do
                            {
                                codeGen = this.InputForm(codeGen);
                                if (CheckCodeExist(codeGen))
                                {
                                    donVi.MaDVCS = codeGen;
                                    result = 0;
                                }
                                else
                                {
                                    result = 1;
                                    codeGen = this.codeGenOld;
                                }
                            } while (result == 1);
                        }
                        else
                            donVi.MaDVCS = codeGen;
                        if (BioBLL.InsDonViCS(donVi))
                        {
                            XtraMessageBox.Show("Thêm mới đơn vị cơ sở thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (XtraMessageBox.Show("Hệ thống tự động thêm dịch vụ vào đơn vị này. \nBạn có muốn thực hiện tác vụ này không?", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                            {
                                List<PSDanhMucGoiDichVuChung> lstGoiDV = BioBLL.GetListGoiDichVuChung();
                                List<PSDanhMucGoiDichVuTheoDonVi> lstGoiTT = new List<PSDanhMucGoiDichVuTheoDonVi>();
                                List<PSChiTietGoiDichVuChung> lstChiTietGoiGV = BioBLL.GetListChiTietGoiDichVuChung();
                                foreach(var dv in lstGoiDV)
                                {
                                    PSDanhMucGoiDichVuTheoDonVi tt = new PSDanhMucGoiDichVuTheoDonVi();
                                    tt.IDGoiDichVuChung = dv.IDGoiDichVuChung;
                                    tt.MaDVCS = donVi.MaDVCS;
                                    tt.TenGoiDichVuChung = dv.TenGoiDichVuChung;
                                    tt.DonGia = dv.DonGia??0;
                                    tt.ChietKhau =dv.ChietKhau?? 0;
                                    tt.isXoa = false;
                                    tt.isDongBo = false;
                                    lstGoiTT.Add(tt);
                                }
                                if(!BioBLL.InsMultiGoiDichVuCoSo(lstGoiTT))
                                    XtraMessageBox.Show("Tự động thêm dịch vụ vào đơn vị thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm mới đơn vị cơ sở thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        PSDanhMucDonViCoSo dvOld = BioBLL.GetDonViCoSoById(donVi.RowIDDVCS);
                        if (BioBLL.UpdDonViCS(donVi))
                        {
                            PSDanhMucDonViCoSo dvNew = BioBLL.GetDonViCoSoById(donVi.RowIDDVCS);
                            if (dvOld.MaChiCuc != donVi.MaChiCuc)
                                XtraMessageBox.Show("Thay đổi mã đơn vị " + donVi.MaDVCS + " thành " + dvNew.MaDVCS+ " thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XtraMessageBox.Show("Cập nhật đơn vị cơ sở thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật đơn vị cơ sở thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_DonViCoSo.DataSource = BioBLL.GetListDonViCoSo();
                }
            }
            catch { XtraMessageBox.Show("Thao tác thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool CheckCodeExist(string maDonViCS)
        {
            if (!BioBLL.CheckExistCodeDVCS(maDonViCS))
            {
                XtraMessageBox.Show("Mã đơn vị cơ sở đã tồn tại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private string InputForm(string codeGen)
        {
            FrmInputCode frm = new FrmInputCode(codeGen.Substring(5, 3), codeGen.Substring(0, 5), 3);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                codeGen = frm.name + frm.code;
            return codeGen;
        }

        private void gridControl_DonViCoSo_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_DonViCoSo.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa danh mục này hay không?", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (BioBLL.DelDonViCS(gridView_DonViCoSo.GetRowCellValue(gridView_DonViCoSo.FocusedRowHandle, "MaDVCS").ToString()))
                            this.gridControl_DonViCoSo.DataSource = BioBLL.GetListDonViCoSo();
                        else
                            XtraMessageBox.Show("Xóa danh mục thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        XtraMessageBox.Show("Xóa danh mục thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void repositoryItemPictureEdit_header_Click(object sender, EventArgs e)
        {
            fileHeader.ShowHelp = true;
            fileHeader.FileName = string.Empty;
            fileHeader.Filter = "Images (*.jpg)|*.jpg|All Files(*.*)|*.*";
            fileHeader.ShowDialog();
        }

        private void fileLogo_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                var fileBytes = File.ReadAllBytes(fileLogo.FileName);
                var image = new Binary(fileBytes);
                gridView_DonViCoSo.SetFocusedRowCellValue(col_th_Logo, image);
            }
            catch { }
        }

        private void fileHeader_FileOk(object sender, CancelEventArgs e)
        {
            try
            {

                var fileBytes = File.ReadAllBytes(fileHeader.FileName);
                var image = new Binary(fileBytes);
                gridView_DonViCoSo.SetFocusedRowCellValue(col_th_HeaderReport, image);
            }
            catch { }
        }

        private void gridView_DonViCoSo_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridColumn column = e.Column;
                if (column.Name == this.col_th_MaDVCS.Name)
                {
                    string code = e.CellValue.ToString();
                    if (XtraMessageBox.Show("Bạn có muốn thay đổi mã " + code + " không?", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        int result = 0;
                        do
                        {
                            FrmInputCode frm = new FrmInputCode(code.Substring(5, 3), code.Substring(0, 5), 3);
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                            {
                                code = frm.name + frm.code;
                                if (CheckCodeExist(code))
                                {
                                    result = 0;
                                    gridView_DonViCoSo.SetRowCellValue(e.RowHandle, e.Column, code);
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