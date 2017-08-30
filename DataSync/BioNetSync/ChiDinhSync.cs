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
    class ChiDinhSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkPostChiDinh = "/api/chidinhdv/AddUpFromApp";


        public static PsReponse UpdateChiDinhChiTiet(PSChiDinhDichVuChiTiet cdct)
        {
            PsReponse res = new PsReponse();
            res.Result = true;

            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSChiDinhDichVuChiTiets.FirstOrDefault(p => p.MaChiDinh == cdct.MaChiDinh && p.MaDichVu == cdct.MaDichVu);
                if(dv == null)
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

        public static PsReponse UpdateChiDinh(PSChiDinhDichVu cddv)
        {
            PsReponse res = new PsReponse();

            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                var dv = db.PSChiDinhDichVus.FirstOrDefault(p => p.MaPhieu == cddv.MaPhieu && p.MaTiepNhan == cddv.MaTiepNhan);
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
        public static PsReponse PostChiDinh()
        {
            PsReponse res = new PsReponse();
            res.Result = true;

            try
            {
                ProcessDataSync cn = new ProcessDataSync();
                db = cn.db;
                var account = db.PSAccount_Syncs.FirstOrDefault();
                if(account != null)
                {
                    string token = cn.GetToken(account.userName, account.passWord);
                    if(!String.IsNullOrEmpty(token))
                    {
                        var datas = db.PSChiDinhDichVus.Where(x => x.isDongBo == false);
                        foreach(var data in datas)
                        {
                            ChiDinhDichVuViewModel chidinhVM = new ChiDinhDichVuViewModel();
                            var datact = cn.ConvertObjectToObject(data, chidinhVM);
                            chidinhVM.listCDDVCTVM = new List<ChiDinhDichVuChiTietViewModel>();
                            foreach(var cdct in data.PSChiDinhDichVuChiTiets)
                            {
                                ChiDinhDichVuChiTietViewModel term = new ChiDinhDichVuChiTietViewModel();
                                var t = cn.ConvertObjectToObject(cdct, term);
                                chidinhVM.listCDDVCTVM.Add((ChiDinhDichVuChiTietViewModel)t);
                            }
                            
                            string jsonstr = new JavaScriptSerializer().Serialize(datact);
                            var result = cn.PostRespone(cn.CreateLink(linkPostChiDinh), token, jsonstr);
                            if (result.Result)
                            {
                                res.StringError += "Dữ liệu đơn vị " + data.MaDonVi + " đã được đồng bộ lên tổng cục \r\n";
                                
                                var resupdate = UpdateChiDinh(data);
                                if (!resupdate.Result)
                                {
                                    res.StringError += "Dữ liệu đơn vị " + data.MaDonVi + " chưa được cập nhật \r\n";
                                }
                            }
                            else
                            {
                                res.Result = false;
                                res.StringError += "Dữ liệu đơn vị " + data.MaDonVi + " chưa được đồng bộ lên tổng cục \r\n";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError += DateTime.Now.ToString() + "Lỗi khi đồng bộ dữ liệu danh sách chỉ định Lên Tổng Cục \r\n " + ex.Message;

            }
            return res;
        }
    }
}
