using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
    public class DanhGiaChatLuongMauSync
    {
        private static BioNetDBContextDataContext db = null;
        
        private static string linkPostCTDanhGiaChatLuongMau = "/api/danhgiachatluong/AddUpChiTiet";
        public static PsReponse UpdateCTDanhGiaChatLuongMau(List<PSChiTietDanhGiaChatLuong> lstpsl)
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
                    var psldb = db.PSChiTietDanhGiaChatLuongs.FirstOrDefault(p => p.IDPhieu == psl.IDPhieu);
                    if (psldb != null)
                    {
                        var term = psldb.IDMapsLyDoKhongDat;
                        cn.ConvertObjectToObject(psl, psldb);
                        psldb.IDMapsLyDoKhongDat = term;
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

        public static PsReponse PostCTDanhGiaChatLuongMau()
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
                        var datas = db.PSChiTietDanhGiaChatLuongs.Where(p => p.isDongBo == false);
                        foreach (var data in datas)
                        {
                            string jsonstr = new JavaScriptSerializer().Serialize(data);
                            var result = cn.PostRespone(cn.CreateLink(linkPostCTDanhGiaChatLuongMau), token, jsonstr);
                            if (result.Result)
                            {
                                res.StringError += "Dữ liệu phiếu" + data.IDPhieu + " đã được đồng bộ lên tổng cục \r\n";
                                List<PSChiTietDanhGiaChatLuong> lstpsl = new List<PSChiTietDanhGiaChatLuong>();
                                data.isDongBo = true;
                                lstpsl.Add(data);
                                var resupdate = UpdateCTDanhGiaChatLuongMau(lstpsl);
                                if (!resupdate.Result)
                                {
                                    res.Result = false;
                                    res.StringError += "Dữ liệu phiếu " + data.IDPhieu + " chưa được cập nhật \r\n";
                                }
                                else
                                {
                                    res.Result = true;
                                }
                            }
                            else
                            {
                                res.Result = false;
                                res.StringError += "Dữ liệu phiếu " + data.IDPhieu + " chưa được đồng bộ lên tổng cục \r\n";
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
