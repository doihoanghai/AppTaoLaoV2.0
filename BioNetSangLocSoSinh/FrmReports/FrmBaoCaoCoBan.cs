using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class FrmBaoCaoCoBan : DevExpress.XtraEditors.XtraForm
    {
        public FrmBaoCaoCoBan()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoCoBan_Load(object sender, EventArgs e)
        {
            FrmReports.urcReportTrungTam_SoBo urc = new urcReportTrungTam_SoBo();
            urc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(urc);
        }
    }
}