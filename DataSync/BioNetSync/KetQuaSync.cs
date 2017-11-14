using Bionet.API.Models;
using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DataSync.BioNetSync
{
    public class KetQuaSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkPost = "/api/xnketqua/AddUpFromApp";
        private static string linkPDF = "/api/patient/pushlistfilekq";


        public static PsReponse UpdateKetQua(PSXN_KetQua ketqua)
        {
            PsReponse res = new PsReponse();

            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSXN_KetQuas.FirstOrDefault(p => p.MaKetQua == ketqua.MaKetQua);
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
        public static PsReponse UpdateKetQuaChiTiet(PSXN_KetQua_ChiTiet ketquachitiet)
        {
            PsReponse res = new PsReponse();
            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSXN_KetQua_ChiTiets.FirstOrDefault(p => p.MaXetNghiem == ketquachitiet.MaXetNghiem && p.MaKyThuat == ketquachitiet.MaKyThuat);
                if(dv!=null)
                {
                    dv.isDongBo = true;
                    db.SubmitChanges();
                }
                db.Transaction.Commit();
                db.Connection.Close();
                res.Result = true;

            }
            catch(Exception ex)
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
                        var datas = db.PSXN_KetQuas.Where(x => x.isDongBo == false);
                       
                        List<XN_KetQuaViewModel> de = new List<XN_KetQuaViewModel>();
                        foreach (var data in datas)
                        {
                            XN_KetQuaViewModel des = new XN_KetQuaViewModel();
                            cn.ConvertObjectToObject(data, des);
                            des.lstKetQuaChiTiet = new List<XN_KetQua_ChiTietViewModel>();
                            var cts = db.PSXN_KetQua_ChiTiets.Where(x => x.MaKQ == data.MaKetQua && x.MaXetNghiem == data.MaXetNghiem);
                            foreach (var chitiet in cts)
                            {
                                XN_KetQua_ChiTietViewModel term = new XN_KetQua_ChiTietViewModel();
                                var t = cn.ConvertObjectToObject(chitiet, term);
                                des.lstKetQuaChiTiet.Add((XN_KetQua_ChiTietViewModel)t);
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
                                    res.StringError = "Danh sách phiếu kết quả lỗi \r\n ";
                                foreach (var lst in psl)
                                {
                                   
                                      
                                            PSResposeSync sn = cn.CutString(lst);

                                        if (sn != null)
                                        {     
                                            var ds = db.PSXN_KetQuas.FirstOrDefault(p => p.MaKetQua == sn.Code);
                                            if (ds != null)
                                            {
                                                ds.isDongBo = false;
                                                var ct = db.PSXN_KetQua_ChiTiets.Where(p => p.MaKQ == ds.MaKetQua && p.MaXetNghiem == ds.MaXetNghiem).ToList();
                                                foreach (var c in ct)
                                                {
                                                    c.isDongBo = false;
                                                }
                                                res.StringError = res.StringError + sn.Code + ": " + sn.Error + ".\r\n";
                                            }
                                        }

                                    }
                                }
                                db.SubmitChanges();
                                res.Result = false;
                            }
                            else
                            {
                                res.Result = true;
                                res.StringError = "Đồng bộ phiếu kết quả thành công!";
                            }
                        }
                        else
                        {
                            res.Result = false;
                            res.StringError = "Đồng bộ phiếu kết quả lỗi- Kiểm tra kết nội mạng!\r\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError += DateTime.Now.ToString() + "Lỗi khi đồng bộ dữ liệu danh sách phiếu kết quả Lên Tổng Cục \r\n " + ex.Message;

            }
            return res;
        }
       
       
    }
}

