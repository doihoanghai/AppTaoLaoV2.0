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
   public class DanhMucGoiDichVuChungSync
    {
        private static BioNetDBContextDataContext db = null;
        // private static string linkhost = "http://localhost:53112";
        private static string linkDanhMucGoiDichVuChung = "/api/goidichvuchung/getallGoiDichVu?keyword=&page=0&pagesize=999";
        private static string linkGetDanhMucGoiDVChung_ChiTiet = "/api/chitietgoidichvu/getServiceByServicePackage/";

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
                            ObjectModel.RootObjectAPI Repo = jss.Deserialize<ObjectModel.RootObjectAPI>(json);
                            if (Repo != null)
                            {
                                if (Repo.TotalCount > 0)
                                {
                                    foreach (var item in Repo.Items)
                                    {
                                        PSDanhMucGoiDichVuChung ct = new PSDanhMucGoiDichVuChung();
                                        ct = cn.CovertDynamicToObjectModel(item, ct);
                                        
                                        UpdateDMGoiDichVuChung(ct);
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu Danh Mục Gói Dịch Vụ Chung từ server \r\n " + ex.Message;
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
               
                    var kyt = db.PSDanhMucGoiDichVuChungs.FirstOrDefault(p => p.IDGoiDichVuChung == cl.IDGoiDichVuChung);
                    if (kyt != null)
                    {
                        kyt.TenGoiDichVuChung = cl.TenGoiDichVuChung;
                        kyt.DonGia = cl.DonGia;
                        kyt.ChietKhau = cl.ChietKhau;
                        db.SubmitChanges();
                    }
                    else
                    {
                        PSDanhMucGoiDichVuChung kyth = new PSDanhMucGoiDichVuChung();
                        kyth.ChietKhau = cl.ChietKhau;
                        kyth.DonGia = cl.DonGia;
                        kyth.IDGoiDichVuChung = cl.IDGoiDichVuChung;
                        kyth.TenGoiDichVuChung = cl.TenGoiDichVuChung;
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
                            ObjectModel.RootObjectAPI Repo = jss.Deserialize<ObjectModel.RootObjectAPI>(json);
                            if (Repo != null)
                            {
                                if (Repo.TotalCount > 0)
                                {
                                    foreach (var item in Repo.Items)
                                    {
                                        PSChiTietGoiDichVuChung  ct = new PSChiTietGoiDichVuChung();
                                        ct = cn.CovertDynamicToObjectModel(item, ct);
                                        UpdateDMGoiDichVuChung_ChiTiet(ct);
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu Danh Mục Chi Tiết Gói Dịch Vụ Chung từ server \r\n " + ex.Message;
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
                
                    var kyt = db.PSChiTietGoiDichVuChungs.FirstOrDefault(p => p.IDGoiDichVuChung == cl.IDGoiDichVuChung && p.IDDichVu == cl.IDDichVu);
                    if (kyt == null)
                    {
                        PSChiTietGoiDichVuChung kyth = new PSChiTietGoiDichVuChung();
                        kyth.IDDichVu = cl.IDDichVu;
                        kyth.IDGoiDichVuChung = cl.IDGoiDichVuChung;
                        db.PSChiTietGoiDichVuChungs.InsertOnSubmit(kyth);
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
