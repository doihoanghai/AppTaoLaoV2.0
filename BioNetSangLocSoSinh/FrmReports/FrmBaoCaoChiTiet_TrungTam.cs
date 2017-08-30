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
    public partial class FrmBaoCaoChiTiet_TrungTam : DevExpress.XtraEditors.XtraForm
    {
        public FrmBaoCaoChiTiet_TrungTam()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoChiTiet_TrungTam_Load(object sender, EventArgs e)
        {
            FrmReports.urcReportTrungTam_ChiCuc urc = new urcReportTrungTam_ChiCuc();
            urc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(urc);

        }
    }
}