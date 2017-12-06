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
using DevExpress.XtraCharts;
using BioNetModel;
using BioNetBLL;

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class FrmReportThongKeCoBan : DevExpress.XtraEditors.XtraForm
    {
        public FrmReportThongKeCoBan()
        {
            InitializeComponent();
        }
        TTPhieuCB dataRessult = new TTPhieuCB();
        private void FrmReportTrungTam_DonVi_Load(object sender, EventArgs e)
        {
            this.txtChiCuc.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChiCuc();
            this.txtDonVi.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_DonVi("all");
            this.txtDonVi.EditValue = "all";
            this.txtChiCuc.EditValue = "all";
            this.LoadDuLieu();
        }
        private void LoadDuLieu()
        {
            this.dataRessult = BioNetBLL.BioNet_Bus.GetBaoCaoThongTinPhieuTheoTime(this.txtDonVi.EditValue.ToString(), this.txtChiCuc.EditValue.ToString(),this.dllNgay.tungay.Value.Date,this.dllNgay.denngay.Value.Date);
            if (this.txtDonVi.EditValue.ToString() == "all")
            {
                if (this.txtChiCuc.EditValue.ToString() == "all")
                {
                    this.lblTenDonVi.Text = "Thông kế toàn bộ trung tâm";
                }
                else
                {
                    this.lblTenDonVi.Text = "Thông kế chi cục "+ this.txtChiCuc.Text.ToString();
                }
            }
            else
            {
                this.lblTenDonVi.Text = "Thông kế đơn vị " + this.txtDonVi.Text.ToString();
            }
           
            this.LoadChuongTrinh();
            this.LoadThongKeCLMau();
            this.LoadThongKeDGMau();
            this.LoadThongKeGioiTinh();
            this.LoadThongKeGoiXN();
            this.LoadThongKePhieu();
            this.LoadThongKePPSinh();
            this.LoadThongKeThang();

        }
        private void LoadThongKeThang()
        {
            Series SLPhieu = new Series("Số lượng phiếu", ViewType.Line);
            foreach (var tkphieu in dataRessult.slphieu)
            {
                SLPhieu.Points.Add(new SeriesPoint("T" + tkphieu.Thang, tkphieu.SLphieu));
            }
            SLPhieu.Label.TextPattern = "{V:#,#}";
            SLPhieu.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartThongKePhieu.Series.Clear();
            this.chartThongKePhieu.Series.Add(SLPhieu);
            if (chartThongKePhieu.Series[0].View is LineSeriesView)
            {
                (chartThongKePhieu.Series[0].View as LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                (chartThongKePhieu.Series[0].View as LineSeriesView).Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                (chartThongKePhieu.Series[0].View as LineSeriesView).LineMarkerOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            }
        }

        private void LoadThongKeGioiTinh()
        {
            Series GioiTinh = new Series("Tị lệ Nam Nữ", ViewType.StackedBar);
            GioiTinh.Points.Add(new SeriesPoint("Nam", dataRessult.Nam));
            GioiTinh.Points.Add(new SeriesPoint("Nữ", dataRessult.Nu));
            GioiTinh.Points.Add(new SeriesPoint("Khác", dataRessult.GTKhac));
            this.chartGioiTinh.Series.Clear();
            this.chartGioiTinh.Titles.Clear();
            this.chartGioiTinh.Series.Add(GioiTinh);
            (chartGioiTinh.Series[0].View as StackedBarSeriesView).Color = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            chartGioiTinh.Titles.Add(new ChartTitle());
            chartGioiTinh.Titles[0].Text = "Tị lệ Nam/Nữ =" + (float)dataRessult.Nam / dataRessult.Nu;
            ((XYDiagram)chartGioiTinh.Diagram).Rotated = true;
        }

        private void LoadThongKePPSinh()
        {
            List<ObjectChartReport> lstPPS = new List<ObjectChartReport>();
            ObjectChartReport PPS = new ObjectChartReport { Name = "Sinh thường", Values = this.dataRessult.PPSinhThuong ?? 0 };
            lstPPS.Add(PPS);
            PPS = new ObjectChartReport { Name = "Sinh mổ", Values = this.dataRessult.PPSinhMo ?? 0 };
            lstPPS.Add(PPS);
            PPS = new ObjectChartReport { Name = "N/a", Values = this.dataRessult.PPSinhKhac ?? 0 };
            lstPPS.Add(PPS);
            this.chartPPSinh.DataSource = lstPPS;
        }

        private void LoadThongKeCLMau()
        {
            List<ObjectChartReport> lstCLM = new List<ObjectChartReport>();           
            ObjectChartReport CLM = new ObjectChartReport { Name = "Đạt", Values = this.dataRessult.MauDat ?? 0 };
            lstCLM.Add(CLM);
            CLM = new ObjectChartReport { Name = "Không Đạat", Values = this.dataRessult.MauKoDat ?? 0 };
            lstCLM.Add(CLM);
            this.chartCLMau.DataSource = lstCLM;
        }

        private void LoadThongKeGoiXN()
        {
            List<ObjectChartReport> lstGoiXN = new List<ObjectChartReport>();
            foreach (var tkbenh in dataRessult.thongkebenh)
            {
                ObjectChartReport GoiXN = new ObjectChartReport { Name = tkbenh.TenThongKe, Values = tkbenh.SoLuong };
                lstGoiXN.Add(GoiXN);
            }
            this.chartGoiXN.DataSource = lstGoiXN;
        }

        private void LoadThongKeDGMau()
        {
            List<ObjectChartReport> lstCTCLMau = new List<ObjectChartReport>();
            foreach (var tkdgmau in dataRessult.thongkeDGMau)
            {
                ObjectChartReport CTCLmau = new ObjectChartReport { Name = tkdgmau.TenThongKe, Values = tkdgmau.SoLuong };
                lstCTCLMau.Add(CTCLmau);
            }
            this.chartCTCLMau.DataSource = lstCTCLMau;
        }

        private void LoadChuongTrinh()
        {
            List<ObjectChartReport> lstChuongTrinh = new List<ObjectChartReport>();
            foreach (var tkctrinh in dataRessult.thongkeCTrinh)
            {
                ObjectChartReport ChuongTrinh = new ObjectChartReport { Name = tkctrinh.TenThongKe, Values = tkctrinh.SoLuong };
                lstChuongTrinh.Add(ChuongTrinh);
            }
            this.chartChuongTrinh.DataSource = lstChuongTrinh;
        }

        private void LoadThongKePhieu()
        {
            Series Phieu = new Series("Tổng số phiếu: " + dataRessult.TongSoPhieu, ViewType.StackedBar);
            Phieu.Points.Add(new SeriesPoint("Phiếu mới", dataRessult.PhieuThuMoi));
            Phieu.Points.Add(new SeriesPoint("Phiếu thu lại", dataRessult.PhieuThuLai));
            Phieu.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartPhieu.Series.Clear();
            this.chartPhieu.Titles.Clear();
            this.chartPhieu.Series.Add(Phieu);
           this.chartPhieu.Titles.Add(new ChartTitle());
            this.chartPhieu.Titles[0].Text = "Tổng số phiếu:" + dataRessult.TongSoPhieu;
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
            this.LoadDuLieu();
        }

        private void butPrint_Click(object sender, EventArgs e)
        {

        }
    }
}