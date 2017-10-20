using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using BioNetModel;

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class urcReportTTPhieu_DonVi : DevExpress.XtraEditors.XtraUserControl
    {
        public urcReportTTPhieu_DonVi()
        {
            InitializeComponent();
        }
        TTPhieuCB dataRessult = new TTPhieuCB();
        public void  LoadDuLieu()
        {
            List<ObjectChartReport> lstPPS = new List<ObjectChartReport>();
            List<ObjectChartReport> lstCLM = new List<ObjectChartReport>();
            this.dataRessult = BioNetBLL.BioNet_Bus.GetBaoCaoThongTinPhieu("", "", "");
            Series SLPhieu = new Series("Số lượng phiếu", ViewType.Line);
           foreach(var tkphieu in dataRessult.slphieu)
            {
                SLPhieu.Points.Add(new SeriesPoint("T" + tkphieu.Thang, tkphieu.SLphieu));
            }
            SLPhieu.Label.TextPattern = "{V:#,#}";
            SLPhieu.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartThongKePhieu.Series.Clear();
            this.chartThongKePhieu.Series.Add(SLPhieu);
            if (chartThongKePhieu.Series[0].View is LineSeriesView)
                (chartThongKePhieu.Series[0].View as LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            Series GioiTinh = new Series("Tị lệ Nam Nữ", ViewType.StackedBar);
            GioiTinh.Points.Add(new SeriesPoint("Nam",dataRessult.Nam ));
            GioiTinh.Points.Add(new SeriesPoint("Nữ", dataRessult.Nu));
            GioiTinh.Points.Add(new SeriesPoint("Khác", dataRessult.GTKhac));
            GioiTinh.Label.TextPattern = "{V:#,#}";
            GioiTinh.LegendText = "Tị lệ Nam/Nữ =" + (float)dataRessult.Nam / dataRessult.Nu;
            GioiTinh.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartGioiTinh.Series.Clear();
            this.chartGioiTinh.Series.Add(GioiTinh);
            chartGioiTinh.Titles.Add(new ChartTitle());
            chartGioiTinh.Titles[0].Text = "Tị lệ Nam/Nữ =" + (float)dataRessult.Nam / dataRessult.Nu;
            ((XYDiagram)chartGioiTinh.Diagram).Rotated = true;


            ObjectChartReport PPS = new ObjectChartReport { Name = "Sinh thường", Values = this.dataRessult.PPSinhThuong??0 };
            lstPPS.Add(PPS);
               PPS = new ObjectChartReport { Name = "Sinh mổ", Values = this.dataRessult.PPSinhMo ?? 0 };
            lstPPS.Add(PPS);
            PPS = new ObjectChartReport { Name = "N/a", Values = this.dataRessult.PPSinhKhac ?? 0 };
            lstPPS.Add(PPS);

            this.chartPPSinh.DataSource = lstPPS;

            ObjectChartReport CLM = new ObjectChartReport { Name = "Đạt", Values = this.dataRessult.MauDat ?? 0 };
            lstCLM.Add(CLM);
            CLM = new ObjectChartReport { Name = "Không Dat", Values = this.dataRessult.MauKoDat ?? 0 };
            lstCLM.Add(CLM);
            this.chartCLMau.DataSource = lstCLM;


        }

        private void urcReportTTPhieu_DonVi_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }
    }
}
