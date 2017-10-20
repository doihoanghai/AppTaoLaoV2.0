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
    public partial class FrmBaoCaoDonVi_TTPhieu : DevExpress.XtraEditors.XtraForm
    {
        public FrmBaoCaoDonVi_TTPhieu()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoDonVi_TTPhieu_Load(object sender, EventArgs e)
        {
            FrmReports.urcReportTTPhieu_DonVi urc = new urcReportTTPhieu_DonVi();
            urc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(urc);
        }
    }
}