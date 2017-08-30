using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
     public class DanhMucDanTocSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkGetDanhMucDanToc = "/api/dantoc/getallDanToc";
        public static PsReponse GetDMDanToc()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetDanhMucDanToc), token);
                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            List<PSDanhMucDanToc> CLuong = jss.Deserialize<List<PSDanhMucDanToc>>(json);
                            if (CLuong.Count > 0)
                            {
                                foreach (var cl in CLuong)
                                {
                                    cl.TenDanToc = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cl.TenDanToc));
                                }
                                UpdateDMDanToc(CLuong);
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu Danh Mục Dân Tộc từ server \r\n " + ex.Message;
            }
            return res;
        }
        public static PsReponse UpdateDMDanToc(List<PSDanhMucDanToc> Clm)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                var account = db.PSAccount_Syncs.FirstOrDefault();
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                foreach (var cl in Clm)
                {
                    var kyt = db.PSDanhMucDanTocs.FirstOrDefault(p => p.IDDanToc == cl.IDDanToc);
                    if (kyt != null)
                    {
                        kyt.IDQuocGia = cl.IDQuocGia;
                        kyt.STT = cl.STT;
                        kyt.TenDanToc = cl.TenDanToc;
                        db.SubmitChanges();
                    }
                    else
                    {
                        PSDanhMucDanToc kyth = new PSDanhMucDanToc();
                        kyth.IDDanToc = cl.IDDanToc;
                        kyth.IDQuocGia = cl.IDQuocGia;
                        kyth.STT = cl.STT;
                        kyth.TenDanToc = cl.TenDanToc;
                        db.PSDanhMucDanTocs.InsertOnSubmit(kyth);
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
    }
}
