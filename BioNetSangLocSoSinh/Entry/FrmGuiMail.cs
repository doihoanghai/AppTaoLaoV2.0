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
            LoadDuLieuBaoCao();

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
                            MessageBox.Show("Gửi mail cho đơn vị " + madvcs + " thất bại", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                            break;
                        }
                        else if (kq == 2)
                        {
                            MessageBox.Show("Email của đơn vị " + madvcs + " không tồn tại", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                            break;
                        }
                    }
                    if (kq == 0) { MessageBox.Show("Gửi Mail thành công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK); }
                    //Xóa file nén đã gửi mail
                    DirectoryInfo dirInfo = new DirectoryInfo(pathMail);
                    FileInfo[] childFiles = dirInfo.GetFiles();
                    foreach (FileInfo childFile in childFiles) { File.Delete(childFile.FullName); }
                }
                else { MessageBox.Show("Vui lòng tick vào phiếu cần gửi mail", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK); }
            }
            else if (dialogResult == DialogResult.No) { return; }

        }
        private int GuiMail(string MaDVCS)
        {
            string madvcs = MaDVCS;
            string pathzip = pathMail + madvcs + ".zip";
            //string MailKH = BioNet_Bus.GetThongTinMailDonViCoSo(madvcs);
            string mailKh = "thanhquangqb95@gmail.com";
            int kq = DataSync.BioNetSync.GuiMail.Send_Email_With_Attachment(mailKh, fromAddress, pathzip);
            //File.Create(pathzip).Close();
            return kq;
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
        private void NenGuiMail(string pathpdf, string Maphieu, string MaDVCS)
        {
            string tendvcs = MaDVCS;
            string maphieu = Maphieu;
            string startPath = pathpdf;
            if (!Directory.Exists(pathMail))
            {
                Directory.CreateDirectory(pathMail);
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
                    catch(Exception ex)
                    {
                        
                    }
               
                }
            }
        }
    }
}