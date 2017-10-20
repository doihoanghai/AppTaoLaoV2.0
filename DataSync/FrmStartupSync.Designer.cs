namespace DataSync
{
    partial class FrmStartupSync
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnStart = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettup = new System.Windows.Forms.ToolStripMenuItem();
            this.severToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.btnDongBoDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnStart,
            this.mnuSettup,
            this.mnAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnStart
            // 
            this.mnStart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.btnDongBoDuLieu,
            this.exitToolStripMenuItem});
            this.mnStart.Name = "mnStart";
            this.mnStart.Size = new System.Drawing.Size(43, 20);
            this.mnStart.Text = "Start";
            this.mnStart.Click += new System.EventHandler(this.mnStart_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.startToolStripMenuItem.Text = "Đồng Bộ Danh Mục";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mnuSettup
            // 
            this.mnuSettup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.severToolStripMenuItem});
            this.mnuSettup.Name = "mnuSettup";
            this.mnuSettup.Size = new System.Drawing.Size(49, 20);
            this.mnuSettup.Text = "Setup";
            // 
            // severToolStripMenuItem
            // 
            this.severToolStripMenuItem.Name = "severToolStripMenuItem";
            this.severToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.severToolStripMenuItem.Text = "Sever";
            this.severToolStripMenuItem.Click += new System.EventHandler(this.severToolStripMenuItem_Click);
            // 
            // mnAbout
            // 
            this.mnAbout.Name = "mnAbout";
            this.mnAbout.Size = new System.Drawing.Size(52, 20);
            this.mnAbout.Text = "About";
            // 
            // rtbStatus
            // 
            this.rtbStatus.BackColor = System.Drawing.SystemColors.ControlText;
            this.rtbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbStatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.rtbStatus.Location = new System.Drawing.Point(0, 24);
            this.rtbStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(764, 465);
            this.rtbStatus.TabIndex = 3;
            this.rtbStatus.Text = "";
            this.rtbStatus.TextChanged += new System.EventHandler(this.rtbStatus_TextChanged);
            // 
            // btnDongBoDuLieu
            // 
            this.btnDongBoDuLieu.Name = "btnDongBoDuLieu";
            this.btnDongBoDuLieu.Size = new System.Drawing.Size(178, 22);
            this.btnDongBoDuLieu.Text = "Đồng Bộ Dữ Liệu";
            this.btnDongBoDuLieu.Click += new System.EventHandler(this.btnDongBoDuLieu_Click);
            // 
            // FrmStartupSync
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 489);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.InactiveGlowColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmStartupSync";
            this.Text = "FrmStartupSync";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSettup;
        private System.Windows.Forms.ToolStripMenuItem mnStart;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.ToolStripMenuItem mnAbout;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem severToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDongBoDuLieu;
    }
}