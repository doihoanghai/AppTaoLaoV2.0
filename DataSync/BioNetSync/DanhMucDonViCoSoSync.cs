using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
   public class DanhMucDonViCoSoSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkPostDanhMucDonViCoSo = "/api/donvicoso/AddUpFromApp";
        private static string linkGetDanhMucDonVi = "/api/donvicoso/getall?keyword=&page=0&pagesize=999";
        public static PsReponse PostDanhMucDonViCoSo()
        {
            PsReponse res = new PsReponse();
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
                        var datas = db.PSDanhMucDonViCoSos.Where(p => p.isDongBo == false);
                        foreach (var data in datas)
                        {
                            string jsonstr = new JavaScriptSerializer().Serialize(data);
                            var result = cn.PostRespone(cn.CreateLink(linkPostDanhMucDonViCoSo), token, jsonstr);
                            if (result.Result)
                            {
                                res.StringError += "Dữ liệu đơn vị " + data.TenDVCS + " đã được đồng bộ lên tổng cục \r\n";
                                var resupdate = UpdateStatusSyncDanhMucDonVi(data);
                                if (!resupdate.Result)
                                {
                                    res.StringError += "Dữ liệu đơn vị " + data.TenDVCS + " chưa được cập nhật \r\n";
                                }
                            }
                            else
                            {
                                res.Result = false;
                                res.StringError += "Dữ liệu đơn vị " + data.TenDVCS + " chưa được đồng bộ lên tổng cục \r\n";
                            }

                        }
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
        private static PsReponse UpdateStatusSyncDanhMucDonVi(PSDanhMucDonViCoSo dvcs)
        {
            PsReponse res = new PsReponse();
            
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSDanhMucDonViCoSos.FirstOrDefault(p => p.MaDVCS == dvcs.MaDVCS);
                if (dv != null)
                {
                    dv.isDongBo = true;
                    db.SubmitChanges();
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
        public static PsReponse GetDanhMucDonViCoSo()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetDanhMucDonVi), token);
                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            ObjectModel.RootObjectAPI Repo = jss.Deserialize<ObjectModel.RootObjectAPI>(json);
                            if (Repo != null)
                            {
                                if (Repo.TotalCount > 0)
                                {
                                    foreach (var item in Repo.Items)
                                    {
                                        PSDanhMucDonViCoSo kt = new PSDanhMucDonViCoSo();
                                        kt = cn.CovertDynamicToObjectModel(item, kt);
                                        var resup = UpdateDMDonviCoso(kt);
                                        if (!resup.Result)
                                        {
                                            res.StringError += resup.StringError;
                                            res.Result = false;
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu Danh Mục Kỹ Thuật từ server \r\n " + ex.Message;
            }
            return res;
        }
        public static PsReponse UpdateDMDonviCoso(PSDanhMucDonViCoSo cc)
        {
            PsReponse res = new PsReponse();
            res.Result = true;
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var kyt = db.PSDanhMucDonViCoSos.FirstOrDefault(p => p.MaDVCS == cc.MaDVCS);
                if (kyt != null)
                {
                    if (!kyt.isDongBo??false)
                    {
                        kyt.isLocked = cc.isLocked;
                        kyt.Stt = cc.Stt;
                        kyt.TenDVCS = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cc.TenDVCS));
                        kyt.SDTCS = cc.SDTCS;
                        kyt.DiaChiDVCS = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cc.DiaChiDVCS));
                        kyt.MaChiCuc = cc.MaChiCuc;
                        kyt.isLocked = cc.isLocked;
                        kyt.KieuTraKetQua = cc.KieuTraKetQua;
                        kyt.TenBacSiDaiDien = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cc.TenBacSiDaiDien));
                        
                        try
                        {
                            kyt.HeaderReport = cc.HeaderReport;
                            kyt.Logo = cc.Logo;
                        }
                        catch
                        { }

                        db.SubmitChanges();
                    }
                }
                else
                {

                    PSDanhMucDonViCoSo ccnew = new PSDanhMucDonViCoSo();
                    ccnew.isLocked = cc.isLocked;
                    ccnew.Stt = cc.Stt;
                    ccnew.TenDVCS = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cc.TenDVCS));
                    ccnew.SDTCS = cc.SDTCS;
                    ccnew.DiaChiDVCS = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cc.DiaChiDVCS));
                    ccnew.TenBacSiDaiDien   = cc.TenBacSiDaiDien;
                    ccnew.isDongBo  = true;
                    ccnew.MaChiCuc = cc.MaChiCuc;
                    ccnew.MaDVCS = cc.MaDVCS;
                    try
                    {
                        ccnew.HeaderReport = cc.HeaderReport;
                    }
                    catch { }
                    try
                    {
                        ccnew.Logo = cc.Logo;
                    }
                    catch { }
                    db.PSDanhMucDonViCoSos.InsertOnSubmit(ccnew);
                    db.SubmitChanges();

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
    }
}
