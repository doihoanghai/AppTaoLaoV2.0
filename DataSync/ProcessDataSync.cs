using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BioNetModel.Data;
using BioNetModel;
using Bionet.API.Models;
using System.Net;
using System.Security;
using System.Web.Script.Serialization;
using System.Web;
using System.Data.Linq;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Security.Cryptography;
using DataSync;
using System.Data;
using System.Reflection;



namespace DataSync
{
   public  class ProcessDataSync
    {
        private static string linkhost = "http://192.168.88.169/";
        private static string linkGetToken = "/oauth/token";
        private static string linkThongTinTrungTam = "api/trungtamsangloc/getall";
        
        private static string linkGetDanhMucDanhGiaChatLuongMau = "api/danhgiachatluong/getall?keyword=&page=0&pagesize=20";
        private static string linkGetDanhMucChuongTrinh = "/api/chuongtrinh/getall?keyword=&page=0&pagesize=20";
        private static string linkGetDanhMucDichVu = "/api/dichvu/getall?keyword=&page=0&pagesize=20";
        private static string linkGetDanhMucKyThuat = "api/dmkythuatxn/getall?keyword=&page=0&pagesize=20"; 
        private static string linkGetDanhMucDanToc= "/api/dantoc/getallDanToc"; 
        private static string linkGetDanhMucGoiDVChung = "/api/goidichvuchung/getallGoiDichVuTT";
        private static string linkGetDanhMucThongSo = "http://localhost:55570/api/thongsoxetnghiem/getall";
        private static string linkGetDanhMucMap_ThongSo_KyThuat = "http://localhost:55570/api/chuongtrinh/getallChuongTrinh"; // Thiếu
        private static string linkGetDanhMucMap_KyThuat_DichVu = "http://localhost:55570/api/chuongtrinh/getallChuongTrinh";// Thiếu
        private static string linkGetPhieuSangLoc = "http://localhost:55570/api/phieusangloc";

        
        
        
        private static ServerInfo serverInfo = new ServerInfo();
      public ProcessDataSync()
        {
            try
            {
                db = new BioNetDBContextDataContext(GetConfigObject());
            }
            catch { }
        }
        public   string CreateLink(string link)
        {
            // get linkhost từ configdb
            return linkhost + link;
        }

        private static string DecryptString(string toDecrypt, bool useHashing)
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
         private static ServerInfo LoadFileXml(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(ServerInfo));
                return serializer.Deserialize(stream) as ServerInfo;
            }
        }
        private static string GetConfigObject()
        {
            try
            {
                string connectionstring;
                //string pathFileName = (Application.StartupPath).Remove((Application.StartupPath).Length - 10);
                //ServerInfo server = this.LoadFileXml(pathFileName + "\\xml\\configiHIS.xml");
                string pathFileName = (Application.StartupPath) + "\\xml\\configiBionet.xml";
                ServerInfo server = LoadFileXml(pathFileName);
                if (server != null && server.Encrypt == "true")
                {
                    serverInfo.Encrypt = server.Encrypt;
                    serverInfo.ServerName = DecryptString(server.ServerName, true);
                    serverInfo.Database = DecryptString(server.Database, true);
                   serverInfo.UserName = DecryptString(server.UserName, true);
                   serverInfo.Password =DecryptString(server.Password, true);
                }
                else if (server != null && server.Encrypt == "false")
                {
                   serverInfo.Encrypt = "false";
                   serverInfo.ServerName = "powersoft.vn";
                   serverInfo.Database = "Bio";
                  serverInfo.UserName = "ps";
                   serverInfo.Password = "*******";
                }
                connectionstring = "Data Source=" +serverInfo.ServerName + ";Initial Catalog=" + serverInfo.Database + ";User Id=" + serverInfo.UserName + ";Password=" + serverInfo.Password + ";";
                return connectionstring;
            }
            catch (Exception ex)
            {
                //connectionstring = string.Empty;
                throw new Exception(ex.Message);
            }
        }
        public  BioNetDBContextDataContext db = null;
        public ObjectModel.ResultReponse GetRespone(string link, string token)
        {
            using (var wb = new WebClient())
            {
                ObjectModel.ResultReponse res = new ObjectModel.ResultReponse();
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Headers.Add("Authorization", token);

                    res.Result = true;
                    res.ValueResult = webClient.DownloadString(link);

                }
                catch (Exception ex)
                {
                    res.Result = false;
                    res.ValueResult = ex.Message;
                    res.ErorrResult = ex.Message;
                }
                return res;
            }
        }

        public object ConvertObjectToObject(object source,object des)
        {
            var props = des.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {        
                try
                {
                    var data = source.GetType().GetProperty(prop.Name).GetValue(source, null);
                    prop.SetValue(des, data, null);

                }
                catch
                {
                    prop.SetValue(des, null, null);
                }
            }
            return des;
        }
        public  object CovertDynamicToObjectModel(dynamic item, object ct)
        {
            var props = ct.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                

                if (prop.PropertyType.ToString().Contains("DateTime"))
                { 
                    if (item[prop.Name] != null)
                        prop.SetValue(ct, Convert.ToDateTime(item[prop.Name]), null);
                    else
                        prop.SetValue(ct, null, null);
                }
                else
                    if (prop.PropertyType.ToString().Contains("Boolean"))
                    try {
                        prop.SetValue(ct, Convert.ToBoolean(item[prop.Name]), null); }
                    catch { prop.SetValue(ct, true, null); }
                else
                if (prop.PropertyType.ToString().Contains("Int64"))
                    prop.SetValue(ct, Convert.ToInt64(item[prop.Name]), null);
                else
               if (prop.PropertyType.ToString().Contains("Int32"))
                    try {
                        prop.SetValue(ct, Convert.ToInt32(item[prop.Name]), null); }
                    catch { prop.SetValue(ct, 0, null); }
                else
                if (prop.PropertyType.ToString().Contains("Int16"))
                    prop.SetValue(ct, Convert.ToInt16(item[prop.Name]), null);
                else
                    if (prop.PropertyType.ToString().Contains("Binary"))
                    try {
                        prop.SetValue(ct, Convert.ToByte(item[prop.Name]), null); }
                    catch { prop.SetValue(ct, null, null); }
                else
                    if (prop.PropertyType.ToString().Contains("Double"))
                    try
                    {
                        prop.SetValue(ct, Convert.ToDouble(item[prop.Name]), null);
                    }
                    catch { prop.SetValue(ct, 0, null); }
                else
                    if (prop.PropertyType.ToString().Contains("Decimal"))
                    try
                    {
                        prop.SetValue(ct, Convert.ToDecimal(item[prop.Name]), null);
                    }
                    catch { prop.SetValue(ct, 0, null); }
                else
                    if (prop.PropertyType.ToString().Contains("Byte"))
                    try
                    {
                        prop.SetValue(ct, Convert.ToByte(item[prop.Name]), null);
                    }
                    catch { prop.SetValue(ct, 0, null); }
                else
                    prop.SetValue(ct, item[prop.Name], null);


            }
            return ct;
        }
        public string GetToken(string userName, string passWord)
        {
            try
            {
                ObjectModel.AccessToken result = new ObjectModel.AccessToken();

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(CreateLink(linkGetToken));
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Method = "POST";
                string urldata = @"grant_type=password&username={0}&password={1}";
                byte[] byteArray = Encoding.UTF8.GetBytes(string.Format(urldata, userName, passWord));
                httpWebRequest.ContentLength = byteArray.Length;
                Stream dataStream = httpWebRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                var response = httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    JavaScriptSerializer javaScript = new JavaScriptSerializer();
                    result = javaScript.Deserialize<ObjectModel.AccessToken>(streamReader.ReadToEnd());
                }
                if (result != null)
                {
                    return result.token_type + " " + result.access_token;
                }
                else return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public ObjectModel.ResultReponse PostRespone(string link, string token, string jsonData)
        {
            ObjectModel.ResultReponse res = new ObjectModel.ResultReponse();
            try
            {
                string result = string.Empty;
                WebClient webClient = new WebClient();

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                httpWebRequest.Headers.Add("Authorization", token);
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonData);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    res.Result = true;
                }
                else
                {
                    res.ErorrResult = httpResponse.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.ValueResult = ex.Message;
                res.ErorrResult = ex.Message;
            }
            return res;

            }
        public int PostPDF(string link, string token, byte[] file)
        {
            ObjectModel.ResultReponse res = new ObjectModel.ResultReponse();
            try
            {
                string result = string.Empty;
                WebClient webClient = new WebClient();

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                httpWebRequest.Headers.Add("Authorization", token);
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(Encoding.Unicode.GetChars(file), 0, file.Length);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    res.Result = true;
                }
                else
                {
                    res.ErorrResult = httpResponse.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.ValueResult = ex.Message;
                res.ErorrResult = ex.Message;
            }
            return 1;

        }
    }

}
   

