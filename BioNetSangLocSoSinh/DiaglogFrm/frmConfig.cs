using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using BioNetBLL;

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class frmConfig : DevExpress.XtraEditors.XtraForm
    {
        public bool isConnected = false;
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            try
            {
                this.GetServerName();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Chưa kết nối với dữ liệu! Vui lòng thiết lập kết nối", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void GetServerName()
        {
            string myServer = BioBLL.MyServerName();
            DataTable servers = BioBLL.TableServerName();
            if (servers != null && servers.Rows.Count > 0)
            {
                for (int i = 0; i < servers.Rows.Count; i++)
                {
                    this.cbxServerName.Properties.Items.Add(servers.Rows[i]["ServerName"]);
                }
                this.cbxServerName.EditValue = myServer;
            }
        }

        private void cbxServerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Up)
                this.cbxServerName.Focus();
        }

        private void txtDataBaseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Up)
                this.cbxServerName.Focus();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Up)
                this.txtDataBaseName.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Up)
                this.txtUserName.Focus();
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (BioBLL.CheckConnection(this.cbxServerName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.txtDataBaseName.Text.Trim()))
                {

                    MessageBox.Show("Kết nối thành công đến Server: " + cbxServerName.EditValue.ToString() + ".\nChương trình tự động khởi động lại.", "iHIS - Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.isConnected = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kết nối đến server " + cbxServerName.EditValue.ToString() + ", database: " + this.txtDataBaseName.Text + ", userName: " + this.txtUserName.Text.ToString() + " không thành công! \r\n Vui lòng kiểm tra lại thông tin kết nối.", "iHIS - Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbxServerName.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("butConnect_Click: " + ex.ToString(), "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}