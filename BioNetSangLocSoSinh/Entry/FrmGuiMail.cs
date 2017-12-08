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
using BioNetModel.Data;
using DevExpress.XtraSplashScreen;
using BioNetSangLocSoSinh.DiaglogFrm;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class FrmGuiMail : DevExpress.XtraEditors.XtraForm
    {
        string fromAddress = "sanglocbionet@gmail.com";
        string pathMail = Application.StartupPath + "\\DSGuiMail\\";
        PSThongTinTrungTam tt = new PSThongTinTrungTam();

        public FrmGuiMail()
        {
            InitializeComponent();
        }

        private void LoadDuLieuEmail()
        {
            this.GC_DSPhieuMail.DataSource = BioNet_Bus.GetTinhTrangPhieuMail(this.dllNgay.tungay.Value, this.dllNgay.denngay.Value, txtDonVi.EditValue.ToString(),txtChiCuc.EditValue.ToString());
           
            if (this.GV_DSPhieuMail.DataRowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu phiếu kết quả cần tìm", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                this.bttGuiMail.Enabled = false;
            }
            else
            {
                this.bttGuiMail.Enabled = true;
            }
        }

        private void FrmGuiMail_Load(object sender, EventArgs e)
        {
            this.txtChiCuc.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChiCuc();
            this.txtDonVi.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DonVi("all");
            this.txtDonVi.EditValue = "all";
            this.txtChiCuc.EditValue = "all";
            this.bttGuiMail.Enabled = false;
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
            LoadDuLieuEmail();            
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
            }
            catch (Exception ex) { return; }

        }

        private void bttGuiMail_Click(object sender, EventArgs e)
        {
           
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn là sẽ gửi mail", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try {
                    SplashScreenManager.ShowForm(this, typeof(WaitingformMail), true, true, false);
                    List<PsTinhTrangPhieu> dt = (List<PsTinhTrangPhieu>)GC_DSPhieuMail.DataSource;
                    List<string> MaDVCS = new List<string>();
                  

                    DataTable dtselect = new DataTable();
                    int kq = 0;
                    int chon = 0;
                    for (int i = 0; i < dt.Count; i++)
                    {
                        int kt = 0;
                        if (dt[i].Chon == 1)
                        {
                            chon = 1;
                            string maDVCS = dt[i].MaDonVi.ToString();
                            string maPhieu = dt[i].IDPhieu.ToString();
                            string temdvcs = dt[i].TenDonVi.ToString();
                            if (MaDVCS != null)
                            {
                                foreach (string dvcs in MaDVCS)
                                {
                                    if (maDVCS == dvcs)
                                    {
                                        kt = 1;
                                        break;
                                    }
                                }
                            }
                            if (kt == 0) { MaDVCS.Add(maDVCS); }
                            //Noi lưu phiếu trả kết quả                               
                            string pathpdf = Application.StartupPath + "\\PhieuKetQua\\" + maDVCS + "\\" + maPhieu + ".pdf";
                            //Kiểm tra đường dẫn tồn tại ko

                            // if (!File.Exists(pathpdf)) {
                            LuuPDF(maPhieu, maDVCS); //}//Nếu ko có phiếu thì in lại phiếu 
                            NenGuiMail(pathpdf, maPhieu, maDVCS);
                        }
                    }
                 
                    if (chon == 1)
                    {
                        foreach (string madvcs in MaDVCS)
                        {

                            kq = GuiMail(madvcs);
                            if (kq == 1)
                            {
                                XtraMessageBox.Show("Gửi mail cho đơn vị " + madvcs + " thất bại", "bionet - chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                                break;
                            }
                            else if (kq == 2)
                            {
                                XtraMessageBox.Show("Email của đơn vị " + madvcs + " không tồn tại", "bionet - chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                                break;
                            }
                            else if (kq == 5)
                            {
                                XtraMessageBox.Show("Dữ liệu của Email của trung tâm lỗi - Vui lòng kiểm tra lại dữ liệu ", "bionet - chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                                break;
                            }
                            else
                            {
                                var MaPhieu = dt.Where(x => x.Chon == 1 && x.MaDonVi == madvcs).Select(x => x.IDPhieu).ToList();
                                var res = BioNet_Bus.CapNhatGuiMail(MaPhieu);
                                
                            }
                        }
                        SplashScreenManager.CloseForm();
                        if (kq == 0) { XtraMessageBox.Show("Gửi Mail thành công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK
                            
                            );

                        }
                        //Xóa file nén đã gửi mail
                        DirectoryInfo dirInfo = new DirectoryInfo(pathMail);
                        FileInfo[] childFiles = dirInfo.GetFiles();
                        foreach (FileInfo childFile in childFiles) { File.Delete(childFile.FullName); }
                    }
                    else { XtraMessageBox.Show("Vui lòng tick vào phiếu cần gửi mail", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK); }
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi gửi mail", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
               
            }
            else if (dialogResult == DialogResult.No) { return; }

        }
        public static void CombineMultiplePDFs(List<string> fileNames, string outFile)
        {
            Document document = new Document();
            PdfCopy writer = new PdfCopy(document, new FileStream(outFile, FileMode.Create));
            if (writer == null)
            {
                return;
            }
            document.Open();
            foreach (string fileName in fileNames)
            {

                PdfReader reader = new PdfReader(fileName);
                reader.ConsolidateNamedDestinations();


                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    writer.AddPage(page);
                }

                PRAcroForm form = reader.AcroForm;
                if (form != null)
                {
                    writer.CopyDocumentFields(reader);
                }

                reader.Close();
            }

            writer.Close();
            document.Close();
        }
        private int GuiMail(string MaDVCS)
        {
            var donvi = BioNet_Bus.GetThongTinDonViCoSo(MaDVCS);
            this.tt = BioNet_Bus.GetThongTinTrungTam();
            if(this.tt!=null)
            {
                string fromAddress = tt.Email;
                string passEMail = tt.PassEmail;
                string tieude = "BIONET: KẾT QUẢ SLSS - " + donvi.TenDVCS + " " + DateTime.Now.ToShortDateString();
                //Bảng kết quả
                string bangkq = ThongKeMail(MaDVCS);
                string noidung = "<p style='font-size:12.8px;margin:6pt 0in;text-align:justify'><font face='times new roman,serif' size='4' color='black'>" + "Kính gửi:<b> " + donvi.TenDVCS + "</b>,</font></p>" +
                    "<p style='font-size:12.8px;margin:6pt 0in;text-align:justify '><font face='times new roman,serif' size='4' color='black'>" + "Trung tâm SLSS Bionet Việt Nam gửi tới Bệnh viện file kết quả sàng lọc sơ sinh tiếp nhận từ ngày " + this.dllNgay.tungay.Value.ToShortDateString() + " đến ngày " + this.dllNgay.denngay.Value.ToShortDateString() + "." + "</font></p>" +
                   "<p style='font-size:12.8px;margin:6pt 0in;text-align:justify'><font face='times new roman,serif' size = '4' color='black'>" + "Kết quả xét nghiệm như sau:" + "</font></p>" + bangkq +
                  "<p style='font-size:12.8px;margin:6pt 0in;text-align:justify'><font face='times new roman,serif' size = '4' color='black'>" + "Mọi thắc mắc hoặc góp ý, xin quý Bệnh viện vui lòng liên hệ Trung tâm Sàng lọc sơ sinh Bionet Việt Nam." + "</font></p>" + "<p style='font-size:12.8px;margin:6pt 0in;text-align:justify'><font face='times new roman,serif' size = '4' color='black'>" + "Số điện thoại Chăm sóc khách hàng:<span style='color:rgb(54,204,255)'> 024 6686 1304,</span>" + "</font></p>" +
                   "<p></p><p></p>" +
                   "<p style='font-size:12.8px;margin:6pt 0in;text-align:justify'><font face='times new roman,serif' size = '4' color='black'>" + "Kính thư," + "</font></p>";
                string madvcs = MaDVCS;
                //string pathzip = pathMail + madvcs  +"(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")" + ".zip"; 
                string pathzip = pathMail + madvcs + "(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")" + ".pdf";
                string MailKH = BioNet_Bus.GetThongTinMailDonViCoSo(madvcs);
                //string mailKh = "thanhquangqb95@gmail.com";
                int kq = DataSync.BioNetSync.GuiMail.Send_Email_With_Attachment(MailKH, fromAddress, passEMail, pathzip, tieude, noidung);
                //File.Create(pathzip).Close();
                return kq;
            }
            else
            {
                return 5;
            }
           
        }
        //THống kê
        private string ThongKeMail(string MaDVCS)
        {
            string zipPath = Application.StartupPath + "\\DSGuiMail\\" + MaDVCS+ "(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year +")"+ ".zip";
            string[] maphieu = null;

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string[] temp = entry.Name.Split('.');
                    if (maphieu == null)
                    {
                        maphieu = new string[] { temp[0] };
                    }
                    else
                    {
                        Array.Resize(ref maphieu, maphieu.Length + 1);
                        maphieu[maphieu.Length - 1] = temp[0];
                    }

                }
            }
            string zipPathpdf = Application.StartupPath + "\\DSGuiMail\\" + MaDVCS + "(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")" + ".pdf";
           
            Document document = new Document();
            PdfCopy writer = new PdfCopy(document, new FileStream(zipPathpdf, FileMode.Create));
            document.Open();
            foreach (string Maphieu in maphieu)
            {
                string fileName = Application.StartupPath + "\\PhieuKetQua\\" + MaDVCS + "\\" + Maphieu + ".pdf";
                PdfReader reader = new PdfReader(fileName);
                reader.ConsolidateNamedDestinations();


                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    writer.AddPage(page);
                }

                PRAcroForm form = reader.AcroForm;
                if (form != null)
                {
                    writer.CopyDocumentFields(reader);
                }

                reader.Close();
            }

            writer.Close();
            document.Close();
            PSTKKQPhieuMail tk = new PSTKKQPhieuMail();
            tk = BioNet_Bus.GetThongKePhieuMail(maphieu);
            int chitieumaumoi = tk.benh2 * 2 + tk.benh3 * 3 + tk.benh5 * 5;
            int chitieumauxnl = tk.G6PD3 +tk.GAL3+tk.PKU3+tk.CH3+tk.CAH3;
            string bangkq = "<table width='100%'  border='1' cellpadding='0' cellspacing='0' >" +
               "<tr style='padding:5px; text-align:center;'>" +
                    "<th style='padding:5px; text-align:center; color:#ffffff; background-color:#5ec0d6;'colspan='3'><b>  MẪU XÉT NGHIỆM</b></th>" +
                    "<th style='padding:5px; text-align:center; color:#ffffff; background-color:#5ec0d6;'colspan='7'><b>KẾT QUẢ XÉT NGHIỆM</b></th>" +
               "</tr >" +

               "<tr style='padding:5px; text-align:center;'>" +
                    "<td style='padding:5px; text-align:center; background-color:#d9e5e8;' colspan='3'>Mẫu mới</td>" +
                    "<td style='padding:5px; text-align:center;' rowspan='2'>Nguy Cơ Thấp</td>" +
                    "<td style='padding:5px; text-align:center; background-color:#87dc86;' colspan='1'>Tổng</td>" +
                     "<td style='padding:5px; text-align:center; background-color:#d9e5e8;' colspan='1'>G6PD</td>" +
                      "<td style='padding:5px; text-align:center; background-color:#d9e5e8;' colspan='1'>TGAL</td>" +
                       "<td style='padding:5px; text-align:center; background-color:#d9e5e8;' colspan='1'>PKU</td>" +
                        "<td style='padding:5px; text-align:center; background-color:#d9e5e8;' colspan='1'>CH</td>" +
                         "<td style='padding:5px; text-align:center; background-color:#d9e5e8;' colspan='1'>CAH</td>" +
               "</tr>" +

               "<tr style='padding:5px; text-align:center;' >" +
                     "<td style='padding:5px; text-align:center;' rowspan='3'>" + tk.MauMoi+"<br>"+"("+ chitieumaumoi+"chỉ tiêu)" + "</td>" +
                     "<td style='padding:5px; text-align:center;'>2 bệnh</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.benh2 + "</td>" +
                        "<td style='padding:5px; text-align:center;'>" + tk.NguyCoThap + "</td>" +
                     "<td style='padding:5px; text-align:center;'> " + tk.G6PD + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.GAL + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.PKU + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.CH + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.CAH + "</td>" +
                "</tr>" +

                "<tr style='padding:5px; text-align:center;'>" +
                     "<td style='padding:5px; text-align:center;'>3 bệnh</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.benh3 + "</td>" +
                     "<td style='padding:5px;' rowspan='2' colspan='1'>Nghi ngờ</td>" +
                     "<td style='padding:5px; text-align:center;background-color:#87dc86;' colspan='1'>Tổng</td>" +
                     "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>G6PD</td>" +
                      "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>TGAL</td>" +
                       "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>PKU</td>" +
                        "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>CH</td>" +
                         "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>CAH</td>" +
                "</tr>" +

               "<tr style='padding:5px; text-align:center;'>" +
                     "<td style='padding:5px; text-align:center;'>5 bệnh</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.benh5 + "</td>" +
                     "<td style='padding:5px; text-align:center;'> " + tk.NguyCoCao + "</td>" +
                     "<td style='padding:5px; text-align:center;'> " + tk.G6PD2 + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.GAL2 + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.PKU2 + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.CH2 + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.CAH2 + "</td>" +
               "</tr>" +
"<tr><td  style='padding:2px; text-align:center; background-color:#83e8a7;' colspan='10'></td></tr>" +
                     "<td style='padding:5px; text-align:center; background-color:#d9e5e8;' colpan='1'>Mẫu XNL</td>" +
                     "<td style='padding:5px; text-align:center;' colspan='1'>G6PD</td>" +
                      "<td style='padding:5px; text-align:center;' colspan='1'>" + tk.G6PD3 + "</td>" +
                    "<td style='padding:5px; text-align:center;' rowspan='2' colspan='1' >Nguy cơ thấp</td>" +
                    "<td style='padding:5px; text-align:center;background-color:#87dc86;' colspan='1'>Tổng</td>" +
                     "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>G6PD</td>" +
                      "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>TGAL</td>" +
                       "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>PKU</td>" +
                        "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>CH</td>" +
                         "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>CAH</td>" +
                "</tr>" +

                "<tr style='padding:5px; text-align:center;'>" +
                     "<td style='padding:5px; text-align:center;' rowspan='4'>" + tk.MauXNL + "<br>" + "(" + chitieumauxnl + "chỉ tiêu)" + "</td>" +
                    "<td style='padding:5px; text-align:center;' colspan='1'>TGAL</td>" +
                      "<td style='padding:5px; text-align:center;' colspan='1'>" + tk.GAL3 + "</td>" +
                      "<td style='padding:5px; text-align:center;'> " + tk.NguyCoThap2 + "</td>" +
                   "<td style='padding:5px; text-align:center;'> " + tk.G6PD4 + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.GAL4 + "</td>" +
                     "<td style='padding:5px;text-align:center;'>" + tk.PKU4 + "</td>" +
                     "<td style='padding:5px;text-align:center;'>" + tk.CH4 + "</td>" +
                     "<td style='padding:5px;text-align:center;'>" + tk.CAH4 + "</td>" +
                "</tr>" +

                "<tr style='padding:5px; text-align:center;'> " +
                       "<td style='padding:5px; text-align:center;'>PKU</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.PKU3 + "</td>" +
                     "<td style='padding:5px; text-align:center;' rowspan='2' colspan='1'>Nghi cơ cao</td>" +
                     "<td style='padding:5px; text-align:center;background-color:#87dc86;' colspan='1'>Tổng</td>" +
                     "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>G6PD</td>" +
                      "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>TGAL</td>" +
                       "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>PKU</td>" +
                        "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>CH</td>" +
                         "<td style='padding:5px; text-align:center;background-color:#d9e5e8;' colspan='1'>CAH</td>" +
                 "</tr>" +
                    "<tr style='padding:5px; text-align:center;'>" +
                    "<td style='padding:5px; text-align:center;' colspan='1'>CH</td>" +
                      "<td style='padding:5px; text-align:center;' colspan='1'>" + tk.PKU3 + "</td>" +
                      "<td style='padding:5px; text-align:center;'> " + tk.NguyCoCao2 + "</td>" +
                   "<td style='padding:5px; text-align:center;'> " + tk.G6PD5 + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.GAL5 + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.PKU5 + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.CH5 + "</td>" +
                     "<td style='padding:5px; text-align:center;'>" + tk.CAH5 + "</td>" +
                "</tr>" +
                  "</tr>" +
                    "<tr style='padding:5px; text-align:center;'>" +
                    "<td style='padding:5px; text-align:center;' colspan='1'>CAH</td>" +
                    "<td style='padding:5px; text-align:center;' colspan='1'>" + tk.CAH3+ "</td>" +
                   "<td style='padding:5px; text-align:center;'></td>" +
                     "<td style='padding:5px; text-align:center;'></td>" +
                     "<td style='padding:5px; text-align:center;'></td>" +
                     "<td style='padding:5px; text-align:center;'></td>" +
                     "<td style='padding:5px; text-align:center;'></td>" +
                       "<td style='padding:5px; text-align:center;'></td>" +
                     "<td style='padding:5px; text-align:center;'></td>" +
                "</tr>" +
"</table>" + "<br></br>" +
"<table width='100%'  border='1' cellpadding='0' cellspacing='0' >" +
                "<tr><td colspan=6 style='padding:5px; text-align:center;color:#ffffff; background-color:#5ec0d6;'>CHẤT LƯỢNG MẪU </td></tr >" +
                "<tr><td colspan=1 style='padding:5px; text-align:center;background-color:#d9e5e8;'>Mẫu đạt </td>" +
                "<td colspan=2 style='padding:5px; text-align:center;background-color:#d9e5e8;'>Mẫu không đạt </td>" +
                "<td colspan=1  style='padding:5px; text-align:center;'>" + tk.MauKDat + "</td>" +
                "<th colspan=2 style ='padding:5px;' >" + "" + " </td></tr>" +
       "<tr>" +
                "<td rowspan=6  style='padding:5px; text-align:center;'>" + tk.MauDat + "</td>" +
                         "<td rowspan=6 style='padding:5px; text-align:center;'>Lý Do</td>"+ 
                         "<td colspan=1 style='padding:5px; '>1. Mẫu không thấm đều 2 mặt, mẫu ít </td>"+ 
                         "<td colspan=1 style='padding:5px; text-align:center;'>"+tk.MauKdeu+", "+ tk.Mauit+" </ td > " + 
                         "<td rowspan=6 style='padding:5px; text-align:center;'>Người thu mẫu </td>" +
                         "<td colspan=1 style='padding:5px; text-align:center;'>"+ "" +" </ td > "+

           "</tr>"+
           "<tr>"+
                         "<td colspan=1 style='padding:5px; '>2. Giọt máu chồng lên nhau </td> "+
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + +tk.MauChong + " </ td > " +
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + "" + " </ td > " +

           "</tr>"+
           "<tr>" +
                         "<td colspan=1 style='padding:5px; '>3. Thời gian gửi mẫu muộn </td> " +
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + tk.GuiCham + " </ td > " +
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + "" + " </ td > " +

           "</tr>" +
            "<tr>" +
                         "<td colspan=1 style='padding:5px; '>4. Thu mẫu sớm (trước 24h tuổi) </td>" +
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + tk.ThuSom + "</td>" +
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + "" + "</td>" +
           "</tr>" +
            "<tr>" +
                         "<td colspan=1 style='padding:5px; '>5. Trẻ sinh non hoặc nhẹ cân </td>" +
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + tk.SinhNonNheCan + "</td>" +
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + "" + "</td>" +
           "</tr>" +
            "<tr>" +
                         "<td colspan=1 style='padding:5px; '>6. Lý do khác </td>" +
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + tk.LyDoKhac + "</td>" +
                         "<td colspan=1 style='padding:5px; text-align:center;'>" + "" + "</td>" +
           "</tr>" +
                    "</table>";
            return bangkq;
        }
        //Lưu File PDF
        private void LuuPDF(string MaPhieu, string MaDVCS)
        {
            PsRptTraKetQuaSangLoc data = new PsRptTraKetQuaSangLoc();
            try
            {
                var donvi = BioNet_Bus.GetThongTinDonViCoSo(MaDVCS);
                string Matiepnhan = BioNet_Bus.GetThongTinMaTiepNhan(MaPhieu, MaDVCS);
                if (donvi != null)
                {
                    var kieuTraKQ = donvi.KieuTraKetQua ?? 1;
                    data = BioNet_Bus.GetDuLieuInKetQuaSangLoc(MaPhieu, Matiepnhan, "MaBsi", MaDVCS);
                    if (kieuTraKQ == 1) // Cần sửa chỗ này, cho chọn động loat report theo cấu hình của đơn vị
                    {
                        Reports.rptPhieuTraKetQua datarp = new Reports.rptPhieuTraKetQua();
                        frmReportEditGeneral.FileLuuPDF(datarp, data);
                    }
                    else
                    if (kieuTraKQ == 2)
                    {
                        Reports.rptPhieuTraKetQua_TheoTT2 datarp = new Reports.rptPhieuTraKetQua_TheoTT2();
                        frmReportEditGeneral.FileLuuPDF(datarp, data);
                    }
                    else
                    if (kieuTraKQ == 3)
                    {
                        Reports.rptPhieuTraKetQua_TheoDonVi datarp = new Reports.rptPhieuTraKetQua_TheoDonVi();
                        frmReportEditGeneral.FileLuuPDF(datarp, data);
                    }
                    else
                    if (kieuTraKQ == 4)
                    {
                        Reports.rptPhieuTraKetQua_TheoDonVi2 datarp = new Reports.rptPhieuTraKetQua_TheoDonVi2();
                        frmReportEditGeneral.FileLuuPDF(datarp, data);
                    }
                    else
                    {
                        Reports.rptPhieuTraKetQua datarp = new Reports.rptPhieuTraKetQua();
                        frmReportEditGeneral.FileLuuPDF(datarp, data);
                    }
                }
                else
                {
                    Reports.rptPhieuTraKetQua datarp = new Reports.rptPhieuTraKetQua();
                    frmReportEditGeneral.FileLuuPDF(datarp, data);
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Lỗi phát sinh khi lấy dữ liệu in \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        //Nén file zip
        private void NenGuiMail(string pathpdf, string Maphieu, string MaDVCS)
        {
            string tendvcs = MaDVCS;
            string maphieu = Maphieu;
            string startPath = pathpdf;
            if (!Directory.Exists(pathMail))
            {
                Directory.CreateDirectory(pathMail);
            }
            else
            {

            }
            string zipPath = Application.StartupPath + "\\DSGuiMail\\" + tendvcs + "(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")" + ".zip";
           
            
            if (Directory.Exists(zipPath))
            {
                ZipFile.CreateFromDirectory(startPath, zipPath);
            }
            else
            {

                using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
                {
                    try
                    {
                        archive.CreateEntryFromFile(startPath, maphieu + ".pdf");
                    }
                    catch (Exception ex)
                    {

                    }

                }

            }
        }

        private void GV_DSPhieuMail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView Viewer = sender as GridView;
                
                string isMail = Viewer.GetRowCellValue(e.RowHandle, this.col_isGuiMail).ToString();
                if (isMail=="True" || isMail=="1")
                {
                        e.Appearance.BackColor = Color.MistyRose;
                        e.Appearance.BackColor2 = Color.PaleGoldenrod; 
                }
            
            if (e.Column.FieldName == "TinhTrangMau_Text")
                {
                    string category = Viewer.GetRowCellValue(e.RowHandle, Viewer.Columns["TinhTrangMau"]).ToString();
                   
                    int trangthai = 0;
                    try
                    {
                        trangthai = int.Parse(category);
                    }
                    catch { }


                    switch (trangthai)
                    {
                        case 1:

                            e.Appearance.BackColor = Color.DeepSkyBlue;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 2:
                            e.Appearance.BackColor = Color.Wheat;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 3:
                            e.Appearance.BackColor = Color.LightCoral;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 4:
                            e.Appearance.BackColor = Color.Violet;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 5:
                            e.Appearance.BackColor = Color.LightYellow;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                        case 6:
                            e.Appearance.BackColor = Color.SandyBrown;
                            e.Appearance.BackColor2 = Color.LightCyan;
                            break;
                    }
                }
            }
            catch (Exception ex) { }
        }

    }
}