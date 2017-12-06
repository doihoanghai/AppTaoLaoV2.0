namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMDichVu
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
            this.gridControl_DMDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridView_DMDichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_th_IDDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_TenDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_TenHienThiDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_GiaDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_th_MaNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Nhom = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_th_isLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_isLocked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_th_isGoiXn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_xetNghiem = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DMDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DMDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Nhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_xetNghiem)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_DMDichVu
            // 
            this.gridControl_DMDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DMDichVu.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_DMDichVu.Location = new System.Drawing.Point(0, 0);
            this.gridControl_DMDichVu.MainView = this.gridView_DMDichVu;
            this.gridControl_DMDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_DMDichVu.Name = "gridControl_DMDichVu";
            this.gridControl_DMDichVu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit_isLocked,
            this.repositoryItemCheckEdit_xetNghiem,
            this.repositoryItemLookUpEdit_Nhom});
            this.gridControl_DMDichVu.Size = new System.Drawing.Size(998, 526);
            this.gridControl_DMDichVu.TabIndex = 0;
            this.gridControl_DMDichVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DMDichVu});
            this.gridControl_DMDichVu.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_DMDichVu_ProcessGridKey);
            // 
            // gridView_DMDichVu
            // 
            this.gridView_DMDichVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_th_IDDichVu,
            this.col_th_TenDichVu,
            this.col_th_TenHienThiDichVu,
            this.col_th_GiaDichVu,
            this.col_th_MaNhom,
            this.col_th_isLocked,
            this.col_th_isGoiXn});
            this.gridView_DMDichVu.GridControl = this.gridControl_DMDichVu;
            this.gridView_DMDichVu.Name = "gridView_DMDichVu";
            this.gridView_DMDichVu.NewItemRowText = "Thêm danh mục dịch vụ mới";
            this.gridView_DMDichVu.OptionsView.ShowGroupPanel = false;
            this.gridView_DMDichVu.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_DMDichVu_ValidateRow);
            // 
            // col_th_IDDichVu
            // 
            this.col_th_IDDichVu.Caption = "IDDichVu";
            this.col_th_IDDichVu.FieldName = "IDDichVu";
            this.col_th_IDDichVu.Name = "col_th_IDDichVu";
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
            this.col_th_TenDichVu.OptionsColumn.ReadOnly = true;
            this.col_th_TenDichVu.Visible = true;
            this.col_th_TenDichVu.VisibleIndex = 0;
            this.col_th_TenDichVu.Width = 144;
            // 
            // col_th_TenHienThiDichVu
            // 
            this.col_th_TenHienThiDichVu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_TenHienThiDichVu.AppearanceHeader.Options.UseFont = true;
            this.col_th_TenHienThiDichVu.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_TenHienThiDichVu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_TenHienThiDichVu.Caption = "Tên hiển thị dịch vụ";
            this.col_th_TenHienThiDichVu.FieldName = "TenHienThiDichVu";
            this.col_th_TenHienThiDichVu.Name = "col_th_TenHienThiDichVu";
            this.col_th_TenHienThiDichVu.OptionsColumn.AllowEdit = false;
            this.col_th_TenHienThiDichVu.OptionsColumn.ReadOnly = true;
            this.col_th_TenHienThiDichVu.Visible = true;
            this.col_th_TenHienThiDichVu.VisibleIndex = 1;
            this.col_th_TenHienThiDichVu.Width = 367;
            // 
            // col_th_GiaDichVu
            // 
            this.col_th_GiaDichVu.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_GiaDichVu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_th_GiaDichVu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_GiaDichVu.AppearanceHeader.Options.UseFont = true;
            this.col_th_GiaDichVu.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_GiaDichVu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_GiaDichVu.Caption = "Giá dịch vụ";
            this.col_th_GiaDichVu.DisplayFormat.FormatString = "{0:#,#}";
            this.col_th_GiaDichVu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_th_GiaDichVu.FieldName = "GiaDichVu";
            this.col_th_GiaDichVu.Name = "col_th_GiaDichVu";
            this.col_th_GiaDichVu.Visible = true;
            this.col_th_GiaDichVu.VisibleIndex = 2;
            this.col_th_GiaDichVu.Width = 210;
            // 
            // col_th_MaNhom
            // 
            this.col_th_MaNhom.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_MaNhom.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_MaNhom.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_MaNhom.AppearanceHeader.Options.UseFont = true;
            this.col_th_MaNhom.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_MaNhom.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_MaNhom.Caption = "MaNhom";
            this.col_th_MaNhom.ColumnEdit = this.repositoryItemLookUpEdit_Nhom;
            this.col_th_MaNhom.FieldName = "MaNhom";
            this.col_th_MaNhom.Name = "col_th_MaNhom";
            this.col_th_MaNhom.Visible = true;
            this.col_th_MaNhom.VisibleIndex = 3;
            this.col_th_MaNhom.Width = 170;
            // 
            // repositoryItemLookUpEdit_Nhom
            // 
            this.repositoryItemLookUpEdit_Nhom.AutoHeight = false;
            this.repositoryItemLookUpEdit_Nhom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Nhom.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowIDNhom", "RowIDNhom", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhom", "TenNhom")});
            this.repositoryItemLookUpEdit_Nhom.Name = "repositoryItemLookUpEdit_Nhom";
            this.repositoryItemLookUpEdit_Nhom.NullText = "";
            this.repositoryItemLookUpEdit_Nhom.ShowFooter = false;
            this.repositoryItemLookUpEdit_Nhom.ShowHeader = false;
            // 
            // col_th_isLocked
            // 
            this.col_th_isLocked.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_isLocked.AppearanceHeader.Options.UseFont = true;
            this.col_th_isLocked.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_isLocked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_isLocked.Caption = "isLocked";
            this.col_th_isLocked.ColumnEdit = this.repositoryItemCheckEdit_isLocked;
            this.col_th_isLocked.FieldName = "isLocked";
            this.col_th_isLocked.Name = "col_th_isLocked";
            this.col_th_isLocked.Visible = true;
            this.col_th_isLocked.VisibleIndex = 4;
            this.col_th_isLocked.Width = 106;
            // 
            // repositoryItemCheckEdit_isLocked
            // 
            this.repositoryItemCheckEdit_isLocked.AutoHeight = false;
            this.repositoryItemCheckEdit_isLocked.DisplayValueChecked = "True";
            this.repositoryItemCheckEdit_isLocked.DisplayValueGrayed = "False";
            this.repositoryItemCheckEdit_isLocked.DisplayValueUnchecked = "False";
            this.repositoryItemCheckEdit_isLocked.Name = "repositoryItemCheckEdit_isLocked";
            this.repositoryItemCheckEdit_isLocked.Tag = false;
            this.repositoryItemCheckEdit_isLocked.ValueGrayed = false;
            // 
            // col_th_isGoiXn
            // 
            this.col_th_isGoiXn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_isGoiXn.AppearanceHeader.Options.UseFont = true;
            this.col_th_isGoiXn.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_isGoiXn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_isGoiXn.Caption = "Gói xét nghiệm";
            this.col_th_isGoiXn.ColumnEdit = this.repositoryItemCheckEdit_xetNghiem;
            this.col_th_isGoiXn.FieldName = "isGoiXn";
            this.col_th_isGoiXn.Name = "col_th_isGoiXn";
            this.col_th_isGoiXn.OptionsColumn.ReadOnly = true;
            this.col_th_isGoiXn.Visible = true;
            this.col_th_isGoiXn.VisibleIndex = 5;
            this.col_th_isGoiXn.Width = 147;
            // 
            // repositoryItemCheckEdit_xetNghiem
            // 
            this.repositoryItemCheckEdit_xetNghiem.AutoHeight = false;
            this.repositoryItemCheckEdit_xetNghiem.DisplayValueChecked = "True";
            this.repositoryItemCheckEdit_xetNghiem.DisplayValueGrayed = "False";
            this.repositoryItemCheckEdit_xetNghiem.DisplayValueUnchecked = "False";
            this.repositoryItemCheckEdit_xetNghiem.Name = "repositoryItemCheckEdit_xetNghiem";
            this.repositoryItemCheckEdit_xetNghiem.Tag = false;
            this.repositoryItemCheckEdit_xetNghiem.ValueGrayed = false;
            // 
            // FrmDMDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 526);
            this.Controls.Add(this.gridControl_DMDichVu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDMDichVu";
            this.Text = "FrmDMDichVu";
            this.Load += new System.EventHandler(this.FrmDMDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DMDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DMDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Nhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_xetNghiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_DMDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DMDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_IDDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_TenDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_TenHienThiDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_GiaDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_MaNhom;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_isLocked;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_isGoiXn;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_isLocked;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_xetNghiem;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Nhom;
    }
}