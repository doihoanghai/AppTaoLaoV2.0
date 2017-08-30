namespace BioNetSangLocSoSinh
{
    partial class FrmDiaglogSuaPhieuDaTiepNhan
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
            DevExpress.XtraPrinting.BarCode.CodabarGenerator codabarGenerator1 = new DevExpress.XtraPrinting.BarCode.CodabarGenerator();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiaglogSuaPhieuDaTiepNhan));
            this.searchLookUpDonViCoSo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.barCodePhieu = new DevExpress.XtraEditors.BarCodeControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.col_MaDv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenDv = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpDonViCoSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchLookUpDonViCoSo
            // 
            this.searchLookUpDonViCoSo.Location = new System.Drawing.Point(99, 124);
            this.searchLookUpDonViCoSo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchLookUpDonViCoSo.Name = "searchLookUpDonViCoSo";
            this.searchLookUpDonViCoSo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpDonViCoSo.Properties.DisplayMember = "TenDVCS";
            this.searchLookUpDonViCoSo.Properties.NullText = "Chọn đơn vị cơ sở cần nhận mẫu ...";
            this.searchLookUpDonViCoSo.Properties.ValueMember = "MaDVCS";
            this.searchLookUpDonViCoSo.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpDonViCoSo.Size = new System.Drawing.Size(341, 22);
            this.searchLookUpDonViCoSo.TabIndex = 2;
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
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(9, 128);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Đơn vị cơ sở :";
            // 
            // barCodePhieu
            // 
            this.barCodePhieu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.barCodePhieu.Font = new System.Drawing.Font("Tahoma", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barCodePhieu.HorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barCodePhieu.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.barCodePhieu.Location = new System.Drawing.Point(11, 29);
            this.barCodePhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barCodePhieu.Name = "barCodePhieu";
            this.barCodePhieu.Padding = new System.Windows.Forms.Padding(12, 2, 12, 0);
            this.barCodePhieu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.barCodePhieu.Size = new System.Drawing.Size(429, 91);
            codabarGenerator1.WideNarrowRatio = 2F;
            this.barCodePhieu.Symbology = codabarGenerator1;
            this.barCodePhieu.TabIndex = 10;
            this.barCodePhieu.VerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.barCodePhieu.VerticalTextAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.Indigo;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(309, 167);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 28);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Appearance.ForeColor = System.Drawing.Color.Indigo;
            this.btnThoat.Appearance.Options.UseForeColor = true;
            this.btnThoat.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnThoat.Image = global::BioNetSangLocSoSinh.Properties.Resources.exit;
            this.btnThoat.Location = new System.Drawing.Point(387, 167);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(71, 28);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.searchLookUpDonViCoSo);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnThoat);
            this.groupControl1.Controls.Add(this.barCodePhieu);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(463, 201);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Sửa đơn vị của phiếu";
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
            // FrmDiaglogSuaPhieuDaTiepNhan
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 201);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDiaglogSuaPhieuDaTiepNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmDiaglogSuaPhieuDaTiepNhan";
            this.Load += new System.EventHandler(this.FrmDiaglogSuaPhieuDaTiepNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpDonViCoSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpDonViCoSo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaDv;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenDv;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.BarCodeControl barCodePhieu;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}