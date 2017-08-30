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

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class FrmReportTrungTam_DonVi : DevExpress.XtraEditors.XtraForm
    {
        public FrmReportTrungTam_DonVi()
        {
            InitializeComponent();
        }

        private void FrmReportTrungTam_DonVi_Load(object sender, EventArgs e)
        {
            FrmReports.urcReportTrungTam_DonVi urc = new urcReportTrungTam_DonVi ();
            urc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(urc);
        }
    }
}