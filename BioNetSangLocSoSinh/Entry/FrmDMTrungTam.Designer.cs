namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMTrungTam
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
            this.gridControl_Trungtam = new DevExpress.XtraGrid.GridControl();
            this.gridView_Trungtam = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_th_MaTrungTam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_TenTrungTam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_Diachi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_DienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_MaVietTat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_Logo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit_logo = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.fileLogo = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Trungtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Trungtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Trungtam
            // 
            this.gridControl_Trungtam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Trungtam.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Trungtam.MainView = this.gridView_Trungtam;
            this.gridControl_Trungtam.Name = "gridControl_Trungtam";
            this.gridControl_Trungtam.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit_logo});
            this.gridControl_Trungtam.Size = new System.Drawing.Size(1149, 576);
            this.gridControl_Trungtam.TabIndex = 0;
            this.gridControl_Trungtam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Trungtam});
            // 
            // gridView_Trungtam
            // 
            this.gridView_Trungtam.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_th_MaTrungTam,
            this.col_th_TenTrungTam,
            this.col_th_Diachi,
            this.col_th_DienThoai,
            this.col_th_MaVietTat,
            this.col_th_Logo});
            this.gridView_Trungtam.GridControl = this.gridControl_Trungtam;
            this.gridView_Trungtam.Name = "gridView_Trungtam";
            this.gridView_Trungtam.OptionsView.ShowGroupPanel = false;
            this.gridView_Trungtam.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Trungtam_ValidateRow);
            // 
            // col_th_MaTrungTam
            // 
            this.col_th_MaTrungTam.Caption = "MaTrungTam";
            this.col_th_MaTrungTam.FieldName = "MaTrungTam";
            this.col_th_MaTrungTam.Name = "col_th_MaTrungTam";
            // 
            // col_th_TenTrungTam
            // 
            this.col_th_TenTrungTam.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_TenTrungTam.AppearanceHeader.Options.UseFont = true;
            this.col_th_TenTrungTam.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_TenTrungTam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_TenTrungTam.Caption = "Tên trung tâm";
            this.col_th_TenTrungTam.FieldName = "TenTrungTam";
            this.col_th_TenTrungTam.Name = "col_th_TenTrungTam";
            this.col_th_TenTrungTam.Visible = true;
            this.col_th_TenTrungTam.VisibleIndex = 0;
            // 
            // col_th_Diachi
            // 
            this.col_th_Diachi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_Diachi.AppearanceHeader.Options.UseFont = true;
            this.col_th_Diachi.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_Diachi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Diachi.Caption = "Địa chỉ";
            this.col_th_Diachi.FieldName = "Diachi";
            this.col_th_Diachi.Name = "col_th_Diachi";
            this.col_th_Diachi.Visible = true;
            this.col_th_Diachi.VisibleIndex = 1;
            // 
            // col_th_DienThoai
            // 
            this.col_th_DienThoai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_DienThoai.AppearanceHeader.Options.UseFont = true;
            this.col_th_DienThoai.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_DienThoai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_DienThoai.Caption = "Điện thoại";
            this.col_th_DienThoai.FieldName = "DienThoai";
            this.col_th_DienThoai.Name = "col_th_DienThoai";
            this.col_th_DienThoai.Visible = true;
            this.col_th_DienThoai.VisibleIndex = 2;
            // 
            // col_th_MaVietTat
            // 
            this.col_th_MaVietTat.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_MaVietTat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_MaVietTat.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_MaVietTat.AppearanceHeader.Options.UseFont = true;
            this.col_th_MaVietTat.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_MaVietTat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_MaVietTat.Caption = "Mã viết tắt";
            this.col_th_MaVietTat.FieldName = "MaVietTat";
            this.col_th_MaVietTat.Name = "col_th_MaVietTat";
            this.col_th_MaVietTat.Visible = true;
            this.col_th_MaVietTat.VisibleIndex = 3;
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
            // 
            // repositoryItemPictureEdit_logo
            // 
            this.repositoryItemPictureEdit_logo.Name = "repositoryItemPictureEdit_logo";
            this.repositoryItemPictureEdit_logo.NullText = " ";
            this.repositoryItemPictureEdit_logo.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPictureEdit_logo.Click += new System.EventHandler(this.repositoryItemPictureEdit_logo_Click);
            // 
            // fileLogo
            // 
            this.fileLogo.FileName = "fileLogo";
            this.fileLogo.FileOk += new System.ComponentModel.CancelEventHandler(this.fileLogo_FileOk);
            // 
            // FrmDMTrungTam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 576);
            this.Controls.Add(this.gridControl_Trungtam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDMTrungTam";
            this.Text = "FrmDMTrungTam";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDMTrungTam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Trungtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Trungtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Trungtam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Trungtam;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_MaTrungTam;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_TenTrungTam;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Diachi;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_DienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_MaVietTat;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Logo;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit_logo;
        private System.Windows.Forms.OpenFileDialog fileLogo;
    }
}