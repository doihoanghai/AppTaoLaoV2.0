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
using BioNetBLL;
using BioNetModel;
using DevExpress.XtraGrid.Views.Grid;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Diagnostics;

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class FrmGuiMail : DevExpress.XtraEditors.XtraForm
    {
        public FrmGuiMail()
        {
            InitializeComponent();
            
        }

        private void LoadDuLieuBaoCao()
        {
            this.GC_DSPhieuMail.DataSource = BioNet_Bus.GetTinhTrangPhieu(this.dllNgay.tungay.Value, this.dllNgay.denngay.Value, txtDonVi.EditValue.ToString());
            
        }


        private void FrmGuiMail_Load(object sender, EventArgs e)
        {
            this.txtChiCuc.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChiCuc();
            this.txtDonVi.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DonVi("all");
            this.txtDonVi.EditValue = "all";
            
        }

        private void txtChiCuc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit sear = sender as SearchLookUpEdit;
                var value = sear.EditValue.ToString();
                this.txtDonVi.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DonVi(value.ToString());
                this.txtDonVi.EditValue = "all";
            }
            catch { }
        }

       

        private void butOK_Click(object sender, EventArgs e)
        {
            LoadDuLieuBaoCao();
        }

        private void bttPDF_Click(object sender, EventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView View = GC_DSPhieuMail.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            GridView View = GC_DSPhieuMail.MainView as GridView;
            if (View != null)
            {
                View.ExportToPdf("MainViewData.pdf");
                Process pdfExport = new Process();
                pdfExport.StartInfo.FileName = "AcroRd32.exe";
                pdfExport.StartInfo.Arguments = "MainViewData.pdf";
                pdfExport.Start();
            }
        }
       
        
    }
}