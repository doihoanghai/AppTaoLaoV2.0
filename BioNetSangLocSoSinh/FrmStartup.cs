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
using BioNetModel;
using BioNetSangLocSoSinh.DiaglogFrm;
using DataSync.BioNetSync;

namespace BioNetSangLocSoSinh
{
    public partial class FrmStartup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string empCode = string.Empty;
        //path file txt ds phiếu chưa đồng bộ
        public static string pathtxt = Application.StartupPath + "\\DSPhieuChuaDongBo\\dsPhieuChuaDongBo.txt";
        //path phiếu kết quả xét nghiệm
        public static string pathkq = Application.StartupPath + "\\PhieuKetQua\\";
        //path nơi luuw file đã nén để đồng bộ
        public static string pathdongbo = Application.StartupPath + "\\DSNenDongBo\\";
        public static List<string> MaPhieuPDF=new List<string>();
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
            //FrmStartupSync dl = new FrmStartupSync();
           //dl.DongBoDuLieu();
        }

        private void GetLogin()
        {
            var TrungTam = BioNet_Bus.GetThongTinTrungTam();
            var NgayServer = BioNet_Bus.GetDateTime();
            DLLLicensePS.Reponse res = DLLLicensePS.DECRYPT.CheckLisences(TrungTam.ID, string.Empty, TrungTam.LicenseKey, NgayServer.Date.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyy"));
            res.Result = true;
            res.TimeRemind = 10;

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
            Entry.FrmDanhMaXetNghiem frm = new Entry.FrmDanhMaXetNghiem(this.empCode);
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

        public static PsReponse  NenFileDongBo()
        {
            PsReponse res = new PsReponse();
            try
            {
                var phieuchuadb = BioNet_Bus.GetDanhSachPDFChuaDongBo();
                if(phieuchuadb != null)
                {
                    foreach(var phieu in phieuchuadb)
                    {
                        string startPath = pathkq + phieu.IDCoSo +"\\"+ phieu.MaPhieu + ".pdf";
                        string zipPath = pathdongbo + phieu.IDCoSo + ".zip";
                        if (!File.Exists(startPath))
                        {
                            Entry.FrmTraKetQua.LuuPDF(phieu.MaPhieu, phieu.IDCoSo, phieu.MaTiepNhan);
                        }
                        using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
                        {
                            archive.CreateEntryFromFile(startPath, phieu.MaPhieu+".pdf");
                        }
                        MaPhieuPDF.Add(phieu.MaPhieu);
                    }                  
                }
                res.Result = true;
            }
            catch {
                res.Result = false;
            }
            return res; 
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
           

        }


        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                FrmReports.FrmBaoCaoDonVi_TTPhieu frm = new FrmReports.FrmBaoCaoDonVi_TTPhieu();
                TabCreating(xTabMain, "Báo cáo phiếu đơn vị", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Đồng Bộ Thông TIn Trung Tâm
            PsReponse res = new PsReponse();
            try
            {

                SplashScreenManager.ShowForm(this, typeof(WaitingformLoadDongBo), true, true, false);
                res = ThongTinTrungTamSync.GetThongTinTrungTam();
                SplashScreenManager.CloseForm();
                if (res.Result == true)
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Thông Tin Trung Tâm Thành Công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Thông Tin Trung Tâmc Bị Lỗi- Danh Sách Lỗi: \r\n" + res.StringError, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Đồng Bộ Dữ Liệu Thông Tin Trung Tâmc Bị Lỗi- " + ex, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Đồng Bộ Dữ Liệu Danh Mục
            List<PsReponse> res = new List<PsReponse>();
            try
            {
                string Error = null;
                SplashScreenManager.ShowForm(this, typeof(WaitingformLoadDongBo), true, true, false);
                res.Add(DanhMucChiCucSync.GetDanhMucChiCuc());
                res.Add(DanhMucDonViCoSoSync.GetDanhMucDonViCoSo());
                res.Add(DanhMucDichVuSync.GetDMDichVu());
                res.Add(DanhMucDichVuCoSoSync.GetDMDichVuCoSo());
                res.Add(DanhMucGoiDichVuTheoDonViSync.GetDMGoiDichVuTheoDonVi());
                res.Add(DanhMucGoiDichVuChungSync.GetDMGoiDichVuChung());
                res.Add(DanhMucGoiDichVuChungSync.GetDMGoiDichVuChung_ChiTiet());
                res.Add(DanhMucChuongTrinhSync.GetDanhSachChuongTrinh());
                res.Add(DanhMucThongSoSync.GetDMThongSo());
                res.Add(DanhMucKyThuatSync.GetDMKyThuat());
                res.Add(MappingKyThuat_DichVuSync.GetDMMap_ThongSo_KyThuat());
                res.Add(MappingThongso_KyThuatSync.GetDMMap_KyThuat_DichVu());
                res.Add(DanhMucDanhGiaChatLuongMauSync.GetDMDanhGiaChatLuongMau());
                foreach (var p in res)
                {
                    if (p.Result == false && p.StringError != null)
                    {
                        Error = Error + "\r\n" + p.StringError;
                    }
                }
                SplashScreenManager.CloseForm();
                if (Error == null)
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Danh Mục Thành Công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Danh Mục Bị Lỗi- Danh Sách Lỗi: \r\n" + Error, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi Đồng Bộ Danh Mục - " + ex, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Đồng Bộ Dữ Liệu Phiếu Tiếp Nhận
            List<PsReponse> res = new List<PsReponse>();
            try
            {
                string Error = null;
                SplashScreenManager.ShowForm(this, typeof(WaitingformLoadDongBo), true, true, false);
                res.Add(PhieuSangLocSync.GetPhieuSangLoc());
                res.Add(PatientSync.GetPatient());
                foreach (var p in res)
                {
                    if (p.Result == false && p.StringError != null)
                    {
                        Error = Error + "\r\n" + p.StringError;
                    }
                }
                SplashScreenManager.CloseForm();
                if (Error == null)
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Phiếu Dữ Liệu Tiếp Nhận Thành Công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Phiếu Dữ Liệu Tiếp Nhận Bị Lỗi- Danh Sách Lỗi: \r\n" + Error, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Đồng Bộ Dữ Liệu Phiếu Dữ Liệu Tiếp Nhận Bị Lỗi -" + ex, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Đồng Bộ Dữ Liệu Phiếu Kết Quả
            List<PsReponse> res = new List<PsReponse>();
            try
            {
                string Error = null;
                SplashScreenManager.ShowForm(this, typeof(WaitingformLoadDongBo), true, true, false);
                res.Add(PhieuSangLocSync.PostPhieuSangLoc());
                res.Add(PatientSync.PostPatient());
                res.Add(ChiDinhSync.PostChiDinh());
                res.Add(KetQuaSync.PostKetQua());
                res.Add(BenhNhanNguyCoCaoSync.PostBenhNhanNguyCoCao());
                res.Add(DotChuanDoanSync.PostDotChuanDoan());
                res.Add(TraKetQuaSync.PostKetQua());
                res.Add(DanhGiaChatLuongMauSync.PostCTDanhGiaChatLuongMau());
                res.Add(PDFSync());
                foreach (var p in res)
                {
                    if (p.Result == false && p.StringError != null)
                    {
                        Error = Error + "\r\n" + p.StringError;
                    }
                }
                SplashScreenManager.CloseForm();
                if (Error == null)
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Kết Quả Thành Công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Kết Quả Bị Lỗi- Danh Sách Chi Tiết Lỗi: \r\n" + Error, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi Đồng Bộ Dữ Liệu Kết Quả - " + ex, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public static void DongBoPhieuKQ() { }
        public static PsReponse PDFSync()
        {
            PsReponse resp = new PsReponse();
            PsReponse resNen = NenFileDongBo();
            if (resNen.Result)
            {
                var res = DBPhieuKQDataSync.PostKQPDF();
                if (res.Result)
                {
                    try
                    {                        
                        PsReponse rese = BioNet_Bus.UpdateDanhSachPDFChuaDongBo(MaPhieuPDF);                          
                        resp.Result = true;                      
                    }
                    catch (Exception ex)
                    {
                        resp.Result = false;
                        resp.StringError = " Đồng Bộ Phiếu PDF thất bại - " + ex;                       
                    }
                }
                else
                {
                    resp.Result = false;
                    resp.StringError = " Đồng Bộ Phiếu PDF thất bại -" + res.StringError;
                }
            }
            else 
            {
                resp.Result = false;
                resp.StringError = "Nén file PDF đồng bộ thất bại - Nén Dữ Liệu Thất Bại";               
            }
            DirectoryInfo dirInfo = new DirectoryInfo(pathdongbo);
            FileInfo[] childFiles = dirInfo.GetFiles();
            foreach (FileInfo childFile in childFiles)
            {
                File.Delete(childFile.FullName);
            }
            return resp;

        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(DiaglogFrm.Waitingfrom), true, true, false);
                Entry.FrmSuaPhieuLoi frm = new Entry.FrmSuaPhieuLoi();
                TabCreating(xTabMain, "Sữa lỗi phiếu đã có kết quả", frm);
                SplashScreenManager.CloseForm();
            }
            catch { }
        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            

        }

        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Đồng Bộ Dữ Liệu Phiếu Kết Quả
            List<PsReponse> res = new List<PsReponse>();
            try
            {
                string Error = null;
                SplashScreenManager.ShowForm(this, typeof(WaitingformLoadDongBo), true, true, false);
                res.Add(PhieuSangLocSync.PostPhieuSangLoc());
                res.Add(PatientSync.PostPatient());
                res.Add(ChiDinhSync.PostChiDinh());
                foreach (var p in res)
                {
                    if (p.Result == false && p.StringError != null)
                    {
                        Error = Error + "\r\n" + p.StringError;
                    }
                }
                SplashScreenManager.CloseForm();
                if (Error == null)
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Phiếu Đã Tiếp Nhận Thành Công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Phiếu Đã Tiếp Nhận Kết Quả Bị Lỗi- Danh Sách Chi Tiết Lỗi: \r\n" + Error, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi Đồng Bộ Dữ Liệu Phiếu Đã Tiếp Nhận - " + ex, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void barButtonItem47_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<PsReponse> res = new List<PsReponse>();
            try
            {
                string Error = null;
                SplashScreenManager.ShowForm(this, typeof(WaitingformLoadDongBo), true, true, false);
                res.Add(PhieuSangLocSync.PostPhieuSangLoc());
                res.Add(PatientSync.PostPatient());
                res.Add(ChiDinhSync.PostChiDinh());
                res.Add(KetQuaSync.PostKetQua());
                foreach (var p in res)
                {
                    if (p.Result == false && p.StringError != null)
                    {
                        Error = Error + "\r\n" + p.StringError;
                    }
                }
                SplashScreenManager.CloseForm();
                if (Error == null)
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Phiếu Phòng Xét Nghiệm Thành Công", "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Đồng Bộ Dữ Liệu Phiếu Phòng Xét Nghiệm Bị Lỗi- Danh Sách Chi Tiết Lỗi: \r\n" + Error, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi Đồng Bộ Dữ Liệu Phiếu Phòng Xét Nghiệm - " + ex, "BioNet - Chương trình sàng lọc sơ sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}