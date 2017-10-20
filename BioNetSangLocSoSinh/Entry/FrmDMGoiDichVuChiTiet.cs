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
using DataSync;
using BioNetModel.Data;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmDMGoiDichVuChiTiet : DevExpress.XtraEditors.XtraForm
    {
        private string idServicePackage = string.Empty;
        private DataTable dtGoiDV = new DataTable();
        public FrmDMGoiDichVuChiTiet()
        {
            InitializeComponent();
        }

        private void FrmDMGoiDichVuChiTiet_Load(object sender, EventArgs e)
        {
            gridControl_GoiDichVuChung.DataSource = BioBLL.GetListGoiDichVuChung();

            this.dtGoiDV = BioBLL.GetListDichVu();
            this.dtGoiDV.Columns.Add("Check", typeof(bool));
            foreach (DataRow row in this.dtGoiDV.Rows)
                row["Check"] = false;
            gridControl_DichVu.DataSource = this.dtGoiDV;
        }

        private void gridView_GoiDichVuChung_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            this.idServicePackage = gridView_GoiDichVuChung.GetRowCellValue(gridView_GoiDichVuChung.FocusedRowHandle, col_th_IDGoiDichVuChung).ToString();
            CheckService(this.idServicePackage);
        }

        private void CheckService(string id)
        {
            List<string> lstService = new List<string>();
            lstService = BioBLL.GetListServicePackageByIDGoi(id).Select(x => x.IDDichVu).ToList();
            foreach (DataRow row in this.dtGoiDV.Rows)
            {
                if(lstService.Contains(row["IDDichVu"].ToString()))
                    row["Check"] = true;
                else
                    row["Check"] = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.idServicePackage))
            {
                XtraMessageBox.Show("Chưa chọn gói dịch vụ!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> lstService = new List<string>();
            foreach (DataRow row in this.dtGoiDV.Rows)
            {
                if (Convert.ToBoolean(row["Check"]))
                    lstService.Add(row["IDDichVu"].ToString());
            }
            if(BioBLL.UpdDetailServicePackage(this.idServicePackage, lstService))
            {
                XtraMessageBox.Show("Cập nhật chi tiết gói dịch vụ thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Cập nhật chi tiết gói dịch vụ thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckService(this.idServicePackage);
            }
        }

        private void btnLuuSTT_Click(object sender, EventArgs e)
        {
            try {
              
                List<PSDanhMucGoiDichVuChung> dt = (List<PSDanhMucGoiDichVuChung>)gridControl_GoiDichVuChung.DataSource;
                bool kq = BioBLL.UpdateGoiDV(dt);
                if(kq==true)
                {
                    XtraMessageBox.Show("Cập nhật số thứ tự thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(kq==false)
                {
                    XtraMessageBox.Show("Cập nhật số thứ tự thất bại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch(Exception ex)
            {

            }
               
        }
    }
}