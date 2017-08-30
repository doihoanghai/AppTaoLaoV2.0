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

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmChangePass : DevExpress.XtraEditors.XtraForm
    {
        private string empLogin = string.Empty;
        public FrmChangePass(string _empLogin)
        {
            this.empLogin = _empLogin;
            InitializeComponent();
        }

        private void FrmChangePass_Load(object sender, EventArgs e)
        {
            txtPassOld.Focus();
        }

        private void txtPassOld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtPassNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtPassConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void ClearText()
        {
            txtPassOld.Text = string.Empty;
            txtPassNew.Text = string.Empty;
            txtPassConfirm.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PSEmployee emp = BioBLL.GetEmployeeByCode(this.empLogin);
            if(emp.Password != BioBLL.GetMD5(txtPassOld.Text))
            {
                XtraMessageBox.Show("Sai mật khẩu cũ. Vui lòng nhập lại!", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassOld.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassNew.Text))
            {
                XtraMessageBox.Show("Không được để trống mật khẩu mới", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassNew.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassConfirm.Text))
            {
                XtraMessageBox.Show("Không được để trống nhập lại mật khấu mới", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassConfirm.Focus();
                return;
            }
            if (txtPassNew.Text != txtPassConfirm.Text)
            {
                XtraMessageBox.Show("Nhập lại mật khẩu mới không trùng nhau", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassConfirm.Focus();
                return;
            }
            if(BioBLL.UpdPassEmployee(this.empLogin, txtPassConfirm.Text))
            {
                XtraMessageBox.Show("Cập nhật mật khẩu thành công", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ClearText();
            }
            else
                XtraMessageBox.Show("Cập nhật mật khẩu thất bại", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}