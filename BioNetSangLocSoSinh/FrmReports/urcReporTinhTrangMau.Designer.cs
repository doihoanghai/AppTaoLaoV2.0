namespace BioNetSangLocSoSinh.FrmReports
{
    partial class urcReporTinhTrangMau
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urcReporTinhTrangMau));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_idChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtChiCuc = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.PanelSingle = new DevExpress.XtraEditors.XtraScrollableControl();
            this.GC_DanhSachPhieu = new DevExpress.XtraGrid.GridControl();
            this.GV_DanhSachPhieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_IDPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpDonVi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_TenBenhNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NamSinhMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NgayNhanMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_TinhTrangMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaBenhNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TrangThaiMau_Text = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dllNgay = new UserControlDate.dllNgay();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txtDonVi = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiCuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.PanelSingle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GC_DanhSachPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_DanhSachPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_idChiCuc,
            this.col_TenChiCuc});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowColumnHeaders = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // col_idChiCuc
            // 
            this.col_idChiCuc.Caption = "Mã";
            this.col_idChiCuc.FieldName = "MaChiCuc";
            this.col_idChiCuc.Name = "col_idChiCuc";
            // 
            // col_TenChiCuc
            // 
            this.col_TenChiCuc.Caption = "ChiCuc";
            this.col_TenChiCuc.FieldName = "TenChiCuc";
            this.col_TenChiCuc.Name = "col_TenChiCuc";
            this.col_TenChiCuc.Visible = true;
            this.col_TenChiCuc.VisibleIndex = 0;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(360, 10);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(54, 17);
            this.labelControl9.TabIndex = 1058;
            this.labelControl9.Text = "Chi cục :";
            // 
            // txtChiCuc
            // 
            this.txtChiCuc.Location = new System.Drawing.Point(413, 6);
            this.txtChiCuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChiCuc.Name = "txtChiCuc";
            this.txtChiCuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtChiCuc.Properties.DisplayMember = "TenChiCuc";
            this.txtChiCuc.Properties.NullText = "Chọn";
            this.txtChiCuc.Properties.PopupFormMinSize = new System.Drawing.Size(350, 350);
            this.txtChiCuc.Properties.PopupFormSize = new System.Drawing.Size(270, 300);
            this.txtChiCuc.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.txtChiCuc.Properties.ShowFooter = false;
            this.txtChiCuc.Properties.ValueMember = "MaChiCuc";
            this.txtChiCuc.Properties.View = this.gridView2;
            this.txtChiCuc.Size = new System.Drawing.Size(204, 22);
            this.txtChiCuc.TabIndex = 1059;
            this.txtChiCuc.EditValueChanged += new System.EventHandler(this.txtChiCuc_EditValueChanged);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 20);
            // 
            // PanelSingle
            // 
            this.PanelSingle.Controls.Add(this.GC_DanhSachPhieu);
            this.PanelSingle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSingle.Location = new System.Drawing.Point(0, 0);
            this.PanelSingle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelSingle.Name = "PanelSingle";
            this.PanelSingle.Size = new System.Drawing.Size(1077, 376);
            this.PanelSingle.TabIndex = 5;
            // 
            // GC_DanhSachPhieu
            // 
            this.GC_DanhSachPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GC_DanhSachPhieu.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GC_DanhSachPhieu.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.GC_DanhSachPhieu.Location = new System.Drawing.Point(0, 0);
            this.GC_DanhSachPhieu.MainView = this.GV_DanhSachPhieu;
            this.GC_DanhSachPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GC_DanhSachPhieu.Name = "GC_DanhSachPhieu";
            this.GC_DanhSachPhieu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpDonVi});
            this.GC_DanhSachPhieu.Size = new System.Drawing.Size(1077, 376);
            this.GC_DanhSachPhieu.TabIndex = 0;
            this.GC_DanhSachPhieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GV_DanhSachPhieu});
            // 
            // GV_DanhSachPhieu
            // 
            this.GV_DanhSachPhieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_IDPhieu,
            this.col_MaDonVi,
            this.col_TenBenhNhan,
            this.col_TenMe,
            this.col_NamSinhMe,
            this.col_DiaChi,
            this.col_NgayNhanMau,
            this.Col_TinhTrangMau,
            this.col_MaBenhNhan,
            this.col_TenDonVi,
            this.col_TrangThaiMau_Text});
            this.GV_DanhSachPhieu.GridControl = this.GC_DanhSachPhieu;
            this.GV_DanhSachPhieu.GroupPanelText = "Kéo cột vào đây để nhóm lại";
            this.GV_DanhSachPhieu.Name = "GV_DanhSachPhieu";
            this.GV_DanhSachPhieu.OptionsView.ColumnAutoWidth = false;
            this.GV_DanhSachPhieu.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GV_DanhSachPhieu_RowCellStyle);
            // 
            // col_IDPhieu
            // 
            this.col_IDPhieu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_IDPhieu.AppearanceHeader.Options.UseFont = true;
            this.col_IDPhieu.Caption = "Mã Phiếu";
            this.col_IDPhieu.FieldName = "IDPhieu";
            this.col_IDPhieu.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_IDPhieu.Name = "col_IDPhieu";
            this.col_IDPhieu.Visible = true;
            this.col_IDPhieu.VisibleIndex = 1;
            // 
            // col_MaDonVi
            // 
            this.col_MaDonVi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_MaDonVi.AppearanceHeader.Options.UseFont = true;
            this.col_MaDonVi.Caption = "Đơn vị";
            this.col_MaDonVi.ColumnEdit = this.repositoryItemLookUpDonVi;
            this.col_MaDonVi.FieldName = "IDCoSo";
            this.col_MaDonVi.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_MaDonVi.Name = "col_MaDonVi";
            this.col_MaDonVi.Width = 167;
            // 
            // repositoryItemLookUpDonVi
            // 
            this.repositoryItemLookUpDonVi.AutoHeight = false;
            this.repositoryItemLookUpDonVi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpDonVi.Name = "repositoryItemLookUpDonVi";
            // 
            // col_TenBenhNhan
            // 
            this.col_TenBenhNhan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_TenBenhNhan.AppearanceHeader.Options.UseFont = true;
            this.col_TenBenhNhan.Caption = "Bệnh nhân";
            this.col_TenBenhNhan.FieldName = "TenBenhNhan";
            this.col_TenBenhNhan.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_TenBenhNhan.Name = "col_TenBenhNhan";
            this.col_TenBenhNhan.Visible = true;
            this.col_TenBenhNhan.VisibleIndex = 2;
            this.col_TenBenhNhan.Width = 99;
            // 
            // col_TenMe
            // 
            this.col_TenMe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_TenMe.AppearanceHeader.Options.UseFont = true;
            this.col_TenMe.Caption = "Tên Mẹ";
            this.col_TenMe.FieldName = "TenMe";
            this.col_TenMe.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_TenMe.Name = "col_TenMe";
            this.col_TenMe.Visible = true;
            this.col_TenMe.VisibleIndex = 3;
            this.col_TenMe.Width = 153;
            // 
            // col_NamSinhMe
            // 
            this.col_NamSinhMe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_NamSinhMe.AppearanceHeader.Options.UseFont = true;
            this.col_NamSinhMe.Caption = "Năm sinh";
            this.col_NamSinhMe.FieldName = "NamSinhMe";
            this.col_NamSinhMe.Name = "col_NamSinhMe";
            this.col_NamSinhMe.Visible = true;
            this.col_NamSinhMe.VisibleIndex = 4;
            // 
            // col_DiaChi
            // 
            this.col_DiaChi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_DiaChi.AppearanceHeader.Options.UseFont = true;
            this.col_DiaChi.Caption = "Địa chỉ";
            this.col_DiaChi.FieldName = "DiaChi";
            this.col_DiaChi.Name = "col_DiaChi";
            this.col_DiaChi.Visible = true;
            this.col_DiaChi.VisibleIndex = 5;
            this.col_DiaChi.Width = 192;
            // 
            // col_NgayNhanMau
            // 
            this.col_NgayNhanMau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_NgayNhanMau.AppearanceHeader.Options.UseFont = true;
            this.col_NgayNhanMau.Caption = "Ngày nhận mẫu";
            this.col_NgayNhanMau.FieldName = "NgayNhanMau";
            this.col_NgayNhanMau.Name = "col_NgayNhanMau";
            this.col_NgayNhanMau.Visible = true;
            this.col_NgayNhanMau.VisibleIndex = 6;
            // 
            // Col_TinhTrangMau
            // 
            this.Col_TinhTrangMau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Col_TinhTrangMau.AppearanceHeader.Options.UseFont = true;
            this.Col_TinhTrangMau.Caption = "Tình trạng mẫu";
            this.Col_TinhTrangMau.FieldName = "TinhTrangMau";
            this.Col_TinhTrangMau.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.Col_TinhTrangMau.Name = "Col_TinhTrangMau";
            this.Col_TinhTrangMau.Width = 101;
            // 
            // col_MaBenhNhan
            // 
            this.col_MaBenhNhan.Caption = "Mã bệnh nhân";
            this.col_MaBenhNhan.FieldName = "MaBenhNhan";
            this.col_MaBenhNhan.Name = "col_MaBenhNhan";
            // 
            // col_TenDonVi
            // 
            this.col_TenDonVi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_TenDonVi.AppearanceHeader.Options.UseFont = true;
            this.col_TenDonVi.Caption = "Đơn vị";
            this.col_TenDonVi.FieldName = "TenDonVi";
            this.col_TenDonVi.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.col_TenDonVi.Name = "col_TenDonVi";
            this.col_TenDonVi.Visible = true;
            this.col_TenDonVi.VisibleIndex = 0;
            // 
            // col_TrangThaiMau_Text
            // 
            this.col_TrangThaiMau_Text.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_TrangThaiMau_Text.AppearanceHeader.Options.UseFont = true;
            this.col_TrangThaiMau_Text.Caption = "Trạng thái";
            this.col_TrangThaiMau_Text.FieldName = "TinhTrangMau_Text";
            this.col_TrangThaiMau_Text.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.col_TrangThaiMau_Text.Name = "col_TrangThaiMau_Text";
            this.col_TrangThaiMau_Text.Visible = true;
            this.col_TrangThaiMau_Text.VisibleIndex = 7;
            this.col_TrangThaiMau_Text.Width = 154;
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(0, 0);
            this.dllNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(344, 90);
            this.dllNgay.TabIndex = 1053;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.labelControl16);
            this.panelControl2.Controls.Add(this.txtDonVi);
            this.panelControl2.Controls.Add(this.labelControl9);
            this.panelControl2.Controls.Add(this.txtChiCuc);
            this.panelControl2.Controls.Add(this.butPrint);
            this.panelControl2.Controls.Add(this.butOK);
            this.panelControl2.Controls.Add(this.dllNgay);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1077, 89);
            this.panelControl2.TabIndex = 4;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(364, 42);
            this.labelControl16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(49, 17);
            this.labelControl16.TabIndex = 1060;
            this.labelControl16.Text = "Đơn vị :";
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(413, 38);
            this.txtDonVi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDonVi.Properties.DisplayMember = "TenDVCS";
            this.txtDonVi.Properties.NullText = "Chọn";
            this.txtDonVi.Properties.PopupFormMinSize = new System.Drawing.Size(350, 350);
            this.txtDonVi.Properties.PopupFormSize = new System.Drawing.Size(270, 300);
            this.txtDonVi.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.txtDonVi.Properties.ShowFooter = false;
            this.txtDonVi.Properties.ValueMember = "MaDVCS";
            this.txtDonVi.Properties.View = this.gridView1;
            this.txtDonVi.Size = new System.Drawing.Size(204, 22);
            this.txtDonVi.TabIndex = 1061;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "MaDVCS";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Đơn vị";
            this.gridColumn2.FieldName = "TenDVCS";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(643, 49);
            this.butPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(93, 32);
            this.butPrint.TabIndex = 1055;
            this.butPrint.Text = "In";
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(643, 10);
            this.butOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(93, 32);
            this.butOK.TabIndex = 1054;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PanelSingle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 89);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 376);
            this.panel1.TabIndex = 6;
            // 
            // urcReporTinhTrangMau
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "urcReporTinhTrangMau";
            this.Size = new System.Drawing.Size(1077, 465);
            this.Load += new System.EventHandler(this.urcReportTrungTam_SoBo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiCuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.PanelSingle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GC_DanhSachPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_DanhSachPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn col_TenChiCuc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col_idChiCuc;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SearchLookUpEdit txtChiCuc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.XtraScrollableControl PanelSingle;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl GC_DanhSachPhieu;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_DanhSachPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn col_IDPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenBenhNhan;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenMe;
        private DevExpress.XtraGrid.Columns.GridColumn col_NamSinhMe;
        private DevExpress.XtraGrid.Columns.GridColumn col_DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn col_NgayNhanMau;
        private DevExpress.XtraGrid.Columns.GridColumn Col_TinhTrangMau;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.SearchLookUpEdit txtDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaBenhNhan;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn col_TrangThaiMau_Text;
    }
}
