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
using Excelc = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace BioNetSangLocSoSinh.Reports
{
    public partial class frmDanhSachDaCapMa : DevExpress.XtraEditors.XtraForm
    {

        private DataSet dsResult = new DataSet();
        private DevExpress.XtraReports.UI.XtraReport rpt = new DevExpress.XtraReports.UI.XtraReport();
        private Excelc.Application oxl;
        private Excelc._Workbook owb;
        private Excelc._Worksheet osheet;
        private string fromdate = string.Empty, todate = string.Empty, sheetname = string.Empty;
        public string NameFile;

        private void frmDanhSachDaCapMa_Load(object sender, EventArgs e)
        {
            try
            {
                //string path = Application.StartupPath + "\\EditReport\\" + this.rpt.GetType().Name + ".repx";
                string path =NameFile;

                this.rpt.CreateDocument(true);
                this.documentView.DocumentSource = this.rpt;
                try
                {

                    Process pdfexport = new Process();
                    //MessageBox.Show("Lưu thành công file: " + NameFile + ".pdf", "Thông Báo", MessageBoxButtons.OK);
                }
                catch (Exception ex) { }
                    this.rpt.LoadLayout(path);
            }
            catch
            { }
        }

        private void printPreviewBarItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
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

                        rpt.ExportToXlsx(frmPath.pathName);
                        oxl = new Excelc.Application();
                        owb = (Excelc._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                        osheet = (Excelc._Worksheet)owb.ActiveSheet;
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
            catch
            {

            }
          
        }

        private void barItem_XuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
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

                        rpt.ExportToXlsx(frmPath.pathName);
                        oxl = new Excelc.Application();
                        owb = (Excelc._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                        osheet = (Excelc._Worksheet)owb.ActiveSheet;
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
            catch
            {

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
        public frmDanhSachDaCapMa(DevExpress.XtraReports.UI.XtraReport _rpt)
        {
            InitializeComponent();
            this.rpt = _rpt;
  
        }

    }
}