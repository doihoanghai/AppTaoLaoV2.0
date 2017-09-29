using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Linq;
using System.IO;
using System.Net.Mail;

namespace BioNetSangLocSoSinh.Entry
{
    public partial class FrmThongTinTrungTam : DevExpress.XtraEditors.XtraForm
    {
        public FrmThongTinTrungTam()
        {
            InitializeComponent();
        }
        BioNetModel.Data.PSThongTinTrungTam tt = new BioNetModel.Data.PSThongTinTrungTam();
        private bool isloaded = false;
        private void LoadThongTinTrungTam()
        {
            this.tt = BioNetBLL.BioNet_Bus.GetThongTinTrungTam();
            if (tt != null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream(this.tt.Logo.ToArray());
                    pictureEdit1.Image = Image.FromStream(ms);
                }
                catch { }
                txtTrungTam.Text = this.tt.TenTrungTam;
                txtSoDT.Text = this.tt.DienThoai;
                txtMaVietTat.Text = this.tt.MaVietTat;
                txtDiaChi.Text = this.tt.Diachi;
                txtEmail.Text = this.tt.Email;
                txtPassEmail.Text = this.tt.PassEmail;
                checkChoPhepNghiNgo.Checked = this.tt.isChoXNLan2 ?? false;
                checkChoPhepThuMauLai.Checked = this.tt.isChoThuLaiMauLan2 ?? false;
                checkBoxCapMaXnTheoMaPhieu.Checked = this.tt.isCapMaXNTheoMaPhieu ?? false;
            }
        }
        private void FrmThongTinTrungTam_Load(object sender, EventArgs e)
        {
            this.LoadThongTinTrungTam();
            this.LoadThongTinGCGhiChu();
            this.isloaded = true;
        }

        private DataTable hienThi()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("Id", typeof(bool));
            tb.Rows.Add("Trước", true);
            tb.Rows.Add("Sau", false);
            return tb;
        }

        private void LoadThongTinGCGhiChu()
        {
            var lstGc = BioNetBLL.BioNet_Bus.GetListCauHinhGhiChu();
            this.GCGhiChu.DataSource = lstGc;
            this.repositoryItemLookUp_HienThi.DataSource = hienThi();
            this.repositoryItemLookUp_HienThi.ValueMember = "Id";
            this.repositoryItemLookUp_HienThi.DisplayMember = "Name";
        }
        private void checkChoPhepNghiNgo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit chk = sender as CheckEdit;
                if (this.isloaded)
                {
                    this.tt.isChoXNLan2 = chk.Checked;
                    this.btnLuu.Enabled = true;
                }
            }
            catch { }

        }

        private void checkChoPhepThuMauLai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit chk = sender as CheckEdit;
                if (this.isloaded)
                {
                    this.tt.isChoThuLaiMauLan2 = chk.Checked;
                    this.btnLuu.Enabled = true;
                }
            }
            catch { }
        }

        private void GvGhiChu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    GridView view = sender as GridView;
            //    var rowHandle = e.RowHandle;
            //    if (rowHandle > 0)
            //    {
            //        BioNetModel.Data.PSDanhMucGhiChu ghichu = new BioNetModel.Data.PSDanhMucGhiChu();
            //        ghichu.isNoiDungDatTruoc = view.GetRowCellValue(rowHandle, this.col_KieuHienThi) == null ? true : (bool)view.GetRowCellValue(rowHandle, this.col_KieuHienThi);
            //        ghichu.MaGhiChu = view.GetRowCellValue(rowHandle, this.col_MaGChu).ToString();
            //        ghichu.ThongTinHienThiGhiChu = view.GetRowCellValue(rowHandle, this.col_NoidungGhiChu).ToString();
            //       var res =  BioNetBLL.BioNet_Bus.UpdateDanhMucGhiChu(ghichu);
            //        if(!res.Result)
            //        {
            //            XtraMessageBox.Show("Lỗi phát sinh khi lưu \r\n Lỗi chi tiết :" + res.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //       this.LoadThongTinGCGhiChu(); 
            //    }
            //}
            //catch(Exception ex)
            //{
            //    XtraMessageBox.Show("Lỗi phát sinh khi lấy dữ liệu để lưu \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {

            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image File|*.jpg;*.jpeg;*.png";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.pictureEdit1.Image = (Image)Image.FromFile(of.FileName);
                    var fileBytes = File.ReadAllBytes(of.FileName);
                    var image = new Binary(fileBytes);
                    this.tt.Logo = image;
                    this.btnLuu.Enabled = true;
                }
                catch (Exception ex) { }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn thay đổi thông tin trung tâm", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                this.tt.TenTrungTam = txtTrungTam.Text.Trim();
                this.tt.Diachi = txtDiaChi.Text.Trim();
                this.tt.DienThoai = txtSoDT.Text.Trim();
                this.tt.isChoThuLaiMauLan2 = this.checkChoPhepThuMauLai.Checked;
                this.tt.isChoXNLan2 = this.checkChoPhepNghiNgo.Checked;
                this.tt.isCapMaXNTheoMaPhieu = this.checkBoxCapMaXnTheoMaPhieu.Checked;
                this.tt.Email = txtEmail.Text.Trim();
                this.tt.PassEmail = txtPassEmail.Text.Trim();
                bool result = regex.IsMatch(tt.Email);
                if (result == false)
                {
                    //Lỗi địa chỉ mail
                    XtraMessageBox.Show("Địa chỉ Email không hợp lệ - Vui lòng kiểm tra lại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        MailMessage mail = new MailMessage(tt.Email,"thanhquangqb95@gmail.com");
                        mail.Subject = "Thư Kiểm Tra Mật Khẩu";
                        mail.Body = "Đây là thư kiểm tra xác nhận mật khẩu của phần mềm bionet";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.Credentials = new System.Net.NetworkCredential(tt.Email, tt.PassEmail);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        mail.Dispose();
                        
                    }
                    catch {
                        XtraMessageBox.Show("Mật Khẩu Email không hợp lệ - Vui lòng kiểm tra lại!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                   
                    var rss = BioNetBLL.BioNet_Bus.UpdateThongTinTrungTam(this.tt);
                    if (rss.Result)
                    {
                        XtraMessageBox.Show("Lưu thông tin trung tâm sàng lọc thành công!", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                        this.btnLuu.Enabled = false;
                        txtDiaChi.Enabled = false;
                        txtEmail.Enabled = false;
                        txtPassEmail.Enabled = false;
                        txtSoDT.Enabled = false;
                        txtTrungTam.Enabled = false;
                        this.isloaded = false;
                        this.LoadThongTinTrungTam();
                        this.isloaded = true;
                        this.btnHuy.Enabled = false;
                        this.btnSua.Enabled = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi phát sinh khi lấy dữ liệu để lưu \r\n Lỗi chi tiết :" + rss.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else if (dialogResult == DialogResult.No) { return; }

        }



        private void checkBoxCapMaXnTheoMaPhieu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit chk = sender as CheckEdit;
                if (this.isloaded)
                {
                    this.tt.isCapMaXNTheoMaPhieu = chk.Checked;
                    this.btnLuu.Enabled = true;
                }
            }
            catch { }
        }

        private void GvGhiChu_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            try
            {
                GridView view = sender as GridView;
                var rowHandle = e.RowHandle;
                if (rowHandle > 0)
                {
                    BioNetModel.Data.PSDanhMucGhiChu ghichu = new BioNetModel.Data.PSDanhMucGhiChu();
                    ghichu.isNoiDungDatTruoc = view.GetRowCellValue(rowHandle, this.col_KieuHienThi) == null ? true : (bool)view.GetRowCellValue(rowHandle, this.col_KieuHienThi);
                    ghichu.MaGhiChu = view.GetRowCellValue(rowHandle, this.col_MaGChu).ToString();
                    ghichu.ThongTinHienThiGhiChu = view.GetRowCellValue(rowHandle, this.col_NoidungGhiChu).ToString();
                    var res = BioNetBLL.BioNet_Bus.UpdateDanhMucGhiChu(ghichu);
                    if (!res.Result)
                    {
                        XtraMessageBox.Show("Lỗi phát sinh khi lưu \r\n Lỗi chi tiết :" + res.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.LoadThongTinGCGhiChu();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi lấy dữ liệu để lưu \r\n Lỗi chi tiết :" + ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtPassEmail.Enabled = true;
            txtSoDT.Enabled = true;
            txtTrungTam.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có hủy việc thay đổi thông tin trung tâm", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.btnLuu.Enabled = false;
                txtDiaChi.Enabled = false;
                txtEmail.Enabled = false;
                txtPassEmail.Enabled = false;
                txtSoDT.Enabled = false;
                txtTrungTam.Enabled = false;
                this.isloaded = false;
                this.LoadThongTinTrungTam();
                this.isloaded = true;
                this.btnHuy.Enabled = false;
                this.btnSua.Enabled = true;
            }
        }
    }
}