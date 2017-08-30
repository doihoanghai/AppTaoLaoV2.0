using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using DevExpress.XtraCharts;
using BioNetModel;

namespace BioNetSangLocSoSinh.Reports
{
    public partial class rptBaocaoDonviSoBo : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBaocaoDonviSoBo()
        {
            InitializeComponent();
            this.lst = this.DataSource as List<BioNetModel.rptBaoCaoTongHop>;
        }
        private List<BioNetModel.rptBaoCaoTongHop> lst = new List<BioNetModel.rptBaoCaoTongHop>();
       

        private void rptBaocaoTrungTamSoBo_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.lst = this.DataSource as List<BioNetModel.rptBaoCaoTongHop>;
            this.lst = this.DataSource as List<BioNetModel.rptBaoCaoTongHop>;
            if (this.lst.Count > 0)
            {
                List<ObjectChartReport> lstGioiTinh = new List<ObjectChartReport>();
                BioNetModel.rptBaoCaoTongHop data = this.lst[0];
                ObjectChartReport doituong = new ObjectChartReport { Name = "Nam", Values = this.lst[0].gioiTinh.GTNam };
                lstGioiTinh.Add(doituong);
                doituong = new ObjectChartReport { Name = "Nữ", Values = this.lst[0].gioiTinh.GTNu };
                lstGioiTinh.Add(doituong);
                doituong = new ObjectChartReport { Name = "N/a", Values = this.lst[0].gioiTinh.GTNa };
                lstGioiTinh.Add(doituong);
                this.ChartGioiTinh.DataSource = lstGioiTinh;
                Series seriesGioiTinh = new Series("Chart Gioi Tinh", ViewType.Pie);
                seriesGioiTinh.ArgumentDataMember = "Name";
                //series1.LegendText = "Name";
                seriesGioiTinh.ValueDataMembers.AddRange(new string[] { "Values" });
                ChartGioiTinh.Series.Add(seriesGioiTinh);
                seriesGioiTinh.Label.TextPattern = "{A}: {VP:p0}";

                List<ObjectChartReport> lstGoiBenh = new List<ObjectChartReport>();
                ObjectChartReport goiXN = new ObjectChartReport { Name = "2Bệnh", Values = this.lst[0].goiBenh.sl2Benh };
                lstGoiBenh.Add(goiXN);
                goiXN = new ObjectChartReport { Name = "3Bệnh", Values = this.lst[0].goiBenh.sl3Benh };
                lstGoiBenh.Add(goiXN);
                goiXN = new ObjectChartReport { Name = "5Bệnh", Values = this.lst[0].goiBenh.sl5Benh };
                lstGoiBenh.Add(goiXN);
                this.ChartGoiXN.DataSource = lstGoiBenh;
                Series seriesGoiXN = new Series("Chart Gói Xét Nghiệm", ViewType.Doughnut);
                seriesGoiXN.ArgumentDataMember = "Name";
                //series1.LegendText = "Name";
                seriesGoiXN.ValueDataMembers.AddRange(new string[] { "Values" });
                ChartGoiXN.Series.Add(seriesGoiXN);
                seriesGoiXN.Label.TextPattern = "{A}: {VP:p0}";

                List<ObjectChartReport> lstPPS = new List<ObjectChartReport>();
                ObjectChartReport PPS = new ObjectChartReport { Name = "Sinh thường", Values = this.lst[0].phuongPhapSinh.SinhThuong };
                lstPPS.Add(PPS);
                PPS = new ObjectChartReport { Name = "Sinh mổ", Values = this.lst[0].phuongPhapSinh.SinhMo };
                lstPPS.Add(PPS);
                PPS = new ObjectChartReport { Name = "N/a", Values = this.lst[0].phuongPhapSinh.SinhNa };
                lstPPS.Add(PPS);
                this.ChartPPSinh.DataSource = lstPPS;
                Series seriesPPS = new Series("Chart Phương pháp sinh", ViewType.Doughnut);
                seriesPPS.ArgumentDataMember = "Name";
                //series1.LegendText = "Name";
                seriesPPS.ValueDataMembers.AddRange(new string[] { "Values" });
                ChartPPSinh.Series.Add(seriesPPS);
                seriesPPS.Label.TextPattern = "{A}: {VP:p0}";

                Series NguyCoCao = new Series("Nguy cơ cao", ViewType.SideBySideFullStackedBar );
                Series NguyCoThap = new Series("Nguy cơ thấp", ViewType.SideBySideFullStackedBar);
                //NguyCoCao.View.Color = Color.RosyBrown;
                //NguyCoThap.View.Color = Color.CadetBlue;
                NguyCoThap.Label.TextPattern = "{ VP: p0}";
                NguyCoCao.Label.TextPattern = "{ VP: p0}";
                this.ChartKQ.Series.Clear(); 
                // Add points to them
                NguyCoCao.Points.Add(new SeriesPoint("G6PD", this.lst[0].g6PD.G6PDNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("CH", this.lst[0].cH.CHNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("CAH", this.lst[0].cAH.CAHNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("PKU", this.lst[0].pKU.PKUNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("GAL", this.lst[0].gAL.GALNguyCo));

                NguyCoThap.Points.Add(new SeriesPoint("G6PD", this.lst[0].g6PD.G6PDBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("CH", this.lst[0].cH.CHBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("CAH", this.lst[0].cAH.CAHBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("PKU", this.lst[0].pKU.PKUBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("GAL", this.lst[0].gAL.GALBinhThuong));


                // Add all series to the chart.
                ChartKQ.Series.AddRange
                    (new Series[] { NguyCoCao, NguyCoThap });

            }
        }

      
    }
}
