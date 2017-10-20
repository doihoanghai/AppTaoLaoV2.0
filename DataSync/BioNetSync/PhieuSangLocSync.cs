using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;


namespace DataSync.BioNetSync
{
    public class PhieuSangLocSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkGetPhieuSangLoc = "/api/phieusangloc/getallFromApp?keyword=&page=0&pagesize=20";
        private static string linkPostPhieuSangLoc = "/api/phieusangloc/AddUpFromApp";

        public static PsReponse GetPhieuSangLoc()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetPhieuSangLoc), token);

                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();

                             ObjectModel.RootObjectAPI  psl = jss.Deserialize<ObjectModel.RootObjectAPI>(json);
                            //List<PSPatient> patient = jss.Deserialize<List<PSPatient>>(json);
                            List<PSPhieuSangLoc> lstpsl = new List<PSPhieuSangLoc>();
                            if (psl.TotalCount > 0)
                            {
                                foreach(var item in psl.Items)
                                {
                                    PSPhieuSangLoc term = new PSPhieuSangLoc();
                                   
                                    term = cn.CovertDynamicToObjectModel(item, term);
                                    lstpsl.Add(term);
                                }
                                //UpdatePatient(patient); 
                                var resUpdate = UpdatePhieuSangLoc(lstpsl,1);
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu Danh Mục Mapping Kỹ Thuật - Dịch Vụ từ server \r\n " + ex.Message;

            }
            return res;
        }
        public static PsReponse UpdatePhieuSangLoc(List<PSPhieuSangLoc> lstpsl,int luachon)
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
                    var psldb = db.PSPhieuSangLocs.FirstOrDefault(p => p.IDPhieu == psl.IDPhieu);
                    if (psldb != null)
                    {
                        var term = psldb.RowIDPhieu;
                        cn.ConvertObjectToObject(psl, psldb);
                        psldb.RowIDPhieu = term;
                        if (luachon==1)
                        {
                            if (psl.DiaChiLayMau != null)
                            {
                                psldb.DiaChiLayMau = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.DiaChiLayMau));
                            }
                            if (psl.NoiLayMau != null)
                            {
                                psldb.NoiLayMau = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.NoiLayMau));
                            }
                            if (psl.TenNhanVienLayMau != null)
                            {
                                psldb.TenNhanVienLayMau = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.TenNhanVienLayMau));
                            }                        
                        }
                        else if(luachon==2)
                        {}                      
                            db.SubmitChanges();
                    }
                    else
                    {
                        PSPhieuSangLoc newpsl = new PSPhieuSangLoc();
                        newpsl = psl;
                        if(psl.DiaChiLayMau!=null)
                        {
                            newpsl.DiaChiLayMau = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.DiaChiLayMau));
                        }
                        if (psl.NoiLayMau != null)
                        {
                            newpsl.NoiLayMau = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.NoiLayMau));
                        }
                        if (psl.TenNhanVienLayMau != null)
                        {
                            newpsl.TenNhanVienLayMau = Encoding.UTF8.GetString(Encoding.Default.GetBytes(psl.TenNhanVienLayMau));
                        }  
                        newpsl.RowIDPhieu = 0;
                        newpsl.isDongBo = true;
                        db.PSPhieuSangLocs.InsertOnSubmit(newpsl);
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

        public static PsReponse PostPhieuSangLoc()
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
                        var datas = db.PSPhieuSangLocs.Where(p => p.isDongBo == false);
                        foreach (var data in datas)
                        {
                            string jsonstr = new JavaScriptSerializer().Serialize(data);
                            var result = cn.PostRespone(cn.CreateLink(linkPostPhieuSangLoc), token, jsonstr);
                            if (result.Result)
                            {
                                res.StringError += "Dữ liệu đơn vị " + data.IDCoSo + " đã được đồng bộ lên tổng cục \r\n";
                                List<PSPhieuSangLoc> lstpsl = new List<PSPhieuSangLoc>();
                                //PSPhieuSangLoc term = new PSPhieuSangLoc();
                                data.isDongBo = true;
                                //cn.ConvertObjectToObject(data, term);
                               
                              
                                lstpsl.Add(data);
                                var resupdate = UpdatePhieuSangLoc(lstpsl,2);

                                if (resupdate.Result==true)
                                {
                                    res.Result = true;
                                    res.StringError += "Dữ liệu dơn vị " + data.IDCoSo + " đã được cập nhật thành công \r\n";
                                   
                                }
                                else
                                {
                                    res.Result = false;
                                    res.StringError += "Dữ liệu đơn vị " + data.IDCoSo + " chưa được cập nhật \r\n";
                                }
                            }
                            else
                            {
                                res.Result = false;
                                res.StringError += "Dữ liệu đơn vị " + data.IDCoSo + " chưa được đồng bộ lên tổng cục \r\n";
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

        //public static PsReponse UpdatePatient(List<PSPatient> lstPatient) {
        //    PsReponse res = new PsReponse();

        //    try
        //    {
        //        ProcessDataSync cn = new ProcessDataSync();
        //        db = cn.db;
        //        var account = db.PSPatients.FirstOrDefault();
        //        db.Connection.Open();
        //        db.Transaction = db.Connection.BeginTransaction();
        //        foreach (var patient in lstPatient)
        //        {
        //            var patientdb = db.PSPatients.FirstOrDefault(p => p.MaBenhNhan == patient.MaBenhNhan && p.MaKhachHang == patient.MaKhachHang);
        //            if (patientdb != null)
        //            {
        //                var term = patientdb.RowIDBenhNhan;
        //                patientdb = patient;
        //                patientdb.RowIDBenhNhan = term;
        //                db.SubmitChanges();

        //            }
        //            else
        //            {
        //                PSPatient newpatient = new PSPatient();
        //                newpatient = patient;
        //                db.PSPatients.InsertOnSubmit(newpatient);
        //                db.SubmitChanges();
        //            }

        //        }

        //        db.Transaction.Commit();
        //        db.Connection.Close();
        //        res.Result = true;


        //    }
        //    catch (Exception ex)
        //    {
        //        db.Transaction.Rollback();
        //        db.Connection.Close();
        //        res.Result = false;
        //        res.StringError = ex.ToString();
        //    }
        //    return res;
        //}
    }
}