namespace BioNetSangLocSoSinh.UserControl
{
    partial class UscCapMaTheoDonVi
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
            this.lookUpDonVi = new DevExpress.XtraEditors.LookUpEdit();
            this.txtTu = new DevExpress.XtraEditors.TextEdit();
            this.txtDen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtslMax = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtslMax.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpDonVi
            // 
            this.lookUpDonVi.Location = new System.Drawing.Point(3, 3);
            this.lookUpDonVi.Name = "lookUpDonVi";
            this.lookUpDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDonVi.Properties.DisplayMember = "TenDVCS";
            this.lookUpDonVi.Properties.NullText = "Đơn vị";
            this.lookUpDonVi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpDonVi.Properties.ValueMember = "MaDVCS";
            this.lookUpDonVi.Size = new System.Drawing.Size(381, 20);
            this.lookUpDonVi.TabIndex = 0;
            this.lookUpDonVi.EditValueChanged += new System.EventHandler(this.lookUpDonVi_EditValueChanged);
            // 
            // txtTu
            // 
            this.txtTu.Location = new System.Drawing.Point(412, 3);
            this.txtTu.Name = "txtTu";
            this.txtTu.Properties.MaxLength = 8;
            this.txtTu.Size = new System.Drawing.Size(73, 20);
            this.txtTu.TabIndex = 1;
            this.txtTu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTu_KeyPress);
            this.txtTu.Validated += new System.EventHandler(this.txtTu_Validated);
            // 
            // txtDen
            // 
            this.txtDen.Location = new System.Drawing.Point(514, 3);
            this.txtDen.Name = "txtDen";
            this.txtDen.Properties.MaxLength = 8;
            this.txtDen.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDen_Properties_KeyPress);
            this.txtDen.Size = new System.Drawing.Size(77, 20);
            this.txtDen.TabIndex = 2;
            this.txtDen.Validated += new System.EventHandler(this.txtDen_Validated);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(391, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(20, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Từ :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(487, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Đến :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(597, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Giới hạn :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(672, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(14, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "mã";
            // 
            // txtslMax
            // 
            this.txtslMax.Location = new System.Drawing.Point(642, 3);
            this.txtslMax.Name = "txtslMax";
            this.txtslMax.Properties.ReadOnly = true;
            this.txtslMax.Size = new System.Drawing.Size(28, 20);
            this.txtslMax.TabIndex = 4;
            // 
            // UscCapMaTheoDonVi
            // 
            this.Appearance.BackColor = System.Drawing.Color.PapayaWhip;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtslMax);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDen);
            this.Controls.Add(this.txtTu);
            this.Controls.Add(this.lookUpDonVi);
            this.Name = "UscCapMaTheoDonVi";
            this.Size = new System.Drawing.Size(698, 27);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtslMax.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpDonVi;
        private DevExpress.XtraEditors.TextEdit txtTu;
        private DevExpress.XtraEditors.TextEdit txtDen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtslMax;
    }
}
