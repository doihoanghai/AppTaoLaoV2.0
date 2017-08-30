namespace BioNetSangLocSoSinh
{
    partial class XtraForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraForm2));
            this.gridControl_Vendor = new DevExpress.XtraGrid.GridControl();
            this.gridView_Vendor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_VendorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_VendorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_VendorTaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Salesman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_VendorFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_VendorBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Vendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Vendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Vendor
            // 
            this.gridControl_Vendor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl_Vendor.Location = new System.Drawing.Point(2, 62);
            this.gridControl_Vendor.MainView = this.gridView_Vendor;
            this.gridControl_Vendor.Name = "gridControl_Vendor";
            this.gridControl_Vendor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.refStatus});
            this.gridControl_Vendor.Size = new System.Drawing.Size(1090, 407);
            this.gridControl_Vendor.TabIndex = 0;
            this.gridControl_Vendor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Vendor});
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
            this.col_VendorTaxNo,
            this.col_Salesman,
            this.col_Address,
            this.col_Phone,
            this.col_Email,
            this.col_Status,
            this.col_VendorFax,
            this.col_VendorBankName});
            this.gridView_Vendor.GridControl = this.gridControl_Vendor;
            this.gridView_Vendor.Name = "gridView_Vendor";
            this.gridView_Vendor.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Nhà cung cấp).";
            this.gridView_Vendor.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Vendor.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Vendor.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Vendor.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Vendor.OptionsView.ShowFooter = true;
            this.gridView_Vendor.OptionsView.ShowGroupPanel = false;
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
            // col_VendorTaxNo
            // 
            this.col_VendorTaxNo.Caption = "Mã số thuế";
            this.col_VendorTaxNo.FieldName = "VendorTaxNo";
            this.col_VendorTaxNo.Name = "col_VendorTaxNo";
            this.col_VendorTaxNo.Visible = true;
            this.col_VendorTaxNo.VisibleIndex = 1;
            this.col_VendorTaxNo.Width = 80;
            // 
            // col_Salesman
            // 
            this.col_Salesman.Caption = "Người đại diện";
            this.col_Salesman.FieldName = "Salesman";
            this.col_Salesman.Name = "col_Salesman";
            this.col_Salesman.Visible = true;
            this.col_Salesman.VisibleIndex = 2;
            this.col_Salesman.Width = 88;
            // 
            // col_Address
            // 
            this.col_Address.Caption = "Địa chỉ";
            this.col_Address.FieldName = "Address";
            this.col_Address.Name = "col_Address";
            this.col_Address.Visible = true;
            this.col_Address.VisibleIndex = 3;
            this.col_Address.Width = 157;
            // 
            // col_Phone
            // 
            this.col_Phone.Caption = "Điện thoại";
            this.col_Phone.FieldName = "Phone";
            this.col_Phone.Name = "col_Phone";
            this.col_Phone.OptionsColumn.AllowSize = false;
            this.col_Phone.Visible = true;
            this.col_Phone.VisibleIndex = 4;
            this.col_Phone.Width = 79;
            // 
            // col_Email
            // 
            this.col_Email.Caption = "Email";
            this.col_Email.FieldName = "Email";
            this.col_Email.Name = "col_Email";
            this.col_Email.OptionsColumn.AllowSize = false;
            this.col_Email.Visible = true;
            this.col_Email.VisibleIndex = 6;
            this.col_Email.Width = 103;
            // 
            // col_Status
            // 
            this.col_Status.AppearanceCell.Options.UseTextOptions = true;
            this.col_Status.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Status.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Status.Caption = "Khóa";
            this.col_Status.ColumnEdit = this.refStatus;
            this.col_Status.FieldName = "Status";
            this.col_Status.Name = "col_Status";
            this.col_Status.OptionsColumn.AllowSize = false;
            this.col_Status.Visible = true;
            this.col_Status.VisibleIndex = 8;
            this.col_Status.Width = 42;
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
            // col_VendorFax
            // 
            this.col_VendorFax.Caption = "Số Fax";
            this.col_VendorFax.FieldName = "VendorFax";
            this.col_VendorFax.Name = "col_VendorFax";
            this.col_VendorFax.Visible = true;
            this.col_VendorFax.VisibleIndex = 5;
            this.col_VendorFax.Width = 76;
            // 
            // col_VendorBankName
            // 
            this.col_VendorBankName.Caption = "Số TK & Ngân hàng";
            this.col_VendorBankName.FieldName = "VendorBankName";
            this.col_VendorBankName.Name = "col_VendorBankName";
            this.col_VendorBankName.Visible = true;
            this.col_VendorBankName.VisibleIndex = 7;
            this.col_VendorBankName.Width = 123;
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.button1);
            this.grMain.Controls.Add(this.gridControl_Vendor);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(1094, 471);
            this.grMain.TabIndex = 1;
            this.grMain.Text = "Danh sách nhà cung cấp";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // XtraForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 471);
            this.Controls.Add(this.grMain);
            this.Name = "XtraForm2";
            this.Text = "XtraForm2";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Vendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Vendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Vendor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Vendor;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorName;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorTaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn col_Salesman;
        private DevExpress.XtraGrid.Columns.GridColumn col_Address;
        private DevExpress.XtraGrid.Columns.GridColumn col_Phone;
        private DevExpress.XtraGrid.Columns.GridColumn col_Email;
        private DevExpress.XtraGrid.Columns.GridColumn col_Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit refStatus;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorFax;
        private DevExpress.XtraGrid.Columns.GridColumn col_VendorBankName;
        private DevExpress.XtraEditors.GroupControl grMain;
        private System.Windows.Forms.Button button1;
    }
}