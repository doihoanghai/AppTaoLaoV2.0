namespace BioNetSangLocSoSinh.Entry
{
    partial class frmNhaCungCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhaCungCap));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Vendor = new DevExpress.XtraGrid.GridControl();
            this.gridView_Vendor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_VendorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_VendorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_VendorAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_VendorPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Vendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Vendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_Vendor);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(921, 482);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh sách nhà cung cấp";
            // 
            // gridControl_Vendor
            // 
            this.gridControl_Vendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Vendor.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Vendor.MainView = this.gridView_Vendor;
            this.gridControl_Vendor.Name = "gridControl_Vendor";
            this.gridControl_Vendor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refStatus});
            this.gridControl_Vendor.Size = new System.Drawing.Size(917, 457);
            this.gridControl_Vendor.TabIndex = 0;
            this.gridControl_Vendor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Vendor});
            this.gridControl_Vendor.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Vendor_ProcessGridKey);
            // 
            // gridView_Vendor
            // 
            this.gridView_Vendor.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Vendor.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Vendor.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Vendor.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Vendor.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Vendor.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Vendor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_VendorCode,
            this.col_VendorName,
            this.col_VendorAddress,
            this.col_VendorPhone});
            this.gridView_Vendor.GridControl = this.gridControl_Vendor;
            this.gridView_Vendor.Name = "gridView_Vendor";
            this.gridView_Vendor.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Nhà cung cấp).";
            this.gridView_Vendor.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Vendor.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Vendor.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Vendor.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Vendor.OptionsView.ShowFooter = true;
            this.gridView_Vendor.OptionsView.ShowGroupPanel = false;
            this.gridView_Vendor.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Vendor_InvalidRowException);
            this.gridView_Vendor.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Vendor_ValidateRow);
            // 
            // col_VendorCode
            // 
            this.col_VendorCode.AppearanceCell.Options.UseTextOptions = true;
            this.col_VendorCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_VendorCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_VendorCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_VendorCode.Caption = "Mã NCC";
            this.col_VendorCode.FieldName = "VendorCode";
            this.col_VendorCode.Name = "col_VendorCode";
            this.col_VendorCode.OptionsColumn.AllowEdit = false;
            this.col_VendorCode.OptionsColumn.AllowSize = false;
            this.col_VendorCode.Width = 96;
            // 
            // col_VendorName
            // 
            this.col_VendorName.Caption = "Tên nhà cung cấp";
            this.col_VendorName.FieldName = "VendorName";
            this.col_VendorName.Name = "col_VendorName";
            this.col_VendorName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "VendorCode", "Count: {0:#,#}")});
            this.col_VendorName.Visible = true;
            this.col_VendorName.VisibleIndex = 0;
            this.col_VendorName.Width = 153;
            // 
            // col_VendorAddress
            // 
            this.col_VendorAddress.Caption = "Địa chỉ";
            this.col_VendorAddress.FieldName = "VendorTaxNo";
            this.col_VendorAddress.Name = "col_VendorAddress";
            this.col_VendorAddress.Visible = true;
            this.col_VendorAddress.VisibleIndex = 1;
            this.col_VendorAddress.Width = 80;
            // 
            // refStatus
            // 
            this.refStatus.AutoHeight = false;
            this.refStatus.DisplayValueChecked = "1";
            this.refStatus.DisplayValueGrayed = "0";
            this.refStatus.DisplayValueUnchecked = "0";
            this.refStatus.Name = "refStatus";
            this.refStatus.ValueChecked = 1;
            this.refStatus.ValueGrayed = 0;
            this.refStatus.ValueUnchecked = 0;
            // 
            // col_VendorPhone
            // 
            this.col_VendorPhone.Caption = "Số điện thoại";
            this.col_VendorPhone.Name = "col_VendorPhone";
            this.col_VendorPhone.Visible = true;
            this.col_VendorPhone.VisibleIndex = 2;
            // 
            // frmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 482);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhaCungCap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách nhà cung cấp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Vendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Vendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Vendor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Vendor;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit refStatus;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorPhone;
    }
}