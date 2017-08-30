namespace BioNetSangLocSoSinh.UserControl
{
    partial class UscBaoCaoTrungtam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UscBaoCaoTrungtam));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.txtDenNgay_DsCho = new DevExpress.XtraEditors.DateEdit();
            this.txtTuNgay_DsCho = new DevExpress.XtraEditors.DateEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay_DsCho.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay_DsCho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay_DsCho.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay_DsCho.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(906, 554);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl1);
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(900, 526);
            this.xtraTabPage1.Text = "Báo cáo cơ bản";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 33);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(900, 493);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnRefesh);
            this.panelControl1.Controls.Add(this.txtDenNgay_DsCho);
            this.panelControl1.Controls.Add(this.txtTuNgay_DsCho);
            this.panelControl1.Controls.Add(this.labelControl18);
            this.panelControl1.Controls.Add(this.labelControl19);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(900, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // btnRefesh
            // 
            this.btnRefesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefesh.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnRefesh.Appearance.Options.UseFont = true;
            this.btnRefesh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRefesh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefesh.Image")));
            this.btnRefesh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRefesh.Location = new System.Drawing.Point(807, 3);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(88, 29);
            this.btnRefesh.TabIndex = 13;
            this.btnRefesh.Text = "Lấy số liệu";
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // txtDenNgay_DsCho
            // 
            this.txtDenNgay_DsCho.EditValue = null;
            this.txtDenNgay_DsCho.Location = new System.Drawing.Point(269, 7);
            this.txtDenNgay_DsCho.Name = "txtDenNgay_DsCho";
            this.txtDenNgay_DsCho.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDenNgay_DsCho.Properties.Appearance.Options.UseFont = true;
            this.txtDenNgay_DsCho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay_DsCho.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay_DsCho.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay_DsCho.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay_DsCho.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay_DsCho.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay_DsCho.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtDenNgay_DsCho.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtDenNgay_DsCho.Size = new System.Drawing.Size(120, 20);
            this.txtDenNgay_DsCho.TabIndex = 11;
            // 
            // txtTuNgay_DsCho
            // 
            this.txtTuNgay_DsCho.EditValue = null;
            this.txtTuNgay_DsCho.Location = new System.Drawing.Point(66, 7);
            this.txtTuNgay_DsCho.Name = "txtTuNgay_DsCho";
            this.txtTuNgay_DsCho.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTuNgay_DsCho.Properties.Appearance.Options.UseFont = true;
            this.txtTuNgay_DsCho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay_DsCho.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay_DsCho.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay_DsCho.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay_DsCho.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay_DsCho.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay_DsCho.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtTuNgay_DsCho.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtTuNgay_DsCho.Size = new System.Drawing.Size(131, 20);
            this.txtTuNgay_DsCho.TabIndex = 12;
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl18.Location = new System.Drawing.Point(6, 8);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(54, 14);
            this.labelControl18.TabIndex = 9;
            this.labelControl18.Text = "Từ ngày :";
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl19.Location = new System.Drawing.Point(203, 10);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(60, 14);
            this.labelControl19.TabIndex = 10;
            this.labelControl19.Text = "Đến ngày :";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(900, 526);
            this.xtraTabPage2.Text = "Báo cáo theo đơn vị";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(900, 526);
            this.xtraTabPage3.Text = "Báo cáo thống kê theo điều kiện";
            // 
            // UscBaoCaoTrungtam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "UscBaoCaoTrungtam";
            this.Size = new System.Drawing.Size(906, 554);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay_DsCho.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay_DsCho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay_DsCho.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay_DsCho.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private DevExpress.XtraEditors.DateEdit txtDenNgay_DsCho;
        private DevExpress.XtraEditors.DateEdit txtTuNgay_DsCho;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl19;
    }
}
