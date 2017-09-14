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


        public static PsReponse UpdateChiDinh(PSXN_KetQua ketqua)
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
                        foreach (var data in datas)
                        {
                            XN_KetQuaViewModel des = new XN_KetQuaViewModel();
                            cn.ConvertObjectToObject(data, des);
                            des.lstKetQuaChiTiet = new List<XN_KetQua_ChiTietViewModel>();
                            foreach (var chitiet in data.PSXN_KetQua_ChiTiets.ToList())
                            {
                                XN_KetQua_ChiTietViewModel term = new XN_KetQua_ChiTietViewModel();
                                cn.ConvertObjectToObject(chitiet, term);
                                des.lstKetQuaChiTiet.Add(term);
                            }
                            string jsonstr = new JavaScriptSerializer().Serialize(data);
                            var result = cn.PostRespone(cn.CreateLink(linkPost), token, jsonstr);
                            if (result.Result)
                            {
                                res.StringError += "Dữ liệu kết quả " + data.MaKetQua + " đã được đồng bộ lên tổng cục \r\n";

                                var resupdate = UpdateChiDinh(data);
                                if (!resupdate.Result)
                                {
                                    res.StringError += "Dữ liệu kết quả " + data.MaKetQua + " chưa được cập nhật \r\n";
                                }
                            }
                            else
                            {
                                res.Result = false;
                                res.StringError += "Dữ liệu kết quả " + data.MaKetQua + " chưa được đồng bộ lên tổng cục \r\n";
                            }
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

