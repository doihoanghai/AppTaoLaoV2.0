using Bionet.API.Models;
using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
    public class TraKetQuaSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkPost = "/api/xntraTraKetQua/AddUpFromApp";


        public static PsReponse UpdateKetQua(PSXN_TraKetQua ketqua)
        {
            PsReponse res = new PsReponse();

            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSXN_TraKetQuas.FirstOrDefault(p => p.MaPhieu == ketqua.MaPhieu);
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

        public static PsReponse UpdateKetQuaChiTiet(PSXN_TraKQ_ChiTiet ketquachitiet)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSXN_TraKQ_ChiTiets.FirstOrDefault(p => p.MaTiepNhan == ketquachitiet.MaTiepNhan && p.IDKyThuat == ketquachitiet.IDKyThuat);
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
        public static PsReponse PostKetQua()
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
                        var datas = db.PSXN_TraKetQuas.Where(x => x.isDongBo != true && x.isTraKQ == true && x.isDaDuyetKQ == true && x.isXoa!=true).OrderBy(x=>x.RowIDXN_TraKetQua ).ToList();
                        List<XN_TraKetQuaViewModel> de = new List<XN_TraKetQuaViewModel>();
                        List<string> jsonstr = new List<string>();
                        string Nhom = (string)null;

                        foreach (var data in datas)
                        {
                            XN_TraKetQuaViewModel des = new XN_TraKetQuaViewModel();
                            cn.ConvertObjectToObject(data, des);             
                            des.lstTraKetQuaChiTiet = new List<XN_TraKQ_ChiTietViewModel>();                           
                            foreach (var chitiet in data.PSXN_TraKQ_ChiTiets)
                            {
                                XN_TraKQ_ChiTietViewModel term = new XN_TraKQ_ChiTietViewModel();
                                 var t = cn.ConvertObjectToObject(chitiet, term);
                                des.lstTraKetQuaChiTiet.Add((XN_TraKQ_ChiTietViewModel)t);
                            }
                            de.Add(des);
                        }
                        while (de.Count() > 200)
                        {
                            var temp = de.Take(200);
                            Nhom = new JavaScriptSerializer().Serialize(temp);
                            jsonstr.Add(Nhom);
                            de.RemoveRange(0, 200);
                        } 
                        if (de.Count() <= 200 && de.Count()>0)
                        {
                            Nhom = new JavaScriptSerializer().Serialize(de);
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
                                    List<PSXN_TraKetQua> datares = js.Deserialize<List<PSXN_TraKetQua>>(jsons);
                                    var data = db.PSXN_TraKetQuas.Where(s => (from d in datares select d.MaPhieu).Contains(s.MaPhieu)).ToList();
                                    var datact = db.PSXN_TraKQ_ChiTiets.Where(s => (from d in datares select d.MaPhieu).Contains(s.MaPhieu)).ToList();
                                    data.ToList().ForEach(c => c.isDongBo = true);
                                    datact.ToList().ForEach(c => c.isDongBo = true);
                                    db.SubmitChanges();
                                    if (result.ErorrResult != "[]")
                                    {
                                        string json = result.ErorrResult;
                                        JavaScriptSerializer jss = new JavaScriptSerializer();
                                        List<String> psl = jss.Deserialize<List<String>>(json);
                                        if (psl != null)
                                        {
                                            if (psl.Count > 0)
                                            {
                                                res.StringError = "Danh sách phiếu tiếp nhận lỗi: \r\n ";
                                                foreach (var lst in psl)
                                                {
                                                    PSResposeSync sn = cn.CutString(lst);
                                                    if (sn != null)
                                                    {
                                                        var ds = db.PSXN_TraKetQuas.FirstOrDefault(p => p.MaPhieu == sn.Code);
                                                        if (ds != null)
                                                        {
                                                            ds.isDongBo = false;
                                                            var ct = db.PSXN_TraKQ_ChiTiets.Where(p => p.MaPhieu == sn.Code).ToList();
                                                            foreach (var c in ct)
                                                            {
                                                                c.isDongBo = false;
                                                            }
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
                                            res.Result = false;
                                            res.StringError = "Đồng bộ phiếu trả kết quả - Kiểm tra kết nội mạng!\r\n";
                                        }

                                    }

                                }

                            }
                            #endregion
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
                        res.StringError = "Đồng bộ phiếu tiếp nhận - Kiểm tra kết nội mạng hoặc tài khoản đồng b!\r\n";
                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError += DateTime.Now.ToString() + "Lỗi khi đồng bộ dữ liệu danh sách bệnh nhân nguy cơ cao Lên Tổng Cục \r\n " + ex.Message;

            }
            return res;
        }
    }
}

