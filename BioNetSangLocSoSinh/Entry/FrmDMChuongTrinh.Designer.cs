namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMChuongTrinh
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
            this.gridControl_ChuongTrinh = new DevExpress.XtraGrid.GridControl();
            this.gridView_ChuongTrinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_th_RowIDChuongTrinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_IDChuongTrinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_TenChuongTrinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_Ngaytao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit_NgayTao = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_th_NgayHetHieuLuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit_NgayHetHieuLuc = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_th_isLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_IsLocked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ChuongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ChuongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_NgayTao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_NgayTao.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_NgayHetHieuLuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_NgayHetHieuLuc.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_IsLocked)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_ChuongTrinh
            // 
            this.gridControl_ChuongTrinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ChuongTrinh.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_ChuongTrinh.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ChuongTrinh.MainView = this.gridView_ChuongTrinh;
            this.gridControl_ChuongTrinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_ChuongTrinh.Name = "gridControl_ChuongTrinh";
            this.gridControl_ChuongTrinh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit_NgayTao,
            this.repositoryItemDateEdit_NgayHetHieuLuc,
            this.repositoryItemCheckEdit_IsLocked});
            this.gridControl_ChuongTrinh.Size = new System.Drawing.Size(915, 557);
            this.gridControl_ChuongTrinh.TabIndex = 0;
            this.gridControl_ChuongTrinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ChuongTrinh});
            this.gridControl_ChuongTrinh.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_ChuongTrinh_ProcessGridKey);
            // 
            // gridView_ChuongTrinh
            // 
            this.gridView_ChuongTrinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_th_RowIDChuongTrinh,
            this.col_th_IDChuongTrinh,
            this.col_th_TenChuongTrinh,
            this.col_th_Ngaytao,
            this.col_th_NgayHetHieuLuc,
            this.col_th_isLocked});
            this.gridView_ChuongTrinh.GridControl = this.gridControl_ChuongTrinh;
            this.gridView_ChuongTrinh.Name = "gridView_ChuongTrinh";
            this.gridView_ChuongTrinh.NewItemRowText = "Thêm danh mục chương trình..";
            this.gridView_ChuongTrinh.OptionsView.ShowGroupPanel = false;
            this.gridView_ChuongTrinh.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ChuongTrinh_ValidateRow);
            // 
            // col_th_RowIDChuongTrinh
            // 
            this.col_th_RowIDChuongTrinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_RowIDChuongTrinh.AppearanceHeader.Options.UseFont = true;
            this.col_th_RowIDChuongTrinh.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_RowIDChuongTrinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_RowIDChuongTrinh.Caption = "RowIDChuongTrinh";
            this.col_th_RowIDChuongTrinh.FieldName = "RowIDChuongTrinh";
            this.col_th_RowIDChuongTrinh.Name = "col_th_RowIDChuongTrinh";
            // 
            // col_th_IDChuongTrinh
            // 
            this.col_th_IDChuongTrinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_IDChuongTrinh.AppearanceHeader.Options.UseFont = true;
            this.col_th_IDChuongTrinh.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_IDChuongTrinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_IDChuongTrinh.Caption = "Mã chương trình";
            this.col_th_IDChuongTrinh.FieldName = "IDChuongTrinh";
            this.col_th_IDChuongTrinh.Name = "col_th_IDChuongTrinh";
            this.col_th_IDChuongTrinh.OptionsColumn.AllowEdit = false;
            this.col_th_IDChuongTrinh.OptionsColumn.ReadOnly = true;
            this.col_th_IDChuongTrinh.Visible = true;
            this.col_th_IDChuongTrinh.VisibleIndex = 0;
            this.col_th_IDChuongTrinh.Width = 149;
            // 
            // col_th_TenChuongTrinh
            // 
            this.col_th_TenChuongTrinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_TenChuongTrinh.AppearanceHeader.Options.UseFont = true;
            this.col_th_TenChuongTrinh.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_TenChuongTrinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_TenChuongTrinh.Caption = "Tên chương trình";
            this.col_th_TenChuongTrinh.FieldName = "TenChuongTrinh";
            this.col_th_TenChuongTrinh.Name = "col_th_TenChuongTrinh";
            this.col_th_TenChuongTrinh.OptionsColumn.AllowEdit = false;
            this.col_th_TenChuongTrinh.OptionsColumn.ReadOnly = true;
            this.col_th_TenChuongTrinh.Visible = true;
            this.col_th_TenChuongTrinh.VisibleIndex = 1;
            this.col_th_TenChuongTrinh.Width = 400;
            // 
            // col_th_Ngaytao
            // 
            this.col_th_Ngaytao.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_Ngaytao.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Ngaytao.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_Ngaytao.AppearanceHeader.Options.UseFont = true;
            this.col_th_Ngaytao.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_Ngaytao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Ngaytao.Caption = "Ngày tạo";
            this.col_th_Ngaytao.ColumnEdit = this.repositoryItemDateEdit_NgayTao;
            this.col_th_Ngaytao.FieldName = "Ngaytao";
            this.col_th_Ngaytao.Name = "col_th_Ngaytao";
            this.col_th_Ngaytao.OptionsColumn.AllowEdit = false;
            this.col_th_Ngaytao.OptionsColumn.ReadOnly = true;
            this.col_th_Ngaytao.Visible = true;
            this.col_th_Ngaytao.VisibleIndex = 2;
            this.col_th_Ngaytao.Width = 210;
            // 
            // repositoryItemDateEdit_NgayTao
            // 
            this.repositoryItemDateEdit_NgayTao.AutoHeight = false;
            this.repositoryItemDateEdit_NgayTao.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit_NgayTao.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit_NgayTao.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.repositoryItemDateEdit_NgayTao.Name = "repositoryItemDateEdit_NgayTao";
            // 
            // col_th_NgayHetHieuLuc
            // 
            this.col_th_NgayHetHieuLuc.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_NgayHetHieuLuc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_NgayHetHieuLuc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_NgayHetHieuLuc.AppearanceHeader.Options.UseFont = true;
            this.col_th_NgayHetHieuLuc.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_NgayHetHieuLuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_NgayHetHieuLuc.Caption = "Ngày hết hiệu lực";
            this.col_th_NgayHetHieuLuc.ColumnEdit = this.repositoryItemDateEdit_NgayHetHieuLuc;
            this.col_th_NgayHetHieuLuc.FieldName = "NgayHetHieuLuc";
            this.col_th_NgayHetHieuLuc.Name = "col_th_NgayHetHieuLuc";
            this.col_th_NgayHetHieuLuc.OptionsColumn.AllowEdit = false;
            this.col_th_NgayHetHieuLuc.OptionsColumn.ReadOnly = true;
            this.col_th_NgayHetHieuLuc.Visible = true;
            this.col_th_NgayHetHieuLuc.VisibleIndex = 3;
            this.col_th_NgayHetHieuLuc.Width = 178;
            // 
            // repositoryItemDateEdit_NgayHetHieuLuc
            // 
            this.repositoryItemDateEdit_NgayHetHieuLuc.AutoHeight = false;
            this.repositoryItemDateEdit_NgayHetHieuLuc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit_NgayHetHieuLuc.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit_NgayHetHieuLuc.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.repositoryItemDateEdit_NgayHetHieuLuc.Name = "repositoryItemDateEdit_NgayHetHieuLuc";
            // 
            // col_th_isLocked
            // 
            this.col_th_isLocked.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_isLocked.AppearanceHeader.Options.UseFont = true;
            this.col_th_isLocked.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_isLocked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_isLocked.Caption = "isLocked";
            this.col_th_isLocked.ColumnEdit = this.repositoryItemCheckEdit_IsLocked;
            this.col_th_isLocked.FieldName = "isLocked";
            this.col_th_isLocked.Name = "col_th_isLocked";
            this.col_th_isLocked.Visible = true;
            this.col_th_isLocked.VisibleIndex = 4;
            this.col_th_isLocked.Width = 111;
            // 
            // repositoryItemCheckEdit_IsLocked
            // 
            this.repositoryItemCheckEdit_IsLocked.AutoHeight = false;
            this.repositoryItemCheckEdit_IsLocked.Name = "repositoryItemCheckEdit_IsLocked";
            // 
            // FrmDMChuongTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 557);
            this.Controls.Add(this.gridControl_ChuongTrinh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDMChuongTrinh";
            this.Text = "FrmDMChuongTrinh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDMChuongTrinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ChuongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ChuongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_NgayTao.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_NgayTao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_NgayHetHieuLuc.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit_NgayHetHieuLuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_IsLocked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ChuongTrinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ChuongTrinh;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_RowIDChuongTrinh;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_IDChuongTrinh;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_TenChuongTrinh;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Ngaytao;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_NgayHetHieuLuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_isLocked;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit_NgayTao;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit_NgayHetHieuLuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_IsLocked;
    }
}