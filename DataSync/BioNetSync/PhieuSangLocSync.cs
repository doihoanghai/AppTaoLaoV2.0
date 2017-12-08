using BioNetBLL;
using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;


namespace DataSync.BioNetSync
{
    public class PhieuSangLocSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkGetPhieuSangLoc = "/api/phieusangloc/getallFromApp?keyword=&page=0&pagesize=999";
        private static string linkPostPhieuSangLoc = "/api/phieusangloc/AddUpFromApp";
        private static string linkXoaPhieu = "/api/phieusangloc/getdeleted";

        public static PsReponse GetPhieuSangLoc()
        {
            PsReponse res = new PsReponse();
            res.Result = true;
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                var account = db.PSAccount_Syncs.FirstOrDefault();
                if (account != null)
                {
                    string token = cn.GetToken(account.userName, account.passWord);
                    if (!string.IsNullOrEmpty(token))
                    {
                        var result = cn.GetRespone(cn.CreateLink(linkGetPhieuSangLoc), token);
                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            ObjectModel.RootObjectAPI  psl = jss.Deserialize<ObjectModel.RootObjectAPI>(json);
                            List<PSPhieuSangLoc> lstpsl = new List<PSPhieuSangLoc>();
                            if (psl.TotalCount > 0)
                            {
                                foreach(var item in psl.Items)
                                {
                                    PSPhieuSangLoc term = new PSPhieuSangLoc();                                  
                                    term = cn.CovertDynamicToObjectModel(item, term);
                                    lstpsl.Add(term);
                                }
                                var resUpdate = UpdatePhieuSangLoc(lstpsl,1);
                                if (resUpdate.Result == true)
                                {
                                    res.Result = true;
                                }
                                else
                                {
                                    res.Result = false;
                                    res.StringError = resUpdate.StringError;
                                }
                            }
                            XoaPhieuDongBO();
                        }
                        else
                        {
                            res.Result = false;
                            res.StringError = result.ErorrResult;
                        }
                    }
                    else
                    {
                        res.Result = false;
                        res.StringError = "Kiểm tra lại kết nối mạng hoặc tài khoản đồng bộ!";
                    }
                }
                else
                {
                    res.Result = false;
                    res.StringError = "Chưa có  tài khoản đồng bộ!";
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu phiếu sàng ltiếp nhận \r\n " + ex.Message;
            }
            return res;
        }

        public static PsReponse UpdatePhieuSangLoc(List<PSPhieuSangLoc> lstpsl,int luachon)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                var account = db.PSPhieuSangLocs.FirstOrDefault();
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                foreach (var psl in lstpsl)
                {
                    var psldb = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieu == psl.IDPhieu );
                  
                    if (psldb != null)
                    {
                        if (psldb.TrangThaiMau == 0 || psldb.TrangThaiMau == null)
                        {
                            var term = psldb.RowIDPhieu;

                            psldb.RowIDPhieu = term;
                            if (luachon == 1)
                            {
                                psldb.DiaChiLayMau = psl.DiaChiLayMau!=null?Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.DiaChiLayMau)):null;
                                psldb.NoiLayMau = psl.NoiLayMau != null?Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.NoiLayMau)):null;
                                psldb.TenNhanVienLayMau = psl.TenNhanVienLayMau != null? Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.TenNhanVienLayMau)):null;
                                
                            }

                            db.SubmitChanges();
                        }
                            
                    }
                    else
                    {
                        PSPhieuSangLoc newpsl = new PSPhieuSangLoc();
                        newpsl = psl;
                        int a=psl.IDNhanVienTaoPhieu.Length;
                        newpsl.IDNhanVienTaoPhieu = psl.IDNhanVienTaoPhieu;
                        if(psl.DiaChiLayMau!=null)
                        {
                            newpsl.DiaChiLayMau = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.DiaChiLayMau));
                        }
                        if (psl.NoiLayMau != null)
                        {
                            newpsl.NoiLayMau = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.NoiLayMau));
                        }
                        if (psl.TenNhanVienLayMau != null)
                        {
                            newpsl.TenNhanVienLayMau = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.TenNhanVienLayMau));
                        }
                        newpsl.RowIDPhieu = 0;
                        newpsl.isXoa = false;
                        newpsl.isDongBo = true;
                        db.PSPhieuSangLocs.InsertOnSubmit(newpsl);
                        db.SubmitChanges();
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
                res.StringError = ex.ToString();
            }
            return res;
        }

        public static PsReponse PostPhieuSangLoc()
        {
            PsReponse res = new PsReponse();
            List<String> listPhieuXoa = new List<String>();
            res.Result = true;
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                var account = db.PSAccount_Syncs.FirstOrDefault();
                if (account != null)
                {
                    string token = cn.GetToken(account.userName, account.passWord);
                    if (!string.IsNullOrEmpty(token))
                    {
                        var datas = db.PSPhieuSangLocs.Where(p => p.isDongBo !=true ).OrderBy(x=>x.RowIDPhieu).ToList();
                        List<string> jsonstr = new List<string>();
                        string Nhom = (string)null;
                        while (datas.Count() > 1000)
                        {
                            var temp = datas.Take(1000);
                            Nhom = new JavaScriptSerializer().Serialize(temp);
                            jsonstr.Add(Nhom);
                            datas.RemoveRange(0, 1000);
                        } 
                        if (datas.Count() <= 1000 && datas.Count()>0)
                        {
                            Nhom = new JavaScriptSerializer().Serialize(datas);
                            jsonstr.Add(Nhom);
                        }
                        if(jsonstr.Count()>0)
                        {
                            #region Đồng bộ phiếu
                            foreach (var jsons in jsonstr)
                            {
                                var result = cn.PostRespone(cn.CreateLink(linkPostPhieuSangLoc), token, jsons);
                                if (result.Result)
                                {
                                    JavaScriptSerializer js = new JavaScriptSerializer();
                                    List<PSPhieuSangLoc> datares = js.Deserialize<List<PSPhieuSangLoc>>(jsons);
                                    var data = db.PSPhieuSangLocs.Where(s => (from d in datares select d.IDPhieu).Contains(s.IDPhieu));
                                    data.ToList().ForEach(c => c.isDongBo = true);
                                    db.SubmitChanges();
                                    var map = data.Where(y => y.isXoa == true).Select(x=>x.IDPhieu).ToList();
                                    listPhieuXoa.AddRange(map);
                                    #region Cập nhật phiếu lỗi
                                    string json = result.ErorrResult;
                                    JavaScriptSerializer jss = new JavaScriptSerializer();
                                    List<String> psl = jss.Deserialize<List<String>>(json);
                                    if (psl != null)
                                    {
                                        if (psl.Count > 0)
                                        {
                                            res.StringError = "Danh sách phiếu sàng lọc bị lỗi: \r\n ";
                                            foreach (var lst in psl)
                                            {
                                                PSResposeSync sn = cn.CutString(lst);
                                                if (sn != null)
                                                {
                                                    var ds = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieu == sn.Code);
                                                    if (ds != null)
                                                    {
                                                        ds.isDongBo = false;
                                                        res.StringError = res.StringError + sn.Code + ": " + sn.Error + ".\r\n";
                                                        listPhieuXoa.Remove(sn.Code);
                                                    }
                                                }
                                            }
                                            db.SubmitChanges();
                                            res.Result = false;
                                        }
                                    }
                                    #endregion
                                    PsReponse resXoa = BioNet_Bus.DeletePhieu(listPhieuXoa, true,null,null);
                                    if (resXoa.Result == false)
                                    {
                                        res.StringError = res.StringError + resXoa.StringError;
                                    }

                                }
                                else
                                {
                                    res.Result = false;
                                    res.StringError = "Đồng bộ phiếu phiếu sàng lọc - Kiểm tra kết nội mạng! -"+result.ErorrResult+"!\r\n";
                                }

                            }
                            #endregion
                        }
                        else
                        {
                            res.Result = true;
                        }
                    }
                    if(String.IsNullOrEmpty(res.StringError))
                    {
                        res.Result = true;
                    }
                    else
                    {
                        res.Result = false;
                    }
                                         
                    }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError += DateTime.Now.ToString() + "Lỗi khi đồng bộ dữ liệu Danh Sách Đơn Vị Lên Tổng Cục \r\n " + ex.Message;
            }
            return res;
        }
        public static PsReponse XoaPhieuDongBO()
        {
            PsReponse res = new PsReponse();
            res.Result = true;
            try
            {
               
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                var account = db.PSAccount_Syncs.FirstOrDefault();
                if (account != null)
                {
                    string token = cn.GetToken(account.userName, account.passWord);
                    if (!string.IsNullOrEmpty(token))
                    {
                        var result = cn.GetRespone(cn.CreateLink(linkXoaPhieu), token);
                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            List<string> psl = jss.Deserialize<List<string>>(json);
                            List<string> listXoaPhieu = new List<string>();

                            if(psl!=null)
                            {
                                if (psl.Count > 0)
                                {
                                    foreach(var ps in psl)
                                    {
                                        var phieu2 = db.PSPhieuSangLocs.FirstOrDefault(x => x.isLayMauLan2 == true && x.IDPhieuLan1 == ps);
                                        if (phieu2 != null)
                                        {
                                            listXoaPhieu.Add(phieu2.IDPhieu);
                                        }
                                    }
                                    listXoaPhieu.AddRange(psl);
                                    PsReponse kq=BioNet_Bus.DeletePhieu(listXoaPhieu, true,null,null);
                                   

                                    if (kq.Result == true )
                                    {
                                        res.Result = true;
                                    }
                                    else
                                    {
                                        res.Result = false;
                                        if (kq.Result == false)
                                            res.StringError = " Xóa phiếu bị lỗi";
                                    
                                    }

                                }
                            }
                            
                        }
                        else
                        {
                            res.Result = false;
                            res.StringError = result.ErorrResult;
                        }
                    }
                    else
                    {
                        res.Result = false;
                        res.StringError = "Kiểm tra lại kết nối mạng hoặc tài khoản đồng bộ!";
                    }
                }
                else
                {
                    res.Result = false;
                    res.StringError = "Chưa có  tài khoản đồng bộ!";
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu phiếu sàng ltiếp nhận \r\n " + ex.Message;
            }
            return res;
        }
    }
}