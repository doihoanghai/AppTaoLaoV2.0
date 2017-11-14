namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMGoiDichVuDonVi
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
            this.gridControl_GoiDVDonvi = new DevExpress.XtraGrid.GridControl();
            this.gridView_GoiDVDonvi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_th_IDGoiDichVuChung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_TenGoiDichVuTrungTam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_IDMaDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_MaDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_DonViCoSo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_th_ChietKhau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_DonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_RowIDGoiDichVuTrungTam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_GoiDVChung = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_GoiDVDonvi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_GoiDVDonvi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DonViCoSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_GoiDVChung)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_GoiDVDonvi
            // 
            this.gridControl_GoiDVDonvi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_GoiDVDonvi.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_GoiDVDonvi.Location = new System.Drawing.Point(0, 0);
            this.gridControl_GoiDVDonvi.MainView = this.gridView_GoiDVDonvi;
            this.gridControl_GoiDVDonvi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_GoiDVDonvi.Name = "gridControl_GoiDVDonvi";
            this.gridControl_GoiDVDonvi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_GoiDVChung,
            this.repositoryItemLookUpEdit_DonViCoSo});
            this.gridControl_GoiDVDonvi.Size = new System.Drawing.Size(906, 526);
            this.gridControl_GoiDVDonvi.TabIndex = 0;
            this.gridControl_GoiDVDonvi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_GoiDVDonvi});
            // 
            // gridView_GoiDVDonvi
            // 
            this.gridView_GoiDVDonvi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_th_IDGoiDichVuChung,
            this.col_th_TenGoiDichVuTrungTam,
            this.col_th_IDMaDVCS,
            this.col_th_MaDVCS,
            this.col_th_ChietKhau,
            this.col_th_DonGia,
            this.col_th_RowIDGoiDichVuTrungTam});
            this.gridView_GoiDVDonvi.GridControl = this.gridControl_GoiDVDonvi;
            this.gridView_GoiDVDonvi.Name = "gridView_GoiDVDonvi";
            this.gridView_GoiDVDonvi.NewItemRowText = "Thêm danh mục gói dịch vụ cho đơn vị cơ sở";
            this.gridView_GoiDVDonvi.OptionsView.ShowGroupPanel = false;
            this.gridView_GoiDVDonvi.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_GoiDVDonvi_ValidateRow);
            // 
            // col_th_IDGoiDichVuChung
            // 
            this.col_th_IDGoiDichVuChung.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.col_th_IDGoiDichVuChung.AppearanceCell.Options.UseFont = true;
            this.col_th_IDGoiDichVuChung.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.col_th_IDGoiDichVuChung.AppearanceHeader.Options.UseFont = true;
            this.col_th_IDGoiDichVuChung.Caption = "ID Gói Dịch Vụ Chung";
            this.col_th_IDGoiDichVuChung.FieldName = "IDGoiDichVuChung";
            this.col_th_IDGoiDichVuChung.Name = "col_th_IDGoiDichVuChung";
            this.col_th_IDGoiDichVuChung.OptionsColumn.ReadOnly = true;
            this.col_th_IDGoiDichVuChung.Visible = true;
            this.col_th_IDGoiDichVuChung.VisibleIndex = 0;
            this.col_th_IDGoiDichVuChung.Width = 122;
            // 
            // col_th_TenGoiDichVuTrungTam
            // 
            this.col_th_TenGoiDichVuTrungTam.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_TenGoiDichVuTrungTam.AppearanceHeader.Options.UseFont = true;
            this.col_th_TenGoiDichVuTrungTam.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_TenGoiDichVuTrungTam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_TenGoiDichVuTrungTam.Caption = "Tên gói";
            this.col_th_TenGoiDichVuTrungTam.FieldName = "TenGoiDichVuChung";
            this.col_th_TenGoiDichVuTrungTam.Name = "col_th_TenGoiDichVuTrungTam";
            this.col_th_TenGoiDichVuTrungTam.OptionsColumn.ReadOnly = true;
            this.col_th_TenGoiDichVuTrungTam.Visible = true;
            this.col_th_TenGoiDichVuTrungTam.VisibleIndex = 1;
            this.col_th_TenGoiDichVuTrungTam.Width = 145;
            // 
            // col_th_IDMaDVCS
            // 
            this.col_th_IDMaDVCS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_th_IDMaDVCS.AppearanceHeader.Options.UseFont = true;
            this.col_th_IDMaDVCS.Caption = "Mã Đơn Vị Cơ Sở";
            this.col_th_IDMaDVCS.FieldName = "MaDVCS";
            this.col_th_IDMaDVCS.Name = "col_th_IDMaDVCS";
            this.col_th_IDMaDVCS.OptionsColumn.ReadOnly = true;
            this.col_th_IDMaDVCS.Visible = true;
            this.col_th_IDMaDVCS.VisibleIndex = 2;
            this.col_th_IDMaDVCS.Width = 101;
            // 
            // col_th_MaDVCS
            // 
            this.col_th_MaDVCS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_MaDVCS.AppearanceHeader.Options.UseFont = true;
            this.col_th_MaDVCS.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_MaDVCS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_MaDVCS.Caption = "Tên đơn vị CS";
            this.col_th_MaDVCS.ColumnEdit = this.repositoryItemLookUpEdit_DonViCoSo;
            this.col_th_MaDVCS.FieldName = "MaDVCS";
            this.col_th_MaDVCS.Name = "col_th_MaDVCS";
            this.col_th_MaDVCS.OptionsColumn.ReadOnly = true;
            this.col_th_MaDVCS.Visible = true;
            this.col_th_MaDVCS.VisibleIndex = 3;
            this.col_th_MaDVCS.Width = 168;
            // 
            // repositoryItemLookUpEdit_DonViCoSo
            // 
            this.repositoryItemLookUpEdit_DonViCoSo.AutoHeight = false;
            this.repositoryItemLookUpEdit_DonViCoSo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_DonViCoSo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaDVCS", "MaDVCS", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDVCS", "TenDVCS")});
            this.repositoryItemLookUpEdit_DonViCoSo.Name = "repositoryItemLookUpEdit_DonViCoSo";
            this.repositoryItemLookUpEdit_DonViCoSo.NullText = "";
            this.repositoryItemLookUpEdit_DonViCoSo.ShowFooter = false;
            this.repositoryItemLookUpEdit_DonViCoSo.ShowHeader = false;
            // 
            // col_th_ChietKhau
            // 
            this.col_th_ChietKhau.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_ChietKhau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_th_ChietKhau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_ChietKhau.AppearanceHeader.Options.UseFont = true;
            this.col_th_ChietKhau.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_ChietKhau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_ChietKhau.Caption = "Chiết khấu";
            this.col_th_ChietKhau.DisplayFormat.FormatString = "{0:#,#}";
            this.col_th_ChietKhau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_th_ChietKhau.FieldName = "ChietKhau";
            this.col_th_ChietKhau.Name = "col_th_ChietKhau";
            this.col_th_ChietKhau.Visible = true;
            this.col_th_ChietKhau.VisibleIndex = 4;
            this.col_th_ChietKhau.Width = 188;
            // 
            // col_th_DonGia
            // 
            this.col_th_DonGia.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_DonGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_th_DonGia.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_DonGia.AppearanceHeader.Options.UseFont = true;
            this.col_th_DonGia.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_DonGia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_DonGia.Caption = "Đơn giá";
            this.col_th_DonGia.DisplayFormat.FormatString = "{0:#,#}";
            this.col_th_DonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_th_DonGia.FieldName = "DonGia";
            this.col_th_DonGia.Name = "col_th_DonGia";
            this.col_th_DonGia.Visible = true;
            this.col_th_DonGia.VisibleIndex = 5;
            this.col_th_DonGia.Width = 164;
            // 
            // col_th_RowIDGoiDichVuTrungTam
            // 
            this.col_th_RowIDGoiDichVuTrungTam.Caption = "RowIDGoiDichVuTrungTam";
            this.col_th_RowIDGoiDichVuTrungTam.FieldName = "RowIDGoiDichVuTrungTam";
            this.col_th_RowIDGoiDichVuTrungTam.Name = "col_th_RowIDGoiDichVuTrungTam";
            // 
            // repositoryItemLookUpEdit_GoiDVChung
            // 
            this.repositoryItemLookUpEdit_GoiDVChung.AutoHeight = false;
            this.repositoryItemLookUpEdit_GoiDVChung.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_GoiDVChung.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IDGoiDichVuChung", "IDGoiDichVuChung", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenGoiDichVuChung", "TenGoiDichVuChung")});
            this.repositoryItemLookUpEdit_GoiDVChung.Name = "repositoryItemLookUpEdit_GoiDVChung";
            this.repositoryItemLookUpEdit_GoiDVChung.NullText = "";
            this.repositoryItemLookUpEdit_GoiDVChung.ShowFooter = false;
            this.repositoryItemLookUpEdit_GoiDVChung.ShowHeader = false;
            // 
            // FrmDMGoiDichVuDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 526);
            this.Controls.Add(this.gridControl_GoiDVDonvi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDMGoiDichVuDonVi";
            this.Text = "PSDMGoiDichVuDonVi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDMGoiDichVuDonVi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_GoiDVDonvi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_GoiDVDonvi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DonViCoSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_GoiDVChung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_GoiDVDonvi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_GoiDVDonvi;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_TenGoiDichVuTrungTam;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_MaDVCS;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_ChietKhau;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_DonGia;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_GoiDVChung;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_DonViCoSo;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_RowIDGoiDichVuTrungTam;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_IDGoiDichVuChung;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_IDMaDVCS;
    }
}