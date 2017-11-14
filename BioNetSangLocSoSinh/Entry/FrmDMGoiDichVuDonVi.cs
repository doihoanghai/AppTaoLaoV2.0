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
    public partial class FrmDMGoiDichVuDonVi : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMGoiDichVuDonVi()
        {
            InitializeComponent();
        }

        private void FrmDMGoiDichVuDonVi_Load(object sender, EventArgs e)
        {
            this.repositoryItemLookUpEdit_DonViCoSo.DataSource = BioBLL.GetListDonViCoSo();
            this.repositoryItemLookUpEdit_DonViCoSo.ValueMember = "MaDVCS";
            this.repositoryItemLookUpEdit_DonViCoSo.DisplayMember = "TenDVCS";

            this.repositoryItemLookUpEdit_GoiDVChung.DataSource = BioBLL.GetListGoiDichVuChung();
            this.repositoryItemLookUpEdit_GoiDVChung.ValueMember = "IDGoiDichVuChung";
            this.repositoryItemLookUpEdit_GoiDVChung.DisplayMember = "TenGoiDichVuChung";

            //this.gridControl_GoiDVDonvi.DataSource = BioBLL.GetListGoiDichVuCoSo();
            this.gridControl_GoiDVDonvi.DataSource = BioBLL.GetListGoiDichVuTheoDonVi();
        }

        private void gridView_GoiDVDonvi_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                //if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_TenGoiDichVuTrungTam))))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_th_TenGoiDichVuTrungTam, "Tên gói không được để trống!");
                //}
                //if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_IDGoiDichVuChung))))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_th_IDGoiDichVuChung, "Hãy chọn gói dịch vụ chung!");
                //}
                //if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_th_MaDVCS))))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_th_MaDVCS, "Hãy chọn đơn vị cơ sở!");
                //}
                if (e.Valid)
                {
                    PSDanhMucGoiDichVuTheoDonVi goiDVCoSo = new PSDanhMucGoiDichVuTheoDonVi();
                    //if (string.IsNullOrEmpty(gridView_GoiDVDonvi.GetRowCellValue(e.RowHandle, "RowIDGoiDichVuTrungTam").ToString()))
                    //    goiDVCoSo.RowIDGoiDichVuTrungTam = 0;
                    //else
                    goiDVCoSo.RowIDGoiDichVuTrungTam = Convert.ToInt32(gridView_GoiDVDonvi.GetRowCellValue(e.RowHandle, "RowIDGoiDichVuTrungTam").ToString());
                    goiDVCoSo.TenGoiDichVuChung = gridView_GoiDVDonvi.GetRowCellValue(e.RowHandle, "TenGoiDichVuChung").ToString();
                    goiDVCoSo.IDGoiDichVuChung = gridView_GoiDVDonvi.GetRowCellValue(e.RowHandle, "IDGoiDichVuChung").ToString();
                    goiDVCoSo.MaDVCS = gridView_GoiDVDonvi.GetRowCellValue(e.RowHandle, "MaDVCS").ToString();
                
                    if (string.IsNullOrEmpty(gridView_GoiDVDonvi.GetRowCellValue(e.RowHandle, "ChietKhau").ToString()))
                        goiDVCoSo.ChietKhau = 0;
                    else
                        goiDVCoSo.ChietKhau = Convert.ToDouble(gridView_GoiDVDonvi.GetRowCellValue(e.RowHandle, "ChietKhau").ToString());
                    if (string.IsNullOrEmpty(gridView_GoiDVDonvi.GetRowCellValue(e.RowHandle, "DonGia").ToString()))
                        goiDVCoSo.DonGia = 0;
                    else
                        goiDVCoSo.DonGia = Convert.ToDecimal(gridView_GoiDVDonvi.GetRowCellValue(e.RowHandle, "DonGia").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (!BioBLL.CheckExistGoiTheoDonVi(goiDVCoSo.IDGoiDichVuChung, goiDVCoSo.MaDVCS))
                        {
                            XtraMessageBox.Show("Đã tồn tại gói theo đơn vị!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.gridControl_GoiDVDonvi.DataSource = BioBLL.GetListGoiDichVuCoSo();
                            return;
                        }
                        if (BioBLL.InsGoiDichVuCoSo(goiDVCoSo))
                        {
                            XtraMessageBox.Show("Thêm mới gói dịch vụ theo đơn vị cơ sở thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm mới gói dịch vụ theo đơn vị cơ sở thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        PSDanhMucGoiDichVuTheoDonVi goiDVCoSoOld = BioBLL.GetGoiDichVuCoSoById(Convert.ToInt32(goiDVCoSo.RowIDGoiDichVuTrungTam));
                        if (goiDVCoSoOld.IDGoiDichVuChung != goiDVCoSo.IDGoiDichVuChung || goiDVCoSoOld.MaDVCS != goiDVCoSo.MaDVCS)
                        {
                            if (!BioBLL.CheckExistGoiTheoDonVi(goiDVCoSo.IDGoiDichVuChung, goiDVCoSo.MaDVCS))
                            {
                                XtraMessageBox.Show("Đã tồn tại gói theo đơn vị!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.gridControl_GoiDVDonvi.DataSource = BioBLL.GetListGoiDichVuCoSo();
                                return;
                            }
                        }
                        if (BioBLL.UpdGoiDichVuCoSo(goiDVCoSo))
                        {
                            XtraMessageBox.Show("Cập nhật gói dịch vụ theo đơn vị cơ sở thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật gói dịch vụ theo đơn vị cơ sở thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.gridControl_GoiDVDonvi.DataSource = BioBLL.GetListGoiDichVuTheoDonVi();
                }
            }
            catch
            {

            }
        }

        //private void gridControl_GoiDVDonvi_ProcessGridKey(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Delete && gridView_GoiDVDonvi.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
        //    {
        //        if (XtraMessageBox.Show("Bạn có muốn xóa danh mục này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
        //        {
        //            try
        //            {
        //                if (BioBLL.DelGoiDichVuCoSo(Convert.ToInt32(gridView_GoiDVDonvi.GetRowCellValue(gridView_GoiDVDonvi.FocusedRowHandle, "RowIDGoiDichVuTrungTam").ToString())))
        //                    this.gridControl_GoiDVDonvi.DataSource = BioBLL.GetListGoiDichVuCoSo();
        //            }
        //            catch
        //            {
        //                XtraMessageBox.Show("Xóa danh mục thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //        }
        //    }
        //}

        //private void repositoryItemLookUpEdit_GoiDVChung_EditValueChanged(object sender, EventArgs e)
        //{
        //    //LookUpEdit view = sender as LookUpEdit;
        //    //string tenGoi = view.Text;
        //    //gridView_GoiDVDonvi.SetFocusedRowCellValue(col_th_TenGoiDichVuTrungTam, tenGoi);
        //}
    }
}