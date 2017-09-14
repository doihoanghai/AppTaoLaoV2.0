using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DataSync
{
    public class DBPhieuKQDataSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkPDF = "/api/patient/pushlistfilekq";      
        public static PsReponse PostKQPDF()
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
                        string path = Application.StartupPath + "\\DSNenDongBo\\";
                        IEnumerable<string> linkfiledb = Directory.EnumerateDirectories(path);
                        // Danh sách thư mục đơn vị cơ sở

                        DirectoryInfo linkpdfs = new DirectoryInfo(path);

                        FileInfo[] linkpdf = linkpdfs.GetFiles();
                        foreach (FileInfo filedongbo in linkpdf)
                        {

                            long numBytes = filedongbo.Length;
                            FileStream fStream = new FileStream(filedongbo.FullName, FileMode.Open, FileAccess.Read);

                            BinaryReader br = new BinaryReader(fStream);

                            byte[] bdata = br.ReadBytes((int)numBytes);

                            br.Close();

                            var result = PostPDF(cn.CreateLink(linkPDF), token, bdata);
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
        public static ObjectModel.ResultReponse PostPDF(string link, string token, byte[] file)
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
            return res;

        }
    }
}
