using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class FrmBaoCapMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmBaoCapMain()
        {
            InitializeComponent();
        }

        private void tbItemVEN_ItemClick(object sender, TileItemEventArgs e)
        {
            tbDrugFunction.SelectedItem.Checked = true;
            if(pnDetails.Controls.Count>0)
            {
                foreach(System.Windows.Forms.UserControl item in pnDetails.Controls)
                {
                    item.Dispose();
                }
            }
            pnDetails.Controls.Clear();
            GC.Collect();
           UserControl.ucBaoCaoTrungTam BcTrungTam = new UserControl.ucBaoCaoTrungTam();
            BcTrungTam.Dock = DockStyle.Fill;
            pnDetails.Controls.Add(BcTrungTam);
        }

        private void tbItemADR_ItemClick(object sender, TileItemEventArgs e)
        {
            tbDrugFunction.SelectedItem.Checked = true;
            if (pnDetails.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.UserControl item in pnDetails.Controls)
                {
                    item.Dispose();
                }
            }
            pnDetails.Controls.Clear();
            GC.Collect();
            UserControl.ucBaoCaoChiCuc BcChiCuc= new UserControl.ucBaoCaoChiCuc();
            pnDetails.Controls.Add(BcChiCuc);
        }

        private void tbItemDDD_ItemClick(object sender, TileItemEventArgs e)
        {
            tbDrugFunction.SelectedItem.Checked = true;
            if (pnDetails.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.UserControl item in pnDetails.Controls)
                {
                    item.Dispose();
                }
            }
            pnDetails.Controls.Clear();
            GC.Collect();
            UserControl.ucBaoCaoDonVi BcdoVi = new UserControl.ucBaoCaoDonVi();
            pnDetails.Controls.Add(BcdoVi);
        }

        //private void tbItemADR_ItemClick(object sender, TileItemEventArgs e)
        //{
        //    tbDrugFunction.SelectedItem.Checked = true;
        //    if (pnDetails.Controls.Count > 0)
        //    {
        //        foreach (UserControl item in pnDetails.Controls)
        //        {
        //            item.Dispose();
        //        }
        //    }
        //    pnDetails.Controls.Clear();
        //    GC.Collect();
        //    iHIS.Inventory.Utility.Adr.ucADR ucADR = new Adr.ucADR();
        //    pnDetails.Controls.Add(ucADR);
        //}

        //private void tbItemDDD_ItemClick(object sender, TileItemEventArgs e)
        //{
        //    tbDrugFunction.SelectedItem.Checked = true;
        //    if (pnDetails.Controls.Count > 0)
        //    {
        //        foreach (UserControl item in pnDetails.Controls)
        //        {
        //            item.Dispose();
        //        }
        //    }
        //    pnDetails.Controls.Clear();
        //    GC.Collect();
        //    iHIS.Inventory.Utility.DDD.ucDDD ucDDD = new DDD.ucDDD();
        //    pnDetails.Controls.Add(ucDDD);
        //}

        //private void tbItemCautionDrug_ItemClick(object sender, TileItemEventArgs e)
        //{
        //    tbDrugFunction.SelectedItem.Checked = true;
        //    if (pnDetails.Controls.Count > 0)
        //    {
        //        foreach (UserControl item in pnDetails.Controls)
        //        {
        //            item.Dispose();
        //        }
        //    }
        //    pnDetails.Controls.Clear();
        //    GC.Collect();
        //    iHIS.Inventory.Utility.Me.ucMe ucME = new Me.ucMe();
        //    pnDetails.Controls.Add(ucME);
        //}
    }
}