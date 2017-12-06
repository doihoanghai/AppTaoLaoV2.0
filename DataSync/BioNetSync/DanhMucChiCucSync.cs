using System.Linq;
using System.Text;
using BioNetModel.Data;
using BioNetModel;
using Bionet.API.Models;
using System.Net;
using System.Security;
using System.Web.Script.Serialization;
using System.Web;
using System.Data.Linq;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Security.Cryptography;
using DataSync;
using System.Data;
using System.Reflection;
using DataSync.BioNetSync;
using System.Drawing;
using System.Collections.Generic;
using System;

namespace DataSync.BioNetSync
{
   public class DanhMucChiCucSync
    {
        private static BioNetDBContextDataContext db = null;
        //private static string linkGetDanhMucChiCuc = "/api/chicuc/getall?keyword=&page=0&pagesize=20";
        private static string linkGetDanhMucChiCuc = "/api/chicuc/getall?keyword=&page=0&pagesize=100";
        private static string linkPostDanhMucChiCuc = "/api/chicuc/AddUpFromApp";

        public static PsReponse PostDanhMucChiCuc()
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
                        var datas = db.PSDanhMucChiCucs.Where(p => p.isDongBo == false);
                        if(datas.Count()>0)
                        {
                            foreach (var data in datas)
                            {
                                DanhMucChiCucViewModel datac = new DanhMucChiCucViewModel();
                                var datact = cn.ConvertObjectToObject(data, datac);
                                string jsonstr = new JavaScriptSerializer().Serialize(datact);
                                var result = cn.PostRespone(cn.CreateLink(linkPostDanhMucChiCuc), token, jsonstr);
                                if (result.Result)
                                {
                                    res.StringError += "Dữ liệu chi cục " + data.TenChiCuc + " đang đồng bộ lên tổng cục \r\n";
                                    var resupdate = UpdateStatusSyncDanhMucChiCuc(data);
                                    if (!resupdate.Result)
                                    {
                                        res.StringError += "Dữ liệu chi cục " + data.TenChiCuc + " chưa được cập nhật \r\n";
                                    }
                                    else
                                    {
                                        res.StringError+= "Dữ liệu chi cục " + data.TenChiCuc + " đã được cập nhật \r\n";
                                    }

                                }
                                else
                                {
                                    res.Result = false;
                                    res.StringError += "Dữ liệu đơn vị " + data.TenChiCuc + " chưa được đồng bộ lên tổng cục \r\n";
                                }
                                res.Result = true;

                            }
                    }
                   else
                    {
                            res.Result = false;
                            res.StringError += "Không có dữ liệu chi cục cần đồng bộ \r\n";
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
        private static PsReponse UpdateStatusSyncDanhMucChiCuc(PSDanhMucChiCuc chicuc)
        {
            PsReponse res = new PsReponse();
           
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSDanhMucChiCucs.FirstOrDefault(p => p.MaChiCuc == chicuc.MaChiCuc);
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

        public static PsReponse GetDanhMucChiCuc()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetDanhMucChiCuc), token);
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
                                        PSDanhMucChiCuc kt = new PSDanhMucChiCuc();
                                        kt = cn.CovertDynamicToObjectModel(item, kt);
                                        var resup =    UpdateDMChiCuc(kt);
                                        if(!resup.Result)
                                        { res.StringError += resup.StringError;
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
                res.StringError = ex.Message;
            }
            if(res.Result==false)
            {
                res.StringError = "Lỗi đồng bộ chi cục - " + res.StringError;
            }
            return res;
        }
        public static PsReponse UpdateDMChiCuc(PSDanhMucChiCuc cc)
        {
            PsReponse res = new PsReponse();
            res.Result = true;
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var kyt = db.PSDanhMucChiCucs.FirstOrDefault(p => p.MaChiCuc == cc.MaChiCuc);
                if (kyt != null)
                {
                    if (!kyt.isDongBo)
                    {
                        kyt.isLocked = cc.isLocked;
                        kyt.Stt = cc.Stt;
                        kyt.TenChiCuc = Encoding.UTF8.GetString(Encoding.Default.GetBytes( cc.TenChiCuc));
                        kyt.SdtChiCuc = cc.SdtChiCuc;
                        kyt.DiaChiChiCuc = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cc.DiaChiChiCuc));
                        kyt.MaTrungTam = cc.MaTrungTam;
                        kyt.isXoa = cc.isXoa;
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
                  
                    PSDanhMucChiCuc ccnew = new PSDanhMucChiCuc();
                    ccnew.isLocked = cc.isLocked;
                    ccnew.Stt = cc.Stt;
                    ccnew.TenChiCuc = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cc.TenChiCuc));
                    ccnew.SdtChiCuc = cc.SdtChiCuc;
                    ccnew.DiaChiChiCuc = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cc.DiaChiChiCuc));
                    ccnew.MaTrungTam = cc.MaTrungTam;
                    ccnew.isXoa = cc.isXoa;
                    ccnew.MaChiCuc = cc.MaChiCuc;
                    try
                    {
                        ccnew.HeaderReport = cc.HeaderReport;
                        ccnew.Logo = cc.Logo;
                    }
                    catch { }
                    db.PSDanhMucChiCucs.InsertOnSubmit(ccnew);
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
