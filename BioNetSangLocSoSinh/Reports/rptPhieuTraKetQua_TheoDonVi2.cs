using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace BioNetSangLocSoSinh.Reports
{
    public partial class rptPhieuTraKetQua_TheoDonVi2 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPhieuTraKetQua_TheoDonVi2()
        {
            InitializeComponent();
        }

        private void rptPhieuTraKetQua_TheoDonVi2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (txtNguyCo.Text.ToLower().Equals("true"))
            {
                this.txtKetLuan.Font = new Font("Times New Roman", 10f, FontStyle.Italic | FontStyle.Bold);
                this.txtKetLuan.ForeColor = System.Drawing.Color.Red;
                this.txtGiaTri.Font = new Font("Times New Roman", 10f, FontStyle.Bold);
            }
            else
            {
                this.txtKetLuan.Font = new Font("Times New Roman", 10f);
                this.txtGiaTri.Font = new Font("Times New Roman", 10f);
            }
        }

        private void xrTable3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (txtNguyCo.Text.ToLower().Equals("true"))
            {
                this.txtKetLuan.Font = new Font("Times New Roman", 10f, FontStyle.Bold);

            }
            else
            {
                this.txtKetLuan.Font = new Font("Times New Roman", 10f);

            }
        }
    }
}
