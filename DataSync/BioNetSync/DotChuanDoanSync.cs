using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
    public class DotChuanDoanSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkPost = "/api/dotchuandoan/AddUppFromApp";


        public static PsReponse UpdateDotChuanDoan(PSDotChuanDoan dcd)
        {
            PsReponse res = new PsReponse();

            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSDotChuanDoans.FirstOrDefault(p => p.MaBenhNhan == dcd.MaBenhNhan && p.MaKhachHang == dcd.MaKhachHang);
                if (dv != null)
                {
                    dv.isDongBo = true;
                    db.SubmitChanges();
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
        public static PsReponse PostDotChuanDoan()
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
                    if (!String.IsNullOrEmpty(token))
                    {
                        var datas = db.PSDotChuanDoans.Where(x => x.isDongBo !=true && x.isXoa!=true).ToList();
                        datas.ToList().ForEach(c => c.PSBenhNhanNguyCoCao = null);
                        List<string> jsonstr = new List<string>();
                        string Nhom = (string)null;
                        while (datas.Count() > 1000)
                        {
                            var temp = datas.Take(1000);
                            Nhom = new JavaScriptSerializer().Serialize(temp);
                            jsonstr.Add(Nhom);
                            datas.RemoveRange(0, 1000);
                        }
                        if (datas.Count() <= 1000 && datas.Count() > 0)
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
                                    List<PSDotChuanDoan> datares = js.Deserialize<List<PSDotChuanDoan>>(jsons);
                                    var data = db.PSDotChuanDoans.Where(s => (from d in datares select d.MaDotChuanDoan).Contains(s.MaDotChuanDoan));
                                    data.ToList().ForEach(c => c.isDongBo = true);
                                    db.SubmitChanges();

                                    string json = result.ErorrResult;
                                    JavaScriptSerializer jss = new JavaScriptSerializer();
                                    List<String> psl = jss.Deserialize<List<String>>(json);
                                    if (psl != null)
                                    {
                                        if (psl.Count > 0)
                                        {
                                            res.StringError = "Danh sách phiếu đợt chấn đoán lỗi: \r\n ";
                                            foreach (var lst in psl)
                                            {
                                                PSResposeSync sn = cn.CutString(lst);
                                                if (sn != null)
                                                {
                                                    var ds = db.PSDotChuanDoans.FirstOrDefault(p => p.MaDotChuanDoan == sn.Code);
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
                                        res.StringError = "Đồng bộ phiếu phiếu đợt chấn đoán lỗi thành công!";
                                    }
                                }
                                else
                                {
                                    res.Result = false;
                                    res.StringError = "Đồng bộ phiếu đợt chấn đoán lỗi - Kiểm tra kết nội mạng!\r\n";
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
                                
                }
                else
                {
                    res.Result = false;
                    res.StringError = "Đồng bộ phiếu đợt chấn đoán lỗi - Kiểm tra kết nội mạng!\r\n";
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError += DateTime.Now.ToString() + "Lỗi khi đồng bộ dữ liệu danh sách  phiếu đợt chấn đoán  Lên Tổng Cục \r\n " + ex.Message;

            }
            return res;
        }
    }
}

