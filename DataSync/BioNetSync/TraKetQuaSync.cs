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
                        var datas = db.PSXN_TraKetQuas.Where(x => x.isDongBo == false);
                        List<XN_TraKetQuaViewModel> de = new List<XN_TraKetQuaViewModel>();                       
                        foreach (var data in datas)
                        {
                            XN_TraKetQuaViewModel des = new XN_TraKetQuaViewModel();
                            cn.ConvertObjectToObject(data, des);
                            des.lstTraKetQuaChiTiet = new List<XN_TraKQ_ChiTietViewModel>();
                            var cts = db.PSXN_TraKQ_ChiTiets.Where(x => x.MaPhieu == data.MaPhieu && x.MaTiepNhan == data.MaTiepNhan);
                            foreach (var chitiet in cts)
                            {
                                XN_TraKQ_ChiTietViewModel term = new XN_TraKQ_ChiTietViewModel();
                                var t = cn.ConvertObjectToObject(chitiet, term);
                                des.lstTraKetQuaChiTiet.Add((XN_TraKQ_ChiTietViewModel)t);
                                chitiet.isDongBo = true;
                            }
                            data.isDongBo = true;
                            de.Add(des);                         
                        }
                        string jsonstr = new JavaScriptSerializer().Serialize(de);
                        var result = cn.PostRespone(cn.CreateLink(linkPost), token, jsonstr);
                        if (result.Result)
                        {
                            db.SubmitChanges();
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
                                res.Result = true;
                                res.StringError = "Đồng bộ phiếu tiếp nhận thành công!";
                            }
                        }
                        else
                        {
                            res.Result = false;
                            res.StringError = "Đồng bộ phiếu tiếp nhận - Kiểm tra kết nội mạng!\r\n";
                        }
                    }
                }
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

