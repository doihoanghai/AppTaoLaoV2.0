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
using BioNetModel;
using BioNetSangLocSoSinh.UserControl;


namespace BioNetSangLocSoSinh.DiaglogFrm
{
    public partial class FrmDiaglogCapMaTuDong : DevExpress.XtraEditors.XtraForm
    {
        public FrmDiaglogCapMaTuDong()
        {
            InitializeComponent();
        }
        private int x = 2;
        public List<PsDanhSachCapMa> lstCapMaTheoDonVi = new List<PsDanhSachCapMa>();
        public void LoadDanhSachCapMa()
        { }
        private void FrmDiaglogCapMaTuDong_Load(object sender, EventArgs e)
        {
            foreach (var item in this.lstCapMaTheoDonVi)
            {
                UscCapMaTheoDonVi us = new UscCapMaTheoDonVi(item.maDonVi);
                us.Location = new System.Drawing.Point(1, x);
                us.AutoSize = true;
                us.Name = item.maDonVi;
                us.SetGiaTri(item.soBatDau, item.soLuong);
                this.GroupDanhSach.Controls.Add(us);
                x += 29;
            }
            
          
        }

        private void btnLuuMaXN_Click(object sender, EventArgs e)
        {
            foreach( var control in this.GroupDanhSach.Controls)
            {
                try
                {
                    UscCapMaTheoDonVi ctr = control as UscCapMaTheoDonVi;
                    var ct = this.lstCapMaTheoDonVi.FirstOrDefault(p => p.maDonVi == ctr.Name);
                    if( ct !=null)
                    {
                        ct.soBatDau = ctr.maBD;
                    }
                }
                catch { }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}