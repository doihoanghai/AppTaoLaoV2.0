namespace BioNetSangLocSoSinh.DiaglogFrm
{
    partial class FrmDiaglogCapMaXNTuDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiaglogCapMaXNTuDong));
            this.GCCapMa = new DevExpress.XtraGrid.GridControl();
            this.GVCapMa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupDonVi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.GCCapMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCapMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GCCapMa
            // 
            this.GCCapMa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCCapMa.Location = new System.Drawing.Point(2, 23);
            this.GCCapMa.MainView = this.GVCapMa;
            this.GCCapMa.Name = "GCCapMa";
            this.GCCapMa.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookupDonVi});
            this.GCCapMa.Size = new System.Drawing.Size(697, 209);
            this.GCCapMa.TabIndex = 0;
            this.GCCapMa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVCapMa});
            // 
            // GVCapMa
            // 
            this.GVCapMa.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GVCapMa.Appearance.HeaderPanel.Options.UseFont = true;
            this.GVCapMa.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.GVCapMa.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GVCapMa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaDonVi,
            this.col_SoLuong,
            this.col_MaBatDau,
            this.col_MaKetThuc});
            this.GVCapMa.GridControl = this.GCCapMa;
            this.GVCapMa.Name = "GVCapMa";
            this.GVCapMa.OptionsView.ShowGroupPanel = false;
            this.GVCapMa.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.GVCapMa_RowStyle);
            this.GVCapMa.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GVCapMa_CellValueChanged);
            // 
            // col_MaDonVi
            // 
            this.col_MaDonVi.Caption = "Đơn vị";
            this.col_MaDonVi.ColumnEdit = this.lookupDonVi;
            this.col_MaDonVi.FieldName = "maDonVi";
            this.col_MaDonVi.Name = "col_MaDonVi";
            this.col_MaDonVi.Visible = true;
            this.col_MaDonVi.VisibleIndex = 0;
            this.col_MaDonVi.Width = 337;
            // 
            // lookupDonVi
            // 
            this.lookupDonVi.AutoHeight = false;
            this.lookupDonVi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupDonVi.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaDVCS", 30, "Mã đơn vị"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDVCS", 70, "Tên đơn vị")});
            this.lookupDonVi.DisplayMember = "TenDVCS";
            this.lookupDonVi.Name = "lookupDonVi";
            this.lookupDonVi.NullText = "Đơn vị";
            this.lookupDonVi.ValueMember = "MaDVCS";
            // 
            // col_SoLuong
            // 
            this.col_SoLuong.Caption = "Số lượng";
            this.col_SoLuong.FieldName = "soLuong";
            this.col_SoLuong.Name = "col_SoLuong";
            this.col_SoLuong.OptionsColumn.AllowEdit = false;
            this.col_SoLuong.Visible = true;
            this.col_SoLuong.VisibleIndex = 1;
            this.col_SoLuong.Width = 70;
            // 
            // col_MaBatDau
            // 
            this.col_MaBatDau.Caption = "Mã bắt đầu";
            this.col_MaBatDau.FieldName = "soBatDau";
            this.col_MaBatDau.Name = "col_MaBatDau";
            this.col_MaBatDau.Visible = true;
            this.col_MaBatDau.VisibleIndex = 2;
            this.col_MaBatDau.Width = 123;
            // 
            // col_MaKetThuc
            // 
            this.col_MaKetThuc.Caption = "Mã kết thúc";
            this.col_MaKetThuc.FieldName = "soKetThuc";
            this.col_MaKetThuc.Name = "col_MaKetThuc";
            this.col_MaKetThuc.OptionsColumn.AllowEdit = false;
            this.col_MaKetThuc.OptionsColumn.ReadOnly = true;
            this.col_MaKetThuc.Visible = true;
            this.col_MaKetThuc.VisibleIndex = 3;
            this.col_MaKetThuc.Width = 166;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.btnLuu);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 232);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(697, 25);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(537, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Bỏ qua";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(619, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.GCCapMa);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(701, 259);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Danh sách cấp mã theo đơn vị";
            // 
            // FrmDiaglogCapMaXNTuDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 259);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDiaglogCapMaXNTuDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDiaglogCapMaXNTuDong";
            this.Load += new System.EventHandler(this.FrmDiaglogCapMaXNTuDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GCCapMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCapMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GCCapMa;
        private DevExpress.XtraGrid.Views.Grid.GridView GVCapMa;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaDonVi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaKetThuc;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}