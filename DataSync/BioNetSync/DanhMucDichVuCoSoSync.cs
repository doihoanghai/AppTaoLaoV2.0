using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
    public class DanhMucDichVuCoSoSync
    {
        private static BioNetDBContextDataContext db = null;
        // private static string linkhost = "http://localhost:53112";
        private static string linkGetDanhMucdichvu = "/api/dichvutheodv/getall";
        public static PsReponse GetDMDichVuCoSo()
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
                            List< PSDanhMucDichVuTheoDonVi> list = jss.Deserialize<List<PSDanhMucDichVuTheoDonVi>>(json);
                            if (list != null)
                            {
                                if (list.Count > 0)
                                {
                                    foreach (var item in list)
                                    {
                                        PSDanhMucDichVuTheoDonVi ct = new PSDanhMucDichVuTheoDonVi();
                                        //ct = cn.CovertDynamicToObjectModel(item, ct);
                                        UpdateDMDichVu(item);
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu Danh Mục Dich Vụ từ server \r\n " + ex.Message;
            }
            return res;
        }
        public static PsReponse UpdateDMDichVu(PSDanhMucDichVuTheoDonVi dv)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var div = db.PSDanhMucDichVuTheoDonVis.FirstOrDefault(p => p.IDDichVu == dv.IDDichVu && p.MaDonVi==dv.MaDonVi);
                if (div != null)
                {
                    div.isLocked = dv.isLocked;
                    div.MaNhom = dv.MaNhom;
                    div.TenHienThi = dv.TenHienThi != null ? Encoding.UTF8.GetString(Encoding.Default.GetBytes(dv.TenHienThi)):null;
                    div.TenDichVu = dv.TenDichVu!=null?Encoding.UTF8.GetString(Encoding.Default.GetBytes(dv.TenDichVu)):null;
                    db.SubmitChanges();
                }
                else
                {
                    PSDanhMucDichVuTheoDonVi divu = new PSDanhMucDichVuTheoDonVi();
                    divu.isLocked = dv.isLocked;
                    divu.MaNhom = dv.MaNhom;
                    divu.TenHienThi = dv.TenHienThi != null ? Encoding.UTF8.GetString(Encoding.Default.GetBytes(dv.TenHienThi)) : null;
                    divu.DonGia = dv.DonGia;
                    divu.ChietKhau = dv.ChietKhau;
                    divu.TenDichVu = dv.TenDichVu != null ? Encoding.UTF8.GetString(Encoding.Default.GetBytes(dv.TenDichVu)) : null;
                    divu.MaDonVi = dv.MaDonVi;
                    divu.IDDichVu = dv.IDDichVu;
                    db.PSDanhMucDichVuTheoDonVis.InsertOnSubmit(divu);
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
