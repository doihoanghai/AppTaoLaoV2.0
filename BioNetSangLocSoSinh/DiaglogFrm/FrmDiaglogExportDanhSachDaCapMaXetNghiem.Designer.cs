namespace BioNetSangLocSoSinh.DiaglogFrm
{
    partial class FrmDiaglogExportDanhSachDaCapMaXetNghiem
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiaglogExportDanhSachDaCapMaXetNghiem));
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpDonViCoSo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDenNgay_ChuaKQ = new DevExpress.XtraEditors.DateEdit();
            this.txtTuNgay_ChuaKQ = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.col_MaDv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenDv = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpDonViCoSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay_ChuaKQ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay_ChuaKQ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay_ChuaKQ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay_ChuaKQ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefesh
            // 
            this.btnRefesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefesh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRefesh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefesh.Image")));
            this.btnRefesh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefesh.Location = new System.Drawing.Point(448, 53);
            this.btnRefesh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(58, 53);
            this.btnRefesh.TabIndex = 15;
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(16, 85);
            this.labelControl19.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(34, 17);
            this.labelControl19.TabIndex = 5;
            this.labelControl19.Text = "Đến :";
            // 
            // searchLookUpDonViCoSo
            // 
            this.searchLookUpDonViCoSo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLookUpDonViCoSo.Location = new System.Drawing.Point(51, 29);
            this.searchLookUpDonViCoSo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchLookUpDonViCoSo.Name = "searchLookUpDonViCoSo";
            this.searchLookUpDonViCoSo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpDonViCoSo.Properties.DisplayMember = "TenDVCS";
            this.searchLookUpDonViCoSo.Properties.NullText = "Chọn đơn vị cơ sở cần nhận mẫu ...";
            this.searchLookUpDonViCoSo.Properties.ValueMember = "MaDVCS";
            this.searchLookUpDonViCoSo.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpDonViCoSo.Size = new System.Drawing.Size(455, 22);
            this.searchLookUpDonViCoSo.TabIndex = 0;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaDv,
            this.col_TenDv});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtDenNgay_ChuaKQ
            // 
            this.txtDenNgay_ChuaKQ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenNgay_ChuaKQ.EditValue = null;
            this.txtDenNgay_ChuaKQ.Location = new System.Drawing.Point(51, 83);
            this.txtDenNgay_ChuaKQ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDenNgay_ChuaKQ.Name = "txtDenNgay_ChuaKQ";
            this.txtDenNgay_ChuaKQ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay_ChuaKQ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay_ChuaKQ.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay_ChuaKQ.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay_ChuaKQ.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtDenNgay_ChuaKQ.Properties.NullDate = new System.DateTime(2016, 12, 15, 16, 49, 27, 0);
            this.txtDenNgay_ChuaKQ.Properties.NullDateCalendarValue = new System.DateTime(2016, 12, 15, 16, 49, 40, 0);
            this.txtDenNgay_ChuaKQ.Size = new System.Drawing.Size(391, 22);
            this.txtDenNgay_ChuaKQ.TabIndex = 6;
            // 
            // txtTuNgay_ChuaKQ
            // 
            this.txtTuNgay_ChuaKQ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTuNgay_ChuaKQ.EditValue = null;
            this.txtTuNgay_ChuaKQ.Location = new System.Drawing.Point(51, 56);
            this.txtTuNgay_ChuaKQ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTuNgay_ChuaKQ.Name = "txtTuNgay_ChuaKQ";
            this.txtTuNgay_ChuaKQ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay_ChuaKQ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay_ChuaKQ.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay_ChuaKQ.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay_ChuaKQ.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtTuNgay_ChuaKQ.Properties.NullDate = new System.DateTime(2016, 12, 15, 16, 49, 53, 0);
            this.txtTuNgay_ChuaKQ.Properties.NullDateCalendarValue = new System.DateTime(2016, 12, 15, 16, 50, 0, 0);
            this.txtTuNgay_ChuaKQ.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.txtTuNgay_ChuaKQ.Size = new System.Drawing.Size(391, 22);
            this.txtTuNgay_ChuaKQ.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 33);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 17);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Đơn vị :";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(25, 59);
            this.labelControl18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(26, 17);
            this.labelControl18.TabIndex = 4;
            this.labelControl18.Text = "Từ :";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.btnRefesh);
            this.groupControl1.Controls.Add(this.searchLookUpDonViCoSo);
            this.groupControl1.Controls.Add(this.labelControl19);
            this.groupControl1.Controls.Add(this.labelControl18);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtDenNgay_ChuaKQ);
            this.groupControl1.Controls.Add(this.txtTuNgay_ChuaKQ);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(511, 117);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Chọn đơn vị cần xuất mã xét nghiệm";
            // 
            // col_MaDv
            // 
            this.col_MaDv.Caption = "Mã đơn vị";
            this.col_MaDv.FieldName = "MaDVCS";
            this.col_MaDv.Name = "col_MaDv";
            this.col_MaDv.Visible = true;
            this.col_MaDv.VisibleIndex = 0;
            // 
            // col_TenDv
            // 
            this.col_TenDv.Caption = "Tên Đơn vị";
            this.col_TenDv.FieldName = "TenDVCS";
            this.col_TenDv.Name = "col_TenDv";
            this.col_TenDv.Visible = true;
            this.col_TenDv.VisibleIndex = 1;
            // 
            // FrmDiaglogExportDanhSachDaCapMaXetNghiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 117);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDiaglogExportDanhSachDaCapMaXetNghiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpDonViCoSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay_ChuaKQ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay_ChuaKQ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay_ChuaKQ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay_ChuaKQ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpDonViCoSo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaDv;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenDv;
        private DevExpress.XtraEditors.DateEdit txtDenNgay_ChuaKQ;
        private DevExpress.XtraEditors.DateEdit txtTuNgay_ChuaKQ;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}