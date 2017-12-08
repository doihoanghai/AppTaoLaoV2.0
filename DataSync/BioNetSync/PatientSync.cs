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
        private static string linkGet = "/api/patient/getall?keyword=&page=0&pagesize=999";
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
                                var resUpdate = UpdatePatient(lstpsl, 1);
                                if (resUpdate.Result == true)
                                {
                                    res.Result = true;
                                }
                                else
                                {
                                    res.Result = false;
                                    res.StringError = resUpdate.StringError;
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
        public static PsReponse UpdatePatient(List<PSPatient> lstpsl, int luachon)
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
                    var psldb = db.PSPatients.FirstOrDefault(p => p.MaBenhNhan == psl.MaBenhNhan);
                    if (psldb != null)
                    {
                        var term = psldb.RowIDBenhNhan;
                        cn.ConvertObjectToObject(psl, psldb);

                        psldb.RowIDBenhNhan = term;

                        if (luachon == 1)
                        {
                            if (psl.TenBenhNhan != null)
                            {
                                psldb.TenBenhNhan = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.TenBenhNhan));
                            }
                            if (psl.MotherName != null)
                            {
                                psldb.MotherName = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.MotherName));
                            }
                            if (psl.FatherName != null)
                            {
                                psldb.FatherName = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.FatherName));
                            }
                            if (psl.DiaChi != null)
                            {
                                psldb.DiaChi = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.DiaChi));
                            }
                            if (psl.NoiSinh != null)
                            {
                                psldb.NoiSinh = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.NoiSinh));
                            }
                        }
                        else if (luachon == 2)
                        {

                        }


                        db.SubmitChanges();

                    }
                    else
                    {
                        PSPatient newpsl = new PSPatient();
                        newpsl = psl;
                        if (psl.TenBenhNhan != null)
                        {
                            newpsl.TenBenhNhan = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.TenBenhNhan));
                        }
                        if (psl.MotherName != null)
                        {
                            newpsl.MotherName = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.MotherName));
                        }
                        if (psl.FatherName != null)
                        {
                            newpsl.FatherName = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.FatherName));
                        }
                        if (psl.DiaChi != null)
                        {
                            newpsl.DiaChi = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.DiaChi));
                        }
                        if (psl.NoiSinh != null)
                        {
                            newpsl.NoiSinh = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.NoiSinh));
                        }
                        newpsl.isXoa = false;
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
                        var datas = db.PSPatients.Where(p => p.isDongBo != true && p.MaKhachHang != null &&  p.isXoa!=true).ToList();
                        List<string> jsonstr = new List<string>();
                        string Nhom = (string)null;
                        while (datas.Count() > 1000)
                        {
                            var temp = datas.Take(1000);
                            Nhom = new JavaScriptSerializer().Serialize(temp);
                            jsonstr.Add(Nhom);
                            datas.RemoveRange(0, 1000);
                        } 
                        if (datas.Count() <= 1000 && datas.Count()>0)
                        {
                            Nhom = new JavaScriptSerializer().Serialize(datas);
                            jsonstr.Add(Nhom);
                        }
                        if (jsonstr.Count() > 0)
                        {
                            #region Đồng bộ phiếu
                            foreach (var jsons in jsonstr)
                            {
                                var result = cn.PostRespone(cn.CreateLink(linkPost), token, jsons);
                                if (result.Result)
                                {
                                    JavaScriptSerializer js = new JavaScriptSerializer();
                                    List<PSPatient> datares = js.Deserialize<List<PSPatient>>(jsons);
                                    var data = db.PSPatients.Where(s => (from d in datares select d.MaBenhNhan).Contains(s.MaBenhNhan));
                                    data.ToList().ForEach(c => c.isDongBo = true);
                                    db.SubmitChanges();
                                    #region Cập nhật phiếu lỗi
                                    string json = result.ErorrResult;
                                    JavaScriptSerializer jss = new JavaScriptSerializer();
                                    List<String> psl = jss.Deserialize<List<String>>(json);
                                    if (psl != null)
                                    {
                                        if (psl.Count > 0)
                                        {
                                            res.StringError = "Danh sách phiếu Patient lỗi: \r\n ";
                                            foreach (var lst in psl)
                                            {
                                                PSResposeSync sn = cn.CutString(lst);
                                                if (sn != null)
                                                {
                                                    var ds = db.PSPatients.FirstOrDefault(p => p.MaKhachHang == sn.Code);
                                                    if (ds != null)
                                                    {
                                                        ds.isDongBo = false;
                                                        res.StringError = res.StringError + sn.Code + ": " + sn.Error + ".\r\n";
                                                    }

                                                }
                                            }
                                            db.SubmitChanges();
                                            res.Result = false;
                                        }
                                    }
                                    #endregion

                                }
                                else
                                {
                                    res.Result = false;
                                    res.StringError = "Đồng bộ phiếu Patient lỗi - Kiểm tra kết nội mạng!\r\n";
                                }

                            }
                            #endregion
                        }
                        if (String.IsNullOrEmpty(res.StringError))
                        {
                            res.Result = true;
                        }
                        else
                        {
                            res.Result = false;
                        }

                    }
                    else
                    {
                        res.Result = true;

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