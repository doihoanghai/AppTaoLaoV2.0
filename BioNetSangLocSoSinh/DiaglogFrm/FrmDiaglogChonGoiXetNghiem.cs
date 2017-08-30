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
namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmDiaglogChonGoiXetNghiem : DevExpress.XtraEditors.XtraForm
    {
        public FrmDiaglogChonGoiXetNghiem()
        {
            InitializeComponent();
        }
        public string maGoiXn = string.Empty;
        private void FrmDiaglogChonGoiXetNghiem_Load(object sender, EventArgs e)
        {
            this.LoadListGoiXetNghiem();
        }
        private void LoadListGoiXetNghiem()
        {
            var list = BioNet_Bus.GetDanhsachGoiDichVuChung();
            this.radioGroup1.Properties.Items.Clear();
            foreach (var item in list)
            {   if( !item.IDGoiDichVuChung.Equals("DVGXN0001")&&!item.IDGoiDichVuChung.Equals("DVGXNL2"))
                this.radioGroup1.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(item.IDGoiDichVuChung, item.TenGoiDichVuChung));
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
           if(!string.IsNullOrEmpty(this.maGoiXn))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn gói xét nghiệm!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            RadioGroup rd = sender as RadioGroup;
            var ts = rd.EditValue;
            this.maGoiXn = ts.ToString();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}