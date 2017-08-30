namespace BioNetSangLocSoSinh.DiaglogFrm
{
    partial class FrmDiaglogAddKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiaglogAddKey));
            this.txtLicense = new DevExpress.XtraEditors.MemoEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddKey = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicense.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(5, 29);
            this.txtLicense.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(474, 103);
            this.txtLicense.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(392, 140);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 28);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddKey
            // 
            this.btnAddKey.Image = ((System.Drawing.Image)(resources.GetObject("btnAddKey.Image")));
            this.btnAddKey.Location = new System.Drawing.Point(298, 140);
            this.btnAddKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.Size = new System.Drawing.Size(87, 28);
            this.btnAddKey.TabIndex = 1;
            this.btnAddKey.Text = "Kích hoạt";
            this.btnAddKey.Click += new System.EventHandler(this.btnAddKey_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.txtLicense);
            this.groupControl1.Controls.Add(this.btnAddKey);
            this.groupControl1.Controls.Add(this.btnExit);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(488, 179);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Kích hoạt bản quyền";
            // 
            // FrmDiaglogAddKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 179);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDiaglogAddKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kích hoạt bản quyền";
            ((System.ComponentModel.ISupportInitialize)(this.txtLicense.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtLicense;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnAddKey;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}