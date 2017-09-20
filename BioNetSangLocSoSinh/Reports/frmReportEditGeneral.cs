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
using DevExpress.XtraPrinting;
using BioNetModel;

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
        public string NameFile;
        public string NameDVCS;
        public frmReportEditGeneral(DevExpress.XtraReports.UI.XtraReport _rpt, string _sheetname,string name,string madvcs)
        {
            InitializeComponent();
            this.rpt = _rpt;
            this.sheetname = _sheetname;
            NameFile = name;
            NameDVCS = madvcs;
            string pathpdf = Application.StartupPath + "\\PhieuKetQua\\" + "\\" + NameDVCS + "\\";
            System.IO.Directory.CreateDirectory(pathpdf);
            //DataTable dt= rpt.DataSource as DataTable;
            //name = dt.Rows[10][0].ToString();
        }
        private void barItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (new EditDesignReport(rpt).ShowpageEditDesign())
            {
                //rpt.LoadLayout(Application.StartupPath + "\\EditReport\\" + this.rpt.GetType().Name + ".repx");
                rpt.LoadLayout(Application.StartupPath + "\\EditReport\\" + NameFile + ".repx");
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
                // string path = Application.StartupPath + "\\EditReport\\" + this.rpt.GetType().Name + ".repx";
                string path = Application.StartupPath + "\\PhieuKetQua\\" + NameDVCS + @"\" + NameFile + ".pdf";

                this.rpt.CreateDocument(true);
                this.documentView.DocumentSource = this.rpt;
                try
                {
                    //Lưu file pdf phiếu kết quả theo tên mã phiếu
                  
                   // this.rpt.ExportToPdf(path);
                 
                    Process pdfexport = new Process();
                    //MessageBox.Show("Lưu thành công file: " + NameFile + ".pdf", "Thông Báo", MessageBoxButtons.OK);
                }
                catch (Exception ex) { }

                if (File.Exists(path))
                    this.rpt.LoadLayout(path);
            }
            catch 
            { }
            //this.rpt.DataSource = this.data;
            
            
        }
        //Lưu phiếu trả kết quả pdf
        public static void FileLuuPDF(DevExpress.XtraReports.UI.XtraReport datarp, PsRptTraKetQuaSangLoc data)
        {
            datarp.DataSource = data;
            string name = data.MaPhieu.ToString();
            string madvcs = data.MaDonVi.ToString();
            //Tạo thư mục có tên là mã đơn vị cơ sở
            string pathpdf = Application.StartupPath + "\\PhieuKetQua\\" + "\\" + madvcs + "\\";
            Directory.CreateDirectory(pathpdf);
            //Đường dẫn file pdf
            string path = Application.StartupPath + "\\PhieuKetQua\\" + madvcs + @"\" + name + ".pdf";
            try
            {
                //Lưu file pdf phiếu kết quả theo tên mã phiếu
                datarp.ExportToPdf(path);
                Process pdfexport = new Process();
            }
            catch
            { }
        }
    }
}