using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;


namespace DataSync.BioNetSync
{
    public class PatientSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkGet = "/api/patient/getall?keyword=&page=0&pagesize=20";
        private static string linkPost = "/api/patient/AddUpFromApp";

        public static PsReponse GetPatient()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGet), token);
                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();

                            ObjectModel.RootObjectAPI psl = jss.Deserialize<ObjectModel.RootObjectAPI>(json);
                            //List<PSPatient> patient = jss.Deserialize<List<PSPatient>>(json);
                            List<PSPatient> lstpsl = new List<PSPatient>();
                            if (psl.TotalCount > 0)
                            {
                                foreach (var item in psl.Items)
                                {
                                    PSPatient term = new PSPatient();
                                    term = cn.CovertDynamicToObjectModel(item, term);
                                    lstpsl.Add(term);
                                }
                                //UpdatePatient(patient);
                                UpdatePatient(lstpsl);
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu danh mục Patient từ server \r\n " + ex.Message;

            }
            return res;
        }
        public static PsReponse UpdatePatient(List<PSPatient> lstpsl)
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
                    var psldb = db.PSPatients.FirstOrDefault(p => p.MaKhachHang == psl.MaKhachHang);
                    if (psldb != null)
                    {
                        var term = psl.RowIDBenhNhan;
                        psldb = psl;
                        psldb.RowIDBenhNhan = term;
                        db.SubmitChanges();

                    }
                    else
                    {
                        PSPatient newpsl = new PSPatient();
                        newpsl = psl;
                        newpsl.TenBenhNhan = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.TenBenhNhan));
                        newpsl.MotherName = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.MotherName));
                        newpsl.FatherName = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.FatherName));
                        newpsl.DiaChi = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.DiaChi));
                        newpsl.NoiSinh = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.NoiSinh));
                        newpsl.RowIDBenhNhan = 0;
                        newpsl.isDongBo = true;
                        db.PSPatients.InsertOnSubmit(newpsl);
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

        public static PsReponse PostPatient()
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
                        var datas = db.PSPatients.Where(p => p.isDongBo == false);
                        foreach (var data in datas)
                        {
                            string jsonstr = new JavaScriptSerializer().Serialize(data);
                            var result = cn.PostRespone(cn.CreateLink(linkPost), token, jsonstr);
                            if (result.Result)
                            {
                                res.StringError += "Dữ liệu Patient " + data.MaKhachHang + " đã được đồng bộ lên tổng cục \r\n";
                                List<PSPatient> lstpsl = new List<PSPatient>();
                                lstpsl.Add(data);
                                var resupdate = UpdatePatient(lstpsl);
                                if (!resupdate.Result)
                                {
                                    res.StringError += "Dữ liệu khách hàng " + data.MaKhachHang + " chưa được cập nhật \r\n";
                                }
                            }
                            else
                            {
                                res.Result = false;
                                res.StringError += "Dữ liệu khách hàng " + data.MaKhachHang + " chưa được đồng bộ lên tổng cục \r\n";
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