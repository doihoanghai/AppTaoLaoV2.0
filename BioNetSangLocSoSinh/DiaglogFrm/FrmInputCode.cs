using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmInputCode : DevExpress.XtraEditors.XtraForm
    {
        public string code, name = string.Empty;
        public int inputLengh = 0;
        public FrmInputCode(string _code,  string _name, int _inputLengh)
        {
            this.code = _code;
            this.name = _name;
            this.inputLengh = _inputLengh;
            InitializeComponent();
        }

        private bool CheckValidation()
        {
            try
            {
                if (this.code.Length == inputLengh)
                    return true;
                else return false;
            }
            catch { return false; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.code = txtText.Text;
            if (!CheckValidation())
            {
                XtraMessageBox.Show("Xin nhập không quá "+this.inputLengh+" ký tự !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmInputCode_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.name))
                lblText.Text = this.name;
            txtText.Text = this.code;
        }
    }
}