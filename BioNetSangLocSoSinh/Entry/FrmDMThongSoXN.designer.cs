namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmDMThongSoXN
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
            this.gridControl_thongso = new DevExpress.XtraGrid.GridControl();
            this.gridView_thongso = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowIDThongSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IDThongSoXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenThongSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GiaTriMinNu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GiaTriMaxNu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GiaTriTrungBinhNu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GiaTriMacDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GiaTriMinNam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GiaTriMaxNam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GiaTriTrungBinhNam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_nhom = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_th_Stt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GiaTri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_isLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_isLocked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_thongso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_thongso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_nhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_thongso
            // 
            this.gridControl_thongso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_thongso.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_thongso.Location = new System.Drawing.Point(0, 0);
            this.gridControl_thongso.MainView = this.gridView_thongso;
            this.gridControl_thongso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl_thongso.Name = "gridControl_thongso";
            this.gridControl_thongso.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit_isLocked,
            this.repositoryItemLookUpEdit_nhom});
            this.gridControl_thongso.Size = new System.Drawing.Size(1259, 488);
            this.gridControl_thongso.TabIndex = 0;
            this.gridControl_thongso.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_thongso});
            this.gridControl_thongso.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_thongso_ProcessGridKey);
            // 
            // gridView_thongso
            // 
            this.gridView_thongso.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowIDThongSo,
            this.col_IDThongSoXN,
            this.col_TenThongSo,
            this.col_GiaTriMinNu,
            this.col_GiaTriMaxNu,
            this.col_GiaTriTrungBinhNu,
            this.col_GiaTriMacDinh,
            this.col_GiaTriMinNam,
            this.col_GiaTriMaxNam,
            this.col_GiaTriTrungBinhNam,
            this.col_MaNhom,
            this.col_th_Stt,
            this.col_GiaTri,
            this.col_DonViTinh,
            this.col_isLocked});
            this.gridView_thongso.GridControl = this.gridControl_thongso;
            this.gridView_thongso.Name = "gridView_thongso";
            this.gridView_thongso.NewItemRowText = "Thêm danh mục thông số xét nghiệm...";
            this.gridView_thongso.OptionsView.ShowGroupPanel = false;
            this.gridView_thongso.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_thongso_ValidateRow);
            // 
            // col_RowIDThongSo
            // 
            this.col_RowIDThongSo.Caption = "RowIDThongSo";
            this.col_RowIDThongSo.FieldName = "RowIDThongSo";
            this.col_RowIDThongSo.Name = "col_RowIDThongSo";
            // 
            // col_IDThongSoXN
            // 
            this.col_IDThongSoXN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_IDThongSoXN.AppearanceHeader.Options.UseFont = true;
            this.col_IDThongSoXN.AppearanceHeader.Options.UseTextOptions = true;
            this.col_IDThongSoXN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_IDThongSoXN.Caption = "Mã";
            this.col_IDThongSoXN.FieldName = "IDThongSoXN";
            this.col_IDThongSoXN.Name = "col_IDThongSoXN";
            this.col_IDThongSoXN.OptionsColumn.ReadOnly = true;
            this.col_IDThongSoXN.Visible = true;
            this.col_IDThongSoXN.VisibleIndex = 0;
            this.col_IDThongSoXN.Width = 68;
            // 
            // col_TenThongSo
            // 
            this.col_TenThongSo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_TenThongSo.AppearanceHeader.Options.UseFont = true;
            this.col_TenThongSo.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TenThongSo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenThongSo.Caption = "Tên thông số";
            this.col_TenThongSo.FieldName = "TenThongSo";
            this.col_TenThongSo.Name = "col_TenThongSo";
            this.col_TenThongSo.OptionsColumn.ReadOnly = true;
            this.col_TenThongSo.Visible = true;
            this.col_TenThongSo.VisibleIndex = 1;
            this.col_TenThongSo.Width = 128;
            // 
            // col_GiaTriMinNu
            // 
            this.col_GiaTriMinNu.AppearanceCell.Options.UseTextOptions = true;
            this.col_GiaTriMinNu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMinNu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_GiaTriMinNu.AppearanceHeader.Options.UseFont = true;
            this.col_GiaTriMinNu.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GiaTriMinNu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMinNu.Caption = "Giá trị Min nữ";
            this.col_GiaTriMinNu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_GiaTriMinNu.FieldName = "GiaTriMinNu";
            this.col_GiaTriMinNu.Name = "col_GiaTriMinNu";
            this.col_GiaTriMinNu.Visible = true;
            this.col_GiaTriMinNu.VisibleIndex = 3;
            this.col_GiaTriMinNu.Width = 116;
            // 
            // col_GiaTriMaxNu
            // 
            this.col_GiaTriMaxNu.AppearanceCell.Options.UseTextOptions = true;
            this.col_GiaTriMaxNu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMaxNu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_GiaTriMaxNu.AppearanceHeader.Options.UseFont = true;
            this.col_GiaTriMaxNu.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GiaTriMaxNu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMaxNu.Caption = "Giá trị Max nữ";
            this.col_GiaTriMaxNu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_GiaTriMaxNu.FieldName = "GiaTriMaxNu";
            this.col_GiaTriMaxNu.Name = "col_GiaTriMaxNu";
            this.col_GiaTriMaxNu.Visible = true;
            this.col_GiaTriMaxNu.VisibleIndex = 4;
            this.col_GiaTriMaxNu.Width = 107;
            // 
            // col_GiaTriTrungBinhNu
            // 
            this.col_GiaTriTrungBinhNu.AppearanceCell.Options.UseTextOptions = true;
            this.col_GiaTriTrungBinhNu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriTrungBinhNu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_GiaTriTrungBinhNu.AppearanceHeader.Options.UseFont = true;
            this.col_GiaTriTrungBinhNu.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GiaTriTrungBinhNu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriTrungBinhNu.Caption = "Giá trị TB nữ";
            this.col_GiaTriTrungBinhNu.FieldName = "GiaTriTrungBinhNu";
            this.col_GiaTriTrungBinhNu.Name = "col_GiaTriTrungBinhNu";
            this.col_GiaTriTrungBinhNu.Visible = true;
            this.col_GiaTriTrungBinhNu.VisibleIndex = 5;
            this.col_GiaTriTrungBinhNu.Width = 103;
            // 
            // col_GiaTriMacDinh
            // 
            this.col_GiaTriMacDinh.AppearanceCell.Options.UseTextOptions = true;
            this.col_GiaTriMacDinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMacDinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_GiaTriMacDinh.AppearanceHeader.Options.UseFont = true;
            this.col_GiaTriMacDinh.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GiaTriMacDinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMacDinh.Caption = "Giá trị mặc định";
            this.col_GiaTriMacDinh.FieldName = "GiaTriMacDinh";
            this.col_GiaTriMacDinh.Name = "col_GiaTriMacDinh";
            this.col_GiaTriMacDinh.Visible = true;
            this.col_GiaTriMacDinh.VisibleIndex = 6;
            this.col_GiaTriMacDinh.Width = 127;
            // 
            // col_GiaTriMinNam
            // 
            this.col_GiaTriMinNam.AppearanceCell.Options.UseTextOptions = true;
            this.col_GiaTriMinNam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMinNam.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_GiaTriMinNam.AppearanceHeader.Options.UseFont = true;
            this.col_GiaTriMinNam.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GiaTriMinNam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMinNam.Caption = "Giá trị min nam";
            this.col_GiaTriMinNam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_GiaTriMinNam.FieldName = "GiaTriMinNam";
            this.col_GiaTriMinNam.Name = "col_GiaTriMinNam";
            this.col_GiaTriMinNam.Visible = true;
            this.col_GiaTriMinNam.VisibleIndex = 7;
            this.col_GiaTriMinNam.Width = 122;
            // 
            // col_GiaTriMaxNam
            // 
            this.col_GiaTriMaxNam.AppearanceCell.Options.UseTextOptions = true;
            this.col_GiaTriMaxNam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMaxNam.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_GiaTriMaxNam.AppearanceHeader.Options.UseFont = true;
            this.col_GiaTriMaxNam.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GiaTriMaxNam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriMaxNam.Caption = "Giá trị max nam";
            this.col_GiaTriMaxNam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_GiaTriMaxNam.FieldName = "GiaTriMaxNam";
            this.col_GiaTriMaxNam.Name = "col_GiaTriMaxNam";
            this.col_GiaTriMaxNam.Visible = true;
            this.col_GiaTriMaxNam.VisibleIndex = 8;
            this.col_GiaTriMaxNam.Width = 117;
            // 
            // col_GiaTriTrungBinhNam
            // 
            this.col_GiaTriTrungBinhNam.AppearanceCell.Options.UseTextOptions = true;
            this.col_GiaTriTrungBinhNam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriTrungBinhNam.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_GiaTriTrungBinhNam.AppearanceHeader.Options.UseFont = true;
            this.col_GiaTriTrungBinhNam.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GiaTriTrungBinhNam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTriTrungBinhNam.Caption = "Giá trị tb nam";
            this.col_GiaTriTrungBinhNam.FieldName = "GiaTriTrungBinhNam";
            this.col_GiaTriTrungBinhNam.Name = "col_GiaTriTrungBinhNam";
            this.col_GiaTriTrungBinhNam.Visible = true;
            this.col_GiaTriTrungBinhNam.VisibleIndex = 9;
            this.col_GiaTriTrungBinhNam.Width = 105;
            // 
            // col_MaNhom
            // 
            this.col_MaNhom.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_MaNhom.AppearanceHeader.Options.UseFont = true;
            this.col_MaNhom.AppearanceHeader.Options.UseTextOptions = true;
            this.col_MaNhom.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_MaNhom.Caption = "Nhóm";
            this.col_MaNhom.ColumnEdit = this.repositoryItemLookUpEdit_nhom;
            this.col_MaNhom.FieldName = "MaNhom";
            this.col_MaNhom.Name = "col_MaNhom";
            this.col_MaNhom.Visible = true;
            this.col_MaNhom.VisibleIndex = 10;
            this.col_MaNhom.Width = 93;
            // 
            // repositoryItemLookUpEdit_nhom
            // 
            this.repositoryItemLookUpEdit_nhom.AutoHeight = false;
            this.repositoryItemLookUpEdit_nhom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_nhom.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowIDNhom", "RowIDNhom", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhom", "TenNhom")});
            this.repositoryItemLookUpEdit_nhom.Name = "repositoryItemLookUpEdit_nhom";
            this.repositoryItemLookUpEdit_nhom.NullText = "";
            this.repositoryItemLookUpEdit_nhom.ShowFooter = false;
            this.repositoryItemLookUpEdit_nhom.ShowHeader = false;
            // 
            // col_th_Stt
            // 
            this.col_th_Stt.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_Stt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Stt.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_th_Stt.AppearanceHeader.Options.UseFont = true;
            this.col_th_Stt.AppearanceHeader.Options.UseTextOptions = true;
            this.col_th_Stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_Stt.Caption = "Stt";
            this.col_th_Stt.FieldName = "Stt";
            this.col_th_Stt.Name = "col_th_Stt";
            this.col_th_Stt.Visible = true;
            this.col_th_Stt.VisibleIndex = 12;
            this.col_th_Stt.Width = 52;
            // 
            // col_GiaTri
            // 
            this.col_GiaTri.AppearanceCell.Options.UseTextOptions = true;
            this.col_GiaTri.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTri.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_GiaTri.AppearanceHeader.Options.UseFont = true;
            this.col_GiaTri.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GiaTri.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GiaTri.Caption = "Giá trị";
            this.col_GiaTri.FieldName = "GiaTri";
            this.col_GiaTri.Name = "col_GiaTri";
            this.col_GiaTri.Visible = true;
            this.col_GiaTri.VisibleIndex = 13;
            this.col_GiaTri.Width = 63;
            // 
            // col_DonViTinh
            // 
            this.col_DonViTinh.AppearanceCell.Options.UseTextOptions = true;
            this.col_DonViTinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DonViTinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_DonViTinh.AppearanceHeader.Options.UseFont = true;
            this.col_DonViTinh.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DonViTinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DonViTinh.Caption = "Đơn vị";
            this.col_DonViTinh.FieldName = "DonViTinh";
            this.col_DonViTinh.Name = "col_DonViTinh";
            this.col_DonViTinh.Visible = true;
            this.col_DonViTinh.VisibleIndex = 2;
            this.col_DonViTinh.Width = 81;
            // 
            // col_isLocked
            // 
            this.col_isLocked.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.col_isLocked.AppearanceHeader.Options.UseFont = true;
            this.col_isLocked.AppearanceHeader.Options.UseTextOptions = true;
            this.col_isLocked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_isLocked.Caption = "isLocked";
            this.col_isLocked.ColumnEdit = this.repositoryItemCheckEdit_isLocked;
            this.col_isLocked.FieldName = "isLocked";
            this.col_isLocked.Name = "col_isLocked";
            this.col_isLocked.Visible = true;
            this.col_isLocked.VisibleIndex = 13;
            this.col_isLocked.Width = 73;
            // 
            // repositoryItemCheckEdit_isLocked
            // 
            this.repositoryItemCheckEdit_isLocked.AutoHeight = false;
            this.repositoryItemCheckEdit_isLocked.Name = "repositoryItemCheckEdit_isLocked";
            // 
            // FrmDMThongSoXN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 488);
            this.Controls.Add(this.gridControl_thongso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDMThongSoXN";
            this.Text = "FrmDMThongSoXN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDMThongSoXN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_thongso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_thongso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_nhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_isLocked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_thongso;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_thongso;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowIDThongSo;
        private DevExpress.XtraGrid.Columns.GridColumn col_IDThongSoXN;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenThongSo;
        private DevExpress.XtraGrid.Columns.GridColumn col_GiaTriMinNu;
        private DevExpress.XtraGrid.Columns.GridColumn col_GiaTriMaxNu;
        private DevExpress.XtraGrid.Columns.GridColumn col_GiaTriTrungBinhNu;
        private DevExpress.XtraGrid.Columns.GridColumn col_GiaTriMacDinh;
        private DevExpress.XtraGrid.Columns.GridColumn col_GiaTriMinNam;
        private DevExpress.XtraGrid.Columns.GridColumn col_GiaTriMaxNam;
        private DevExpress.XtraGrid.Columns.GridColumn col_GiaTriTrungBinhNam;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaNhom;
        private DevExpress.XtraGrid.Columns.GridColumn col_th_Stt;
        private DevExpress.XtraGrid.Columns.GridColumn col_GiaTri;
        private DevExpress.XtraGrid.Columns.GridColumn col_DonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn col_isLocked;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_isLocked;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_nhom;
    }
}