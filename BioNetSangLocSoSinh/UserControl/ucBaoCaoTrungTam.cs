using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using BioNetBLL;
using BioNetSangLocSoSinh.FrmReports;

namespace BioNetSangLocSoSinh.UserControl
{
    public partial class ucBaoCaoTrungTam : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoTrungTam()
        {
            InitializeComponent();
        }

      

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            XtraMessageBox.Show("Tính năng đang hoàn thiện, vui lòng thử lại sau!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tileItem9_ItemClick(object sender, TileItemEventArgs e)
        {
            XtraMessageBox.Show("Tính năng đang hoàn thiện, vui lòng thử lại sau!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tileItem12_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                this.panel_Content.Dock = DockStyle.Fill;
                this.panel_Content.Visible = true;
                this.tileListBaoCaoTrungTam.Visible = false;

            //    this.panel_UserConTrol_Data.Controls.Clear();
                //    frmReportTrungTam_ChiCuc urc = new frmReportTrungTam_ChiCuc();
                urcReportTrungTam_ChiCuc urc = new urcReportTrungTam_ChiCuc();
                
                this.panel_UserConTrol_Data.Controls.Add(urc);
                urc.Dock = DockStyle.Fill;
                this.panel_UserConTrol_Data.Refresh();
                this.panel_Content.Refresh();
                // XtraMessageBox.Show("Tính năng đang hoàn thiện, vui lòng thử lại sau!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //DiaglogFrm.FrmDiaglogChonThoiGian frm = new DiaglogFrm.FrmDiaglogChonThoiGian();
                //frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //{
                //    DateTime tuNGay = frm.tuNgay;
                //    DateTime denNGay = frm.denNgay;
                //    BioNetModel.rptChiTietTrungTam dataResult = BioNet_Bus.GetBaoCaoTrungTamTongHopChiTietTheoChiCuc(tuNGay, denNGay);
                //    Reports.rptBaoCaoChiTietTrungTam datarp = new Reports.rptBaoCaoChiTietTrungTam();
                //    List<BioNetModel.rptChiTietTrungTam> lstResult = new List<BioNetModel.rptChiTietTrungTam>();
                //    lstResult.Add(dataResult);
                //    datarp.DataSource = lstResult;
                //    Reports.frmReportEditGeneral rept = new Reports.frmReportEditGeneral(datarp, "BaoCaoChiTietTrungTam");
                //    rept.ShowDialog();
                //}
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void tileItem5_ItemClick(object sender, TileItemEventArgs e)
        {

            this.panel_Content.Dock = DockStyle.Fill;
            this.panel_Content.Visible = true;
            this.tileListBaoCaoTrungTam.Visible = false;
            try
            {

                this.panel_UserConTrol_Data.Controls.Clear();
                urcReportTrungTam_DonVi urc = new urcReportTrungTam_DonVi();
                urc.Dock = DockStyle.Fill;
                this.panel_UserConTrol_Data.Controls.Add(urc);
                this.panel_UserConTrol_Data.Refresh();
                this.panel_Content.Refresh();
                // XtraMessageBox.Show("Tính năng đang hoàn thiện, vui lòng thử lại sau!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //DiaglogFrm.FrmDiaglogChonThoiGian frm = new DiaglogFrm.FrmDiaglogChonThoiGian();
                //frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //{
                //    DateTime tuNGay = frm.tuNgay;
                //    DateTime denNGay = frm.denNgay;
                //    BioNetModel.rptBaoCaoTongHop dataResult = BioNet_Bus.GetBaoCaoTongHopTrungTam(tuNGay, denNGay);
                //    Reports.rptBaocaoTrungTamSoBo datarp = new Reports.rptBaocaoTrungTamSoBo();
                //    List<BioNetModel.rptBaoCaoTongHop> lstResult = new List<BioNetModel.rptBaoCaoTongHop>();
                //    lstResult.Add(dataResult);
                //    datarp.DataSource = lstResult;
                //    Reports.frmReportEditGeneral rept = new Reports.frmReportEditGeneral(datarp, "BaoCaoTrungTamSoBo");
                //    rept.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            //   XtraMessageBox.Show("Tính năng đang hoàn thiện, vui lòng thử lại sau!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //DiaglogFrm.FrmDiaglogChonThoiGian frm = new DiaglogFrm.FrmDiaglogChonThoiGian();
            //frm.ShowDialog();
            //if (frm.DialogResult == DialogResult.OK)
            //{
            //    DateTime tuNGay = frm.tuNgay;
            //    DateTime denNGay = frm.denNgay;
            //    BioNetModel.rptChiTietTrungTam dataResult = BioNet_Bus.GetBaoCaoTrungTamTongHopChiTietTheoDonVi(tuNGay, denNGay);
            //    Reports.rptBaoCaoChiTietTrungTamTheoDonVi datarp = new Reports.rptBaoCaoChiTietTrungTamTheoDonVi();
            //    List<BioNetModel.rptChiTietTrungTam> lstResult = new List<BioNetModel.rptChiTietTrungTam>();
            //    lstResult.Add(dataResult);
            //    datarp.DataSource = lstResult;
            //    Reports.frmReportEditGeneral rept = new Reports.frmReportEditGeneral(datarp, "BaoCaoChiTietTrungTam");
            //    rept.ShowDialog();
            //}
        }

        private void tileItem11_ItemClick(object sender, TileItemEventArgs e)
        {
            XtraMessageBox.Show("Tính năng đang hoàn thiện, vui lòng thử lại sau!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tileItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            //XtraMessageBox.Show("Tính năng đang hoàn thiện, vui lòng thử lại sau!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.panel_Content.Dock = DockStyle.Fill;
            this.panel_Content.Visible = true;
            this.tileListBaoCaoTrungTam.Visible = false;
            this.panel_UserConTrol_Data.Controls.Clear();

          FrmReports.urcReporTinhTrangMau  usc = new urcReporTinhTrangMau();
            usc.Location = new System.Drawing.Point(3, 3);
            usc.Name = "ucBaoCaoTinhTrangMau";
            usc.Dock = DockStyle.Fill;
            this.panel_UserConTrol_Data.Controls.Add(usc);
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            this.panel_Content.Dock = DockStyle.Fill;
            this.panel_Content.Visible = true;
            this.tileListBaoCaoTrungTam.Visible = false;
            this.panel_UserConTrol_Data.Controls.Clear();

            UserControl.ucBaoCaoTuyChonTrungTam usc = new ucBaoCaoTuyChonTrungTam();
            usc.Location = new System.Drawing.Point(3, 3);
            usc.Name = "ucBaoCaoTuyChonTrungTam";
            usc.Dock = DockStyle.Fill;
            this.panel_UserConTrol_Data.Controls.Add(usc);
            //XtraForm fr = new XtraForm();
            //fr.FormBorderStyle = FormBorderStyle.Sizable;
            //fr.Text = "Báo cáo tùy chọn theo trung tâm";
            //fr.LookAndFeel.SkinName = "Office 2016 Colorful";
            //fr.WindowState = FormWindowState.Maximized;
            //fr.Controls.Add(usc);
            //fr.ShowDialog();

        }

        private void tileItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            this.panel_Content.Dock = DockStyle.Fill;
            this.panel_Content.Visible = true;
            this.tileListBaoCaoTrungTam.Visible = false;
            try
            {
                
                this.panel_UserConTrol_Data.Controls.Clear();
                urcReportTrungTam_SoBo urc = new urcReportTrungTam_SoBo();
                urc.Dock = DockStyle.Fill;
                this.panel_UserConTrol_Data.Controls.Add(urc);
                this.panel_UserConTrol_Data.Refresh();
                this.panel_Content.Refresh();
                // XtraMessageBox.Show("Tính năng đang hoàn thiện, vui lòng thử lại sau!", "Bionet sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //DiaglogFrm.FrmDiaglogChonThoiGian frm = new DiaglogFrm.FrmDiaglogChonThoiGian();
                //frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //{
                //    DateTime tuNGay = frm.tuNgay;
                //    DateTime denNGay = frm.denNgay;
                //    BioNetModel.rptBaoCaoTongHop dataResult = BioNet_Bus.GetBaoCaoTongHopTrungTam(tuNGay, denNGay);
                //    Reports.rptBaocaoTrungTamSoBo datarp = new Reports.rptBaocaoTrungTamSoBo();
                //    List<BioNetModel.rptBaoCaoTongHop> lstResult = new List<BioNetModel.rptBaoCaoTongHop>();
                //    lstResult.Add(dataResult);
                //    datarp.DataSource = lstResult;
                //    Reports.frmReportEditGeneral rept = new Reports.frmReportEditGeneral(datarp, "BaoCaoTrungTamSoBo");
                //    rept.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.tileListBaoCaoTrungTam.Dock = DockStyle.Fill;
            this.panel_Content.Visible = false;
            this.tileListBaoCaoTrungTam.Visible = true;
        }

        private void ucBaoCaoTrungTam_Load(object sender, EventArgs e)
        {
            this.tileListBaoCaoTrungTam.Dock = DockStyle.Fill;
            this.tileListBaoCaoTrungTam.Visible = true;
            this.panel_Content.Visible = false;
           
        }

        private void panel_UserConTrol_Data_Click(object sender, EventArgs e)
        {

        }
    }
}
