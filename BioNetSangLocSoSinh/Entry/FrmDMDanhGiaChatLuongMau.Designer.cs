namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMDanhGiaChatLuongMau
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
            this.gridControl_DanhGiaChatLuongMau = new DevExpress.XtraGrid.GridControl();
            this.gridView_DanhGiaChatLuongMau = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_th_RowIDChatLuongMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_IDDanhGiaChatLuongMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_ChatLuongMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_isLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_isLocked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DanhGiaChatLuongMau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DanhGiaChatLuongMau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_DanhGiaChatLuongMau
            // 
            this.gridControl_DanhGiaChatLuongMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DanhGiaChatLuongMau.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_DanhGiaChatLuongMau.Location = new System.Drawing.Point(0, 0);
            this.gridControl_DanhGiaChatLuongMau.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.gridControl_DanhGiaChatLuongMau.MainView = this.gridView_DanhGiaChatLuongMau;
            this.gridControl_DanhGiaChatLuongMau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_DanhGiaChatLuongMau.Name = "gridControl_DanhGiaChatLuongMau";
            this.gridControl_DanhGiaChatLuongMau.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit_isLocked});
            this.gridControl_DanhGiaChatLuongMau.Size = new System.Drawing.Size(963, 478);
            this.gridControl_DanhGiaChatLuongMau.TabIndex = 0;
            this.gridControl_DanhGiaChatLuongMau.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DanhGiaChatLuongMau});
            this.gridControl_DanhGiaChatLuongMau.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_DanhGiaChatLuongMau_ProcessGridKey);
            // 
            // gridView_DanhGiaChatLuongMau
            // 
            this.gridView_DanhGiaChatLuongMau.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_th_RowIDChatLuongMau,
            this.col_th_IDDanhGiaChatLuongMau,
            this.col_th_ChatLuongMau,
            this.col_th_isLocked});
            this.gridView_DanhGiaChatLuongMau.GridControl = this.gridControl_DanhGiaChatLuongMau;
            this.gridView_DanhGiaChatLuongMau.Name = "gridView_DanhGiaChatLuongMau";
            this.gridView_DanhGiaChatLuongMau.NewItemRowText = "Thêm danh mục đánh giá chất lượng mẫu...";
            this.gridView_DanhGiaChatLuongMau.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_DanhGiaChatLuongMau.OptionsView.ShowGroupPanel = false;
            this.gridView_DanhGiaChatLuongMau.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_DanhGiaChatLuongMau_ValidateRow);
            // 
            // col_th_RowIDChatLuongMau
            // 
            this.col_th_RowIDChatLuongMau.Caption = "RowIDChatLuongMau";
            this.col_th_RowIDChatLuongMau.FieldName = "RowIDChatLuongMau";
            this.col_th_RowIDChatLuongMau.Name = "col_th_RowIDChatLuongMau";
            // 
            // col_th_IDDanhGiaChatLuongMau
            // 
            this.col_th_IDDanhGiaChatLuongMau.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_IDDanhGiaChatLuongMau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_IDDanhGiaChatLuongMau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_IDDanhGiaChatLuongMau.AppearanceHeader.Options.UseFont = true;
            this.col_th_IDDanhGiaChatLuongMau.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_IDDanhGiaChatLuongMau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_IDDanhGiaChatLuongMau.Caption = "Mã đánh giá";
            this.col_th_IDDanhGiaChatLuongMau.FieldName = "IDDanhGiaChatLuongMau";
            this.col_th_IDDanhGiaChatLuongMau.Name = "col_th_IDDanhGiaChatLuongMau";
            this.col_th_IDDanhGiaChatLuongMau.Visible = true;
            this.col_th_IDDanhGiaChatLuongMau.VisibleIndex = 0;
            this.col_th_IDDanhGiaChatLuongMau.Width = 165;
            // 
            // col_th_ChatLuongMau
            // 
            this.col_th_ChatLuongMau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_ChatLuongMau.AppearanceHeader.Options.UseFont = true;
            this.col_th_ChatLuongMau.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_ChatLuongMau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_ChatLuongMau.Caption = "Chất lượng mẫu";
            this.col_th_ChatLuongMau.FieldName = "ChatLuongMau";
            this.col_th_ChatLuongMau.Name = "col_th_ChatLuongMau";
            this.col_th_ChatLuongMau.Visible = true;
            this.col_th_ChatLuongMau.VisibleIndex = 1;
            this.col_th_ChatLuongMau.Width = 813;
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
            this.col_th_isLocked.VisibleIndex = 2;
            this.col_th_isLocked.Width = 125;
            // 
            // repositoryItemCheckEdit_isLocked
            // 
            this.repositoryItemCheckEdit_isLocked.AutoHeight = false;
            this.repositoryItemCheckEdit_isLocked.Name = "repositoryItemCheckEdit_isLocked";
            // 
            // FrmDMDanhGiaChatLuongMau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 478);
            this.Controls.Add(this.gridControl_DanhGiaChatLuongMau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDMDanhGiaChatLuongMau";
            this.Text = "FrmDMDanhGiaChatLuongMau";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDMDanhGiaChatLuongMau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DanhGiaChatLuongMau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DanhGiaChatLuongMau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_DanhGiaChatLuongMau;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DanhGiaChatLuongMau;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_RowIDChatLuongMau;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_IDDanhGiaChatLuongMau;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_ChatLuongMau;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_isLocked;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_isLocked;
    }
}