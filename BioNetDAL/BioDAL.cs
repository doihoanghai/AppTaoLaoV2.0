using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BioNetDAL
{
    public class BioDAL
    {
        public static BioNetDBContextDataContext db = null;
        private string connectString = string.Empty;
        public SqlConnection sqlConnection = null;
        public BioDAL()
        {
            string str = GetConfigObject();
            db = new BioNetDBContextDataContext(str);
           // db = new BioNetDBContextDataContext(DataContext.connectionString);
        }

        public bool CheckConnection()
        {
            try
            {             
                db.Connection.Open();               
                db.Connection.Close();
                return true;
            }catch(Exception ex) { return false; }
        }
        public ServerInfo serverInfo = new ServerInfo();
        private string GetConfigObject()
        {
            try
            {
                string connectionstring;
                //string pathFileName = (Application.StartupPath).Remove((Application.StartupPath).Length - 10);
                //ServerInfo server = this.LoadFileXml(pathFileName + "\\xml\\configiHIS.xml");
                string pathFileName = (Application.StartupPath) + "\\xml\\configiBionet.xml";
                ServerInfo server = this.LoadFileXml(pathFileName);
                if (server != null && server.Encrypt == "true")
                {
                    this.serverInfo.Encrypt = server.Encrypt;
                    this.serverInfo.ServerName = this.DecryptString(server.ServerName, true);
                    this.serverInfo.Database = this.DecryptString(server.Database, true);
                    this.serverInfo.UserName = this.DecryptString(server.UserName, true);
                    this.serverInfo.Password = this.DecryptString(server.Password, true);
                }
                else if (server != null && server.Encrypt == "false")
                {
                    this.serverInfo.Encrypt = "false";
                    this.serverInfo.ServerName = "powersoft.vn";
                    this.serverInfo.Database = "Bio";
                    this.serverInfo.UserName = "ps";
                    this.serverInfo.Password = "*******";
                }            
                connectionstring = "Data Source=" + this.serverInfo.ServerName + ";Initial Catalog=" + this.serverInfo.Database + ";User Id=" + this.serverInfo.UserName + ";Password=" + this.serverInfo.Password + ";";
                return connectionstring;
            }
            catch (Exception ex)
            {
                //connectionstring = string.Empty;
                throw new Exception(ex.Message);
            }
        }
        public string DecryptString(string toDecrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                if (useHashing)
                {
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("2$Powersoft.vn"));
                }
                else keyArray = Encoding.UTF8.GetBytes("2$Powersoft.vn");
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
            catch { return toDecrypt; }
        }
        public ServerInfo LoadFileXml(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(ServerInfo));
                return serializer.Deserialize(stream) as ServerInfo;
            }
        }
        public bool CheckConnection(string servername, string username, string password, string database)
        {
            try
            {
                this.connectString = "Data Source=" + servername + ";Initial Catalog=" + database + ";User Id=" + username + ";Password=" + password + ";";        
                db = new BioNetDBContextDataContext(this.connectString);
                db.Connection.Open();
                this.WritefileXmlObject(servername, username, password, database);
               // db.Connection.Close();
                //SaveSetting(this.connectString);
                return true;
            }
            catch(Exception ex) { return false; }
            finally
            {
                if (db.Connection.State != ConnectionState.Closed)
                    db.Connection.Close();
            }
        }
        private void WritefileXmlObject(string servername, string username, string password, string database)
        {
            string fileName = (Application.StartupPath) + "\\xml\\configiBionet.xml";
            var serializer = new XmlSerializer(typeof(ServerInfo));
            ServerInfo server = new ServerInfo { Encrypt = "true", ServerName = this.EncryptString(servername, true), UserName = this.EncryptString(username, true), Password = this.EncryptString(password, true), Database = this.EncryptString(database, true) };
            using (StreamWriter myWriter = new StreamWriter(fileName, false))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(ServerInfo));
                mySerializer.Serialize(myWriter, server);
            }
        }
        public string EncryptString(string toEncrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
                if (useHashing)
                {
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("2$Powersoft.vn"));
                }
                else keyArray = Encoding.UTF8.GetBytes("2$Powersoft.vn");
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch { return toEncrypt; }
        }
        public List<PSPatient> getListBenhNhan()
        {
            List<PSPatient> lst = new List<PSPatient>();
            try
            {
                lst = db.PSPatients.ToList();
                return lst;
            }
            catch { return lst; }
        }

        private void SaveSetting(string connectionString)
        {
            try
            {
                //use for coder
                string path = (Application.StartupPath).Remove((Application.StartupPath).Length - 9) + "app.config";
                var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
                var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["BioNetModel"].ConnectionString = connectionString;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch { }

            try
            {
                //change config BIN first
                var configBinfirst = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSectionBinfirst = (ConnectionStringsSection)configBinfirst.GetSection("connectionStrings");
                connectionStringsSectionBinfirst.ConnectionStrings["BioNetModel"].ConnectionString = connectionString;
                configBinfirst.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch { }
            
        }

        public string MyServerName()
        {
            return Environment.MachineName;
        }

        public DataTable TableServerName()
        {
            try
            {
                string myServer = Environment.MachineName;
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
                return servers;
            }
            catch { return null; }
        }

        public string GetMD5(string str)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);
            foreach (byte b in mang)
            {
                str_md5 += b.ToString("x2");
            }
            return str_md5;
        }

        #region Login
        public bool CheckLoginUser(string userName, string passWord)
        {
            try
            {
                var res = db.PSEmployees.FirstOrDefault(p => p.Username == userName && p.Password == passWord);
                if (res != null)
                    return true;
                else return false;
            }
            catch { return false; }
        }

        public List<PSMenuSecurity> ListMenuSecurity(string empCode)
        {
            List<PSMenuSecurity> lstMenuSecurity = new List<PSMenuSecurity>();
            try
            {
                lstMenuSecurity = db.PSMenuSecurities.Where(x => x.EmployeeCode == empCode).ToList();
            }
            catch
            {
                lstMenuSecurity.Clear();
            }
            return lstMenuSecurity;
        }

        public string GetEmployeeCode(string userName)
        {
            try
            {
                return db.PSEmployees.Where(x => x.Username == userName).FirstOrDefault().EmployeeCode;
            }catch { return string.Empty; }
        }
        #endregion

        #region Phân quyền

        public List<PsEmployeePosition> GetEmployeeByPosition(int code)
        {
            try
            {
                List<PsEmployeePosition> lstEmployeePosition = new List<PsEmployeePosition>();
                List<PSEmployee> lstEmployee = db.PSEmployees.ToList();
                var lstEmpPosition = new List<PSEmployeePosition>();
                if (code == 0)
                    lstEmpPosition = db.PSEmployeePositions.ToList();
                else
                    lstEmpPosition = db.PSEmployeePositions.Where(x=>x.PositionCode == code).ToList();
                foreach (var position in lstEmpPosition)
                {
                    PsEmployeePosition empPosition = new PsEmployeePosition();
                    List<PSEmployee> lstEmp = new List<PSEmployee>();
                    lstEmp = lstEmployee.Where(x => x.PositionCode == position.PositionCode).ToList();
                    empPosition.PositionCode = position.PositionCode;
                    empPosition.PositionName = position.PositionName;
                    empPosition.Level = position.Level;
                    empPosition.Employee = lstEmp;
                    lstEmployeePosition.Add(empPosition);
                }
                return lstEmployeePosition;
            }
            catch { return null; }
        }

        public List<PSChiTietGoiDichVuChung> GetListChiTietGoiDichVuChung()
        {
            List<PSChiTietGoiDichVuChung> lst = new List<PSChiTietGoiDichVuChung>();
            try
            {
                var res = db.PSChiTietGoiDichVuChungs.ToList();
                if (res.Count > 0) return res;
                else return lst;
            }
            catch { return lst; }
        }

        public  bool UpdateMenuSercurity(List<PSMenuSecurity> lstMenuSecurity, string empCode)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var delListMenu = db.PSMenuSecurities.Where(x => x.EmployeeCode == empCode);
                db.PSMenuSecurities.DeleteAllOnSubmit(delListMenu);
                db.PSMenuSecurities.InsertAllOnSubmit(lstMenuSecurity);

                db.SubmitChanges();
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdateMenuSercurityPosition(List<PSMenuSecurityPosition> lstMenuSecurity, int positionCode)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var delListMenu = db.PSMenuSecurityPositions.Where(x => x.PositionCode == positionCode);
                db.PSMenuSecurityPositions.DeleteAllOnSubmit(delListMenu);
                db.PSMenuSecurityPositions.InsertAllOnSubmit(lstMenuSecurity);

                db.SubmitChanges();
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public List<PSMenuSecurityPosition> ListMenuSecurityByPosition(int positionCode)
        {
            List<PSMenuSecurityPosition> lstMenuSecurity = new List<PSMenuSecurityPosition>();
            try
            {
                lstMenuSecurity = db.PSMenuSecurityPositions.Where(x => x.PositionCode == positionCode).ToList();
            }
            catch
            {
                lstMenuSecurity.Clear();
            }
            return lstMenuSecurity;
        }

        public void DeleteItemMenuSercurity(PSMenuSecurity itemMenuSecurity)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var delListMenu = db.PSMenuSecurities.Where(x => x.EmployeeCode == itemMenuSecurity.EmployeeCode && x.MenuCode == itemMenuSecurity.MenuCode).FirstOrDefault();
                if(delListMenu != null)
                {
                    db.PSMenuSecurities.DeleteOnSubmit(delListMenu);
                    db.SubmitChanges();
                }

                db.Transaction.Commit();
                db.Connection.Close();
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
            }
        }

        public void InsertItemMenuSercurity(PSMenuSecurity itemMenuSecurity)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var insListMenu = db.PSMenuSecurities.Where(x => x.EmployeeCode == itemMenuSecurity.EmployeeCode && x.MenuCode == itemMenuSecurity.MenuCode).FirstOrDefault();

                if(insListMenu == null)
                {
                    db.PSMenuSecurities.InsertOnSubmit(itemMenuSecurity);
                    db.SubmitChanges();
                }

                db.Transaction.Commit();
                db.Connection.Close();
            }
            catch(Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
            }
        }
        #endregion

        #region Nhân viên
        private string passDefault = "123456";

        public List<PSEmployeeGroup> ListEmployeeGroup(int id)
        {
            var lstEmpGroup = new List<PSEmployeeGroup>();
            try
            {
                if (id == 0)
                    lstEmpGroup = db.PSEmployeeGroups.ToList();
                else
                    lstEmpGroup = db.PSEmployeeGroups.Where(x => x.EmployeeGroupID == id).ToList();
            }
            catch{}
            return lstEmpGroup;
        }

        public List<PSEmployeePosition> ListEmployeePosition(int id)
        {
            var lstEmpPosition = new List<PSEmployeePosition>();
            try
            {
                if (id == 0)
                    lstEmpPosition = db.PSEmployeePositions.ToList();
                else
                    lstEmpPosition = db.PSEmployeePositions.Where(x => x.PositionCode == id).ToList();
            }
            catch { }
            return lstEmpPosition;
        }

        public List<PSEmployee> ListEmployee(string empCode)
        {
            var lstEmployee = new List<PSEmployee>();
            try
            {
                if (string.IsNullOrEmpty(empCode))
                    lstEmployee = db.PSEmployees.ToList();
                else
                    lstEmployee = db.PSEmployees.Where(x => x.EmployeeCode == empCode).ToList();
            }
            catch { }
            return lstEmployee;
        }
        //public List<PSEmployeePosition> ListEmployeePosition(int positioncode)
        //{
        //    var lstEmployee = new List<PSEmployeePosition>();
        //    try
        //    {
        //        if (positioncode<1)
        //            lstEmployee = db.PSEmployeePositions.ToList();
        //        else
        //            lstEmployee = db.PSEmployeePositions.Where(x => x.PositionCode == positioncode).ToList();
        //    }
        //    catch { }
        //    return lstEmployee;
        //}
        public bool CheckExistPosition(string positionName,int id)
        {
            try
            {
                var emp = db.PSEmployeePositions.Where(x => x.PositionName == positionName).ToList();
                if (emp.Count <= 0)
                    return true;
                else if (id >0 && emp.Count<2)
                    return true;
                else
                    return false;

            }
            catch { return false; }
        }
        public bool CheckExistUser(string username)
        {
            try
            {
                var emp = db.PSEmployees.Where(x => x.Username == username).ToList();
                if (emp.Count <= 0)
                    return true;
                else
                    return false;

            }catch { return false; }
        }

        public bool DelEmployee(string empCode)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var delEmp = db.PSEmployees.Where(x => x.EmployeeCode == empCode).FirstOrDefault();
                db.PSEmployees.DeleteOnSubmit(delEmp);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        public bool DelEmployeePosition(int empCode)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var delEmp = db.PSEmployeePositions.Where(x => x.PositionCode == empCode).FirstOrDefault();
                db.PSEmployeePositions.DeleteOnSubmit(delEmp);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        public bool InsEmployeePosition(PSEmployeePosition  emp)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                db.PSEmployeePositions.InsertOnSubmit(emp);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool InsEmployee(PSEmployee emp)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                int maxRow = db.PSEmployees.Max(p => p.RowID);
                string lastEmpCode = db.PSEmployees.Where(p => p.RowID == maxRow).FirstOrDefault().EmployeeCode;
                int numID = Convert.ToInt32(lastEmpCode.Substring(2)) + 1;
                string empCode = string.Empty;
                if (numID <= 9)
                    empCode = "NV000" + numID;
                else if (numID > 9 && numID <= 99)
                    empCode = "NV00" + numID;
                else if (numID > 99 && numID <= 999)
                    empCode = "NV0" + numID;
                else
                    empCode = "NV" + numID;
                emp.EmployeeCode = empCode;
                emp.Password = GetMD5(passDefault);
                db.PSEmployees.InsertOnSubmit(emp);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdEmployee(PSEmployee emp)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var empUpd = db.PSEmployees.Where(x => x.EmployeeCode == emp.EmployeeCode).FirstOrDefault();
                empUpd.EmployeeName = emp.EmployeeName;
                empUpd.Sex = emp.Sex;
                empUpd.Mobile = emp.Mobile;
                empUpd.IDCard = emp.IDCard;
                empUpd.Address = emp.Address;
                empUpd.Birthday = emp.Birthday;
                empUpd.PositionCode = emp.PositionCode;
                empUpd.Username = emp.Username;
                empUpd.EmployeeGroupID = emp.EmployeeGroupID;
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdEmployeePosition(PSEmployeePosition emp)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var empUpd = db.PSEmployeePositions.Where(x => x.PositionCode == emp.PositionCode).FirstOrDefault();
               
                empUpd.PositionName = emp.PositionName;
                empUpd.Level = emp.Level;
               
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdPassEmployee(string empCode, string pass)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var empUpd = db.PSEmployees.Where(x => x.EmployeeCode == empCode).FirstOrDefault();
                if(string.IsNullOrEmpty(pass))
                    empUpd.Password = GetMD5(passDefault);
                else
                    empUpd.Password = GetMD5(pass);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public PSEmployee GetEmployeeByCode(string empCode)
        {
            PSEmployee employee = new PSEmployee();
            try
            {
                employee = db.PSEmployees.Where(x => x.EmployeeCode == empCode).FirstOrDefault();
                return employee;
            }
            catch { return employee = new PSEmployee(); }
        }

        public PSEmployeePosition GetPositionByCode(int posCode)
        {
            PSEmployeePosition position = new PSEmployeePosition();
            try
            {
                position = db.PSEmployeePositions.Where(x => x.PositionCode == posCode).FirstOrDefault();
                return position;
            }
            catch { return position = new PSEmployeePosition(); }
        }
        #endregion

        #region DM Gói dịch vụ chung
        public List<PSDanhMucGoiDichVuChung> GetListGoiDichVuChung()
        {
            List<PSDanhMucGoiDichVuChung> lstGoiDichVuChung = new List<PSDanhMucGoiDichVuChung>();
            try
            {
                lstGoiDichVuChung = db.PSDanhMucGoiDichVuChungs.ToList();
                return lstGoiDichVuChung;
            }
            catch { return lstGoiDichVuChung = new List<PSDanhMucGoiDichVuChung>(); }
        }

        #endregion

        #region DM Gói dịch vụ cơ sở
        public List<PSDanhMucGoiDichVuTheoDonVi> GetListGoiDichVuCoSo()
        {
            List<PSDanhMucGoiDichVuTheoDonVi> lstGoiDichVuCoSo = new List<PSDanhMucGoiDichVuTheoDonVi>();
            try
            {
                lstGoiDichVuCoSo = db.PSDanhMucGoiDichVuTheoDonVis.ToList();
                return lstGoiDichVuCoSo;
            }
            catch { return lstGoiDichVuCoSo = new List<PSDanhMucGoiDichVuTheoDonVi>(); }
        }

        public PSDanhMucGoiDichVuTheoDonVi GetGoiDichVuCoSoById(int id)
        {
            PSDanhMucGoiDichVuTheoDonVi goiDichVuCS = new PSDanhMucGoiDichVuTheoDonVi();
            try
            {
                goiDichVuCS = db.PSDanhMucGoiDichVuTheoDonVis.Where(x => x.RowIDGoiDichVuTrungTam == id).FirstOrDefault();
                return goiDichVuCS;
            }catch { return goiDichVuCS = new PSDanhMucGoiDichVuTheoDonVi(); }
        }

        public bool CheckExistGoiTheoDonVi(string maGoi, string maDonVi)
        {
            try
            {
                var goiDonVi = db.PSDanhMucGoiDichVuTheoDonVis.Where(x => x.IDGoiDichVuChung == maGoi && x.MaDVCS == maDonVi).ToList();
                if (goiDonVi.Count <= 0)
                    return true;
                else
                    return false;
            }catch { return false; }
        }

        public bool InsGoiDichVuCoSo(PSDanhMucGoiDichVuTheoDonVi goiDichVuCoSo)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                db.PSDanhMucGoiDichVuTheoDonVis.InsertOnSubmit(goiDichVuCoSo);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool InsMultiGoiDichVuCoSo(List<PSDanhMucGoiDichVuTheoDonVi> lstGoiDichVuCoSo)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();
                List< PSChiTietGoiDichVuChung >lstDichVuChung = new List<PSChiTietGoiDichVuChung>();
                lstDichVuChung = db.PSChiTietGoiDichVuChungs.ToList();
                foreach (var dichVu in lstGoiDichVuCoSo)
                {
                    if (CheckExistGoiTheoDonVi(dichVu.IDGoiDichVuChung, dichVu.MaDVCS))
                    {
                        db.PSDanhMucGoiDichVuTheoDonVis.InsertOnSubmit(dichVu);
                        #region InserDichVuTheoDonvi 
                        foreach (var dv in lstDichVuChung)
                        {
                            var donvidichvu = db.PSDanhMucDichVuTheoDonVis.FirstOrDefault(p => p.IDDichVu == dv.IDDichVu && p.MaDonVi == dichVu.MaDVCS);
                            
                            if (donvidichvu == null)
                            {
                                PSDanhMucDichVuTheoDonVi dvdv = new PSDanhMucDichVuTheoDonVi();
                                PSDanhMucDichVu dmdv = new PSDanhMucDichVu();
                                try
                                {
                                    dmdv = db.PSDanhMucDichVus.FirstOrDefault(p => p.IDDichVu == dv.IDDichVu);
                                }
                                catch { }
                                dvdv.ChietKhau = 0;
                                string ten = string.Empty;
                                dvdv.DonGia = dmdv.GiaDichVu ?? 0;
                                dvdv.IDDichVu = dv.IDDichVu;
                                dvdv.isLocked = false;
                                dvdv.MaDonVi = dichVu.MaDVCS;
                                dvdv.TenDichVu = dmdv.TenDichVu ?? string.Empty;
                                dvdv.TenHienThi = dmdv.TenHienThiDichVu ?? string.Empty;
                                dvdv.MaNhom = dmdv.MaNhom.ToString();
                                db.PSDanhMucDichVuTheoDonVis.InsertOnSubmit(dvdv);
                                db.SubmitChanges();
                            }
                        }
                        #endregion InserDichVuTheoDonvi
                        db.SubmitChanges();
                    }
                }
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }


        public bool UpdGoiDichVuCoSo(PSDanhMucGoiDichVuTheoDonVi goiDichVuCoSo)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var goiDvCoSo = db.PSDanhMucGoiDichVuTheoDonVis.Where(x => x.RowIDGoiDichVuTrungTam == goiDichVuCoSo.RowIDGoiDichVuTrungTam).FirstOrDefault();

                goiDvCoSo.TenGoiDichVuChung = goiDichVuCoSo.TenGoiDichVuChung;
                goiDvCoSo.MaDVCS = goiDichVuCoSo.MaDVCS;
                goiDvCoSo.IDGoiDichVuChung = goiDichVuCoSo.IDGoiDichVuChung;
                goiDvCoSo.ChietKhau = goiDichVuCoSo.ChietKhau;
                goiDvCoSo.DonGia = goiDichVuCoSo.DonGia;
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool DelGoiDichVuChung(int id)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var goiDvCoSo = db.PSDanhMucGoiDichVuTheoDonVis.Where(x => x.RowIDGoiDichVuTrungTam == id).FirstOrDefault();
                db.PSDanhMucGoiDichVuTheoDonVis.DeleteOnSubmit(goiDvCoSo);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        #endregion

        #region DM nhóm
        public List<PSDanhMucNhom> GetListNhom()
        {
            List<PSDanhMucNhom> lstNhom = new List<PSDanhMucNhom>();
            try
            {
                lstNhom = db.PSDanhMucNhoms.ToList();
                return lstNhom;
            }
            catch { return lstNhom = new List<PSDanhMucNhom>(); }
        }
        #endregion

        #region DM Dịch vụ
        public List<PSDanhMucDichVu> GetListDichVu()
        {
            List<PSDanhMucDichVu> lstDichVu = new List<PSDanhMucDichVu>();
            try
            {
                lstDichVu = db.PSDanhMucDichVus.ToList();
                return lstDichVu;
            }
            catch { return lstDichVu = new List<PSDanhMucDichVu>(); }
        }

        public bool InsDichVu(PSDanhMucDichVu dichVu)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                int maxRow = db.PSDanhMucDichVus.Max(p => p.RowIDDichVu);
                string lastID = db.PSDanhMucDichVus.Where(p => p.RowIDDichVu == maxRow).FirstOrDefault().IDDichVu;
                int numID = Convert.ToInt32(lastID.Substring(4)) + 1;
                string idDV = string.Empty;
                if (numID <= 9)
                    idDV = "DVXN0000" + numID;
                else if (numID > 9 && numID <= 99)
                    idDV = "DVXN000" + numID;
                else if (numID > 99 && numID <= 999)
                    idDV = "DVXN00" + numID;
                else if (numID > 999 && numID <= 9999)
                    idDV = "DVXN0" + numID;
                else 
                    idDV = "DVXN" + numID;
                dichVu.IDDichVu = idDV;
                db.PSDanhMucDichVus.InsertOnSubmit(dichVu);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdDichVu(PSDanhMucDichVu dichVu)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var dv = db.PSDanhMucDichVus.Where(x => x.IDDichVu == dichVu.IDDichVu).FirstOrDefault();

                dv.TenDichVu = dichVu.TenDichVu;
                dv.GiaDichVu = dichVu.GiaDichVu;
                dv.MaNhom = dichVu.MaNhom;
                dv.isLocked = dichVu.isLocked;
                dv.isGoiXn = dichVu.isGoiXn;
                dv.TenHienThiDichVu = dichVu.TenHienThiDichVu;
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool DelDichVu(string idDv)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var dV = db.PSDanhMucDichVus.Where(x => x.IDDichVu == idDv).FirstOrDefault();
                db.PSDanhMucDichVus.DeleteOnSubmit(dV);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        #endregion

        #region DM chi tiêt Gói dịch vụ chung
        public List<PSChiTietGoiDichVuChung> GetListServicePackageByIDGoi(string idGoi)
        {
            List<PSChiTietGoiDichVuChung> lstDichVu = new List<PSChiTietGoiDichVuChung>();
            try
            {
                lstDichVu = db.PSChiTietGoiDichVuChungs.Where(x => x.IDGoiDichVuChung == idGoi).ToList();
                return lstDichVu;
            }
            catch { return lstDichVu = new List<PSChiTietGoiDichVuChung>(); }
        }

        public bool UpdDetailServicePackage(string idGoi, List<string> idDichVu)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var delDetailServicePackage = db.PSChiTietGoiDichVuChungs.Where(x => x.IDGoiDichVuChung == idGoi).ToList();
                db.PSChiTietGoiDichVuChungs.DeleteAllOnSubmit(delDetailServicePackage);

                List<PSChiTietGoiDichVuChung> lstIns = new List<PSChiTietGoiDichVuChung>();
                foreach(var item in idDichVu)
                {
                    PSChiTietGoiDichVuChung detailServicePackage = new PSChiTietGoiDichVuChung() {
                        IDDichVu = item,
                        IDGoiDichVuChung = idGoi
                    };
                    lstIns.Add(detailServicePackage);
                }
                db.PSChiTietGoiDichVuChungs.InsertAllOnSubmit(lstIns);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch { db.Transaction.Rollback(); db.Connection.Close(); return false; }
        }
        #endregion

        #region DM Chi cục
        public List<PSDanhMucChiCuc> GetListChiCuc()
        {
            List<PSDanhMucChiCuc> lstChiCuc = new List<PSDanhMucChiCuc>();
            try
            {
                lstChiCuc = db.PSDanhMucChiCucs.ToList();
                return lstChiCuc;
            }
            catch { return lstChiCuc = new List<PSDanhMucChiCuc>(); }
        }



        public string GetCodeChiCuc()
        {
            try
            {
                string code = string.Empty;
                //string maTrungTam = db.PSThongTinTrungTams.FirstOrDefault().MaTrungTam;

                //int maxRow = db.PSDanhMucChiCucs.Max(p => p.RowIDChiCuc);
                //string lastID = db.PSDanhMucChiCucs.Where(p => p.RowIDChiCuc == maxRow).FirstOrDefault().MaChiCuc;
                //int numID = Convert.ToInt32(lastID.Substring(maTrungTam.Length)) + 1;
                //if (numID <= 9)
                //    code = maTrungTam + "0" + numID;
                //else if (numID > 9 && numID <= 99)
                //    code = maTrungTam + numID;

                var lstChiCuc = db.PSDanhMucChiCucs.ToList();
                string maTrungTam = db.PSThongTinTrungTams.FirstOrDefault().MaTrungTam;
                for(int i = 1; i < 100; i ++)
                {
                    string maChicuc = string.Empty;
                    if (i <= 9)
                        maChicuc = maTrungTam + "0" + i;
                    else
                        maChicuc = maTrungTam + i;
                    var checkExist = lstChiCuc.Where(x => x.MaChiCuc == maChicuc).ToList();
                    if(checkExist.Count == 0)
                    {
                        code = maChicuc;
                        break;
                    }
                }
                return code;
            }
            catch { return string.Empty; }
        }

        public bool CheckExistCode(string code)
        {
            try
            {
                var chiCuc = db.PSDanhMucChiCucs.Where(x => x.MaChiCuc == code).FirstOrDefault();
                if (chiCuc == null)
                    return true;
                else
                    return false;
            }catch { return false; }
        }

        public bool CheckExistCodeInForeign(string code)
        {
            try
            {
                var donVi = db.PSDanhMucDonViCoSos.Where(x => x.MaChiCuc == code).FirstOrDefault();
                if (donVi == null)
                    return true;
                else
                    return false;

            }
            catch { return false; }
        }

        public bool InsChiCuc(PSDanhMucChiCuc chiCuc)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                string code = string.Empty;
                string maTrungTam = db.PSThongTinTrungTams.FirstOrDefault().MaTrungTam;

                chiCuc.MaChiCuc = chiCuc.MaChiCuc;
                chiCuc.MaTrungTam = maTrungTam;
                db.PSDanhMucChiCucs.InsertOnSubmit(chiCuc);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdChiCuc(PSDanhMucChiCuc chiCuc)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var dmChiCuc = db.PSDanhMucChiCucs.Where(x => x.RowIDChiCuc == chiCuc.RowIDChiCuc).FirstOrDefault();
                if (dmChiCuc.MaChiCuc != chiCuc.MaChiCuc)
                    if (!CheckExistCodeInForeign(dmChiCuc.MaChiCuc))
                        return false;
                dmChiCuc.MaChiCuc = chiCuc.MaChiCuc;
                dmChiCuc.TenChiCuc = chiCuc.TenChiCuc;
                dmChiCuc.DiaChiChiCuc = chiCuc.DiaChiChiCuc;
                dmChiCuc.SdtChiCuc = chiCuc.SdtChiCuc;
                dmChiCuc.Stt = chiCuc.Stt;
                dmChiCuc.Logo = chiCuc.Logo;
                dmChiCuc.HeaderReport = chiCuc.HeaderReport;
                dmChiCuc.isLocked = chiCuc.isLocked;
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool DelChiCuc(string idChicuc)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var chiCuc = db.PSDanhMucChiCucs.Where(x => x.MaChiCuc == idChicuc).FirstOrDefault();
                if (!CheckExistCodeInForeign(chiCuc.MaChiCuc))
                    return false;
                db.PSDanhMucChiCucs.DeleteOnSubmit(chiCuc);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        #endregion

        #region DM Trung tâm
        public List<PSThongTinTrungTam> GetListTrungTam()
        {
            List<PSThongTinTrungTam> lstTrungTam = new List<PSThongTinTrungTam>();
            try
            {
                lstTrungTam = db.PSThongTinTrungTams.ToList();
                return lstTrungTam;
            }
            catch { return lstTrungTam = new List<PSThongTinTrungTam>(); }
        }

        public bool UpdTrungTam(PSThongTinTrungTam trungTam)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var dmTrungTam = db.PSThongTinTrungTams.Where(x => x.MaTrungTam == trungTam.MaTrungTam).FirstOrDefault();
                dmTrungTam.TenTrungTam = trungTam.TenTrungTam;
                dmTrungTam.Diachi = trungTam.Diachi;
                dmTrungTam.Logo = trungTam.Logo;
                dmTrungTam.MaVietTat = trungTam.MaVietTat;
                dmTrungTam.DienThoai = trungTam.DienThoai;
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        #endregion

        #region DM Đơn vị cơ sở
        public List<PSDanhMucDonViCoSo> GetListDonViCoSo()
        {
            List<PSDanhMucDonViCoSo> lstDonViCoSo = new List<PSDanhMucDonViCoSo>();
            try
            {
                lstDonViCoSo = db.PSDanhMucDonViCoSos.ToList();
                return lstDonViCoSo;
            }
            catch { return lstDonViCoSo = new List<PSDanhMucDonViCoSo>(); }
        }

        public PSDanhMucDonViCoSo GetDonViCoSoById(int rowID)
        {
            PSDanhMucDonViCoSo donViCS = new PSDanhMucDonViCoSo();
            try
            {
                donViCS = db.PSDanhMucDonViCoSos.Where(x => x.RowIDDVCS == rowID).FirstOrDefault();
                return donViCS;
            }
            catch { return donViCS = new PSDanhMucDonViCoSo(); }
        }

        public string GetCodeDonViCoSo(string codeChiCuc)
        {
            try
            {
                string code = string.Empty;

                var lstDVCS= db.PSDanhMucDonViCoSos.ToList();
                for (int i = 1; i < 1000; i++)
                {
                    string maDonVi = string.Empty;
                    if (i <= 9)
                        maDonVi = codeChiCuc + "00" + i;
                    else if (i > 9 && i <= 99)
                        maDonVi = codeChiCuc + "0" + i;
                    else
                        maDonVi = codeChiCuc + i;
                    var checkExist = lstDVCS.Where(x => x.MaDVCS == maDonVi).ToList();
                    if (checkExist.Count == 0)
                    {
                        code = maDonVi;
                        break;
                    }
                }
                return code;
            }
            catch { return string.Empty; }
        }

        public bool CheckExistCodeDVCS(string code)
        {
            try
            {
                var donViCS = db.PSDanhMucDonViCoSos.Where(x => x.MaDVCS == code).FirstOrDefault();
                if (donViCS == null)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public bool CheckExistCodeInForeignDVCS(string code)
        {
            try
            {
                var phieuSangLoc = db.PSPhieuSangLocs.Where(x => x.IDCoSo == code).FirstOrDefault();
                var trungTam = db.PSDanhMucGoiDichVuTheoDonVis.Where(x => x.MaDVCS == code).FirstOrDefault();
                if (phieuSangLoc != null || trungTam !=  null)
                    return false;
                else
                    return true;
            }
            catch { return false; }
        }

        public bool InsDonViCS(PSDanhMucDonViCoSo donViCS)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                db.PSDanhMucDonViCoSos.InsertOnSubmit(donViCS);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdDonViCS(PSDanhMucDonViCoSo donViCS)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var dmdonViCS = db.PSDanhMucDonViCoSos.Where(x => x.RowIDDVCS == donViCS.RowIDDVCS).FirstOrDefault();
                if (dmdonViCS.MaDVCS != donViCS.MaDVCS)
                    if (!CheckExistCodeInForeignDVCS(dmdonViCS.MaDVCS))
                        return false;
                    else
                if (dmdonViCS.MaChiCuc != donViCS.MaChiCuc)
                    dmdonViCS.MaDVCS = GetCodeDonViCoSo(donViCS.MaChiCuc);
                else
                    dmdonViCS.MaDVCS = donViCS.MaDVCS;
                dmdonViCS.MaChiCuc = donViCS.MaChiCuc;
                dmdonViCS.TenDVCS = donViCS.TenDVCS;
                dmdonViCS.DiaChiDVCS = donViCS.DiaChiDVCS;
                dmdonViCS.SDTCS = donViCS.SDTCS;
                dmdonViCS.Stt = donViCS.Stt;
                dmdonViCS.Logo = donViCS.Logo;
                dmdonViCS.HeaderReport = donViCS.HeaderReport;
                dmdonViCS.isLocked = donViCS.isLocked;
                dmdonViCS.KieuTraKetQua = donViCS.KieuTraKetQua;
                dmdonViCS.isDongBo = donViCS.isDongBo;
                dmdonViCS.TenBacSiDaiDien = donViCS.TenBacSiDaiDien;
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool DelDonViCS(string idDonViCS)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var donViCS = db.PSDanhMucDonViCoSos.Where(x => x.MaDVCS == idDonViCS).FirstOrDefault();
                if (!CheckExistCodeInForeignDVCS(donViCS.MaDVCS))
                    return false;
                db.PSDanhMucDonViCoSos.DeleteOnSubmit(donViCS);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        #endregion

        #region Thông tin bệnh nhân
        //private List<PSPatient> MapToInfoPerson()
        //{
        //    List<PSPatient> lstInfoPerson = new List<PSPatient>();
        //    try
        //    {
        //        var patient = db.PSPatients.ToList();
        //        var person = db.PsPersons.ToList();
        //        foreach (var model in patient)
        //        {
        //            PsInfoPerson infoPatient = new PsInfoPerson();
        //            infoPatient.MaThongTin = model.MaThongTinBenhNhan;
        //            infoPatient.Patients = model;
        //            infoPatient.Persons = person.Where(x => x.MaThongTin == model.MaThongTinBenhNhan).FirstOrDefault();
        //            lstInfoPerson.Add(infoPatient);
        //        }
        //        return lstInfoPerson;
        //    }
        //    catch { return lstInfoPerson = new List<PsInfoPerson>(); }
        //}

        public List<PSPatient> GetListBenhNhanSearch(string keyword)
        {
            List<PSPatient> lstInfoPerson = new List<PSPatient>();
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    lstInfoPerson = db.PSPatients.ToList();
                }
                else { 

                lstInfoPerson = db.PSPatients.Where(x => x.MotherName.Contains(keyword) || x.TenBenhNhan.Contains(keyword) || x.MaKhachHang.Contains(keyword)).ToList();
            }

                return lstInfoPerson;
            }
            catch { return lstInfoPerson; }
        }

        public PSPatient GetInfoPersonByMa(string maBenhNhan)
        {
            PSPatient infoPerson = new PSPatient();
            try
            {
                infoPerson = db.PSPatients.FirstOrDefault(p => p.MaBenhNhan == maBenhNhan);
                return infoPerson;
            }
            catch { return infoPerson; }
        }

        public bool UpdInfoPerson(PSPatient infoPerson)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var patient = db.PSPatients.Where(x => x.MaBenhNhan == infoPerson.MaBenhNhan).FirstOrDefault();
                patient.TenBenhNhan = infoPerson.TenBenhNhan;
                patient.NgayGioSinh = infoPerson.NgayGioSinh;
                patient.NoiSinh = infoPerson.NoiSinh;
                patient.DanTocID = infoPerson.DanTocID;
                patient.DiaChi = infoPerson.DiaChi;
                patient.TuanTuoiKhiSinh = infoPerson.TuanTuoiKhiSinh;
                patient.CanNang = infoPerson.CanNang;
                patient.PhuongPhapSinh = infoPerson.PhuongPhapSinh;
                patient.GioiTinh = infoPerson.GioiTinh;
                patient.FatherName = infoPerson.FatherName;
                patient.MotherName = infoPerson.MotherName;
                patient.FatherBirthday = infoPerson.FatherBirthday;
                patient.MotherBirthday = infoPerson.MotherBirthday;
                patient.FatherPhoneNumber = infoPerson.FatherPhoneNumber;
                patient.MotherPhoneNumber  = infoPerson.MotherPhoneNumber;
                patient.DiaChi = infoPerson.DiaChi;

                db.SubmitChanges();
                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        #endregion

        #region DM Chương trình
        public List<PSDanhMucChuongTrinh> GetListChuongTrinh()
        {
            List<PSDanhMucChuongTrinh> lstChuongTrinh = new List<PSDanhMucChuongTrinh>();
            try
            {
                lstChuongTrinh = db.PSDanhMucChuongTrinhs.ToList();
                return lstChuongTrinh;
            }
            catch { return lstChuongTrinh = new List<PSDanhMucChuongTrinh>(); }
        }

        public PSDanhMucChuongTrinh GetChuongTrinhById(int id)
        {
            PSDanhMucChuongTrinh chuongTrinh = new PSDanhMucChuongTrinh();
            try
            {
                chuongTrinh = db.PSDanhMucChuongTrinhs.Where(x => x.RowIDChuongTrinh == id).FirstOrDefault();
                return chuongTrinh;
            }catch { return chuongTrinh = new PSDanhMucChuongTrinh(); }
        }

        public bool CheckExistMaCT(string maChuongTrinh)
        {
            try
            {
                var chuongTrinh = db.PSDanhMucChuongTrinhs.Where(x => x.IDChuongTrinh == maChuongTrinh).ToList();
                if (chuongTrinh.Count <= 0)
                    return true;
                else
                    return false;
            }catch { return false; }
        }

        private bool CheckExistForeignChuongTrinh(string maChuongTrinh)
        {
            try
            {
                var phieuSangLoc = db.PSPhieuSangLocs.Where(x => x.IDChuongTrinh == maChuongTrinh).ToList();
                if (phieuSangLoc.Count <= 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public bool InsChuongTrinh(PSDanhMucChuongTrinh chuongTrinh)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                db.PSDanhMucChuongTrinhs.InsertOnSubmit(chuongTrinh);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdChuongTrinh(PSDanhMucChuongTrinh chuongTrinh)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var ct = db.PSDanhMucChuongTrinhs.Where(x => x.RowIDChuongTrinh == chuongTrinh.RowIDChuongTrinh).FirstOrDefault();

                ct.IDChuongTrinh = chuongTrinh.IDChuongTrinh;
                ct.TenChuongTrinh = chuongTrinh.TenChuongTrinh;
                ct.Ngaytao = chuongTrinh.Ngaytao;
                ct.NgayHetHieuLuc = chuongTrinh.NgayHetHieuLuc;
                ct.isLocked = chuongTrinh.isLocked;
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool DelChuongTrinh(int id)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var chuongTrinh = db.PSDanhMucChuongTrinhs.Where(x => x.RowIDChuongTrinh == id).FirstOrDefault();
                if (!CheckExistForeignChuongTrinh(chuongTrinh.IDChuongTrinh))
                    return false;
                db.PSDanhMucChuongTrinhs.DeleteOnSubmit(chuongTrinh);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        #endregion

        #region DM Đánh giá chất lượng mẫu
        public List<PSDanhMucDanhGiaChatLuongMau> GetListDanhGia()
        {
            List<PSDanhMucDanhGiaChatLuongMau> lstDanhGia = new List<PSDanhMucDanhGiaChatLuongMau>();
            try
            {
                lstDanhGia = db.PSDanhMucDanhGiaChatLuongMaus.ToList();
                return lstDanhGia;
            }
            catch { return lstDanhGia = new List<PSDanhMucDanhGiaChatLuongMau>(); }
        }

        public PSDanhMucDanhGiaChatLuongMau GetDanhGiaById(int id)
        {
            PSDanhMucDanhGiaChatLuongMau danhGia = new PSDanhMucDanhGiaChatLuongMau();
            try
            {
                danhGia = db.PSDanhMucDanhGiaChatLuongMaus.Where(x => x.RowIDChatLuongMau == id).FirstOrDefault();
                return danhGia;
            }
            catch { return danhGia = new PSDanhMucDanhGiaChatLuongMau(); }
        }

        public bool CheckExistMaDanhGia(string maDanhGia)
        {
            try
            {
                var danhGia = db.PSDanhMucDanhGiaChatLuongMaus.Where(x => x.IDDanhGiaChatLuongMau == maDanhGia).ToList();
                if (danhGia.Count <= 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private bool CheckExistForeignDanhGia(string maDanhGia)
        {
            try
            {
                var chiTietDanhGia = db.PSChiTietDanhGiaChatLuongs.Where(x => x.IDDanhGiaChatLuongMau == maDanhGia).ToList();
                if (chiTietDanhGia.Count <= 0)
                    return true;
                else
                    return false;
            }
            catch(Exception ex) { return false; }
        }

        public bool InsDanhGia(PSDanhMucDanhGiaChatLuongMau danhGia)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                db.PSDanhMucDanhGiaChatLuongMaus.InsertOnSubmit(danhGia);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdDanhGia(PSDanhMucDanhGiaChatLuongMau danhGia)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var ct = db.PSDanhMucDanhGiaChatLuongMaus.Where(x => x.RowIDChatLuongMau == danhGia.RowIDChatLuongMau).FirstOrDefault();

                ct.IDDanhGiaChatLuongMau = danhGia.IDDanhGiaChatLuongMau;
                ct.ChatLuongMau = danhGia.ChatLuongMau;
                ct.isLocked = danhGia.isLocked;
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool DelDanhGia(int id)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var danhGia = db.PSDanhMucDanhGiaChatLuongMaus.Where(x => x.RowIDChatLuongMau == id).FirstOrDefault();
                if (!CheckExistForeignDanhGia(danhGia.IDDanhGiaChatLuongMau))
                    return false;
                db.PSDanhMucDanhGiaChatLuongMaus.DeleteOnSubmit(danhGia);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        #endregion

        #region DM Thông số xét nghiệm
        public List<PSDanhMucThongSoXN> GetListThongSoXN()
        {
            List<PSDanhMucThongSoXN> lstThongSo = new List<PSDanhMucThongSoXN>();
            try
            {
                lstThongSo = db.PSDanhMucThongSoXNs.ToList();
                return lstThongSo;
            }
            catch { return lstThongSo = new List<PSDanhMucThongSoXN>(); }
        }

        public PSDanhMucThongSoXN GetThongSoXNById(int id)
        {
            PSDanhMucThongSoXN thongSo = new PSDanhMucThongSoXN();
            try
            {
                thongSo = db.PSDanhMucThongSoXNs.Where(x => x.RowIDThongSo == id).FirstOrDefault();
                return thongSo;
            }
            catch { return thongSo = new PSDanhMucThongSoXN(); }
        }

        public bool CheckExistThongSo(string maThongSo)
        {
            try
            {
                var thongSo = db.PSDanhMucThongSoXNs.Where(x => x.IDThongSoXN == maThongSo).ToList();
                if (thongSo.Count <= 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private bool CheckExistForeignThongSo(string maThongSo)
        {
            try
            {
                var phieuSangLoc = db.PSPhieuSangLocs.Where(x => x.IDChuongTrinh == maThongSo).ToList();
                if (phieuSangLoc.Count <= 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public bool InsThongSoXN(PSDanhMucThongSoXN thongSo)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                db.PSDanhMucThongSoXNs.InsertOnSubmit(thongSo);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool UpdThongSo(PSDanhMucThongSoXN thongSo)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var ts = db.PSDanhMucThongSoXNs.Where(x => x.RowIDThongSo == thongSo.RowIDThongSo).FirstOrDefault();
                ts.IDThongSoXN = thongSo.IDThongSoXN;
                ts.TenThongSo = thongSo.TenThongSo;
                ts.GiaTriMinNu = thongSo.GiaTriMinNu;
                ts.GiaTriMaxNu = thongSo.GiaTriMaxNu;
                ts.GiaTriTrungBinhNu = thongSo.GiaTriTrungBinhNu;
                ts.GiaTriMacDinh = thongSo.GiaTriMacDinh;
                ts.GiaTriMinNam = thongSo.GiaTriMinNam;
                ts.GiaTriMaxNam = thongSo.GiaTriMaxNam;
                ts.GiaTriTrungBinhNam = thongSo.GiaTriTrungBinhNam;
                ts.MaNhom = thongSo.MaNhom;
                ts.Stt = thongSo.Stt;
                ts.GiaTri = thongSo.GiaTri;
                ts.isLocked = thongSo.isLocked;
                ts.DonViTinh = thongSo.DonViTinh;
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }

        public bool DelThongSo(int id)
        {
            try
            {
                db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                var thongSo = db.PSDanhMucThongSoXNs.Where(x => x.RowIDThongSo == id).FirstOrDefault();
                if (!CheckExistForeignThongSo(thongSo.IDThongSoXN))
                    return false;
                db.PSDanhMucThongSoXNs.DeleteOnSubmit(thongSo);
                db.SubmitChanges();

                db.Transaction.Commit();
                db.Connection.Close();
                return true;
            }
            catch
            {
                db.Transaction.Rollback();
                db.Connection.Close();
                return false;
            }
        }
        #endregion
    }
}
