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

           // this.gridControl_thongso.DataSource = BioBLL.GetListThongSoXN();
            this.gridControl_thongso.DataSource = BioNet_Bus.GetThongSoXN();
        }

        private void gridView_thongso_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
               
                if (e.Valid)
                {
                    PSDanhMucThongSoXN thongSo = new PSDanhMucThongSoXN();
                    thongSo.RowIDThongSo =Convert.ToInt32((gridView_thongso.GetRowCellValue(e.RowHandle, "RowIDThongSo") ?? String.Empty).ToString());
                    thongSo.IDThongSoXN = (gridView_thongso.GetRowCellValue(e.RowHandle, "IDThongSoXN") ?? String.Empty).ToString();
                    thongSo.TenThongSo = (gridView_thongso.GetRowCellValue(e.RowHandle, "TenThongSo") ?? String.Empty).ToString();
                    thongSo.GiaTriMinNu = Convert.ToDouble((gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMinNu") ?? String.Empty).ToString());
                    thongSo.GiaTriMaxNu = Convert.ToDouble((gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMaxNu") ?? String.Empty).ToString());
                    thongSo.GiaTriTrungBinhNu = (gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriTrungBinhNu") ?? String.Empty).ToString();
                    thongSo.GiaTriMacDinh = (gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMacDinh") ?? String.Empty).ToString();
                    thongSo.GiaTriMinNam = Convert.ToDouble((gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMinNam")??0).ToString());
                    thongSo.GiaTriMaxNam = Convert.ToDouble((gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriMaxNam") ?? 0).ToString());
                    thongSo.GiaTriTrungBinhNam = (gridView_thongso.GetRowCellValue(e.RowHandle, "GiaTriTrungBinhNam")??String.Empty).ToString();
                    thongSo.MaNhom = Convert.ToByte(gridView_thongso.GetRowCellValue(e.RowHandle, "MaNhom").ToString());
                    thongSo.Stt= Convert.ToByte((gridView_thongso.GetRowCellValue(e.RowHandle, col_th_Stt) ?? 0).ToString());
                    thongSo.GiaTri = (gridView_thongso.GetRowCellValue(e.RowHandle, col_GiaTri)??String.Empty).ToString();
                    thongSo.DonViTinh = gridView_thongso.GetRowCellValue(e.RowHandle, "DonViTinh").ToString();
                    //string a = (gridView_thongso.GetRowCellValue(e.RowHandle, col_isLocked) ?? "False").ToString();
                    thongSo.isLocked = (gridView_thongso.GetRowCellValue(e.RowHandle, col_isLocked) ?? "False").ToString()=="True"? true :false;
                    
                    if (e.RowHandle < 0)
                    {
                        if (!BioBLL.CheckExistThongSo(thongSo.IDThongSoXN))
                        {
                            XtraMessageBox.Show("Đã tồn tại mã thông số xét nghiệm!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.gridControl_thongso.DataSource = BioBLL.GetListThongSoXetNghiem();
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
                                this.gridControl_thongso.DataSource = BioNet_Bus.GetThongSoXN();
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
                    this.gridControl_thongso.DataSource = BioNet_Bus.GetThongSoXN();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thao tác thất bại thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gridControl_thongso.DataSource = BioNet_Bus.GetThongSoXN();
            }
        }

        private void gridControl_thongso_ProcessGridKey(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete && gridView_thongso.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            //{
            //    XtraMessageBox.Show("Danh mục không thể xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        
    }
}