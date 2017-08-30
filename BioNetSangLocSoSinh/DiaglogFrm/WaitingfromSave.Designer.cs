namespace BioNetSangLocSoSinh.DiaglogFrm
{
    partial class WaitingfromSave
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
            this.txtnoidung = new DevExpress.XtraEditors.LabelControl();
            this.txtTieuDe = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtnoidung
            // 
            this.txtnoidung.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnoidung.Appearance.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.txtnoidung.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtnoidung.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtnoidung.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.txtnoidung.Location = new System.Drawing.Point(115, 50);
            this.txtnoidung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtnoidung.Name = "txtnoidung";
            this.txtnoidung.Size = new System.Drawing.Size(447, 20);
            this.txtnoidung.TabIndex = 13;
            this.txtnoidung.Text = "Đang lưu dữ liệu, vui lòng đợi...";
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieuDe.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtTieuDe.Location = new System.Drawing.Point(115, 15);
            this.txtTieuDe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(424, 29);
            this.txtTieuDe.TabIndex = 12;
            this.txtTieuDe.Text = "BIONET - Chương trình sàng lọc sơ sinh";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::BioNetSangLocSoSinh.Properties.Resources.facebook__2_;
            this.pictureEdit1.Location = new System.Drawing.Point(3, 2);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(95, 80);
            this.pictureEdit1.TabIndex = 11;
            // 
            // WaitingfromSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 85);
            this.Controls.Add(this.txtnoidung);
            this.Controls.Add(this.txtTieuDe);
            this.Controls.Add(this.pictureEdit1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WaitingfromSave";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl txtnoidung;
        private DevExpress.XtraEditors.LabelControl txtTieuDe;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}
