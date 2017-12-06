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
using Bionet.Web.Models;

namespace DataSync.BioNetSync
{
   public class DanhMucGoiDichVuChungSync
    {
        private static BioNetDBContextDataContext db = null;
        // private static string linkhost = "http://localhost:53112";
        private static string linkDanhMucGoiDichVuChung = "/api/goidichvuchung/getallGoiDichVu?keyword=&page=0&pagesize=999";
        private static string linkGetDanhMucGoiDVChung_ChiTiet = "/api/chitietgoidichvu/getAll/";

        public static PsReponse GetDMGoiDichVuChung()
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
                        var result = cn.GetRespone(cn.CreateLink(linkDanhMucGoiDichVuChung), token);
                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            List<PSDanhMucGoiDichVuChung> lst = jss.Deserialize<List<PSDanhMucGoiDichVuChung>>(json);
                            if (lst != null)
                            {
                                if (lst.Count > 0)
                                {
                                    foreach (PSDanhMucGoiDichVuChung item in lst)
                                    {
                                        PSDanhMucGoiDichVuChung ct = new PSDanhMucGoiDichVuChung();
                                        UpdateDMGoiDichVuChung(item);
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
                res.StringError = "Lỗi đồng bộ danh mục gói dịch vụ chung - " + res.StringError;
            }
            return res;
        }
        public static PsReponse UpdateDMGoiDichVuChung(PSDanhMucGoiDichVuChung cl)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
               
                    var kyt = db.PSDanhMucGoiDichVuChungs.FirstOrDefault(p => p.IDGoiDichVuChung == cl.IDGoiDichVuChung.Trim());
                    if (kyt != null)
                    {
                        kyt.TenGoiDichVuChung = cl.TenGoiDichVuChung!=null?Encoding.UTF8.GetString(Encoding.Default.GetBytes(cl.TenGoiDichVuChung)):null;
                        kyt.DonGia = cl.DonGia;
                        kyt.ChietKhau = cl.ChietKhau;
                        db.SubmitChanges();
                    }
                    else
                    {
                        PSDanhMucGoiDichVuChung kyth = new PSDanhMucGoiDichVuChung();
                   
                        kyth.ChietKhau = cl.ChietKhau;
                        kyth.DonGia = cl.DonGia;
                        kyth.IDGoiDichVuChung = cl.IDGoiDichVuChung.Trim();
                        kyth.TenGoiDichVuChung = cl.TenGoiDichVuChung != null ? Encoding.UTF8.GetString(Encoding.Default.GetBytes(cl.TenGoiDichVuChung)) : null;
                        kyth.Stt = db.PSDanhMucGoiDichVuChungs.Max(p => p.Stt)+1;
                        db.PSDanhMucGoiDichVuChungs.InsertOnSubmit(kyth);
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

        public static PsReponse GetDMGoiDichVuChung_ChiTiet()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetDanhMucGoiDVChung_ChiTiet), token);
                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            List<PSChiTietGoiDichVuChung> list = jss.Deserialize<List<PSChiTietGoiDichVuChung>>(json);
                            if (list != null)
                            {
                                if (list.Count > 0)
                                {
                                    foreach (var item in list)
                                    {
                                        //PSChiTietGoiDichVuChung  ct = new PSChiTietGoiDichVuChung();
                                        //ct = cn.CovertDynamicToObjectModel(item, ct);
                                        UpdateDMGoiDichVuChung_ChiTiet(item);
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
                res.StringError = "Lỗi đồng bộ chi tiết gói dịch vụ chung- " + res.StringError;
            }
            return res;
        }
        public static PsReponse UpdateDMGoiDichVuChung_ChiTiet(PSChiTietGoiDichVuChung cl)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                
                    var kyt = db.PSChiTietGoiDichVuChungs.FirstOrDefault(p => p.IDGoiDichVuChung == cl.IDGoiDichVuChung.Trim() && p.IDDichVu == cl.IDDichVu.Trim());
                    if (kyt == null)
                    {
                        PSChiTietGoiDichVuChung kyth = new PSChiTietGoiDichVuChung();
                        kyth.IDDichVu = cl.IDDichVu.Trim();
                        kyth.IDGoiDichVuChung = cl.IDGoiDichVuChung.Trim();
                        db.PSChiTietGoiDichVuChungs.InsertOnSubmit(kyth);
                        db.SubmitChanges();
                    }
                else
                {
                    kyt.IDDichVu = cl.IDDichVu.Trim();
                    kyt.IDGoiDichVuChung = cl.IDGoiDichVuChung.Trim();
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
