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

namespace BioNetSangLocSoSinh
{
    public partial class FrmDiaglogSuaPhieuDaTiepNhan : DevExpress.XtraEditors.XtraForm
    {
        
        public FrmDiaglogSuaPhieuDaTiepNhan(string maPhieu,string maDonVi)
        {
            InitializeComponent();
            this._maPhieu = maPhieu;
            this._maDonVi = maDonVi;
        }
        public string _maPhieu = string.Empty;
        public string _maDonVi = string.Empty;
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
            this._maDonVi = this.barCodePhieu.Text;
            this._maDonVi = searchLookUpDonViCoSo.EditValue.ToString();
            this.DialogResult = DialogResult.OK;
            this.Dispose();
            this.Close();
           
        }
    }
}