using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetBLL;

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmDiaglogGhiChuXetNghiem : DevExpress.XtraEditors.XtraForm
    {
        public FrmDiaglogGhiChuXetNghiem(string maKetQua)
        {
            InitializeComponent();
            this.maKQ = maKetQua;
        }
        private string maKQ = string.Empty;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.txtGhiChu.Enabled = true;
            this.txtGhiChu.ReadOnly = false;
            this.btnSua.Enabled = false;
            this.btnLuu.Enabled = true;
        }
        private void LuuGhiChu()
        {
            try
            {
                var res = BioNet_Bus.UpdateGhiChuXetNghiem(this.maKQ, this.txtGhiChu.Text);
                if(res.Result)
                {
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Lỗi khi lưu! \r\n Lỗi chi tiết " + res.StringError, "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lưu! \r\n Lỗi chi tiết "+ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void FrmDiaglogGhiChuXetNghiem_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(maKQ))
            {
                XtraMessageBox.Show("Không tìm thấy nội dung mà bạn cần!", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btnSua.Enabled = false;
                this.btnThoat.Focus();
            }
            else
            {
                var res = BioNet_Bus.GetGhiChuPhongXetNghiem(maKQ);
                if(!string.IsNullOrEmpty(res))
                    {
                    this.txtGhiChu.Text = res;
                    this.btnSua.Enabled = true;
                    this.txtGhiChu.Enabled = false;
                    this.txtGhiChu.ReadOnly = true;
                }else
                {
                    XtraMessageBox.Show("Không tìm thấy nội dung mà bạn cần!", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.btnSua.Enabled = false;
                    this.btnThoat.Focus();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.LuuGhiChu();
        }
    }
}