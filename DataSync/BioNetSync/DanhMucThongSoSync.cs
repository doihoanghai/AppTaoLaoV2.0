using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
    public class DanhMucThongSoSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkGetDanhMucThongSo = "/api/thongsoxetnghiem/getallThongSo";
        public static PsReponse GetDMThongSo()
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
                            List<PSDanhMucThongSoXN> CLuong = jss.Deserialize<List<PSDanhMucThongSoXN>>(json);
                            if (CLuong.Count > 0)
                            {
                                foreach (var cl in CLuong)
                                {
                                    cl.TenThongSo = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cl.TenThongSo));
                                    cl.DonViTinh = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cl.DonViTinh));
                                }
                                UpdateDMThongSo(CLuong);
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
                res.StringError =  ex.Message;
            }
            if (res.Result == false)
            {
                res.StringError = "Lỗi đồng bộ danh mục thông số -" + res.StringError;
            }
            return res;
        }
        public static PsReponse UpdateDMThongSo(List<PSDanhMucThongSoXN> Clm)
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
                    var kyt = db.PSDanhMucThongSoXNs.FirstOrDefault(p => p.IDThongSoXN == cl.IDThongSoXN);
                    if (kyt != null)
                    {

                        kyt.DonViTinh = cl.DonViTinh;
                        kyt.MaNhom = kyt.MaNhom;
                        kyt.Stt = cl.Stt;
                        kyt.TenThongSo = cl.TenThongSo;
                        db.SubmitChanges();
                    }
                    else
                    {
                        PSDanhMucThongSoXN kyth = new PSDanhMucThongSoXN();
                        kyth.DonViTinh = cl.DonViTinh;
                        kyth.GiaTri = cl.GiaTri;
                        kyth.GiaTriMacDinh = cl.GiaTriMacDinh;
                        kyth.GiaTriMaxNam = cl.GiaTriMaxNam;
                        kyth.GiaTriMaxNu = cl.GiaTriMaxNu;
                        kyth.GiaTriMinNam = cl.GiaTriMinNam;
                        kyth.GiaTriMinNu = cl.GiaTriMinNu;
                        kyth.GiaTriTrungBinhNam = cl.GiaTriTrungBinhNam;
                        kyth.GiaTriTrungBinhNu = cl.GiaTriTrungBinhNu;
                        kyth.MaDonViTinh = cl.MaDonViTinh;
                        kyth.MaNhom = cl.MaNhom;
                        kyth.Stt = cl.Stt;
                        kyth.TenThongSo = cl.TenThongSo;
                        kyth.IDThongSoXN = cl.IDThongSoXN;
                        db.PSDanhMucThongSoXNs.InsertOnSubmit(kyth);
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
