using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
   
    class MappingKyThuat_DichVuSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkGetDanhMucThongSo = "/api/mapsxnthongso/getall";
        public static PsReponse GetDMMap_ThongSo_KyThuat()
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
                        var result = cn.GetRespone(cn.CreateLink(linkGetDanhMucThongSo), token);
                        if (result.Result)
                        {
                            string json = result.ValueResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            List<PSMapsXN_DichVu> CLuong = jss.Deserialize<List<PSMapsXN_DichVu>>(json);
                            if (CLuong.Count > 0)
                            {

                                UpdateDMMap_KyThuat_DichVu(CLuong);
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
                res.StringError = DateTime.Now.ToString() + "Lỗi khi get dữ liệu Danh Mục Mapping Thông Số - Kỹ Thuật từ server \r\n " + ex.Message;
            }
            return res;
        }
        public static PsReponse UpdateDMMap_KyThuat_DichVu(List<PSMapsXN_DichVu> Clm)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                foreach (var cl in Clm)
                {
                    var kyt = db.PSMapsXN_DichVus.FirstOrDefault(p => p.IDDichVu == cl.IDDichVu && p.IDKyThuatXN == cl.IDKyThuatXN);
                    if (kyt != null)
                    {

                    }
                    else
                    {
                        PSMapsXN_DichVu kyth = new PSMapsXN_DichVu();
                        kyth.IDKyThuatXN = cl.IDKyThuatXN;
                        kyth.IDDichVu = cl.IDDichVu;
                        db.PSMapsXN_DichVus.InsertOnSubmit(kyth);
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
