using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace DataSync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserLookAndFeel.Default.SkinName = "Office 2016 Colorful";//"Lilian";
        //   BonusSkins.Register();
            SkinManager.EnableFormSkins();
       Application.Run(new FrmStartupSync());
        // Application.Run(new Entry.FrmNhapKho());
         // Application.Run(new FrmReports.FrmBaoCapMain());
           // Application.Run(new FrmReports.frmReportTrungTam_ChiCuc());
            // Application.Run(new DiaglogFrm.FrmDiaglog_ThongTinBanQuyen());
        }
    }
}
