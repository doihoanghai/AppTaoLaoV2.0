using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DataSync.BioNetSync
{
   public  class BenhNhanNguyCoCaoSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkPost = "/api/benhnhannguycocao/AddUpFromApp";


        public static PsReponse UpdateChiDinh(PSBenhNhanNguyCoCao bnncc)
        {
            PsReponse res = new PsReponse();

            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSBenhNhanNguyCoCaos.FirstOrDefault(p => p.MaBenhNhan == bnncc.MaBenhNhan);
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
        public static PsReponse PostBenhNhanNguyCoCao()
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
                        var datas = db.PSBenhNhanNguyCoCaos.Where(x => x.isDongBo == false);
                        foreach (var data in datas)
                        {
                            foreach (var cicle in data.PSDotChuanDoans.ToList())
                            {
                                cicle.PSBenhNhanNguyCoCao = null;


                                if (cicle.isDongBo != false)
                                {
                                    data.PSDotChuanDoans.Remove(cicle);
                                }
                            }

                            string jsonstr = new JavaScriptSerializer().Serialize(data);
                            var result = cn.PostRespone(cn.CreateLink(linkPost), token, jsonstr);
                            if (result.Result)
                            {
                                res.StringError += "Dữ liệu bệnh nhân " + data.MaBenhNhan + " đã được đồng bộ lên tổng cục \r\n";
                                
                                var resupdate = UpdateChiDinh(data);
                                if (!resupdate.Result)
                                {
                                    res.StringError += "Dữ liệu bệnh nhân " + data.MaBenhNhan + " chưa được cập nhật \r\n";
                                }
                            }
                            else
                            {
                                res.Result = false;
                                res.StringError += "Dữ liệu bệnh nhân " + data.MaBenhNhan + " chưa được đồng bộ lên tổng cục \r\n";
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

