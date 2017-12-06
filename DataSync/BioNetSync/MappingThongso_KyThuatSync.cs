using BioNetModel;
using BioNetModel.APIViewModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
   
   public  class MappingKyThuat_DichVuSync
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
                            List<MapsXN_ThongSoSync> CLuong = jss.Deserialize<List<MapsXN_ThongSoSync>>(json);
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
        public static PsReponse UpdateDMMap_KyThuat_DichVu(List<MapsXN_ThongSoSync> Clm)
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
                    var kyt = db.PSMapsXN_ThongSos.FirstOrDefault(p => p.IDThongSo== cl.IDThongSoXN && p.IDKyThuatXN == cl.IDKyThuatXN );
                    if (kyt != null)
                    {
                        kyt.IDKyThuatXN = cl.IDKyThuatXN;
                        kyt.IDThongSo = cl.IDThongSoXN;
                        kyt.TenKyThuat = cl.TenThongSo != null ? Encoding.UTF8.GetString(Encoding.Default.GetBytes(cl.TenThongSo)) : null;
                        db.SubmitChanges();
                    }
                    else
                    {
                        PSMapsXN_ThongSo kyth = new PSMapsXN_ThongSo();
                        kyth.IDKyThuatXN = cl.IDKyThuatXN;
                        kyth.IDThongSo = cl.IDThongSoXN;
                        kyth.TenKyThuat = cl.TenThongSo != null?Encoding.UTF8.GetString(Encoding.Default.GetBytes(cl.TenThongSo)):null;
                        db.PSMapsXN_ThongSos.InsertOnSubmit(kyth);
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
