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
   public class DanhMucKyThuatSync
    {
        private static BioNetDBContextDataContext db = null;
        // private static string linkhost = "http://localhost:53112";
        private static string linkGetDanhMucKyThuat = "/api/dmkythuatxn/getall?keyword=&page=0&pagesize=999";

        public static PsReponse GetDMKyThuat()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetDanhMucKyThuat), token);
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
                                        PSDanhMucKyThuatXN kt = new PSDanhMucKyThuatXN();
                                        kt = cn.CovertDynamicToObjectModel(item, kt);
                                        UpdateDMKyThuat(kt);
                                    }
                                    res.Result = true;
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
                    res.StringError = "Chưa có tài khoản đồng bộ!";
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError = ex.Message;
            }
            if (res.Result == false)
            {
                res.StringError = "Lỗi đồng bộ danh mục kỹ thuật dịch vụ - " + res.StringError;
            }
            return res;
        }
        public static PsReponse UpdateDMKyThuat(PSDanhMucKyThuatXN kt)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var kyt = db.PSDanhMucKyThuatXNs.FirstOrDefault(p => p.IDKyThuatXN == kt.IDKyThuatXN);
                if (kyt != null)
                {
                    kyt.isLocked = kt.isLocked;
                    kyt.STT = kt.STT;
                    kyt.TenKyThuat = kt.TenKyThuat != null ? Encoding.UTF8.GetString(Encoding.Default.GetBytes(kt.TenKyThuat)) : null;
                    kyt.TenHienThiKyThuat = kt.TenHienThiKyThuat != null ? Encoding.UTF8.GetString(Encoding.Default.GetBytes(kt.TenHienThiKyThuat)) : null;
                    db.SubmitChanges();
                }
                else
                {
                    PSDanhMucKyThuatXN kyth = new PSDanhMucKyThuatXN();
                    kyth.isLocked = kt.isLocked;
                    kyth.STT = kt.STT;
                    kyth.TenKyThuat = kt.TenKyThuat!=null?Encoding.UTF8.GetString(Encoding.Default.GetBytes(kt.TenKyThuat)):null;
                    kyth.TenHienThiKyThuat = kt.TenHienThiKyThuat!=null?Encoding.UTF8.GetString(Encoding.Default.GetBytes(kt.TenHienThiKyThuat)):null;
                    kyth.IDKyThuatXN = kt.IDKyThuatXN;
                    db.PSDanhMucKyThuatXNs.InsertOnSubmit(kyth);
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

    }
}
