using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmDiaglogCapMaTuChon : DevExpress.XtraEditors.XtraForm
    {
        public FrmDiaglogCapMaTuChon(ref string maXN)
        {
            InitializeComponent();
        }
        private string maTiepNhan = string.Empty;
        private string maPhieu = string.Empty;
        private string maChiDinh = string.Empty;
        private void btnCapMa_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtMaXetNghiem.Text.Trim()))
            {
                XtraMessageBox.Show(" Vui lòng không để trống mã xét nghiệm", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try 
            {if (KiemTraMaXNLaKieuSo(this.txtMaXetNghiem.Text.Trim()))//đổi mã ra số nếu không được tức là có chữ
                {
                    long ma = long.Parse(this.txtMaXetNghiem.Text.Trim());
                    //long sobd = long.Parse(BioNetBLL.BioNet_Bus.GetMaXNTrongBangGhi());
                    long sobd = long.Parse(BioNetBLL.BioNet_Bus.GetMaXetNghiemTrongDB());
                    if (ma > sobd + 1)
                    {
                        XtraMessageBox.Show("Mã xét nghiệm không được lớn hơn " + sobd + 1, "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch { XtraMessageBox.Show("", "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            

        }
        private bool KiemTraMaXNHopLe (string maXN) //
        {
            return false;
        }
        private bool KiemTraMaXNLaKieuSo(string text)
        {
            try
            {
                long ma = long.Parse(this.txtMaXetNghiem.Text.Trim());
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}