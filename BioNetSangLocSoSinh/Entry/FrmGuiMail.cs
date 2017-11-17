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
                            if (!Directory.Exists(pathpdf)) { LuuPDF(maPhieu, maDVCS); }//Nếu ko có phiếu thì in lại phiếu 
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
                                MessageBox.Show("Gửi mail cho đơn vị " + madvcs + " thất bại", "bionet - chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                                break;
                            }
                            else if (kq == 2)
                            {
                                MessageBox.Show("Email của đơn vị " + madvcs + " không tồn tại", "bionet - chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                                break;
                            }
                            else if (kq == 5)
                            {
                                MessageBox.Show("Dữ liệu của Email của trung tâm lỗi - Vui lòng kiểm tra lại dữ liệu ", "bionet - chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                                break;
                            }
                        }
                        SplashScreenManager.CloseForm();
                        if (kq == 0) { MessageBox.Show("Gửi Mail thành công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK); }
                        //Xóa file nén đã gửi mail
                        DirectoryInfo dirInfo = new DirectoryInfo(pathMail);
                        FileInfo[] childFiles = dirInfo.GetFiles();
                        foreach (FileInfo childFile in childFiles) { File.Delete(childFile.FullName); }
                    }
                    else { MessageBox.Show("Vui lòng tick vào phiếu cần gửi mail", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK); }
                }
                catch(Exception ex)
                {

                }
               
            }
            else if (dialogResult == DialogResult.No) { return; }

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
                string pathzip = pathMail + madvcs + ".zip";

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
            string zipPath = Application.StartupPath + "\\DSGuiMail\\" + MaDVCS + ".zip";
           string[] maphieu = null;
           
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string[] temp = entry.Name.Split('.');
                    if(maphieu==null)
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
          
            List<PSTKKQPhieuMail> tk = new List<PSTKKQPhieuMail>();
            tk = BioNet_Bus.GetThongKePhieuMail(maphieu);

            string bangkq = "<table width='100%'  border='1' cellpadding='0' cellspacing='0' >" +
               "<tr style='padding:5px;'>" +
                    "<th style='padding:5px; text-align:center; 'colspan='3' >SỐ MẪU GỬI BIONET</th>" +
                    "<th style='padding:5px; tex -align:center; ' colspan='7'>KẾT QUẢ XN</th>" +
               "</tr >" +

               "<tr style='padding:5px;'>" +
                    "<td style='padding:5px;' rowspan='1'>Mẫu mới:</td>" +
                    "<td style='padding:5px;'>2 bệnh</td>" +
                    "<td style='padding:5px;'>"+tk[0].benh2+"</td>" +
                    "<td style='padding:5px;'>Nguy Cơ Thấp</td>" +
                    "<td style='padding:5px; text-align:center;' colspan='6'>"+tk[0].NguyCoThap+"</td>" +
               "</tr>" +

               "<tr style='padding:5px;' >" +
                     "<td style='padding:5px;' rowspan='2'>" + tk[0].MauMoi + "</td>" +
                     "<td style='padding:5px;'>3 bệnh</td>" +
                     "<td style='padding:5px;'> " + tk[0].benh3 + "</td>" +
                     "<td style='padding:5px;'>Nghi ngờ</td>" +
                     "<td style='padding:5px;'>G6PD</td>" +
                     "<td style='padding:5px;'> " + tk[0].G6PD + "</td>" +
                     "<td style='padding:5px;'>GAL</td>" +
                     "<td style='padding:5px;'>" + tk[0].GAL+ "</td>" +
                     "<td style='padding:5px;'>PKU</td>" +
                     "<td style='padding:5px;'>" + tk[0].PKU + "</td>" +
                "</tr>" +

                "<tr style='padding:5px;'>" +
                     "<td style='padding:5px;'>5 bệnh</td>" +
                     "<td style='padding:5px;'>" + tk[0].benh5 + "</td>" +
                     "<td style='padding:5px;'>" + tk[0].NguyCoCao + "</td>" +
                     "<td style='padding:5px;'>CH</td>" +
                     "<td style='padding:5px;'> " + tk[0].CH + "</td>" +
                     "<td style='padding:5px;'>CAH</td>" +
                     "<td style='padding:5px;'> " + tk[0].CAH + "</td>" +
                     "<td style='padding:5px;'></td>" +
                     "<td style='padding:5px;'> </td>" +
                "</tr>" +

               "<tr style='padding:5px;'>" +
                     "<td style='padding:5px;' rowspan='1'>Mẫu XNL</td>" +
                     "<td style='padding:5px;'>G6PD</td>" +
                     "<td style='padding:5px;'> " + tk[0].G6PD2 + "</td>" +
                     "<td style='padding:5px;'>Nguy cơ thấp</td>" +
                     "<td style='padding:5px;'>G6PD</td>" +
                     "<td style='padding:5px;'>" + tk[0].G6PD3 + "</td>" +
                     "<td style='padding:5px;'>GAL</td>" +
                     "<td style='padding:5px;'> " + tk[0].GAL3 + "</td>" +
                     "<td style='padding:5px;'>PKU</td>" +
                     "<td style='padding:5px;'> " + tk[0].PKU3 + "</td>" +
               "</tr>" +

               "<tr style='padding:5px;'>" +
                      "<td style='padding:5px; text-align:center;' rowspan='4'>" + tk[0].MauXNL + "</td>" +
                     "<td style='padding:5px;'>GAL</td>" +
                     "<td style='padding:5px;'> " + tk[0].GAL2 + "</td>" +
                     "<td style='padding:5px;'>" + tk[0].NguyCoThap2 + "</td>" +
                     "<td style='padding:5px;'>CH</td>" +
                     "<td style='padding:5px;'> " + tk[0].CH3 + "</td>" +
                     "<td style='padding:5px;'>CAH</td>" +
                     "<td style='padding:5px;'> " + tk[0].CAH3 + "</td>" +
                     "<td style='padding:5px;'></td>" +
                     "<td style='padding:5px;'></td>" +
               "</tr>" +

                "<tr>" +
                     "<td style='padding:5px;'>PKU</td>" +
                     "<td style='padding:5px;'> " + tk[0].PKU2 + "</td>" +
                     "<td style='padding:5px;'>Nguy cơ Cao</td>" +
                     "<td style='padding:5px; 'colspan='6'></td>" +
                "</tr>" +

                "<tr style='padding:5px;'>" +
                     "<td style='padding:5px;'>CH</td>" +
                     "<td style='padding:5px;'>" + tk[0].CH2 + "</td>" +
                     "<td style='padding:5px; text-align:center;' rowspan ='2'>" + tk[0].NguyCoCao2 + "</td>" +
                     "<td style='padding:5px;'>G6PD</td>" +
                     "<td style='padding:5px;'> " + tk[0].G6PD4 + "</td>" +
                     "<td style='padding:5px;'>GAL</td>" +
                     "<td style='padding:5px;'> " + tk[0].GAL4 + "</td>" +
                     "<td style='padding:5px;'>PKU</td>" +
                    " <td style='padding:5px;'> " + tk[0].PKU4 + "</td>" +
                "</tr>" +

                "<tr style='padding:5px;'> " +
                     "<td style='padding:5px;'>CAH</td>" +
                     "<td style='padding:5px;'> " + tk[0].CAH2 + "</td>" +
                     "<td style='padding:5px;'>CH</td>" +
                     "<td style='padding:5px;'>" + tk[0].CH4 + "</td>" +
                     "<td style='padding:5px;'>CAH</td>" +
                     "<td style='padding:5px;'>" + tk[0].CAH4 + "</td>" +
                     "<td style='padding:5px;'></td>" +
                     "<td style='padding:5px;'></td>" +
                 "</tr>" +

                 "<tr style='padding:5px;'>" +
                     "<td style='padding:5px; text-align:center;' colspan='10'  >Chất lượng mẫu</td>" +
                 "</tr>" +

                 "<tr style='padding:5px;'>" +
                     "<td style='padding:5px;' colspan='1' >Mẫu đạt: </td>" +
                     "<td style='padding:5px; text-align:center;'colspan='9' >" + tk[0].MauDat + "</td>" +
                 "</tr>" +

                 "<tr style='padding:5px;'>" +
                     "<td style='padding:5px;' colspan='1' >Mẫu không đạt:</td>" +
                     "<td style='padding:5px;' colspan='1' rowspan='5' >Lý do: </td>" +
                     "<td style='padding:5px;' colspan='3' >1. Mẫu ít:</td>" +
                     "<td style='padding:5px;' colspan='1' >" + tk[0].Mauit + "</td>" +
                     "<td style='padding:5px; text-align:center; vertical-align: top;' colspan='2' rowspan='5' >Người thu mẫu</td>" +
                     "<td style='padding:5px; text-align:center; vertical-align: top;' colspan='2' rowspan='5'>N/A</td>" +
                 "</tr>" +

                "<tr style='padding:5px;'>" +
                     "<td style='padding:5px; text-align:center;' colspan='1' rowspan='5' >" + tk[0].MauKDat+ "</td>" +
                     "<td style='padding:5px;' colspan='3'>2. Mẫu có vòng huyết thanh</td>" +
                     "<td style='padding:5px;' colspan='1' >" + tk[0].MauCoVongHuyetThanh + "</td>" +
                "</tr>" +

                "<tr style='padding:5px;'>" +
                     "<td style='padding:5px;' colspan='3'>3. Mẫu không thấm đều 2 mặt</td>" +
                     "<td style='padding:5px;' colspan='1' >" + tk[0].MauKdeu + "</td>" +
                "</tr>" +

                "<tr style='padding:5px;'>" +
                      "<td style='padding:5px;' colspan='3'>4. Mẫu chưa khô</td>" +
                      "<td style='padding:5px;' colspan='1' >" + tk[0].MauChuaKho + "</td>" +
                 "</tr>" +

                 "<tr style='padding:5px;'>" +
                      "<td style='padding:5px;' colspan='3'>5. Giọt máu chồng lên nhau</td>" +
                      "<td style='padding:5px;' colspan='1' >" + tk[0].MauChong + "</td>" +
                 "</tr>"+

           "</table>" ;
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
            string zipPath = Application.StartupPath + "\\DSGuiMail\\" + tendvcs + ".zip";
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