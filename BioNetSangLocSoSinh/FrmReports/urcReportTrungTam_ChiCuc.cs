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
using System.IO;

namespace BioNetSangLocSoSinh.FrmReports
{
    public partial class urcReportTrungTam_ChiCuc : DevExpress.XtraEditors.XtraUserControl
    {
        public urcReportTrungTam_ChiCuc()
        {
            InitializeComponent();
        }

        BioNetModel.rptChiTietTrungTam dataResultFull = new rptChiTietTrungTam();
        BioNetModel.rptChiTietTrungTam dataResult = new rptChiTietTrungTam();
        private void LoadDuLieuBaoCao()
        {

            this.dataResultFull = BioNet_Bus.GetBaoCaoTrungTamTongHopChiTietTheoChiCuc(this.dllNgay.tungay.Value.Date, this.dllNgay.denngay.Value.Date);
            List<ObjectChartReport> lstGioiTinh = new List<ObjectChartReport>();
            List<ObjectChartReport> lstGoiBenh = new List<ObjectChartReport>();
            List<ObjectChartReport> lstPPS = new List<ObjectChartReport>();
            this.ChartSoLuongMau_Multi.Series.Clear();
            //this.ChartGioiTinh.Series.Clear();
            //this.ChartGoiXN.Series.Clear();
            this.ChartKQ.Series.Clear();
            //this.ChartPPSinh.Series.Clear();
            this.chartSlBenh_Multi.Series.Clear();
            this.ChartSoLuongMau_Multi.Series.Clear();
            this.Chart_GioiTinh_Multi.Series.Clear();
            this.Chart_KQ_Multi.Series.Clear();
            this.dataResult = this.dataResultFull;
            if (this.txtChiCuc.EditValue != null && !this.txtChiCuc.EditValue.ToString().Equals("all"))
            {
                this.PanelSingle.Visible = true;
                this.PanelSingle.Dock = DockStyle.Fill;
                this.PanelMulti.Visible = false;

                this.dataResult.ChiTietCacChiCuc = this.dataResultFull.ChiTietCacChiCuc.Where(p => p.MaChiCuc == this.txtChiCuc.EditValue.ToString()).ToList();
                if(this.dataResult.ChiTietCacChiCuc.Count<1)
                {
                    XtraMessageBox.Show("");
                }
                this.txtTongPhieu.Text = this.dataResult.ChiTietCacChiCuc[0].SoLuongMau.ToString();
                this.txtThuLai.Text = this.dataResult.ChiTietCacChiCuc[0].slMauThuLai.ToString();
                this.txtThuMoi.Text = (this.dataResult.ChiTietCacChiCuc[0].SoLuongMau - this.dataResult.ChiTietCacChiCuc[0].slMauThuLai).ToString();
                ObjectChartReport doituong = new ObjectChartReport { Name = "Nam", Values = this.dataResult.ChiTietCacChiCuc[0].GTNam };
                lstGioiTinh.Add(doituong);
                doituong = new ObjectChartReport { Name = "Nữ", Values = this.dataResult.ChiTietCacChiCuc[0].GTNu };
                lstGioiTinh.Add(doituong);
                doituong = new ObjectChartReport { Name = "N/a", Values = this.dataResult.ChiTietCacChiCuc[0].GTNa };
                lstGioiTinh.Add(doituong);
                this.ChartGioiTinh.DataSource = lstGioiTinh;



                ObjectChartReport goiXN = new ObjectChartReport { Name = "2Bệnh", Values = this.dataResult.ChiTietCacChiCuc[0].sl2Benh };
                lstGoiBenh.Add(goiXN);
                goiXN = new ObjectChartReport { Name = "3Bệnh", Values = this.dataResult.ChiTietCacChiCuc[0].sl3Benh };
                lstGoiBenh.Add(goiXN);
                goiXN = new ObjectChartReport { Name = "5Bệnh", Values = this.dataResult.ChiTietCacChiCuc[0].sl5Benh };
                lstGoiBenh.Add(goiXN);
                goiXN = new ObjectChartReport { Name = "Thu lại", Values = this.dataResult.ChiTietCacChiCuc[0].slMauThuLai };
                lstGoiBenh.Add(goiXN);
                this.ChartGoiXN.DataSource = lstGoiBenh;

                ObjectChartReport PPS = new ObjectChartReport { Name = "Sinh thường", Values = this.dataResult.ChiTietCacChiCuc[0].SinhThuong };
                lstPPS.Add(PPS);
                PPS = new ObjectChartReport { Name = "Sinh mổ", Values = this.dataResult.ChiTietCacChiCuc[0].SinhMo };
                lstPPS.Add(PPS);
                PPS = new ObjectChartReport { Name = "N/a", Values = this.dataResult.ChiTietCacChiCuc[0].SinhNa };
                lstPPS.Add(PPS);

                this.ChartPPSinh.DataSource = lstPPS;
                // this.charTest.Series.Clear();


                Series NguyCoCao = new Series("Nguy cơ cao", ViewType.SideBySideStackedBar);
                Series NguyCoThap = new Series("Nguy cơ thấp", ViewType.SideBySideStackedBar);
                NguyCoCao.Label.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
                NguyCoCao.Label.TextPattern = "{V:#,#} ({V:0.00%})";
                NguyCoCao.Points.Add(new SeriesPoint("G6PD", this.dataResult.ChiTietCacChiCuc[0].G6PDNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("CH", this.dataResult.ChiTietCacChiCuc[0].CHNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("CAH", this.dataResult.ChiTietCacChiCuc[0].CAHNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("PKU", this.dataResult.ChiTietCacChiCuc[0].PKUNguyCo));
                NguyCoCao.Points.Add(new SeriesPoint("GAL", this.dataResult.ChiTietCacChiCuc[0].GALNguyCo));

                NguyCoThap.Points.Add(new SeriesPoint("G6PD", this.dataResult.ChiTietCacChiCuc[0].G6PDBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("CH", this.dataResult.ChiTietCacChiCuc[0].CHBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("CAH", this.dataResult.ChiTietCacChiCuc[0].CAHBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("PKU", this.dataResult.ChiTietCacChiCuc[0].PKUBinhThuong));
                NguyCoThap.Points.Add(new SeriesPoint("GAL", this.dataResult.ChiTietCacChiCuc[0].GALBinhThuong));

                NguyCoThap.Label.TextPattern = "{V:#,#} mẫu";
                NguyCoCao.Label.TextPattern = "{V:#,#} mẫu";
                NguyCoCao.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                NguyCoThap.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                NguyCoCao.ShowInLegend = true;

                this.ChartKQ.Series.Add(NguyCoThap);
                this.ChartKQ.Series.Add(NguyCoCao);
                
            }
            else
            {


                if (this.dataResult != null)
                {
                    if (dataResult.ChiTietCacChiCuc != null & dataResult.ChiTietCacChiCuc.Count > 0)
                    {
                        this.PanelMulti.Dock = DockStyle.Fill;
                        this.PanelMulti.Visible = true;
                        this.PanelSingle.Visible = false;
                        Series SlMau = new Series("Số lượng mẫu", ViewType.FullStackedBar);
                        Series SlMauThuLai = new Series("Số lượng mẫu thu lại", ViewType.FullStackedBar);
                        Series Sl2Benh = new Series("2 bệnh", ViewType.Bar);
                        Series Sl3Benh = new Series("3 bệnh", ViewType.Bar);
                        Series Sl5Benh = new Series("5 bệnh", ViewType.Bar);
                        Series SlBenhThuMauLai = new Series("Thu mẫu lại", ViewType.Bar);
                        Series SlGioiTinNam = new Series("Nam", ViewType.SideBySideStackedBar);
                        Series SlGioiTinNu = new Series("Nữ", ViewType.SideBySideStackedBar);
                        Series SlGioiTinhNon = new Series("Giới tính N/a", ViewType.SideBySideStackedBar);
                        Series G6PD = new Series("G6PD", ViewType.SideBySideStackedBar);
                        Series G6PD_NguyCo = new Series("G6PD nguy cơ", ViewType.SideBySideStackedBar);
                        Series CH = new Series("CH", ViewType.SideBySideStackedBar);
                        Series CH_NguyCo = new Series("CH nguy cơ", ViewType.SideBySideStackedBar);
                        Series CAH = new Series("CAH", ViewType.SideBySideStackedBar);
                        Series CAH_NguyCo = new Series("CAH nguy cơ", ViewType.SideBySideStackedBar);
                        Series GAL = new Series("GAL", ViewType.SideBySideStackedBar);
                        Series GAL_NguyCo = new Series("GAL nguy cơ", ViewType.SideBySideStackedBar);
                        Series PKU = new Series("PKU", ViewType.SideBySideStackedBar);
                        Series PKU_NguyCo = new Series("PKU nguy cơ", ViewType.SideBySideStackedBar);
                        Sl2Benh.Label.TextPattern = "{V:#,#} mẫu";
                        Sl2Benh.Label.TextOrientation = TextOrientation.BottomToTop;
                        Sl2Benh.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        Sl3Benh.Label.TextPattern = "{V:#,#} mẫu";
                        Sl3Benh.Label.TextOrientation = TextOrientation.BottomToTop;
                        Sl3Benh.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        Sl5Benh.Label.TextPattern = "{V:#,#} mẫu";
                        Sl5Benh.Label.TextOrientation = TextOrientation.BottomToTop;
                        Sl5Benh.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        SlBenhThuMauLai.Label.TextPattern = "{V:#,#} mẫu";
                        SlBenhThuMauLai.Label.TextOrientation = TextOrientation.BottomToTop;
                        SlBenhThuMauLai.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        SlGioiTinhNon.Label.TextPattern = "{V:#,#} mẫu";
                        SlGioiTinhNon.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        SlGioiTinNam.Label.TextPattern = "{V:#,#} mẫu";
                        SlGioiTinNam.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        SlGioiTinNu.Label.TextPattern = "{V:#,#} mẫu";
                        SlGioiTinNu.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        SlMau.Label.TextPattern = "{V:#,#}:({VP:0.00%})";
                        SlMau.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        SlMauThuLai.Label.TextPattern = "{V:#,#}:({VP:0.00%})";
                        SlMauThuLai.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        CH.Label.TextPattern = "{V:#,#}";
                        CH.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        CH_NguyCo.Label.TextPattern = "{V:#,#}";
                        CH_NguyCo.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        CAH.Label.TextPattern = "{V:#,#}";
                        CAH.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        CAH_NguyCo.Label.TextPattern = "{V:#,#} ";
                        CAH_NguyCo.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        G6PD.Label.TextPattern = "{V:#,#}";
                        G6PD.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        G6PD_NguyCo.Label.TextPattern = "{V:#,#}";
                        G6PD_NguyCo.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        GAL.Label.TextPattern = "{V:#,#}";
                        GAL.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        GAL_NguyCo.Label.TextPattern = "{V:#,#}";
                        GAL_NguyCo.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PKU.Label.TextPattern = "{V:#,#} ";
                        PKU.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PKU_NguyCo.Label.TextPattern = "{V:#,#} ";
                        PKU_NguyCo.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;



                        foreach (var chicuc in dataResult.ChiTietCacChiCuc)
                        {
                            SlMau.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.SoLuongMau));
                            SlMauThuLai.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.slMauThuLai));
                            Sl2Benh.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.sl2Benh));
                            Sl3Benh.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.sl3Benh));
                            Sl5Benh.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.sl5Benh));
                            SlBenhThuMauLai.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.slMauThuLai));
                            SlGioiTinhNon.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.GTNa));
                            SlGioiTinNam.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.GTNam));
                            SlGioiTinNu.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.GTNu));
                            G6PD.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.G6PDBinhThuong));
                            G6PD_NguyCo.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.G6PDNguyCo));
                            CH.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.CHBinhThuong));
                            CH_NguyCo.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.CHNguyCo));
                            CAH.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.CAHBinhThuong));
                            CAH_NguyCo.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.CAHNguyCo));
                            GAL.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.GAL));
                            GAL_NguyCo.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.GALNguyCo));
                            PKU.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.PKUBinhThuong));
                            PKU_NguyCo.Points.Add(new SeriesPoint(chicuc.TenChiCuc, chicuc.PKUNguyCo));

                        }
                         ((SideBySideStackedBarSeriesView)G6PD.View).StackedGroup = 0;
                        ((SideBySideStackedBarSeriesView)G6PD_NguyCo.View).StackedGroup = 0;
                        ((SideBySideStackedBarSeriesView)CH.View).StackedGroup = 1;
                        ((SideBySideStackedBarSeriesView)CH_NguyCo.View).StackedGroup = 1;
                        ((SideBySideStackedBarSeriesView)CAH.View).StackedGroup = 2;
                        ((SideBySideStackedBarSeriesView)CAH_NguyCo.View).StackedGroup = 2;
                        ((SideBySideStackedBarSeriesView)GAL.View).StackedGroup = 3;
                        ((SideBySideStackedBarSeriesView)GAL_NguyCo.View).StackedGroup = 3;
                        ((SideBySideStackedBarSeriesView)PKU.View).StackedGroup = 4;
                        ((SideBySideStackedBarSeriesView)PKU_NguyCo.View).StackedGroup = 4;
                        this.ChartSoLuongMau_Multi.Series.Add(SlMau);
                        this.ChartSoLuongMau_Multi.Series.Add(SlMauThuLai);
                        this.chartSlBenh_Multi.Series.Add(Sl2Benh);
                        this.chartSlBenh_Multi.Series.Add(Sl3Benh);
                        this.chartSlBenh_Multi.Series.Add(Sl5Benh);
                        this.chartSlBenh_Multi.Series.Add(SlBenhThuMauLai);
                        this.Chart_GioiTinh_Multi.Series.Add(SlGioiTinNam);
                        this.Chart_GioiTinh_Multi.Series.Add(SlGioiTinNu);
                        this.Chart_GioiTinh_Multi.Series.Add(SlGioiTinhNon);
                        this.Chart_KQ_Multi.Series.AddRange(new Series[] { G6PD, G6PD_NguyCo, CH, CH_NguyCo, CAH, CAH_NguyCo, GAL, GAL_NguyCo, PKU, PKU_NguyCo });
                         this.Chart_KQ_Multi.AppearanceNameSerializable = "In A Fog";
                        //this.Chart_KQ_Multi.PaletteBaseColorNumber = 5;
                        //this.Chart_KQ_Multi.PaletteName = "InAFog";
                        //  this.chartSlBenh_Multi.Dock = DockStyle.Top;
                        //  this.ChartSoLuongMau_Multi.Dock = DockStyle.Top;
                        //  this.Chart_GioiTinh_Multi.Dock = DockStyle.Top;
                        //foreach(var chicuc in dataResult.ChiTietCacChiCuc)
                        //{
                        //    Series chicucSeries = new Series(chicuc.TenChiCuc, ViewType.Bar);
                        //    chicucSeries.Label.TextPattern = "{V:#,#} ({V:0.00%})";
                        //    chicucSeries.Points.Add(new SeriesPoint("Số lượng mẫu "+chicuc.TenChiCuc, chicuc.SoLuongMau));
                        //    chicucSeries.Points.Add(new SeriesPoint("Số lượng mẫu thu lại" + chicuc.TenChiCuc, chicuc.slMauThuLai));
                        //    this.ChartSoLuongMau_Multi.Series.Add(chicucSeries);

                        //}
                    }
                    else
                    {
                        this.PanelSingle.Visible = true;
                        this.PanelSingle.Dock = DockStyle.Fill;
                        this.PanelMulti.Visible = false;


                    }
                }
            }

            }
        private void urcReportTrungTam_SoBo_Load(object sender, EventArgs e)
        {
            this.PanelSingle.Visible = true;
            this.PanelSingle.Dock = DockStyle.Fill;
           this.PanelMulti.Visible = false;
            this.txtChiCuc.Properties.DataSource = BioNet_Bus.GetDieuKienLocBaoCao_ChiCuc();
            this.txtChiCuc.EditValue = "all";
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.LoadDuLieuBaoCao();
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            if (this.txtChiCuc.EditValue != null && !this.txtChiCuc.EditValue.ToString().Equals("all"))
            {
                try
                {
                    Reports.rptBaocaoTrungTamSoBo datarp = new Reports.rptBaocaoTrungTamSoBo();
                    List<BioNetModel.rptBaoCaoTongHop> lstResult = new List<BioNetModel.rptBaoCaoTongHop>();
                    var data = BioNetBLL.BioNet_Bus.GetBaoCaoTongHopChiCuc(dllNgay.tungay.Value, dllNgay.denngay.Value,this.txtChiCuc.EditValue.ToString());
                    //var chicuc = this.dataResult.ChiTietCacChiCuc.FirstOrDefault(p => p.MaChiCuc == this.txtChiCuc.EditValue.ToString());
                    //if (chicuc != null)
                    //{
                    //    rptBaoCaoTongHop tonghop = new rptBaoCaoTongHop();
                    //    PsThongTinTrungTam tt = new PsThongTinTrungTam();
                    //    rptBaoCaoTongHop.G6PD g6pd = new rptBaoCaoTongHop.G6PD();
                    //    rptBaoCaoTongHop.CAH cah = new rptBaoCaoTongHop.CAH();
                    //    rptBaoCaoTongHop.CH ch = new rptBaoCaoTongHop.CH();
                    //    rptBaoCaoTongHop.ChatLuongMau clm = new rptBaoCaoTongHop.ChatLuongMau();
                    //    rptBaoCaoTongHop.ChuongTrinh ct = new rptBaoCaoTongHop.ChuongTrinh();
                    //    rptBaoCaoTongHop.GAL gal = new rptBaoCaoTongHop.GAL();
                    //    rptBaoCaoTongHop.GioiTinh gt = new rptBaoCaoTongHop.GioiTinh();
                    //    rptBaoCaoTongHop.GoiBenh gb = new rptBaoCaoTongHop.GoiBenh();
                    //    rptBaoCaoTongHop.PhuongPhapSinh pps = new rptBaoCaoTongHop.PhuongPhapSinh();
                    //    rptBaoCaoTongHop.PKU pku = new rptBaoCaoTongHop.PKU();
                    //    var tttemp = BioNet_Bus.GetThongTinTrungTam();
                    //    tt.TenTrungTam = chicuc.TenChiCuc;
                    //    tt.MaTrungTam = chicuc.MaChiCuc;
                    //    if (tttemp.Logo.Length > 0)
                    //    {

                    //        try
                    //        {
                    //            byte[] b = tttemp.Logo.ToArray();
                    //            MemoryStream ms = new MemoryStream(b);
                    //            Image img = Image.FromStream(ms);
                    //            tt.Logo = img;
                    //        }
                    //        catch { }
                    //    }


                    // }
                    lstResult.Add(data);
                    datarp.DataSource = lstResult;
                    Reports.frmReportEditGeneral rept = new Reports.frmReportEditGeneral(datarp, "BaoCaoTrungTamSoBo");
                    rept.ShowDialog();


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi lấy dữ liệu in \r\n Lỗi chi tiết : " +ex.ToString(), "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Reports.rptBaoCaoChiTietTrungTam datarp = new Reports.rptBaoCaoChiTietTrungTam();
                List<BioNetModel.rptChiTietTrungTam> lstResult = new List<BioNetModel.rptChiTietTrungTam>();
                lstResult.Add(this.dataResult);
                datarp.DataSource = lstResult;
                Reports.frmReportEditGeneral rept = new Reports.frmReportEditGeneral(datarp, "BaoCaoTrungTamChiTiet");
                rept.ShowDialog();
            }
        }

       
    }
}
