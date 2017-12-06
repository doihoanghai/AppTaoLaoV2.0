
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BioNetModel.Data;
using BioNetModel;
using Bionet.API.Models;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
    public class DanhMucDichVuSync
    {
        private static BioNetDBContextDataContext db = null;
        // private static string linkhost = "http://localhost:53112";
        private static string linkGetDanhMucdichvu = "/api/dichvu/getall?keyword=&page=0&pagesize=999";
        public static PsReponse GetDMDichVu()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetDanhMucdichvu), token);
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
                                        PSDanhMucDichVu ct = new PSDanhMucDichVu();
                                        ct = cn.CovertDynamicToObjectModel(item, ct);
                                        UpdateDMDichVu(ct);
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
                    res.StringError = "Chưa có  tài khoản đồng bộ!";
                }


            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError = ex.Message;
            }
            if (res.Result == false)
            {
                res.StringError = "Lỗi đồng bộ danh mục dịch vụ - " + res.StringError;
            }
            return res;
        }
        public static PsReponse UpdateDMDichVu(PSDanhMucDichVu dv)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var div = db.PSDanhMucDichVus.FirstOrDefault(p => p.IDDichVu == dv.IDDichVu.Trim());
                if (div != null)
                {
                    div.isLocked = dv.isLocked;
                    div.isGoiXn = dv.isGoiXn;
                    div.MaNhom = dv.MaNhom;
                    div.TenDichVu = Encoding.UTF8.GetString(Encoding.Default.GetBytes(dv.TenDichVu));
                    div.TenHienThiDichVu = Encoding.UTF8.GetString(Encoding.Default.GetBytes(dv.TenHienThiDichVu));
                    db.SubmitChanges();
                }
                else
                {
                    PSDanhMucDichVu divu = new PSDanhMucDichVu();
                    divu.IDDichVu = dv.IDDichVu.Trim();
                    divu.isLocked = dv.isLocked;
                    divu.isGoiXn = dv.isGoiXn;
                    divu.GiaDichVu = dv.GiaDichVu;
                    divu.MaNhom = dv.MaNhom;
                    divu.TenDichVu = Encoding.UTF8.GetString(Encoding.Default.GetBytes(dv.TenDichVu));
                    divu.TenHienThiDichVu = Encoding.UTF8.GetString(Encoding.Default.GetBytes(dv.TenHienThiDichVu));
                    db.PSDanhMucDichVus.InsertOnSubmit(divu);
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
