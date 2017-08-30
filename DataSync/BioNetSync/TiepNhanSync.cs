using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;


namespace DataSync.BioNetSync
{
    public class TiepNhanSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkGetTiepNhan = "/api/tiepnhan/getall?keyword=&page=0&pagesize=20";
        private static string linkPostTiepNhan = "/api/tiepnhan/AddUpFromApp";

        public static PsReponse GetTiepNhan()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetTiepNhan), token);
                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();

                            ObjectModel.RootObjectAPI psl = jss.Deserialize<ObjectModel.RootObjectAPI>(json);
                            //List<PSPatient> patient = jss.Deserialize<List<PSPatient>>(json);
                            List<PSTiepNhan> lstpsl = new List<PSTiepNhan>();
                            if (psl.TotalCount > 0)
                            {
                                foreach (var item in psl.Items)
                                {
                                    PSTiepNhan term = new PSTiepNhan();
                                    term = cn.CovertDynamicToObjectModel(item, term);
                                    lstpsl.Add(term);
                                }
                                //UpdatePatient(patient);
                                UpdateTiepNhan(lstpsl);
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu Danh Mục Mapping Kỹ Thuật - Dịch Vụ từ server \r\n " + ex.Message;

            }
            return res;
        }
        public static PsReponse UpdateTiepNhan(List<PSTiepNhan> lstpsl)
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
                    var psldb = db.PSTiepNhans.FirstOrDefault(p => p.MaPhieu == psl.MaPhieu);
                    if (psldb != null)
                    {
                        var term = psl.RowIDPhieu;
                        psldb = psl;
                        psldb.RowIDPhieu = term;
                        db.SubmitChanges();

                    }
                    else
                    {
                        PSTiepNhan newpsl = new PSTiepNhan();
                        newpsl = psl;
                        newpsl.RowIDPhieu = 0;
                        newpsl.isDongBo = true;
                        db.PSTiepNhans.InsertOnSubmit(newpsl);
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

        public static PsReponse PostTiepNhan()
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
                        var datas = db.PSTiepNhans.Where(p => p.isDongBo == false);
                        foreach (var data in datas)
                        {
                            string jsonstr = new JavaScriptSerializer().Serialize(data);
                            var result = cn.PostRespone(cn.CreateLink(linkPostTiepNhan), token, jsonstr);
                            if (result.Result)
                            {
                                res.StringError += "Dữ liệu đơn vị " + data.MaDonVi + " đã được đồng bộ lên tổng cục \r\n";
                                List<PSTiepNhan> lstpsl = new List<PSTiepNhan>();
                                lstpsl.Add(data);
                                var resupdate = UpdateTiepNhan(lstpsl);
                                if (!resupdate.Result)
                                {
                                    res.StringError += "Dữ liệu đơn vị " + data.MaDonVi + " chưa được cập nhật \r\n";
                                }
                            }
                            else
                            {
                                res.Result = false;
                                res.StringError += "Dữ liệu đơn vị " + data.MaDonVi + " chưa được đồng bộ lên tổng cục \r\n";
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


    }
}