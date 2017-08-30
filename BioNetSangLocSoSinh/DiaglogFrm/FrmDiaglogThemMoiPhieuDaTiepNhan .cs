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
using BioNetModel.Data;
using BioNetModel;

namespace BioNetSangLocSoSinh
{
    public partial class FrmDiaglogThemMoiPhieuDaTiepNhan : DevExpress.XtraEditors.XtraForm
    {
        
        public FrmDiaglogThemMoiPhieuDaTiepNhan(List<PSTiepNhan> lstTiepNhan)
        {
            InitializeComponent();
            this.lstDaTiepNhan = lstTiepNhan;
        }
        public string _maPhieu = string.Empty;
        public string _maDonVi = string.Empty;
        private List<PSTiepNhan> lstDaTiepNhan = new List<PSTiepNhan>(); //danh sach phieu được nhân viên tiếp nhận
        private List<PSTiepNhan> lstTiepNhanTiepNhanMoi = new List<PSTiepNhan>();
        private void LoadSearchLookUpDoViCoSo()
        {
            try
            {
                this.searchLookUpDonViCoSo.Properties.DataSource = BioNet_Bus.GetDanhSachDonViCoSo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi load danh sách đơn vị cơ sở \r\n Lỗi chi tiết :" + ex.ToString(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.searchLookUpDonViCoSo.Focus();
            }
        }
        private void FrmDiaglogSuaPhieuDaTiepNhan_Load(object sender, EventArgs e)
        {
            this.LoadSearchLookUpDoViCoSo();
            this.barCodePhieu.Text = this._maPhieu;
            this.searchLookUpDonViCoSo.EditValue = this._maDonVi;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.lstDaTiepNhan.FindAll(p => p.MaPhieu == txtMaPhieu.Text).Count > 0)
            {
                XtraMessageBox.Show(" Phiếu này đã được nhập rồi!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this._maDonVi = this.searchLookUpDonViCoSo.EditValue.ToString();
            this._maPhieu = this.txtMaPhieu.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
            this.Close();
        }

        private void txtMaPhieu_Validated(object sender, EventArgs e)
        {
            this.barCodePhieu.Text = this.txtMaPhieu.Text;
        }
    }
}