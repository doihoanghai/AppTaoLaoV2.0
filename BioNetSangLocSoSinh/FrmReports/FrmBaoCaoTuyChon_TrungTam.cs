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
    public partial class FrmBaoCaoTuyChon_TrungTam : DevExpress.XtraEditors.XtraForm
    {
        public FrmBaoCaoTuyChon_TrungTam()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoTuyChon_TrungTam_Load(object sender, EventArgs e)
        {
          UserControl.ucBaoCaoTuyChonTrungTam urc = new UserControl.ucBaoCaoTuyChonTrungTam();
            urc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(urc);
        }
    }
}