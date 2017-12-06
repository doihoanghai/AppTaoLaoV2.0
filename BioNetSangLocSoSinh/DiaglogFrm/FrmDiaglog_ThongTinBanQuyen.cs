using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using DLLLicensePS;
using DataSync.BioNetSync;
using BioNetModel.Data;
using BioNetBLL;




namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmDiaglog_ThongTinBanQuyen : DevExpress.XtraEditors.XtraForm
    {
        public FrmDiaglog_ThongTinBanQuyen()
        {               
            InitializeComponent();
        }
        private PSThongTinTrungTam TrungTam;
        private DateTime NgayServer;
        private string str = @"{0} ngày";
        private void checkVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.txtVersion.Text = fvi.FileVersion;

        }
        private void LoadNgayServer()
        {
            try
            {
                this.NgayServer = BioNet_Bus.GetDateTime();
            }
            catch { }
        }
        private void LoadCheckLicense()
        {
            DLLLicensePS.Reponse res = DLLLicensePS.DECRYPT.CheckLisences(TrungTam.ID, string.Empty, TrungTam.LicenseKey, this.NgayServer.Date.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyy"));
            switch (res.KindOfLisence)
            {
                case 1:
                    this.txtBanQuyen.Text = "Dùng thử";
                    break;
                case 2:
                    this.txtBanQuyen.Text = "Đã chứng thực";
                    break;
                case 3:
                    this.txtBanQuyen.Text = "Miễn phí";
                    break;
                default:
                    this.txtBanQuyen.Text = "Không hợp lệ";
                    break;
            }

            this.txtThoiGian.Text = string.Format(this.str, res.TimeRemind);
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadGethongTinTrungTam()
        {
            try
            {
                this.TrungTam = BioNet_Bus.GetThongTinTrungTam();
            }
            catch (Exception ex) { }
        }
        private void LoadFrom()
        {

            this.LoadNgayServer();
            this.LoadGethongTinTrungTam();
            this.checkVersion();
            if (TrungTam != null)
            {
                this.LoadCheckLicense();
                this.txtTenTrungTam.Text = this.TrungTam.TenTrungTam;
            }
            else
            {
                XtraMessageBox.Show("Không lấy được dữ liệu bản quyền, Vui lòng đăng nhập lại phần mềm!", "BioNet Sàng Lọc Sơ Sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmDiaglog_ThongTinBanQuyen_Load(object sender, EventArgs e)
        {
            this.LoadFrom();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DiaglogFrm.FrmDiaglogAddKey frm = new FrmDiaglogAddKey();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                this.LoadFrom();
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            var res = ThongTinTrungTamSync.GetThongTinTrungTam();
            if (!string.IsNullOrEmpty(res.StringError))
            {
                XtraMessageBox.Show(res.StringError, "BioNet Sàng Lọc Sơ Sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                XtraMessageBox.Show("Cập nhật thông tin thành công! Vui lòng đăng nhập lại.", "BioNet Sàng Lọc Sơ Sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}