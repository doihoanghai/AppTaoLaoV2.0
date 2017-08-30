using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraReports;
using System.Diagnostics;
namespace BioNetSangLocSoSinh.Reports
{
    public partial class frmReportEditGeneral : DevExpress.XtraEditors.XtraForm
    {
        private DataSet dsResult = new DataSet();
        private DevExpress.XtraReports.UI.XtraReport rpt = new DevExpress.XtraReports.UI.XtraReport();   
        private Excel.Application oxl;
        private Excel._Workbook owb;
        private Excel._Worksheet osheet;
        private string fromdate = string.Empty, todate = string.Empty, sheetname = string.Empty;
        public frmReportEditGeneral(DevExpress.XtraReports.UI.XtraReport _rpt, string _sheetname)
        {
            InitializeComponent();
            this.rpt = _rpt;
            this.sheetname = _sheetname;
        }
        private void barItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (new EditDesignReport(rpt).ShowpageEditDesign())
            {
                rpt.LoadLayout(Application.StartupPath + "\\EditReport\\" + this.rpt.GetType().Name + ".repx");
                rpt.CreateDocument();
            }
        }

        private void barItem_XuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.dsResult != null)
            {
                DiaglogFrm.frmExcelPathName frmPath = new DiaglogFrm.frmExcelPathName();
                frmPath.ShowDialog();
                if (frmPath.reloaded)
                {
                    this.Check_Process_Excel();
                    rpt.DataSource = this.dsResult;
                    rpt.ExportOptions.Xls.ShowGridLines = true;
                    rpt.ExportOptions.Xls.SheetName = this.sheetname;
                    rpt.ExportToXls(frmPath.pathName);
                    oxl = new Excel.Application();
                    owb = (Excel._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                    osheet = (Excel._Worksheet)owb.ActiveSheet;
                    oxl.ActiveWindow.DisplayGridlines = false;
                    oxl.ActiveWindow.DisplayZeros = false;
                    oxl.Visible = true;
                }
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void Check_Process_Excel()
        {
            Process[] processes = Process.GetProcesses();

            if (processes.Length > 1)
            {
                int i = 0;
                for (int n = 0; n <= processes.Length - 1; n++)
                {
                    if (((Process)processes[n]).ProcessName == "EXCEL")
                    {
                        i++;
                        ((Process)processes[n]).Kill();
                    }
                }
            }
        }
        private void frmReportEditGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath + "\\EditReport\\" + this.rpt.GetType().Name + ".repx";
                if (File.Exists(path))
                    this.rpt.LoadLayout(path);
            }
            catch 
            { }
            //this.rpt.DataSource = this.data;
            this.documentView.DocumentSource = this.rpt;
            this.rpt.CreateDocument(true);
        }
    }
}