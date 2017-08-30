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

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class urcReportTrungTam_SoBo : DevExpress.XtraEditors.XtraUserControl
    {
        public urcReportTrungTam_SoBo()
        {
            InitializeComponent();
        }
        BioNetModel.rptBaoCaoTongHop dataResult = new BioNetModel.rptBaoCaoTongHop();
        
        private void LoadDuLieuBaoCao()
        {
            this.dataResult = new BioNetModel.rptBaoCaoTongHop();
            this.dataResult = BioNetBLL.BioNet_Bus.GetBaoCaoTongHopTrungTam(dllNgay.tungay.Value, dllNgay.denngay.Value);
            List<ObjectChartReport> lstGioiTinh = new List<ObjectChartReport>();
            List<ObjectChartReport> lstGoiBenh = new List<ObjectChartReport>();
            List<ObjectChartReport> lstPPS = new List<ObjectChartReport>();
           
            if (this.dataResult!=null)
            {

                this.txtTongPhieu.Text = this.dataResult.SoLuongMau.ToString();
                this.txtThuLai.Text = this.dataResult.goiBenh.slThuLai.ToString();
                this.txtThuMoi.Text = (this.dataResult.SoLuongMau - this.dataResult.goiBenh.slThuLai).ToString();
                ObjectChartReport doituong = new ObjectChartReport { Name = "Nam", Values = this.dataResult.gioiTinh.GTNam };
                lstGioiTinh.Add(doituong);
                doituong = new ObjectChartReport { Name = "Nữ", Values = this.dataResult.gioiTinh.GTNu };
                lstGioiTinh.Add(doituong);
                doituong = new ObjectChartReport { Name = "N/a", Values = this.dataResult.gioiTinh.GTNa };
                lstGioiTinh.Add(doituong);
                this.ChartGioiTinh.DataSource = lstGioiTinh;



                ObjectChartReport goiXN = new ObjectChartReport { Name = "2Bệnh", Values = this.dataResult.goiBenh.sl2Benh };
                lstGoiBenh.Add(goiXN);
                goiXN = new ObjectChartReport { Name = "3Bệnh", Values = this.dataResult.goiBenh.sl3Benh };
                lstGoiBenh.Add(goiXN);
                goiXN = new ObjectChartReport { Name = "5Bệnh", Values = this.dataResult.goiBenh.sl5Benh };
                lstGoiBenh.Add(goiXN);
                goiXN = new ObjectChartReport { Name = "Thu lại", Values = this.dataResult.goiBenh.slThuLai };
                lstGoiBenh.Add(goiXN);
                this.ChartGoiXN.DataSource = lstGoiBenh;

                ObjectChartReport PPS = new ObjectChartReport { Name = "Sinh thường", Values = this.dataResult.phuongPhapSinh.SinhThuong };
                lstPPS.Add(PPS);
                PPS = new ObjectChartReport { Name = "Sinh mổ", Values = this.dataResult.phuongPhapSinh.SinhMo };
                lstPPS.Add(PPS);
                PPS = new ObjectChartReport { Name = "N/a", Values = this.dataResult.phuongPhapSinh.SinhNa };
                lstPPS.Add(PPS);
                
                this.ChartPPSinh.DataSource = lstPPS;
                this.ChartKQ.Series.Clear();
               
                Series NguyCoCao = new Series("Nguy cơ cao", ViewType.SideBySideStackedBar);
                Series NguyCoThap = new Series("Nguy cơ thấp", ViewType.SideBySideStackedBar);
                Series TongSl = new Series("Số lượng", ViewType.Area);
                //NguyCoCao.View.Color = Color.Crimson;
                //NguyCoThap.View.Color = Color.DeepSkyBlue;
                NguyCoThap.Label.TextPattern = "{V:#,#} ({V:0.00%})";
                NguyCoCao.Label.TextPattern = "{V:#,#} ({V:0.00%})";
                this.ChartKQ.Series.Clear();
                // Add points to them
             //   TongSl.Points.Add(new SeriesPoint("G6PD", this.dataResult.g6PD.G6PDTong));
             //   TongSl.Points.Add(new SeriesPoint("CH", this.dataResult.cH.CHTong));
             //   TongSl.Points.Add(new SeriesPoint("CAH", this.dataResult.cAH.CAHTong));
             //   TongSl.Points.Add(new SeriesPoint("PKU", this.dataResult.pKU.PKUTong));
             //   TongSl.Points.Add(new SeriesPoint("GAL", this.dataResult.gAL.GALTong));

                NguyCoCao.Points.Add(new SeriesPoint("G6PD", this.dataResult.g6PD.G6PDNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("CH", this.dataResult.cH.CHNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("CAH", this.dataResult.cAH.CAHNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("PKU", this.dataResult.pKU.PKUNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("GAL", this.dataResult.gAL.GALNguyCo));

                NguyCoThap.Points.Add(new SeriesPoint("G6PD", this.dataResult.g6PD.G6PDBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("CH", this.dataResult.cH.CHBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("CAH", this.dataResult.cAH.CAHBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("PKU", this.dataResult.pKU.PKUBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("GAL", this.dataResult.gAL.GALBinhThuong));
                Series NguyCoCao_Test = new Series("Nguy cơ cao", ViewType.Line);
                Series NguyCoThap_Test = new Series("Nguy cơ thấp", ViewType.SideBySideStackedBar);
                //NguyCoCao.View.Color = Color.Crimson;
                //NguyCoThap.View.Color = Color.DeepSkyBlue;
                NguyCoThap.Label.TextPattern = "{VP:#,#} mẫu";//"{V:#,#} ({V:0.00%})";
                NguyCoCao.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                NguyCoThap.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                NguyCoCao.Label.TextPattern = "{VP:#,#} mẫu";//"{V:#,#} ({V:0.00%})";
               // TongSl.Label.TextPattern = "{VP:#,#}";
                this.ChartKQ.Series.Clear();
                // Add points to them

                this.ChartKQ.Series.Add(NguyCoThap);
                this.ChartKQ.Series.Add(NguyCoCao);
             //   this.ChartKQ.Series.Add(TongSl);
                //this.chartKQ2.Series.Add(NguyCoThap);
                //this.chartKQ2.Series.Add(NguyCoCao);
                // Add all series to the chart.
                //ChartKQ.Series.AddRange
                //    (new Series[] { NguyCoThap, NguyCoCao });
            }
        }
        private void urcReportTrungTam_SoBo_Load(object sender, EventArgs e)
        {
            this.LoadDuLieuBaoCao();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            Reports.rptBaocaoTrungTamSoBo datarp = new Reports.rptBaocaoTrungTamSoBo();
            List<BioNetModel.rptBaoCaoTongHop> lstResult = new List<BioNetModel.rptBaoCaoTongHop>();
            lstResult.Add(dataResult);
            datarp.DataSource = lstResult;
            Reports.frmReportEditGeneral rept = new Reports.frmReportEditGeneral(datarp, "BaoCaoTrungTamSoBo");
            rept.ShowDialog();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
         this.LoadDuLieuBaoCao();
        }
    }
}
