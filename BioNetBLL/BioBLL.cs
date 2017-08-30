using BioNetDAL;
using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace BioNetBLL
{
    public class BioBLL
    {
        public static bool CheckConnection()
        {
            try {
                var db = new BioDAL();
                return db.CheckConnection();
            }
            catch { return false; }
        }

        public static bool CheckConnection(string servername, string username, string password, string database)
        {
            var db = new BioDAL();
            return db.CheckConnection(servername, username, password, database);
        }

        public static string MyServerName()
        {
            var db = new BioDAL();
            return db.MyServerName();
        }
        public static List<PSPatient> GetDanhSachBenhNhan()
        {
            var db = new BioDAL();
            return db.getListBenhNhan();
        }
        public static DataTable TableServerName()
        {
            var db = new BioDAL();
            return db.TableServerName();
        }

        public static string GetMD5(string str)
        {
            var db = new BioDAL();
            return db.GetMD5(str);
        }

        #region Login
        public static bool CheckLogin(string userName, string passWord)
        {
            var db = new BioDAL();
            return db.CheckLoginUser(userName, passWord);
        }

        public static string GetEmployeeCode(string userName)
        {
            var db = new BioDAL();
            return db.GetEmployeeCode(userName);
        }

        public static List<PSMenuSecurity> ListMenuSecurity(string empCode)
        {
            var db = new BioDAL();
            return db.ListMenuSecurity(empCode);
        }
        #endregion

        #region Phân quyền
        public static List<PsEmployeePosition> GetEmployeeByPosition(int code)
        {
            List<PsEmployeePosition> lstEmployeePosition = new List<PsEmployeePosition>();
            var db = new BioDAL();
            var empPosition = db.GetEmployeeByPosition(code);
            if (empPosition != null)
            {
                return empPosition;
            }
            else return lstEmployeePosition;
        }

        public static bool UpdateMenuSercurity(List<PSMenuSecurity> lstMenuSecurity, string empCode)
        {
            try
            {
                var db = new BioDAL();
                return db.UpdateMenuSercurity(lstMenuSecurity, empCode);
            }
            catch { return false; }
        }

        public static bool UpdateMenuSercurityPosition(List<PSMenuSecurityPosition> lstMenuSecurity, int positionCode)
        {
            try
            {
                var db = new BioDAL();
                return db.UpdateMenuSercurityPosition(lstMenuSecurity, positionCode);
            }
            catch { return false; }
        }

        public static List<PSMenuSecurityPosition> ListMenuSecurity(int empCode)
        {
            var db = new BioDAL();
            return db.ListMenuSecurityByPosition(empCode);
        }

        public static void DeleteItemMenuSercurity(PSMenuSecurity itemMenuSecurity)
        {
            var db = new BioDAL();
            db.DeleteItemMenuSercurity(itemMenuSecurity);
        }

        public static void InsertItemMenuSercurity(PSMenuSecurity itemMenuSecurity)
        {
            var db = new BioDAL();
            db.InsertItemMenuSercurity(itemMenuSecurity);
        }
        #endregion

        #region Nhân viên
        public static List<PSEmployeeGroup> ListEmployeeGroup(int id)
        {
            var db = new BioDAL();
            return db.ListEmployeeGroup(id);
        }

        public static bool CheckExistUser(string username)
        {
            var db = new BioDAL();
            return db.CheckExistUser(username);
        }
        public static bool CheckExistPosition(string positionName, int id)
        {
            var db = new BioDAL();
            return db.CheckExistPosition(positionName, id);
        }
        public static List<PSEmployeePosition> ListEmployeePosition(int id)
        {
            var db = new BioDAL();
            return db.ListEmployeePosition(id);
        }

        public static List<PSEmployee> ListEmployee(string empCode)
        {
            var db = new BioDAL();
            return db.ListEmployee(empCode);
        }

        public static DataTable DTEmployee(string empCode)
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
                dt.Columns.Add(new DataColumn("Sex", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Mobile", typeof(string)));
                dt.Columns.Add(new DataColumn("IDCard", typeof(string)));
                dt.Columns.Add(new DataColumn("Address", typeof(string)));
                dt.Columns.Add(new DataColumn("Birthday", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("PositionCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Username", typeof(string)));
                dt.Columns.Add(new DataColumn("Password", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeGroupID", typeof(Int32)));
                var vlist = db.ListEmployee(empCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.EmployeeCode;
                    dr[2] = lt1.EmployeeName;
                    dr[3] = lt1.Sex;
                    dr[4] = lt1.Mobile;
                    dr[5] = lt1.IDCard;
                    dr[6] = lt1.Address;
                    dr[7] = !string.IsNullOrEmpty(lt1.Birthday.ToString()) ? lt1.Birthday : (object)DBNull.Value;
                    dr[8] = lt1.PositionCode;
                    dr[9] = lt1.Username;
                    dr[10] = "Về mặc định";
                    dr[11] = lt1.EmployeeGroupID;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable DTEmployeePosition()
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("PositionCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("PositionName", typeof(string)));
                dt.Columns.Add(new DataColumn("Level", typeof(Int32)));
                
                var vlist = db.ListEmployeePosition(0);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.PositionCode;
                    dr[1] = lt1.PositionName;
                    dr[2] = lt1.Level;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }
        public static List<PSChiTietGoiDichVuChung> GetListChiTietGoiDichVuChung()
        {
            var db = new BioDAL();
            return db.GetListChiTietGoiDichVuChung();
        }
        public static bool DelEmployeePosition(int postionCode)
        {
            var db = new BioDAL();
            return db.DelEmployeePosition(postionCode);
        }
        public static bool DelEmployee(string empCode)
        {
            var db = new BioDAL();
            return db.DelEmployee(empCode);
        }

        public static bool InsEmployee(PSEmployee emp)
        {
            var db = new BioDAL();
            return db.InsEmployee(emp);
        }
        public static bool InsEmployeePosition(PSEmployeePosition emp)
        {
            var db = new BioDAL();
            return db.InsEmployeePosition(emp);
        }

        public static bool UpdEmployee(PSEmployee emp)
        {
            var db = new BioDAL();
            return db.UpdEmployee(emp);
        }
        public static bool updEmployeePosition(PSEmployeePosition emp)
        {
            var db = new BioDAL();
            return db.UpdEmployeePosition(emp);
        }
        public static bool UpdPassEmployee(string empCode, string pass)
        {
            var db = new BioDAL();
            return db.UpdPassEmployee(empCode, pass);
        }

        public static PSEmployee GetEmployeeByCode(string empCode)
        {
            var db = new BioDAL();
            return db.GetEmployeeByCode(empCode);
        }

        public static PSEmployeePosition GetPositionByCode(int posCode)
        {
            var db = new BioDAL();
            return db.GetPositionByCode(posCode);
        }
        #endregion

        #region DM Đơn vị cơ sở
        public static DataTable GetListDonViCoSo()
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowIDDVCS", typeof(int)));
                dt.Columns.Add(new DataColumn("MaDVCS", typeof(string)));
                dt.Columns.Add(new DataColumn("TenDVCS", typeof(string)));
                dt.Columns.Add(new DataColumn("DiaChiDVCS", typeof(string)));
                dt.Columns.Add(new DataColumn("SDTCS", typeof(string)));
                dt.Columns.Add(new DataColumn("isLocked", typeof(bool)));
                dt.Columns.Add(new DataColumn("Logo", typeof(Binary)));
                dt.Columns.Add(new DataColumn("HeaderReport", typeof(Binary)));
                dt.Columns.Add(new DataColumn("Stt", typeof(int)));
                dt.Columns.Add(new DataColumn("MaChiCuc", typeof(string)));
                dt.Columns.Add(new DataColumn("KieuTraKetQua", typeof(int)));
                dt.Columns.Add(new DataColumn("isDongBo", typeof(bool)));
                dt.Columns.Add(new DataColumn("TenBacSiDaiDien", typeof(string)));

                var vlist = db.GetListDonViCoSo();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowIDDVCS;
                    dr[1] = lt1.MaDVCS;
                    dr[2] = lt1.TenDVCS;
                    dr[3] = lt1.DiaChiDVCS??string.Empty;
                    dr[4] = lt1.SDTCS ?? string.Empty;
                    dr[5] = lt1.isLocked ?? false;
                    dr[6] = lt1.Logo;
                    dr[7] = lt1.HeaderReport;
                    dr[8] = lt1.Stt??1;
                    dr[9] = lt1.MaChiCuc;
                    dr[10] = lt1.KieuTraKetQua??1;
                    dr[11] = lt1.isDongBo??false;
                    dr[12] = lt1.TenBacSiDaiDien ?? string.Empty;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static string GetCodeDonViCoSo(string codeChiCuc)
        {
            var db = new BioDAL();
            return db.GetCodeDonViCoSo(codeChiCuc);
        }

        public static bool CheckExistCodeDVCS(string code)
        {
            var db = new BioDAL();
            return db.CheckExistCodeDVCS(code);
        }

        public static bool InsDonViCS(PSDanhMucDonViCoSo donViCS)
        {
            var db = new BioDAL();
            return db.InsDonViCS(donViCS);
        }

        public static bool InsMultiGoiDichVuCoSo(List<PSDanhMucGoiDichVuTheoDonVi> lstGoiDichVuCoSo)
        {
            var db = new BioDAL();
            return db.InsMultiGoiDichVuCoSo(lstGoiDichVuCoSo);
        }

        public static bool UpdDonViCS(PSDanhMucDonViCoSo donViCS)
        {
            var db = new BioDAL();
            return db.UpdDonViCS(donViCS);
        }

        public static bool DelDonViCS(string idDonViCS)
        {
            var db = new BioDAL();
            return db.DelDonViCS(idDonViCS);
        }

        public static PSDanhMucDonViCoSo GetDonViCoSoById(int rowID)
        {
            var db = new BioDAL();
            return db.GetDonViCoSoById(rowID);
        }
        #endregion

        #region DM Gói dịch vụ chung
        public static List<PSDanhMucGoiDichVuChung> GetListGoiDichVuChung()
        {
            var db = new BioDAL();
            return db.GetListGoiDichVuChung();
        }
        #endregion

        #region DM Gói dịch vụ cơ sở
        public static DataTable GetListGoiDichVuCoSo()
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowIDGoiDichVuTrungTam", typeof(Int32)));
                dt.Columns.Add(new DataColumn("TenGoiDichVuTrungTam", typeof(string)));
                dt.Columns.Add(new DataColumn("IDGoiDichVuChung", typeof(string)));
                dt.Columns.Add(new DataColumn("MaDVCS", typeof(string)));
                dt.Columns.Add(new DataColumn("ChietKhau", typeof(float)));
                dt.Columns.Add(new DataColumn("DonGia", typeof(decimal)));
                var vlist = db.GetListGoiDichVuCoSo();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowIDGoiDichVuTrungTam;
                    dr[1] = lt1.TenGoiDichVuChung;
                    dr[2] = lt1.IDGoiDichVuChung;
                    dr[3] = lt1.MaDVCS;
                    dr[4] = lt1.ChietKhau;
                    dr[5] = lt1.DonGia;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static PSDanhMucGoiDichVuTheoDonVi GetGoiDichVuCoSoById(int id)
        {
            var db = new BioDAL();
            return db.GetGoiDichVuCoSoById(id);
        }

        public static bool CheckExistGoiTheoDonVi(string maGoi, string maDonVi)
        {
            var db = new BioDAL();
            return db.CheckExistGoiTheoDonVi(maGoi, maDonVi);
        }

        public static bool InsGoiDichVuCoSo(PSDanhMucGoiDichVuTheoDonVi goiDichVuCoSo)
        {
            var db = new BioDAL();
            return db.InsGoiDichVuCoSo(goiDichVuCoSo);
        }

        public static bool UpdGoiDichVuCoSo(PSDanhMucGoiDichVuTheoDonVi goiDichVuCoSo)
        {
            var db = new BioDAL();
            return db.UpdGoiDichVuCoSo(goiDichVuCoSo);
        }

        public static bool DelGoiDichVuCoSo(int id)
        {
            var db = new BioDAL();
            return db.DelGoiDichVuChung(id);
        }
        #endregion

        #region DM nhóm
        public static List<PSDanhMucNhom> GetListNhom()
        {
            var db = new BioDAL();
            return db.GetListNhom();
        }
        #endregion

        #region DM dịch vụ 
        public static DataTable GetListDichVu()
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("IDDichVu", typeof(string)));
                dt.Columns.Add(new DataColumn("TenDichVu", typeof(string)));
                dt.Columns.Add(new DataColumn("GiaDichVu", typeof(decimal)));
                dt.Columns.Add(new DataColumn("MaNhom", typeof(string)));
                dt.Columns.Add(new DataColumn("isLocked", typeof(bool)));
                dt.Columns.Add(new DataColumn("isGoiXn", typeof(bool)));
                dt.Columns.Add(new DataColumn("TenHienThiDichVu", typeof(string)));
                var vlist = db.GetListDichVu();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.IDDichVu;
                    dr[1] = lt1.TenDichVu;
                    dr[2] = lt1.GiaDichVu;
                    dr[3] = lt1.MaNhom;
                    dr[4] = lt1.isLocked;
                    dr[5] = lt1.isGoiXn;
                    dr[6] = lt1.TenHienThiDichVu;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static bool InsDichVu(PSDanhMucDichVu dichVu)
        {
            var db = new BioDAL();
            return db.InsDichVu(dichVu);
        }

        public static bool UpdDichVu(PSDanhMucDichVu dichVu)
        {
            var db = new BioDAL();
            return db.UpdDichVu(dichVu);
        }

        public static bool DelDichVu(string idDv)
        {
            var db = new BioDAL();
            return db.DelDichVu(idDv);
        }
        #endregion

        #region DM chi tiêt Gói dịch vụ chung
        public static List<PSChiTietGoiDichVuChung> GetListServicePackageByIDGoi(string idGoi)
        {
            var db = new BioDAL();
            return db.GetListServicePackageByIDGoi(idGoi);
        }

        public static bool UpdDetailServicePackage(string idGoi, List<string> idDichVu)
        {
            var db = new BioDAL();
            return db.UpdDetailServicePackage(idGoi, idDichVu);
        }

        #endregion

        #region DM Chi cục
        public static DataTable GetListChiCuc()
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MaChiCuc", typeof(string)));
                dt.Columns.Add(new DataColumn("TenChiCuc", typeof(string)));
                dt.Columns.Add(new DataColumn("DiaChiChiCuc", typeof(string)));
                dt.Columns.Add(new DataColumn("SdtChiCuc", typeof(string)));
                dt.Columns.Add(new DataColumn("isLocked", typeof(bool)));
                dt.Columns.Add(new DataColumn("Logo", typeof(Binary)));
                dt.Columns.Add(new DataColumn("HeaderReport", typeof(Binary)));
                dt.Columns.Add(new DataColumn("Stt", typeof(int)));
                dt.Columns.Add(new DataColumn("RowIDChiCuc", typeof(int)));

                var vlist = db.GetListChiCuc();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.MaChiCuc;
                    dr[1] = lt1.TenChiCuc;
                    dr[2] = lt1.DiaChiChiCuc;
                    dr[3] = lt1.SdtChiCuc;
                    dr[4] = lt1.isLocked;
                    dr[5] = lt1.Logo;
                    dr[6] = lt1.HeaderReport;
                    dr[7] = string.IsNullOrEmpty(lt1.Stt.ToString()) ? 0 : lt1.Stt;
                    dr[8] = lt1.RowIDChiCuc;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }

            }
            catch(Exception ex) { dt = null; }
            return dt;
        }

        public static string GetCodeChiCuc()
        {
            var db = new BioDAL();
            return db.GetCodeChiCuc();
        }

        public static bool CheckExistCode(string code)
        {
            var db = new BioDAL();
            return db.CheckExistCode(code);
        }

        public static bool InsChiCuc(PSDanhMucChiCuc chiCuc)
        {
            var db = new BioDAL();
            return db.InsChiCuc(chiCuc);
        }

        public static bool UpdChiCuc(PSDanhMucChiCuc chiCuc)
        {
            var db = new BioDAL();
            return db.UpdChiCuc(chiCuc);
        }

        public static bool DelChiCuc(string idChicuc)
        {
            var db = new BioDAL();
            return db.DelChiCuc(idChicuc);
        }
        #endregion

        #region DM Trung tâm
        public static DataTable GetListTrungTam()
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MaTrungTam", typeof(string)));
                dt.Columns.Add(new DataColumn("TenTrungTam", typeof(string)));
                dt.Columns.Add(new DataColumn("Diachi", typeof(string)));
                dt.Columns.Add(new DataColumn("Logo", typeof(Binary)));
                dt.Columns.Add(new DataColumn("MaVietTat", typeof(string)));
                dt.Columns.Add(new DataColumn("DienThoai", typeof(string)));

                var vlist = db.GetListTrungTam();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.MaTrungTam;
                    dr[1] = lt1.TenTrungTam;
                    dr[2] = lt1.Diachi;
                    dr[3] = lt1.Logo;
                    dr[4] = lt1.MaVietTat;
                    dr[5] = lt1.DienThoai;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static bool UpdTrungTam(PSThongTinTrungTam trungTam)
        {
            var db = new BioDAL();
            return db.UpdTrungTam(trungTam);
        }
        #endregion

        #region Thông tin bệnh nhân
        public static List<PSPatient> GetListPatient(string keyword)
        {
            var db = new BioDAL();
            return db.GetListBenhNhanSearch(keyword);
        }

        public static PSPatient GetInfoPersonByMa(string maBenhNhan)
        {
            var db = new BioDAL();
            return db.GetInfoPersonByMa(maBenhNhan);
        }

        public static bool UpdInfoPerson(PSPatient infoPatient)
        {
            var db = new BioDAL();
            return db.UpdInfoPerson(infoPatient);
        }
        #endregion

        #region DM Chương trình
        public static DataTable GetListChuongTrinh()
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowIDChuongTrinh", typeof(int)));
                dt.Columns.Add(new DataColumn("IDChuongTrinh", typeof(string)));
                dt.Columns.Add(new DataColumn("TenChuongTrinh", typeof(string)));
                dt.Columns.Add(new DataColumn("Ngaytao", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("NgayHetHieuLuc", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("isLocked", typeof(bool)));
                var vlist = db.GetListChuongTrinh();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowIDChuongTrinh;
                    dr[1] = lt1.IDChuongTrinh;
                    dr[2] = lt1.TenChuongTrinh;
                    dr[3] = !string.IsNullOrEmpty(lt1.Ngaytao.ToString())?lt1.Ngaytao:(object)DBNull.Value;
                    dr[4] = !string.IsNullOrEmpty(lt1.NgayHetHieuLuc.ToString()) ? lt1.NgayHetHieuLuc : (object)DBNull.Value;
                    dr[5] = lt1.isLocked;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static PSDanhMucChuongTrinh GetChuongTrinhById(int id)
        {
            var db = new BioDAL();
            return db.GetChuongTrinhById(id);
        }

        public static bool CheckExistMaCT(string maChuongTrinh)
        {
            var db = new BioDAL();
            return db.CheckExistMaCT(maChuongTrinh);
        }

        public static bool InsChuongTrinh(PSDanhMucChuongTrinh chuongTrinh)
        {
            var db = new BioDAL();
            return db.InsChuongTrinh(chuongTrinh);
        }

        public static bool UpdChuongTrinh(PSDanhMucChuongTrinh chuongTrinh)
        {
            var db = new BioDAL();
            return db.UpdChuongTrinh(chuongTrinh);
        }

        public static bool DelChuongTrinh(int id)
        {
            var db = new BioDAL();
            return db.DelChuongTrinh(id);
        }
        #endregion

        #region DM Đánh giá chất lượng mẫu
        public static DataTable GetListDanhGia()
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowIDChatLuongMau", typeof(int)));
                dt.Columns.Add(new DataColumn("IDDanhGiaChatLuongMau", typeof(string)));
                dt.Columns.Add(new DataColumn("ChatLuongMau", typeof(string)));
                dt.Columns.Add(new DataColumn("isLocked", typeof(bool)));
                var vlist = db.GetListDanhGia();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowIDChatLuongMau;
                    dr[1] = lt1.IDDanhGiaChatLuongMau;
                    dr[2] = lt1.ChatLuongMau;
                    dr[3] = lt1.isLocked;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static PSDanhMucDanhGiaChatLuongMau GetDanhGiaById(int id)
        {
            var db = new BioDAL();
            return db.GetDanhGiaById(id);
        }

        public static bool CheckExistMaDanhGia(string maDanhGia)
        {
            var db = new BioDAL();
            return db.CheckExistMaDanhGia(maDanhGia);
        }

        public static bool InsDanhGia(PSDanhMucDanhGiaChatLuongMau danhGia)
        {
            var db = new BioDAL();
            return db.InsDanhGia(danhGia);
        }

        public static bool UpdDanhGia(PSDanhMucDanhGiaChatLuongMau danhGia)
        {
            var db = new BioDAL();
            return db.UpdDanhGia(danhGia);
        }

        public static bool DelDanhGia(int id)
        {
            var db = new BioDAL();
            return db.DelDanhGia(id);
        }
        #endregion

        #region DM Thông số xét nghiệm
        public static DataTable GetListThongSoXN()
        {
            var db = new BioDAL();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowIDThongSo", typeof(int)));
                dt.Columns.Add(new DataColumn("IDThongSoXN", typeof(string)));
                dt.Columns.Add(new DataColumn("TenThongSo", typeof(string)));
                dt.Columns.Add(new DataColumn("GiaTriMinNu", typeof(double)));
                dt.Columns.Add(new DataColumn("GiaTriMaxNu", typeof(double)));
                dt.Columns.Add(new DataColumn("GiaTriTrungBinhNu", typeof(string)));
                dt.Columns.Add(new DataColumn("GiaTriMacDinh", typeof(string)));
                dt.Columns.Add(new DataColumn("GiaTriMinNam", typeof(double)));
                dt.Columns.Add(new DataColumn("GiaTriMaxNam", typeof(double)));
                dt.Columns.Add(new DataColumn("GiaTriTrungBinhNam", typeof(string)));
                dt.Columns.Add(new DataColumn("MaNhom", typeof(byte)));
                dt.Columns.Add(new DataColumn("Stt", typeof(int)));
                dt.Columns.Add(new DataColumn("GiaTri", typeof(string)));
                dt.Columns.Add(new DataColumn("DonViTinh", typeof(string)));
                dt.Columns.Add(new DataColumn("isLocked", typeof(bool)));
                var vlist = db.GetListThongSoXN();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowIDThongSo;
                    dr[1] = lt1.IDThongSoXN;
                    dr[2] = lt1.TenThongSo;
                    dr[3] = lt1.GiaTriMinNu;
                    dr[4] = lt1.GiaTriMaxNu;
                    dr[5] = lt1.GiaTriTrungBinhNu;
                    dr[6] = lt1.GiaTriMacDinh;
                    dr[7] = lt1.GiaTriMinNam;
                    dr[8] = lt1.GiaTriMaxNam;
                    dr[9] = lt1.GiaTriTrungBinhNam;
                    dr[10] = lt1.MaNhom;
                    dr[11] = lt1.Stt;
                    dr[12] = lt1.GiaTri;
                    dr[13] = lt1.DonViTinh;
                    dr[14] = lt1.isLocked;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static PSDanhMucThongSoXN GetThongSoXNById(int id)
        {
            var db = new BioDAL();
            return db.GetThongSoXNById(id);
        }

        public static bool CheckExistThongSo(string maThongSo)
        {
            var db = new BioDAL();
            return db.CheckExistThongSo(maThongSo);
        }

        public static bool InsThongSoXN(PSDanhMucThongSoXN thongSo)
        {
            var db = new BioDAL();
            return db.InsThongSoXN(thongSo);
        }

        public static bool UpdThongSo(PSDanhMucThongSoXN thongSo)
        {
            var db = new BioDAL();
            return db.UpdThongSo(thongSo);
        }

        public static bool DelThongSo(int id)
        {
            var db = new BioDAL();
            return db.DelThongSo(id);
        }
        #endregion
    }
}
