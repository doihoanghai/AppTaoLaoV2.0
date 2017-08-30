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
    public partial class WaitingfromSave : SplashScreen
    {
        public WaitingfromSave()
        {
            InitializeComponent();
        }
        public WaitingfromSave(string noidung)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(noidung))
                this.txtnoidung.Text = "Đang lưu dữ liệu, vui lòng đợi...";
            else this.txtnoidung.Text = noidung;
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
    }
}