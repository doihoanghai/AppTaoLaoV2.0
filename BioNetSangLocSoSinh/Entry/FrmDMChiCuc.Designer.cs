namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMChiCuc
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
            this.gridControl_ChiCuc = new DevExpress.XtraGrid.GridControl();
            this.gridView_ChiCuc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_th_MaChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_TenChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_DiaChiChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_SdtChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_Logo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit_logo = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.col_th_HeaderReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit_Header = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.col_th_Stt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_isLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_isLocked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_th_RowIDChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fileLogo = new System.Windows.Forms.OpenFileDialog();
            this.fileHeader = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ChiCuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ChiCuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_Header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_ChiCuc
            // 
            this.gridControl_ChiCuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ChiCuc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_ChiCuc.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ChiCuc.MainView = this.gridView_ChiCuc;
            this.gridControl_ChiCuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_ChiCuc.Name = "gridControl_ChiCuc";
            this.gridControl_ChiCuc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit_isLocked,
            this.repositoryItemPictureEdit_logo,
            this.repositoryItemPictureEdit_Header});
            this.gridControl_ChiCuc.Size = new System.Drawing.Size(1033, 497);
            this.gridControl_ChiCuc.TabIndex = 0;
            this.gridControl_ChiCuc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ChiCuc});
            this.gridControl_ChiCuc.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_ChiCuc_ProcessGridKey);
            // 
            // gridView_ChiCuc
            // 
            this.gridView_ChiCuc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_th_MaChiCuc,
            this.col_th_TenChiCuc,
            this.col_th_DiaChiChiCuc,
            this.col_th_SdtChiCuc,
            this.col_th_Logo,
            this.col_th_HeaderReport,
            this.col_th_Stt,
            this.col_th_isLocked,
            this.col_th_RowIDChiCuc});
            this.gridView_ChiCuc.GridControl = this.gridControl_ChiCuc;
            this.gridView_ChiCuc.Name = "gridView_ChiCuc";
            this.gridView_ChiCuc.NewItemRowText = "Thêm danh mục chi cục";
            this.gridView_ChiCuc.OptionsView.ShowGroupPanel = false;
            this.gridView_ChiCuc.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_ChiCuc_RowCellClick);
            this.gridView_ChiCuc.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ChiCuc_ValidateRow);
            // 
            // col_th_MaChiCuc
            // 
            this.col_th_MaChiCuc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_MaChiCuc.AppearanceHeader.Options.UseFont = true;
            this.col_th_MaChiCuc.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_MaChiCuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_MaChiCuc.Caption = "Mã chi cục";
            this.col_th_MaChiCuc.FieldName = "MaChiCuc";
            this.col_th_MaChiCuc.Name = "col_th_MaChiCuc";
            this.col_th_MaChiCuc.OptionsColumn.AllowEdit = false;
            this.col_th_MaChiCuc.OptionsColumn.AllowFocus = false;
            this.col_th_MaChiCuc.OptionsColumn.ReadOnly = true;
            this.col_th_MaChiCuc.Visible = true;
            this.col_th_MaChiCuc.VisibleIndex = 0;
            this.col_th_MaChiCuc.Width = 84;
            // 
            // col_th_TenChiCuc
            // 
            this.col_th_TenChiCuc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_TenChiCuc.AppearanceHeader.Options.UseFont = true;
            this.col_th_TenChiCuc.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_TenChiCuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_TenChiCuc.Caption = "Tên chi cục";
            this.col_th_TenChiCuc.FieldName = "TenChiCuc";
            this.col_th_TenChiCuc.Name = "col_th_TenChiCuc";
            this.col_th_TenChiCuc.OptionsColumn.ReadOnly = true;
            this.col_th_TenChiCuc.Visible = true;
            this.col_th_TenChiCuc.VisibleIndex = 1;
            this.col_th_TenChiCuc.Width = 150;
            // 
            // col_th_DiaChiChiCuc
            // 
            this.col_th_DiaChiChiCuc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_DiaChiChiCuc.AppearanceHeader.Options.UseFont = true;
            this.col_th_DiaChiChiCuc.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_DiaChiChiCuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_DiaChiChiCuc.Caption = "Địa chỉ";
            this.col_th_DiaChiChiCuc.FieldName = "DiaChiChiCuc";
            this.col_th_DiaChiChiCuc.Name = "col_th_DiaChiChiCuc";
            this.col_th_DiaChiChiCuc.OptionsColumn.ReadOnly = true;
            this.col_th_DiaChiChiCuc.Visible = true;
            this.col_th_DiaChiChiCuc.VisibleIndex = 2;
            this.col_th_DiaChiChiCuc.Width = 257;
            // 
            // col_th_SdtChiCuc
            // 
            this.col_th_SdtChiCuc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_SdtChiCuc.AppearanceHeader.Options.UseFont = true;
            this.col_th_SdtChiCuc.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_SdtChiCuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_SdtChiCuc.Caption = "Số điện thoại";
            this.col_th_SdtChiCuc.FieldName = "SdtChiCuc";
            this.col_th_SdtChiCuc.Name = "col_th_SdtChiCuc";
            this.col_th_SdtChiCuc.Visible = true;
            this.col_th_SdtChiCuc.VisibleIndex = 3;
            this.col_th_SdtChiCuc.Width = 146;
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
            this.col_th_Logo.Width = 187;
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
            this.col_th_HeaderReport.ColumnEdit = this.repositoryItemPictureEdit_Header;
            this.col_th_HeaderReport.FieldName = "HeaderReport";
            this.col_th_HeaderReport.Name = "col_th_HeaderReport";
            this.col_th_HeaderReport.Visible = true;
            this.col_th_HeaderReport.VisibleIndex = 5;
            this.col_th_HeaderReport.Width = 203;
            // 
            // repositoryItemPictureEdit_Header
            // 
            this.repositoryItemPictureEdit_Header.Name = "repositoryItemPictureEdit_Header";
            this.repositoryItemPictureEdit_Header.NullText = " ";
            this.repositoryItemPictureEdit_Header.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPictureEdit_Header.Click += new System.EventHandler(this.repositoryItemPictureEdit_Header_Click);
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
            this.col_th_Stt.VisibleIndex = 6;
            this.col_th_Stt.Width = 52;
            // 
            // col_th_isLocked
            // 
            this.col_th_isLocked.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_isLocked.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_isLocked.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_isLocked.AppearanceHeader.Options.UseFont = true;
            this.col_th_isLocked.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_isLocked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_isLocked.Caption = "isLocked";
            this.col_th_isLocked.ColumnEdit = this.repositoryItemCheckEdit_isLocked;
            this.col_th_isLocked.FieldName = "isLocked";
            this.col_th_isLocked.Name = "col_th_isLocked";
            this.col_th_isLocked.Visible = true;
            this.col_th_isLocked.VisibleIndex = 7;
            this.col_th_isLocked.Width = 106;
            // 
            // repositoryItemCheckEdit_isLocked
            // 
            this.repositoryItemCheckEdit_isLocked.AutoHeight = false;
            this.repositoryItemCheckEdit_isLocked.Name = "repositoryItemCheckEdit_isLocked";
            // 
            // col_th_RowIDChiCuc
            // 
            this.col_th_RowIDChiCuc.Caption = "RowIDChiCuc";
            this.col_th_RowIDChiCuc.FieldName = "RowIDChiCuc";
            this.col_th_RowIDChiCuc.Name = "col_th_RowIDChiCuc";
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
            // FrmDMChiCuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 497);
            this.Controls.Add(this.gridControl_ChiCuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDMChiCuc";
            this.Text = "FrmDMChiCuc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDMChiCuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ChiCuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ChiCuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_Header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ChiCuc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_MaChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_TenChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_DiaChiChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_SdtChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Logo;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit_logo;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_HeaderReport;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Stt;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_isLocked;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_isLocked;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit_Header;
        private System.Windows.Forms.OpenFileDialog fileLogo;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_RowIDChiCuc;
        private System.Windows.Forms.OpenFileDialog fileHeader;
    }
}