namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMDonViCoSo
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
            this.gridControl_DonViCoSo = new DevExpress.XtraGrid.GridControl();
            this.gridView_DonViCoSo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_th_RowIDDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_MaDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_TenDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_DiaChiDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_SDTCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_Logo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit_logo = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.col_th_HeaderReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit_header = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.col_th_Stt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_MaChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_ChiCuc = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_th_isLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_isLocked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_KieuTraKetQua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_KieuTraKetQua = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemComboBoxKieuTraKetQua = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.fileLogo = new System.Windows.Forms.OpenFileDialog();
            this.fileHeader = new System.Windows.Forms.OpenFileDialog();
            this.col_BacSiDaiDien = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DonViCoSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DonViCoSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_ChiCuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_KieuTraKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxKieuTraKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_DonViCoSo
            // 
            this.gridControl_DonViCoSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DonViCoSo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_DonViCoSo.Location = new System.Drawing.Point(0, 0);
            this.gridControl_DonViCoSo.MainView = this.gridView_DonViCoSo;
            this.gridControl_DonViCoSo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_DonViCoSo.Name = "gridControl_DonViCoSo";
            this.gridControl_DonViCoSo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit_isLocked,
            this.repositoryItemLookUpEdit_ChiCuc,
            this.repositoryItemPictureEdit_logo,
            this.repositoryItemPictureEdit_header,
            this.repositoryItemComboBoxKieuTraKetQua,
            this.repositoryItemLookUpEdit_KieuTraKetQua});
            this.gridControl_DonViCoSo.Size = new System.Drawing.Size(1181, 518);
            this.gridControl_DonViCoSo.TabIndex = 0;
            this.gridControl_DonViCoSo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DonViCoSo});
            this.gridControl_DonViCoSo.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_DonViCoSo_ProcessGridKey);
            // 
            // gridView_DonViCoSo
            // 
            this.gridView_DonViCoSo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_th_RowIDDVCS,
            this.col_th_MaDVCS,
            this.col_th_TenDVCS,
            this.col_th_DiaChiDVCS,
            this.col_th_SDTCS,
            this.col_th_Logo,
            this.col_th_HeaderReport,
            this.col_th_Stt,
            this.col_th_MaChiCuc,
            this.col_th_isLocked,
            this.col_KieuTraKetQua,
            this.col_BacSiDaiDien});
            this.gridView_DonViCoSo.GridControl = this.gridControl_DonViCoSo;
            this.gridView_DonViCoSo.Name = "gridView_DonViCoSo";
            this.gridView_DonViCoSo.NewItemRowText = "Thêm danh mục đơn vị cơ sở";
            this.gridView_DonViCoSo.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_DonViCoSo.OptionsView.ShowGroupPanel = false;
            this.gridView_DonViCoSo.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_DonViCoSo_RowCellClick);
            this.gridView_DonViCoSo.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_DonViCoSo_ValidateRow);
            // 
            // col_th_RowIDDVCS
            // 
            this.col_th_RowIDDVCS.Caption = "RowIDDVCS";
            this.col_th_RowIDDVCS.FieldName = "RowIDDVCS";
            this.col_th_RowIDDVCS.Name = "col_th_RowIDDVCS";
            // 
            // col_th_MaDVCS
            // 
            this.col_th_MaDVCS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_MaDVCS.AppearanceHeader.Options.UseFont = true;
            this.col_th_MaDVCS.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_MaDVCS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_MaDVCS.Caption = "Mã đơn vị";
            this.col_th_MaDVCS.FieldName = "MaDVCS";
            this.col_th_MaDVCS.Name = "col_th_MaDVCS";
            this.col_th_MaDVCS.OptionsColumn.AllowEdit = false;
            this.col_th_MaDVCS.OptionsColumn.AllowFocus = false;
            this.col_th_MaDVCS.OptionsColumn.ReadOnly = true;
            this.col_th_MaDVCS.Visible = true;
            this.col_th_MaDVCS.VisibleIndex = 0;
            this.col_th_MaDVCS.Width = 73;
            // 
            // col_th_TenDVCS
            // 
            this.col_th_TenDVCS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_TenDVCS.AppearanceHeader.Options.UseFont = true;
            this.col_th_TenDVCS.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_TenDVCS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_TenDVCS.Caption = "Tên đơn vị";
            this.col_th_TenDVCS.FieldName = "TenDVCS";
            this.col_th_TenDVCS.Name = "col_th_TenDVCS";
            this.col_th_TenDVCS.Visible = true;
            this.col_th_TenDVCS.VisibleIndex = 1;
            this.col_th_TenDVCS.Width = 134;
            // 
            // col_th_DiaChiDVCS
            // 
            this.col_th_DiaChiDVCS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_DiaChiDVCS.AppearanceHeader.Options.UseFont = true;
            this.col_th_DiaChiDVCS.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_DiaChiDVCS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_DiaChiDVCS.Caption = "Địa chỉ";
            this.col_th_DiaChiDVCS.FieldName = "DiaChiDVCS";
            this.col_th_DiaChiDVCS.Name = "col_th_DiaChiDVCS";
            this.col_th_DiaChiDVCS.Visible = true;
            this.col_th_DiaChiDVCS.VisibleIndex = 2;
            this.col_th_DiaChiDVCS.Width = 193;
            // 
            // col_th_SDTCS
            // 
            this.col_th_SDTCS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_SDTCS.AppearanceHeader.Options.UseFont = true;
            this.col_th_SDTCS.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_SDTCS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_SDTCS.Caption = "Số ĐT";
            this.col_th_SDTCS.FieldName = "SDTCS";
            this.col_th_SDTCS.Name = "col_th_SDTCS";
            this.col_th_SDTCS.Visible = true;
            this.col_th_SDTCS.VisibleIndex = 3;
            this.col_th_SDTCS.Width = 90;
            // 
            // col_th_Logo
            // 
            this.col_th_Logo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_Logo.AppearanceHeader.Options.UseFont = true;
            this.col_th_Logo.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_Logo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Logo.Caption = "Logo";
            this.col_th_Logo.ColumnEdit = this.repositoryItemPictureEdit_logo;
            this.col_th_Logo.FieldName = "Logo";
            this.col_th_Logo.Name = "col_th_Logo";
            this.col_th_Logo.Visible = true;
            this.col_th_Logo.VisibleIndex = 4;
            this.col_th_Logo.Width = 80;
            // 
            // repositoryItemPictureEdit_logo
            // 
            this.repositoryItemPictureEdit_logo.Name = "repositoryItemPictureEdit_logo";
            this.repositoryItemPictureEdit_logo.NullText = " ";
            this.repositoryItemPictureEdit_logo.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPictureEdit_logo.Click += new System.EventHandler(this.repositoryItemPictureEdit_logo_Click);
            // 
            // col_th_HeaderReport
            // 
            this.col_th_HeaderReport.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_HeaderReport.AppearanceHeader.Options.UseFont = true;
            this.col_th_HeaderReport.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_HeaderReport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_HeaderReport.Caption = "Hình tiêu đề";
            this.col_th_HeaderReport.ColumnEdit = this.repositoryItemPictureEdit_header;
            this.col_th_HeaderReport.FieldName = "HeaderReport";
            this.col_th_HeaderReport.Name = "col_th_HeaderReport";
            this.col_th_HeaderReport.Visible = true;
            this.col_th_HeaderReport.VisibleIndex = 5;
            this.col_th_HeaderReport.Width = 97;
            // 
            // repositoryItemPictureEdit_header
            // 
            this.repositoryItemPictureEdit_header.Name = "repositoryItemPictureEdit_header";
            this.repositoryItemPictureEdit_header.NullText = " ";
            this.repositoryItemPictureEdit_header.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPictureEdit_header.Click += new System.EventHandler(this.repositoryItemPictureEdit_header_Click);
            // 
            // col_th_Stt
            // 
            this.col_th_Stt.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_Stt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Stt.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_Stt.AppearanceHeader.Options.UseFont = true;
            this.col_th_Stt.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_Stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Stt.Caption = "STT";
            this.col_th_Stt.FieldName = "Stt";
            this.col_th_Stt.Name = "col_th_Stt";
            this.col_th_Stt.Visible = true;
            this.col_th_Stt.VisibleIndex = 10;
            this.col_th_Stt.Width = 73;
            // 
            // col_th_MaChiCuc
            // 
            this.col_th_MaChiCuc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_MaChiCuc.AppearanceHeader.Options.UseFont = true;
            this.col_th_MaChiCuc.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_MaChiCuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_MaChiCuc.Caption = "Chi cục";
            this.col_th_MaChiCuc.ColumnEdit = this.repositoryItemLookUpEdit_ChiCuc;
            this.col_th_MaChiCuc.FieldName = "MaChiCuc";
            this.col_th_MaChiCuc.Name = "col_th_MaChiCuc";
            this.col_th_MaChiCuc.Visible = true;
            this.col_th_MaChiCuc.VisibleIndex = 6;
            this.col_th_MaChiCuc.Width = 126;
            // 
            // repositoryItemLookUpEdit_ChiCuc
            // 
            this.repositoryItemLookUpEdit_ChiCuc.AutoHeight = false;
            this.repositoryItemLookUpEdit_ChiCuc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_ChiCuc.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaChiCuc", "Mã chi cục"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChiCuc", "Tên chi cục")});
            this.repositoryItemLookUpEdit_ChiCuc.Name = "repositoryItemLookUpEdit_ChiCuc";
            this.repositoryItemLookUpEdit_ChiCuc.NullText = "";
            // 
            // col_th_isLocked
            // 
            this.col_th_isLocked.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_isLocked.AppearanceHeader.Options.UseFont = true;
            this.col_th_isLocked.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_isLocked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_isLocked.Caption = "Khóa";
            this.col_th_isLocked.ColumnEdit = this.repositoryItemCheckEdit_isLocked;
            this.col_th_isLocked.FieldName = "isLocked";
            this.col_th_isLocked.Name = "col_th_isLocked";
            this.col_th_isLocked.Visible = true;
            this.col_th_isLocked.VisibleIndex = 9;
            this.col_th_isLocked.Width = 68;
            // 
            // repositoryItemCheckEdit_isLocked
            // 
            this.repositoryItemCheckEdit_isLocked.AutoHeight = false;
            this.repositoryItemCheckEdit_isLocked.Name = "repositoryItemCheckEdit_isLocked";
            // 
            // col_KieuTraKetQua
            // 
            this.col_KieuTraKetQua.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_KieuTraKetQua.AppearanceHeader.Options.UseFont = true;
            this.col_KieuTraKetQua.Caption = "Kiểu trả kết quả";
            this.col_KieuTraKetQua.ColumnEdit = this.repositoryItemLookUpEdit_KieuTraKetQua;
            this.col_KieuTraKetQua.FieldName = "KieuTraKetQua";
            this.col_KieuTraKetQua.Name = "col_KieuTraKetQua";
            this.col_KieuTraKetQua.Visible = true;
            this.col_KieuTraKetQua.VisibleIndex = 7;
            this.col_KieuTraKetQua.Width = 105;
            // 
            // repositoryItemLookUpEdit_KieuTraKetQua
            // 
            this.repositoryItemLookUpEdit_KieuTraKetQua.AutoHeight = false;
            this.repositoryItemLookUpEdit_KieuTraKetQua.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_KieuTraKetQua.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")});
            this.repositoryItemLookUpEdit_KieuTraKetQua.Name = "repositoryItemLookUpEdit_KieuTraKetQua";
            this.repositoryItemLookUpEdit_KieuTraKetQua.NullText = "";
            this.repositoryItemLookUpEdit_KieuTraKetQua.ShowFooter = false;
            this.repositoryItemLookUpEdit_KieuTraKetQua.ShowHeader = false;
            // 
            // repositoryItemComboBoxKieuTraKetQua
            // 
            this.repositoryItemComboBoxKieuTraKetQua.AutoHeight = false;
            this.repositoryItemComboBoxKieuTraKetQua.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxKieuTraKetQua.Items.AddRange(new object[] {
            "Theo đơn vị",
            "Theo trung tâm"});
            this.repositoryItemComboBoxKieuTraKetQua.Name = "repositoryItemComboBoxKieuTraKetQua";
            // 
            // fileLogo
            // 
            this.fileLogo.FileName = "fileLogo";
            this.fileLogo.FileOk += new System.ComponentModel.CancelEventHandler(this.fileLogo_FileOk);
            // 
            // fileHeader
            // 
            this.fileHeader.FileName = "fileHeader";
            this.fileHeader.FileOk += new System.ComponentModel.CancelEventHandler(this.fileHeader_FileOk);
            // 
            // col_BacSiDaiDien
            // 
            this.col_BacSiDaiDien.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_BacSiDaiDien.AppearanceHeader.Options.UseFont = true;
            this.col_BacSiDaiDien.Caption = "Người đại diện";
            this.col_BacSiDaiDien.FieldName = "TenBacSiDaiDien";
            this.col_BacSiDaiDien.Name = "col_BacSiDaiDien";
            this.col_BacSiDaiDien.Visible = true;
            this.col_BacSiDaiDien.VisibleIndex = 8;
            this.col_BacSiDaiDien.Width = 124;
            // 
            // FrmDMDonViCoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 518);
            this.Controls.Add(this.gridControl_DonViCoSo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDMDonViCoSo";
            this.Text = "FrmDMDonViCoSo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDMDonViCoSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DonViCoSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DonViCoSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_ChiCuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_KieuTraKetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxKieuTraKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_DonViCoSo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DonViCoSo;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_RowIDDVCS;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_MaDVCS;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_TenDVCS;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_DiaChiDVCS;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_SDTCS;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Logo;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_HeaderReport;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Stt;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_MaChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_isLocked;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_isLocked;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_ChiCuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit_logo;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit_header;
        private System.Windows.Forms.OpenFileDialog fileLogo;
        private System.Windows.Forms.OpenFileDialog fileHeader;
        private DevExpress.XtraGrid.Columns.GridColumn col_KieuTraKetQua;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxKieuTraKetQua;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_KieuTraKetQua;
        private DevExpress.XtraGrid.Columns.GridColumn col_BacSiDaiDien;
    }
}