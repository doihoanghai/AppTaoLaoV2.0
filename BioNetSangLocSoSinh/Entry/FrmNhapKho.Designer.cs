namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmNhapKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNhapKho));
            this.grDetails = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Detail = new DevExpress.XtraGrid.GridControl();
            this.gridView_Detail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaPhieuNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearch_VatTu = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchView_Item = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repSearch_MaVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearch_TenVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearch_DongGoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearch_DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearch_SoLuongQuyDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DongGoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SLQuyDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SoLuongNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SoLoVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_HanSuDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ref_UoM = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.ref_view_UoM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.view_UoM_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.view_UoM_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grHeader = new DevExpress.XtraEditors.GroupControl();
            this.cboLyDoNhap = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtNhaCungCap = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.txtSophieu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkupNhacc = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNCC_VendorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCC_VendorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCC_VendorTaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCC_Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCC_VendorAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).BeginInit();
            this.grDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearch_VatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_UoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_view_UoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grHeader)).BeginInit();
            this.grHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLyDoNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhaCungCap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSophieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhacc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // grDetails
            // 
            this.grDetails.Appearance.BackColor = System.Drawing.Color.White;
            this.grDetails.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grDetails.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grDetails.Appearance.Options.UseBackColor = true;
            this.grDetails.Appearance.Options.UseFont = true;
            this.grDetails.Appearance.Options.UseForeColor = true;
            this.grDetails.Controls.Add(this.gridControl_Detail);
            this.grDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetails.Location = new System.Drawing.Point(0, 76);
            this.grDetails.Name = "grDetails";
            this.grDetails.Size = new System.Drawing.Size(878, 385);
            this.grDetails.TabIndex = 16;
            this.grDetails.Text = "Chi tiết danh sách đơn hàng";
            // 
            // gridControl_Detail
            // 
            this.gridControl_Detail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Detail.Location = new System.Drawing.Point(2, 20);
            this.gridControl_Detail.MainView = this.gridView_Detail;
            this.gridControl_Detail.Name = "gridControl_Detail";
            this.gridControl_Detail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_UoM,
            this.repSearch_VatTu,
            this.repositoryItemDateEdit1});
            this.gridControl_Detail.Size = new System.Drawing.Size(874, 363);
            this.gridControl_Detail.TabIndex = 15;
            this.gridControl_Detail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Detail});
            // 
            // gridView_Detail
            // 
            this.gridView_Detail.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Detail.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Detail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.col_MaPhieuNhap,
            this.col_MaVatTu,
            this.col_DongGoi,
            this.col_DonViTinh,
            this.col_SLQuyDoi,
            this.col_SoLuong,
            this.col_SoLuongNhap,
            this.col_SoLoVatTu,
            this.col_HanSuDung});
            this.gridView_Detail.GridControl = this.gridControl_Detail;
            this.gridView_Detail.Name = "gridView_Detail";
            this.gridView_Detail.NewItemRowText = "Nhập thêm mới danh sách vật tư cho đơn hàng mua!";
            this.gridView_Detail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Detail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Detail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Detail.OptionsView.ShowFooter = true;
            this.gridView_Detail.OptionsView.ShowGroupPanel = false;
            this.gridView_Detail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Detail_InvalidRowException);
            this.gridView_Detail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Detail_ValidateRow);
            this.gridView_Detail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Detail_KeyDown);
            this.gridView_Detail.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_Detail_ValidatingEditor);
            // 
            // col_RowID
            // 
            this.col_RowID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.col_RowID.AppearanceCell.Options.UseFont = true;
            this.col_RowID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.col_RowID.AppearanceHeader.Options.UseFont = true;
            this.col_RowID.Caption = "RowID";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.OptionsColumn.AllowMove = false;
            // 
            // col_MaPhieuNhap
            // 
            this.col_MaPhieuNhap.Caption = "Code";
            this.col_MaPhieuNhap.FieldName = "MaPhieuNhap";
            this.col_MaPhieuNhap.Name = "col_MaPhieuNhap";
            // 
            // col_MaVatTu
            // 
            this.col_MaVatTu.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.col_MaVatTu.AppearanceHeader.BorderColor = System.Drawing.Color.White;
            this.col_MaVatTu.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.col_MaVatTu.AppearanceHeader.Options.UseBackColor = true;
            this.col_MaVatTu.AppearanceHeader.Options.UseForeColor = true;
            this.col_MaVatTu.AppearanceHeader.Options.UseTextOptions = true;
            this.col_MaVatTu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_MaVatTu.Caption = "Vật tư";
            this.col_MaVatTu.ColumnEdit = this.repSearch_VatTu;
            this.col_MaVatTu.FieldName = "MaVatTu";
            this.col_MaVatTu.Name = "col_MaVatTu";
            this.col_MaVatTu.OptionsColumn.AllowMove = false;
            this.col_MaVatTu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.col_MaVatTu.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemCode", "Cộng khoản : {0:#,#}")});
            this.col_MaVatTu.Visible = true;
            this.col_MaVatTu.VisibleIndex = 0;
            this.col_MaVatTu.Width = 255;
            // 
            // repSearch_VatTu
            // 
            this.repSearch_VatTu.AutoHeight = false;
            this.repSearch_VatTu.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repSearch_VatTu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearch_VatTu.DisplayMember = "TenVatTu";
            this.repSearch_VatTu.Name = "repSearch_VatTu";
            this.repSearch_VatTu.NullText = "";
            this.repSearch_VatTu.ShowClearButton = false;
            this.repSearch_VatTu.ValueMember = "MaVatTu";
            this.repSearch_VatTu.View = this.repSearchView_Item;
            this.repSearch_VatTu.EditValueChanged += new System.EventHandler(this.repSearch_VatTu_EditValueChanged);
            // 
            // repSearchView_Item
            // 
            this.repSearchView_Item.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.repSearch_MaVatTu,
            this.repSearch_TenVatTu,
            this.repSearch_DongGoi,
            this.repSearch_DonViTinh,
            this.repSearch_SoLuongQuyDoi});
            this.repSearchView_Item.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchView_Item.Name = "repSearchView_Item";
            this.repSearchView_Item.OptionsFind.FindFilterColumns = "ItemName;Active";
            this.repSearchView_Item.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchView_Item.OptionsView.ShowGroupPanel = false;
            // 
            // repSearch_MaVatTu
            // 
            this.repSearch_MaVatTu.Caption = "Vật tư";
            this.repSearch_MaVatTu.FieldName = "MaVatTu";
            this.repSearch_MaVatTu.Name = "repSearch_MaVatTu";
            this.repSearch_MaVatTu.OptionsColumn.ReadOnly = true;
            // 
            // repSearch_TenVatTu
            // 
            this.repSearch_TenVatTu.Caption = "Vật tư";
            this.repSearch_TenVatTu.FieldName = "TenVatTu";
            this.repSearch_TenVatTu.Name = "repSearch_TenVatTu";
            this.repSearch_TenVatTu.OptionsColumn.ReadOnly = true;
            this.repSearch_TenVatTu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.repSearch_TenVatTu.Visible = true;
            this.repSearch_TenVatTu.VisibleIndex = 0;
            this.repSearch_TenVatTu.Width = 162;
            // 
            // repSearch_DongGoi
            // 
            this.repSearch_DongGoi.AppearanceCell.Options.UseTextOptions = true;
            this.repSearch_DongGoi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repSearch_DongGoi.AppearanceHeader.Options.UseTextOptions = true;
            this.repSearch_DongGoi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repSearch_DongGoi.Caption = "Đóng gói";
            this.repSearch_DongGoi.FieldName = "DongGoi";
            this.repSearch_DongGoi.Name = "repSearch_DongGoi";
            this.repSearch_DongGoi.OptionsColumn.ReadOnly = true;
            this.repSearch_DongGoi.Visible = true;
            this.repSearch_DongGoi.VisibleIndex = 1;
            this.repSearch_DongGoi.Width = 66;
            // 
            // repSearch_DonViTinh
            // 
            this.repSearch_DonViTinh.Caption = "Đơn vị tính";
            this.repSearch_DonViTinh.FieldName = "DonViTinh";
            this.repSearch_DonViTinh.Name = "repSearch_DonViTinh";
            this.repSearch_DonViTinh.OptionsColumn.ReadOnly = true;
            this.repSearch_DonViTinh.Visible = true;
            this.repSearch_DonViTinh.VisibleIndex = 2;
            this.repSearch_DonViTinh.Width = 59;
            // 
            // repSearch_SoLuongQuyDoi
            // 
            this.repSearch_SoLuongQuyDoi.AppearanceCell.Options.UseTextOptions = true;
            this.repSearch_SoLuongQuyDoi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repSearch_SoLuongQuyDoi.AppearanceHeader.Options.UseTextOptions = true;
            this.repSearch_SoLuongQuyDoi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repSearch_SoLuongQuyDoi.Caption = "Giá mua";
            this.repSearch_SoLuongQuyDoi.DisplayFormat.FormatString = "#,#";
            this.repSearch_SoLuongQuyDoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSearch_SoLuongQuyDoi.FieldName = "SoLuongQuyDoi";
            this.repSearch_SoLuongQuyDoi.Name = "repSearch_SoLuongQuyDoi";
            this.repSearch_SoLuongQuyDoi.OptionsColumn.ReadOnly = true;
            this.repSearch_SoLuongQuyDoi.Visible = true;
            this.repSearch_SoLuongQuyDoi.VisibleIndex = 3;
            this.repSearch_SoLuongQuyDoi.Width = 81;
            // 
            // col_DongGoi
            // 
            this.col_DongGoi.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DongGoi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DongGoi.Caption = "Đóng gói";
            this.col_DongGoi.FieldName = "DongGoi";
            this.col_DongGoi.Name = "col_DongGoi";
            this.col_DongGoi.OptionsColumn.AllowEdit = false;
            this.col_DongGoi.OptionsColumn.AllowFocus = false;
            this.col_DongGoi.OptionsColumn.ReadOnly = true;
            this.col_DongGoi.Visible = true;
            this.col_DongGoi.VisibleIndex = 1;
            this.col_DongGoi.Width = 99;
            // 
            // col_DonViTinh
            // 
            this.col_DonViTinh.Caption = "Đơn vị tính";
            this.col_DonViTinh.FieldName = "DonViTinh";
            this.col_DonViTinh.Name = "col_DonViTinh";
            this.col_DonViTinh.OptionsColumn.AllowEdit = false;
            this.col_DonViTinh.Visible = true;
            this.col_DonViTinh.VisibleIndex = 2;
            this.col_DonViTinh.Width = 88;
            // 
            // col_SLQuyDoi
            // 
            this.col_SLQuyDoi.AppearanceCell.Options.UseTextOptions = true;
            this.col_SLQuyDoi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SLQuyDoi.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SLQuyDoi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SLQuyDoi.Caption = "SL Quy Đổi";
            this.col_SLQuyDoi.DisplayFormat.FormatString = "{0:#,#}";
            this.col_SLQuyDoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SLQuyDoi.FieldName = "SoLuongQuyDoi";
            this.col_SLQuyDoi.Name = "col_SLQuyDoi";
            this.col_SLQuyDoi.OptionsColumn.AllowEdit = false;
            this.col_SLQuyDoi.OptionsColumn.AllowFocus = false;
            this.col_SLQuyDoi.OptionsColumn.ReadOnly = true;
            this.col_SLQuyDoi.Visible = true;
            this.col_SLQuyDoi.VisibleIndex = 4;
            this.col_SLQuyDoi.Width = 90;
            // 
            // col_SoLuong
            // 
            this.col_SoLuong.AppearanceCell.Options.UseTextOptions = true;
            this.col_SoLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SoLuong.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SoLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SoLuong.Caption = "Số Lượng";
            this.col_SoLuong.DisplayFormat.FormatString = "{0:#,#}";
            this.col_SoLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SoLuong.FieldName = "SoLuong";
            this.col_SoLuong.Name = "col_SoLuong";
            this.col_SoLuong.OptionsColumn.AllowMove = false;
            this.col_SoLuong.OptionsColumn.FixedWidth = true;
            this.col_SoLuong.Visible = true;
            this.col_SoLuong.VisibleIndex = 3;
            this.col_SoLuong.Width = 61;
            // 
            // col_SoLuongNhap
            // 
            this.col_SoLuongNhap.AppearanceCell.Options.UseTextOptions = true;
            this.col_SoLuongNhap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SoLuongNhap.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SoLuongNhap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SoLuongNhap.Caption = "Số lượng nhập";
            this.col_SoLuongNhap.DisplayFormat.FormatString = "{0:#,#}";
            this.col_SoLuongNhap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SoLuongNhap.FieldName = "SoLuongNhap";
            this.col_SoLuongNhap.Name = "col_SoLuongNhap";
            this.col_SoLuongNhap.OptionsColumn.AllowEdit = false;
            this.col_SoLuongNhap.OptionsColumn.AllowFocus = false;
            this.col_SoLuongNhap.OptionsColumn.AllowMove = false;
            this.col_SoLuongNhap.OptionsColumn.AllowSize = false;
            this.col_SoLuongNhap.OptionsColumn.FixedWidth = true;
            this.col_SoLuongNhap.OptionsColumn.ReadOnly = true;
            this.col_SoLuongNhap.Visible = true;
            this.col_SoLuongNhap.VisibleIndex = 5;
            this.col_SoLuongNhap.Width = 80;
            // 
            // col_SoLoVatTu
            // 
            this.col_SoLoVatTu.Caption = "Số Lô";
            this.col_SoLoVatTu.FieldName = "SoLo";
            this.col_SoLoVatTu.Name = "col_SoLoVatTu";
            this.col_SoLoVatTu.Visible = true;
            this.col_SoLoVatTu.VisibleIndex = 6;
            this.col_SoLoVatTu.Width = 76;
            // 
            // col_HanSuDung
            // 
            this.col_HanSuDung.Caption = "Hạn sử dụng";
            this.col_HanSuDung.ColumnEdit = this.repositoryItemDateEdit1;
            this.col_HanSuDung.FieldName = "HanSuDung";
            this.col_HanSuDung.Name = "col_HanSuDung";
            this.col_HanSuDung.Visible = true;
            this.col_HanSuDung.VisibleIndex = 7;
            this.col_HanSuDung.Width = 109;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // ref_UoM
            // 
            this.ref_UoM.AutoHeight = false;
            this.ref_UoM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_UoM.Name = "ref_UoM";
            this.ref_UoM.NullText = "...";
            this.ref_UoM.View = this.ref_view_UoM;
            // 
            // ref_view_UoM
            // 
            this.ref_view_UoM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view_UoM_Code,
            this.view_UoM_Name});
            this.ref_view_UoM.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ref_view_UoM.Name = "ref_view_UoM";
            this.ref_view_UoM.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ref_view_UoM.OptionsView.ShowGroupPanel = false;
            // 
            // view_UoM_Code
            // 
            this.view_UoM_Code.Caption = "Mã ĐVT";
            this.view_UoM_Code.FieldName = "UnitOfMeasureCode";
            this.view_UoM_Code.Name = "view_UoM_Code";
            this.view_UoM_Code.Visible = true;
            this.view_UoM_Code.VisibleIndex = 0;
            // 
            // view_UoM_Name
            // 
            this.view_UoM_Name.Caption = "Tên ĐVT";
            this.view_UoM_Name.FieldName = "UnitOfMeasureName";
            this.view_UoM_Name.Name = "view_UoM_Name";
            this.view_UoM_Name.Visible = true;
            this.view_UoM_Name.VisibleIndex = 1;
            // 
            // grHeader
            // 
            this.grHeader.Controls.Add(this.cboLyDoNhap);
            this.grHeader.Controls.Add(this.btnNew);
            this.grHeader.Controls.Add(this.btnSave);
            this.grHeader.Controls.Add(this.simpleButton1);
            this.grHeader.Controls.Add(this.txtNhaCungCap);
            this.grHeader.Controls.Add(this.textEdit1);
            this.grHeader.Controls.Add(this.txtSophieu);
            this.grHeader.Controls.Add(this.labelControl12);
            this.grHeader.Controls.Add(this.labelControl2);
            this.grHeader.Controls.Add(this.labelControl8);
            this.grHeader.Controls.Add(this.labelControl1);
            this.grHeader.Controls.Add(this.lkupNhacc);
            this.grHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.grHeader.Location = new System.Drawing.Point(0, 0);
            this.grHeader.Name = "grHeader";
            this.grHeader.Size = new System.Drawing.Size(878, 76);
            this.grHeader.TabIndex = 15;
            this.grHeader.Text = "Thông tin phiếu nhập kho";
            // 
            // cboLyDoNhap
            // 
            this.cboLyDoNhap.Location = new System.Drawing.Point(489, 27);
            this.cboLyDoNhap.Name = "cboLyDoNhap";
            this.cboLyDoNhap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLyDoNhap.Properties.Items.AddRange(new object[] {
            "Nhập kho",
            "Nhập bù",
            "Khác"});
            this.cboLyDoNhap.Size = new System.Drawing.Size(100, 20);
            this.cboLyDoNhap.TabIndex = 12;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(698, 23);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(86, 23);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "Mới";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(790, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Nhập kho";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(790, 48);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 23);
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "Thoát";
            // 
            // txtNhaCungCap
            // 
            this.txtNhaCungCap.Location = new System.Drawing.Point(73, 52);
            this.txtNhaCungCap.Name = "txtNhaCungCap";
            this.txtNhaCungCap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhaCungCap.Properties.Appearance.Options.UseFont = true;
            this.txtNhaCungCap.Size = new System.Drawing.Size(516, 20);
            this.txtNhaCungCap.TabIndex = 6;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(271, 27);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(137, 20);
            this.textEdit1.TabIndex = 6;
            // 
            // txtSophieu
            // 
            this.txtSophieu.Location = new System.Drawing.Point(69, 27);
            this.txtSophieu.Name = "txtSophieu";
            this.txtSophieu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSophieu.Properties.Appearance.Options.UseFont = true;
            this.txtSophieu.Properties.ReadOnly = true;
            this.txtSophieu.Size = new System.Drawing.Size(123, 20);
            this.txtSophieu.TabIndex = 0;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl12.Location = new System.Drawing.Point(423, 30);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(60, 13);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "Lý do nhập :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl2.Location = new System.Drawing.Point(204, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Số hóa đơn :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl8.Location = new System.Drawing.Point(10, 55);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(57, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Nhà C.cấp :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl1.Location = new System.Drawing.Point(19, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số phiếu :";
            // 
            // lkupNhacc
            // 
            this.lkupNhacc.EditValue = "";
            this.lkupNhacc.Location = new System.Drawing.Point(597, 52);
            this.lkupNhacc.Name = "lkupNhacc";
            this.lkupNhacc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupNhacc.Properties.DisplayMember = "TenNhaCungCap";
            this.lkupNhacc.Properties.NullText = "Chọn nhà cung cấp";
            this.lkupNhacc.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkupNhacc.Properties.ValueMember = "MaNhaCungCap";
            this.lkupNhacc.Properties.View = this.searchLookUpEdit1View;
            this.lkupNhacc.Size = new System.Drawing.Size(102, 20);
            this.lkupNhacc.TabIndex = 7;
            this.lkupNhacc.Visible = false;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNCC_VendorCode,
            this.colNCC_VendorName,
            this.colNCC_VendorTaxNo,
            this.colNCC_Phone,
            this.colNCC_VendorAddress});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsFind.FindNullPrompt = "Tìm nhà cung cấp...!";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem;
            this.searchLookUpEdit1View.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colNCC_VendorCode
            // 
            this.colNCC_VendorCode.Caption = "Mã";
            this.colNCC_VendorCode.FieldName = "MaNhaCungCap";
            this.colNCC_VendorCode.Name = "colNCC_VendorCode";
            // 
            // colNCC_VendorName
            // 
            this.colNCC_VendorName.Caption = "Tên nhà cung cấp";
            this.colNCC_VendorName.FieldName = "TenNhaCungCap";
            this.colNCC_VendorName.Name = "colNCC_VendorName";
            this.colNCC_VendorName.Visible = true;
            this.colNCC_VendorName.VisibleIndex = 0;
            // 
            // colNCC_VendorTaxNo
            // 
            this.colNCC_VendorTaxNo.Caption = "Mã số thuế";
            this.colNCC_VendorTaxNo.FieldName = "VendorTaxNo";
            this.colNCC_VendorTaxNo.Name = "colNCC_VendorTaxNo";
            // 
            // colNCC_Phone
            // 
            this.colNCC_Phone.Caption = "Điện thoại";
            this.colNCC_Phone.FieldName = "Phone";
            this.colNCC_Phone.Name = "colNCC_Phone";
            // 
            // colNCC_VendorAddress
            // 
            this.colNCC_VendorAddress.Caption = "Địa chỉ";
            this.colNCC_VendorAddress.FieldName = "Address";
            this.colNCC_VendorAddress.Name = "colNCC_VendorAddress";
            this.colNCC_VendorAddress.Visible = true;
            this.colNCC_VendorAddress.VisibleIndex = 1;
            // 
            // FrmNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 461);
            this.Controls.Add(this.grDetails);
            this.Controls.Add(this.grHeader);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.Name = "FrmNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNhapKho";
            this.Load += new System.EventHandler(this.FrmNhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grDetails)).EndInit();
            this.grDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearch_VatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchView_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_UoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_view_UoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grHeader)).EndInit();
            this.grHeader.ResumeLayout(false);
            this.grHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLyDoNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhaCungCap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSophieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhacc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grDetails;
        private DevExpress.XtraGrid.GridControl gridControl_Detail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaPhieuNhap;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaVatTu;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearch_VatTu;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchView_Item;
        private DevExpress.XtraGrid.Columns.GridColumn repSearch_MaVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn repSearch_TenVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn repSearch_DongGoi;
        private DevExpress.XtraGrid.Columns.GridColumn repSearch_DonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn repSearch_SoLuongQuyDoi;
        private DevExpress.XtraGrid.Columns.GridColumn col_DongGoi;
        private DevExpress.XtraGrid.Columns.GridColumn col_SLQuyDoi;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoLuongNhap;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ref_UoM;
        private DevExpress.XtraGrid.Views.Grid.GridView ref_view_UoM;
        private DevExpress.XtraGrid.Columns.GridColumn view_UoM_Code;
        private DevExpress.XtraGrid.Columns.GridColumn view_UoM_Name;
        private DevExpress.XtraEditors.GroupControl grHeader;
        private DevExpress.XtraEditors.TextEdit txtSophieu;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lkupNhacc;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colNCC_VendorCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNCC_VendorName;
        private DevExpress.XtraGrid.Columns.GridColumn colNCC_VendorTaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn colNCC_Phone;
        private DevExpress.XtraGrid.Columns.GridColumn colNCC_VendorAddress;
        private DevExpress.XtraEditors.ComboBoxEdit cboLyDoNhap;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn col_DonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoLoVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn col_HanSuDung;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.TextEdit txtNhaCungCap;
    }
}