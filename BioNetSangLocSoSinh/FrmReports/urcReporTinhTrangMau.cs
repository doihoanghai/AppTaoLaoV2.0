using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UserControlDate;
using BioNetModel;
using DevExpress.XtraCharts;
using BioNetBLL;
using DevExpress.XtraGrid.Views.Grid;

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class urcReporTinhTrangMau : DevExpress.XtraEditors.XtraUserControl
    {
        public urcReporTinhTrangMau()
        {
            InitializeComponent();
        }

        BioNetModel.rptChiTietTrungTam dataResultFull = new rptChiTietTrungTam();
        BioNetModel.rptChiTietTrungTam dataResult = new rptChiTietTrungTam();
        private void LoadDuLieuBaoCao()
        {
           this.GC_DanhSachPhieu.DataSource = BioNet_Bus.GetTinhTrangPhieu(this.dllNgay.tungay.Value,this.dllNgay.denngay.Value, txtDonVi.EditValue.ToString());
        }
        private void urcReportTrungTam_SoBo_Load(object sender, EventArgs e)
        {
            this.PanelSingle.Visible = true;
            this.PanelSingle.Dock = DockStyle.Fill;
            this.txtChiCuc.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChiCuc();
            this.txtDonVi.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DonVi("all");
            this.txtDonVi.EditValue = "all";

        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.LoadDuLieuBaoCao();
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

        private void GV_DanhSachPhieu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView Viewer = sender as GridView;
                if (e.Column.FieldName == "TinhTrangMau_Text")
                {
                    string category = Viewer.GetRowCellValue ( e.RowHandle, Viewer.Columns["TinhTrangMau"]).ToString();
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
