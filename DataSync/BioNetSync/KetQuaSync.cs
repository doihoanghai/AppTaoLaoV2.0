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
                        var datas = db.PSXN_KetQuas.Where(x => x.isDongBo != true && x.isXoa!= true && x.isCoKQ==true).OrderBy(x => x.RowIDKetQua).ToList();

                        List<XN_KetQuaViewModel> de = new List<XN_KetQuaViewModel>();
                        List<string> jsonstr = new List<string>();
                        string Nhom = (string)null;
                        foreach (var data in datas)
                        {
                            XN_KetQuaViewModel des = new XN_KetQuaViewModel();
                            cn.ConvertObjectToObject(data, des);
                            des.lstKetQuaChiTiet = new List<XN_KetQua_ChiTietViewModel>();
                            foreach (var chitiet in data.PSXN_KetQua_ChiTiets)
                            {
                                XN_KetQua_ChiTietViewModel term = new XN_KetQua_ChiTietViewModel();
                                var t = cn.ConvertObjectToObject(chitiet, term);
                                des.lstKetQuaChiTiet.Add((XN_KetQua_ChiTietViewModel)t);
                            }
                            de.Add(des);
                        }
                       while (de.Count() > 125)
                            {
                                var temp = de.Take(125);
                                Nhom = new JavaScriptSerializer().Serialize(de);
                                jsonstr.Add(Nhom);
                                de.RemoveRange(0, 125);
                            } 
                            if (de.Count() <= 125 && de.Count()>0)
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
                                    List<PSXN_KetQua> datares = js.Deserialize<List<PSXN_KetQua>>(jsons);
                                    var data = db.PSXN_KetQuas.Where(s => (from d in datares select d.MaKetQua).Contains(s.MaKetQua)).ToList();
                                    var datact = db.PSXN_KetQua_ChiTiets.Where(s => (from d in datares select d.MaXetNghiem).Contains(s.MaXetNghiem)).ToList();
                                    data.ToList().ForEach(c => c.isDongBo = true);
                                    datact.ToList().ForEach(c => c.isDongBo = true);
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
                                }
                                else
                                {
                                    res.Result = false;
                                    res.StringError = "Đồng bộ phiếu kết quả lỗi- Kiểm tra kết nối mạng!\r\n";
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
                    else
                    {
                        res.Result = false;
                        res.StringError = "Đồng bộ phiếu kết quả lỗi- Kiểm tra kết nối mạng hoặc tài khoản đồng bộ!\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError += DateTime.Now.ToString() + "Lỗi khi đồng bộ dữ liệu danh sách phiếu kết quả \r\n " + ex.Message;

            }
            return res;
        }


    }
}

