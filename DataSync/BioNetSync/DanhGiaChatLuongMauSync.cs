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
                        string jsonstr = new JavaScriptSerializer().Serialize(datas);
                        var result = cn.PostRespone(cn.CreateLink(linkPostCTDanhGiaChatLuongMau), token, jsonstr);
                        if (result.Result)
                        {
                            foreach (var data in datas)
                            {
                                data.isDongBo = true;
                            }
                            db.SubmitChanges();
                            string json = result.ErorrResult;
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            List<String> psl = jss.Deserialize<List<String>>(json);
                            if (psl != null)
                            {
                                if(psl.Count>0)
                                {
                                    res.StringError = "Danh sách phiếu chi tiết đánh giá chất lượng mẫu lỗi: \r\n ";
                                    foreach (var lst in psl)
                                    {
                                        PSResposeSync sn = cn.CutString(lst);
                                        if (sn != null)
                                        {
                                            var ds = db.PSChiTietDanhGiaChatLuongs.FirstOrDefault(p => p.IDPhieu == sn.Code);
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
                               
                            else
                            {
                                res.Result = true;
                                res.StringError = "Đồng bộ chi tiết đánh giá chất lượng mẫu lỗi thành công!";
                            }
                        }
                        else
                        {
                            res.Result = false;
                            res.StringError = "Đồng bộ chi tiết đánh giá chất lượng mẫu lỗi - Kiểm tra kết nội mạng!\r\n";
                        }

                    }
                }
                else
                {
                    res.Result = false;
                    res.StringError = "Đồng bộ chi tiết đánh giá chất lượng mẫu lỗi - Kiểm tra kết nội mạng!\r\n";
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
