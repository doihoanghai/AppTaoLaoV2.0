namespace BioNetSangLocSoSinh.UserControl
{
    partial class ucBaoCaoDonVi
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
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBaoCaoDonVi));
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem1 = new DevExpress.XtraEditors.TileItem();
            this.tileItem9 = new DevExpress.XtraEditors.TileItem();
            this.tileItem2 = new DevExpress.XtraEditors.TileItem();
            this.tileListABCVEN = new DevExpress.XtraEditors.TileControl();
            this.SuspendLayout();
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileItem2);
            this.tileGroup2.Items.Add(this.tileItem9);
            this.tileGroup2.Items.Add(this.tileItem1);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // tileItem1
            // 
            tileItemElement3.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement3.Image")));
            tileItemElement3.Text = "Báo cáo tùy chọn";
            this.tileItem1.Elements.Add(tileItemElement3);
            this.tileItem1.Id = 27;
            this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem1.Name = "tileItem1";
            this.tileItem1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem1_ItemClick);
            // 
            // tileItem9
            // 
            this.tileItem9.AppearanceItem.Hovered.BorderColor = System.Drawing.Color.White;
            this.tileItem9.AppearanceItem.Hovered.Options.UseBorderColor = true;
            this.tileItem9.AppearanceItem.Normal.BackColor = System.Drawing.Color.Teal;
            this.tileItem9.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItem9.AppearanceItem.Selected.BorderColor = System.Drawing.Color.White;
            this.tileItem9.AppearanceItem.Selected.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tileItem9.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tileItem9.AppearanceItem.Selected.Options.UseFont = true;
            tileItemElement2.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement2.Image")));
            tileItemElement2.Text = "Báo cáo chi tiết";
            this.tileItem9.Elements.Add(tileItemElement2);
            this.tileItem9.Id = 21;
            this.tileItem9.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem9.Name = "tileItem9";
            this.tileItem9.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem9_ItemClick);
            // 
            // tileItem2
            // 
            this.tileItem2.AppearanceItem.Hovered.BorderColor = System.Drawing.Color.White;
            this.tileItem2.AppearanceItem.Hovered.Options.UseBorderColor = true;
            this.tileItem2.AppearanceItem.Normal.BackColor = System.Drawing.Color.Teal;
            this.tileItem2.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItem2.AppearanceItem.Selected.BorderColor = System.Drawing.Color.White;
            this.tileItem2.AppearanceItem.Selected.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tileItem2.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tileItem2.AppearanceItem.Selected.Options.UseFont = true;
            tileItemElement1.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement1.Image")));
            tileItemElement1.Text = "Báo cáo tổng hợp";
            this.tileItem2.Elements.Add(tileItemElement1);
            this.tileItem2.Id = 1;
            this.tileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem2.Name = "tileItem2";
            this.tileItem2.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem2_ItemClick);
            // 
            // tileListABCVEN
            // 
            this.tileListABCVEN.AllowItemHover = true;
            this.tileListABCVEN.AllowSelectedItem = true;
            this.tileListABCVEN.Cursor = System.Windows.Forms.Cursors.Default;
            this.tileListABCVEN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileListABCVEN.DragSize = new System.Drawing.Size(0, 0);
            this.tileListABCVEN.Groups.Add(this.tileGroup2);
            this.tileListABCVEN.ItemSize = 80;
            this.tileListABCVEN.Location = new System.Drawing.Point(0, 0);
            this.tileListABCVEN.MaxId = 28;
            this.tileListABCVEN.Name = "tileListABCVEN";
            this.tileListABCVEN.ShowText = true;
            this.tileListABCVEN.Size = new System.Drawing.Size(912, 467);
            this.tileListABCVEN.TabIndex = 2;
            this.tileListABCVEN.Text = "Các báo cáo theo đơn vị";
            // 
            // ucBaoCaoDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileListABCVEN);
            this.Name = "ucBaoCaoDonVi";
            this.Size = new System.Drawing.Size(912, 467);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileItem2;
        private DevExpress.XtraEditors.TileItem tileItem9;
        private DevExpress.XtraEditors.TileItem tileItem1;
        private DevExpress.XtraEditors.TileControl tileListABCVEN;
    }
}
