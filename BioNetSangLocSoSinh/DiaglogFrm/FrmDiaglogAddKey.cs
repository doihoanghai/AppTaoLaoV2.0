using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DLLLicensePS;
using BioNetBLL;
using BioNetModel.Data;

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmDiaglogAddKey : DevExpress.XtraEditors.XtraForm
    {
        public FrmDiaglogAddKey()
        {
            InitializeComponent();
            this.LoadNgayServer();
            this.LoadGethongTinTrungTam();
        }
        private DateTime NgayServer;

        private PSThongTinTrungTam TrungTam;

        private void LoadNgayServer()
        {
            try
            {
                this.NgayServer = BioNet_Bus.GetDateTime();
            }
            catch { }
        }
        private void LoadGethongTinTrungTam()
        {
            try
            {
                this.TrungTam = BioNet_Bus.GetThongTinTrungTam();
            }
            catch (Exception ex) { }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAddKey_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.txtLicense.Text.Trim()))
            {
                DLLLicensePS.Reponse res = DLLLicensePS.DECRYPT.CheckLisences(this.TrungTam.ID, string.Empty, this.txtLicense.Text.Trim(), this.NgayServer.Date.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyyy"));
                if(res!=null)
                {
                    if(res.TimeRemind>0)
                    {
                        var submit = BioNet_Bus.CapNhatLisence(this.txtLicense.Text.Trim());
                        if (submit.Result)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show(submit.StringError, "BioNet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(res.ResultString))
                        {
                            XtraMessageBox.Show("Key này đã hết hạn, vui lòng thử key khác!", "BioNet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(res.ResultString, "BioNet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}