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
using DevExpress.DashboardCommon.Native.DashboardRestfulService;

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
            try
            {
                for (int i = 0; i < GV_DSPhieuMail.DataRowCount; i++)
                {
                    string machicuc = GV_DSPhieuMail.GetRowCellValue(i, this.col_MaDV).ToString();
                    string mcc = machicuc.Substring(0, 5);
                   
                   
                }
            }
            catch(Exception ex) { return; }
            

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

            GridView view = GC_DSPhieuMail.MainView as GridView;
            if (view != null)
            {
                view.ExportToPdf("mainviewdata.pdf");
                Process pdfexport = new Process();
                pdfexport.StartInfo.FileName = "acrord32.exe";
                pdfexport.StartInfo.Arguments = "mainviewdata.pdf";
                pdfexport.Start();
            }
            else
                MessageBox.Show("không có nội dung xuất", "cảnh báo");
        }

        private void ckkTatCa_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                this.ckkTatCa.Text = ckkTatCa.Checked ? "Bỏ chọn" : "Chọn tất cả";
                for (int i = 0; i < GV_DSPhieuMail.DataRowCount; i++)
                {
                    if (this.ckkTatCa.Checked)
                    {

                        GV_DSPhieuMail.SetRowCellValue(i, col_Chon, 1);

                    }
                    else
                    {
                        GV_DSPhieuMail.SetRowCellValue(i, col_Chon, 0);
                    }
                }

            }
            catch { }


        }
    }
}