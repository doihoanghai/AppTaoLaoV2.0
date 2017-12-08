using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace BioNetSangLocSoSinh
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
           BonusSkins.Register();
            SkinManager.EnableFormSkins();

            Application.Run(new FrmStartup());
            //Application.Run(new FrmReports.FrmBaoCaoDonVi_ChiTietcs());
            // Application.Run(new FrmReports.frmReportTrungTam_ChiCuc());
            //Application.Run(new DiaglogFrm.FrmDiaglog_ThongTinBanQuyen());
        }
    }
}
