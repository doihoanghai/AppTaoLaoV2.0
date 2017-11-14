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
    public class ChiDinhSync
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
                var dv = db.PSChiDinhDichVus.FirstOrDefault(p => p.MaPhieu == cddv.MaPhieu && p.MaChiDinh == cddv.MaChiDinh);
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
                        var datas = db.PSChiDinhDichVus.Where(x => x.isDongBo == false).ToList();
                        List<ChiDinhDichVuViewModel> de = new List<ChiDinhDichVuViewModel>();
                        foreach(var data in datas)
                        {
                            ChiDinhDichVuViewModel chidinhVM = new ChiDinhDichVuViewModel();
                           cn.ConvertObjectToObject(data, chidinhVM);
                            chidinhVM.listCDDVCTVM = new List<ChiDinhDichVuChiTietViewModel>();
                            foreach(var cdct in data.PSChiDinhDichVuChiTiets)
                            {
                                ChiDinhDichVuChiTietViewModel term = new ChiDinhDichVuChiTietViewModel();
                                var t = cn.ConvertObjectToObject(cdct, term);
                                chidinhVM.listCDDVCTVM.Add((ChiDinhDichVuChiTietViewModel)t);
                                cdct.isDongBo = true;
                            }
                            de.Add(chidinhVM);
                            data.isDongBo = true;
                        }
                        string jsonstr = new JavaScriptSerializer().Serialize(de);
                        var result = cn.PostRespone(cn.CreateLink(linkPostChiDinh), token, jsonstr);
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
                                    res.StringError = "Danh sách phiếu chỉ định dịch vũ lỗi: \r\n ";
                                    foreach (var lst in psl)
                                    {
                                        PSResposeSync sn = cn.CutString(lst);
                                        if (sn != null)
                                        {
                                            var ds = db.PSChiDinhDichVus.FirstOrDefault(p => p.MaPhieu == sn.Code);
                                            if (ds != null)
                                            {
                                                var dct = db.PSChiDinhDichVuChiTiets.Where(p => p.MaPhieu == sn.Code).ToList();
                                                foreach (var dcts in dct)
                                                {
                                                    dcts.isDongBo = false;
                                                }
                                                ds.isDongBo = false;
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
                                res.StringError = "Đồng bộ phiếu chỉ định dịch vũ thành công!";
                            }
                        }
                        else
                        {
                            res.Result = false;
                            res.StringError = "Đồng bộ phiếu chỉ định dịch vũ - Kiểm tra kết nội mạng!\r\n";
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
