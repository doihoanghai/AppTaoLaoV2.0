namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMGoiDichVuChiTiet
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
            this.gridControl_GoiDichVuChung = new DevExpress.XtraGrid.GridControl();
            this.gridView_GoiDichVuChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_th_Stt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_IDGoiDichVuChung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_TenGoiDichVuChung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLuuSTT = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemCheckEdit_Check = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView_DichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_th_IDDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_Check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_TenDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_DichVu = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_GoiDichVuChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_GoiDichVuChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_Check)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_GoiDichVuChung
            // 
            this.gridControl_GoiDichVuChung.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl_GoiDichVuChung.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_GoiDichVuChung.Location = new System.Drawing.Point(0, 0);
            this.gridControl_GoiDichVuChung.MainView = this.gridView_GoiDichVuChung;
            this.gridControl_GoiDichVuChung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_GoiDichVuChung.Name = "gridControl_GoiDichVuChung";
            this.gridControl_GoiDichVuChung.Size = new System.Drawing.Size(339, 557);
            this.gridControl_GoiDichVuChung.TabIndex = 0;
            this.gridControl_GoiDichVuChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_GoiDichVuChung});
            // 
            // gridView_GoiDichVuChung
            // 
            this.gridView_GoiDichVuChung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_th_Stt,
            this.col_th_IDGoiDichVuChung,
            this.col_th_TenGoiDichVuChung});
            this.gridView_GoiDichVuChung.GridControl = this.gridControl_GoiDichVuChung;
            this.gridView_GoiDichVuChung.Name = "gridView_GoiDichVuChung";
            this.gridView_GoiDichVuChung.OptionsView.ShowGroupPanel = false;
            this.gridView_GoiDichVuChung.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_GoiDichVuChung_RowCellClick);
            // 
            // col_th_Stt
            // 
            this.col_th_Stt.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_Stt.AppearanceHeader.Options.UseFont = true;
            this.col_th_Stt.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_Stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Stt.Caption = "STT";
            this.col_th_Stt.FieldName = "Stt";
            this.col_th_Stt.Name = "col_th_Stt";
            this.col_th_Stt.Visible = true;
            this.col_th_Stt.VisibleIndex = 2;
            // 
            // col_th_IDGoiDichVuChung
            // 
            this.col_th_IDGoiDichVuChung.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_IDGoiDichVuChung.AppearanceHeader.Options.UseFont = true;
            this.col_th_IDGoiDichVuChung.Caption = "Mã gói";
            this.col_th_IDGoiDichVuChung.FieldName = "IDGoiDichVuChung";
            this.col_th_IDGoiDichVuChung.Name = "col_th_IDGoiDichVuChung";
            this.col_th_IDGoiDichVuChung.OptionsColumn.AllowEdit = false;
            this.col_th_IDGoiDichVuChung.OptionsColumn.AllowFocus = false;
            this.col_th_IDGoiDichVuChung.OptionsColumn.ReadOnly = true;
            this.col_th_IDGoiDichVuChung.Visible = true;
            this.col_th_IDGoiDichVuChung.VisibleIndex = 0;
            this.col_th_IDGoiDichVuChung.Width = 112;
            // 
            // col_th_TenGoiDichVuChung
            // 
            this.col_th_TenGoiDichVuChung.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_TenGoiDichVuChung.AppearanceHeader.Options.UseFont = true;
            this.col_th_TenGoiDichVuChung.Caption = "Tên gói";
            this.col_th_TenGoiDichVuChung.FieldName = "TenGoiDichVuChung";
            this.col_th_TenGoiDichVuChung.Name = "col_th_TenGoiDichVuChung";
            this.col_th_TenGoiDichVuChung.OptionsColumn.AllowEdit = false;
            this.col_th_TenGoiDichVuChung.OptionsColumn.AllowFocus = false;
            this.col_th_TenGoiDichVuChung.OptionsColumn.ReadOnly = true;
            this.col_th_TenGoiDichVuChung.Visible = true;
            this.col_th_TenGoiDichVuChung.VisibleIndex = 1;
            this.col_th_TenGoiDichVuChung.Width = 212;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnLuuSTT);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(339, 519);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(743, 38);
            this.panelControl1.TabIndex = 2;
            // 
            // btnLuuSTT
            // 
            this.btnLuuSTT.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnLuuSTT.Location = new System.Drawing.Point(86, 8);
            this.btnLuuSTT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuuSTT.Name = "btnLuuSTT";
            this.btnLuuSTT.Size = new System.Drawing.Size(64, 24);
            this.btnLuuSTT.TabIndex = 1;
            this.btnLuuSTT.Text = "Lưu";
            this.btnLuuSTT.Click += new System.EventHandler(this.btnLuuSTT_Click);
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSave.Location = new System.Drawing.Point(16, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // repositoryItemCheckEdit_Check
            // 
            this.repositoryItemCheckEdit_Check.AutoHeight = false;
            this.repositoryItemCheckEdit_Check.Name = "repositoryItemCheckEdit_Check";
            // 
            // gridView_DichVu
            // 
            this.gridView_DichVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_th_IDDichVu,
            this.col_th_Check,
            this.col_th_TenDichVu});
            this.gridView_DichVu.GridControl = this.gridControl_DichVu;
            this.gridView_DichVu.Name = "gridView_DichVu";
            this.gridView_DichVu.OptionsView.ShowGroupPanel = false;
            // 
            // col_th_IDDichVu
            // 
            this.col_th_IDDichVu.Caption = "IDDichVu";
            this.col_th_IDDichVu.FieldName = "IDDichVu";
            this.col_th_IDDichVu.Name = "col_th_IDDichVu";
            // 
            // col_th_Check
            // 
            this.col_th_Check.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_Check.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Check.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_Check.AppearanceHeader.Options.UseFont = true;
            this.col_th_Check.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_Check.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Check.Caption = "Chọn";
            this.col_th_Check.FieldName = "Check";
            this.col_th_Check.Name = "col_th_Check";
            this.col_th_Check.Visible = true;
            this.col_th_Check.VisibleIndex = 0;
            this.col_th_Check.Width = 85;
            // 
            // col_th_TenDichVu
            // 
            this.col_th_TenDichVu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_TenDichVu.AppearanceHeader.Options.UseFont = true;
            this.col_th_TenDichVu.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_TenDichVu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_TenDichVu.Caption = "Tên dịch vụ";
            this.col_th_TenDichVu.FieldName = "TenDichVu";
            this.col_th_TenDichVu.Name = "col_th_TenDichVu";
            this.col_th_TenDichVu.OptionsColumn.AllowEdit = false;
            this.col_th_TenDichVu.OptionsColumn.AllowFocus = false;
            this.col_th_TenDichVu.OptionsColumn.ReadOnly = true;
            this.col_th_TenDichVu.Visible = true;
            this.col_th_TenDichVu.VisibleIndex = 1;
            this.col_th_TenDichVu.Width = 716;
            // 
            // gridControl_DichVu
            // 
            this.gridControl_DichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DichVu.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_DichVu.Location = new System.Drawing.Point(339, 0);
            this.gridControl_DichVu.MainView = this.gridView_DichVu;
            this.gridControl_DichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_DichVu.Name = "gridControl_DichVu";
            this.gridControl_DichVu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit_Check});
            this.gridControl_DichVu.Size = new System.Drawing.Size(743, 557);
            this.gridControl_DichVu.TabIndex = 1;
            this.gridControl_DichVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DichVu});
            // 
            // FrmDMGoiDichVuChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 557);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl_DichVu);
            this.Controls.Add(this.gridControl_GoiDichVuChung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDMGoiDichVuChiTiet";
            this.Text = "FrmDMGoiDichVuChiTiet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDMGoiDichVuChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_GoiDichVuChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_GoiDichVuChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_Check)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_GoiDichVuChung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_GoiDichVuChung;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_IDGoiDichVuChung;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_TenGoiDichVuChung;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_Check;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DichVu;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_IDDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Check;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_TenDichVu;
        private DevExpress.XtraGrid.GridControl gridControl_DichVu;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Stt;
        private DevExpress.XtraEditors.SimpleButton btnLuuSTT;
    }
}