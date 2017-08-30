namespace BioNetSangLocSoSinh.Entry
{
    partial class FrmPhanQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhanQuyen));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeEmployee = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ttUser_Refresh = new System.Windows.Forms.ToolStripButton();
            this.txtTim = new System.Windows.Forms.ToolStripTextBox();
            this.butTim = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblTotalMenu = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.rdoApplyToDefault = new System.Windows.Forms.RadioButton();
            this.rdoApplyForEmp = new System.Windows.Forms.RadioButton();
            this.rdoDefault = new System.Windows.Forms.RadioButton();
            this.treeAuthor = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.butQuyen_All = new System.Windows.Forms.ToolStripButton();
            this.lbQuyen = new System.Windows.Forms.ToolStripLabel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panel2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1542, 597);
            this.splitContainerControl1.SplitterPosition = 405;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.treeEmployee);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panel1.Size = new System.Drawing.Size(405, 597);
            this.panel1.TabIndex = 15;
            // 
            // treeEmployee
            // 
            this.treeEmployee.BackColor = System.Drawing.Color.MintCream;
            this.treeEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeEmployee.Location = new System.Drawing.Point(1, 29);
            this.treeEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeEmployee.Name = "treeEmployee";
            this.treeEmployee.Size = new System.Drawing.Size(399, 563);
            this.treeEmployee.TabIndex = 18;
            this.treeEmployee.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeEmployee_BeforeSelect);
            this.treeEmployee.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeEmployee_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ttUser_Refresh,
            this.txtTim,
            this.butTim});
            this.toolStrip1.Location = new System.Drawing.Point(1, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(399, 27);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(110, 24);
            this.toolStripLabel1.Text = "Người dùng";
            // 
            // ttUser_Refresh
            // 
            this.ttUser_Refresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ttUser_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ttUser_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttUser_Refresh.Name = "ttUser_Refresh";
            this.ttUser_Refresh.Size = new System.Drawing.Size(23, 24);
            this.ttUser_Refresh.Text = "Nạp lại danh sách";
            this.ttUser_Refresh.ToolTipText = "Nạp lại danh sách người sử dụng";
            // 
            // txtTim
            // 
            this.txtTim.AutoSize = false;
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(139, 27);
            this.txtTim.Enter += new System.EventHandler(this.txtTim_Enter);
            // 
            // butTim
            // 
            this.butTim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(24, 24);
            this.butTim.Text = "Tìm người dùng";
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(399, 2);
            this.label4.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panelControl1);
            this.panel2.Controls.Add(this.treeAuthor);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panel2.Size = new System.Drawing.Size(1131, 597);
            this.panel2.TabIndex = 16;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblTotalMenu);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.rdoApplyToDefault);
            this.panelControl1.Controls.Add(this.rdoApplyForEmp);
            this.panelControl1.Controls.Add(this.rdoDefault);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(1, 546);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1125, 46);
            this.panelControl1.TabIndex = 16;
            // 
            // lblTotalMenu
            // 
            this.lblTotalMenu.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalMenu.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblTotalMenu.Location = new System.Drawing.Point(17, 16);
            this.lblTotalMenu.Name = "lblTotalMenu";
            this.lblTotalMenu.Size = new System.Drawing.Size(63, 18);
            this.lblTotalMenu.TabIndex = 4;
            this.lblTotalMenu.Text = "(12/85)";
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSave.Image = global::BioNetSangLocSoSinh.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(849, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rdoApplyToDefault
            // 
            this.rdoApplyToDefault.AutoSize = true;
            this.rdoApplyToDefault.Enabled = false;
            this.rdoApplyToDefault.Location = new System.Drawing.Point(596, 16);
            this.rdoApplyToDefault.Name = "rdoApplyToDefault";
            this.rdoApplyToDefault.Size = new System.Drawing.Size(210, 21);
            this.rdoApplyToDefault.TabIndex = 2;
            this.rdoApplyToDefault.TabStop = true;
            this.rdoApplyToDefault.Text = "Tất cả nhân viên về mặc định";
            this.rdoApplyToDefault.UseVisualStyleBackColor = true;
            // 
            // rdoApplyForEmp
            // 
            this.rdoApplyForEmp.AutoSize = true;
            this.rdoApplyForEmp.Enabled = false;
            this.rdoApplyForEmp.Location = new System.Drawing.Point(359, 16);
            this.rdoApplyForEmp.Name = "rdoApplyForEmp";
            this.rdoApplyForEmp.Size = new System.Drawing.Size(208, 21);
            this.rdoApplyForEmp.TabIndex = 1;
            this.rdoApplyForEmp.TabStop = true;
            this.rdoApplyForEmp.Text = "Áp dụng thêm cho nhân viên";
            this.rdoApplyForEmp.UseVisualStyleBackColor = true;
            // 
            // rdoDefault
            // 
            this.rdoDefault.AutoSize = true;
            this.rdoDefault.Enabled = false;
            this.rdoDefault.Location = new System.Drawing.Point(151, 16);
            this.rdoDefault.Name = "rdoDefault";
            this.rdoDefault.Size = new System.Drawing.Size(182, 21);
            this.rdoDefault.TabIndex = 0;
            this.rdoDefault.TabStop = true;
            this.rdoDefault.Text = "Làm mặc định cho nhóm";
            this.rdoDefault.UseVisualStyleBackColor = true;
            // 
            // treeAuthor
            // 
            this.treeAuthor.BackColor = System.Drawing.Color.MintCream;
            this.treeAuthor.CheckBoxes = true;
            this.treeAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAuthor.Location = new System.Drawing.Point(1, 29);
            this.treeAuthor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeAuthor.Name = "treeAuthor";
            this.treeAuthor.Size = new System.Drawing.Size(1125, 563);
            this.treeAuthor.TabIndex = 2;
            this.treeAuthor.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeAuthor_AfterCheck);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butQuyen_All,
            this.lbQuyen});
            this.toolStrip2.Location = new System.Drawing.Point(1, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1125, 27);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // butQuyen_All
            // 
            this.butQuyen_All.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butQuyen_All.Image = ((System.Drawing.Image)(resources.GetObject("butQuyen_All.Image")));
            this.butQuyen_All.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butQuyen_All.Name = "butQuyen_All";
            this.butQuyen_All.Size = new System.Drawing.Size(24, 24);
            this.butQuyen_All.Text = "Chọn tất cả";
            this.butQuyen_All.Click += new System.EventHandler(this.butQuyen_All_Click);
            // 
            // lbQuyen
            // 
            this.lbQuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbQuyen.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbQuyen.Name = "lbQuyen";
            this.lbQuyen.Size = new System.Drawing.Size(144, 24);
            this.lbQuyen.Text = "Chức năng sử dụng";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1125, 2);
            this.label3.TabIndex = 15;
            // 
            // FrmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 597);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPhanQuyen";
            this.Text = "FrmPhanQuyen";
            this.Load += new System.EventHandler(this.FrmPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeEmployee;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton ttUser_Refresh;
        private System.Windows.Forms.ToolStripTextBox txtTim;
        private System.Windows.Forms.ToolStripButton butTim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeAuthor;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton butQuyen_All;
        private System.Windows.Forms.ToolStripLabel lbQuyen;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.RadioButton rdoApplyToDefault;
        private System.Windows.Forms.RadioButton rdoApplyForEmp;
        private System.Windows.Forms.RadioButton rdoDefault;
        private DevExpress.XtraEditors.LabelControl lblTotalMenu;
    }
}