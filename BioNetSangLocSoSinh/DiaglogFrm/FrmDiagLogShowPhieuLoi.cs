using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BioNetModel;
namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmDiagLogShowPhieuLoi : DevExpress.XtraEditors.XtraForm
    {
        public FrmDiagLogShowPhieuLoi(List<PsPhieuLoiKhiDanhGia> lstPhieu)
        {
            InitializeComponent();
            this.lst = lstPhieu;
        }
        private List<PsPhieuLoiKhiDanhGia> lst = new List<PsPhieuLoiKhiDanhGia>();
        private void LoadDanhSach()
        {
            this.gridControl1.DataSource = this.lst;
        }

        private void FrmDiagLogShowPhieuLoi_Load(object sender, EventArgs e)
        {
            this.LoadDanhSach();
        }
    }
}