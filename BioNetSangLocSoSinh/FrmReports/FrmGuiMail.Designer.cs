namespace BioNetSangLocSoSinh.FrmReports
{
    partial class FrmGuiMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGuiMail));
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dllNgay = new UserControlDate.dllNgay();
            this.txtChiCuc = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtDonVi = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GC_DSPhieuMail = new DevExpress.XtraGrid.GridControl();
            this.GV_DSPhieuMail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_TenChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NgayNhanMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IDPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TinhTrangMau_Text = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bttPDF = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiCuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GC_DSPhieuMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_DSPhieuMail)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.bttPDF);
            this.panelControl1.Controls.Add(this.dllNgay);
            this.panelControl1.Controls.Add(this.txtChiCuc);
            this.panelControl1.Controls.Add(this.txtDonVi);
            this.panelControl1.Controls.Add(this.butOK);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Location = new System.Drawing.Point(0, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1203, 103);
            this.panelControl1.TabIndex = 1;
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(12, 6);
            this.dllNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(363, 90);
            this.dllNgay.TabIndex = 1066;
            // 
            // txtChiCuc
            // 
            this.txtChiCuc.Location = new System.Drawing.Point(495, 25);
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
            this.txtChiCuc.Properties.View = this.gridView3;
            this.txtChiCuc.Size = new System.Drawing.Size(295, 22);
            this.txtChiCuc.TabIndex = 1065;
            this.txtChiCuc.EditValueChanged += new System.EventHandler(this.txtChiCuc_EditValueChanged);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaChiCuc,
            this.TenChiCuc});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // col_MaChiCuc
            // 
            this.col_MaChiCuc.Caption = "Mã";
            this.col_MaChiCuc.FieldName = "MaChiCuc";
            this.col_MaChiCuc.Name = "col_MaChiCuc";
            // 
            // TenChiCuc
            // 
            this.TenChiCuc.Caption = "Chi Cục";
            this.TenChiCuc.FieldName = "TenChiCuc";
            this.TenChiCuc.Name = "TenChiCuc";
            this.TenChiCuc.Visible = true;
            this.TenChiCuc.VisibleIndex = 0;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(477, 61);
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
            this.txtDonVi.Size = new System.Drawing.Size(313, 22);
            this.txtDonVi.TabIndex = 1063;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaDVCS,
            this.col_TenDVCS});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // col_MaDVCS
            // 
            this.col_MaDVCS.Caption = "Mã ";
            this.col_MaDVCS.FieldName = "MaDVCS";
            this.col_MaDVCS.Name = "col_MaDVCS";
            // 
            // col_TenDVCS
            // 
            this.col_TenDVCS.Caption = "Tên Đơn Vị Cơ Sở";
            this.col_TenDVCS.FieldName = "TenDVCS";
            this.col_TenDVCS.Name = "col_TenDVCS";
            this.col_TenDVCS.Visible = true;
            this.col_TenDVCS.VisibleIndex = 0;
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(844, 15);
            this.butOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(177, 32);
            this.butOK.TabIndex = 1055;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đơn Vị";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chi Cục";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Name = "gridColumn2";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GC_DSPhieuMail);
            this.panel1.Location = new System.Drawing.Point(0, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 474);
            this.panel1.TabIndex = 2;
            // 
            // GC_DSPhieuMail
            // 
            this.GC_DSPhieuMail.Location = new System.Drawing.Point(3, 3);
            this.GC_DSPhieuMail.MainView = this.GV_DSPhieuMail;
            this.GC_DSPhieuMail.Name = "GC_DSPhieuMail";
            this.GC_DSPhieuMail.Size = new System.Drawing.Size(1197, 471);
            this.GC_DSPhieuMail.TabIndex = 0;
            this.GC_DSPhieuMail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GV_DSPhieuMail});
            // 
            // GV_DSPhieuMail
            // 
            this.GV_DSPhieuMail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_TenChiCuc,
            this.col_TenDonVi,
            this.col_Email,
            this.col_NgayNhanMau,
            this.col_IDPhieu,
            this.col_TinhTrangMau_Text,
            this.Col_Chon});
            this.GV_DSPhieuMail.GridControl = this.GC_DSPhieuMail;
            this.GV_DSPhieuMail.Name = "GV_DSPhieuMail";
            // 
            // col_TenChiCuc
            // 
            this.col_TenChiCuc.Caption = "Chi Cục";
            this.col_TenChiCuc.FieldName = "TenChiCuc";
            this.col_TenChiCuc.Name = "col_TenChiCuc";
            this.col_TenChiCuc.Visible = true;
            this.col_TenChiCuc.VisibleIndex = 0;
            // 
            // col_TenDonVi
            // 
            this.col_TenDonVi.Caption = "Đơn Vị";
            this.col_TenDonVi.FieldName = "TenDonVi";
            this.col_TenDonVi.Name = "col_TenDonVi";
            this.col_TenDonVi.Visible = true;
            this.col_TenDonVi.VisibleIndex = 1;
            // 
            // col_Email
            // 
            this.col_Email.Caption = "Email";
            this.col_Email.FieldName = "Email";
            this.col_Email.Name = "col_Email";
            this.col_Email.Visible = true;
            this.col_Email.VisibleIndex = 2;
            // 
            // col_NgayNhanMau
            // 
            this.col_NgayNhanMau.Caption = "Đợt Tiếp Nhận";
            this.col_NgayNhanMau.FieldName = "NgayNhanMau";
            this.col_NgayNhanMau.Name = "col_NgayNhanMau";
            this.col_NgayNhanMau.Visible = true;
            this.col_NgayNhanMau.VisibleIndex = 3;
            // 
            // col_IDPhieu
            // 
            this.col_IDPhieu.Caption = "Mã Phiếu";
            this.col_IDPhieu.FieldName = "IDPhieu";
            this.col_IDPhieu.Name = "col_IDPhieu";
            this.col_IDPhieu.Visible = true;
            this.col_IDPhieu.VisibleIndex = 4;
            // 
            // col_TinhTrangMau_Text
            // 
            this.col_TinhTrangMau_Text.Caption = "Tình Trạng Mẫu";
            this.col_TinhTrangMau_Text.FieldName = "TinhTrangMau_Text";
            this.col_TinhTrangMau_Text.Name = "col_TinhTrangMau_Text";
            this.col_TinhTrangMau_Text.Visible = true;
            this.col_TinhTrangMau_Text.VisibleIndex = 5;
            // 
            // Col_Chon
            // 
            this.Col_Chon.Caption = "Chọn";
            this.Col_Chon.ColumnEdit = this.repositoryItemCheckEdit1;
            this.Col_Chon.FieldName = "Chon";
            this.Col_Chon.Name = "Col_Chon";
            this.Col_Chon.Visible = true;
            this.Col_Chon.VisibleIndex = 6;
            // 
            // bttPDF
            // 
            this.bttPDF.Location = new System.Drawing.Point(844, 54);
            this.bttPDF.Name = "bttPDF";
            this.bttPDF.Size = new System.Drawing.Size(177, 39);
            this.bttPDF.TabIndex = 1067;
            this.bttPDF.Text = "Lưu File";
            this.bttPDF.Click += new System.EventHandler(this.bttPDF_Click);
            // 
            // FrmGuiMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 598);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmGuiMail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmGuiMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiCuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GC_DSPhieuMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_DSPhieuMail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SearchLookUpEdit txtDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
       
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl GC_DSPhieuMail;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_DSPhieuMail;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn col_Email;
        private DevExpress.XtraGrid.Columns.GridColumn col_NgayNhanMau;
        private DevExpress.XtraGrid.Columns.GridColumn col_IDPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn col_TinhTrangMau_Text;
        private DevExpress.XtraGrid.Columns.GridColumn Col_Chon;
        private DevExpress.XtraEditors.SearchLookUpEdit txtChiCuc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn TenChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaDVCS;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenDVCS;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraEditors.SimpleButton bttPDF;
    }
}