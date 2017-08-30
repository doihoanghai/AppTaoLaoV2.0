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
    public partial class FrmDiaglogChonThoiGian : DevExpress.XtraEditors.XtraForm
    {
        public FrmDiaglogChonThoiGian()
        {
            InitializeComponent();
            this.txtDenNgay.DateTime = DateTime.Now ;
            this.txtTuNgay.DateTime = DateTime.Now;
        }
        public DateTime tuNgay = DateTime.Now;
        public DateTime denNgay = DateTime.Now;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
        private bool KiemTraThoiGian()
        {
            if(string.IsNullOrEmpty(this.txtTuNgay.Text.Trim()))
            {
                XtraMessageBox.Show("Vui lòng chọn ngày cần xem báo cáo", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtDenNgay.Text.Trim()))
            {
                XtraMessageBox.Show("Vui lòng chọn ngày cần xem báo cáo", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            try
            {
                if(((DateTime)  this.txtDenNgay.EditValue).Year >1975 && ((DateTime)this.txtDenNgay.EditValue).Year<2500 &&( (DateTime)this.txtTuNgay.EditValue).Year > 1975 && ((DateTime)this.txtTuNgay.EditValue).Year < 2500 )
                {
                }
                else
                {
                    XtraMessageBox.Show("Thời gian báo cáo phải sau năm 1975 và trước năm 2500!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                
            }
                catch {
                XtraMessageBox.Show("Định dạng ngày tháng không hợp lệ \r\n Thời gian báo cáo phải sau năm 1975 và trước năm 2500!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            if(KiemTraThoiGian())
            {
                this.tuNgay = (DateTime)this.txtTuNgay.EditValue;
                this.denNgay = (DateTime)this.txtDenNgay.EditValue;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}