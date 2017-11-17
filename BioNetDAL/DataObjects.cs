using System;
using System.Collections.Generic;
using System.Linq;
using BioNetModel.Data;
using BioNetModel;
using System.Data;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace BioNetDAL
{
    public class DataObjects
    {

        public static BioNetDBContextDataContext db = null;
        public DataObjects()
        {
            try
            {
                string str = calltringconect();
                db = new BioNetDBContextDataContext(str);
                //db = new BioNetDBContextDataContext(DataContext.connectionString);

            }
            catch (Exception ex) { }
        }
        private ServerInfo serverInfo = new ServerInfo();

        public SqlConnection sqlConnection;
        private string calltringconect()
        {
            try
            {
                string connectionstring;
                string pathFileName = (Application.StartupPath) + "\\xml\\configiBionet.xml";
                ServerInfo server = this.LoadFileXml(pathFileName);
                if (server != null && server.Encrypt == "true")
                {
                    this.serverInfo.Encrypt = server.Encrypt;
                    this.serverInfo.ServerName = this.DecryptString(server.ServerName, true);
                    this.serverInfo.Database = this.DecryptString(server.Database, true);
                    this.serverInfo.UserName = this.DecryptString(server.UserName, true);
                    this.serverInfo.Password = this.DecryptString(server.Password, true);
                }
                else
                {
                    this.serverInfo.Encrypt = "false";
                    this.serverInfo.ServerName = "powersoft.vn";
                    this.serverInfo.Database = "Bio";
                    this.serverInfo.UserName = "sa";
                    this.serverInfo.Password = "****";
                }
                connectionstring = "Data Source=" + this.serverInfo.ServerName + ";Initial Catalog=" + this.serverInfo.Database + ";User Id=" + this.serverInfo.UserName + ";Password=" + this.serverInfo.Password + ";";
                return connectionstring;
            }
            catch (Exception ex)
            {
                //this.connectionstring = string.Empty;
                throw new Exception(ex.Message);
            }

        }
        public ServerInfo LoadFileXml(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(ServerInfo));
                return serializer.Deserialize(stream) as ServerInfo;
            }
        }
        public string DecryptString(string toDecrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                if (useHashing)
                {
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("2$Powersoft.vn"));
                }
                else keyArray = Encoding.UTF8.GetBytes("2$Powersoft.vn");
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
            catch { return toDecrypt; }
        }


        #region GET
        //public DataTable GetInKetQua(string maTiepNhan, string maPhieu)
        //{

        //}
        //public List<rptBaoCaoSLPhieu> GetBaoCaoThongTinPhieu(string MaDonVi, string MaChiCuc, string MaTT)
        //{
        //    List<rptBaoCaoSLPhieu> rpt = new List<rptBaoCaoSLPhieu>();
        //    try
        //    {
        //        var TkSlPhieu = (from p in db.pro_Report_ThongKeSLPhieu(MaDonVi, MaChiCuc, MaTT)
        //                         select new
        //                         {
        //                             thang = p.thang,
        //                             slphieu = p.SLphieu

        //                         }).ToList();

        //        if (TkSlPhieu != null)
        //        {


        //            foreach (var tkslphieu in TkSlPhieu)
        //            {
        //                rptBaoCaoSLPhieu tkphieu = new rptBaoCaoSLPhieu();
        //                tkphieu.Thang = tkslphieu.thang ?? 0;
        //                tkphieu.SLphieu = tkslphieu.slphieu ?? 0;
        //                rpt.Add(tkphieu);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return rpt;
        //}
        public TTPhieuCB GetBaoCaoThongTinPhieu(string MaDonVi,string MaChiCuc,string MaTT)
        {
            TTPhieuCB pcb = new TTPhieuCB();
            List<PsThongKeDanhGiaMau> dgm = new List<PsThongKeDanhGiaMau>();
            List< rptBaoCaoSLPhieu> rpt = new List<rptBaoCaoSLPhieu>();
            try {

               var phieucb = db.pro_Report_TTCoBanPhieu(MaDonVi, MaChiCuc, MaTT).FirstOrDefault();
                var TkSlPhieu = (from p in db.pro_Report_ThongKeSLPhieu(MaDonVi, MaChiCuc, MaTT)
                                 select new
                                 {
                                     thang = p.thang,
                                     slphieu = p.SLphieu

                                 }).ToList();
             
                
                if (TkSlPhieu != null && phieucb!=null)
                {
                    foreach (var tkslphieu in TkSlPhieu)
                    {
                        rptBaoCaoSLPhieu tkphieu = new rptBaoCaoSLPhieu();
                        tkphieu.Thang = tkslphieu.thang ?? 0;
                        tkphieu.SLphieu = tkslphieu.slphieu ?? 0;
                        rpt.Add(tkphieu);
                    }
                    pcb.slphieu = rpt;
                    pcb.TongSoPhieu = phieucb.TongSoPhieu ?? 0;
                    pcb.PhieuThuLai = phieucb.PhieuThuLai ?? 0;
                    pcb.PhieuThuMoi = phieucb.PhieuThuMoi ?? 0;
                    pcb.PPSinhMo = phieucb.PPSinhMo ?? 0;
                    pcb.PPSinhThuong = phieucb.PPSinhThuong ?? 0;
                    pcb.PPSinhKhac = phieucb.PPSinhKhac ?? 0;
                    pcb.Nam = phieucb.Nam ?? 0;
                    pcb.Nu = phieucb.Nu ?? 0;
                    pcb.GTKhac = phieucb.GTKhac ?? 0;
                    pcb.MauDat = phieucb.MauDat ?? 0;
                    pcb.MauKoDat = phieucb.MauKoDat ?? 0;
                    
                }
            }
            catch(Exception ex)
            {

            }
            return pcb;
        }
        public rptBaoCaoTongHop GetBaoCaoTongHopTrungTam(DateTime tuNgay, DateTime denNgay)
        {
            rptBaoCaoTongHop rpt = new rptBaoCaoTongHop();
            try
            {
                PsThongTinTrungTam TrungTam = new PsThongTinTrungTam();
                PsThongTinDonVi donvi = new PsThongTinDonVi();
                var ttam = db.PSThongTinTrungTams.FirstOrDefault();
                try
                {
                    TrungTam.DiaChi = ttam.Diachi;
                    TrungTam.DienThoai = ttam.DienThoai;
                    TrungTam.MaTrungTam = ttam.MaTrungTam;
                    TrungTam.MaVietTat = ttam.MaVietTat;
                    TrungTam.TenTrungTam = ttam.TenTrungTam;
                    if (ttam.ChuKiTT.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiTT.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiTT = img;
                        }
                        catch { }
                    }
                    if (ttam.ChuKiXN.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiXN.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiXN = img;
                        }
                        catch { }
                    }
                    if (ttam.Header.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.Header.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Hearder = img;
                        }
                        catch { }
                    }
                    if (ttam.Logo.Length > 0)
                    {

                        try
                        {
                            byte[] b = ttam.Logo.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Logo = img;
                        }
                        catch { }
                    }
                    donvi.TenDonVi = ttam.TenTrungTam;
                    donvi.DiaChi = ttam.Diachi;
                }
                catch { }

                var datatonghop = db.pro_Report_TrungTamCoBan(tuNgay, denNgay).FirstOrDefault();
                if (datatonghop != null)
                {

                    rptBaoCaoTongHop.CAH cah = new rptBaoCaoTongHop.CAH();
                    rptBaoCaoTongHop.CH ch = new rptBaoCaoTongHop.CH();
                    rptBaoCaoTongHop.ChatLuongMau chatluong = new rptBaoCaoTongHop.ChatLuongMau();
                    rptBaoCaoTongHop.ChuongTrinh ctr = new rptBaoCaoTongHop.ChuongTrinh();
                    rptBaoCaoTongHop.G6PD g6pd = new rptBaoCaoTongHop.G6PD();
                    rptBaoCaoTongHop.GAL gal = new rptBaoCaoTongHop.GAL();
                    rptBaoCaoTongHop.GioiTinh gt = new rptBaoCaoTongHop.GioiTinh();
                    rptBaoCaoTongHop.GoiBenh gb = new rptBaoCaoTongHop.GoiBenh();
                    rptBaoCaoTongHop.PhuongPhapSinh pps = new rptBaoCaoTongHop.PhuongPhapSinh();
                    rptBaoCaoTongHop.PKU pku = new rptBaoCaoTongHop.PKU();
                    cah.CAHBinhThuong = datatonghop.CAHBinhThuong ?? 0;
                    cah.CAHBinhThuong_Tong = datatonghop.CAHBinhThuong_Tong;
                    cah.CAHNguyCo = datatonghop.CAHNguyCo ?? 0;
                    cah.CAHNguyCo_Tong = datatonghop.CAHNguyCo_Tong;
                    cah.CAHTong = datatonghop.CAHTong ?? 0;
                    ch.CHBinhThuong = datatonghop.CHBinhThuong ?? 0;
                    ch.CHBinhThuong_Tong = datatonghop.CHBinhThuong_Tong;
                    ch.CHNguyCo = datatonghop.CHNguyCo ?? 0;
                    ch.CHNguyCo_Tong = datatonghop.CHNguyCo_Tong;
                    ch.CHTong = datatonghop.CHTong ?? 0;
                    chatluong.Dat = datatonghop.Dat ?? 0;
                    chatluong.KhongDat = datatonghop.KhongDat ?? 0;
                    ctr.QuocGia = datatonghop.QuocGia ?? 0;
                    ctr.XaHoiHoa = datatonghop.XaHoi ?? 0;
                    g6pd.G6PDBinhThuong = datatonghop.G6PDBinhThuong ?? 0;
                    g6pd.G6PDBinhThuong_Tong = datatonghop.G6PDBinhThuong_Tong;
                    g6pd.G6PDNguyCo = datatonghop.G6PDNguyCo ?? 0;
                    g6pd.G6PDNguyCo_Tong = datatonghop.G6PDNguyCo_Tong;
                    g6pd.G6PDTong = datatonghop.G6PDTong ?? 0;
                    gal.GALBinhThuong = datatonghop.GALBinhThuong ?? 0;
                    gal.GALBinhThuong_Tong = datatonghop.GALBinhThuong_Tong;
                    gal.GALNguyCo = datatonghop.GALNguyCo ?? 0;
                    gal.GALNguyCo_Tong = datatonghop.GALNguyCo_Tong;
                    gal.GALTong = datatonghop.GALTong ?? 0;
                    gt.GTNa = datatonghop.KhongXacDinh ?? 0;
                    gt.GTNam = datatonghop.Nam ?? 0;
                    gt.GTNu = datatonghop.Nu ?? 0;
                    gb.sl2Benh = datatonghop.SL2Benh ?? 0;
                    gb.sl3Benh = datatonghop.SL3Benh ?? 0;
                    gb.sl5Benh = datatonghop.SL5Benh ?? 0;
                    gb.slThuLai = datatonghop.SLThuLai ?? 0;
                    pps.SinhMo = datatonghop.SinhMo ?? 0;
                    pps.SinhNa = datatonghop.KhongXacDinhSinh ?? 0;
                    pps.SinhThuong = datatonghop.SinhThuong ?? 0;
                    pku.PKUBinhThuong = datatonghop.PKUBinhThuong ?? 0;
                    pku.PKUNguyCo = datatonghop.PKUNguyCo ?? 0;
                    pku.PKUTong = datatonghop.PKUTong ?? 0;
                    pku.PUKBinhThuong_Tong = datatonghop.PKUBinhThuong_Tong;
                    pku.PUKNguyCo_Tong = datatonghop.PKUNguyCo_Tong;
                    rpt.cAH = cah;
                    rpt.cH = ch;
                    rpt.chatLuongMau = chatluong;
                    rpt.chuongTrinh = ctr;
                    rpt.g6PD = g6pd;
                    rpt.gAL = gal;
                    rpt.gioiTinh = gt;
                    rpt.goiBenh = gb;
                    rpt.phuongPhapSinh = pps;
                    rpt.pKU = pku;
                    rpt.SoLuongMau = datatonghop.SoPhieu ?? 0;
                    rpt.TrungTam = TrungTam;
                    rpt.Donvi = donvi;
                    rpt.tuNgay = tuNgay;
                    rpt.denNgay = denNgay;
                }
            }
            catch { }
            return rpt;
        }
        public rptBaoCaoTongHop GetBaoCaoTongHopChiCuc(DateTime tuNgay, DateTime denNgay, string maChiCuc)
        {
            rptBaoCaoTongHop rpt = new rptBaoCaoTongHop();
            try
            {
                PsThongTinTrungTam TrungTam = new PsThongTinTrungTam();
                PsThongTinDonVi DonVi = new PsThongTinDonVi();
                var ttam = db.PSThongTinTrungTams.FirstOrDefault();
                var chicuc = db.PSDanhMucChiCucs.FirstOrDefault(p => p.MaChiCuc == maChiCuc);
                try
                {

                    TrungTam.DiaChi = ttam.Diachi;
                    TrungTam.DienThoai = ttam.DienThoai;
                    TrungTam.MaTrungTam = ttam.MaTrungTam;
                    TrungTam.TenTrungTam = ttam.TenTrungTam;
                    TrungTam.MaVietTat = ttam.MaVietTat;
                    if (ttam.ChuKiTT.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiTT.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiTT = img;
                        }
                        catch { }
                    }
                    if (ttam.ChuKiXN.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiXN.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiXN = img;
                        }
                        catch { }
                    }
                    if (ttam.Header.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.Header.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Hearder = img;
                        }
                        catch { }
                    }
                    if (ttam.Logo.Length > 0)
                    {

                        try
                        {
                            byte[] b = ttam.Logo.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Logo = img;
                        }
                        catch { }
                    }
                    DonVi.TenDonVi = chicuc.TenChiCuc;
                    DonVi.DiaChi = chicuc.DiaChiChiCuc;
                }
                catch { }

                var datatonghop = db.pro_Report_ChiCucCoBan(tuNgay, denNgay, maChiCuc).FirstOrDefault();
                if (datatonghop != null)
                {

                    rptBaoCaoTongHop.CAH cah = new rptBaoCaoTongHop.CAH();
                    rptBaoCaoTongHop.CH ch = new rptBaoCaoTongHop.CH();
                    rptBaoCaoTongHop.ChatLuongMau chatluong = new rptBaoCaoTongHop.ChatLuongMau();
                    rptBaoCaoTongHop.ChuongTrinh ctr = new rptBaoCaoTongHop.ChuongTrinh();
                    rptBaoCaoTongHop.G6PD g6pd = new rptBaoCaoTongHop.G6PD();
                    rptBaoCaoTongHop.GAL gal = new rptBaoCaoTongHop.GAL();
                    rptBaoCaoTongHop.GioiTinh gt = new rptBaoCaoTongHop.GioiTinh();
                    rptBaoCaoTongHop.GoiBenh gb = new rptBaoCaoTongHop.GoiBenh();
                    rptBaoCaoTongHop.PhuongPhapSinh pps = new rptBaoCaoTongHop.PhuongPhapSinh();
                    rptBaoCaoTongHop.PKU pku = new rptBaoCaoTongHop.PKU();
                    cah.CAHBinhThuong = datatonghop.CAHBinhThuong ?? 0;
                    cah.CAHBinhThuong_Tong = datatonghop.CAHBinhThuong_Tong;
                    cah.CAHNguyCo = datatonghop.CAHNguyCo ?? 0;
                    cah.CAHNguyCo_Tong = datatonghop.CAHNguyCo_Tong;
                    cah.CAHTong = datatonghop.CAHTong ?? 0;
                    ch.CHBinhThuong = datatonghop.CHBinhThuong ?? 0;
                    ch.CHBinhThuong_Tong = datatonghop.CHBinhThuong_Tong;
                    ch.CHNguyCo = datatonghop.CHNguyCo ?? 0;
                    ch.CHNguyCo_Tong = datatonghop.CHNguyCo_Tong;
                    ch.CHTong = datatonghop.CHTong ?? 0;
                    chatluong.Dat = datatonghop.Dat ?? 0;
                    chatluong.KhongDat = datatonghop.KhongDat ?? 0;
                    ctr.QuocGia = datatonghop.QuocGia ?? 0;
                    ctr.XaHoiHoa = datatonghop.XaHoi ?? 0;
                    g6pd.G6PDBinhThuong = datatonghop.G6PDBinhThuong ?? 0;
                    g6pd.G6PDBinhThuong_Tong = datatonghop.G6PDBinhThuong_Tong;
                    g6pd.G6PDNguyCo = datatonghop.G6PDNguyCo ?? 0;
                    g6pd.G6PDNguyCo_Tong = datatonghop.G6PDNguyCo_Tong;
                    g6pd.G6PDTong = datatonghop.G6PDTong ?? 0;
                    gal.GALBinhThuong = datatonghop.GALBinhThuong ?? 0;
                    gal.GALBinhThuong_Tong = datatonghop.GALBinhThuong_Tong;
                    gal.GALNguyCo = datatonghop.GALNguyCo ?? 0;
                    gal.GALNguyCo_Tong = datatonghop.GALNguyCo_Tong;
                    gal.GALTong = datatonghop.GALTong ?? 0;
                    gt.GTNa = datatonghop.KhongXacDinh ?? 0;
                    gt.GTNam = datatonghop.Nam ?? 0;
                    gt.GTNu = datatonghop.Nu ?? 0;
                    gb.sl2Benh = datatonghop.SL2Benh ?? 0;
                    gb.sl3Benh = datatonghop.SL3Benh ?? 0;
                    gb.sl5Benh = datatonghop.SL5Benh ?? 0;
                    gb.slThuLai = datatonghop.SLThuLai ?? 0;
                    pps.SinhMo = datatonghop.SinhMo ?? 0;
                    pps.SinhNa = datatonghop.KhongXacDinhSinh ?? 0;
                    pps.SinhThuong = datatonghop.SinhThuong ?? 0;
                    pku.PKUBinhThuong = datatonghop.PKUBinhThuong ?? 0;
                    pku.PKUNguyCo = datatonghop.PKUNguyCo ?? 0;
                    pku.PKUTong = datatonghop.PKUTong ?? 0;
                    pku.PUKBinhThuong_Tong = datatonghop.PKUBinhThuong_Tong;
                    pku.PUKNguyCo_Tong = datatonghop.PKUNguyCo_Tong;
                    rpt.cAH = cah;
                    rpt.cH = ch;
                    rpt.chatLuongMau = chatluong;
                    rpt.chuongTrinh = ctr;
                    rpt.g6PD = g6pd;
                    rpt.gAL = gal;
                    rpt.gioiTinh = gt;
                    rpt.goiBenh = gb;
                    rpt.phuongPhapSinh = pps;
                    rpt.pKU = pku;
                    rpt.SoLuongMau = datatonghop.SoPhieu ?? 0;
                    rpt.TrungTam = TrungTam;
                    rpt.Donvi = DonVi;
                    rpt.tuNgay = tuNgay;
                    rpt.denNgay = denNgay;
                }
            }
            catch (Exception ex) { }
            return rpt;
        }
        public PsReponse CapNhatLisence(string key)
        {
            PsReponse res = new PsReponse();

            try
            {
                var tt = db.PSThongTinTrungTams.FirstOrDefault();
                if (tt != null)
                {
                    tt.LicenseKey = key;
                    tt.isDongBo = false;
                    db.SubmitChanges();
                    res.Result = true;
                }
                else
                {
                    res.Result = false;
                    res.StringError = "Chưa có thông tin trung tâm, vui lòng đăng nhập lại!";
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError = ex.ToString();
            }
            return res;
        }

        //public string GetMaPhieuNhapMoi()
        // {
        //     try
        //     {
        //        // string sodb = SoBanDau();
        //         string maTC = "PN" + SoBanDau();
        //         var soht = db.BangGhiDuLieus.FirstOrDefault(p => p.MaDuLieu == maTC);
        //         if()
        //     }
        //     catch { }
        // }

        public List<PSDanhMucVatTu> GetDanhMucVatTu()
        {
            List<PSDanhMucVatTu> lst = new List<PSDanhMucVatTu>();
            try
            {
                var vts = db.PSDanhMucVatTus.ToList();
                if (vts.Count > 0)
                {
                    return vts;
                }
            }
            catch { }
            return lst;
        }

        public List<PSNhaCungCap> GetDanhMucNhaCungCap()
        {
            List<PSNhaCungCap> lst = new List<PSNhaCungCap>();
            try
            {
                var nccs = db.PSNhaCungCaps.ToList();
                if (nccs.Count > 0)
                    return nccs;
            }
            catch { }
            return lst;
        }
        public List<PSDanhMucThongSoXN> GetDanhMucThongSoXN()
        {
            List<PSDanhMucThongSoXN> lst = new List<PSDanhMucThongSoXN>();
            try
            {
                var nccs = db.PSDanhMucThongSoXNs.ToList();
                if (nccs.Count > 0)
                    return nccs;
            }
            catch { }
            return lst;
        }
        public rptChiTietTrungTam GetBaoCaoChiCucTongHopChiTietTheoDonVi(DateTime tuNgay, DateTime denNgay, string maChiCuc)
        {
            rptChiTietTrungTam rpt = new rptChiTietTrungTam();
            try
            {
                PsThongTinTrungTam TrungTam = new PsThongTinTrungTam();
                List<rptChiTietTrungTam_ChiTiet> lstdata = new List<rptChiTietTrungTam_ChiTiet>();
                var data = db.pro_Report_ChiCucChiTietTheoTungDonVi(tuNgay, denNgay, maChiCuc).ToList();
                if (data != null)
                {
                    int stt = 0;
                    foreach (var rd in data)
                    {
                        rptChiTietTrungTam_ChiTiet dt = new rptChiTietTrungTam_ChiTiet();
                        dt.CAH = rd.CAHNguyCo ?? 0 + rd.CAHBinhThuong ?? 0;
                        dt.CAHBinhThuong = rd.CAHBinhThuong ?? 0;
                        dt.CAHBinhThuong_Tong = rd.CAHBinhThuong_Tong;
                        dt.CAHNguyCo = rd.CAHNguyCo ?? 0;
                        dt.CAHNguyCo_Tong = rd.CAHNguyCo_Tong;
                        dt.CH = rd.CHBinhThuong ?? 0 + rd.CHNguyCo ?? 0;
                        dt.CHBinhThuong = rd.CHBinhThuong ?? 0;
                        dt.CHBinhThuong_Tong = rd.CHBinhThuong_Tong;
                        dt.CHNguyCo = rd.CHNguyCo ?? 0;
                        dt.CHNguyCo_Tong = rd.CHNguyCo_Tong;
                        dt.Dat = rd.Dat ?? 0;
                        dt.G6PD = rd.G6PDBinhThuong ?? 0 + rd.G6PDNguyCo ?? 0;
                        dt.G6PDBinhThuong = rd.G6PDBinhThuong ?? 0;
                        dt.G6PDBinhThuong_Tong = rd.G6PDBinhThuong_Tong;
                        dt.G6PDNguyCo = rd.G6PDNguyCo ?? 0;
                        dt.G6PDNguyCo_Tong = rd.G6PDNguyCo_Tong;
                        dt.GAL = rd.GALBinhThuong ?? 0 + rd.GALNguyCo ?? 0;
                        dt.GALBinhThuong = rd.GALBinhThuong ?? 0;
                        dt.GALBinhThuong_Tong = rd.GALBinhThuong_Tong;
                        dt.GALNguyCo = rd.GALNguyCo ?? 0;
                        dt.GALNguyCo_Tong = rd.GALNguyCo_Tong;
                        dt.GTNa = rd.KhongXacDinh ?? 0;
                        dt.GTNam = rd.Nam ?? 0;
                        dt.GTNu = rd.Nu ?? 0;
                        dt.KhongDat = rd.KhongDat ?? 0;
                        dt.MaChiCuc = rd.MaChiCuc;
                        dt.TenChiCuc = rd.ChiCuc;
                        dt.MaDonVi = rd.MaDonVi;
                        dt.TenDonVi = rd.TenDonVi;
                        dt.XaHoiHoa = rd.XaHoi ?? 0;
                        dt.PKU = rd.PKUBinhThuong ?? 0 + rd.PKUNguyCo ?? 0;
                        dt.PKUNguyCo = rd.PKUNguyCo ?? 0;
                        dt.PUKBinhThuong_Tong = rd.PKUBinhThuong_Tong;
                        dt.PKUBinhThuong = rd.PKUBinhThuong ?? 0;
                        dt.PUKNguyCo_Tong = rd.PKUNguyCo_Tong;
                        dt.QuocGia = rd.QuocGia ?? 0;
                        dt.SinhMo = rd.SinhMo ?? 0;
                        dt.SinhNa = rd.KhongXacDinhSinh ?? 0;
                        dt.SinhThuong = rd.SinhThuong ?? 0;
                        dt.sl2Benh = rd.SL2Benh ?? 0;
                        dt.sl3Benh = rd.SL3Benh ?? 0;
                        dt.sl5Benh = rd.SL5Benh ?? 0;
                        dt.slMauThuLai = rd.SLThuLai ?? 0;
                        dt.SoLuongMau = rd.SoPhieu ?? 0;
                        dt.Stt = (stt + 1).ToString();
                        lstdata.Add(dt);
                    }
                }
                var ttam = db.PSThongTinTrungTams.FirstOrDefault();
                try
                {
                    TrungTam.DiaChi = ttam.Diachi;
                    TrungTam.DienThoai = ttam.DienThoai;
                    TrungTam.MaTrungTam = ttam.MaTrungTam;
                    TrungTam.MaVietTat = ttam.MaVietTat;
                    TrungTam.TenTrungTam = ttam.TenTrungTam;
                    if (ttam.ChuKiTT.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiTT.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiTT = img;
                        }
                        catch { }
                    }
                    if (ttam.ChuKiXN.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiXN.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiXN = img;
                        }
                        catch { }
                    }
                    if (ttam.Header.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.Header.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Hearder = img;
                        }
                        catch { }
                    }
                    if (ttam.Logo.Length > 0)
                    {

                        try
                        {
                            byte[] b = ttam.Logo.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Logo = img;
                        }
                        catch { }
                    }
                }
                catch { }
                rpt.TuNgay = tuNgay;
                rpt.DenNgay = denNgay;
                rpt.ThongTinTrungTam = TrungTam;
                rpt.ChiTietCacChiCuc = lstdata;
                return rpt;
            }
            catch
            {
                return rpt;
            }
        }
        public rptChiTietTrungTam GetBaoCaoTrungTamTongHopChiTietTheoDonVi(DateTime tuNgay, DateTime denNgay)
        {
            rptChiTietTrungTam rpt = new rptChiTietTrungTam();
            try
            {
                PsThongTinTrungTam TrungTam = new PsThongTinTrungTam();
                List<rptChiTietTrungTam_ChiTiet> lstdata = new List<rptChiTietTrungTam_ChiTiet>();
                var data = db.pro_Report_TrungTamChiTietTheoTungDonVi(tuNgay, denNgay).ToList();
                if (data != null)
                {
                    int stt = 0;
                    foreach (var rd in data)
                    {
                        rptChiTietTrungTam_ChiTiet dt = new rptChiTietTrungTam_ChiTiet();
                        dt.CAH = rd.CAHNguyCo ?? 0 + rd.CAHBinhThuong ?? 0;
                        dt.CAHBinhThuong = rd.CAHBinhThuong ?? 0;
                        dt.CAHBinhThuong_Tong = rd.CAHBinhThuong_Tong;
                        dt.CAHNguyCo = rd.CAHNguyCo ?? 0;
                        dt.CAHNguyCo_Tong = rd.CAHNguyCo_Tong;
                        dt.CH = rd.CHBinhThuong ?? 0 + rd.CHNguyCo ?? 0;
                        dt.CHBinhThuong = rd.CHBinhThuong ?? 0;
                        dt.CHBinhThuong_Tong = rd.CHBinhThuong_Tong;
                        dt.CHNguyCo = rd.CHNguyCo ?? 0;
                        dt.CHNguyCo_Tong = rd.CHNguyCo_Tong;
                        dt.Dat = rd.Dat ?? 0;
                        dt.G6PD = rd.G6PDBinhThuong ?? 0 + rd.G6PDNguyCo ?? 0;
                        dt.G6PDBinhThuong = rd.G6PDBinhThuong ?? 0;
                        dt.G6PDBinhThuong_Tong = rd.G6PDBinhThuong_Tong;
                        dt.G6PDNguyCo = rd.G6PDNguyCo ?? 0;
                        dt.G6PDNguyCo_Tong = rd.G6PDNguyCo_Tong;
                        dt.GAL = rd.GALBinhThuong ?? 0 + rd.GALNguyCo ?? 0;
                        dt.GALBinhThuong = rd.GALBinhThuong ?? 0;
                        dt.GALBinhThuong_Tong = rd.GALBinhThuong_Tong;
                        dt.GALNguyCo = rd.GALNguyCo ?? 0;
                        dt.GALNguyCo_Tong = rd.GALNguyCo_Tong;
                        dt.GTNa = rd.KhongXacDinh ?? 0;
                        dt.GTNam = rd.Nam ?? 0;
                        dt.GTNu = rd.Nu ?? 0;
                        dt.KhongDat = rd.KhongDat ?? 0;
                        dt.MaChiCuc = rd.MaChiCuc;
                        dt.TenChiCuc = rd.ChiCuc;
                        dt.MaDonVi = rd.MaDonVi;
                        dt.TenDonVi = rd.TenDonVi;
                        dt.XaHoiHoa = rd.XaHoi ?? 0;
                        dt.PKU = rd.PKUBinhThuong ?? 0 + rd.PKUNguyCo ?? 0;
                        dt.PKUNguyCo = rd.PKUNguyCo ?? 0;
                        dt.PUKBinhThuong_Tong = rd.PKUBinhThuong_Tong;
                        dt.PKUBinhThuong = rd.PKUBinhThuong ?? 0;
                        dt.PUKNguyCo_Tong = rd.PKUNguyCo_Tong;
                        dt.QuocGia = rd.QuocGia ?? 0;
                        dt.SinhMo = rd.SinhMo ?? 0;
                        dt.SinhNa = rd.KhongXacDinhSinh ?? 0;
                        dt.SinhThuong = rd.SinhThuong ?? 0;
                        dt.sl2Benh = rd.SL2Benh ?? 0;
                        dt.sl3Benh = rd.SL3Benh ?? 0;
                        dt.sl5Benh = rd.SL5Benh ?? 0;
                        dt.slMauThuLai = rd.SLThuLai ?? 0;
                        dt.SoLuongMau = rd.SoPhieu ?? 0;
                        dt.Stt = (stt + 1).ToString();
                        lstdata.Add(dt);
                    }
                }
                var ttam = db.PSThongTinTrungTams.FirstOrDefault();
                try
                {
                    TrungTam.DiaChi = ttam.Diachi;
                    TrungTam.DienThoai = ttam.DienThoai;
                    TrungTam.MaTrungTam = ttam.MaTrungTam;
                    TrungTam.MaVietTat = ttam.MaVietTat;
                    TrungTam.TenTrungTam = ttam.TenTrungTam;
                    if (ttam.ChuKiTT.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiTT.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiTT = img;
                        }
                        catch { }
                    }
                    if (ttam.ChuKiXN.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiXN.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiXN = img;
                        }
                        catch { }
                    }
                    if (ttam.Header.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.Header.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Hearder = img;
                        }
                        catch { }
                    }
                    if (ttam.Logo.Length > 0)
                    {

                        try
                        {
                            byte[] b = ttam.Logo.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Logo = img;
                        }
                        catch { }
                    }
                }
                catch { }
                rpt.TuNgay = tuNgay;
                rpt.DenNgay = denNgay;
                rpt.ThongTinTrungTam = TrungTam;
                rpt.ChiTietCacChiCuc = lstdata;
                return rpt;
            }
            catch
            {
                return rpt;
            }
        }
        public PsReponse DelPhieuTiepNhan(string maPhieu,string maBenhNhan)
        {
            PsReponse res = new PsReponse();
            try
            {
                var phieu = db.PSPhieuSangLocs.FirstOrDefault(x => x.IDPhieu == maPhieu);
                var patient = db.PSPatients.FirstOrDefault(x => x.MaBenhNhan == maBenhNhan);
                db.PSPhieuSangLocs.DeleteOnSubmit(phieu);
                db.PSPatients.DeleteOnSubmit(patient);
                db.SubmitChanges();
                res.Result = true;
            }
            catch
            {
                res.Result = false;

            }
            return res;
        }
        public rptChiTietTrungTam GetBaoCaoTrungTamTongHopChiTietTheoChiCuc(DateTime tuNgay, DateTime denNgay)
        {
            rptChiTietTrungTam rpt = new rptChiTietTrungTam();
            try
            {
                PsThongTinTrungTam TrungTam = new PsThongTinTrungTam();
                List<rptChiTietTrungTam_ChiTiet> lstdata = new List<rptChiTietTrungTam_ChiTiet>();
                var data = db.pro_Report_TrungTamChiTietTheoTungChiCuc(tuNgay, denNgay).ToList();
                if (data != null)
                {
                    int stt = 0;
                    foreach (var rd in data)
                    {
                        rptChiTietTrungTam_ChiTiet dt = new rptChiTietTrungTam_ChiTiet();
                        dt.CAH = rd.CAHNguyCo ?? 0 + rd.CAHBinhThuong ?? 0;
                        dt.CAHBinhThuong = rd.CAHBinhThuong ?? 0;
                        dt.CAHBinhThuong_Tong = rd.CAHBinhThuong_Tong;
                        dt.CAHNguyCo = rd.CAHNguyCo ?? 0;
                        dt.CAHNguyCo_Tong = rd.CAHNguyCo_Tong;
                        dt.CH = rd.CHBinhThuong ?? 0 + rd.CHNguyCo ?? 0;
                        dt.CHBinhThuong = rd.CHBinhThuong ?? 0;
                        dt.CHBinhThuong_Tong = rd.CHBinhThuong_Tong;
                        dt.CHNguyCo = rd.CHNguyCo ?? 0;
                        dt.CHNguyCo_Tong = rd.CHNguyCo_Tong;
                        dt.Dat = rd.Dat ?? 0;
                        dt.G6PD = rd.G6PDBinhThuong ?? 0 + rd.G6PDNguyCo ?? 0;
                        dt.G6PDBinhThuong = rd.G6PDBinhThuong ?? 0;
                        dt.G6PDBinhThuong_Tong = rd.G6PDBinhThuong_Tong;
                        dt.G6PDNguyCo = rd.G6PDNguyCo ?? 0;
                        dt.G6PDNguyCo_Tong = rd.G6PDNguyCo_Tong;
                        dt.GAL = rd.GALBinhThuong ?? 0 + rd.GALNguyCo ?? 0;
                        dt.GALBinhThuong = rd.GALBinhThuong ?? 0;
                        dt.GALBinhThuong_Tong = rd.GALBinhThuong_Tong;
                        dt.GALNguyCo = rd.GALNguyCo ?? 0;
                        dt.GALNguyCo_Tong = rd.GALNguyCo_Tong;
                        dt.GTNa = rd.KhongXacDinh ?? 0;
                        dt.GTNam = rd.Nam ?? 0;
                        dt.GTNu = rd.Nu ?? 0;
                        dt.KhongDat = rd.KhongDat ?? 0;
                        dt.MaChiCuc = rd.MaChiCuc;
                        dt.TenChiCuc = rd.ChiCuc;
                        dt.XaHoiHoa = rd.XaHoi ?? 0;
                        dt.PKU = rd.PKUBinhThuong ?? 0 + rd.PKUNguyCo ?? 0;
                        dt.PKUNguyCo = rd.PKUNguyCo ?? 0;
                        dt.PUKBinhThuong_Tong = rd.PKUBinhThuong_Tong;
                        dt.PKUBinhThuong = rd.PKUBinhThuong ?? 0;
                        dt.PUKNguyCo_Tong = rd.PKUNguyCo_Tong;
                        dt.QuocGia = rd.QuocGia ?? 0;
                        dt.SinhMo = rd.SinhMo ?? 0;
                        dt.SinhNa = rd.KhongXacDinhSinh ?? 0;
                        dt.SinhThuong = rd.SinhThuong ?? 0;
                        dt.sl2Benh = rd.SL2Benh ?? 0;
                        dt.sl3Benh = rd.SL3Benh ?? 0;
                        dt.sl5Benh = rd.SL5Benh ?? 0;
                        dt.slMauThuLai = rd.SLThuLai ?? 0;
                        dt.SoLuongMau = rd.SoPhieu ?? 0;
                        dt.Stt = (stt + 1).ToString();
                        lstdata.Add(dt);
                    }
                }
                var ttam = db.PSThongTinTrungTams.FirstOrDefault();
                try
                {
                    TrungTam.DiaChi = ttam.Diachi;
                    TrungTam.DienThoai = ttam.DienThoai;
                    TrungTam.MaTrungTam = ttam.MaTrungTam;
                    TrungTam.MaVietTat = ttam.MaVietTat;
                    TrungTam.TenTrungTam = ttam.TenTrungTam;
                    if (ttam.ChuKiTT.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiTT.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiTT = img;
                        }
                        catch { }
                    }
                    if (ttam.ChuKiXN.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.ChuKiXN.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.ChuKiXN = img;
                        }
                        catch { }
                    }
                    if (ttam.Header.Length > 0)
                    {
                        try
                        {
                            byte[] b = ttam.Header.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Hearder = img;
                        }
                        catch { }
                    }
                    if (ttam.Logo.Length > 0)
                    {

                        try
                        {
                            byte[] b = ttam.Logo.ToArray();
                            MemoryStream ms = new MemoryStream(b);
                            Image img = Image.FromStream(ms);
                            TrungTam.Logo = img;
                        }
                        catch { }
                    }
                }
                catch { }
                rpt.TuNgay = tuNgay;
                rpt.DenNgay = denNgay;
                rpt.ThongTinTrungTam = TrungTam;
                rpt.ChiTietCacChiCuc = lstdata;
                return rpt;
            }
            catch (Exception ex)
            {
                return rpt;
            }
        }
        public DataTable GetBaoCaoTrungTamTongHopCoBan(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                var data = db.pro_Report_TrungTamCoBan(tuNgay, denNgay).ToList();
                return ToDataTable(data);
            }
            catch
            {
                return new DataTable();
            }
        }
        public bool KiemTraChoPhepThuMauLan2()
        {
            try
            {
                return db.PSThongTinTrungTams.FirstOrDefault().isChoThuLaiMauLan2 ?? false;
            }
            catch { return false; }
        }
        public bool KiemTraChoPhepLamLaiXetNghiemLan2()
        {
            try
            {
                return db.PSThongTinTrungTams.FirstOrDefault().isChoXNLan2 ?? false;
            }
            catch { return false; }
        }
        public string GetGhiChuPhongXetNghiem(string maKQ)
        {
            string res = "Ghi chú xét nghiệm : \r\n";
            try
            {
                if (!string.IsNullOrEmpty(maKQ))
                {
                    var KQ = db.PSXN_KetQuas.FirstOrDefault(p => p.MaKetQua == maKQ && p.isXoa == false);
                    if (KQ != null)
                    {
                        if (!string.IsNullOrEmpty(KQ.GhiChu))
                            res = KQ.GhiChu;
                    }
                }
                return res;
            }
            catch { return null; }

        }
        public PSThongTinTrungTam GetThongTinTrungTam()
        {
            PSThongTinTrungTam tt = new PSThongTinTrungTam();
            try
            {
                tt = db.PSThongTinTrungTams.FirstOrDefault();
            }
            catch(Exception ex) { }
            return tt;
        }
        public PSEmployee GetThongTinNhanVien(string maNV)
        {
            PSEmployee NV = new PSEmployee();
            try
            {
                NV = db.PSEmployees.FirstOrDefault(p => p.EmployeeCode == maNV);
            }
            catch { }
            return NV;
        }

        public bool KiemTraMauDaLamLaiXetNghiemLan2DaVaoQuyTrinhXetNghieHayChua(string maPhieu, string maDonvi)
        {
            try
            {
                var res = db.PSXN_KetQuas.Where(p => p.MaPhieu == maPhieu && p.MaDonVi == maDonvi && p.isXoa == false).ToList();
                if (res.Count > 1) return true;
                else return false;
            }
            catch { return false; }
        }
        public int KiemTraTrangThaiPhieu(string maPhieu, string maDonVi)
        {
            try
            {
                var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieu == maPhieu && p.IDCoSo == maDonVi && p.isXoa == false);
                if (phieu != null)
                {
                    return phieu.TrangThaiMau ?? 0;
                }
                else { return 0; }
            }
            catch { return 0; }
        }
        public bool KiemTraMauDaLamLaiXetNghiemLan2(string maPhieu)
        {
            try
            {
                var res = db.PSChiDinhDichVus.Where(p => p.MaPhieu == maPhieu && p.isXoa == false).ToList();
                if (res.Count > 1) return true;
                else return false;
            }
            catch { return false; }
        }
        public string GetThongTinMaTiepNhan(string maPhieu, string maDonVi)
        {

            try
            {
                var phieu = db.PSXN_TraKetQuas.FirstOrDefault(p => p.MaPhieu == maPhieu && p.IDCoSo == maDonVi && p.isXoa == false);
                if (phieu != null)
                {
                    return phieu.MaTiepNhan;
                }
                else { return null; }
            }
            catch { return null; }
        }
        public PSDanhMucGhiChu GetThongTinHienThiGhiChu(string maGhiChu)
        {
            PSDanhMucGhiChu gc = new PSDanhMucGhiChu();
            try
            {
                if (!string.IsNullOrEmpty(maGhiChu))
                {
                    var res = db.PSDanhMucGhiChus.FirstOrDefault(p => p.MaGhiChu == maGhiChu);
                    if (res != null)
                        return res;
                    else return gc;
                }
                else
                {
                    return gc;
                }
            }
            catch
            {
                return gc;
            }
        }

        public List<PsTinhTrangPhieu> GetTinhTrangPhieu(DateTime startdate, DateTime enddate, string maDonVi)
        {
            string donvi = "";
            List<PsTinhTrangPhieu> lst = new List<PsTinhTrangPhieu>();
            try
            {

                if (maDonVi != null && !maDonVi.Equals("all"))
                {
                    donvi = maDonVi;
                    //return db.PSPhieuSangLocs.Where(p => p.NgayNhanMau.Value.Date >= startdate.Date && p.NgayNhanMau.Value.Date <= enddate.Date && p.IDCoSo == maDonVi).ToList();
                }
                else
                {
                    maDonVi = "";
                }

                var data = db.pro_Report_TrungTamTinhTrangMau(startdate, enddate, donvi).ToList();



                if (data.Count > 0)
                {
                    foreach (var _data in data)
                    {
                        PsTinhTrangPhieu tt = new PsTinhTrangPhieu();
                        tt.DiaChi = _data.DiaChi;
                        tt.IDPhieu = _data.IDPhieu;
                        tt.MaBenhNhan = _data.MaBenhNhan;
                        tt.MaDonVi = _data.MaDVCS;
                        tt.MaKhachHang = _data.MaKhachHang;
                        tt.NamSinhCha = _data.FatherBirthday ?? DateTime.Now;
                        tt.NamSinhMe = _data.MotherBirthday ?? DateTime.Now;
                        tt.NgayNhanMau = _data.NgayNhanMau ?? DateTime.Now;
                        tt.SdtCha = _data.FatherPhoneNumber;
                        tt.SdtMe = _data.MotherPhoneNumber;
                        tt.TenMe = _data.MotherName;
                        tt.TenBenhNhan = _data.TenBenhNhan;
                        tt.TenDonVi = _data.TenDVCS;
                        tt.TinhTrangMau_Text = _data.TrangThaiMau_Text;
                        tt.TinhTrangMau = _data.TrangThaiMau ?? 0;
                        lst.Add(tt);
                    }
                }
            }
            catch { }
            return lst;
        }
        public List<PsTinhTrangPhieu> GetTTPhieuCanSuaLoi(DateTime startdate, DateTime enddate, string maDonVi,string maphieu)
        {
            string donvi = "";
            List<PsTinhTrangPhieu> lst = new List<PsTinhTrangPhieu>();
            try
            {

                if (maphieu != null && maphieu != "")
                {
                    var da = (from l in db.PSPhieuSangLocs
                              join p in db.PSPatients on l.MaBenhNhan equals p.MaBenhNhan
                              join dv in db.PSDanhMucDonViCoSos on l.IDCoSo equals dv.MaDVCS
                              where l.IDPhieu == maphieu && (l.TrangThaiMau==7 ||l.TrangThaiMau==4 ||l.TrangThaiMau==6)
                              select new { l, p, dv }).SingleOrDefault();

                    if (da != null)
                    {

                        PsTinhTrangPhieu tt = new PsTinhTrangPhieu();
                        tt.DiaChi = da.p.DiaChi;
                        tt.IDPhieu = da.l.IDPhieu;
                        tt.MaBenhNhan = da.p.MaBenhNhan;
                        tt.MaDonVi = da.l.IDCoSo;
                        tt.MaKhachHang = da.p.MaKhachHang;
                        tt.NamSinhCha = da.p.FatherBirthday ?? DateTime.Now;
                        tt.NamSinhMe = da.p.MotherBirthday ?? DateTime.Now;
                        tt.NgayNhanMau = da.l.NgayNhanMau ?? DateTime.Now;
                        tt.SdtCha = da.p.FatherPhoneNumber;
                        tt.SdtMe = da.p.MotherPhoneNumber;
                        tt.TenMe = da.p.MotherName;
                        tt.TenBenhNhan = da.p.TenBenhNhan;
                        tt.TenDonVi = da.dv.TenDVCS;
                        tt.TinhTrangMau = da.l.TrangThaiMau ?? 0;
                        switch (tt.TinhTrangMau)
                        {
                            case 1:
                                tt.TinhTrangMau_Text = "Đã tiếp nhận";
                                break;
                            case 2:
                                tt.TinhTrangMau_Text = "Đã đánh giá";
                                break;
                            case 3:
                                tt.TinhTrangMau_Text = "Đã vào phòng xét nghiệm";
                                break;
                            case 4:
                                tt.TinhTrangMau_Text = "Đã có kết quả";
                                break;
                            case 5:
                                tt.TinhTrangMau_Text = "Đang xét nghiệm lại lần 2";
                                break;
                            case 6:
                                tt.TinhTrangMau_Text = "Đang chờ thu mẫu lần 2";
                                break;
                            case 7:
                                tt.TinhTrangMau_Text = "Đã có kết quả - Đã thu lại mẫu";
                                break;
                            default:
                                tt.TinhTrangMau_Text = "Không xác định";
                                break;
                        }
                        lst.Add(tt);
                    }
                }
                else
                {
                    if (maDonVi != null && !maDonVi.Equals("all"))
                    {
                        donvi = maDonVi;
                        //return db.PSPhieuSangLocs.Where(p => p.NgayNhanMau.Value.Date >= startdate.Date && p.NgayNhanMau.Value.Date <= enddate.Date && p.IDCoSo == maDonVi).ToList();
                    }
                    else
                    {
                        maDonVi = "";
                    }

                    var data = db.pro_Report_TrungTamTinhTrangMau(startdate, enddate, donvi).ToList();
                    if (data.Count > 0)
                    {
                        foreach (var _data in data)
                        {
                            if (_data.TrangThaiMau == 7 || _data.TrangThaiMau == 4 || _data.TrangThaiMau == 6)
                            {
                                PsTinhTrangPhieu tt = new PsTinhTrangPhieu();
                                tt.DiaChi = _data.DiaChi;
                                tt.IDPhieu = _data.IDPhieu;
                                tt.MaBenhNhan = _data.MaBenhNhan;
                                tt.MaDonVi = _data.MaDVCS;
                                tt.MaKhachHang = _data.MaKhachHang;
                                tt.NamSinhCha = _data.FatherBirthday ?? DateTime.Now;
                                tt.NamSinhMe = _data.MotherBirthday ?? DateTime.Now;
                                tt.NgayNhanMau = _data.NgayNhanMau ?? DateTime.Now;
                                tt.SdtCha = _data.FatherPhoneNumber;
                                tt.SdtMe = _data.MotherPhoneNumber;
                                tt.TenMe = _data.MotherName;
                                tt.TenBenhNhan = _data.TenBenhNhan;
                                tt.TenDonVi = _data.TenDVCS;
                                tt.TinhTrangMau_Text = _data.TrangThaiMau_Text;
                                tt.TinhTrangMau = _data.TrangThaiMau ?? 0;
                                lst.Add(tt);
                            }
                          
                        }
                    }
                }               
               
            }
            catch { }
            return lst;
        }
        public PsReponse UpdatePhieuSuaLoi(List<string> maphieu)
        {
            PsReponse res = new PsReponse();
            try
            {
                foreach (var phieu in maphieu)
                {
                    
                    // db.pro_DeletePhieuLoi(phieu);
                    var kq = db.PSXN_TraKetQuas.FirstOrDefault(x => x.MaPhieu == phieu);
                    kq.isTraKQ = false;
                    kq.isDaDuyetKQ = false;
                    kq.isDongBo = false;
                    var ctkq = db.PSXN_TraKQ_ChiTiets.Where(x => x.MaPhieu == phieu);
                    bool p = true;
                    foreach(var ct in ctkq)
                    {
                        ct.isDongBo = false;
                        if(ct.GiaTri2!=null)
                        {
                            p = false;
                        }
                    }
                    var phieuc = db.PSPhieuSangLocs.FirstOrDefault(x => x.IDPhieu == phieu);
                    if (p == true)
                    {
                        phieuc.TrangThaiMau = 3;
                    }
                    else
                    {
                        phieuc.TrangThaiMau = 5;
                    }
                    phieuc.isDongBo = false;
                    db.SubmitChanges();
                    res.Result = true;
                }

            }
            catch
            {
                res.Result = false;
            }
            return res;
        }
        public List<PSTKKQPhieuMail> GetThongKePhieuMail(string[] maphieu)
        {
            List<PSTKKQPhieuMail> lst = new List<PSTKKQPhieuMail>();
            try
            {
                PSTKKQPhieuMail tt = new PSTKKQPhieuMail();
                tt.MauMoi = 0;
                tt.MauXNL = 0;
                tt.NguyCoThap = 0;
                tt.NguyCoCao = 0;
                tt.benh2 = 0;
                tt.benh3 = 0;
                tt.benh5 = 0;
                tt.G6PD = 0;
                tt.GAL = 0;
                tt.PKU = 0;
                tt.CH = 0;
                tt.CAH = 0;
                tt.NguyCoThap2 = 0;
                tt.NguyCoCao2 = 0;
                tt.G6PD2 = 0;
                tt.GAL2 = 0;
                tt.PKU2 = 0;
                tt.CH2 = 0;
                tt.CAH2 = 0;
                tt.G6PD3 = 0;
                tt.GAL3 = 0;
                tt.PKU3 = 0;
                tt.CH3 = 0;
                tt.CAH3 = 0;
                tt.G6PD4 = 0;
                tt.GAL4 = 0;
                tt.PKU4 = 0;
                tt.CH4 = 0;
                tt.CAH4 = 0;
                tt.MauKDat = 0;
                tt.MauDat = 0;
                tt.Mauit = 0;
                tt.GuiCham = 0;
                tt.MauKdeu = 0;
                tt.ThuSom = 0;
                tt.MauChong = 0;
                tt.MauChuaKho = 0;
                tt.MauCoVongHuyetThanh = 0;
                foreach (string MaPhieu in maphieu)
                {

                    //var data = db.pro_Report_BaoCaoPhieuMail(MaPhieu).ToList();
                    var kqmau = db.PSPhieuSangLocs.FirstOrDefault(x => x.IDPhieu == MaPhieu);
                    var kqxn = db.PSXN_TraKQ_ChiTiets.Where(x => x.MaPhieu == MaPhieu && x.isXoa!=true).ToList();
                   
                        if (kqmau.isLayMauLan2 == false)
                        {
                            tt.MauMoi = tt.MauMoi + 1;
                            //thống kê Gói XN
                            switch (kqmau.MaGoiXN)
                            {
                                case "DVGXN0005":
                                    tt.benh5 = tt.benh5 + 1;
                                    break;
                                case "DVGXN0003":
                                    tt.benh3 = tt.benh3 + 1;
                                    break;
                                case "DVGXN0002":
                                    tt.benh2 = tt.benh2 + 1;
                                    break;
                                default:
                                    break;
                            }
                            foreach (var _kqxn in kqxn)
                            {
                                //Thông kê nguy cơ cao thấp
                                if (_kqxn.isNguyCo == false)
                                {
                                    tt.NguyCoThap = tt.NguyCoThap + 1;
                                }
                                else if (_kqxn.isNguyCo == true)
                                {
                                    tt.NguyCoCao = tt.NguyCoCao + 1;
                                    switch (_kqxn.IDThongSoXN)
                                    {

                                        case "G6PD":
                                            tt.G6PD = tt.G6PD + 1;
                                            break;
                                        case "CH":
                                            tt.CH = tt.CH + 1;
                                            break;
                                        case "GAL":
                                            tt.GAL = tt.GAL + 1;
                                            break;
                                        case "PKU":
                                            tt.PKU = tt.PKU + 1;
                                            break;
                                        case "CAH":
                                            tt.CAH = tt.CAH + 1;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                        }
                        else if(kqmau.isLayMauLan2==true)
                        //Thống kê mẫu lấy lại
                        {
                            tt.MauXNL = tt.MauXNL + 1;

                            foreach (var _kqxn in kqxn)
                            {
                                switch (_kqxn.IDThongSoXN)
                                {

                                    case "G6PD":
                                        tt.G6PD2 = tt.G6PD2 + 1;
                                        break;
                                    case "CH":
                                        tt.CH2 = tt.CH2 + 1;
                                        break;
                                    case "GAL":
                                        tt.GAL2 = tt.GAL2 + 1;
                                        break;
                                    case "PKU":
                                        tt.PKU2 = tt.PKU2 + 1;
                                        break;
                                    case "CAH":
                                        tt.CAH2 = tt.CAH2 + 1;
                                        break;
                                    default:
                                        break;
                                }
                                if (_kqxn.isNguyCo == false)
                                {
                                
                                tt.NguyCoThap2 = tt.NguyCoThap2 + 1;
                                    switch (_kqxn.IDThongSoXN)
                                    {
                                        case "G6PD":
                                            tt.G6PD3 = tt.G6PD3 + 1;
                                            break;
                                        case "CH":
                                            tt.CH3 = tt.CH3 + 1;
                                            break;
                                        case "GAL":
                                            tt.GAL3 = tt.GAL3 + 1;
                                            break;
                                        case "PKU":
                                            tt.PKU3 = tt.PKU3 + 1;
                                            break;
                                        case "CAH":
                                            tt.CAH3 = tt.CAH3 + 1;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else if (_kqxn.isNguyCo == true)
                                {
                                    tt.NguyCoCao2 = tt.NguyCoCao2 + 1;
                                    switch (_kqxn.IDThongSoXN)
                                    {

                                        case "G6PD":
                                            tt.G6PD4 = tt.G6PD4 + 1;
                                            break;
                                        case "CH":
                                            tt.CH4 = tt.CH4 + 1;
                                            break;
                                        case "GAL":
                                            tt.GAL4 = tt.GAL4 + 1;
                                            break;
                                        case "PKU":
                                            tt.PKU4 = tt.PKU4 + 1;
                                            break;
                                        case "CAH":
                                            tt.CAH4 = tt.CAH4 + 1;
                                            break;
                                        default:
                                            break;
                                    }
                                }

                            }

                        }
                    if (kqmau.isTruoc24h == true)
                    {
                        tt.ThuSom = tt.ThuSom + 1;
                    }
                    if (kqmau.isGuiMauTre == true)
                    {
                        tt.GuiCham = tt.GuiCham + 1;
                    }
                    // Thống kê Chất lượng mẫu
                    if (kqmau.isKhongDat == false)
                        {
                            tt.MauDat = tt.MauDat + 1;
                        }
                        else
                        {
                            tt.MauKDat = tt.MauKDat + 1;
                          
                        var ghichuLydoKoDat = db.PSChiTietDanhGiaChatLuongs.Where(x => x.IDPhieu == MaPhieu).ToList();
                        foreach(var ghichu in ghichuLydoKoDat)
                        {
                            switch (ghichu.IDDanhGiaChatLuongMau.Trim())
                            {

                                case "CK":
                                    tt.MauChuaKho = tt.MauChuaKho + 1;
                                    break;
                                case "KT":
                                    tt.MauKdeu = tt.MauKdeu + 1;
                                    break;
                                case "CL":
                                    tt.MauChong = tt.MauChong + 1;
                                    break;
                                case "HT":
                                    tt.MauCoVongHuyetThanh = tt.MauCoVongHuyetThanh + 1;
                                    break;
                                case "MI":
                                    tt.Mauit = tt.Mauit + 1;
                                    break;

                                default:
                                    break;
                            }
                        }

                     
                        }                 
                }
                lst.Add(tt);
            }
            catch { }
            return lst;
                    
        }

        public bool KiemTraGioiHan()
        {
            try
            {
                var res = db.PSTiepNhans.ToList();
                if (res.Count > 1000)
                    return true;
                else return false;
            }
            catch { return false; }
        }
        public List<PsTinhTrangPhieu> GetTinhTrangPhieuMail(DateTime startdate, DateTime enddate, string maDonVi,string maChiCuc)
        {
            string donvi = "";
            List<PsTinhTrangPhieu> lst = new List<PsTinhTrangPhieu>();
            try
            {

                if (maDonVi != null && !maDonVi.Equals("all"))
                {
                    donvi = maDonVi;
                    
                }
                else
                {
                    maDonVi = "";
                    if(maChiCuc==null|| maChiCuc.Equals("all"))
                    {
                        maChiCuc = "";
                    }
                }

                var data = db.pro_Report_TrungTamTinhTrangMauMail(startdate, enddate, donvi,maChiCuc).ToList();
                if (data.Count > 0)
                {
                    foreach (var _data in data)
                    {
                        PsTinhTrangPhieu tt = new PsTinhTrangPhieu();
                        tt.DiaChi = _data.DiaChi;
                        tt.IDPhieu = _data.IDPhieu;
                        tt.MaBenhNhan = _data.MaBenhNhan;
                        tt.MaDonVi = _data.MaDVCS;
                        tt.MaKhachHang = _data.MaKhachHang;
                        tt.NamSinhCha = _data.FatherBirthday ?? DateTime.Now;
                        tt.NamSinhMe = _data.MotherBirthday ?? DateTime.Now;
                        tt.NgayNhanMau = _data.NgayNhanMau ?? DateTime.Now;
                        tt.SdtCha = _data.FatherPhoneNumber;
                        tt.SdtMe = _data.MotherPhoneNumber;
                        tt.TenMe = _data.MotherName;
                        tt.TenBenhNhan = _data.TenBenhNhan;
                        tt.TenDonVi = _data.TenDVCS;
                        tt.TinhTrangMau_Text = _data.TrangThaiMau_Text;
                        tt.TinhTrangMau = _data.TrangThaiMau ?? 0;
                        tt.Chon = 0;
                        tt.TenChiCuc = _data.TenChiCuc;
                        tt.Email = _data.Email;
                        lst.Add(tt);
                    }
                }
            }
            catch { }
            return lst;
        }


      
        public bool KiemTraBenhNhanNguyCoCaoDaVaoDotChanDoanChua(string maTiepNhan)
        {
            try
            {
                var res = db.PSDotChuanDoans.FirstOrDefault(p => p.MaBenhNhan == db.PSBenhNhanNguyCoCaos.FirstOrDefault(o => o.MaTiepNhan == maTiepNhan && p.isXoa == false).MaBenhNhan);
                if (res != null) return true;
                else return false;
            }
            catch { return false; }
        }
        public bool KiemTraPhieuDaDuyetHayChua(string maPhieu, string maTiepNhan)
        {
            try
            {
                var res = db.PSXN_TraKetQuas.FirstOrDefault(p => p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepNhan && p.isXoa == false);
                if (res != null)
                {
                    bool isDuyet = res.isDaDuyetKQ ?? false;
                    if (isDuyet)
                    {
                        return true;
                    }
                    else return false;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        public List<PSBenhNhanNguyCoCao> GetDanhSachBenhNhanNguyCoCao(string maDonvi, bool nguyco, DateTime tuNgay, DateTime denNgay)
        {
            List<PSBenhNhanNguyCoCao> lst = new List<PSBenhNhanNguyCoCao>();
            try
            {
                if (string.IsNullOrEmpty(maDonvi))
                {
                    var res = db.PSBenhNhanNguyCoCaos.Where(p => p.isNguyCoCao == nguyco && p.NgayTiepNhan.Value.Date <= denNgay && p.NgayTiepNhan.Value.Date >= tuNgay.Date && p.isXoa == false).ToList();
                    if (res.Count > 0) return res;
                    else return lst;
                }
                else
                {
                    var res = db.PSBenhNhanNguyCoCaos.Where(p => p.isNguyCoCao == nguyco && p.NgayTiepNhan.Value.Date <= denNgay && p.NgayTiepNhan.Value.Date >= tuNgay.Date &&  p.isXoa == false && p.MaDonVi == maDonvi ).ToList();
                    if (res.Count > 0) return res;
                    else return lst;
                }
            }
            catch { return lst; }
        }
        public string GetNewMaKhachHang(string maDonVi, string chuoiNamThang)
        {

            int numID = 0;
            string maKH = string.Empty;
            string startStr = maDonVi + chuoiNamThang;
            try
            {
                var res = db.PSPatients.Where(p => p.MaKhachHang.StartsWith(maDonVi + chuoiNamThang) && p.isXoa == false).ToList();
                if (res != null)
                {
                    if (res.Count > 0)
                    {
                        var idRow = res.Max(p => p.RowIDBenhNhan);
                        numID = int.Parse(res.FirstOrDefault(p => p.RowIDBenhNhan == idRow).MaKhachHang.Substring(12, 4)) + 1;
                        if (numID <= 9)
                            maKH = startStr + "000" + numID;
                        else if (numID > 9 && numID <= 99)
                            maKH = startStr + "00" + numID;
                        else if (numID > 99 && numID <= 999)
                            maKH = startStr + "0" + numID;
                        else maKH = startStr + numID;
                    }
                    else maKH = startStr + "0001";
                }
                else maKH = startStr + "0001";
            }
            catch
            {
                maKH = startStr + "0001";
            }
            return maKH;
        }
        public string GetMaXN(string maTiepNhan)
        {
            try
            {
                var res = db.PSXN_KetQuas.FirstOrDefault(p => p.MaTiepNhan == maTiepNhan && p.isXoa == false).MaXetNghiem.ToString();
                if (res == null) return string.Empty;
                else return res;
            }
            catch
            {
                return string.Empty;
            }
        }
        public string GetDuLieuBangGhi(string MaDuLieu)
        {
            try
            {
                var res = db.BangGhiDuLieus.FirstOrDefault(p => p.MaDuLieu == MaDuLieu);
                if (res != null)
                    return res.DuLieu;
                else return string.Empty;
            }
            catch { return string.Empty; }
        }
        public PsReponse UpdateDuLieuBangGhi(string MaBatDau)
        {
            PsReponse res = new PsReponse();
            try
            {
                var data = db.BangGhiDuLieus.OrderByDescending(x => x.MaDuLieu).FirstOrDefault();
                
                if(data != null)
                {
                    data.DuLieu = MaBatDau;
                    db.SubmitChanges();
                    res.Result = true;
                }
                else
                {
                    BangGhiDuLieu N = new BangGhiDuLieu();
                  
                    var dat = GetDateTimeServer();
                    string s1 = (dat.Year.ToString()).Trim().Substring(DateTime.Now.Year.ToString().Trim().ToString().Length - 2);
                    string s2=data.DuLieu.Substring(6, 2);
                    N.MaDuLieu = "MAXN" + s1+s2;
                    N.DuLieu = MaBatDau;
                    db.BangGhiDuLieus.InsertOnSubmit(N);
                    db.SubmitChanges();
                    res.Result = true;
                }
            }
            catch { res.Result = false; }
            return res;
        }

        public string GetDuLieuXNBangGhi()
        {
            try
            {
                var res = db.BangGhiDuLieus.OrderByDescending(x=>x.MaDuLieu).FirstOrDefault();
                if (res != null)
                    return res.DuLieu;
                else return string.Empty;
            }
            catch { return string.Empty; }
        }
        public PsReponse KTMaXN(string MaXN)
        {
            PsReponse res = new PsReponse();
            try {
                var kq = db.PSXN_KetQuas.Where(x => x.MaXetNghiem == MaXN).ToList();
                if(kq.Count>0)
                {
                    res.Result = false;
                    res.StringError = "Mã Xét Nghiệm Đã Tồn Tại - Yêu Cầu Nhập Mã Khác";
                }
                else
                {
                    res.Result = true;
                }
            }
            catch
            {
                 res.Result = false;
            }
            return res;
        }
        public PSTiepNhan GetThongTinTiepNhan(long rowID)
        {
            try
            {
                return db.PSTiepNhans.FirstOrDefault(p => p.RowIDTiepNhan == rowID);
            }
            catch { return null; }
        }
        public PSTiepNhan GetThongTinTiepNhanTheoMaPhieu(string maPhieu)
        {
            try
            {
                return db.PSTiepNhans.FirstOrDefault(p => p.MaPhieu == maPhieu);
            }
            catch { return null; }
        }

        public bool KiemTraThongTinPhieuDaDuocTiepNhan(string maPhieu)
        {
            try
            {
                var result = db.PSTiepNhans.FirstOrDefault(p => p.MaPhieu == maPhieu && p.isXoa !=true);
                if (result != null) return true;
                else return false;
            }
            catch { return false; }
        }
        public PSChiDinhDichVu GetThongTinChiDinh(string maPhieu, string maTiepNhan)
        {
            try
            {
                if (!string.IsNullOrEmpty(maPhieu) && !string.IsNullOrEmpty(maTiepNhan))
                {
                    var result = db.PSChiDinhDichVus.FirstOrDefault(p => p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepNhan && p.isXoa == false);
                    if (result != null) return result;
                    else return null;
                }
                else return null;
            }
            catch { return null; }
        }
        public PSDanhMucDonViCoSo GetThongTinDonViCoSo(string maDovi)
        {
            PSDanhMucDonViCoSo donvi = db.PSDanhMucDonViCoSos.FirstOrDefault(p => p.MaDVCS == maDovi);
            return donvi;
        }
        public string GetThongTinMailDonViCoSo(string maDovi)
        {
            PSDanhMucDonViCoSo donvi = db.PSDanhMucDonViCoSos.FirstOrDefault(p => p.MaDVCS == maDovi);
            return donvi.Email;
        }
        public List<PSChiDinhDichVuChiTiet> GetThongTinChiDinhDichVuChiTiet(string maCD)
        {
            List<PSChiDinhDichVuChiTiet> lst = new List<PSChiDinhDichVuChiTiet>();
            try
            {
                if (string.IsNullOrEmpty(maCD))
                    return lst;
                else
                {
                    var res = db.PSChiDinhDichVuChiTiets.Where(p => p.MaChiDinh == maCD).ToList();
                    if (res.Count > 0)
                    {
                        return res;
                    }
                    else return lst;
                }
            }
            catch { return lst; }
        }
        public PSChiDinhDichVu GetThongTinChiDinh(string maCD)
        {
            try
            {
                if (!string.IsNullOrEmpty(maCD))
                {
                    var result = db.PSChiDinhDichVus.FirstOrDefault(p => p.MaChiDinh == maCD && p.isXoa == false);
                    if (result != null) return result;
                    else return null;
                }
                else return null;
            }
            catch { return null; }
        }
        public List<PSChiDinhDichVu> GetDanhSachDichVuDaChiDinh(int Trangthai, string maDonVi, DateTime tuNgay, DateTime denNgay, bool isCanCapMa)
        {
            if (!isCanCapMa)
            {
                if (Trangthai < 0)//get tất cả
                {

                    if (string.IsNullOrEmpty(maDonVi))
                    {
                        var results = db.PSChiDinhDichVus.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.IDGoiDichVu != "DVGXNL2" && p.NgayChiDinhLamViec.Value.Date <= denNgay && p.NgayChiDinhLamViec.Value.Date >= tuNgay.Date).ToList();
                        if (results.Count > 0) return results;
                        else return null;
                    }
                    else
                    {
                        var results = db.PSChiDinhDichVus.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.IDGoiDichVu != "DVGXNL2" && p.NgayChiDinhLamViec.Value.Date <= denNgay && p.NgayChiDinhLamViec.Value.Date >= tuNgay.Date && p.MaDonVi == maDonVi).ToList();
                        if (results.Count > 0) return results;
                        else return null;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(maDonVi))
                    {
                        var results = db.PSChiDinhDichVus.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.IDGoiDichVu != "DVGXNL2" && p.TrangThai == Trangthai && p.NgayChiDinhLamViec.Value.Date <= denNgay && p.NgayChiDinhLamViec.Value.Date >= tuNgay.Date).ToList();
                        if (results.Count > 0) return results;
                        else return null;
                    }
                    else
                    {
                        var results = db.PSChiDinhDichVus.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.IDGoiDichVu != "DVGXNL2" && p.TrangThai == Trangthai && p.NgayChiDinhLamViec.Value.Date <= denNgay && p.NgayChiDinhLamViec.Value.Date >= tuNgay.Date && p.MaDonVi == maDonVi).ToList();
                        if (results.Count > 0) return results;
                        else return null;
                    }
                }
            }
            else
            {
                if (Trangthai < 0)//get tất cả
                {
                    if (string.IsNullOrEmpty(maDonVi))
                    {
                        var results = db.PSChiDinhDichVus.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.NgayChiDinhLamViec.Value.Date <= denNgay && p.NgayChiDinhLamViec.Value.Date >= tuNgay.Date).ToList();
                        if (results.Count > 0) return results;
                        else return null;
                    }
                    else
                    {
                        var results = db.PSChiDinhDichVus.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.NgayChiDinhLamViec.Value.Date <= denNgay && p.NgayChiDinhLamViec.Value.Date >= tuNgay.Date && p.MaDonVi == maDonVi).ToList();
                        if (results.Count > 0) return results;
                        else return null;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(maDonVi))
                    {
                        var results = db.PSChiDinhDichVus.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.TrangThai == Trangthai && p.NgayChiDinhLamViec.Value.Date <= denNgay && p.NgayChiDinhLamViec.Value.Date >= tuNgay.Date).ToList();
                        if (results.Count > 0) return results;
                        else return null;
                    }
                    else
                    {
                        var results = db.PSChiDinhDichVus.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.TrangThai == Trangthai && p.NgayChiDinhLamViec.Value.Date <= denNgay && p.NgayChiDinhLamViec.Value.Date >= tuNgay.Date && p.MaDonVi == maDonVi).ToList();
                        if (results.Count > 0) return results;
                        else return null;
                    }
                }
            }
        }
        
        public List<PSDanhMucDanhGiaChatLuongMau> GetDanhMucDanhGiaChatLuongMau()
        {
            var lst = db.PSDanhMucDanhGiaChatLuongMaus.ToList();
            if (lst.Count > 0)
            {
                return lst;
            }
            else return null;
        }
        public List<PSDanhMucDonViCoSo> GetDanhSachDonVi(string maChiCuc)
        {
            List<PSDanhMucDonViCoSo> lst = new List<PSDanhMucDonViCoSo>();
            try
            {
                if (!string.IsNullOrEmpty(maChiCuc) & !maChiCuc.Equals("0") & !maChiCuc.ToLower().Equals("all"))
                {
                    var results = db.PSDanhMucDonViCoSos.Where(p => p.isLocked == false && p.MaChiCuc == maChiCuc).ToList();
                    if (results.Count > 0) return results;
                }
                else
                {
                    var results = db.PSDanhMucDonViCoSos.Where(p => p.isLocked == false).ToList();
                    if (results.Count > 0) return results;
                }
            }

            catch (Exception ex) { }
            return lst;
        }
        public List<PSDanhMucDonViCoSo> GetDanhSachDonVi()
        {
            List<PSDanhMucDonViCoSo> lst = new List<PSDanhMucDonViCoSo>();
            try
            {
                var results = db.PSDanhMucDonViCoSos.Where(p => p.isLocked == false).ToList();
                PSDanhMucDonViCoSo dv = new PSDanhMucDonViCoSo();
                dv.MaDVCS = "ALL";
                dv.TenDVCS = "Tất cả";
                lst.Add(dv);
                foreach (var donvi in results)
                {
                    lst.Add(donvi);
                }
            }

            catch (Exception ex) { }
            return lst;
        }
        public List<PSDanhMucDonViCoSo> GetDonViCoSo(string maDonViCoSo)
        {
            List<PSDanhMucDonViCoSo> lst = new List<PSDanhMucDonViCoSo>();
            try
            {
                if (!string.IsNullOrEmpty(maDonViCoSo))
                {
                    var result = db.PSDanhMucDonViCoSos.FirstOrDefault(p => p.MaDVCS == maDonViCoSo);
                    if (result != null)
                    {
                        lst.Add(result);
                    }
                }
                else
                {
                    var results = db.PSDanhMucDonViCoSos.OrderBy(p =>p.Stt).Where(p=>p.isLocked == false).ToList();

                    foreach (var donvi in results)
                    {
                        lst.Add(donvi);
                    }
                }
            }
            catch (Exception ex) { }
            return lst;
        }
        public List<PSPhieuSangLoc> GetPhieuSangLoc(bool tinhTrangPhieu, byte tinhTrangMau)
        {
            List<PSPhieuSangLoc> lst = new List<PSPhieuSangLoc>();
            try
            {
                if (tinhTrangMau >= 0) // Lấy danh sách các phiếu đã đc cơ sở gửi và chọn điều kiện mẫu đã được :0- Chưa nhận,1- đã nhận,2 - Đã đánh giá;3-đang làm XN,4-Đã có kết quả, 5 XN lại ; 6 thu mẫu lại
                {
                    lst= db.PSPhieuSangLocs.OrderBy(p=>p.IDPhieu).Where(p => p.TrangThaiPhieu == tinhTrangPhieu && p.TrangThaiMau == tinhTrangMau && p.isXoa != true).ToList();
                 
                }
                else
                {
                    lst= db.PSPhieuSangLocs.OrderBy(p => p.IDPhieu).Where(p => p.TrangThaiPhieu == tinhTrangPhieu && p.isXoa != true).ToList();
                 
                }
            }
            catch (Exception ex) { }
            return lst;
        }
    

        public List<PSTiepNhan> GetDanhSachPhieuDaTiepNhan(string maDonVi, bool isDaDanhGia, DateTime tuNgay, DateTime denNgay)
        {
            List<PSTiepNhan> lst = new List<PSTiepNhan>();

            if (string.IsNullOrEmpty(maDonVi))
            {
                var results = db.PSTiepNhans.OrderBy(p => p.MaPhieu).Where(p => p.isXoa != true && p.isDaDanhGia == isDaDanhGia && p.NgayTiepNhan.Value.Date >= tuNgay.Date && p.NgayTiepNhan.Value.Date <= denNgay.Date).ToList();
                if (results.Count > 0)
                {
                    return results;
                }
                else return null;
            }
            else
            {
                var results = db.PSTiepNhans.OrderBy(p => p.MaPhieu).Where(p => p.isXoa != true && p.isDaDanhGia == isDaDanhGia && p.MaDonVi == maDonVi && p.NgayTiepNhan.Value.Date >= tuNgay.Date && p.NgayTiepNhan.Value.Date <= denNgay.Date).ToList();

                if (results.Count > 0)
                {
                    return results;
                }
                else return null;
            }
        }
        public List<PSTiepNhan> GetDanhSachPhieuDaTiepNhan(string maDonVi, DateTime tuNgay, DateTime denNgay)
        {
            List<PSTiepNhan> lst = new List<PSTiepNhan>();

            if (string.IsNullOrEmpty(maDonVi))
            {
                var results = db.PSTiepNhans.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.isDaDanhGia == true && p.NgayTiepNhan.Value.Date >= tuNgay.Date && p.NgayTiepNhan.Value.Date <= denNgay.Date).ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        lst.Add(result);
                    }
                    return lst;
                }
                else return null;
            }
            else
            {
                var results = db.PSTiepNhans.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.isDaDanhGia == true && p.MaDonVi == maDonVi && p.NgayTiepNhan.Value.Date >= tuNgay.Date && p.NgayTiepNhan.Value.Date <= denNgay.Date).ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        lst.Add(result);
                    }
                    return lst;
                }
                else return null;
            }
        }
        public PSPhieuSangLoc GetPhieuSangLoc(string maPhieu, string maDonVi)
        {
            try
            {
                var result = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieu == maPhieu && p.IDCoSo == maDonVi && p.isXoa == false);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { return null; }

        }
        public PSPatient GetThongTinDuLieuBenhNhan(string maBenhNhan)
        {
            try
            {
                var result = db.PSPatients.FirstOrDefault(p => p.MaBenhNhan == maBenhNhan && p.isXoa == false);
                if (result != null)
                    return result;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        //public PsPerson GetThongTinConNguoi(string maThongTin)
        //{
        //    try
        //    {
        //        var result = db.PsPersons.FirstOrDefault(p => p.MaThongTin == maThongTin);
        //        if (result != null)
        //            return result;
        //        else
        //            return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        public List<PSDanhMucChiCuc> GetDanhMucChiCuc()
        {
            List<PSDanhMucChiCuc> lst = new List<PSDanhMucChiCuc>();
            try
            {
                var cc = db.PSDanhMucChiCucs.ToList();
                if (cc.Count > 0)
                    lst = cc;
            }
            catch
            {
            }
            return lst;
        }
        public List<PSDanhMucDanToc> GetDanhSachDanToc(int maQuocGia)
        {
            try
            {
                if (maQuocGia < 0)
                    return db.PSDanhMucDanTocs.ToList();
                else
                    return db.PSDanhMucDanTocs.Where(p => p.IDQuocGia == maQuocGia).ToList();
            }
            catch { return null; }
        }
        public List<PSChiDinhTrenPhieu> GetDichVuCanLamLaiCuaPhieu(string maPhieuCu, string maDonVi)
        {
            List<PSChiDinhTrenPhieu> lst = new List<PSChiDinhTrenPhieu>();
            try
            {
                string maTN = db.PSTiepNhans.FirstOrDefault(p => p.MaPhieu == maPhieuCu && p.MaDonVi == maDonVi && p.isXoa == false).MaTiepNhan;
                if (string.IsNullOrEmpty(maTN))
                    return lst;
                else
                {
                    var lstnguyco = db.PSXN_TraKQ_ChiTiets.Where(p => p.MaTiepNhan == maTN && p.MaPhieu == maPhieuCu && p.isNguyCo == true && p.isXoa == false).ToList();
                    if (lstnguyco.Count > 0)
                    {
                        foreach (var dichvu in lstnguyco)
                        {
                            PSChiDinhTrenPhieu dv = new PSChiDinhTrenPhieu();
                            dv.MaDichVu = dichvu.MaDichVu;
                            dv.MaPhieu = maPhieuCu;
                            lst.Add(dv);
                        }
                    }

                }
            }
            catch
            {
            }
            return lst;
        }
        public List<PSChiDinhTrenPhieu> GetChiDinhTrenPhieu(string maPhieu, string maTiepNhan)
        {
            List<PSChiDinhTrenPhieu> lst = new List<PSChiDinhTrenPhieu>();
            if (!string.IsNullOrEmpty(maPhieu))
            {
                try
                {
                    var results = db.PSChiDinhTrenPhieus.Where(p => p.MaPhieu == maPhieu).ToList();
                    if (results.Count > 0)
                    {
                        foreach (var result in results)
                        {
                            lst.Add(result);
                        }
                        return lst;
                    }
                    else return null;
                }
                catch { return null; }
            }
            else
                return null;
        }
        public bool XacThucNhanVien(string maNV, string pass)
        {
            try
            {
                if (!string.IsNullOrEmpty(maNV) && !string.IsNullOrEmpty(pass))
                {
                    var res = db.PSEmployees.FirstOrDefault(p => p.EmployeeCode == maNV && p.Password == pass);
                    if (res != null)
                        return true;
                    else return false;
                }
                else return false;
            }
            catch { return false; }
        }
        public List<PSChiDinhTrenPhieu> GetChiDinhTrenPhieu(string maPhieu)
        {
            List<PSChiDinhTrenPhieu> lst = new List<PSChiDinhTrenPhieu>();
            if (!string.IsNullOrEmpty(maPhieu))
            {
                try
                {
                    var results = db.PSChiDinhTrenPhieus.Where(p => p.MaPhieu == maPhieu).ToList();
                    if (results.Count > 0)
                    {
                        foreach (var result in results)
                        {
                            lst.Add(result);
                        }
                        return lst;
                    }
                    else return null;
                }
                catch { return null; }
            }
            else
                return null;
        }
        public List<PSChiTietGoiDichVuChung> GetDichVuTheoMaGoi(string maGoiDichVi)
        {
            List<PSChiTietGoiDichVuChung> lst = new List<PSChiTietGoiDichVuChung>();
            if (!string.IsNullOrEmpty(maGoiDichVi))
            {
                var results = db.PSChiTietGoiDichVuChungs.Where(p => p.IDGoiDichVuChung == maGoiDichVi).ToList();
                if (results.Count > 0)
                {
                    return results;
                    //foreach (var result in results)
                    //{
                    //    lst.Add(result);
                    //}
                    //return lst;
                }
                else return lst;
            }
            else return lst;
        }
        public PSDanhMucDichVu GetDichVuTheoDonVi(string maDichVu, string maDonVi)
        {
            var result = db.PSDanhMucDichVus.Where(x => x.IDDichVu == maDichVu).FirstOrDefault();
            if (result != null)
                return result;
            else return null;
        }
      


        
        public List<PSDanhMucGoiDichVuTheoDonVi> GetDanhMucGoiXetNghiemTrungTam(string maDonVi)
        {
            List<PSDanhMucGoiDichVuTheoDonVi> lst = new List<PSDanhMucGoiDichVuTheoDonVi>();
            if (!string.IsNullOrEmpty(maDonVi))
            {

                // var results = db.PSDanhMucGoiDichVuTheoDonVis.Where(p => p.MaDVCS == maDonVi).ToList();
                var results = (from p in db.PSDanhMucGoiDichVuTheoDonVis join x in db.PSDanhMucGoiDichVuChungs on p.IDGoiDichVuChung equals x.IDGoiDichVuChung
                               where p.MaDVCS==maDonVi orderby x.Stt select p).ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        lst.Add(result);
                    }
                    return lst;

                }
            }
            return lst;
        }

        public List<PSDanhMucGhiChu> GetListCauHinhGhiChu()
        {
            List<PSDanhMucGhiChu> lst = new List<PSDanhMucGhiChu>();
            var res = db.PSDanhMucGhiChus.ToList();
            if (res.Count > 0)
                return res;
            else return lst;
        }

        public List<PSDanhMucGoiDichVuChung> GetDanhMucGoiXetNghiemChung(string idGoiDichVuChung)
        {
            List<PSDanhMucGoiDichVuChung> lst = new List<PSDanhMucGoiDichVuChung>();
            if (!string.IsNullOrEmpty(idGoiDichVuChung))
            {
                var result = db.PSDanhMucGoiDichVuChungs.FirstOrDefault(p => p.IDGoiDichVuChung == idGoiDichVuChung);
                if (result != null) { lst.Add(result); return lst; }
                else return null;
            }
            else
            {
                var results = db.PSDanhMucGoiDichVuChungs.ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        lst.Add(result);
                    }
                    return lst;
                }
                else return null;
            }
        }
        public List<PSDanhMucDichVu> GetDanhSachDichVu(bool isLocked)
        {
            List<PSDanhMucDichVu> lst = new List<PSDanhMucDichVu>();
            try
            {
                if (!isLocked)
                {
                    var results = db.PSDanhMucDichVus.Where(p => p.isLocked != true).ToList();
                    if (results.Count > 0)
                    {
                        foreach (var result in results)
                        {
                            lst.Add(result);
                        }
                    }
                    else return null;
                }
                else
                {
                    var results = db.PSDanhMucDichVus.ToList();
                    if (results.Count > 0)
                    {
                        foreach (var result in results)
                        {
                            lst.Add(result);
                        }
                    }
                    else return null;
                }
            }
            catch { }
            return lst;
        }
        public List<PSDanhMucChuongTrinh> GetDanhSachChuongTrinh(bool isLocked)
        {
            List<PSDanhMucChuongTrinh> lst = new List<PSDanhMucChuongTrinh>();
            try
            {
                if (!isLocked)
                {
                    var results = db.PSDanhMucChuongTrinhs.Where(p => p.isLocked == isLocked).ToList();
                    if (results.Count > 0)
                    {
                        foreach (var result in results)
                        {
                            lst.Add(result);
                        }
                        return lst;
                    }
                    else return null;

                }
                else
                {
                    var results = db.PSDanhMucChuongTrinhs.ToList();
                    if (results.Count > 0)
                    {
                        foreach (var result in results)
                        {
                            lst.Add(result);
                        }
                        return lst;
                    }
                    else return null;
                }
            }
            catch (Exception ex) { return null; }
        }
        public List<PSXN_KetQua> GetDanhSachChoNhanKetQua(DateTime tuNgay, DateTime denNgay, string maDonVi, bool isCoKQ)
        {
            List<PSXN_KetQua> lst = new List<PSXN_KetQua>();
            try
            {
                if(isCoKQ==false)
                {
                    if (string.IsNullOrEmpty(maDonVi) || maDonVi.Equals("all"))
                    {
                        var results = db.PSXN_KetQuas.OrderBy(p => p.MaXetNghiem).Where(p => p.isXoa == false && p.isCoKQ == isCoKQ && p.NgayLamXetNghiem.Value.Date >= tuNgay.Date && p.NgayLamXetNghiem.Value.Date <= denNgay.Date).ToList();
                        if (results.Count > 0)
                        {
                            foreach (var result in results)
                            {
                                lst.Add(result);
                            }
                        }
                    }
                    else
                    {
                        var results = db.PSXN_KetQuas.OrderBy(p => p.MaXetNghiem).Where(p => p.isXoa == false && p.isCoKQ == isCoKQ && p.NgayLamXetNghiem.Value.Date >= tuNgay.Date && p.NgayLamXetNghiem.Value.Date <= denNgay.Date && p.MaDonVi == maDonVi).ToList();
                        if (results.Count > 0)
                        {
                            foreach (var result in results)
                            {
                                lst.Add(result);
                            }

                        }

                    }
                }
                else if (isCoKQ == true)
                {
                    if (string.IsNullOrEmpty(maDonVi) || maDonVi.Equals("all"))
                    {
                        var results = db.PSXN_KetQuas.OrderBy(p => p.MaXetNghiem).Where(p => p.isXoa == false && p.isCoKQ == isCoKQ && p.NgayTraKQ.Value.Date >= tuNgay.Date && p.NgayTraKQ.Value.Date <= denNgay.Date).ToList();
                        if (results.Count > 0)
                        {
                            foreach (var result in results)
                            {
                                lst.Add(result);
                            }
                        }
                    }
                    else
                    {
                        var results = db.PSXN_KetQuas.OrderBy(p => p.MaXetNghiem).Where(p => p.isXoa == false && p.isCoKQ == isCoKQ && p.NgayTraKQ.Value.Date >= tuNgay.Date && p.NgayTraKQ.Value.Date <= denNgay.Date && p.MaDonVi == maDonVi).ToList();
                        if (results.Count > 0)
                        {
                            foreach (var result in results)
                            {
                                lst.Add(result);
                            }

                        }

                    }
                }

            }
            catch
            {
            }
            return lst;
        }
        public List<PSChiTietDanhGiaChatLuong> GetChiTietDanhGiaMạuKhongDatTrenPhieu(string maPhieu, string maTiepNhan)
        {
            List<PSChiTietDanhGiaChatLuong> lst = new List<PSChiTietDanhGiaChatLuong>();
            var res = db.PSChiTietDanhGiaChatLuongs.Where(p => p.MaTiepNhan == p.MaTiepNhan && p.IDPhieu == maPhieu && p.isXoa == false).ToList();
            if (res.Count > 0) return res;
            else return lst;
        }
        public PSXN_TraKetQua GetThongTinTraKetQua(string maPhieu, string maTiepNhan)
        {
            PSXN_TraKetQua KQ = new PSXN_TraKetQua();
            try
            {
                var result = db.PSXN_TraKetQuas.FirstOrDefault(p => p.isXoa == false && p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepNhan);
                if (result != null)
                    return result;
                else return null;
            }
            catch
            {
                return null;
            }
        }
        public string GetTenDichVuCuaKyThuat(string maKyThuat)
        {
            try
            {
                var result = db.PSDanhMucDichVus.FirstOrDefault(p => p.IDDichVu == db.PSMapsXN_DichVus.FirstOrDefault(o => o.IDKyThuatXN == maKyThuat).IDDichVu).TenHienThiDichVu;
                return result;
            }
            catch { return string.Empty; }
        }
        public List<PSXN_TraKQ_ChiTiet> GetThongTinTraKetQuaChiTiet(string maPhieu, string maTiepNhan)
        {
            try
            {
                var results = db.PSXN_TraKQ_ChiTiets.Where(p => p.isXoa == false && p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepNhan).ToList();
                if (results.Count < 1)
                {
                    return null;
                }
                else return results.OrderByDescending(p => p.Stt).ToList();
            }
            catch { return null; }
        }
        public PSPatient GetThongTinBenhNhan(string maBenhNhan)
        {
            PSPatient BN = new PSPatient();
            try
            {
                var bn = db.PSPatients.FirstOrDefault(p => p.MaBenhNhan == maBenhNhan && p.isXoa == false);
                if (bn != null) return bn;
                else return BN;

            }
            catch
            {
                return BN;
            }

        }
        public List<PSXN_TraKetQua> GetDanhSachChoTraKetQua(DateTime tuNgay, DateTime denNgay, string maDonVi, bool isTraKQ)
        {
            List<PSXN_TraKetQua> lst = new List<PSXN_TraKetQua>();
            try
            {
                if (isTraKQ == false)
                {
                    if (string.IsNullOrEmpty(maDonVi) || maDonVi.Equals("all"))
                    {
                        
                        var results = db.PSXN_TraKetQuas.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.isTraKQ == false && p.NgayLamXetNghiem.Value.Date >= tuNgay.Date && p.NgayLamXetNghiem.Value.Date <= denNgay.Date).ToList();
                        
                        if (results.Count > 0)
                        {
                            foreach (var result in results)
                            {
                               
                                lst.Add(result);
                            }
                        }
                    }
                    else
                    {
                        var results = db.PSXN_TraKetQuas.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.isTraKQ == false && p.NgayLamXetNghiem.Value.Date >= tuNgay.Date && p.NgayLamXetNghiem.Value.Date <= denNgay.Date && p.IDCoSo == maDonVi).ToList();
                        if (results.Count > 0)
                        {
                            foreach (var result in results)
                            {
                                lst.Add(result);
                            }

                        }

                    }
                }
                else if (isTraKQ == true)
                {
                    if (string.IsNullOrEmpty(maDonVi) || maDonVi.Equals("all"))
                    {
                        var results = db.PSXN_TraKetQuas.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.isTraKQ == true && p.NgayTraKQ.Value.Date >= tuNgay.Date && p.NgayTraKQ.Value.Date <= denNgay.Date).ToList();
                        if (results.Count > 0)
                        {
                            foreach (var result in results)
                            {
                                lst.Add(result);
                            }
                        }
                    }
                    else
                    {
                        var results = db.PSXN_TraKetQuas.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.isTraKQ == true && p.NgayTraKQ.Value.Date >= tuNgay.Date && p.NgayTraKQ.Value.Date <= denNgay.Date && p.IDCoSo == maDonVi).ToList();
                        if (results.Count > 0)
                        {
                            foreach (var result in results)
                            {
                                lst.Add(result);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return lst;
        }
        public List<PSXN_TTTraKQ> GetDanhSachChoTraKetQuaAll(DateTime tuNgay, DateTime denNgay, string maDonVi, bool isTraKQ)
        {
           
            List<PSXN_TTTraKQ> lst = new List<PSXN_TTTraKQ>();
            try
            {
                if (isTraKQ == false)
                {
                    
                        if (string.IsNullOrEmpty(maDonVi) || maDonVi.Equals("all"))
                        {

                            var results = db.PSXN_TraKetQuas.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.isTraKQ == false && p.NgayLamXetNghiem.Value.Date >= tuNgay.Date && p.NgayLamXetNghiem.Value.Date <= denNgay.Date ).ToList();
                            if (results.Count > 0)
                            {
                                foreach (var result in results)
                                {
                                    PSXN_TTTraKQ ls = new PSXN_TTTraKQ();
                                    var NhapLieu = db.PSChiDinhDichVus.FirstOrDefault(x => x.MaPhieu == result.MaPhieu).isDaNhapLieu;
                                    ConvertObjectToObject(result, ls);
                                    ls.isDaNhapLieu = NhapLieu != null ? NhapLieu : false;
                                    lst.Add(ls);
                                }
                            }
                        }
                        else
                        {
                            var results = db.PSXN_TraKetQuas.OrderBy(p => p.MaPhieu).Where(p => p.isXoa == false && p.isTraKQ == false && p.NgayLamXetNghiem.Value.Date >= tuNgay.Date && p.NgayLamXetNghiem.Value.Date <= denNgay.Date && p.IDCoSo == maDonVi ).ToList();
                            if (results.Count > 0)
                            {
                                foreach (var result in results)
                                {
                                    PSXN_TTTraKQ ls = new PSXN_TTTraKQ();
                                    var NhapLieu = db.PSChiDinhDichVus.FirstOrDefault(x => x.MaPhieu == result.MaPhieu).isDaNhapLieu;
                                    ConvertObjectToObject(result, ls);
                                    ls.isDaNhapLieu = NhapLieu != null ? NhapLieu : false;
                                    lst.Add(ls);
                                }

                            }

                        }
                    }
                        
            }
            catch
            {
            }
            return lst;
        }
        public object ConvertObjectToObject(object source, object des)
        {
            var props = des.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                try
                {
                    var data = source.GetType().GetProperty(prop.Name).GetValue(source, null);
                    prop.SetValue(des, data, null);

                }
                catch
                {
                    prop.SetValue(des, null, null);
                }
            }
            return des;
        }
        public List<PSXN_TraKQ_ChiTiet> GetDanhSachTraKetQuaChiTietPhieuCu(string maPhieu)
        {
            List<PSXN_TraKQ_ChiTiet> lst = new List<PSXN_TraKQ_ChiTiet>();
            try
            {
                var results = db.PSXN_TraKQ_ChiTiets.Where(p => p.isXoa == false && p.MaPhieu == maPhieu).ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        lst.Add(result);
                    }

                }
            }
            catch { }
            return lst;
        }
        public List<PSXN_TraKQ_ChiTiet> GetDanhSachTraKetQuaChiTiet(string maTiepNhan)
        {
            List<PSXN_TraKQ_ChiTiet> lst = new List<PSXN_TraKQ_ChiTiet>();
            try
            {
                var results = db.PSXN_TraKQ_ChiTiets.Where(p => p.isXoa == false && p.MaTiepNhan == maTiepNhan).ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        lst.Add(result);
                    }

                }
            }
            catch { }
            return lst;
        }
        public PSDotChuanDoan GetThongTinDotChanDoan(long rowID)
        {
            try
            {
                return db.PSDotChuanDoans.FirstOrDefault(p => p.isXoa == false && p.rowIDDotChanDoan == rowID);
            }
            catch
            {
                return null;
            }
        }
        public List<PSDotChuanDoan> GetDanhSachDotChanDoanCuaBenhNhan(string MaBenhNhan)
        {
            List<PSDotChuanDoan> lst = new List<PSDotChuanDoan>();
            try
            {
                var res = db.PSDotChuanDoans.Where(p => p.isXoa == false && p.MaBenhNhan == MaBenhNhan).ToList();
                if (res != null)
                    lst = res;
            }
            catch { }
            return lst;
        }
        public List<PSDotChuanDoan> GetDanhSachDotChanDoanCuaBenhNhan(string maBenhNhan, string maKhachHang)
        {
            List<PSDotChuanDoan> lst = new List<PSDotChuanDoan>();
            try
            {
                var res = db.PSDotChuanDoans.Where(p => p.isXoa == false && p.MaBenhNhan == maBenhNhan && p.MaKhachHang == maKhachHang).ToList();
                if (res != null)
                    lst = res;
            }
            catch
            {
            }
            return lst;
        }
        public List<PSXN_TraKQ_ChiTiet> GetDanhSachTraKetQuaChiTiet(string maTiepNhan, string maPhieu)
        {
            List<PSXN_TraKQ_ChiTiet> lst = new List<PSXN_TraKQ_ChiTiet>();
            try
            {
                var results = db.PSXN_TraKQ_ChiTiets.Where(p => p.isXoa == false && p.MaTiepNhan == maTiepNhan && p.MaPhieu == maPhieu).ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        lst.Add(result);
                    }

                }
            }
            catch { }
            return lst;
        }
        public bool KiemTraPhieuThuMauLaiDaDuocChiDinhChua(string maphieu)
        {
            try
            {
                var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieuLan1 == maphieu);
                if (phieu != null)
                {
                    var tn = db.PSTiepNhans.Where(p => p.isXoa == false && p.MaPhieu == phieu.IDPhieu).ToList();
                    if (tn.Count > 0)
                        return true;
                    else return false;
                }
                else return false;
            }
            catch { return false; }
        }
        public List<PSXN_KetQua_ChiTiet> GetDanhSachChiTietKetQua(string maKetQua)
        {
            List<PSXN_KetQua_ChiTiet> lst = new List<PSXN_KetQua_ChiTiet>();
            try
            {
                var results = db.PSXN_KetQua_ChiTiets.Where(p => p.isXoa == false && p.MaKQ == maKetQua).ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        lst.Add(result);
                    }
                }
            }
            catch
            {
            }
            return lst;
        }
        public PSPhieuSangLoc GetThongTinPhieu(string maPhieu)
        {
            try
            {
                var result = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == maPhieu);
                return result;
            }
            catch
            {
                return null;
            }
        }
        #endregion GET
        #region SET
        public PsReponse DuyetNhanh(string maTiepNhan, string maPhieu)
        {
            PsReponse result = new PsReponse();
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var kq = db.PSXN_TraKetQuas.FirstOrDefault(p => p.isXoa == false && p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepNhan);
                if (kq != null)
                {
                    kq.isDaDuyetKQ = true;
                    kq.isTraKQ = true;
                    kq.isDongBo = false;
                    kq.NgayTraKQ = DateTime.Now;
                }
                db.SubmitChanges();
                var lstkq = db.PSXN_TraKQ_ChiTiets.Where(p => p.isXoa == false && p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepNhan).ToList();
                if (lstkq.Count > 0)
                {
                    foreach (var item in lstkq)
                    {
                      
                        item.isDaDuyetKQ = true;
                        item.isDongBo = false;
                        db.SubmitChanges();
                    }
                }
                var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieu == maPhieu && p.isXoa == false);
                if (phieu != null)
                {
                    phieu.TrangThaiMau = 4;
                    db.SubmitChanges();
                }
                result.Result = true;
                db.Transaction.Commit();
                db.Connection.Close();
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                if (string.IsNullOrEmpty(result.StringError))
                    result.StringError = ex.ToString();
            }
            return result;
        }
        public PsReponse HuyMauPhieu(string maPhieu, string maTiepnhan, string maDonVi, string maNV, string lydoXoa)
        {
            PsReponse result = new PsReponse();
            result.Result = true;
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                DateTime ngaygio = DateTime.Now;
                try
                {
                    ngaygio = GetDateTimeServer();
                }
                catch
                {
                    ngaygio = DateTime.Now;
                }
                var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == maPhieu);
                if (phieu != null)
                {
                    if ((phieu.TrangThaiMau ?? 0) == 6)
                    {
                        var lstp = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieuLan1 == maPhieu && p.TrangThaiMau > 1);
                        if (lstp != null)
                        {
                            result.Result = false;
                            result.StringError = "Phiếu " + maPhieu + " đã được thu mẫu lại và đã vào quy trình nên không thể hủy! \r\n Để xóa mẫu này thì cần phải hủy mẫu " + phieu.IDPhieu + "trước!";
                            throw new Exception("Phiếu đã được thu mẫu lại !");
                        }
                    }
                }
                var TraKQ = db.PSXN_TraKetQuas.FirstOrDefault(p => p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepnhan && p.IDCoSo == maDonVi && p.isXoa == false);
                if (TraKQ != null)
                {
                    TraKQ.isXoa = true;
                    TraKQ.isDongBo = false;
                    TraKQ.IDNhanVienXoa = maNV;
                    TraKQ.LyDoXoa = lydoXoa;
                    TraKQ.NgayGioXoa = ngaygio;
                    db.SubmitChanges();
                    var lstchitiet = db.PSXN_TraKQ_ChiTiets.Where(p => p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepnhan && p.isXoa == false).ToList();
                    if (lstchitiet.Count > 0)
                    {
                        foreach (var ct in lstchitiet)
                        {
                            ct.isXoa = true;
                            ct.isDongBo = false;
                            ct.IDNhanVienXoa = maNV;
                            ct.NgayGioXoa = ngaygio;
                            db.SubmitChanges();
                        }
                    }
                }
                var lstKQ = db.PSXN_KetQuas.Where(p => p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepnhan && p.MaDonVi == maDonVi && p.isXoa == false).ToList();
                if (lstKQ.Count > 0)
                {
                    foreach (var KQ in lstKQ)
                    {

                        KQ.isXoa = true;
                        KQ.isDongBo = false;
                        KQ.IDNhanVienXoa = maNV;
                        KQ.LyDoXoa = lydoXoa;
                        KQ.NgayGioXoa = ngaygio;
                        db.SubmitChanges();
                        var lstchitiet = db.PSXN_KetQua_ChiTiets.Where(p => p.MaKQ == KQ.MaKetQua && p.isXoa == false).ToList();
                        if (lstchitiet.Count > 0)
                        {
                            foreach (var ct in lstchitiet)
                            {
                                ct.isXoa = true;
                                ct.isDongBo = false;
                                ct.IDNhanVienXoa = maNV;
                                ct.NgayGioXoa = ngaygio;
                                db.SubmitChanges();
                            }
                        }
                    }
                }
                var lstCD = db.PSChiDinhDichVus.Where(p => p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepnhan && p.MaDonVi == maDonVi && p.isXoa == false).ToList();
                if (lstCD.Count > 0)
                {
                    foreach (var CD in lstCD)
                    {
                        CD.isXoa = true;
                        CD.isDongBo = false;
                        CD.IDNhanVienXoa = maNV;
                        CD.lyDoXoa = lydoXoa;
                        CD.NgayGioXoa = ngaygio;
                        db.SubmitChanges();
                        var lstchitiet = db.PSChiDinhDichVuChiTiets.Where(p => p.MaPhieu == maPhieu && p.MaChiDinh == CD.MaChiDinh && p.isXoa == false).ToList();
                        if (lstchitiet.Count > 0)
                        {
                            foreach (var ct in lstchitiet)
                            {
                                ct.isXoa = true;
                                ct.isDongBo = false;
                                ct.IDNhanVienXoa = maNV;
                                ct.NgayGioXoa = ngaygio;
                                db.SubmitChanges();
                            }
                        }
                    }
                }
                var TN = db.PSTiepNhans.FirstOrDefault(p => p.MaTiepNhan == maTiepnhan && p.isXoa == false);
                if (TN != null)
                {

                    TN.isDongBo = false;
                    TN.isDaDanhGia = false;
                    // TN.NgayGioXoa = ngaygio;
                    //TN.LyDoXoa = lydoXoa;
                    // TN.IDNhanVienXoa = maNV;
                    db.SubmitChanges();
                }

                if (phieu != null)
                {
                    phieu.IDPhieuLan1 = string.Empty;
                    phieu.isLayMauLan2 = false;
                    phieu.TrangThaiMau = 1;
                    phieu.isDongBo = false;
                    db.SubmitChanges();
                }
                db.Transaction.Commit();
                db.Connection.Close();
            }


            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                if (string.IsNullOrEmpty(result.StringError))
                    result.StringError = ex.ToString();
            }
            return result;
        }
        public PsReponse InsertDotChiDinhDichVu(PsChiDinhvsDanhGia dg)
        {
            PsReponse result = new PsReponse();
            result.Result = true;
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                bool isNhapLieu = false;

                if (dg != null) //Nếu có thông tin đợt chỉ định thì bắt đầu kiểm tra và insert
                {
                    string MaBN = string.Empty;
                    string maPh = string.Empty;
                    var trp = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == dg.MaPhieu && p.IDCoSo == dg.MaDonVi);
                    if (trp != null)
                    {
                        if ((trp.TrangThaiMau ?? 0) < 0 || (trp.TrangThaiMau ?? 0) > 3)
                        {
                            db.Transaction.Rollback();
                            db.Connection.Close();
                            result.Result = false;
                            result.StringError = "Phiếu đã được duyệt nên không thể lưu kết quả !";
                            return result;
                        }
                    }
                    if (dg.Phieu != null)
                    {
                        //Kiểm tra xem phiêu đã tồn tại trong db chưa? nếu có rồi thì tiến hành update lại thông tin, nếu chưa thì tạo mới
                        if (dg.Phieu.BenhNhan != null)
                        #region //Kiểm tra xem Bệnh nhân đã tồn tại trong db chưa? nếu có rồi thì tiến hành update lại thông tin, nếu chưa thì tạo mới
                        {
                            if (!string.IsNullOrEmpty(dg.Phieu.BenhNhan.MotherName) && !string.IsNullOrEmpty(dg.Phieu.BenhNhan.MotherPhoneNumber) && !string.IsNullOrEmpty(dg.Phieu.BenhNhan.TenBenhNhan) && !string.IsNullOrEmpty(dg.Phieu.BenhNhan.DiaChi) && dg.Phieu.ngayGioLayMau != null)
                                isNhapLieu = true;
                            #region Nếu có thông tin bệnh nhân
                            if (!string.IsNullOrEmpty(dg.Phieu.BenhNhan.MaBenhNhan)) //Kiểm tra mã Bệnh nhân có tồn tại không? nếu có thì cập nhật thông tin bệnh nhân theo mã, nếu ko thì tạo mới.
                            {

                                var pat = db.PSPatients.FirstOrDefault(p => p.MaBenhNhan == dg.Phieu.BenhNhan.MaBenhNhan && p.isXoa == false);
                                if (pat != null) // Nếu có tồn tại bệnh nhân theo mã bệnh nhân
                                {
                                    #region Update Bệnh nhân 
                                    MaBN = dg.Phieu.maBenhNhan;
                                    pat.FatherName = dg.Phieu.BenhNhan.FatherName;
                                    pat.FatherPhoneNumber = dg.Phieu.BenhNhan.FatherPhoneNumber;
                                    pat.FatherBirthday = dg.Phieu.BenhNhan.FatherBirthday;
                                    pat.MotherBirthday = dg.Phieu.BenhNhan.MotherBirthday;
                                    pat.MotherPhoneNumber = dg.Phieu.BenhNhan.MotherPhoneNumber;
                                    pat.MotherName = dg.Phieu.BenhNhan.MotherName;
                                    pat.DiaChi = dg.Phieu.BenhNhan.DiaChi;
                                    pat.TenBenhNhan = dg.Phieu.BenhNhan.TenBenhNhan;
                                    pat.QuocTichID = dg.Phieu.BenhNhan.QuocTichID;
                                    pat.TuanTuoiKhiSinh = dg.Phieu.BenhNhan.TuanTuoiKhiSinh;
                                    pat.PhuongPhapSinh = dg.Phieu.BenhNhan.PhuongPhapSinh;
                                    pat.NoiSinh = dg.Phieu.BenhNhan.NoiSinh;
                                    pat.NgayGioSinh = dg.Phieu.BenhNhan.NgayGioSinh;
                                    pat.GioiTinh = dg.Phieu.BenhNhan.GioiTinh;
                                    pat.DanTocID = dg.Phieu.BenhNhan.DanTocID;
                                    pat.CanNang = dg.Phieu.BenhNhan.CanNang;                                 
                                    pat.IDThaiPhuTienSoSinh = dg.Phieu.BenhNhan.IDThaiPhuTienSoSinh ?? string.Empty;
                                    pat.isDongBo = false;
                                    pat.isXoa = false;
                                    if (string.IsNullOrEmpty(pat.MaKhachHang)||pat.MaKhachHang=="")
                                        pat.MaKhachHang = GetNewMaKhachHang(dg.MaDonVi, SoBanDau());
                                    pat.Para = dg.Phieu.BenhNhan.Para ?? "0000";
                                    db.SubmitChanges();
                                    #endregion Update Bệnh nhân 
                                }
                                else // Nếu ko có tồn tại bệnh nhân theo mã bệnh nhân
                                {
                                    #region Insert Bệnh nhân mới theo mã Bệnh Nhân
                                    PSPatient patient = new PSPatient();
                                    MaBN = dg.Phieu.BenhNhan.MaBenhNhan;
                                    patient.MaBenhNhan = MaBN;
                                    patient.FatherName = dg.Phieu.BenhNhan.FatherName;
                                    patient.FatherPhoneNumber = dg.Phieu.BenhNhan.FatherPhoneNumber;
                                    patient.FatherBirthday = dg.Phieu.BenhNhan.FatherBirthday;
                                    patient.MotherBirthday = dg.Phieu.BenhNhan.MotherBirthday;
                                    patient.MotherPhoneNumber = dg.Phieu.BenhNhan.MotherPhoneNumber;
                                    patient.MotherName = dg.Phieu.BenhNhan.MotherName;
                                    patient.DiaChi = dg.Phieu.BenhNhan.DiaChi;
                                    patient.TenBenhNhan = dg.Phieu.BenhNhan.TenBenhNhan;
                                    patient.QuocTichID = dg.Phieu.BenhNhan.QuocTichID;
                                    patient.TuanTuoiKhiSinh = dg.Phieu.BenhNhan.TuanTuoiKhiSinh;
                                    patient.PhuongPhapSinh = dg.Phieu.BenhNhan.PhuongPhapSinh;
                                    patient.NoiSinh = dg.Phieu.BenhNhan.NoiSinh;
                                    patient.NgayGioSinh = dg.Phieu.BenhNhan.NgayGioSinh;
                                    patient.GioiTinh = dg.Phieu.BenhNhan.GioiTinh;
                                    patient.DanTocID = dg.Phieu.BenhNhan.DanTocID;
                                    patient.CanNang = dg.Phieu.BenhNhan.CanNang;
                                    patient.IDThaiPhuTienSoSinh = dg.Phieu.BenhNhan.IDThaiPhuTienSoSinh ?? string.Empty;
                                    patient.isDongBo = false;
                                    patient.isXoa = false;
                                    patient.MaKhachHang = GetNewMaKhachHang(dg.MaDonVi, SoBanDau());
                                    patient.Para = dg.Phieu.BenhNhan.Para ?? "0000";
                                    db.PSPatients.InsertOnSubmit(patient);
                                    db.SubmitChanges();
                                    #endregion Insert Bệnh nhân mới theo mã Bệnh Nhân
                                }
                            }
                            else //nếu không tồn tại mã bệnh nhân thì insert bệnh nhân mới
                            {
                                #region Insert Bệnh nhân mới dữ liệu rỗng
                                PSPatient patient = new PSPatient();
                                MaBN = GetID();
                                patient.MaBenhNhan = MaBN;
                                patient.FatherName = dg.Phieu.BenhNhan.FatherName;
                                patient.FatherPhoneNumber = dg.Phieu.BenhNhan.FatherPhoneNumber;
                                patient.FatherBirthday = dg.Phieu.BenhNhan.FatherBirthday;
                                patient.MotherBirthday = dg.Phieu.BenhNhan.MotherBirthday;
                                patient.MotherPhoneNumber = dg.Phieu.BenhNhan.MotherPhoneNumber;
                                patient.MotherName = dg.Phieu.BenhNhan.MotherName;
                                patient.DiaChi = dg.Phieu.BenhNhan.DiaChi;
                                patient.TenBenhNhan = dg.Phieu.BenhNhan.TenBenhNhan;
                                patient.QuocTichID = dg.Phieu.BenhNhan.QuocTichID;
                                patient.TuanTuoiKhiSinh = dg.Phieu.BenhNhan.TuanTuoiKhiSinh;
                                patient.PhuongPhapSinh = dg.Phieu.BenhNhan.PhuongPhapSinh;
                                patient.NoiSinh = dg.Phieu.BenhNhan.NoiSinh;
                                patient.NgayGioSinh = dg.Phieu.BenhNhan.NgayGioSinh;
                                patient.GioiTinh = dg.Phieu.BenhNhan.GioiTinh;
                                patient.DanTocID = dg.Phieu.BenhNhan.DanTocID;
                                patient.CanNang = dg.Phieu.BenhNhan.CanNang;
                                patient.IDThaiPhuTienSoSinh = dg.Phieu.BenhNhan.IDThaiPhuTienSoSinh ?? string.Empty;
                                patient.isDongBo = false;
                                patient.isXoa = false;
                                patient.MaKhachHang = GetNewMaKhachHang(dg.MaDonVi, SoBanDau());
                                patient.Para = dg.Phieu.BenhNhan.Para ?? "0000";
                                db.PSPatients.InsertOnSubmit(patient);
                                db.SubmitChanges();
                                #endregion Insert Bệnh nhân mới dữ liệu rỗng
                            }
                            #endregion Nếu có thông tin bệnh nhân
                        }
                        #endregion
                        else
                        #region// Nếu không tồn tại thông tin Bệnh nhận theo phiếu thì tạo 1 bệnh nhân rỗng
                        {
                            #region Nếu khôngcó thông tin bệnh nhân
                            #region Insert Bệnh nhân mới dữ liệu rỗng
                            PSPatient patient = new PSPatient();
                            MaBN = GetID();
                            patient.MaBenhNhan = MaBN;
                            patient.FatherName = dg.Phieu.BenhNhan.FatherName;
                            patient.FatherPhoneNumber = dg.Phieu.BenhNhan.FatherPhoneNumber;
                            patient.FatherBirthday = dg.Phieu.BenhNhan.FatherBirthday;
                            patient.MotherBirthday = dg.Phieu.BenhNhan.MotherBirthday;
                            patient.MotherPhoneNumber = dg.Phieu.BenhNhan.MotherPhoneNumber;
                            patient.MotherName = dg.Phieu.BenhNhan.MotherName;
                            patient.DiaChi = dg.Phieu.BenhNhan.DiaChi;
                            patient.TenBenhNhan = dg.Phieu.BenhNhan.TenBenhNhan;
                            patient.QuocTichID = dg.Phieu.BenhNhan.QuocTichID;
                            patient.TuanTuoiKhiSinh = dg.Phieu.BenhNhan.TuanTuoiKhiSinh;
                            patient.PhuongPhapSinh = dg.Phieu.BenhNhan.PhuongPhapSinh;
                            patient.NoiSinh = dg.Phieu.BenhNhan.NoiSinh;
                            patient.NgayGioSinh = dg.Phieu.BenhNhan.NgayGioSinh;
                            patient.GioiTinh = dg.Phieu.BenhNhan.GioiTinh;
                            patient.DanTocID = dg.Phieu.BenhNhan.DanTocID;
                            patient.CanNang = dg.Phieu.BenhNhan.CanNang;
                            patient.IDThaiPhuTienSoSinh = dg.Phieu.BenhNhan.IDThaiPhuTienSoSinh ?? string.Empty;
                            patient.isDongBo = false;
                            patient.isXoa = false;
                            patient.MaKhachHang = GetNewMaKhachHang(dg.MaDonVi, SoBanDau());
                            patient.Para = dg.Phieu.BenhNhan.Para ?? "0000";
                            db.PSPatients.InsertOnSubmit(patient);
                            db.SubmitChanges();
                            #endregion Insert Bệnh nhân mới dữ liệu rỗng
                            #endregion Nếu không có thông tin bệnh nhân
                        }
                        #endregion

                        if (!string.IsNullOrEmpty(MaBN)) //Kiểm tra dữ liệu bệnh nhân đã được insert vào db chưa?
                        {
                            #region Xử lý thông tin phiếu
                            if (string.IsNullOrEmpty(dg.Phieu.maPhieu)) //Nếu mã phiếu không tồn tại thì tạo phiếu mới
                            {
                                result.StringError = "Mã phiếu không được để trống";
                                throw new Exception("Mã phiếu không được để trống");
                               
                            }
                            else //nếu tồn tại mã phiếu thì...
                            {
                                var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDCoSo == dg.MaDonVi && p.IDPhieu == dg.MaPhieu && p.isXoa == false);
                                if (phieu != null) //kiểm tra phiếu đã nằm trong db hay chưa, nếu rồi thì update
                                {
                                    #region Update thông tin phiếu
                                    phieu.CheDoDinhDuong = dg.Phieu.maCheDoDinhDuong;
                                    phieu.IDChuongTrinh = dg.Phieu.maChuongTrinh;
                                    phieu.IDCoSo = dg.Phieu.maDonViCoSo;
                                    phieu.IDNhanVienLayMau = dg.Phieu.maNVLayMau;
                                    if (string.IsNullOrEmpty(phieu.IDNhanVienTaoPhieu))
                                        phieu.IDNhanVienTaoPhieu = dg.Phieu.maNVTaoPhieu;
                                    phieu.IDPhieu = dg.Phieu.maPhieu;
                                    phieu.IDPhieuLan1 = dg.Phieu.maPhieuLan1;
                                    phieu.IDViTriLayMau = dg.Phieu.idViTriLayMau;
                                    phieu.isGuiMauTre = dg.Phieu.isGuiMauTre;
                                    phieu.isHuyMau = false;
                                    if (!string.IsNullOrEmpty(phieu.IDPhieuLan1))
                                        phieu.isLayMauLan2 = true;
                                    else phieu.isLayMauLan2 = false;
                                    phieu.isKhongDat = dg.Phieu.isKhongDat;
                                    phieu.isNheCan = dg.Phieu.isNheCan;
                                    phieu.isSinhNon = dg.Phieu.isSinhNon;
                                    phieu.isTruoc24h = dg.Phieu.isTruoc24h;
                                    phieu.MaBenhNhan = MaBN;
                                    if (phieu.TrangThaiMau < 3)
                                        phieu.MaGoiXN = dg.Phieu.maGoiXetNghiem;
                                    if (string.IsNullOrEmpty(phieu.MaXetNghiem))
                                        phieu.MaXetNghiem = dg.Phieu.maXetNghiem;
                                    phieu.NgayGioLayMau = dg.Phieu.ngayGioLayMau;
                                    phieu.NgayNhanMau = dg.Phieu.ngayNhanMau;
                                    phieu.NgayTaoPhieu = dg.Phieu.ngayTaoPhieu;
                                    phieu.NgayTruyenMau = dg.Phieu.ngayTruyenMau;
                                    phieu.NoiLayMau = dg.Phieu.NoiLayMau;
                                    phieu.DiaChiLayMau = dg.Phieu.DiaChiLayMau;
                                    phieu.Para = dg.Phieu.paRa;
                                    phieu.SDTNhanVienLayMau = dg.Phieu.SoDTNhanVienLayMau;
                                    phieu.SLTruyenMau = dg.Phieu.soLuongTruyenMau;
                                    phieu.TenNhanVienLayMau = dg.Phieu.TenNhanVienLayMau;
                                    phieu.TinhTrangLucLayMau = dg.Phieu.maTinhTrangLucLayMau;
                                    if (phieu.TrangThaiMau < 2)
                                        phieu.TrangThaiMau = 2;
                                    phieu.LuuYPhieu = dg.Phieu.LuuYPhieu!=null?dg.Phieu.LuuYPhieu.TrimEnd():"";
                                    phieu.isDongBo = false;
                                    phieu.isXoa = false;
                                    phieu.TrangThaiPhieu = true;
                                    phieu.LyDoKhongDat = dg.Phieu.lydokhongdat;
                                    db.SubmitChanges();
                                    #endregion Update thông tin phiếu
                                }
                                else // nếu chưa thì tạo phiếu và insert vào db
                                {
                                    #region Tạo phiếu mới theo thông tin phiếu của đợt chỉ định
                                    PSPhieuSangLoc p = new PSPhieuSangLoc();
                                    p.LuuYPhieu = dg.Phieu.LuuYPhieu != null ? dg.Phieu.LuuYPhieu.TrimEnd() : "";
                                    p.CheDoDinhDuong = dg.Phieu.maCheDoDinhDuong;
                                    p.IDChuongTrinh = dg.Phieu.maChuongTrinh;
                                    p.IDCoSo = dg.Phieu.maDonViCoSo;
                                    p.IDNhanVienLayMau = dg.Phieu.maNVLayMau;
                                    p.IDNhanVienTaoPhieu = dg.Phieu.maNVTaoPhieu;
                                    p.IDPhieu = dg.Phieu.maPhieu;
                                    p.IDPhieuLan1 = dg.Phieu.maPhieuLan1;
                                    p.IDViTriLayMau = dg.Phieu.idViTriLayMau;
                                    p.isGuiMauTre = dg.Phieu.isGuiMauTre;
                                    p.isHuyMau = false;
                                    p.isKhongDat = dg.Phieu.isKhongDat;
                                    if (!string.IsNullOrEmpty(p.IDPhieuLan1))
                                        p.isLayMauLan2 = true;
                                    else p.isLayMauLan2 = false;
                                    p.isNheCan = dg.Phieu.isNheCan;
                                    p.isSinhNon = dg.Phieu.isSinhNon;
                                    p.isTruoc24h = dg.Phieu.isTruoc24h;
                                    p.MaBenhNhan = MaBN;
                                    p.MaGoiXN = dg.Phieu.maGoiXetNghiem;
                                    p.MaXetNghiem = dg.Phieu.maXetNghiem;
                                    p.NgayGioLayMau = dg.Phieu.ngayGioLayMau;
                                    p.NgayNhanMau = dg.Phieu.ngayNhanMau;
                                    p.NgayTaoPhieu = dg.Phieu.ngayTaoPhieu;
                                    p.NgayTruyenMau = dg.Phieu.ngayTruyenMau;
                                    p.NoiLayMau = dg.Phieu.NoiLayMau;
                                    p.DiaChiLayMau = dg.Phieu.DiaChiLayMau;
                                    p.Para = dg.Phieu.paRa;
                                    p.SDTNhanVienLayMau = dg.Phieu.SoDTNhanVienLayMau;
                                    p.SLTruyenMau = dg.Phieu.soLuongTruyenMau;
                                    p.TenNhanVienLayMau = dg.Phieu.TenNhanVienLayMau;
                                    p.TinhTrangLucLayMau = dg.Phieu.maTinhTrangLucLayMau;
                                    p.TrangThaiMau = 2;
                                    p.TrangThaiPhieu = true;
                                    p.isDongBo = false;
                                    p.isXoa = false;
                                    p.LyDoKhongDat = dg.Phieu.lydokhongdat;
                                    db.PSPhieuSangLocs.InsertOnSubmit(p);
                                    db.SubmitChanges();//gan mPh = maphieu
                                    #endregion Tạo  phiếu mới theo thông tin phiếu của đợt chỉ định
                                }
                            }
                            #endregion Xử lý thông tin phiếu
                        }
                        else //Nếu Thông tin bệnh nhân chưa được insert vào db thì báo lỗi
                        {
                            result.Result = false;
                            result.StringError = "Không lưu được thông tin bệnh nhân theo phiếu.";
                            throw new Exception();
                        }
                    }
                    else // Nếu không có thông tin phiếu thì tạo 1 phiếu mới + bệnh nhân theo phiếu
                    {
                        #region Nếu phiếu ko chứa dữ liệu
                        #region Insert Bệnh nhân mới Theo mã tự tạo của Phần mềm
                        PSPatient patient = new PSPatient();
                        MaBN = GetID();
                        patient.MaBenhNhan = MaBN;
                        patient.FatherName = dg.Phieu.BenhNhan.FatherName;
                        patient.FatherPhoneNumber = dg.Phieu.BenhNhan.FatherPhoneNumber;
                        patient.FatherBirthday = dg.Phieu.BenhNhan.FatherBirthday;
                        patient.MotherBirthday = dg.Phieu.BenhNhan.MotherBirthday;
                        patient.MotherPhoneNumber = dg.Phieu.BenhNhan.MotherPhoneNumber;
                        patient.MotherName = dg.Phieu.BenhNhan.MotherName;
                        patient.DiaChi = dg.Phieu.BenhNhan.DiaChi;
                        patient.TenBenhNhan = dg.Phieu.BenhNhan.TenBenhNhan;
                        patient.QuocTichID = dg.Phieu.BenhNhan.QuocTichID;
                        patient.TuanTuoiKhiSinh = dg.Phieu.BenhNhan.TuanTuoiKhiSinh;
                        patient.PhuongPhapSinh = dg.Phieu.BenhNhan.PhuongPhapSinh;
                        patient.NoiSinh = dg.Phieu.BenhNhan.NoiSinh;
                        patient.NgayGioSinh = dg.Phieu.BenhNhan.NgayGioSinh;
                        patient.GioiTinh = dg.Phieu.BenhNhan.GioiTinh;
                        patient.DanTocID = dg.Phieu.BenhNhan.DanTocID;
                        patient.CanNang = dg.Phieu.BenhNhan.CanNang;
                        patient.IDThaiPhuTienSoSinh = dg.Phieu.BenhNhan.IDThaiPhuTienSoSinh ?? string.Empty;
                        patient.isDongBo = false;
                        patient.isXoa = false;
                        patient.MaKhachHang = GetNewMaKhachHang(dg.MaDonVi, SoBanDau());
                        patient.Para = dg.Phieu.BenhNhan.Para ?? "0000";
                        db.PSPatients.InsertOnSubmit(patient);
                        db.SubmitChanges();
                        #endregion Insert Bệnh nhân mới Theo mã tự tạo của Phần mềm
                        #region Insert một phiếu mới
                        PSPhieuSangLoc p = new PSPhieuSangLoc();
                        p.CheDoDinhDuong = dg.Phieu.maCheDoDinhDuong;
                        p.IDChuongTrinh = dg.Phieu.maChuongTrinh;
                        p.IDCoSo = dg.Phieu.maDonViCoSo;
                        p.IDNhanVienLayMau = dg.Phieu.maNVLayMau;
                        p.IDNhanVienTaoPhieu = dg.Phieu.maNVTaoPhieu;
                        p.IDPhieu = dg.Phieu.maPhieu;
                        p.IDPhieuLan1 = dg.Phieu.maPhieuLan1;
                        p.IDViTriLayMau = dg.Phieu.idViTriLayMau;
                        p.isGuiMauTre = dg.Phieu.isGuiMauTre;
                        p.isHuyMau = false;
                        p.isKhongDat = dg.Phieu.isKhongDat;
                        if (!string.IsNullOrEmpty(p.IDPhieuLan1))
                            p.isLayMauLan2 = true;
                        else p.isLayMauLan2 = false;
                        p.isNheCan = dg.Phieu.isNheCan;
                        p.isSinhNon = dg.Phieu.isSinhNon;
                        p.isTruoc24h = dg.Phieu.isTruoc24h;
                        p.MaBenhNhan = MaBN;
                        p.MaGoiXN = dg.Phieu.maGoiXetNghiem;
                        p.MaXetNghiem = dg.Phieu.maXetNghiem;
                        p.NgayGioLayMau = dg.Phieu.ngayGioLayMau;
                        p.NgayNhanMau = dg.Phieu.ngayNhanMau;
                        p.NgayTaoPhieu = dg.Phieu.ngayTaoPhieu;
                        p.NgayTruyenMau = dg.Phieu.ngayTruyenMau;
                        p.NoiLayMau = dg.Phieu.NoiLayMau;
                        p.DiaChiLayMau = dg.Phieu.DiaChiLayMau;
                        p.Para = dg.Phieu.paRa;
                        p.SDTNhanVienLayMau = dg.Phieu.SoDTNhanVienLayMau;
                        p.SLTruyenMau = dg.Phieu.soLuongTruyenMau;
                        p.TenNhanVienLayMau = dg.Phieu.TenNhanVienLayMau;
                        p.TinhTrangLucLayMau = dg.Phieu.maTinhTrangLucLayMau;
                        p.TrangThaiMau = 2;
                        p.TrangThaiPhieu = true;
                        p.LyDoKhongDat = dg.Phieu.lydokhongdat;
                        p.isDongBo = false;
                        p.isXoa = false;
                        db.PSPhieuSangLocs.InsertOnSubmit(p);
                        db.SubmitChanges();
                        #endregion Insert một phiếu mới
                        #endregion Nếu phiếu ko chứa dữ liệu
                    }

                    var lstld = db.PSChiTietDanhGiaChatLuongs.Where(p => p.MaTiepNhan == dg.MaTiepNhan && p.IDPhieu == dg.MaPhieu).ToList();
                    if (lstld.Count <= 0)
                    {
                        if (dg.Phieu.lstLyDoKhongDat.Count > 0)
                        {
                            foreach (var ld in dg.Phieu.lstLyDoKhongDat)
                            {
                                ld.isDongBo = false;
                                ld.isXoa = false;
                                db.PSChiTietDanhGiaChatLuongs.InsertOnSubmit(ld);
                                db.SubmitChanges();
                            }
                        }
                    }
                    else
                    {
                        db.PSChiTietDanhGiaChatLuongs.DeleteAllOnSubmit(lstld);
                        db.SubmitChanges();
                        if (dg.Phieu.lstLyDoKhongDat.Count > 0)
                        {
                            foreach (var ld in dg.Phieu.lstLyDoKhongDat)
                            {
                                ld.isDongBo = false;
                                ld.isXoa = false;
                                db.PSChiTietDanhGiaChatLuongs.InsertOnSubmit(ld);
                                db.SubmitChanges();
                            }
                        }
                    }


                    string mCD = string.Empty;
                    #region Xử lý dữ liệu của đợt chỉ định
                    if ((db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieu == dg.MaPhieu && p.isXoa == false).TrangThaiMau ?? 0) < 3)
                    {
                        decimal dongia = 0;
                        var goidv = db.PSDanhMucGoiDichVuChungs.FirstOrDefault(p =>  p.IDGoiDichVuChung == dg.MaGoiDichVu );
                        if (goidv != null)
                            dongia = goidv.DonGia ?? 0;
                        if (string.IsNullOrEmpty(dg.MaChiDinh))
                        {
                            var cd = db.PSChiDinhDichVus.FirstOrDefault(p => p.isXoa == false && p.MaPhieu == dg.MaPhieu && p.MaTiepNhan == dg.MaTiepNhan);
                            if (cd != null)
                            {
                                #region update đợt chỉ định 
                                cd.IDGoiDichVu = dg.MaGoiDichVu;
                                if (string.IsNullOrEmpty(cd.IDNhanVienChiDinh))
                                    cd.IDNhanVienChiDinh = dg.MaNVChiDinh;
                                cd.isLayMauLai = dg.isLayMauLai;
                                //cd.MaChiDinh = dg.MaChiDinh;
                                cd.MaDonVi = dg.MaDonVi;
                                cd.isDaNhapLieu = isNhapLieu;
                                cd.MaNVChiDinh = dg.MaNVChiDinh;
                                cd.MaPhieu = dg.Phieu.maPhieu;
                                cd.MaPhieuLan1 = dg.MaPhieuLan1;
                                cd.NgayChiDinhHienTai = dg.NgayChiDinhHienTai;
                                cd.NgayChiDinhLamViec = dg.NgayChiDinhLamViec;
                                cd.SoLuong = dg.SoLuong;
                                if (cd.DonGia == null)
                                    cd.DonGia = dongia;
                                else if (cd.DonGia == 0)
                                    cd.DonGia = dongia;
                                cd.MaTiepNhan = dg.MaTiepNhan;
                                //if(cd.TrangThai<1)
                                //cd.TrangThai = dg.TrangThaiChiDinh;
                                cd.NgayTiepNhan = dg.NgayTiepNhan;
                                cd.isDongBo = false;
                                cd.isXoa = false;

                                db.SubmitChanges();
                                mCD = cd.MaChiDinh;
                                #endregion update đợt chỉ định 
                            }
                            else
                            {
                                #region Insert đợt chỉ định mới
                                PSChiDinhDichVu cdi = new PSChiDinhDichVu();
                                cdi.IDGoiDichVu = dg.MaGoiDichVu;
                                cdi.IDNhanVienChiDinh = dg.MaNVChiDinh;
                                cdi.isLayMauLai = dg.isLayMauLai;
                                cdi.MaChiDinh = "CD" + GetID();
                                cdi.MaDonVi = dg.MaDonVi;
                                cdi.isDaNhapLieu = isNhapLieu;
                                cdi.MaNVChiDinh = dg.MaNVChiDinh;
                                cdi.MaPhieu = dg.Phieu.maPhieu;
                                cdi.MaPhieuLan1 = dg.MaPhieuLan1;
                                cdi.NgayChiDinhHienTai = dg.NgayChiDinhHienTai;
                                cdi.NgayChiDinhLamViec = dg.NgayChiDinhLamViec;
                                cdi.SoLuong = dg.SoLuong;
                                if (cdi.DonGia == null)
                                    cdi.DonGia = dongia;
                                else if (cdi.DonGia == 0)
                                    cdi.DonGia = dongia;
                                cdi.MaTiepNhan = dg.MaTiepNhan;
                                cdi.TrangThai = 1;
                                cdi.NgayTiepNhan = dg.NgayTiepNhan;
                                cdi.isDongBo = false;
                                cdi.isXoa = false;
                                db.PSChiDinhDichVus.InsertOnSubmit(cdi);
                                db.SubmitChanges();
                                mCD = cdi.MaChiDinh;
                            }
                            #endregion Insert đợt chỉ định mới
                        }
                        else
                        {
                            var cd = db.PSChiDinhDichVus.FirstOrDefault(p => p.isXoa == false && p.MaChiDinh == dg.MaChiDinh);
                            if (cd != null)
                            {
                                #region update đợt chỉ định 
                                cd.IDGoiDichVu = dg.MaGoiDichVu;
                                if (string.IsNullOrEmpty(cd.IDNhanVienChiDinh))
                                    cd.IDNhanVienChiDinh = dg.MaNVChiDinh;
                                cd.isLayMauLai = dg.isLayMauLai;
                                cd.MaChiDinh = dg.MaChiDinh;
                                cd.MaDonVi = dg.MaDonVi;
                                cd.isDaNhapLieu = isNhapLieu;
                                cd.MaNVChiDinh = dg.MaNVChiDinh;
                                cd.MaPhieu = dg.Phieu.maPhieu;
                                cd.MaPhieuLan1 = dg.MaPhieuLan1;
                                cd.NgayChiDinhHienTai = dg.NgayChiDinhHienTai;
                                cd.NgayChiDinhLamViec = dg.NgayChiDinhLamViec;
                                cd.SoLuong = dg.SoLuong;
                                if (cd.DonGia == null)
                                    cd.DonGia = dongia;
                                else if (cd.DonGia == 0)
                                    cd.DonGia = dongia;
                                cd.MaTiepNhan = dg.MaTiepNhan;
                                //if(cd.TrangThai<1)
                                //cd.TrangThai = dg.TrangThaiChiDinh;
                                cd.NgayTiepNhan = dg.NgayTiepNhan;
                                cd.isDongBo = false;
                                cd.isXoa = false;
                                db.SubmitChanges();
                                mCD = cd.MaChiDinh;
                                #endregion update đợt chỉ định 
                            }
                            else
                            {
                                #region Insert đợt chỉ định mới
                                PSChiDinhDichVu cdi = new PSChiDinhDichVu();
                                cdi.IDGoiDichVu = dg.MaGoiDichVu;
                                cdi.IDNhanVienChiDinh = dg.MaNVChiDinh;
                                cdi.isLayMauLai = dg.isLayMauLai;
                                cdi.MaChiDinh = dg.MaChiDinh;
                                cdi.MaDonVi = dg.MaDonVi;
                                cdi.isDaNhapLieu = isNhapLieu;
                                cdi.MaNVChiDinh = dg.MaNVChiDinh;
                                cdi.MaPhieu = dg.Phieu.maPhieu;
                                cdi.MaPhieuLan1 = dg.MaPhieuLan1;
                                cdi.NgayChiDinhHienTai = dg.NgayChiDinhHienTai;
                                cdi.NgayChiDinhLamViec = dg.NgayChiDinhLamViec;
                                cdi.SoLuong = dg.SoLuong;
                                cdi.MaTiepNhan = dg.MaTiepNhan;
                                cdi.TrangThai = 1;
                                cdi.NgayTiepNhan = dg.NgayTiepNhan;
                                if (cd.DonGia == null)
                                    cd.DonGia = dongia;
                                else if (cd.DonGia == 0)
                                    cd.DonGia = dongia;
                                cdi.isDongBo = false;
                                cdi.isXoa = false;
                                db.PSChiDinhDichVus.InsertOnSubmit(cdi);
                                db.SubmitChanges();
                                mCD = dg.MaChiDinh;
                                #endregion Insert đợt chỉ định mới
                            }
                        }
                        if (!string.IsNullOrEmpty(mCD))
                        {
                            //******Kiểm tra lại chi tiết các gói dịch vụ đã chỉ định cho trường hợp chỉ định dịch vụ thay đổi gói xét nghiệm
                            // 1 --Lấy tất cả các chi tiết dv của phiếu đã đc chỉ định
                            // 2 --Kiểm tra 
                            // *** LƯU Ý : quá trình cập nhật lại(xóa hoặc thêm ) chi tiết list dịch vụ này thì kiểm tra tình trạng mẫu của mã phiếu trước ( nếu <3 [chưa vào phòng XN] ) thì mới đc thực hiện.
                            List<PSChiDinhDichVuChiTiet> lstdvchitiet = new List<PSChiDinhDichVuChiTiet>();
                            foreach (var itemdv in dg.lstDichVu)
                            {
                                PSChiDinhDichVuChiTiet dv = new PSChiDinhDichVuChiTiet();
                                dv.GiaTien = itemdv.GiaDichVu;
                                dv.isXetNghiemLan2 = false;
                                dv.MaChiDinh = mCD;
                                dv.MaDichVu = itemdv.IDDichVu;
                                dv.MaDonVi = dg.MaDonVi;
                                dv.MaGoiDichVu = dg.MaGoiDichVu;
                                dv.MaPhieu = dg.Phieu.maPhieu;
                                dv.SoLuong = dg.SoLuong;
                                dv.isDongBo = false;
                                dv.isXoa = false;
                                lstdvchitiet.Add(dv);
                            }
                            if (lstdvchitiet.Count > 0)
                            {
                                #region Bỏ
                                //var lstdvcu = db.PSChiDinhDichVuChiTiets.Where(p => p.MaChiDinh == mCD && p.isXoa == false).ToList();
                                //if (lstdvcu.Count > 0) //Kiểm tra nếu các chi tiết dịch vụ đã đc add rồi thì
                                //{
                                //    var lstmagoi = lstdvcu.GroupBy(p => p.MaGoiDichVu).ToList(); //chia nhóm theo gói XN
                                //    if (lstmagoi.Count > 0)
                                //    {
                                //        foreach (var goi in lstmagoi) //với mỗi nhóm
                                //        {
                                //            var lstdvcunggoiXN = lstdvcu.Where(p => p.MaGoiDichVu == dg.MaGoiDichVu).ToList();
                                //            if (dg.MaGoiDichVu == goi.Key) //kiểm tra xem có trùng với mã nhóm xét nghiệm của dữ liệu đầu vào ko?
                                //            {
                                //                //Nếu trùng

                                //                if (lstdvcunggoiXN.Count == dg.lstDichVu.Count) //Kiểm tra số lượng các dịch vụ đi theo gói XN đó có bằng với số lượng dịch vụ dữ liệu đầu vào ko?
                                //                {   //Nếu bằng số lượng thì... 
                                //                    var listGiaonnhautrongdb = lstdvcu.Intersect(lstdvchitiet).ToList();//lấy giá trị giao nhau giữa 2 list
                                //                    if (listGiaonnhautrongdb.Count != lstdvcunggoiXN.Count) // kiểm tra chi tiết trong gói dịch vụ đã add có trùng với tất cả chi tiết dịch vụ của dữ liệu đầu vào ko?
                                //                    {
                                //                        //nếu có bất cứ 1 mẫu ko trùng thì xóa hết list dv đang nằm trong  db
                                //                        foreach (var item in lstdvcunggoiXN)
                                //                        {
                                //                            item.isXoa = true;
                                //                            item.isDongBo = false;
                                //                            db.SubmitChanges();
                                //                        }
                                //                        //foreach (var itemadd in lstdvchitiet) // và add mới
                                //                        //{
                                //                        //    db.PSChiDinhDichVuChiTiets.InsertOnSubmit(itemadd);
                                //                        //    db.SubmitChanges();
                                //                        //}
                                //                    }
                                //                     // nếu như list dv trong db trùng với list dv của dữ liệu đầu vào thì thôi
                                //                }
                                //                else // Nếu số lượng ko bằng
                                //                {
                                //                    foreach( var item in lstdvcunggoiXN) //xóa hết các
                                //                    {
                                //                        item.isXoa = true;
                                //                        item.isDongBo = false;
                                //                        db.SubmitChanges();
                                //                    }
                                //                    //foreach (var itemadd in lstdvchitiet) // và add mới
                                //                    //{
                                //                    //    db.PSChiDinhDichVuChiTiets.InsertOnSubmit(itemadd);
                                //                    //    db.SubmitChanges();
                                //                    //}
                                //                }
                                //            }
                                //            else
                                //            {
                                //                //  var lstcanxoa = db.PSChiDinhDichVuChiTiets.Where(p => p.MaChiDinh == mCD && p.isXoa == false && p.MaGoiDichVu == goi.Key).ToList();
                                //                if (lstdvcunggoiXN.Count > 0)
                                //                {
                                //                    foreach (var item in lstdvcunggoiXN)
                                //                    {
                                //                        item.isXoa = true;
                                //                        item.isDongBo = false;
                                //                        db.SubmitChanges();
                                //                    }
                                //                    //foreach (var itemadd in lstdvchitiet) // và add mới
                                //                    //{
                                //                    //    db.PSChiDinhDichVuChiTiets.InsertOnSubmit(itemadd);
                                //                    //    db.SubmitChanges();
                                //                    //}

                                //                }
                                //            }
                                //        }
                                //    }
                                //}
                                //else {
                                #endregion bỏ
                                if ((db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == dg.MaPhieu).TrangThaiMau ?? 1) < 3)
                                {
                                    var lstdvcu = db.PSChiDinhDichVuChiTiets.Where(p => p.MaChiDinh == mCD && p.isXoa == false).ToList();
                                    if (lstdvcu.Count > 0) //Kiểm tra nếu các chi tiết dịch vụ đã đc add rồi thì xóa
                                    {
                                        //foreach (var dv in lstdvcu)
                                        //{
                                        //    dv.isDongBo = false;
                                        //    dv.isXoa = true;
                                        //    db.SubmitChanges();
                                        //}
                                        db.PSChiDinhDichVuChiTiets.DeleteAllOnSubmit(lstdvcu);
                                        db.SubmitChanges();
                                    }
                                    //insert chi tiết chi định
                                    //foreach (var dichvu in dg.lstDichVu)
                                    //{
                                    //    var dvu = db.PSChiDinhDichVuChiTiets.FirstOrDefault(p => p.MaChiDinh == mCD & p.MaDichVu == dichvu.IDDichVu && p.isXoa == false);
                                    //    if (dvu == null)
                                    //    {
                                    foreach (var item in lstdvchitiet)
                                    {
                                        db.PSChiDinhDichVuChiTiets.InsertOnSubmit(item);
                                        db.SubmitChanges();
                                    }
                                    //    }
                                    //}
                                }

                            }
                            else
                            {
                                //rollback
                                result.Result = false;
                                result.StringError = "Không tìm thấy thông tin dịch vụ trong gói xét nghiệm\r\n Vui lòng kiểm tra và thử lại.";
                                throw new Exception("Không tìm thấy thông tin dịch vụ trong gói xét nghiệm\r\n Vui lòng kiểm tra và thử lại.");
                            }

                        }
                        else
                        {
                            //rollback
                            result.Result = false;
                            result.StringError = "Không thể thêm mới đợt chỉ định này.";
                            throw new Exception("Không thể thêm mới đợt chỉ định này.");
                        }
                    }
                    else
                    {
                        var cd = db.PSChiDinhDichVus.FirstOrDefault(p => p.isXoa == false && p.MaPhieu == dg.MaPhieu && p.MaTiepNhan == dg.MaTiepNhan);
                        if (cd != null)
                        {
                            if (string.IsNullOrEmpty(cd.IDNhanVienChiDinh))
                                cd.IDNhanVienChiDinh = dg.MaNVChiDinh;
                            cd.isLayMauLai = dg.isLayMauLai;
                            //cd.MaChiDinh = dg.MaChiDinh;
                            cd.MaDonVi = dg.MaDonVi;
                            cd.isDaNhapLieu = isNhapLieu;
                            cd.MaNVChiDinh = dg.MaNVChiDinh;
                            cd.MaPhieu = dg.Phieu.maPhieu;
                            cd.MaPhieuLan1 = dg.MaPhieuLan1;
                            cd.NgayChiDinhHienTai = dg.NgayChiDinhHienTai;
                            //  cd.NgayChiDinhLamViec = dg.NgayChiDinhLamViec;
                            cd.SoLuong = dg.SoLuong;
                            cd.MaTiepNhan = dg.MaTiepNhan;
                            //if(cd.TrangThai<1)
                            //cd.TrangThai = dg.TrangThaiChiDinh;
                            cd.NgayTiepNhan = dg.NgayTiepNhan;
                            cd.isDongBo = false;
                            cd.isXoa = false;
                            db.SubmitChanges();
                        }
                    }


                    var tn = db.PSTiepNhans.Where(p => p.isXoa == false && p.MaPhieu == dg.MaPhieu && p.MaDonVi == dg.MaDonVi).ToList();
                    //if (isNhapLieu)
                    //{
                    if (tn.Count > 0)
                    {

                        foreach (var item in tn)
                        {
                            item.isDaNhapLieu = isNhapLieu;
                            item.isDaDanhGia = true;
                            item.isDongBo = false;
                            db.SubmitChanges();
                        }
                    }
                    //}
                    var ph = db.PSPhieuSangLocs.Where(p => p.isXoa == false && p.IDPhieu == dg.MaPhieu && p.IDCoSo == dg.MaDonVi).ToList();
                    if (ph.Count > 0)
                    {
                        foreach (var item in ph)
                        {
                            item.isXoa = false;
                            item.isDongBo = false;
                            item.TrangThaiPhieu = true;
                            if (item.TrangThaiMau < 3)//nếu mẫu chưa vào phòng xét nghiệm thì cập nhật trạng thái mẫu =2 (mẫu đã đc đánh giá)
                                item.TrangThaiMau = 2;
                            db.SubmitChanges();
                        }
                    }
                    if (!string.IsNullOrEmpty(dg.Phieu.maPhieuLan1))
                    {
                        try
                        {
                            var phieucu = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieu == dg.Phieu.maPhieuLan1 && p.isXoa == false);
                            if (phieucu != null)
                            {
                                phieucu.TrangThaiMau = 4;
                                phieucu.isDongBo = false;
                                db.SubmitChanges();
                            }
                        }
                        catch { }
                    }

                    #endregion Xử lý dữ liệu của đợt chỉ định
                    db.Transaction.Commit();
                    db.Connection.Close();
                }
               
            }

            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                if (string.IsNullOrEmpty(result.StringError))
                    result.StringError = ex.ToString();
            }
            return result;
        }
        public PsReponse UpdateThongTinPhieuLan1(string maphieulan1)
        {
            PsReponse result = new PsReponse();
            try {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var tt = db.PSPhieuSangLocs.FirstOrDefault(x => x.IDPhieu == maphieulan1);
                if(tt!=null)
                {
                     tt.TrangThaiMau = 7;
                   
                    db.SubmitChanges();                  
                }
                result.Result = true;

            }
            catch
            {
                result.Result = false;
            }
            return result;
        }
        public PsReponse UpdateThongTinTrungTam(PSThongTinTrungTam tt)
        {
            PsReponse result = new PsReponse();
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var trtam = db.PSThongTinTrungTams.FirstOrDefault();
                if (trtam != null)
                {
                    trtam.Diachi = tt.Diachi;
                    trtam.DienThoai = tt.DienThoai;
                    trtam.isChoThuLaiMauLan2 = tt.isChoThuLaiMauLan2;
                    trtam.isChoXNLan2 = tt.isChoXNLan2;
                    trtam.TenTrungTam = tt.TenTrungTam;
                    trtam.isCapMaXNTheoMaPhieu = tt.isCapMaXNTheoMaPhieu;
                    trtam.Email = tt.Email;
                    trtam.PassEmail = tt.PassEmail;
                    trtam.Logo = tt.Logo;
                    trtam.Header = tt.Header;
                    trtam.ChuKiTT = tt.ChuKiTT;
                    trtam.ChuKiXN = tt.ChuKiXN;
                    db.SubmitChanges();
                    result.Result = true;
                }
                else
                {
                    result.Result = false;
                    result.StringError = "Không có thông tin trung tâm. Vui lòng liên hệ với người quản trị để cài đặt cấu hình ban đầu!";
                }

                db.Transaction.Commit();
                db.Connection.Close();

            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                result.StringError = ex.ToString();
            }
            return result;
        }
        public PsReponse UpdateGhiChuXetNghiem(string maKQ, string ghiChu)
        {
            PsReponse result = new PsReponse();
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var res = db.PSXN_KetQuas.FirstOrDefault(p => p.isXoa == false && p.MaKetQua == maKQ);
                if (res != null)
                {
                    res.GhiChu = ghiChu;
                    db.SubmitChanges();
                }

                db.Transaction.Commit();
                db.Connection.Close();
                result.Result = true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                result.StringError = ex.ToString();
            }
            return result;

        }
        public string GetGhiChuXetNghiem(string maKQ)
        {
            string ghichu = null;
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var res = db.PSXN_KetQuas.FirstOrDefault(p => p.isXoa == false && p.MaKetQua == maKQ);
                if (res != null)
                {
                    ghichu=res.GhiChu;
                    
                }

                
            }
            catch (Exception ex)
            {
                
            }
            return ghichu;

        }
        //public bool InserTraKetQuaXN(PSXN_TraKetQua ketQua)
        //{
        //    db.Connection.Open();
        //    db.Transaction = db.Connection.BeginTransaction();
        //    try
        //    {
        //        db.PSXN_TraKetQuas.InsertOnSubmit(ketQua);
        //        db.SubmitChanges();
        //        db.Transaction.Commit();
        //        db.Connection.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        db.Transaction.Rollback();
        //        db.Connection.Close();
        //        return false;
        //    }
        //}
        //public bool UpdateTraKetQuaXN(PSXN_TraKetQua ketQua)
        //{
        //    db.Connection.Open();
        //    db.Transaction = db.Connection.BeginTransaction();
        //    try
        //    {
        //        var traKQ = db.PSXN_TraKetQuas.FirstOrDefault(p => p.MaTiepNhan == ketQua.MaTiepNhan);
        //        if(ketQua!=null)
        //        {
        //            traKQ.GhiChu = ketQua.GhiChu;
        //            traKQ.KetLuanTongQuat = ketQua.KetLuanTongQuat;
        //            traKQ.NgayTraKQ = ketQua.NgayTraKQ;
        //            traKQ.UserTraKQ = ketQua.UserTraKQ;
        //            db.SubmitChanges();
        //        }
        //        else
        //        {
        //            if(!InserTraKetQuaXN(ketQua))
        //            {
        //                throw new System.ArgumentException("Lỗi khi insert mới một record trả KQ", "original");
        //            }
        //        }

        //        db.Transaction.Commit();
        //        db.Connection.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        db.Transaction.Rollback();
        //        db.Connection.Close();
        //        return false;
        //    }
        //}
        //public bool InsertChiTietTraKetQua(PSXN_TraKQ_ChiTiet chiTietKQ)
        //{
        //    db.Connection.Open();
        //    db.Transaction = db.Connection.BeginTransaction();
        //    try
        //    {
        //        db.Transaction.Commit();
        //        db.Connection.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        db.Transaction.Rollback();
        //        db.Connection.Close();
        //        return false;
        //    }
        //}
        public PsReponse UpdateDanhMucGhiChu(PSDanhMucGhiChu ghichu)
        {
            PsReponse result = new PsReponse();
            result.Result = true;
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var res = db.PSDanhMucGhiChus.Where(p => p.MaGhiChu == ghichu.MaGhiChu).FirstOrDefault();
                if (res != null)
                {
                    res.ThongTinHienThiGhiChu = ghichu.ThongTinHienThiGhiChu;
                    res.isNoiDungDatTruoc = ghichu.isNoiDungDatTruoc;
                    db.SubmitChanges();
                }
                else
                {
                    result.Result = false;
                    result.StringError = "Không tồn tại trường hợp ghi chú này";
                }
                db.Transaction.Commit();
                db.Connection.Close();
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                result.StringError = ex.ToString();
            }
            return result;


        }
        public PsReponse InsertDotChanDoan(PSDotChuanDoan dotChanDoan)
        {
            PsReponse result = new PsReponse();
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                if (dotChanDoan != null)
                {
                    var dot = db.PSDotChuanDoans.FirstOrDefault(p => p.isXoa == false && p.rowIDDotChanDoan == dotChanDoan.rowIDDotChanDoan);
                    var benhnhannguycocao = db.PSBenhNhanNguyCoCaos.FirstOrDefault(p => p.isXoa == false && p.MaKhachHang == dotChanDoan.MaKhachHang);
                    if (dot != null)
                    {
                        dot.GhiChu = dotChanDoan.GhiChu;
                        dot.KetQua = dotChanDoan.KetQua;
                        dot.ChanDoan = dotChanDoan.ChanDoan;
                        if (benhnhannguycocao != null)
                        {
                            if(benhnhannguycocao.isDaChanDoan==false)
                            {
                                benhnhannguycocao.isDaChanDoan = true;
                            }
                        }
                        db.SubmitChanges();
                    }
                    else
                    {
                        if (benhnhannguycocao != null)
                        {
                            if (benhnhannguycocao.isDaChanDoan == false)
                            {
                                benhnhannguycocao.isDaChanDoan = true;
                            }
                        }
                        db.PSDotChuanDoans.InsertOnSubmit(dotChanDoan);
                        db.SubmitChanges();
                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
                result.Result = true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                result.StringError = ex.ToString();
            }
            return result;
        }
        public PsReponse UpdateTrangThaiBenhNhanNguyCoCao(bool isNguyCo, long rowIDBN)
        {
            PsReponse result = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var bn = db.PSBenhNhanNguyCoCaos.FirstOrDefault(p => p.isXoa == false && p.rowIDBenhNhanCanTheoDoi == rowIDBN);
                if (bn != null)
                {
                    bn.isNguyCoCao = isNguyCo;
                    bn.isXoa = false;
                    bn.isDongBo = false;
                    db.SubmitChanges();
                    result.Result = true;
                }
                else
                {
                    result.Result = false;
                    result.StringError = "Không tìm thấy thông tin bệnh nhân!";
                }
                db.Transaction.Commit();
                db.Connection.Close();

            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                result.StringError = ex.ToString();
            }
            return result;
        }
        public bool UpdatePhieuTraKetQuaChoXNLan2(string maPhieu, string maTiepNhan, string maDonVi)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var kq = db.PSXN_TraKetQuas.FirstOrDefault(p => p.isXoa == false && p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepNhan);
                if (kq != null)
                {
                    kq.isDaDuyetKQ = true;
                    kq.isTraKQ = true;
                    kq.isDongBo = false;
                    kq.isDongBoPDF = false;
                    db.SubmitChanges();
                }
                //var reskq = db.PSXN_TraKQ_ChiTiets.Where(p => p.isXoa == false && p.MaPhieu == maPhieu && p.MaTiepNhan == maTiepNhan).ToList();
                //if(reskq.Count>0)
                //{
                //    foreach(var ct in reskq)
                //    {
                //        ct.GiaTriCuoi = string.Empty;
                //        ct.isDongBo = false;
                //        db.SubmitChanges();
                //    }                }
                var resPhieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDCoSo == maDonVi && p.IDPhieu == maPhieu);
                if (resPhieu != null)
                {
                    resPhieu.TrangThaiMau = 5;
                    resPhieu.isXNLan2 = true;
                    resPhieu.isDongBo = false;
                    db.SubmitChanges();
                }

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        public List<PSXN_TraKetQua> GetDanhSachPDFChuaDongBo()
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            List<PSXN_TraKetQua> lis = new List<PSXN_TraKetQua>();
            try
            {
                var res = db.PSXN_TraKetQuas.OrderBy(x=>x.IDCoSo).Where(p => p.isXoa != true && p.isDongBoPDF!=true && p.isTraKQ==true && p.isDaDuyetKQ==true).ToList();
                if (res != null)
                {
                    return res;
                }
                else
                {
                    return lis;
                }
            }
            catch
            {
                return lis;
            }
            
        }
        public PsReponse UpdateDanhSachPDFChuaDongBo(List<string> Maphieu)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            PsReponse res = new PsReponse();
            try
            {
                foreach(var maphieu in Maphieu)
                {
                    var data = db.PSXN_TraKetQuas.FirstOrDefault(p => p.isXoa != true && p.MaPhieu == maphieu);
                    if (data != null)
                    {
                        data.isDongBoPDF = true;
                        db.SubmitChanges();
                       
                    }

                }
                res.Result = true;

            }
            catch
            {
                res.Result = false;
            }
            db.Transaction.Commit();
            db.Connection.Close();
            return res;
        }

        public PsReponse UpdateDuyetKetQua(bool isDuyet, string maTiepNhan, string maDonVi, string maPhieu)
        {
            PsReponse result = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var res = db.PSXN_TraKetQuas.FirstOrDefault(p => p.isXoa == false && p.MaTiepNhan == maTiepNhan);
                if (res != null)
                {
                    if (res.isTraKQ ?? false)
                    {
                        result.Result = false;
                        result.StringError = "Mẫu đã trả kết quả, không thể hủy duyệt!";
                        // db.Transaction.Commit();
                        db.Connection.Close();
                        return result;
                    }
                }
                else
                {
                    result.Result = false;
                    result.StringError = "Không có thông tin dữ liệu kết quả của phiếu này!";
                    //db.Transaction.Commit();
                    db.Connection.Close();
                    return result;
                }

                var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDCoSo == maDonVi && p.IDPhieu == maPhieu);
                if (phieu != null)
                {
                    if ((phieu.TrangThaiMau ?? 0) > 2)
                    {
                        var lstChiDinh = db.PSChiDinhDichVus.Where(p => p.MaDonVi == maDonVi && p.MaPhieu == maPhieu && p.isXoa == false).ToList();
                        if (lstChiDinh.Count > 1)
                        {
                            result.Result = false;
                            result.StringError = "Mẫu đã được chỉ định làm lại xét nghiệm.\r\n Vui lòng liên hệ với phòng đánh giá để hủy chỉ định xét nghiệm lại!";
                            //db.Transaction.Commit();
                            db.Connection.Close();
                            return result;
                        }
                        else
                        {
                            var phieuthulai = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieuLan1 == maPhieu);
                            if (phieuthulai != null)
                            {
                                if (phieuthulai.TrangThaiMau > 0)
                                {
                                    result.Result = false;
                                    result.StringError = "Mã phiếu đã được thu mẫu lại nên không thể hủy duyệt phiếu!";
                                    //db.Transaction.Commit();
                                    db.Connection.Close();
                                    return result;
                                }
                            }
                        }
                    }

                }
                else
                {
                    result.Result = false;
                    result.StringError = "Không có thông tin dữ liệu về phiếu này!";
                    //db.Transaction.Commit();
                    db.Connection.Close();
                    return result;
                }

                res.isDaDuyetKQ = isDuyet;
                res.isDongBo = false;
                db.SubmitChanges();
                db.Transaction.Commit();
                db.Connection.Close();
                result.Result = true;
                return result;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                result.StringError = " Lỗi trong quá trình kiểm tra điều kiện hủy" + ex.ToString();
                return result;
            }
        }
        public bool UpdateBangGhi(string maDuLieu, string GiaTri)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var res = db.BangGhiDuLieus.FirstOrDefault(p => p.MaDuLieu == maDuLieu);
                if (res != null)
                {
                    res.DuLieu = GiaTri;
                    db.SubmitChanges();
                }
                else
                {
                    BangGhiDuLieu moi = new BangGhiDuLieu();
                    moi.MaDuLieu = maDuLieu;
                    moi.DuLieu = GiaTri;
                    db.BangGhiDuLieus.InsertOnSubmit(moi);
                    db.SubmitChanges();

                }
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        public PsReponse InsertChiDinhTheoDanhSachHangLoat(PSTiepNhan dotTiepNhan, string maNVChiDinh, string maGoiXn)
        {
            PsReponse result = new PsReponse();
            result.Result = true;
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            bool isNhapLieu = false;
            try
            {
                if (string.IsNullOrEmpty(dotTiepNhan.MaPhieu))
                {
                    result.Result = false;
                    result.StringError = "Không có thông tin mã phiếu!";
                    throw new Exception("Không có thông tin mã phiếu!");
                }
                else
                {
                    var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == dotTiepNhan.MaPhieu && p.IDCoSo == dotTiepNhan.MaDonVi);
                    string _maGoiXN = maGoiXn;

                    if (phieu != null)
                    {
                        if (!string.IsNullOrEmpty(phieu.MaBenhNhan))
                        {
                            var bn = db.PSPatients.FirstOrDefault(p => p.isXoa == false && p.MaBenhNhan == phieu.MaBenhNhan);
                            if (bn != null)
                            {
                                if (!string.IsNullOrEmpty(bn.MotherName) && !string.IsNullOrEmpty(bn.MotherPhoneNumber) && !string.IsNullOrEmpty(bn.TenBenhNhan) && !string.IsNullOrEmpty(bn.DiaChi) && phieu.NgayGioLayMau != null)
                                    isNhapLieu = true;
                            }
                        }
                        if (string.IsNullOrEmpty(phieu.MaGoiXN))
                        {
                            phieu.MaGoiXN = maGoiXn;
                            phieu.isXoa = false;
                            phieu.isDongBo = false;
                            phieu.TrangThaiPhieu = true;
                            if (phieu.TrangThaiMau < 2)
                                phieu.TrangThaiMau = 2;
                            phieu.isXNLan2 = phieu.isXNLan2 ?? false;
                            phieu.isLayMauLan2 = phieu.isLayMauLan2 ?? false;

                            db.SubmitChanges();
                        }
                        else _maGoiXN = phieu.MaGoiXN;
                    }
                    else
                    {
                        PSPhieuSangLoc phSangLoc = new PSPhieuSangLoc();
                        phSangLoc.IDCoSo = dotTiepNhan.MaDonVi;
                        phSangLoc.IDPhieu = dotTiepNhan.MaPhieu;
                        phSangLoc.MaGoiXN = _maGoiXN;
                        phSangLoc.isDongBo = false;
                        phSangLoc.isXoa = false;
                        phSangLoc.TrangThaiPhieu = true;
                        phSangLoc.TrangThaiMau = 2;
                        phSangLoc.isXNLan2 = false;
                        phSangLoc.isLayMauLan2 = false;
                        phSangLoc.IDNhanVienTaoPhieu = maNVChiDinh;
                        phSangLoc.isKhongDat = false;
                        db.PSPhieuSangLocs.InsertOnSubmit(phSangLoc);
                        db.SubmitChanges();
                    }
                    var dongia = db.PSDanhMucGoiDichVuTheoDonVis.FirstOrDefault(p => p.IDGoiDichVuChung == _maGoiXN && p.MaDVCS == dotTiepNhan.MaDonVi).DonGia ?? 0;


                    PSChiDinhDichVu cd = new PSChiDinhDichVu();
                    cd.IDGoiDichVu = _maGoiXN;
                    cd.MaNVChiDinh = maNVChiDinh;
                    cd.MaChiDinh = cd.MaChiDinh = "CD" + GetID();
                    cd.isLayMauLai = false;
                    cd.MaNVChiDinh = maNVChiDinh;
                    cd.DonGia = dongia;
                    cd.MaDonVi = dotTiepNhan.MaDonVi;
                    cd.MaPhieu = dotTiepNhan.MaPhieu;
                    cd.MaTiepNhan = dotTiepNhan.MaTiepNhan;
                    cd.NgayChiDinhHienTai = DateTime.Now;
                    cd.NgayChiDinhLamViec = DateTime.Now;
                    cd.isDaNhapLieu = isNhapLieu;
                    cd.NgayTiepNhan = dotTiepNhan.NgayTiepNhan;
                    cd.SoLuong = 1;
                    cd.TrangThai = 1;
                    cd.isDongBo = false;
                    cd.isXoa = false;
                    db.PSChiDinhDichVus.InsertOnSubmit(cd);
                    db.SubmitChanges();
                    var listChiTietCD = db.PSChiTietGoiDichVuChungs.Where(p => p.IDGoiDichVuChung == _maGoiXN).ToList();
                   
                    if (listChiTietCD.Count > 0)
                    {
                        foreach (var item in listChiTietCD)
                        {
                            try
                            {                                                                                             
                                var ttdv = GetDichVuTheoDonVi(item.IDDichVu, dotTiepNhan.MaDonVi);
                                PSChiDinhDichVuChiTiet chitiet = new PSChiDinhDichVuChiTiet();
                                chitiet.GiaTien = ttdv.GiaDichVu;
                                chitiet.isDongBo = false;
                                chitiet.isXetNghiemLan2 = false;
                                chitiet.isXoa = false;
                                chitiet.MaChiDinh = cd.MaChiDinh;
                                chitiet.MaDichVu = ttdv.IDDichVu;
                                chitiet.MaDonVi = cd.MaDonVi;
                                chitiet.MaGoiDichVu = maGoiXn;
                                chitiet.MaPhieu = cd.MaPhieu;
                                chitiet.SoLuong = 1;
                                db.PSChiDinhDichVuChiTiets.InsertOnSubmit(chitiet);
                                db.SubmitChanges();
                            }
                            catch
                            {
                                result.Result = false;
                                result.StringError = "Chưa khai báo dịch vụ  cho gói" + _maGoiXN + " Mã dịch vụ chưa khai báo :" + item.IDDichVu;
                                throw new Exception("Chưa khai báo dịch vụ  cho gói!");
                            }
                        }

                    }
                    else
                    {
                        result.Result = false;
                        result.StringError = "Chưa khai báo gói dịch vụ chung";
                        throw new Exception("Chưa khai báo gói dịch vụ chung");
                    }
                    var _Tiepnhan = db.PSTiepNhans.FirstOrDefault(p => p.isXoa == false && p.MaTiepNhan == dotTiepNhan.MaTiepNhan);
                    if (_Tiepnhan != null)
                    {
                        _Tiepnhan.isDongBo = false;
                        _Tiepnhan.isDaDanhGia = true;
                        _Tiepnhan.isDaNhapLieu = isNhapLieu;
                        db.SubmitChanges();
                    }
                }

                db.Transaction.Commit();
                db.Connection.Close();

            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                if (string.IsNullOrEmpty(result.StringError))
                    result.StringError = ex.ToString();

            }
            finally
            {

            }
            return result;
        }
   
        public bool UpdateMaKhachHang(string maBenhNhan, string maDonvi, string chuoiNamThang)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var res = db.PSPatients.FirstOrDefault(p => p.isXoa == false && p.MaBenhNhan == maBenhNhan);
                if (res != null)
                {
                    if (string.IsNullOrEmpty(res.MaKhachHang))
                    {
                        res.MaKhachHang = GetNewMaKhachHang(maDonvi, chuoiNamThang);
                        db.SubmitChanges();
                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        public PsReponse UpdatePhieuThucHienThuMauLai(string maPhieu, string maDonvi)
        {
            PsReponse response = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == maPhieu && p.IDCoSo==maDonvi );
                if (phieu != null)
                {
                    phieu.TrangThaiMau = 6;//6
                    phieu.isDongBo = false;
                    db.SubmitChanges();
                    response.Result = true;
                }
                else
                {
                    response.Result = false;
                    response.StringError = "Không tìm thấy mã phiếu " + maPhieu + " để cập nhật trạng thái";
                }
                db.Transaction.Commit();
                db.Connection.Close();
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                response.Result = false;
                response.StringError = ex.ToString();
            }
            return response;
        }
        public PsReponse InsertKetQuaXN(PSXN_KetQua rowXN)
        {
            PsReponse response = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                bool isOK = false;
                var resKQ = db.PSXN_KetQuas.FirstOrDefault(p => p.isXoa == false && p.MaChiDinh == rowXN.MaChiDinh && p.MaTiepNhan == rowXN.MaTiepNhan);
                if (resKQ != null)
                {
                    rowXN.MaKetQua = resKQ.MaKetQua;
                    resKQ.isCoKQ = false;
                    resKQ.MaGoiXN = rowXN.MaGoiXN;
                    resKQ.isDongBo = false;
                    db.SubmitChanges();
                }
                else
                {
                    rowXN.MaKetQua = GetID();
                    rowXN.isCoKQ = false;
                    rowXN.isXoa = false;
                    rowXN.isDongBo = false;
                    db.PSXN_KetQuas.InsertOnSubmit(rowXN);
                    db.SubmitChanges();
                }
                var listDV = db.PSChiDinhDichVuChiTiets.Where(p => p.isXoa == false && p.MaChiDinh == rowXN.MaChiDinh).ToList();
                if (listDV.Count > 0)
                {
                    foreach (var DV in listDV)
                    {

                        var lstKT = db.PSMapsXN_DichVus.Where(p => p.IDDichVu == DV.MaDichVu).ToList();
                        if (lstKT.Count > 0)
                        {
                            foreach (var KT in lstKT)
                            {
                                var lstThongso = db.PSMapsXN_ThongSos.Where(p => p.IDKyThuatXN == KT.IDKyThuatXN).ToList();
                                if (lstThongso.Count > 0)
                                {
                                    foreach (var tso in lstThongso)
                                    {
                                        var thongso = db.PSDanhMucThongSoXNs.FirstOrDefault(p => p.IDThongSoXN == tso.IDThongSo);
                                        if (thongso != null)
                                        {
                                            PSXN_KetQua_ChiTiet KQct = new PSXN_KetQua_ChiTiet();
                                            KQct.DonViTinh = thongso.DonViTinh;
                                            KQct.GiaTriMaxNam = thongso.GiaTriMaxNam;
                                            KQct.GiaTriMaxNu = thongso.GiaTriMaxNu;
                                            KQct.GiaTriMinNam = thongso.GiaTriMinNam;
                                            KQct.GiaTriMinNu = thongso.GiaTriMinNu;
                                            KQct.GiaTriTrungBinhNam = thongso.GiaTriTrungBinhNam;
                                            KQct.GiaTriTrungBinhNu = thongso.GiaTriTrungBinhNu;
                                            KQct.isNguyCo = false;
                                            KQct.isXoa = false;
                                            KQct.isDongBo = false;
                                            KQct.MaDichVu = DV.MaDichVu;
                                            KQct.MaDonViTinh = thongso.MaDonViTinh;
                                            KQct.MaKQ = rowXN.MaKetQua;
                                            KQct.MaKyThuat = KT.IDKyThuatXN;
                                            KQct.MaThongSoXN = thongso.IDThongSoXN;
                                            KQct.MaXetNghiem = rowXN.MaXetNghiem;
                                            KQct.TenKyThuat = db.PSDanhMucKyThuatXNs.FirstOrDefault(p => p.IDKyThuatXN == KT.IDKyThuatXN).TenKyThuat ?? "";
                                            KQct.TenThongSo = thongso.TenThongSo;
                                            db.PSXN_KetQua_ChiTiets.InsertOnSubmit(KQct);
                                            db.SubmitChanges();
                                            isOK = true;

                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (isOK)
                    {
                        var cDinh = db.PSChiDinhDichVus.FirstOrDefault(p => p.isXoa == false && p.MaChiDinh == rowXN.MaChiDinh);
                        if (cDinh != null)
                        {
                            cDinh.TrangThai = 2;
                            cDinh.isDongBo = false;
                            cDinh.isXoa = false;

                            db.SubmitChanges();
                        }
                        var Phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == rowXN.MaPhieu);
                        if (Phieu != null)
                        {
                            Phieu.TrangThaiPhieu = true;
                            Phieu.isDongBo = false;

                            Phieu.TrangThaiMau = 3;
                            if (string.IsNullOrEmpty(Phieu.MaXetNghiem))
                                Phieu.MaXetNghiem = rowXN.MaXetNghiem;
                            db.SubmitChanges();
                            //  UpdateMaKhachHang(Phieu.MaBenhNhan,Phieu.IDCoSo,SoBanDau());
                            //var patient = db.PSPatients.FirstOrDefault(p => p.MaBenhNhan == Phieu.MaBenhNhan);
                            //if( patient!=null)
                            //{
                            //    if(string.IsNullOrEmpty(patient.MaKhachHang))
                            //    {
                            //        patient.MaKhachHang = GetNewMaKhachHang(Phieu.IDCoSo, SoBanDau());
                            //        db.SubmitChanges();
                            //    }
                            //}

                        }

                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
                response.Result = true;

            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                response.Result = false;
                response.StringError = ex.ToString();
            }
            return response;
        }
        public PsReponse UpdateKetQuaXN(PSXN_KetQua KQ)
        {
            PsReponse res = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var rsKQ = db.PSXN_KetQuas.FirstOrDefault(p => p.isXoa == false && p.MaKetQua == KQ.MaKetQua);
                if (rsKQ == null)
                {
                    db.Connection.Close();
                    res.Result = false;
                    res.StringError = "Không tồn tại dữ liệu kết quả này";
                    return res;
                }
                else
                {
                    var lstkq = db.PSXN_KetQuas.Where(p => p.isXoa == false && p.MaPhieu == KQ.MaPhieu && p.MaDonVi == KQ.MaDonVi).ToList();
                    if (!KQ.MaChiDinh.Substring(0, 2).Equals("XN"))
                    {
                        if (lstkq.Count > 1)
                        {
                            db.Connection.Close();
                            res.Result = false;
                            res.StringError = "Phiếu này đã làm và có kết quả xét nghiệm lần 2 nên không thể sửa";
                            return res;
                        }
                    }

                    rsKQ.NgayTraKQ = DateTime.Now;
                    rsKQ.isCoKQ = KQ.isCoKQ;
                    rsKQ.UserTraKQ = KQ.UserTraKQ;
                    db.SubmitChanges();
                    var resChiDinh = db.PSChiDinhDichVus.Where(p => p.isXoa == false && p.MaChiDinh == KQ.MaChiDinh).ToList();
                    if (resChiDinh.Count > 0)
                    {
                        foreach (var cd in resChiDinh)
                        {
                            cd.TrangThai = 3;
                            db.SubmitChanges();
                        }
                    }
                    var resPhieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDCoSo == KQ.MaDonVi && p.IDPhieu == KQ.MaPhieu);
                    if (resPhieu != null) try { resPhieu.TrangThaiMau = 3; db.SubmitChanges(); } catch { }
                }

                db.Transaction.Commit();
                db.Connection.Close();
                res.Result = true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                res.Result = false;
                res.StringError = "Lỗi khi cập nhật dữ liệu : \r\n " + ex.ToString();
            }
            return res;
        }
        public PsReponse LuuKetQuaXN(KetQua_XetNghiem KQ)
        {
            PsReponse res = new PsReponse();
            res.Result = true;
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var trp = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == KQ.maPhieu);
                if (trp != null)
                {
                    if ((trp.TrangThaiMau ?? 0) < 0 || (trp.TrangThaiMau ?? 0) > 3)
                    {
                        db.Transaction.Rollback();
                        db.Connection.Close();
                        res.Result = false;
                        res.StringError = "Phiếu đã được duyệt nên không thể lưu kết quả !";
                        return res;
                    }
                }

                bool isCoKQ = true;
                bool isNC = false;
                foreach (var item in KQ.KetQuaChiTiet)
                {
                    if (item.isNguyCoCao)
                        isNC = true;
                    if (string.IsNullOrEmpty(item.GiaTri.Trim()))
                    {
                        isCoKQ = false;
                    }
                    var Ct = db.PSXN_KetQua_ChiTiets.FirstOrDefault(p => p.isXoa == false && p.MaKQ == KQ.maKetQua && p.MaThongSoXN == item.MaThongSo);
                    if (Ct != null)
                    {
                        Ct.DonViTinh = item.DonViTinh;
                        Ct.GiaTri = item.GiaTri;
                        Ct.isNguyCo = item.isNguyCoCao;
                        Ct.MaKQ = item.MaKQ;
                        Ct.isDongBo = false;
                        Ct.MaThongSoXN = item.MaThongSo;
                        db.SubmitChanges();
                    }
                }

                var _KQ = db.PSXN_KetQuas.FirstOrDefault(p => p.isXoa == false && p.MaKetQua == KQ.maKetQua);
                if (_KQ != null)
                {
                    var lstkq = db.PSXN_KetQuas.Where(p => p.isXoa == false && p.MaPhieu == _KQ.MaPhieu && p.MaDonVi == _KQ.MaDonVi).ToList();
                    if (!_KQ.MaChiDinh.Substring(0, 2).Equals("XN"))
                    {
                        if (lstkq.Count > 1)
                        {
                            db.Transaction.Rollback();
                            db.Connection.Close();
                            res.Result = false;
                            res.StringError = "Phiếu này đã làm và có kết quả xét nghiệm lần 2 nên không thể sửa";
                            return res;
                        }
                    }
                    _KQ.MaChiDinh = KQ.maChiDinh;
                    _KQ.MaDonVi = KQ.maDonVi;
                    _KQ.MaKetQua = KQ.maKetQua;
                    _KQ.MaPhieu = KQ.maPhieu;
                    _KQ.MaTiepNhan = KQ.maTiepNhan;
                    _KQ.MaXetNghiem = KQ.maXetNghiem;
                    _KQ.NgayTraKQ = DateTime.Now;
                    _KQ.isCoKQ = isCoKQ;
                    _KQ.isXoa = false;
                    _KQ.isDongBo = false;
                    _KQ.UserTraKQ = KQ.maNhanVienTraKQ;
                    _KQ.GhiChu = KQ.GhiChu;
                    db.SubmitChanges();
                }
                if (isCoKQ)
                {
                    var TraKQua = db.PSXN_TraKetQuas.FirstOrDefault(p => p.isXoa == false && p.MaTiepNhan == KQ.maTiepNhan && p.MaPhieu == KQ.maPhieu);
                    if (TraKQua != null)
                    {
                        TraKQua.NgayCoKQ = DateTime.Now;
                        TraKQua.isTraKQ = false;
                        TraKQua.isXoa = false;
                        TraKQua.isDongBo = false;
                        TraKQua.isDaDuyetKQ = false;
                        TraKQua.isNguyCoCao = isNC;
                        TraKQua.MaXetNghiem = KQ.maXetNghiem;
                        TraKQua.GhiChu = string.Empty;
                        TraKQua.KetLuanTongQuat = string.Empty;
                        if (string.IsNullOrEmpty(TraKQua.MaGoiXN))
                            TraKQua.MaGoiXN = KQ.maGoiXetNghiem;
                        TraKQua.GhiChuPhongXetNghiem = _KQ.GhiChu;

                        db.SubmitChanges();
                        if (KQ.maChiDinh.Substring(0, 2).Equals("XN"))
                        {
                            foreach (var item in KQ.KetQuaChiTiet)
                            {
                                var CTThongso = db.PSXN_TraKQ_ChiTiets.FirstOrDefault(p => p.isXoa == false && p.MaTiepNhan == KQ.maTiepNhan && p.MaPhieu == KQ.maPhieu && p.IDThongSoXN == item.MaThongSo);
                                if (CTThongso != null)
                                {
                                    try
                                    {
                                        float gt = (float.Parse(CTThongso.GiaTri1) + float.Parse(item.GiaTri)) / 2;

                                        if (gt > CTThongso.GiaTriMin && gt < CTThongso.GiaTriMax)
                                        {
                                            CTThongso.isNguyCo = false;
                                            CTThongso.KetLuan = "Nguy cơ thấp";
                                            CTThongso.GiaTriCuoi = String.Format("{0:0.00}", gt);

                                        }
                                        else
                                        {
                                            // CTThongso.isNguyCo = true;
                                            isNC = true;
                                            CTThongso.GiaTriCuoi = string.Empty;
                                            CTThongso.KetLuan = string.Empty;
                                        }

                                    }
                                    catch { }

                                    // CTThongso.GiaTriCuoi = string.Empty;
                                    CTThongso.GiaTri2 = item.GiaTri;
                                    CTThongso.isMauXNLai = true;
                                    CTThongso.isXoa = false;
                                    CTThongso.isDongBo = false;
                                    db.SubmitChanges();
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in KQ.KetQuaChiTiet)
                            {

                                var CTThongso = db.PSXN_TraKQ_ChiTiets.FirstOrDefault(p => p.MaTiepNhan == KQ.maTiepNhan && p.MaPhieu == KQ.maPhieu && p.IDThongSoXN == item.MaThongSo);
                                try
                                {
                                    float gt = float.Parse(item.GiaTri);
                                    if (gt < CTThongso.GiaTriMin && gt > CTThongso.GiaTriMax)
                                    {
                                        CTThongso.isNguyCo = true;
                                        CTThongso.KetLuan = string.Empty;
                                        isNC = true;
                                    }
                                    else
                                    {
                                        CTThongso.isNguyCo = false;
                                        CTThongso.KetLuan = "Nguy cơ thấp";
                                        CTThongso.GiaTriCuoi = String.Format("{0:0.##}", gt);
                                    }

                                }
                                catch { }
                                if (CTThongso != null)
                                {
                                    if (!isNC)
                                        CTThongso.GiaTriCuoi = item.GiaTri;
                                    else
                                        CTThongso.GiaTriCuoi = string.Empty;

                                    CTThongso.isMauXNLai = false;
                                    CTThongso.isXoa = false;
                                    CTThongso.isDongBo = false;
                                    CTThongso.GiaTri1 = item.GiaTri;
                                    db.SubmitChanges();
                                }
                            }
                        }
                        //if (!isNC)
                        //{
                        //    //TraKQua.KetLuanTongQuat = "Tất cả các chỉ số đều nằm trong giới hạn bình thường";
                        //    db.SubmitChanges();
                        //}
                    }
                    else
                    {
                        PSXN_TraKetQua TraKQ = new PSXN_TraKetQua();

                        TraKQ.IDCoSo = KQ.maDonVi;
                        TraKQ.MaPhieu = KQ.maPhieu;
                        TraKQ.MaTiepNhan = KQ.maTiepNhan;
                        TraKQ.NgayCoKQ = DateTime.Now;
                        TraKQ.isDaDuyetKQ = false;
                        TraKQ.isTraKQ = false;
                        TraKQ.isDongBo = false;
                        TraKQ.isXoa = false;
                        TraKQ.isNguyCoCao = isNC;
                        //if (!isNC)
                            //TraKQ.KetLuanTongQuat = "Tất cả các chỉ số đều nằm trong giới hạn bình thường";
                        TraKQ.MaXetNghiem = KQ.maXetNghiem;
                        TraKQ.NgayChiDinh = KQ.ngayChiDinh;
                        TraKQ.NgayLamXetNghiem = KQ.ngayXetNghiem;
                        TraKQ.NgayTiepNhan = KQ.ngayTiepNhan;
                        TraKQ.UserTraKQ = KQ.maNhanVienTraKQ;
                        TraKQ.GhiChuPhongXetNghiem = KQ.GhiChu;
                        TraKQ.MaGoiXN = KQ.maGoiXetNghiem;
                        db.PSXN_TraKetQuas.InsertOnSubmit(TraKQ);
                        db.SubmitChanges();
                        bool ismauThuLai = false;
                        var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == KQ.maPhieu && p.IDCoSo == KQ.maDonVi);
                        if (phieu != null)
                            ismauThuLai = phieu.isXNLan2 ?? false;
                        foreach (var item in KQ.KetQuaChiTiet)
                        {

                            PSXN_TraKQ_ChiTiet CtTraKQ = new PSXN_TraKQ_ChiTiet();
                            CtTraKQ.GiaTri1 = item.GiaTri;
                            CtTraKQ.GiaTriMax = item.GiaTriMax;
                            CtTraKQ.GiaTriMin = item.GiaTriMin;
                            CtTraKQ.GiaTriTrungBinh = item.GiaTriTrungBinh;
                            CtTraKQ.IDDonViTinh = item.MaDonViTinh;
                            CtTraKQ.DonViTinh = item.DonViTinh;
                            CtTraKQ.IDKyThuat = item.MaKyThuat;
                            CtTraKQ.IDThongSoXN = item.MaThongSo;
                            CtTraKQ.isNguyCo = item.isNguyCoCao;
                            CtTraKQ.MaDichVu = item.MaDichVu;
                            CtTraKQ.MaPhieu = KQ.maPhieu;
                            CtTraKQ.isXoa = false;
                            CtTraKQ.isDongBo = false;
                            CtTraKQ.MaTiepNhan = KQ.maTiepNhan;
                            CtTraKQ.TenKyThuat = item.TenKyThuat;
                            CtTraKQ.TenThongSo = item.TenThongSo;
                            CtTraKQ.isMauXNLai = ismauThuLai;
                            try
                            {
                                float gt = float.Parse(item.GiaTri);
                                if (gt > item.GiaTriMin && gt < item.GiaTriMax)
                                {
                                    CtTraKQ.isNguyCo = false;
                                    CtTraKQ.KetLuan = "Nguy cơ thấp";
                                    CtTraKQ.GiaTriCuoi = String.Format("{0:0.##}", gt);
                                }
                                else
                                {
                                    isNC = true;
                                }
                            }
                            catch { }
                            db.PSXN_TraKQ_ChiTiets.InsertOnSubmit(CtTraKQ);
                            db.SubmitChanges();
                        }
                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                res.Result = false;
                res.StringError = ex.ToString();
            }
            return res;
        }
        public bool UpdateKetQuaChiTietXN(PSXN_KetQua_ChiTiet KQ)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var rsKQ = db.PSXN_KetQua_ChiTiets.FirstOrDefault(p => p.isXoa == false && p.MaKQ == KQ.MaKQ & p.MaThongSoXN == KQ.MaThongSoXN);
                if (rsKQ != null)
                {
                    rsKQ.isDongBo = false;
                    rsKQ.GiaTri = KQ.GiaTri;
                    db.SubmitChanges();
                }
                else
                {
                    db.Connection.Close();
                    return false;
                }


                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        public bool InsertLyDoKhongDat(List<PSChiTietDanhGiaChatLuong> lstLyDo, string maTiepNhan)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                foreach (var lydo in lstLyDo)
                {
                    db.PSChiTietDanhGiaChatLuongs.InsertOnSubmit(lydo);
                    db.SubmitChanges();
                }
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        public PsReponse UpdateTraKetQua(TraKetQua_XetNghiem KQ, bool isDuyet)
        {
            PsReponse res = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                bool isNguyCoCao = false;
                var result = db.PSXN_TraKetQuas.FirstOrDefault(p => p.isXoa == false && p.MaPhieu == KQ.maPhieu && p.MaTiepNhan == KQ.maTiepNhan && p.isXoa == false);
                if (result != null)
                {
                    if (result.isDaDuyetKQ ?? false)
                    {
                        res.Result = false;
                        res.StringError = "Kết quả đã duyệt nên không được sửa";
                        db.Transaction.Rollback();
                        db.Connection.Close();
                        return res;
                    }
                    else
                    {
                        result.isDongBo = false;
                        result.GhiChu = KQ.ghiChu;
                        result.isTraKQ = KQ.isTraKQ;
                        if (isDuyet)
                            result.isDaDuyetKQ = true;
                        result.KetLuanTongQuat = KQ.ketLuan;
                        result.NgayTraKQ = KQ.ngayDuyetKQ;
                        result.MaPhieuCu = KQ.MaPhieuLan1;
                        result.UserTraKQ = KQ.userTraKQ;
                        result.isDongBoPDF = false;
                        db.SubmitChanges();
                        //  result.nhan

                        if (KQ.chiTietKQ.Count > 0)
                        {
                            foreach (var KQCT in KQ.chiTietKQ)
                            {
                                var ct = db.PSXN_TraKQ_ChiTiets.FirstOrDefault(p => p.isXoa == false && p.MaTiepNhan == KQCT.MaTiepNhan && p.MaPhieu == KQCT.MaPhieu && p.IDThongSoXN == KQCT.IDThongSoXN && p.isXoa == false);
                                if (ct != null)
                                {
                                    ct.GiaTriCuoi = KQCT.GiaTriCuoi;
                                    ct.isNguyCo = KQCT.isNguyCo;
                                    ct.KetLuan = KQCT.KetLuan;
                                    if (isDuyet)
                                        ct.isDaDuyetKQ = true;
                                    ct.isDongBo = false;
                                    db.SubmitChanges();
                                    if (KQCT.isNguyCo && (KQCT.isMauXNLai ?? false)) isNguyCoCao = true;
                                }
                                else
                                {
                                    res.Result = false;
                                    res.StringError = "Một thông số xét nghiệm không tồn tại trong phiếu trả kết quả này ";
                                    db.Transaction.Rollback();
                                    db.Connection.Close();

                                    //  if(!this.UpdateTraKetQuaChiTiet(KQ.chiTietKQ))
                                    //   throw new System.ArgumentException("Error insert UpdateTraKetQuaChiTiet method", "Insert");
                                }
                            }
                        }
                        else
                        {
                            res.Result = false;
                            res.StringError = "Dữ liệu lưu ko chứa thông tin các thông số xét nghiệm";
                            db.Transaction.Rollback();
                            db.Connection.Close();
                            return res;
                        }

                    }
                }
                else
                {
                    res.Result = false;
                    res.StringError = "Không tồn tại thông tin kết quả của phiếu này trong hệ thống";
                    db.Transaction.Rollback();
                    db.Connection.Close();
                    return res;
                }
                if (isDuyet)
                {
                    var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == KQ.maPhieu && p.IDCoSo == KQ.maDonVi && p.isXoa == false);
                    if (phieu != null)
                    {
                        phieu.TrangThaiMau = 4;
                        phieu.isDongBo = false;
                        db.SubmitChanges();
                    }
                    if (isNguyCoCao)
                    {
                        try
                        {

                            var Bn = db.PSPatients.FirstOrDefault(p => p.isXoa == false && p.MaBenhNhan == phieu.MaBenhNhan);
                            if (Bn != null)
                            {
                                var _res = db.PSBenhNhanNguyCoCaos.FirstOrDefault(p => p.isXoa == false && p.MaBenhNhan == phieu.MaBenhNhan && p.MaDonVi == KQ.maDonVi && p.isXoa == false);
                                if (_res == null)
                                {
                                    PSBenhNhanNguyCoCao BNNguyCo = new PSBenhNhanNguyCoCao();
                                    BNNguyCo.isNguyCoCao = true;
                                    BNNguyCo.MaBenhNhan = phieu.MaBenhNhan;
                                    BNNguyCo.MaKhachHang = Bn.MaKhachHang;
                                    BNNguyCo.MaTiepNhan = KQ.maTiepNhan;
                                    BNNguyCo.MaDonVi = KQ.maDonVi;
                                    BNNguyCo.NgayTiepNhan = result.NgayTiepNhan;
                                    BNNguyCo.TenBenhNhan = Bn.TenBenhNhan;
                                    BNNguyCo.isDaChanDoan = false;
                                    BNNguyCo.isDieuTri = false;
                                    BNNguyCo.isXoa = false;
                                    BNNguyCo.isDongBo = false;
                                    db.PSBenhNhanNguyCoCaos.InsertOnSubmit(BNNguyCo);
                                    db.SubmitChanges();
                                }
                                else
                                {
                                    _res.isNguyCoCao = true;
                                    _res.isXoa = false;
                                    _res.isDongBo = false;
                                    _res.TenBenhNhan = Bn.TenBenhNhan;
                                    if (_res.MaTiepNhan.Equals(KQ.maTiepNhan))
                                        _res.MaTiepNhan = KQ.maTiepNhan;
                                    else _res.MaTiepNhan2 = KQ.maTiepNhan;
                                    db.SubmitChanges();
                                }
                            }


                        }
                        catch (Exception ex)
                        { }
                    }
                    else if (!string.IsNullOrEmpty(KQ.MaPhieuLan1))
                    {
                        var phieucu = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieu == KQ.MaPhieuLan1 && p.IDCoSo == KQ.maDonVi && p.isXoa == false);

                        var _res = db.PSBenhNhanNguyCoCaos.FirstOrDefault(p => p.MaBenhNhan == phieu.MaBenhNhan && p.MaDonVi == KQ.maDonVi && p.isXoa == false);
                        if (_res != null)
                        {
                            _res.isNguyCoCao = false;
                            _res.isXoa = false;
                            _res.isDongBo = false;
                            if (_res.MaTiepNhan.Equals(KQ.maTiepNhan))
                                _res.MaTiepNhan = KQ.maTiepNhan;
                            else _res.MaTiepNhan2 = KQ.maTiepNhan;
                            db.SubmitChanges();
                        }
                        if (phieucu != null)
                        {

                        }
                    }
                }

                db.Transaction.Commit();
                db.Connection.Close();
                res.Result = true;
                return res; ;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                res.Result = false;
                if (string.IsNullOrEmpty(res.StringError))
                    res.StringError = ex.ToString();
                return res;
            }
        }
        public bool InsertTraKetQua(PSXN_TraKetQua KQ)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                db.PSXN_TraKetQuas.InsertOnSubmit(KQ);
                db.SubmitChanges();
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdateTraKetQuaChiTiet(List<PSXN_TraKQ_ChiTiet> lstKQCT)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                if (lstKQCT.Count > 0)
                {
                    foreach (var KQCT in lstKQCT)
                    {
                        var result = db.PSXN_TraKQ_ChiTiets.FirstOrDefault(p => p.isXoa == false && p.MaTiepNhan == KQCT.MaTiepNhan && p.MaPhieu == KQCT.MaPhieu && p.IDThongSoXN == KQCT.IDThongSoXN && p.isXoa == false);
                        if (result != null)
                        {
                            // result.DonViTinh = KQCT.DonViTinh;
                            // result.GiaTri1 = KQCT.GiaTri1;
                            //  result.GiaTri2 = KQCT.GiaTri2;
                            result.GiaTriCuoi = KQCT.GiaTriCuoi;
                            //  result.GiaTriMax = KQCT.GiaTriMax;
                            //  result.GiaTriMin = KQCT.GiaTriMin;
                            //  result.GiaTriTrungBinh = KQCT.GiaTriTrungBinh;
                            //  result.IDDonViTinh = KQCT.IDDonViTinh;
                            //  result.IDKyThuat = KQCT.IDKyThuat;
                            // result.IDThongSoXN = KQCT.IDThongSoXN;
                            result.isNguyCo = KQCT.isNguyCo;
                            result.KetLuan = KQCT.KetLuan;
                            //  result.MaDichVu = KQCT.MaDichVu;
                            //   result.TenKyThuat = KQCT.TenKyThuat;
                            // result.isMauThuLai = KQCT.isMauThuLai;
                            result.isDaDuyetKQ = true;
                            result.isXoa = false;
                            result.isDongBo = false;
                            // result.TenThongSo = KQCT.TenThongSo;
                            db.SubmitChanges();
                        }
                        else
                        {
                            db.Transaction.Rollback();
                            db.Connection.Close();
                            return false;
                        }
                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool InsertTraKetQuaChiTiet(PSXN_TraKQ_ChiTiet CTKQ)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                db.PSXN_TraKQ_ChiTiets.InsertOnSubmit(CTKQ);
                db.SubmitChanges();
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }


        public bool UpdateTiepNhan(string maPhieu)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var results = db.PSTiepNhans.Where(p => p.isXoa == false && p.MaPhieu == maPhieu).ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        result.isDaDanhGia = false;
                        result.isDaNhapLieu = true;
                        result.isDongBo = false;
                        db.SubmitChanges();
                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        public PsReponse InsertTiepNhan(PSTiepNhan tiepNhan)
        {
            PsReponse response = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                if (tiepNhan != null)
                {
                    tiepNhan.MaTiepNhan = GetID();
                    var tn = db.PSTiepNhans.FirstOrDefault(p => p.isXoa == false && p.MaDonVi == tiepNhan.MaDonVi && p.MaPhieu == tiepNhan.MaPhieu);
                    if (tn != null)
                    {
                        var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDCoSo == tiepNhan.MaDonVi && p.IDPhieu == tiepNhan.MaPhieu && p.TrangThaiMau==0);
                        if (phieu != null)
                        {
                            tn.isDongBo = false;
                            if (!tn.isDaDanhGia ?? false)
                                tn.isDaDanhGia = false;
                            // tn.isDaNhapLieu = true;
                            if ((phieu.TrangThaiMau ?? 0) < 2)
                                phieu.TrangThaiMau = 1;
                            phieu.NgayNhanMau = DateTime.Now;
                            phieu.TrangThaiPhieu = true;
                            phieu.isDongBo = false;
                            db.SubmitChanges();
                        }
                        else
                        {
                            tiepNhan.isDaNhapLieu = false;
                            tiepNhan.isXoa = false;
                            tiepNhan.isDongBo = false;
                            tiepNhan.isDaDanhGia = false;
                            db.PSTiepNhans.InsertOnSubmit(tiepNhan);
                            db.SubmitChanges();
                        }
                    }
                    else
                    {
                        bool nhaplieu = false;
                        var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDCoSo == tiepNhan.MaDonVi && p.IDPhieu == tiepNhan.MaPhieu);
                        if (phieu != null)
                        {
                            nhaplieu = true;
                            if ((phieu.TrangThaiMau ?? 0) < 2)
                                phieu.TrangThaiMau = 1;
                            phieu.NgayNhanMau = DateTime.Now;
                            phieu.TrangThaiPhieu = true;
                            phieu.isDongBo = false;
                            db.SubmitChanges();
                        }
                        
                        tiepNhan.isDaNhapLieu = nhaplieu;
                        tiepNhan.isXoa = false;
                        tiepNhan.isDongBo = false;
                        tiepNhan.isDaDanhGia = false;
                        db.PSTiepNhans.InsertOnSubmit(tiepNhan);
                        db.SubmitChanges();

                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
                response.Result = true;
                return response;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                response.Result = false;
                response.StringError = ex.ToString();
                return response;
            }
        }
        private string GetID()
        {
            var maTT = db.PSThongTinTrungTams.FirstOrDefault().MaVietTat;
            if (!string.IsNullOrEmpty(maTT))
            {
                return maTT + Guid.NewGuid().ToString();
            }
            else { return "00" + Guid.NewGuid().ToString(); }
        }
        //public  bool InsertDanhSachTiepNhan(List<PSTiepNhan> listTiepNhan)
        //{
        //    db.Connection.Open();
        //    db.Transaction = db.Connection.BeginTransaction();
        //    try
        //    {
        //       if(listTiepNhan!=null)
        //        {
        //            if(listTiepNhan.Count>0)
        //            {
        //                long rowID = 0;
        //                var dottiepnhan = db.PSTiepNhans.ToList().OrderByDescending(p => p.RowIDTiepNhan).ToList();
        //                if(dottiepnhan.Count()>0)
        //                {
        //                     rowID = dottiepnhan[0].RowIDTiepNhan;
        //                }
        //                foreach(var dot in listTiepNhan)
        //                {
        //                    if (dot.RowIDTiepNhan > 0)
        //                    {
        //                            var _tiepNhan = db.PSTiepNhans.FirstOrDefault(p => p.RowIDTiepNhan == dot.RowIDTiepNhan);
        //                            if (_tiepNhan != null)
        //                            {
        //                                _tiepNhan.MaPhieu = dot.MaPhieu;
        //                                _tiepNhan.MaNVTiepNhan = dot.MaNVTiepNhan;
        //                                _tiepNhan.NgayTiepNhan = dot.NgayTiepNhan;
        //                                _tiepNhan.RowIDTiepNhan = rowID;
        //                                _tiepNhan.MaDonVi = dot.MaDonVi;
        //                              //  _tiepNhan.RowIDPhieu = dot.RowIDPhieu;
        //                                _tiepNhan.isDaDanhGia = false;
        //                                db.SubmitChanges();

        //                        }

        //                        }
        //                    else
        //                    {
        //                            PSTiepNhan tiepNhan = new PSTiepNhan();
        //                            rowID += 1;
        //                          //  tiepNhan.RowIDPhieu = dot.RowIDPhieu;
        //                            tiepNhan.MaPhieu = dot.MaPhieu;
        //                            tiepNhan.MaNVTiepNhan = dot.MaNVTiepNhan;
        //                            tiepNhan.NgayTiepNhan = dot.NgayTiepNhan;
        //                            tiepNhan.RowIDTiepNhan = rowID;
        //                            tiepNhan.MaDonVi = dot.MaDonVi;
        //                         //   tiepNhan.RowIDPhieu = dot.RowIDPhieu;
        //                            tiepNhan.isDaDanhGia = false;
        //                            db.PSTiepNhans.InsertOnSubmit(tiepNhan);
        //                            db.SubmitChanges();
        //                    }
        //                    //if (dot.RowIDPhieu > 0) //Cập nhật tình trạng phiếu sau khi đã tiếp nhận
        //                    //{
        //                    //       var phieu = db.PSPhieuSangLocs.FirstOrDefault(p => p.RowIDPhieu == dot.RowIDPhieu);
        //                    //        if (phieu != null)
        //                    //        {
        //                    //            phieu.TrangThaiPhieu = true;
        //                    //            phieu.TrangThaiMau = 1;
        //                    //            db.SubmitChanges();
        //                    //        }
        //                    //    }
        //                }
        //            }
        //            }

        //        db.Transaction.Commit();
        //        db.Connection.Close();
        //        return true;
        //    }
        //    catch {
        //        db.Transaction.Rollback();
        //        db.Connection.Close();
        //        return false; }
        //}
        private void TaoMaKhachHang()
        {

        }

        public PsReponse InsertPhieu(PSPhieuSangLoc phieu)
        {
            PsReponse result = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {

                var ph = db.PSPhieuSangLocs.FirstOrDefault(p => p.isXoa == false && p.IDPhieu == phieu.IDPhieu);
                if (ph != null)
                {
                    ph.CheDoDinhDuong = phieu.CheDoDinhDuong;
                    ph.IDChuongTrinh = phieu.IDChuongTrinh;
                    ph.IDCoSo = phieu.IDCoSo;
                    ph.IDNhanVienLayMau = phieu.IDNhanVienLayMau;
                    //   ph.IDNhanVienTaoPhieu = phieu.IDNhanVienTaoPhieu;
                    ph.IDPhieu = phieu.IDPhieu;
                    ph.IDPhieuLan1 = phieu.IDPhieuLan1;
                    ph.IDViTriLayMau = phieu.IDViTriLayMau;
                    ph.isGuiMauTre = phieu.isGuiMauTre;
                    ph.isHuyMau = phieu.isHuyMau;
                    ph.isKhongDat = phieu.isKhongDat;
                    ph.isDongBo = false;

                    if (string.IsNullOrEmpty(phieu.IDPhieuLan1))
                        ph.isLayMauLan2 = false;
                    else ph.isLayMauLan2 = true;
                    ph.isLayMauLan2 = ph.isLayMauLan2 ?? false;
                    ph.isNheCan = phieu.isNheCan;
                    ph.isSinhNon = phieu.isSinhNon;
                    ph.isTruoc24h = phieu.isTruoc24h;
                    ph.MaBenhNhan = phieu.MaBenhNhan;
                    ph.MaGoiXN = phieu.MaGoiXN;
                    ph.MaXetNghiem = phieu.MaXetNghiem;
                    ph.NgayGioLayMau = phieu.NgayGioLayMau;
                    ph.NgayNhanMau = phieu.NgayNhanMau;
                    ph.NgayTruyenMau = phieu.NgayTruyenMau;
                    ph.NoiLayMau = phieu.NoiLayMau;
                    ph.DiaChiLayMau = phieu.DiaChiLayMau;
                    ph.Para = phieu.Para;
                    ph.SDTNhanVienLayMau = phieu.SDTNhanVienLayMau;
                    ph.SLTruyenMau = phieu.SLTruyenMau;
                    ph.TenNhanVienLayMau = phieu.TenNhanVienLayMau;
                    ph.TinhTrangLucLayMau = phieu.TinhTrangLucLayMau;

                    ph.TrangThaiPhieu = true;
                    ph.LyDoKhongDat = phieu.LyDoKhongDat;

                    db.SubmitChanges();
                }
                else
                {
                    PSPhieuSangLoc p = new PSPhieuSangLoc();
                    p.CheDoDinhDuong = phieu.CheDoDinhDuong;
                    p.IDChuongTrinh = phieu.IDChuongTrinh;
                    p.IDCoSo = phieu.IDCoSo;
                    p.IDNhanVienLayMau = phieu.IDNhanVienLayMau;
                    //    p.IDNhanVienTaoPhieu = phieu.IDNhanVienTaoPhieu;
                    p.IDPhieu = phieu.IDPhieu;
                    p.IDPhieuLan1 = phieu.IDPhieuLan1;
                    p.IDViTriLayMau = phieu.IDViTriLayMau;
                    p.isGuiMauTre = phieu.isGuiMauTre;
                    p.isHuyMau = phieu.isHuyMau;
                    p.isKhongDat = phieu.isKhongDat;
                    if (string.IsNullOrEmpty(phieu.IDPhieuLan1))
                        ph.isLayMauLan2 = false;
                    else ph.isLayMauLan2 = true;
                    p.isNheCan = phieu.isNheCan;
                    p.isSinhNon = phieu.isSinhNon;
                    p.isTruoc24h = phieu.isTruoc24h;
                    p.MaBenhNhan = phieu.MaBenhNhan;
                    p.MaGoiXN = phieu.MaGoiXN;
                    p.MaXetNghiem = phieu.MaXetNghiem;
                    p.NgayGioLayMau = phieu.NgayGioLayMau;
                    p.NgayNhanMau = phieu.NgayNhanMau;
                    p.NgayTaoPhieu = DateTime.Now;
                    p.NgayTruyenMau = phieu.NgayTruyenMau;
                    p.NoiLayMau = phieu.NoiLayMau;
                    p.DiaChiLayMau = phieu.DiaChiLayMau;
                    p.Para = phieu.Para;
                    p.SDTNhanVienLayMau = phieu.SDTNhanVienLayMau;
                    p.SLTruyenMau = phieu.SLTruyenMau;
                    p.TenNhanVienLayMau = phieu.TenNhanVienLayMau;
                    p.TinhTrangLucLayMau = phieu.TinhTrangLucLayMau;
                    p.TrangThaiMau = 1;
                    p.TrangThaiPhieu = true;
                    p.isDongBo = false;
                    p.isXoa = false;
                    p.LyDoKhongDat = phieu.LyDoKhongDat;
                    db.PSPhieuSangLocs.InsertOnSubmit(p);
                    db.SubmitChanges();
                }
                //if (!string.IsNullOrEmpty(phieu.MaBenhNhan))
                //{
                //    try {
                //        var bn = db.PSPatients.First(p => p.isXoa == false && p.MaBenhNhan == phieu.MaBenhNhan);
                //        if (bn != null)
                //        {
                //            if (!string.IsNullOrEmpty(bn.MotherName) && !string.IsNullOrEmpty(bn.TenBenhNhan) && string.IsNullOrEmpty(bn.DiaChi) && !string.IsNullOrEmpty(bn.MotherPhoneNumber) && bn.NgayGioSinh != null)
                //            {
                //                var tiepnhan = db.PSTiepNhans.Where(p =>p.isXoa ==false&& p.MaPhieu == phieu.IDPhieu).ToList();
                //                foreach (var dot in tiepnhan)
                //                {
                //                    dot.isDaNhapLieu = true;
                //                    db.SubmitChanges();
                //                }
                //            }
                //        }
                //    } catch { }
                //}
                //}
                //else
                //{
                //    PSPhieuSangLoc p = new PSPhieuSangLoc();
                //    p.CheDoDinhDuong = phieu.CheDoDinhDuong;
                //    p.IDChuongTrinh = phieu.IDChuongTrinh;
                //    p.IDCoSo = phieu.IDCoSo;
                //    p.IDNhanVienLayMau = phieu.IDNhanVienLayMau;
                //    p.IDNhanVienTaoPhieu = phieu.IDNhanVienTaoPhieu;
                //    p.IDPhieu = phieu.IDPhieu;
                //    p.IDPhieuLan1 = phieu.IDPhieuLan1;
                //    p.IDViTriLayMau = phieu.IDViTriLayMau;
                //    p.isGuiMauTre = phieu.isGuiMauTre;
                //    p.isHuyMau = phieu.isHuyMau;
                //    p.isKhongDat = phieu.isKhongDat;
                //    p.isLayMauLan2 = phieu.isLayMauLan2;
                //    p.isNheCan = phieu.isNheCan;
                //    p.isSinhNon = phieu.isSinhNon;
                //    p.isTruoc24h = phieu.isTruoc24h;
                //    //p.MaBenhNhan = phieu.MaBenhNhan;
                //    p.MaGoiXN = phieu.MaGoiXN;
                //    p.MaXetNghiem = phieu.MaXetNghiem;
                //    p.NgayGioLayMau = phieu.NgayGioLayMau;
                //    p.NgayNhanMau = phieu.NgayNhanMau;
                //    p.NgayTaoPhieu = phieu.NgayTaoPhieu;
                //    p.NgayTruyenMau = phieu.NgayTruyenMau;
                //    p.NoiLayMau = phieu.NoiLayMau;
                //    p.Para = phieu.Para;
                //    p.SDTNhanVienLayMau = phieu.SDTNhanVienLayMau;
                //    p.SLTruyenMau = phieu.SLTruyenMau;
                //    p.TenNhanVienLayMau = phieu.TenNhanVienLayMau;
                //    p.TinhTrangLucLayMau = phieu.TinhTrangLucLayMau;
                //    p.TrangThaiMau = phieu.TrangThaiMau;
                //    p.TrangThaiPhieu = phieu.TrangThaiPhieu;
                //    db.PSPhieuSangLocs.InsertOnSubmit(p);
                //    db.SubmitChanges();
                //}
                db.Transaction.Commit();
                db.Connection.Close();
                result.Result = true;
                return result;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                result.StringError = ex.ToString();
                return result;
            }
        }
        //public string InsertNguoi(PsPerson ttNguoi)
        //{
        //    db.Connection.Open();
        //    db.Transaction = db.Connection.BeginTransaction();
        //    try
        //    {
        //        string maThtin = string.Empty;
        //        if(!string.IsNullOrEmpty( ttNguoi.MaThongTin))
        //        {
        //            var per = db.PsPersons.FirstOrDefault(p => p.MaThongTin == ttNguoi.MaThongTin);
        //            if( per!=null)
        //            {
        //                per.GioiTinh = ttNguoi.GioiTinh;
        //                per.CanNangLucSinh = ttNguoi.CanNangLucSinh;
        //                per.DanTocID = ttNguoi.DanTocID;
        //                per.DiaChi = ttNguoi.DiaChi;
        //                per.HoTen = ttNguoi.HoTen;
        //                per.IDCard = ttNguoi.IDCard;
        //                per.NgayGioSinh = ttNguoi.NgayGioSinh;
        //                per.NoiSinh = ttNguoi.NoiSinh;
        //                per.PhuongPhapSinh = ttNguoi.PhuongPhapSinh;
        //                per.QuocTichID = ttNguoi.QuocTichID;
        //                per.SoDienThoai = ttNguoi.SoDienThoai;
        //                per.SoTuanThaiLucSinh = ttNguoi.SoTuanThaiLucSinh;
        //                db.SubmitChanges();
        //                maThtin = ttNguoi.MaThongTin;
        //            }    
        //            else
        //            {
        //                maThtin = GetID();
        //                PsPerson pr = new PsPerson();
        //                pr.GioiTinh = ttNguoi.GioiTinh;
        //                pr.CanNangLucSinh = ttNguoi.CanNangLucSinh;
        //                pr.DanTocID = ttNguoi.DanTocID;
        //                pr.DiaChi = ttNguoi.DiaChi;
        //                pr.HoTen = ttNguoi.HoTen;
        //                pr.IDCard = ttNguoi.IDCard;
        //                pr.NgayGioSinh = ttNguoi.NgayGioSinh;
        //                pr.NoiSinh = ttNguoi.NoiSinh;
        //                pr.PhuongPhapSinh = ttNguoi.PhuongPhapSinh;
        //                pr.QuocTichID = ttNguoi.QuocTichID;
        //                pr.SoDienThoai = ttNguoi.SoDienThoai;
        //                pr.SoTuanThaiLucSinh = ttNguoi.SoTuanThaiLucSinh;
        //                pr.MaThongTin = maThtin;
        //                db.PsPersons.InsertOnSubmit(pr);
        //                db.SubmitChanges();
        //            }
        //        }
        //        else
        //        {
        //            maThtin = GetID();
        //            PsPerson pr = new PsPerson();
        //            pr.GioiTinh = ttNguoi.GioiTinh;
        //            pr.CanNangLucSinh = ttNguoi.CanNangLucSinh;
        //            pr.DanTocID = ttNguoi.DanTocID;
        //            pr.DiaChi = ttNguoi.DiaChi;
        //            pr.HoTen = ttNguoi.HoTen;
        //            pr.IDCard = ttNguoi.IDCard;
        //            pr.NgayGioSinh = ttNguoi.NgayGioSinh;
        //            pr.NoiSinh = ttNguoi.NoiSinh;
        //            pr.PhuongPhapSinh = ttNguoi.PhuongPhapSinh;
        //            pr.QuocTichID = ttNguoi.QuocTichID;
        //            pr.SoDienThoai = ttNguoi.SoDienThoai;
        //            pr.SoTuanThaiLucSinh = ttNguoi.SoTuanThaiLucSinh;
        //            pr.MaThongTin = maThtin;
        //            db.PsPersons.InsertOnSubmit(pr);
        //            db.SubmitChanges();
        //        }

        //        db.Transaction.Commit();
        //        db.Connection.Close();
        //        return maThtin;
        //    }
        //    catch(Exception ex)
        //    {
        //        db.Transaction.Rollback();
        //        db.Connection.Close();
        //        return string.Empty;
        //    }
        //}
        public string InsertBenhNhan(PSPatient thongTinBenhNhan, string maDonvi)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                string mBN = string.Empty;
                if (!string.IsNullOrEmpty(thongTinBenhNhan.MaBenhNhan))
                {
                    var bn = db.PSPatients.FirstOrDefault(p => p.MaBenhNhan == thongTinBenhNhan.MaBenhNhan);
                    if (bn != null)
                    {
                        bn.FatherName = thongTinBenhNhan.FatherName;
                        bn.FatherPhoneNumber = thongTinBenhNhan.FatherPhoneNumber;
                        bn.FatherBirthday = thongTinBenhNhan.FatherBirthday;
                        bn.MotherBirthday = thongTinBenhNhan.MotherBirthday;
                        bn.MotherName = thongTinBenhNhan.MotherName;
                        bn.MotherPhoneNumber = thongTinBenhNhan.MotherPhoneNumber;
                        if (string.IsNullOrEmpty(bn.MaKhachHang))
                            bn.MaKhachHang = GetNewMaKhachHang(maDonvi, SoBanDau());
                        bn.DiaChi = thongTinBenhNhan.DiaChi;
                        bn.TenBenhNhan = thongTinBenhNhan.TenBenhNhan;
                        bn.QuocTichID = thongTinBenhNhan.QuocTichID;
                        bn.TuanTuoiKhiSinh = thongTinBenhNhan.TuanTuoiKhiSinh;
                        bn.PhuongPhapSinh = thongTinBenhNhan.PhuongPhapSinh;
                        bn.NoiSinh = thongTinBenhNhan.NoiSinh;
                        bn.NgayGioSinh = thongTinBenhNhan.NgayGioSinh;
                        bn.GioiTinh = thongTinBenhNhan.GioiTinh;
                        bn.DanTocID = thongTinBenhNhan.DanTocID;
                        bn.CanNang = thongTinBenhNhan.CanNang;
                        bn.isDongBo = false;
                        bn.Para = thongTinBenhNhan.Para;
                        bn.isXoa = false;
                        db.SubmitChanges();
                        mBN = thongTinBenhNhan.MaBenhNhan;
                    }
                    else
                    {
                        mBN = GetID();
                        PSPatient bnh = new PSPatient();
                        bnh.MaBenhNhan = mBN;
                        bnh.FatherName = thongTinBenhNhan.FatherName;
                        bnh.FatherPhoneNumber = thongTinBenhNhan.FatherPhoneNumber;
                        bnh.FatherBirthday = thongTinBenhNhan.FatherBirthday;
                        bnh.MotherBirthday = thongTinBenhNhan.MotherBirthday;
                        bnh.MotherName = thongTinBenhNhan.MotherName;
                        bnh.MotherPhoneNumber = thongTinBenhNhan.MotherPhoneNumber;
                        if (string.IsNullOrEmpty(thongTinBenhNhan.MaKhachHang))
                            bn.MaKhachHang = GetNewMaKhachHang(maDonvi, SoBanDau());
                        else
                            bnh.MaKhachHang = thongTinBenhNhan.MaKhachHang;
                        bnh.DiaChi = thongTinBenhNhan.DiaChi;
                        bnh.TenBenhNhan = thongTinBenhNhan.TenBenhNhan;
                        bnh.QuocTichID = thongTinBenhNhan.QuocTichID;
                        bnh.TuanTuoiKhiSinh = thongTinBenhNhan.TuanTuoiKhiSinh;
                        bnh.PhuongPhapSinh = thongTinBenhNhan.PhuongPhapSinh;
                        bnh.NoiSinh = thongTinBenhNhan.NoiSinh;
                        bnh.NgayGioSinh = thongTinBenhNhan.NgayGioSinh;
                        bnh.GioiTinh = thongTinBenhNhan.GioiTinh;
                        bnh.DanTocID = thongTinBenhNhan.DanTocID;
                        bnh.CanNang = thongTinBenhNhan.CanNang;
                        bnh.isDongBo = false;
                        bnh.Para = thongTinBenhNhan.Para;
                        bnh.isXoa = false;
                        db.PSPatients.InsertOnSubmit(bnh);
                        db.SubmitChanges();
                    }
                }
                else
                {
                    mBN = GetID();
                    PSPatient bnh = new PSPatient();
                    bnh.MaBenhNhan = mBN;
                    bnh.FatherName = thongTinBenhNhan.FatherName;
                    bnh.FatherPhoneNumber = thongTinBenhNhan.FatherPhoneNumber;
                    bnh.FatherBirthday = thongTinBenhNhan.FatherBirthday;
                    bnh.MotherBirthday = thongTinBenhNhan.MotherBirthday;
                    bnh.MotherName = thongTinBenhNhan.MotherName;
                    bnh.MotherPhoneNumber = thongTinBenhNhan.MotherPhoneNumber;
                    if (string.IsNullOrEmpty(thongTinBenhNhan.MaKhachHang))
                        bnh.MaKhachHang = GetNewMaKhachHang(maDonvi, SoBanDau());
                    else
                        bnh.MaKhachHang = thongTinBenhNhan.MaKhachHang;
                    bnh.DiaChi = thongTinBenhNhan.DiaChi;
                    bnh.TenBenhNhan = thongTinBenhNhan.TenBenhNhan;
                    bnh.QuocTichID = thongTinBenhNhan.QuocTichID;
                    bnh.TuanTuoiKhiSinh = thongTinBenhNhan.TuanTuoiKhiSinh;
                    bnh.PhuongPhapSinh = thongTinBenhNhan.PhuongPhapSinh;
                    bnh.NoiSinh = thongTinBenhNhan.NoiSinh;
                    bnh.NgayGioSinh = thongTinBenhNhan.NgayGioSinh;
                    bnh.GioiTinh = thongTinBenhNhan.GioiTinh;
                    bnh.DanTocID = thongTinBenhNhan.DanTocID;
                    bnh.CanNang = thongTinBenhNhan.CanNang;
                    bnh.isDongBo = false;
                    bnh.Para = thongTinBenhNhan.Para;
                    bnh.isXoa = false;
                    db.PSPatients.InsertOnSubmit(bnh);
                    db.SubmitChanges();
                }
                try
                {
                    bool daNhapLieu = true;
                    if (string.IsNullOrEmpty(thongTinBenhNhan.FatherName)) daNhapLieu = false;
                    if (string.IsNullOrEmpty(thongTinBenhNhan.MotherName)) daNhapLieu = false;
                    if (string.IsNullOrEmpty(thongTinBenhNhan.DiaChi)) daNhapLieu = false;
                    if (string.IsNullOrEmpty(thongTinBenhNhan.FatherPhoneNumber)) daNhapLieu = false;
                    if (string.IsNullOrEmpty(thongTinBenhNhan.MotherPhoneNumber)) daNhapLieu = false;
                    if ((thongTinBenhNhan.CanNang ?? 0) < 500) daNhapLieu = false;
                    //if (string.IsNullOrEmpty(thongTinBenhNhan.MotherName)) daNhapLieu = false;
                    //if (string.IsNullOrEmpty(thongTinBenhNhan.MotherName)) daNhapLieu = false;
                    //if (string.IsNullOrEmpty(thongTinBenhNhan.MotherName)) daNhapLieu = false;
                    if (daNhapLieu)
                    {
                        var lst = db.PSPhieuSangLocs.Where(p => p.isXoa == false && p.MaBenhNhan == mBN).ToList();
                        if (lst.Count > 0)
                        {
                            foreach (var phieu in lst)
                            {
                                if ((phieu.NgayGioLayMau ?? new DateTime(1900, 01, 01)).Year > 2000)
                                {
                                    var lsttiepnhan = db.PSTiepNhans.Where(p => p.isXoa == false && p.MaPhieu == phieu.IDPhieu).ToList();
                                    if (lsttiepnhan.Count > 0)
                                    {
                                        foreach (var tiepnhan in lsttiepnhan)
                                        {
                                            var tn = db.PSTiepNhans.FirstOrDefault(p => p.MaTiepNhan == tiepnhan.MaTiepNhan);
                                            tn.isDaNhapLieu = true;
                                            db.SubmitChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                catch { }
                db.Transaction.Commit();
                db.Connection.Close();
                return mBN;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return string.Empty;
            }

        }
        public List<PSKetQuaXetNghiem> GetDanhSachKetQuaDaDuyet(DateTime tuNGay, DateTime denNay)
        {
            List<PSKetQuaXetNghiem> lstKQ = new List<PSKetQuaXetNghiem>();
            try
            {
                var lstkq = db.PSXN_TraKetQuas.Where(p => p.isDaDuyetKQ == true && p.isXoa == false && p.NgayTraKQ.Value.Date > tuNGay.Date && p.NgayTraKQ.Value.Date < denNay).ToList();

                if (lstkq.Count > 0)
                {
                    foreach (var kq in lstkq)
                    {
                        PSKetQuaXetNghiem KQXN = new PSKetQuaXetNghiem();
                        KQXN.GhiChu = kq.GhiChu;
                        KQXN.GhiChuPhongXetNghiem = kq.GhiChuPhongXetNghiem;
                        KQXN.IDCoSo = kq.IDCoSo;
                        KQXN.IDNhanVienXoa = kq.IDNhanVienXoa;
                        KQXN.isDaDuyetKQ = kq.isDaDuyetKQ;
                        KQXN.isDongBo = kq.isDongBo;
                        KQXN.isTraKQ = kq.isTraKQ;
                        KQXN.isXoa = kq.isXoa;
                        KQXN.KetLuanTongQuat = kq.KetLuanTongQuat;
                        KQXN.LyDoXoa = kq.LyDoXoa;
                        KQXN.MaGoiXN = kq.MaGoiXN;
                        KQXN.MaPhieu = kq.MaPhieu;
                        KQXN.MaPhieuCu = kq.MaPhieuCu;
                        KQXN.MaTiepNhan = kq.MaTiepNhan;
                        KQXN.MaXetNghiem = kq.MaXetNghiem;
                        KQXN.NgayChiDinh = kq.NgayChiDinh;
                        KQXN.NgayCoKQ = kq.NgayCoKQ;
                        KQXN.NgayGioXoa = kq.NgayGioXoa;
                        KQXN.NgayLamXetNghiem = kq.NgayLamXetNghiem;
                        KQXN.NgayTiepNhan = kq.NgayTiepNhan;
                        KQXN.NgayTraKQ = kq.NgayTraKQ;


                        var lstct = db.PSXN_TraKQ_ChiTiets.Where(p => p.MaTiepNhan == kq.MaTiepNhan && p.MaPhieu == kq.MaPhieu).ToList();
                        if (lstct.Count > 0)
                            KQXN.KetQuaChiTiet = lstct;
                        else KQXN.KetQuaChiTiet = new List<PSXN_TraKQ_ChiTiet>();
                        lstKQ.Add(KQXN);
                    }
                }
            }
            catch { }
            return lstKQ;
        }
        public PsReponse InsertDotChiDinhMoi(PsChiDinhvsDanhGia dg)
        {
            PsReponse result = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                if (dg != null)
                {
                    if (dg.Phieu != null)
                    {
                    }
                }
                result.Result = true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                result.Result = false;
                result.StringError = ex.ToString();
            }
            return result;
        }
        public string InsertDotChiDinhDichVu(PSChiDinhDichVu dv, bool isLamLaiXN)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                string maCD = string.Empty;

                if (!string.IsNullOrEmpty(dv.MaChiDinh))
                {
                    var dvv = db.PSChiDinhDichVus.FirstOrDefault(p => p.MaChiDinh == dv.MaChiDinh);
                    if (dvv != null)
                    {
                        dvv.IDGoiDichVu = dv.IDGoiDichVu;
                        //  dvv.IDNhanVienChiDinh = dv.IDNhanVienChiDinh;
                        dvv.isLayMauLai = dv.isLayMauLai;
                        dvv.MaChiDinh = dv.MaChiDinh;
                        dvv.MaDonVi = dv.MaDonVi;
                        //dvv.MaNVChiDinh = dv.MaNVChiDinh;
                        dvv.MaPhieu = dv.MaPhieu;
                        // dvv.MaTiepNhan = dv.MaTiepNhan;
                        dvv.MaPhieuLan1 = dv.MaPhieuLan1;
                        dvv.NgayChiDinhHienTai = dv.NgayChiDinhHienTai;
                        dvv.NgayChiDinhLamViec = dv.NgayChiDinhLamViec;
                        dvv.NgayTiepNhan = dv.NgayTiepNhan;
                        dvv.SoLuong = dv.SoLuong;
                        dvv.isXoa = false;
                        dvv.isDongBo = false;
                        dvv.TrangThai = dv.TrangThai;
                        db.SubmitChanges();
                        maCD = dvv.MaChiDinh;
                    }
                    else
                    {
                        PSChiDinhDichVu cd = new PSChiDinhDichVu();
                        cd.IDGoiDichVu = dv.IDGoiDichVu;
                        cd.IDNhanVienChiDinh = dv.IDNhanVienChiDinh;
                        cd.isLayMauLai = dv.isLayMauLai;
                        cd.MaChiDinh = dv.MaChiDinh;
                        cd.MaDonVi = dv.MaDonVi;
                        cd.MaNVChiDinh = dv.MaNVChiDinh;
                        cd.MaTiepNhan = dv.MaTiepNhan;
                        cd.MaPhieu = dv.MaPhieu;
                        cd.MaPhieuLan1 = dv.MaPhieuLan1;
                        cd.NgayChiDinhHienTai = dv.NgayChiDinhHienTai;
                        cd.NgayChiDinhLamViec = dv.NgayChiDinhLamViec;
                        cd.SoLuong = dv.SoLuong;
                        cd.NgayTiepNhan = dv.NgayTiepNhan;
                        cd.TrangThai = dv.TrangThai;
                        cd.isDongBo = false;
                        cd.isXoa = false;
                        db.PSChiDinhDichVus.InsertOnSubmit(cd);
                        db.SubmitChanges();
                        maCD = cd.MaChiDinh;
                    }

                }
                else
                {
                    PSChiDinhDichVu cd = new PSChiDinhDichVu();
                    cd.IDGoiDichVu = dv.IDGoiDichVu;
                    cd.IDNhanVienChiDinh = dv.MaNVChiDinh;
                    cd.isLayMauLai = dv.isLayMauLai;
                    if (isLamLaiXN)
                        cd.MaChiDinh = "XN" + GetID();
                    else
                        cd.MaChiDinh = "CD" + GetID();
                    cd.MaDonVi = dv.MaDonVi;
                    cd.MaNVChiDinh = dv.MaNVChiDinh;
                    cd.MaTiepNhan = dv.MaTiepNhan;
                    cd.MaPhieu = dv.MaPhieu;
                    cd.MaPhieuLan1 = dv.MaPhieuLan1;
                    cd.NgayChiDinhHienTai = dv.NgayChiDinhHienTai;
                    cd.NgayChiDinhLamViec = dv.NgayChiDinhLamViec;
                    cd.SoLuong = dv.SoLuong;
                    cd.TrangThai = dv.TrangThai;
                    cd.NgayTiepNhan = dv.NgayTiepNhan;
                    cd.isXoa = false;
                    cd.isDongBo = false;
                    db.PSChiDinhDichVus.InsertOnSubmit(cd);
                    db.SubmitChanges();
                    maCD = cd.MaChiDinh;
                }
                var results = db.PSTiepNhans.Where(p => p.isXoa == false && p.MaPhieu == dv.MaPhieu && p.MaDonVi == dv.MaDonVi).ToList();
                if (results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        result.isDongBo = false;
                        result.isDaDanhGia = true;
                        db.SubmitChanges();
                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
                return maCD;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return string.Empty;
            }
        }
        public bool InsertDotChiDinhDichVuChiTiet(PSChiDinhDichVuChiTiet ct)
        {
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                if (!string.IsNullOrEmpty(ct.RowIDDichVuChiTiet.ToString()))
                {
                    if (ct.RowIDDichVuChiTiet > 0)
                    {
                        var row = db.PSChiDinhDichVuChiTiets.FirstOrDefault(p => p.RowIDDichVuChiTiet == ct.RowIDDichVuChiTiet);
                        if (row != null)
                        {
                            row.GiaTien = ct.GiaTien;
                            row.isXetNghiemLan2 = ct.isXetNghiemLan2;
                            row.MaChiDinh = ct.MaChiDinh;
                            row.MaDichVu = ct.MaDichVu;
                            row.MaDonVi = ct.MaDonVi;
                            row.MaGoiDichVu = ct.MaGoiDichVu;
                            row.MaPhieu = ct.MaPhieu;
                            row.SoLuong = ct.SoLuong;
                            row.isDongBo = false;
                            row.isXoa = false;
                            db.SubmitChanges();
                        }
                        {
                            PSChiDinhDichVuChiTiet ctt = new PSChiDinhDichVuChiTiet();
                            ctt.GiaTien = ct.GiaTien;
                            ctt.isXetNghiemLan2 = ct.isXetNghiemLan2;
                            ctt.MaChiDinh = ct.MaChiDinh;
                            ctt.MaDichVu = ct.MaDichVu;
                            ctt.MaDonVi = ct.MaDonVi;
                            ctt.MaGoiDichVu = ct.MaGoiDichVu;
                            ctt.MaPhieu = ct.MaPhieu;
                            ctt.SoLuong = ct.SoLuong;
                            ctt.isXoa = false;
                            ctt.isDongBo = false;
                            db.PSChiDinhDichVuChiTiets.InsertOnSubmit(ctt);
                            db.SubmitChanges();
                        }
                    }
                    else
                    {
                        PSChiDinhDichVuChiTiet ctt = new PSChiDinhDichVuChiTiet();
                        ctt.GiaTien = ct.GiaTien;
                        ctt.isXetNghiemLan2 = ct.isXetNghiemLan2;
                        ctt.MaChiDinh = ct.MaChiDinh;
                        ctt.MaDichVu = ct.MaDichVu;
                        ctt.MaDonVi = ct.MaDonVi;
                        ctt.MaGoiDichVu = ct.MaGoiDichVu;
                        ctt.MaPhieu = ct.MaPhieu;
                        ctt.SoLuong = ct.SoLuong;
                        ctt.isXoa = false;
                        ctt.isDongBo = false;
                        db.PSChiDinhDichVuChiTiets.InsertOnSubmit(ctt);
                        db.SubmitChanges();
                    }
                }

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        public PsReponse HuyKetQuaPhongXetNghiem() // đưa về danh sách chờ kết quả xét nghiệm
        {

            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {

            }
            catch
            {

            }
            return new PsReponse();
        }
        public PsReponse HuyMauTrongPhongXetNghiem() //đưa về danh sách cấp mã  (xét trạng thái bằng 3)
        {
            return new PsReponse();
        }
        public PsReponse HuyTiepNhan() //Đưa phiếu đã tiếp nhận và danh sách hủy
        {
            return new PsReponse();
        }
        public PsReponse HuyChiDinhDichVu(string maCD, string maNV, string lydoHuy, string maPhieu, string maTiepNhan)
        {
            PsReponse res = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try
            {
                var KQ = db.PSXN_KetQuas.Where(p => p.MaChiDinh == maCD && p.isXoa == false).ToList();
                if (KQ.Count > 0)
                {
                    db.Connection.Close();
                    res.Result = false;
                    res.StringError = "Phiếu đã vào phòng xét nghiệm nên không được quyền hủy các dịch vụ ở phiếu này";
                    return res;
                }
                else
                {
                    var cd = db.PSChiDinhDichVus.FirstOrDefault(p => p.MaChiDinh == maCD && p.isXoa == false && p.MaPhieu == maPhieu);
                    if (cd != null)
                    {
                        cd.isXoa = true;
                        cd.IDNhanVienXoa = maNV;
                        cd.isDongBo = false;
                        cd.NgayGioXoa = DateTime.Now;
                        db.SubmitChanges();
                        if (!cd.MaChiDinh.Substring(0, 2).Equals("XN"))
                        {
                            var tn = db.PSTiepNhans.FirstOrDefault(p => p.MaTiepNhan == maTiepNhan && p.MaPhieu == maPhieu && p.isXoa == false);
                            if (tn != null)
                            {
                                tn.isDaDanhGia = false;
                                db.SubmitChanges();
                            }
                        }
                        var CDCT = db.PSChiDinhDichVuChiTiets.Where(p => p.MaChiDinh == maCD && p.isXoa == false).ToList();
                        foreach (var item in CDCT)
                        {
                            item.isXoa = true;
                            item.IDNhanVienXoa = maNV;
                            item.NgayGioXoa = DateTime.Now;
                            db.SubmitChanges();
                        }
                    }
                }

                db.Transaction.Commit();
                db.Connection.Close();
                res.Result = true;

            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                res.Result = false;
                if (string.IsNullOrEmpty(res.StringError))
                    res.StringError = ex.ToString();

            }
            return res;
        }
        #endregion SET
        public PsReponse HuyPhieuDaTiepNhan(string maphieu)
        {
            PsReponse res = new PsReponse();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            try {
                var phieu = db.PSTiepNhans.FirstOrDefault(x => x.MaPhieu == maphieu);
                var psl = db.PSPhieuSangLocs.FirstOrDefault(x => x.IDPhieu == maphieu);
                if(phieu!=null)
                {
                    db.PSTiepNhans.DeleteOnSubmit(phieu);
                }
               
                if(psl!=null)
                {
                    psl.NgayNhanMau = null;
                    psl.TrangThaiMau = 0;
                    psl.TrangThaiPhieu = false;
                }
                db.SubmitChanges();
                db.Transaction.Commit();
                db.Connection.Close();
                res.Result = true;
            }
            catch(Exception ex)
            {

                db.Transaction.Rollback();
                db.Connection.Close();
                res.Result = false;
                if (string.IsNullOrEmpty(res.StringError))
                    res.StringError = ex.ToString();
            }
            return res;
        }
        private static string SoBanDau()
        {
            try
            {

                var dat = db.ExecuteQuery<DateTime>("Select GETDATE()").FirstOrDefault();
                string s1 = (dat.Year.ToString()).Trim().Substring(DateTime.Now.Year.ToString().Trim().ToString().Length - 2);
                string s2 = (dat.Month.ToString()).PadLeft(2, '0');
                return s1 + s2;
            }
            catch
            {
                string s1 = (DateTime.Now.Year.ToString()).Trim().Substring(DateTime.Now.Year.ToString().Trim().ToString().Length - 2);
                string s2 = (DateTime.Now.Month.ToString()).PadLeft(2, '0');
                return s1 + s2;
            }
        }
        public DateTime GetDateTimeServer()
        {
            return db.ExecuteQuery<DateTime>("Select GETDATE()").FirstOrDefault();
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

    }
}
