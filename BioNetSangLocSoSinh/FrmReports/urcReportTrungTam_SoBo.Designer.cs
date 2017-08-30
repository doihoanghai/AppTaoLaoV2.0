namespace BioNetSangLocSoSinh.FrmReports
{
    partial class urcReportTrungTam_SoBo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.SeriesTitle seriesTitle1 = new DevExpress.XtraCharts.SeriesTitle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urcReportTrungTam_SoBo));
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel2 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.SeriesTitle seriesTitle2 = new DevExpress.XtraCharts.SeriesTitle();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.DoughnutSeriesLabel doughnutSeriesLabel1 = new DevExpress.XtraCharts.DoughnutSeriesLabel();
            DevExpress.XtraCharts.DoughnutSeriesView doughnutSeriesView1 = new DevExpress.XtraCharts.DoughnutSeriesView();
            DevExpress.XtraCharts.SeriesTitle seriesTitle3 = new DevExpress.XtraCharts.SeriesTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.ChartGioiTinh = new DevExpress.XtraCharts.ChartControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtThuLai = new DevExpress.XtraEditors.LabelControl();
            this.txtThuMoi = new DevExpress.XtraEditors.LabelControl();
            this.txtTongPhieu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.dllNgay = new UserControlDate.dllNgay();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.ChartPPSinh = new DevExpress.XtraCharts.ChartControl();
            this.ChartGoiXN = new DevExpress.XtraCharts.ChartControl();
            this.ChartKQ = new DevExpress.XtraCharts.ChartControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGioiTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPPSinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGoiXN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartKQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartGioiTinh
            // 
            this.ChartGioiTinh.Legend.MarkerVisible = false;
            this.ChartGioiTinh.Legend.MaxHorizontalPercentage = 30D;
            this.ChartGioiTinh.Legend.MaxVerticalPercentage = 30D;
            this.ChartGioiTinh.Legend.TextVisible = false;
            this.ChartGioiTinh.Location = new System.Drawing.Point(953, 5);
            this.ChartGioiTinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChartGioiTinh.Name = "ChartGioiTinh";
            series1.ArgumentDataMember = "Name";
            pieSeriesLabel1.TextPattern = "{A}:{V} ({VP:0.00%})";
            series1.Label = pieSeriesLabel1;
            series1.Name = "Giới Tính";
            series1.ValueDataMembersSerializable = "Values";
            pieSeriesView1.HeightToWidthRatio = 0.8D;
            pieSeriesView1.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Clockwise;
            seriesTitle1.Font = new System.Drawing.Font("Tahoma", 18F);
            seriesTitle1.TextColor = System.Drawing.Color.DodgerBlue;
            pieSeriesView1.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle1});
            series1.View = pieSeriesView1;
            this.ChartGioiTinh.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.ChartGioiTinh.Size = new System.Drawing.Size(314, 278);
            this.ChartGioiTinh.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.Controls.Add(this.txtThuLai);
            this.panelControl3.Controls.Add(this.txtThuMoi);
            this.panelControl3.Controls.Add(this.txtTongPhieu);
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Location = new System.Drawing.Point(5, 5);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(315, 278);
            this.panelControl3.TabIndex = 1;
            // 
            // txtThuLai
            // 
            this.txtThuLai.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtThuLai.Appearance.ForeColor = System.Drawing.Color.Green;
            this.txtThuLai.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtThuLai.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.txtThuLai.Location = new System.Drawing.Point(153, 190);
            this.txtThuLai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtThuLai.Name = "txtThuLai";
            this.txtThuLai.Size = new System.Drawing.Size(156, 30);
            this.txtThuLai.TabIndex = 0;
            this.txtThuLai.Text = "10000";
            this.txtThuLai.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtThuMoi
            // 
            this.txtThuMoi.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtThuMoi.Appearance.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.txtThuMoi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtThuMoi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.txtThuMoi.Location = new System.Drawing.Point(7, 190);
            this.txtThuMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtThuMoi.Name = "txtThuMoi";
            this.txtThuMoi.Size = new System.Drawing.Size(149, 30);
            this.txtThuMoi.TabIndex = 0;
            this.txtThuMoi.Text = "10000";
            this.txtThuMoi.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtTongPhieu
            // 
            this.txtTongPhieu.Appearance.Font = new System.Drawing.Font("Tahoma", 30F);
            this.txtTongPhieu.Appearance.ForeColor = System.Drawing.Color.Green;
            this.txtTongPhieu.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTongPhieu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.txtTongPhieu.Location = new System.Drawing.Point(0, 50);
            this.txtTongPhieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongPhieu.Name = "txtTongPhieu";
            this.txtTongPhieu.Size = new System.Drawing.Size(309, 60);
            this.txtTongPhieu.TabIndex = 0;
            this.txtTongPhieu.Text = "10000";
            this.txtTongPhieu.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.Location = new System.Drawing.Point(153, 156);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(156, 27);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Phiếu Thu Lại";
            this.labelControl4.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DarkViolet;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.Location = new System.Drawing.Point(6, 156);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(150, 27);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Phiếu Thu Mới";
            this.labelControl3.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Fuchsia;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(5, 5);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(304, 41);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tổng Số Phiếu";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.butPrint);
            this.panelControl2.Controls.Add(this.butOK);
            this.panelControl2.Controls.Add(this.dllNgay);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1269, 89);
            this.panelControl2.TabIndex = 2;
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(351, 46);
            this.butPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(93, 32);
            this.butPrint.TabIndex = 1055;
            this.butPrint.Text = "In";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(351, 6);
            this.butOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(93, 32);
            this.butOK.TabIndex = 1054;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(0, 0);
            this.dllNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(344, 90);
            this.dllNgay.TabIndex = 1053;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.xtraScrollableControl1.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControl1.Controls.Add(this.ChartPPSinh);
            this.xtraScrollableControl1.Controls.Add(this.panelControl3);
            this.xtraScrollableControl1.Controls.Add(this.ChartGioiTinh);
            this.xtraScrollableControl1.Controls.Add(this.ChartGoiXN);
            this.xtraScrollableControl1.Controls.Add(this.ChartKQ);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 89);
            this.xtraScrollableControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1269, 949);
            this.xtraScrollableControl1.TabIndex = 3;
            // 
            // ChartPPSinh
            // 
            this.ChartPPSinh.IndicatorsPaletteName = "Palette 1";
            this.ChartPPSinh.IndicatorsPaletteRepository.Add("Palette 1", new DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(153)))), ((int)(((byte)(211))))), System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(153)))), ((int)(((byte)(211)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(210)))), ((int)(((byte)(169))))), System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(210)))), ((int)(((byte)(169)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(85)))), ((int)(((byte)(105))))), System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(135))))), System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(135))))))}));
            this.ChartPPSinh.Legend.Direction = DevExpress.XtraCharts.LegendDirection.BottomToTop;
            this.ChartPPSinh.Location = new System.Drawing.Point(327, 5);
            this.ChartPPSinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChartPPSinh.Name = "ChartPPSinh";
            series2.ArgumentDataMember = "Name";
            pieSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            pieSeriesLabel2.TextPattern = "{A}:{V} ({VP:0.00%})";
            series2.Label = pieSeriesLabel2;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Phương pháp sinh";
            series2.ValueDataMembersSerializable = "Values";
            seriesTitle2.Font = new System.Drawing.Font("Tahoma", 18F);
            seriesTitle2.MaxLineCount = 4;
            seriesTitle2.TextColor = System.Drawing.Color.MediumPurple;
            seriesTitle2.Visibility = DevExpress.Utils.DefaultBoolean.True;
            pieSeriesView2.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle2});
            series2.View = pieSeriesView2;
            this.ChartPPSinh.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.ChartPPSinh.Size = new System.Drawing.Size(309, 278);
            this.ChartPPSinh.TabIndex = 2;
            // 
            // ChartGoiXN
            // 
            this.ChartGoiXN.Legend.MarkerVisible = false;
            this.ChartGoiXN.Legend.TextVisible = false;
            this.ChartGoiXN.Location = new System.Drawing.Point(643, 5);
            this.ChartGoiXN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChartGoiXN.Name = "ChartGoiXN";
            series3.ArgumentDataMember = "Name";
            doughnutSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            doughnutSeriesLabel1.ColumnIndent = 10;
            doughnutSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty;
            doughnutSeriesLabel1.LineLength = 5;
            doughnutSeriesLabel1.TextAlignment = System.Drawing.StringAlignment.Near;
            doughnutSeriesLabel1.TextPattern = "{A}: {V} ({VP:0.00%})";
            series3.Label = doughnutSeriesLabel1;
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.Name = "Gói xét nghiệm";
            series3.ValueDataMembersSerializable = "Values";
            doughnutSeriesView1.Rotation = 5;
            seriesTitle3.Font = new System.Drawing.Font("Tahoma", 18F);
            seriesTitle3.Indent = 10;
            seriesTitle3.MaxLineCount = 4;
            seriesTitle3.TextColor = System.Drawing.Color.DodgerBlue;
            seriesTitle3.Visibility = DevExpress.Utils.DefaultBoolean.True;
            doughnutSeriesView1.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle3});
            series3.View = doughnutSeriesView1;
            this.ChartGoiXN.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.ChartGoiXN.Size = new System.Drawing.Size(309, 278);
            this.ChartGoiXN.TabIndex = 2;
            // 
            // ChartKQ
            // 
            xyDiagram1.AxisX.Alignment = DevExpress.XtraCharts.AxisAlignment.Zero;
            xyDiagram1.AxisX.GridLines.MinorVisible = true;
            xyDiagram1.AxisX.Label.TextPattern = "{A}";
            xyDiagram1.AxisX.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisX.Tickmarks.Visible = false;
            xyDiagram1.AxisX.Title.Text = "";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.GridLines.Visible = false;
            xyDiagram1.AxisY.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.ChartKQ.Diagram = xyDiagram1;
            this.ChartKQ.Location = new System.Drawing.Point(7, 290);
            this.ChartKQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChartKQ.Name = "ChartKQ";
            this.ChartKQ.PaletteName = "Chameleon";
            sideBySideBarSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            sideBySideBarSeriesLabel1.Indent = 1;
            sideBySideBarSeriesLabel1.LineLength = 1;
            sideBySideBarSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesLabel1.TextPattern = "{V:#,#} ({V:0.00%})";
            series4.Label = sideBySideBarSeriesLabel1;
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.Name = "Series 1";
            this.ChartKQ.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4};
            this.ChartKQ.Size = new System.Drawing.Size(628, 316);
            this.ChartKQ.TabIndex = 0;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 20);
            // 
            // urcReportTrungTam_SoBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.panelControl2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "urcReportTrungTam_SoBo";
            this.Size = new System.Drawing.Size(1269, 1038);
            this.Load += new System.EventHandler(this.urcReportTrungTam_SoBo_Load);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGioiTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPPSinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGoiXN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartKQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl txtThuLai;
        private DevExpress.XtraEditors.LabelControl txtThuMoi;
        private DevExpress.XtraEditors.LabelControl txtTongPhieu;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraCharts.ChartControl ChartGioiTinh;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraCharts.ChartControl ChartPPSinh;
        private DevExpress.XtraCharts.ChartControl ChartGoiXN;
        private DevExpress.XtraCharts.ChartControl ChartKQ;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
