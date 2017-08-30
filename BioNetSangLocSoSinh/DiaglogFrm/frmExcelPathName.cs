using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Globalization;
using DevExpress.XtraReports.UI;

using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class frmExcelPathName : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string pathName = string.Empty;
        public bool reloaded = false;
        public frmExcelPathName()
        {
            InitializeComponent();
        }
                
        private void btAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPath.Text == "")
                {
                    XtraMessageBox.Show(" Chưa chọn đường dẫn lưu file báo cáo!", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    this.pathName = this.txtPath.Text;
                    this.reloaded = true;
                    this.Dispose();
                    this.Close();
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        
        private void btClose_Click(object sender, EventArgs e)
        {
            this.reloaded = false;
            this.Dispose();
            this.Close();
        }

        private void butPath_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "File Excel|*.xls";
                saveFileDialog1.Title = "Excel";
                DialogResult r = saveFileDialog1.ShowDialog();
                if (r == DialogResult.OK)
                    this.txtPath.Text = saveFileDialog1.FileName;
                if (this.txtPath.Text == "")
                {
                    XtraMessageBox.Show(" Chưa chọn đường dẫn lưu file báo cáo!", "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                    this.pathName = this.txtPath.Text;
            }
            catch { }
        }

    }
}