﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace BioNetSangLocSoSinh.Reports
{
    public partial class rptPhieuTraKetQua : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPhieuTraKetQua()
        {
            InitializeComponent();
        }

      

        private void rptPhieuTraKetQua_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
    }
}
