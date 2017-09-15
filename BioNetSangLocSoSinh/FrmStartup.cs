using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraBars.Ribbon;
using BioNetModel.Data;
using BioNetBLL;
using DevExpress.XtraEditors;
using DataSync;
using System.Threading;
using BioNetSangLocSoSinh.FrmReports;
using System.IO;
using System.IO.Compression;

namespace BioNetSangLocSoSinh
{
    public partial class FrmStartup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string empCode = string.Empty;
        //path file txt ds phiếu chưa đồng bộ
        string pathtxt = Application.StartupPath + "\\DSPhieuChuaDongBo\\dsPhieuChuaDongBo.txt";
        //path phiếu kết quả xét nghiệm
        string pathkq = Application.StartupPath + "\\PhieuKetQua\\";
        //path nơi luuw file đã nén để đồng bộ
        string pathdongbo = Application.StartupPath + "\\DSNenDongBo\\";
        public FrmStartup()
        {
            InitializeComponent();
        }

        private void FrmStartup_Load(object sender, EventArgs e)
        {
            if (BioBLL.CheckConnection())
            {
                this.GetLogin();

                Thread thread = new Thread(LoadDuLieu);
                thread.Start();
            }
            else
            {
                DiaglogFrm.frmConfig frm = new DiaglogFrm.frmConfig();
                frm.ShowDialog(this);
                if (frm.isConnected)
                    Application.Restart();
            }

        }
        private void LoadDuLieu()
        {
            //BioNetDBContextDataContext db = null;
            //ProcessDataSync cn = new ProcessDataSync();
            //db = cn.db;
            //var term = db.PSThongTinTrungTams.FirstOrDefault();
            //if (term == null || term.MaTrungTam == null)
            //{
            //    FrmStartupSync dl = new FrmStartupSync();
            //    dl.GetDuLieuBanDau();
            //}
            FrmStartupSync dl = new FrmStartupSync();
            dl.DongBoDuLieu();
        }

        private void GetLogin()
        {
            var TrungTam = BioNet_Bus.GetThongTinTrungTam();
            var NgayServer = BioNet_Bus.GetDateTime();
            DLLLicensePS.Reponse res = DLLLicensePS.DECRYPT.CheckLisences(TrungTam.ID, string.Empty, TrungTam.LicenseKey, NgayServer.Date.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyy"));

            if (!res.Result)
            {
                XtraMessageBox.Show("Bản quyền phần mềm hết hạn,vui lòng liên hệ với nhà cung cấp! \r\n Thông tin chi tiết : " + res.ResultString, "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (res.TimeRemind < 7)
                {
                    string str = @"Bản quyền phần mềm chỉ còn {0} ngày. 
Vui lòng liên hệ mua bản quyền để sử dụng phần mềm không bị gián đoạn!";
                    string mes = string.Format(str, res.TimeRemind);
                    XtraMessageBox.Show(mes, "BioNet - Chương trình sàng lọc sơ sinh!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DiaglogFrm.FrmLogin frm = new DiaglogFrm.FrmLogin();
                frm.ShowDialog();
                if (!frm.cancel)
                {
                    this.empCode = frm._EmployeeCode;
                    List<PSMenuSecurity> lstMenuSecurity = new List<PSMenuSecurity>();
                    lstMenuSecurity = BioBLL.ListMenuSecurity(empCode);
                    foreach (var item in lstMenuSecurity)
                    {
                        this.SetMenu(item.MenuCode);
                    }
                }

            }
        }

        // private WaitingFrom.WaitingFrom Starting = null;
        private Size sizeWaiting = new System.Drawing.Size(400, 40);
        public void TabCreating(XtraTabControl TabControl, string Text, Form Form)
        {
            int Index = this.CheckExists(TabControl, Text);
            if (Index >= 0)
            {
                TabControl.SelectedTabPage = TabControl.TabPages[Index];
                TabControl.SelectedTabPage.Text = Text;
            }
            else
            {
                XtraTabPage TabPage = new XtraTabPage { Text = Text };
                TabPage.AutoScroll = true;
                TabControl.TabPages.Add(TabPage);
                TabControl.SelectedTabPage = TabPage;
                //TabControl.AppearancePage.HeaderActive.ForeColor = Color.Red;
                TabControl.AppearancePage.HeaderActive.Font = new Font(TabControl.AppearancePage.HeaderActive.Font, FontStyle.Bold);
                Form.TopLevel = false;
                Form.Parent = TabPage;
                Form.Dock = DockStyle.Fill;
                Form.Show();
            }
        }

        private int CheckExists(XtraTabControl TabControlName, string TabName)
        {
            int temp = -1;
            for (int i = 0; i < TabControlName.TabPages.Count; i++)
            {
                if (TabControlName.TabPages[i].Text == TabName)
                {
                    temp = i;
                    break;
                }
            }
            return temp;
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmTiepNhan frm = new Entry.FrmTiepNhan(this.empCode);
            TabCreating(xTabMain, "Tiếp nhận", frm);
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmNhapLieuDanhGiaMau frm = new Entry.FrmNhapLieuDanhGiaMau(this.empCode);
            TabCreating(xTabMain, "Nhập liệu và đánh giá", frm);
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDanhMaXetNghiem frm = new Entry.FrmDanhMaXetNghiem();
            TabCreating(xTabMain, "Cấp phát mã xét nghiệm", frm);
            SplashScreenManager.CloseForm();
        }

        private void xTabMain_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraTab.XtraTabControl xtab = (DevExpress.XtraTab.XtraTabControl)sender;
                if (xtab.TabPages.Count == 1) return;
                int i = xtab.SelectedTabPageIndex;
                xtab.TabPages.RemoveAt(xtab.SelectedTabPageIndex);
                xtab.SelectedTabPageIndex = i - 1;
            }
            catch { }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmPhongXetNghiem frm = new Entry.FrmPhongXetNghiem(this.empCode);
            TabCreating(xTabMain, "Phòng xét nghiệm", frm);
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmTraKetQua frm = new Entry.FrmTraKetQua(this.empCode);
            int frmsize = this.xTabMain.Width;
            int pnsize = 222;
            if (frmsize - 800 > 280)
            { pnsize = frmsize - 800; }

            frm.PanelDanhSach.Width = pnsize;
            TabCreating(xTabMain, "Trả kết quả xét nghiệm", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmEmployee frm = new Entry.FrmEmployee();
            TabCreating(xTabMain, "Nhân viên", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmPhanQuyen frm = new Entry.FrmPhanQuyen(GetMenuRib(), this.empCode);
            TabCreating(xTabMain, "Phân quyền nhân viên", frm);
            SplashScreenManager.CloseForm();
        }

        public TreeNode GetMenuRib()
        {
            TreeNode anode, anode1, anode2;
            anode = new TreeNode("Tất cả");
            anode.Tag = "menuChucnang";
            anode.Name = "menuChucnang";
            anode.Text = "Tất cả";
            foreach (RibbonPage mi in this.ribbon.Pages)
            {
                RibbonPage ribbon = (RibbonPage)(mi);
                if (this.ribbon.Pages.Count > 0)
                {
                    anode1 = new TreeNode(ribbon.Text);
                    anode1.Name = ribbon.Name;
                    if (ribbon.Groups != null)
                    {
                        foreach (RibbonPageGroup pagegroup in ribbon.Groups)
                        {
                            anode2 = new TreeNode(pagegroup.Text);
                            anode2.Name = pagegroup.Name;
                            foreach (BarItemLink Item in pagegroup.ItemLinks)
                            {
                                GetPermisonInBarItemLink(anode2, Item);
                            }
                            anode1.Nodes.Add(anode2);
                        }
                    }
                    anode.Nodes.Add(anode1);
                }
            }
            anode.ExpandAll();
            return anode;
        }

        public void GetPermisonInBarItemLink(TreeNode Node, BarItemLink page)
        {
            TreeNode anode1 = new TreeNode();
            BarItem barItem = page.Item;
            if (barItem != null)
            {
                anode1 = new TreeNode(barItem.Caption);
                anode1.Name = barItem.Name;
                Node.Nodes.Add(anode1);

                if (barItem.GetType().FullName == "DevExpress.XtraBars.BarSubItem")
                {
                    BarSubItem mBarSubItem = (BarSubItem)barItem;
                    foreach (BarItemLink mSubLink in mBarSubItem.ItemLinks)
                    {
                        GetPermisonInBarItemLink(anode1, mSubLink);
                    }
                }
            }
        }

        public void SetMenu(string menuName)
        {
            foreach (RibbonPage mi in this.ribbon.Pages)
            {
                bool visibleMenu = false;
                RibbonPage ribbon = (RibbonPage)(mi);
                if (this.ribbon.Pages.Count > 0)
                {
                    this.SetPermisonInPage(menuName, ribbon, ref visibleMenu);
                }
                if (visibleMenu)
                {
                    mi.Visible = true;
                    break;
                }
            }
        }

        public void SetPermisonInPage(string menuname, RibbonPage page, ref bool visibleMenu)
        {
            if (page.Groups != null)
            {
                foreach (RibbonPageGroup pagegroup in page.Groups)
                {
                    this.SetPermisonInPageGroup(menuname, pagegroup, ref visibleMenu);
                    if (visibleMenu)
                    {
                        pagegroup.Visible = true;
                        break;
                    }
                }
                if (visibleMenu)
                    page.Visible = true;
            }
        }

        public void SetPermisonInPageGroup(string menuname, RibbonPageGroup page, ref bool visiblePage)
        {
            if (page != null)
            {
                if (page.Name == menuname)
                {
                    page.Visible = true;
                }
                if (page.ItemLinks != null)
                {
                    foreach (BarItemLink Item in page.ItemLinks)
                    {
                        this.SetPermisonInBarItemLink(menuname, Item, ref visiblePage);
                        if (visiblePage)
                            break;
                    }
                }
            }
        }

        public void SetPermisonInBarItemLink(string menuname, BarItemLink page, ref bool visibleGroup)
        {
            BarItem barItem = page.Item;
            if (barItem != null)
            {
                if (barItem.Name == menuname)
                {
                    barItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    visibleGroup = true;
                }
                if (barItem.GetType().FullName == "DevExpress.XtraBars.BarSubItem")
                {
                    BarSubItem mBarSubItem = (BarSubItem)barItem;
                    foreach (BarItemLink menuSubLink in mBarSubItem.ItemLinks)
                    {
                        SetPermisonInBarItemLink(menuname, menuSubLink, ref visibleGroup);
                        if (visibleGroup)
                        {
                            barItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        }
                    }
                }

            }
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Restart();
        }

        private void btnDMGoiDVCoSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDMGoiDichVuDonVi frm = new Entry.FrmDMGoiDichVuDonVi();
            TabCreating(xTabMain, "Danh mục gói dịch vụ sơ sở", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnDMDichVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDMDichVu frm = new Entry.FrmDMDichVu();
            TabCreating(xTabMain, "Danh mục dịch vụ", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnDetailServicePackage_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDMGoiDichVuChiTiet frm = new Entry.FrmDMGoiDichVuChiTiet();
            TabCreating(xTabMain, "Chi tiết gói dịch vụ chung", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnDMChiCuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDMChiCuc frm = new Entry.FrmDMChiCuc();
            TabCreating(xTabMain, "Danh mục chi cục", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnDMTrungTam_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            //  Entry.FrmDMTrungTam frm = new Entry.FrmDMTrungTam();
            Entry.FrmThongTinTrungTam frm = new Entry.FrmThongTinTrungTam();
            TabCreating(xTabMain, "Thông tin trung tâm", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnDanhMucDonViCoSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDMDonViCoSo frm = new Entry.FrmDMDonViCoSo();
            TabCreating(xTabMain, "Đơn vị cơ sở", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnInforPerson_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmInfoPerson frm = new Entry.FrmInfoPerson();
            TabCreating(xTabMain, "Thông tin bệnh nhân", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnDMChuongTrinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDMChuongTrinh frm = new Entry.FrmDMChuongTrinh();
            TabCreating(xTabMain, "Danh mục chương trình", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnChanDoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmKhamBenh frm = new Entry.FrmKhamBenh();
            TabCreating(xTabMain, "Patient Care", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnDMDanhGiaChatLuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDMDanhGiaChatLuongMau frm = new Entry.FrmDMDanhGiaChatLuongMau();
            TabCreating(xTabMain, "Đánh giá chất lượng mẫu", frm);
            SplashScreenManager.CloseForm();
        }

        private void btnChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            DiaglogFrm.FrmChangePass frm = new DiaglogFrm.FrmChangePass(this.empCode);
            frm.ShowDialog();
            SplashScreenManager.CloseForm();
        }

        private void btnDMThongSoXN_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDMThongSoXN frm = new Entry.FrmDMThongSoXN();
            TabCreating(xTabMain, "Thông số xét nghiệm", frm);
            SplashScreenManager.CloseForm();
        }

        //private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
        //    Entry.FrmNhapLieu frm = new Entry.FrmNhapLieu(this.empCode);
        //    TabCreating(xTabMain, "Nhập liệu", frm);
        //    SplashScreenManager.CloseForm();
        //}

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Reports.DashBoardReport frm = new Reports.DashBoardReport();
            TabCreating(xTabMain, "Dash Board Designer", frm);
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            FrmReports.FrmBaoCaoCoBan frm = new FrmReports.FrmBaoCaoCoBan();
            TabCreating(xTabMain, "Báo cáo cơ bản", frm);
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            FrmReports.FrmBaoCao frm = new FrmReports.FrmBaoCao();
            TabCreating(xTabMain, "Báo cáo ", frm);
            SplashScreenManager.CloseForm();
        }

        private void barSubItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            FrmReports.FrmBaoCapMain frm = new FrmReports.FrmBaoCapMain();
            TabCreating(xTabMain, "Báo cáo ", frm);
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            DiaglogFrm.FrmDiaglog_ThongTinBanQuyen frm = new DiaglogFrm.FrmDiaglog_ThongTinBanQuyen();
            frm.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (BioBLL.CheckConnection())
            {
                this.GetLogin();
            }
            else
            {
                DiaglogFrm.frmConfig frm = new DiaglogFrm.frmConfig();
                frm.ShowDialog(this);
                if (frm.isConnected)
                    Application.Restart();
            }
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.FrmDMNhomNhanVien frm = new Entry.FrmDMNhomNhanVien();
            TabCreating(xTabMain, "Nhóm chức danh nhân viên ", frm);
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                FrmReports.FrmBaoCaoCoBan frm = new FrmReports.FrmBaoCaoCoBan();
                TabCreating(xTabMain, "Báo cáo trung tâm sơ bộ", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                FrmReports.FrmBaoCaoChiTiet_TrungTam frm = new FrmReports.FrmBaoCaoChiTiet_TrungTam();
                TabCreating(xTabMain, "Báo cáo trung tâm chi tiết", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                FrmReports.FrmBaoCaoTuyChon_TrungTam frm = new FrmReports.FrmBaoCaoTuyChon_TrungTam();
                TabCreating(xTabMain, "Báo cáo trung tâm tùy chọn", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                FrmReports.FrmBaoCaoChiTiet_TrungTam frm = new FrmReports.FrmBaoCaoChiTiet_TrungTam();
                TabCreating(xTabMain, "Báo cáo chi cục sơ bộ", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

        private void btnNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
            Entry.frmNhaCungCap frm = new Entry.frmNhaCungCap();
            TabCreating(xTabMain, "Nhà cung cấp", frm);
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                FrmReports.FrmReportTrungTam_DonVi frm = new FrmReports.FrmReportTrungTam_DonVi();
                TabCreating(xTabMain, "Báo cáo chi cục chi tiết", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                FrmReports.FrmBaoCaoDonVi_ChiTietcs frm = new FrmReports.FrmBaoCaoDonVi_ChiTietcs();
                TabCreating(xTabMain, "Báo cáo đơn vị", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                FrmReports.FrmTinhTrangMau frm = new FrmReports.FrmTinhTrangMau();
                TabCreating(xTabMain, "Báo cáo  tình trạng mẫu", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

        private void btnMail_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                FrmReports.FrmGuiMail frm = new FrmReports.FrmGuiMail();
                TabCreating(xTabMain, "Gửi mail cho khách hàng", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

   
        private int  NenFileDongBo()
        {
            
            IEnumerable<string> linkthumucdvcs = Directory.EnumerateDirectories(pathkq);
            List<string> filedvcs = new List<string>(linkthumucdvcs);
            string[] Phieuchuadb;
            int kq=0;
            try
            {
                Phieuchuadb = System.IO.File.ReadAllLines(pathtxt);
                foreach (string dvcs in filedvcs)
                {
                    DirectoryInfo linkpdfs = new DirectoryInfo(dvcs + "\\");
                    int dau = dvcs.Length;
                    string tendvcs = dvcs.Substring(dau - 8, 8);
                    // Danh sách thư mục đơn vị cơ sở               
                    FileInfo[] linkpdf = linkpdfs.GetFiles();
                    string zipPath = pathdongbo + tendvcs + ".zip";
                    foreach (FileInfo childFile in linkpdf)
                    {
                        string[] maphieu = childFile.Name.Split('.');
                        foreach (string phieuchuadb in Phieuchuadb)
                        {
                            if (phieuchuadb == maphieu[0])
                            {
                                string startPath = childFile.FullName;
                                try
                                {
                                    //Nén File
                                    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
                                    {
                                        archive.CreateEntryFromFile(startPath, maphieu[0] + ".pdf");                                        
                                    }
                                }
                                catch { kq=2;}
                            }
                        }
                    }
                    //FileInfo zip_info = new FileInfo(zipPath);
                    //int FileLength = int.Parse(zip_info.Length.ToString());
                    //if (FileLength == 0) {   File.Delete(zipPath);  }//Xóa file nén dvcs có dữ liệu = 0
                }
            }
            catch { kq=1; }
            return kq; 
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            int kq=NenFileDongBo();
            if (kq == 0)
            {
                var res = DBPhieuKQDataSync.PostKQPDF();
                if (string.IsNullOrEmpty(res.StringError))
                {
                    try
                    {
                        //Xóa file txt
                        File.Delete(pathtxt);
                        //Tạo lại file txt trắng
                        StreamWriter file = new StreamWriter(pathtxt, true);
                        DirectoryInfo dirInfo = new DirectoryInfo(pathdongbo);
                        FileInfo[] childFiles = dirInfo.GetFiles();
                        foreach (FileInfo childFile in childFiles)
                        { 
                            File.Delete(childFile.FullName); //Xóa các file nén đã đồng bộ
                        }
                        MessageBox.Show(DateTime.Now +"Đồng bộ phiếu kết quả thành công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi" + ex, "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    MessageBox.Show(DateTime.Now + ":Thông tin chi tiết khi đồng bộ dữ liệu danh sách bệnh nhân nguy cơ cao \r\n" + res.StringError + "\r\n", "Thông Báo", MessageBoxButtons.OK);
                }
            }
            else if(kq==1)
            { MessageBox.Show("Không có dữ liệu phiếu cần đồng bộ", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK); }
            else if(kq==2)
            { MessageBox.Show("Nén dữ liệu đồng bộ bị lỗi", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK); }

        }
    }
}