namespace BioNetSangLocSoSinh.DiaglogFrm
{
    partial class FrmDiaglogCapMaTuDong
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
            this.GroupDanhSach = new DevExpress.XtraEditors.GroupControl();
            this.btnLuuMaXN = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GroupDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupDanhSach
            // 
            this.GroupDanhSach.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupDanhSach.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.GroupDanhSach.AppearanceCaption.Options.UseFont = true;
            this.GroupDanhSach.Location = new System.Drawing.Point(0, 0);
            this.GroupDanhSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupDanhSach.Name = "GroupDanhSach";
            this.GroupDanhSach.Size = new System.Drawing.Size(811, 378);
            this.GroupDanhSach.TabIndex = 0;
            this.GroupDanhSach.Text = "Danh sách cấp mã";
            // 
            // btnLuuMaXN
            // 
            this.btnLuuMaXN.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnLuuMaXN.Location = new System.Drawing.Point(708, 385);
            this.btnLuuMaXN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuuMaXN.Name = "btnLuuMaXN";
            this.btnLuuMaXN.Size = new System.Drawing.Size(87, 28);
            this.btnLuuMaXN.TabIndex = 1;
            this.btnLuuMaXN.Text = "Lưu";
            this.btnLuuMaXN.Click += new System.EventHandler(this.btnLuuMaXN_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCancel.Location = new System.Drawing.Point(614, 385);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmDiaglogCapMaTuDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 418);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLuuMaXN);
            this.Controls.Add(this.GroupDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDiaglogCapMaTuDong";
            this.Text = "FrmDiaglogCapMaTuDong";
            this.Load += new System.EventHandler(this.FrmDiaglogCapMaTuDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GroupDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GroupDanhSach;
        private DevExpress.XtraEditors.SimpleButton btnLuuMaXN;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}