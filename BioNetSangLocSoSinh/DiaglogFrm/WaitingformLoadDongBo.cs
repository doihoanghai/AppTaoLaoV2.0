using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class WaitingformLoadDongBo : SplashScreen
    {
        public WaitingformLoadDongBo()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void WaitingformLoadDongBo_Load(object sender, EventArgs e)
        {

        }
    }
}