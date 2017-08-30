namespace BioNetSangLocSoSinh.FrmReports
{
    partial class FrmBaoCapMain
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaoCapMain));
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            this.tbDrugFunction = new DevExpress.XtraBars.Navigation.TileBar();
            this.tbGroupDrugFunction = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tbItemTrungTam = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tbItemChiCuc = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tbItemDonVi = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tbItemCautionDrug = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem1 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem2 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem3 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.pnListUtility = new DevExpress.XtraEditors.PanelControl();
            this.pnDetails = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnListUtility)).BeginInit();
            this.pnListUtility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDrugFunction
            // 
            this.tbDrugFunction.AllowDrag = false;
            this.tbDrugFunction.AllowSelectedItem = true;
            this.tbDrugFunction.AppearanceText.Options.UseTextOptions = true;
            this.tbDrugFunction.AppearanceText.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbDrugFunction.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbDrugFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDrugFunction.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tbDrugFunction.Groups.Add(this.tbGroupDrugFunction);
            this.tbDrugFunction.ItemCheckMode = DevExpress.XtraEditors.TileItemCheckMode.Single;
            this.tbDrugFunction.Location = new System.Drawing.Point(2, 2);
            this.tbDrugFunction.MaxId = 9;
            this.tbDrugFunction.Name = "tbDrugFunction";
            this.tbDrugFunction.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbDrugFunction.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tbDrugFunction.Size = new System.Drawing.Size(202, 461);
            this.tbDrugFunction.TabIndex = 1;
            this.tbDrugFunction.Text = "Dược lâm sàng";
            // 
            // tbGroupDrugFunction
            // 
            this.tbGroupDrugFunction.Items.Add(this.tbItemTrungTam);
            this.tbGroupDrugFunction.Items.Add(this.tbItemChiCuc);
            this.tbGroupDrugFunction.Items.Add(this.tbItemDonVi);
            this.tbGroupDrugFunction.Items.Add(this.tbItemCautionDrug);
            this.tbGroupDrugFunction.Items.Add(this.tileBarItem1);
            this.tbGroupDrugFunction.Items.Add(this.tileBarItem2);
            this.tbGroupDrugFunction.Items.Add(this.tileBarItem3);
            this.tbGroupDrugFunction.Name = "tbGroupDrugFunction";
            // 
            // tbItemTrungTam
            // 
            this.tbItemTrungTam.AppearanceItem.Hovered.BorderColor = System.Drawing.Color.White;
            this.tbItemTrungTam.AppearanceItem.Hovered.Options.UseBorderColor = true;
            this.tbItemTrungTam.AppearanceItem.Normal.BackColor = System.Drawing.Color.Teal;
            this.tbItemTrungTam.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tbItemTrungTam.AppearanceItem.Selected.BorderColor = System.Drawing.Color.Red;
            this.tbItemTrungTam.AppearanceItem.Selected.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemTrungTam.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tbItemTrungTam.AppearanceItem.Selected.Options.UseFont = true;
            this.tbItemTrungTam.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement1.Image")));
            tileItemElement1.Text = "Báo cáo trung tâm";
            this.tbItemTrungTam.Elements.Add(tileItemElement1);
            this.tbItemTrungTam.Id = 0;
            this.tbItemTrungTam.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tbItemTrungTam.Name = "tbItemTrungTam";
            this.tbItemTrungTam.ShowItemShadow = DevExpress.Utils.DefaultBoolean.False;
            this.tbItemTrungTam.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tbItemVEN_ItemClick);
            // 
            // tbItemChiCuc
            // 
            this.tbItemChiCuc.AppearanceItem.Hovered.BorderColor = System.Drawing.Color.Green;
            this.tbItemChiCuc.AppearanceItem.Hovered.Options.UseBorderColor = true;
            this.tbItemChiCuc.AppearanceItem.Normal.BackColor = System.Drawing.Color.SteelBlue;
            this.tbItemChiCuc.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tbItemChiCuc.AppearanceItem.Selected.BorderColor = System.Drawing.Color.Red;
            this.tbItemChiCuc.AppearanceItem.Selected.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemChiCuc.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tbItemChiCuc.AppearanceItem.Selected.Options.UseFont = true;
            this.tbItemChiCuc.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement2.Image")));
            tileItemElement2.Text = "Báo cáo chi cục";
            this.tbItemChiCuc.Elements.Add(tileItemElement2);
            this.tbItemChiCuc.Id = 1;
            this.tbItemChiCuc.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tbItemChiCuc.Name = "tbItemChiCuc";
            this.tbItemChiCuc.ShowItemShadow = DevExpress.Utils.DefaultBoolean.False;
            this.tbItemChiCuc.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tbItemADR_ItemClick);
            // 
            // tbItemDonVi
            // 
            this.tbItemDonVi.AppearanceItem.Hovered.BorderColor = System.Drawing.Color.Green;
            this.tbItemDonVi.AppearanceItem.Hovered.Options.UseBorderColor = true;
            this.tbItemDonVi.AppearanceItem.Normal.BackColor = System.Drawing.Color.RoyalBlue;
            this.tbItemDonVi.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tbItemDonVi.AppearanceItem.Selected.BorderColor = System.Drawing.Color.Red;
            this.tbItemDonVi.AppearanceItem.Selected.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemDonVi.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tbItemDonVi.AppearanceItem.Selected.Options.UseFont = true;
            this.tbItemDonVi.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement3.Image")));
            tileItemElement3.Text = "Báo cáo đơn vị";
            this.tbItemDonVi.Elements.Add(tileItemElement3);
            this.tbItemDonVi.Id = 2;
            this.tbItemDonVi.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tbItemDonVi.Name = "tbItemDonVi";
            this.tbItemDonVi.ShowItemShadow = DevExpress.Utils.DefaultBoolean.False;
            this.tbItemDonVi.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tbItemDDD_ItemClick);
            // 
            // tbItemCautionDrug
            // 
            this.tbItemCautionDrug.AppearanceItem.Hovered.BorderColor = System.Drawing.Color.Green;
            this.tbItemCautionDrug.AppearanceItem.Hovered.Options.UseBorderColor = true;
            this.tbItemCautionDrug.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.tbItemCautionDrug.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tbItemCautionDrug.AppearanceItem.Selected.BorderColor = System.Drawing.Color.Red;
            this.tbItemCautionDrug.AppearanceItem.Selected.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemCautionDrug.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tbItemCautionDrug.AppearanceItem.Selected.Options.UseFont = true;
            this.tbItemCautionDrug.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement4.Image")));
            tileItemElement4.Text = "Báo cáo khác";
            this.tbItemCautionDrug.Elements.Add(tileItemElement4);
            this.tbItemCautionDrug.Id = 3;
            this.tbItemCautionDrug.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tbItemCautionDrug.Name = "tbItemCautionDrug";
            // 
            // tileBarItem1
            // 
            this.tileBarItem1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement5.Text = "";
            this.tileBarItem1.Elements.Add(tileItemElement5);
            this.tileBarItem1.Id = 6;
            this.tileBarItem1.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem1.Name = "tileBarItem1";
            // 
            // tileBarItem2
            // 
            this.tileBarItem2.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement6.Text = "";
            this.tileBarItem2.Elements.Add(tileItemElement6);
            this.tileBarItem2.Id = 7;
            this.tileBarItem2.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem2.Name = "tileBarItem2";
            // 
            // tileBarItem3
            // 
            this.tileBarItem3.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement7.Text = "";
            this.tileBarItem3.Elements.Add(tileItemElement7);
            this.tileBarItem3.Id = 8;
            this.tileBarItem3.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem3.Name = "tileBarItem3";
            // 
            // pnListUtility
            // 
            this.pnListUtility.Controls.Add(this.tbDrugFunction);
            this.pnListUtility.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnListUtility.Location = new System.Drawing.Point(0, 0);
            this.pnListUtility.Name = "pnListUtility";
            this.pnListUtility.Size = new System.Drawing.Size(206, 465);
            this.pnListUtility.TabIndex = 0;
            // 
            // pnDetails
            // 
            this.pnDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDetails.Location = new System.Drawing.Point(206, 0);
            this.pnDetails.Name = "pnDetails";
            this.pnDetails.Size = new System.Drawing.Size(751, 465);
            this.pnDetails.TabIndex = 2;
            // 
            // FrmBaoCapMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 465);
            this.Controls.Add(this.pnDetails);
            this.Controls.Add(this.pnListUtility);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.Name = "FrmBaoCapMain";
            this.Text = "Utility";
            ((System.ComponentModel.ISupportInitialize)(this.pnListUtility)).EndInit();
            this.pnListUtility.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileBar tbDrugFunction;
        private DevExpress.XtraBars.Navigation.TileBarGroup tbGroupDrugFunction;
        private DevExpress.XtraBars.Navigation.TileBarItem tbItemTrungTam;
        private DevExpress.XtraBars.Navigation.TileBarItem tbItemChiCuc;
        private DevExpress.XtraBars.Navigation.TileBarItem tbItemDonVi;
        private DevExpress.XtraBars.Navigation.TileBarItem tbItemCautionDrug;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem1;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem2;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem3;
        private DevExpress.XtraEditors.PanelControl pnListUtility;
        private DevExpress.XtraEditors.PanelControl pnDetails;
    }
}