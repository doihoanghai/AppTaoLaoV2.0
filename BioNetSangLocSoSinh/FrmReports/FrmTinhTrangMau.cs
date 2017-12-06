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
    public partial class FrmTinhTrangMau : DevExpress.XtraEditors.XtraForm
    {
        public FrmTinhTrangMau()
        {
            InitializeComponent();
        }

        private void FrmTinhTrangMau_Load(object sender, EventArgs e)
        {
           
            FrmReports.urcReporTinhTrangMau urc = new urcReporTinhTrangMau();
            urc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(urc);
        }
    }
}