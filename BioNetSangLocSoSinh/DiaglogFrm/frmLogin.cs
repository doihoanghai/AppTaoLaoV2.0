using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetBLL;

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public string _EmployeeCode = string.Empty;
        public string _fullname = string.Empty;
        public string _username = string.Empty;
        public bool cancel = false;
        public string shiftCode = string.Empty;
        public DateTime dtimeServer = new DateTime();
        public FrmLogin()
        {
            InitializeComponent();
            this.txtUsername.Focus();
        }

        private void butCANCEL_Click(object sender, EventArgs e)
        {
            this.cancel = true;
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUsername.Text == string.Empty)
                {
                    XtraMessageBox.Show("Tên đăng nhập không được để trống!", "Bionet - Sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUsername.Focus();
                    return;
                }
                if (this.txtPassword.Text == string.Empty)
                {
                    XtraMessageBox.Show("Mật khẩu không được để trống!", "Bionet - Sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPassword.Focus();
                    return;
                }
                if (txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
                {
                    string pass = BioBLL.GetMD5(txtPassword.Text);
                    bool bCheckLogin = BioBLL.CheckLogin(txtUsername.Text, pass);
                    if (bCheckLogin)
                    {
                        this._EmployeeCode = BioBLL.GetEmployeeCode(txtUsername.Text);
                        this.Close();
                        
                    }
                    else
                    {
                        XtraMessageBox.Show("Sai thông tin đăng nhập!", "Bionet - Sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtUsername.Focus();
                        this._username = string.Empty;
                        this._fullname = string.Empty;
                        this._EmployeeCode = string.Empty;
                        this.shiftCode = string.Empty;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Chưa kết nối với dữ liệu!\t\n-Liên hệ quản trị để kiểm tra chi tiết:\t\n" + ex.ToString(), "Bionet - Sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //var firstInfo = ClinicInformationBLL.ObjInformation(1);
                //string timeRuntime = Utils.TimeServer();
                //if (Convert.ToDateTime(timeRuntime) >= Convert.ToDateTime(firstInfo.WorkingTimeLineFrom01) && Convert.ToDateTime(timeRuntime) <= Convert.ToDateTime(firstInfo.WorkingTimeLineTo01))
                //    this.cboxWorkShift.SelectedValue = "AM";
                //else if (Convert.ToDateTime(timeRuntime) >= Convert.ToDateTime(firstInfo.WorkingTimeLineFrom02) && Convert.ToDateTime(timeRuntime) <= Convert.ToDateTime(firstInfo.WorkingTimeLineTo02))
                //    this.cboxWorkShift.SelectedValue = "PM";
                //else
                //    this.cboxWorkShift.SelectedValue = this.dtimeServer.ToString("tt");
            }
            catch {  }
        }
    }
}