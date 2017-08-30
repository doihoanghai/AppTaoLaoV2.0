namespace BioNetSangLocSoSinh.DiaglogFrm
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.butExit = new DevExpress.XtraEditors.SimpleButton();
            this.butConnect = new DevExpress.XtraEditors.SimpleButton();
            this.cbxServerName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtDataBaseName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbServerName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBaseName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.ForeColor = System.Drawing.Color.DarkCyan;
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.AppearanceCaption.Options.UseForeColor = true;
            this.grMain.Controls.Add(this.butExit);
            this.grMain.Controls.Add(this.butConnect);
            this.grMain.Controls.Add(this.cbxServerName);
            this.grMain.Controls.Add(this.txtPassword);
            this.grMain.Controls.Add(this.txtUserName);
            this.grMain.Controls.Add(this.txtDataBaseName);
            this.grMain.Controls.Add(this.labelControl7);
            this.grMain.Controls.Add(this.labelControl6);
            this.grMain.Controls.Add(this.labelControl3);
            this.grMain.Controls.Add(this.labelControl1);
            this.grMain.Controls.Add(this.labelControl5);
            this.grMain.Controls.Add(this.labelControl4);
            this.grMain.Controls.Add(this.labelControl2);
            this.grMain.Controls.Add(this.lbServerName);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Margin = new System.Windows.Forms.Padding(2);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(412, 187);
            this.grMain.TabIndex = 2;
            this.grMain.Text = "Thông tin kết nối";
            // 
            // butExit
            // 
            this.butExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.Location = new System.Drawing.Point(268, 146);
            this.butExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(129, 31);
            this.butExit.TabIndex = 5;
            this.butExit.Text = "Thoát";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butConnect
            // 
            this.butConnect.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butConnect.Image = ((System.Drawing.Image)(resources.GetObject("butConnect.Image")));
            this.butConnect.Location = new System.Drawing.Point(134, 146);
            this.butConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(127, 31);
            this.butConnect.TabIndex = 4;
            this.butConnect.Text = "Kết Nối";
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // cbxServerName
            // 
            this.cbxServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxServerName.Location = new System.Drawing.Point(134, 31);
            this.cbxServerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxServerName.Name = "cbxServerName";
            this.cbxServerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxServerName.Size = new System.Drawing.Size(264, 22);
            this.cbxServerName.TabIndex = 0;
            this.cbxServerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxServerName_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(134, 112);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(264, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(134, 85);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(264, 22);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataBaseName.Location = new System.Drawing.Point(134, 58);
            this.txtDataBaseName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(264, 22);
            this.txtDataBaseName.TabIndex = 1;
            this.txtDataBaseName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataBaseName_KeyDown);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(121, 113);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(6, 19);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = ":";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(121, 86);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(6, 19);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = ":";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(121, 59);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(6, 19);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = ":";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(121, 32);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(6, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = ":";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(50, 113);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 19);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Password";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(41, 86);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(78, 19);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "User Name";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(9, 59);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(110, 19);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Database Name";
            // 
            // lbServerName
            // 
            this.lbServerName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServerName.Location = new System.Drawing.Point(27, 32);
            this.lbServerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbServerName.Name = "lbServerName";
            this.lbServerName.Size = new System.Drawing.Size(91, 19);
            this.lbServerName.TabIndex = 0;
            this.lbServerName.Text = "Server Name";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 187);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết Nối Server";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            this.grMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBaseName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraEditors.SimpleButton butExit;
        private DevExpress.XtraEditors.SimpleButton butConnect;
        private DevExpress.XtraEditors.ComboBoxEdit cbxServerName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtDataBaseName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbServerName;
    }
}