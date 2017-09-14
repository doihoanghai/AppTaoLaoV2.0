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
using System.IO;
using System.Diagnostics;
using DevExpress.DashboardCommon.Native.DashboardRestfulService;
using BioNetSangLocSoSinh.Reports;
using System.Net.Mail;
using System.Net;
using System.IO.Compression;

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class FrmGuiMail : DevExpress.XtraEditors.XtraForm
    {
        string fromAddress = "sanglocbionet@gmail.com";
        string pathMail = Application.StartupPath + "\\DSGuiMail\\";

        public FrmGuiMail()
        {
            InitializeComponent();
        }

        private void LoadDuLieuBaoCao()
        {
            this.GC_DSPhieuMail.DataSource = BioNet_Bus.GetTinhTrangPhieuMail(this.dllNgay.tungay.Value, this.dllNgay.denngay.Value, txtDonVi.EditValue.ToString());
            DemChon();
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

        }

        //Chọn tắt cả
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
                DemChon();

            }
            catch (Exception ex) { return; }

        }
        private void DemChon()
        {
            string tong = GV_DSPhieuMail.DataRowCount.ToString();
            int chon = 0;
            for (int i = 0; i < GV_DSPhieuMail.DataRowCount; i++)
            {

                if (Int32.Parse(GV_DSPhieuMail.GetRowCellValue(i, col_Chon).ToString()) == 1)
                {
                    chon = chon + 1;
                }
            }
            lblDemChon.Text = "Số phiếu được chon:" + chon.ToString() + "/" + tong;
            lblDemChon.Visible = true;
        }

        private void bttGuiMail_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn là sẽ gửi mail", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //int[] lstChecked = this.GV_DSPhieuMail.GetSelectedRows();
                List<PsTinhTrangPhieu> dt = (List<PsTinhTrangPhieu>) GC_DSPhieuMail.DataSource;
                string[] MaDVCS = null;
                DataTable dtselect = new DataTable();
                for(int i=0; i<dt.Count; i++)
                {
                    if(dt[i].Chon==1)
                    {
                        string maDVCS = this.GV_DSPhieuMail.GetRowCellValue(i, this.col_MaDV).ToString();
                        MaDVCS = new[] { maDVCS };
                        string maPhieu = this.GV_DSPhieuMail.GetRowCellValue(i, this.col_IDPhieu).ToString();
                        string tendvcs = this.GV_DSPhieuMail.GetRowCellValue(i, this.col_TenDonVi).ToString();
                        //Noi lưu phiếu trả kết quả                               
                        string pathpdf = Application.StartupPath + "\\PhieuKetQua\\" + maDVCS + "\\" + maPhieu + ".pdf";
                        //Kiểm tra đường dẫn tồn tại ko                     
                        if (!Directory.Exists(pathpdf))
                        {
                            //Nếu ko có phiếu thì in lại phiếu
                            LuuPDF(maPhieu, maDVCS);
                        }
                        NenGuiMail(pathpdf, maPhieu, maDVCS);
                    }
                }
                
                //foreach (var index in lstChecked)
                //{
                //    if (index >= 0)
                //    {
                       
                                                               
                //    }
                //    else
                //    {
                //        XtraMessageBox.Show("Yêu cầu chọn phiếu cần gửi mail" , "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        break;
                //    }

                //}
                string kq=GuiMail(MaDVCS);
                MessageBox.Show(kq, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
               
            }

            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }
        private string GuiMail(string[] MaDVCS)
        {

                string kq=null;
                string[] Madvcs = MaDVCS;
                foreach (string madvcs in MaDVCS)
                {
                    string pathzip = pathMail + madvcs + ".zip";
                    //string MailKH = BioNet_Bus.GetThongTinMailDonViCoSo(madvcs);
                    string mailKh = "thanhquangqb95@gmail.com";
                    kq=DataSync.BioNetSync.GuiMail.Send_Email_With_Attachment(mailKh,fromAddress, pathzip);
                }
                return kq;

           
        }
        //Lưu File PDF
        private void LuuPDF(string MaPhieu,string MaDVCS)
        {
            PsRptTraKetQuaSangLoc data = new PsRptTraKetQuaSangLoc();
            try
            {
                var donvi = BioNet_Bus.GetThongTinDonViCoSo(MaDVCS);
                string Matiepnhan = BioNet_Bus.GetThongTinMaTiepNhan(MaPhieu, MaDVCS);
                if (donvi != null)
                {
                    var kieuTraKQ = donvi.KieuTraKetQua ?? 1;
                    data = BioNet_Bus.GetDuLieuInKetQuaSangLoc(MaPhieu, Matiepnhan, "MaBsi",MaDVCS);
                    if (kieuTraKQ == 1) // Cần sửa chỗ này, cho chọn động loat report theo cấu hình của đơn vị
                    {
                        Reports.rptPhieuTraKetQua datarp = new Reports.rptPhieuTraKetQua();
                        frmReportEditGeneral.FileLuuPDF(datarp, data);
                    }
                    else
                    if (kieuTraKQ == 2)
                    {
                        Reports.rptPhieuTraKetQua_TheoDonVi datarp = new Reports.rptPhieuTraKetQua_TheoDonVi();
                        frmReportEditGeneral.FileLuuPDF(datarp, data);
                    }
                    else
                    {
                        Reports.rptPhieuTraKetQua_TheoDonVi2 datarp = new Reports.rptPhieuTraKetQua_TheoDonVi2();
                        frmReportEditGeneral.FileLuuPDF(datarp, data);
                    }
                }
                else
                {

                    Reports.rptPhieuTraKetQua rp = new Reports.rptPhieuTraKetQua();
                    frmReportEditGeneral.FileLuuPDF(rp, data);
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Lỗi phát sinh khi lấy dữ liệu in \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }
        private void NenGuiMail(string pathpdf,string Maphieu,string MaDVCS)
        {
            string tendvcs = MaDVCS;
            string maphieu = Maphieu;
            string startPath = pathpdf;
            
            if(!Directory.Exists(pathMail))
            {
                Directory.CreateDirectory(pathMail);
            }
            string zipPath = Application.StartupPath + "\\DSGuiMail\\" + tendvcs + ".zip";
            if(Directory.Exists(zipPath))
            {
                ZipFile.CreateFromDirectory(startPath, zipPath);
            }
            else {
             
                    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
                    {
                        archive.CreateEntryFromFile(startPath, maphieu + ".pdf");
                    }
                
            }
          


        }
    }
}