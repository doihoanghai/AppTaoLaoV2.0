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
   public class DanhMucChuongTrinhSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkGetDanhMucChuongTrinh = "/api/chuongtrinh/getall?keyword=&page=0&pagesize=999";
        public static PsReponse GetDanhSachChuongTrinh()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetDanhMucChuongTrinh), token);
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
                                        PSDanhMucChuongTrinh ct = new PSDanhMucChuongTrinh();
                                        ct = cn.CovertDynamicToObjectModel(item, ct);
                                        UpdateDMChuongTrinh(ct);
                                    }
                                    res.Result = true;
                                }
                            }

                        }
                        else
                        {
                            res.Result = false;
                            res.StringError = result.ErorrResult;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError =  ex.Message;
            }
            if (res.Result == false)
            {
                res.StringError = "Lỗi đồng bộ danh mục chương trình- " + res.StringError;
            }
            return res;
        }
        public static PsReponse UpdateDMChuongTrinh(PSDanhMucChuongTrinh ct)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();

                db.Transaction = db.Connection.BeginTransaction();

                var ctr = db.PSDanhMucChuongTrinhs.FirstOrDefault(p => p.IDChuongTrinh == ct.IDChuongTrinh);
                if (ctr != null)
                {
                    ctr.isLocked = ct.isLocked;
                    ctr.NgayHetHieuLuc = ct.NgayHetHieuLuc;
                    ctr.TenChuongTrinh = Encoding.UTF8.GetString(Encoding.Default.GetBytes(ct.TenChuongTrinh));
                    db.SubmitChanges();
                }
                else
                {
                    PSDanhMucChuongTrinh chtr = new PSDanhMucChuongTrinh();
                    chtr.IDChuongTrinh = ct.IDChuongTrinh;
                    chtr.isLocked = ct.isLocked;
                    chtr.NgayHetHieuLuc = ct.NgayHetHieuLuc;
                    chtr.Ngaytao = ct.Ngaytao;
                    chtr.TenChuongTrinh = Encoding.UTF8.GetString(Encoding.Default.GetBytes(ct.TenChuongTrinh));
                    db.PSDanhMucChuongTrinhs.InsertOnSubmit(chtr);
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi cập nhật dữ liệu Danh Mục Chương Trình \r\n" + ex.ToString();
            }
            return res;
        }

    }
}
