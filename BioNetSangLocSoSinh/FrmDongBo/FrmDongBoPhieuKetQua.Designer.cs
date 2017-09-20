namespace BioNetSangLocSoSinh.FrmDongBo
{
    partial class FrmDongBoPhieuKetQua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDongBoPhieuKetQua));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtDonVi = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TenDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaDVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckkTatCa = new System.Windows.Forms.CheckBox();
            this.bttGuiMail = new DevExpress.XtraEditors.SimpleButton();
            this.dllNgay = new UserControlDate.dllNgay();
            this.txtChiCuc = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TenChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaChiCuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiCuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txtDonVi);
            this.panelControl1.Controls.Add(this.ckkTatCa);
            this.panelControl1.Controls.Add(this.bttGuiMail);
            this.panelControl1.Controls.Add(this.dllNgay);
            this.panelControl1.Controls.Add(this.txtChiCuc);
            this.panelControl1.Controls.Add(this.butOK);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1261, 110);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 110);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1261, 613);
            this.panelControl2.TabIndex = 1;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(529, 41);
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
            this.txtDonVi.Properties.View = this.gridView2;
            this.txtDonVi.Size = new System.Drawing.Size(313, 22);
            this.txtDonVi.TabIndex = 1077;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TenDVCS,
            this.MaDVCS});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // TenDVCS
            // 
            this.TenDVCS.Caption = "Đơn Vị Cơ Sở";
            this.TenDVCS.FieldName = "TenDVCS";
            this.TenDVCS.Name = "TenDVCS";
            this.TenDVCS.Visible = true;
            this.TenDVCS.VisibleIndex = 0;
            // 
            // MaDVCS
            // 
            this.MaDVCS.Caption = "Mã Đơn Vị Cơ Sở";
            this.MaDVCS.FieldName = "MaDVCS";
            this.MaDVCS.Name = "MaDVCS";
            // 
            // ckkTatCa
            // 
            this.ckkTatCa.AutoSize = true;
            this.ckkTatCa.Location = new System.Drawing.Point(886, 30);
            this.ckkTatCa.Name = "ckkTatCa";
            this.ckkTatCa.Size = new System.Drawing.Size(107, 21);
            this.ckkTatCa.TabIndex = 1076;
            this.ckkTatCa.Text = "Chọn Tất Cả";
            this.ckkTatCa.UseVisualStyleBackColor = true;
            // 
            // bttGuiMail
            // 
            this.bttGuiMail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.bttGuiMail.Location = new System.Drawing.Point(1041, 58);
            this.bttGuiMail.Name = "bttGuiMail";
            this.bttGuiMail.Size = new System.Drawing.Size(177, 39);
            this.bttGuiMail.TabIndex = 1075;
            this.bttGuiMail.Text = "Gửi Mail";
            // 
            // dllNgay
            // 
            this.dllNgay.BackColor = System.Drawing.Color.Transparent;
            this.dllNgay.Location = new System.Drawing.Point(12, 7);
            this.dllNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dllNgay.Name = "dllNgay";
            this.dllNgay.Size = new System.Drawing.Size(374, 90);
            this.dllNgay.TabIndex = 1074;
            // 
            // txtChiCuc
            // 
            this.txtChiCuc.Location = new System.Drawing.Point(529, 13);
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
            this.txtChiCuc.Size = new System.Drawing.Size(313, 22);
            this.txtChiCuc.TabIndex = 1073;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TenChiCuc,
            this.MaChiCuc});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // TenChiCuc
            // 
            this.TenChiCuc.Caption = "Chi Cục";
            this.TenChiCuc.FieldName = "TenChiCuc";
            this.TenChiCuc.Name = "TenChiCuc";
            this.TenChiCuc.Visible = true;
            this.TenChiCuc.VisibleIndex = 0;
            // 
            // MaChiCuc
            // 
            this.MaChiCuc.Caption = "Mã Chi Cục";
            this.MaChiCuc.Name = "MaChiCuc";
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(1041, 9);
            this.butOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(177, 42);
            this.butOK.TabIndex = 1072;
            this.butOK.Text = "Lấy số liệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 1071;
            this.label4.Text = "Đơn Vị";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 1070;
            this.label3.Text = "Chi Cục";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 1078;
            this.label1.Text = "Mã Phiếu Cần Tìm:";
            // 
            // FrmDongBoPhieuKetQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 723);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDongBoPhieuKetQua";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiCuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SearchLookUpEdit txtDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn TenDVCS;
        private DevExpress.XtraGrid.Columns.GridColumn MaDVCS;
        private System.Windows.Forms.CheckBox ckkTatCa;
        private DevExpress.XtraEditors.SimpleButton bttGuiMail;
        private UserControlDate.dllNgay dllNgay;
        private DevExpress.XtraEditors.SearchLookUpEdit txtChiCuc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn TenChiCuc;
        private DevExpress.XtraGrid.Columns.GridColumn MaChiCuc;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}