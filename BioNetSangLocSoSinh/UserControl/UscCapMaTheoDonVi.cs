using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetModel;
using BioNetBLL;
using BioNetModel.Data;

namespace BioNetSangLocSoSinh.UserControl
{
    public partial class UscCapMaTheoDonVi : DevExpress.XtraEditors.XtraUserControl
    {
        public UscCapMaTheoDonVi(string maDVi)
        {
            InitializeComponent();
            this.LoadLookupDonVi();
            this.lookUpDonVi.EditValue = maDVi;
          
        }
        public string maDV = string.Empty;
        public long maBD = 0;
        public long maKT = 0;
        public int slmax = 0;
        public bool isDone = false;
        private void LoadLookupDonVi()
        {
            this.lookUpDonVi.Properties.DataSource = BioNet_Bus.GetDanhSachDonViCoSo();
        }
        private string SoBanDau()
        {
            string s1 = (DateTime.Now.Year.ToString()).Trim().Substring(DateTime.Now.Year.ToString().Trim().ToString().Length - 2);
            string s2 = (DateTime.Now.Month.ToString()).PadRight(2,'0');
            return s1 + s2;
        }
        public void SetGiaTri(long BatDau, int TongSo)
        {
            this.slmax = TongSo;
            this.txtTu.Text = SoBanDau() + BatDau.ToString().PadLeft(4,'0');
            this.txtDen.Text = SoBanDau() + (BatDau+TongSo - 1).ToString().PadLeft(4,'0');
            this.txtslMax.Text = TongSo.ToString();
            this.maBD = long.Parse(this.txtTu.Text.Trim());
            this.maKT = long.Parse(this.txtDen.Text.Trim());
            this.isDone = true;
        }
        private void lookUpDonVi_EditValueChanged(object sender, EventArgs e)
        {
            this.maDV = this.lookUpDonVi.EditValue.ToString();
        }

        private void txtTu_Validated(object sender, EventArgs e)
        {
            if (!this.txtTu.Text.StartsWith(SoBanDau()))
            {
                string s1 = this.txtTu.Text.Trim().Substring(4).PadLeft(4, '0');
                this.txtTu.Text = SoBanDau() + s1;
                this.maBD = long.Parse(this.txtTu.Text.Trim());
                this.txtDen.Text = (this.maBD + this.slmax-1).ToString();
                this.isDone = true;
            }
            else
            {
                string s1 = this.txtTu.Text.Trim().Substring(4).PadLeft(4, '0');
                this.txtTu.Text = SoBanDau() + s1;
                this.maBD = long.Parse(this.txtTu.Text.Trim());
                this.txtDen.Text = (this.maBD + this.slmax-1).ToString();
                this.isDone = true;
            }
            this.maKT = long.Parse(this.txtDen.Text);
        }

        private void txtDen_Validated(object sender, EventArgs e)
                            {
            if (!this.txtDen.Text.StartsWith(SoBanDau()))
            {
                string s1 = this.txtDen.Text.Trim().Substring(4).PadLeft(4, '0');
                this.maBD = long.Parse(this.txtTu.Text.Trim());
                this.txtDen.Text = SoBanDau() + s1;
                this.isDone = true;
            }else
            {
                string s1 = this.txtDen.Text.Trim().Substring(4).PadLeft(4, '0');
                this.maBD = long.Parse(this.txtTu.Text.Trim());
                this.txtDen.Text = SoBanDau() + s1;
                this.isDone = true;
            }
                    this.maKT = long.Parse(this.txtDen.Text);
            if(maKT-maBD+1!=slmax)
            {
                this.isDone = false;
                XtraMessageBox.Show("Số lượng phiếu chỉ có " + slmax + " nhưng số lượng mã xét nghiệm là " + (maKT - maBD).ToString() + "\r\n Vui lòng kiểm tra lại", "\r\nVui lòng kiểm tra lại!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                
            }
        }

        private void txtDen_Properties_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }
    }
}
