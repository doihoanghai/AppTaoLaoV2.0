using BioNetModel;
using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace DataSync
{
    public class DBPhieuKQDataSync
    {
        private static BioNetDBContextDataContext db = null;
        private static string linkPDF = "/api/patient/pushListFileKQ";      
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
                            //Identificate separator
                            string boundary = filedongbo.FullName + DateTime.Now.Ticks.ToString("x");
                            //Encoding                          
                            byte[] boundarybytes = File.ReadAllBytes(filedongbo.FullName);
                            br.Close();
                            string link;
                            link = linkPDF + "?mabenhnhan=" + filedongbo.Name.Substring(0, 8);

                            var result = PostPDF(cn.CreateLink(link), token, boundarybytes);
                            if (string.IsNullOrEmpty(result.ErorrResult))
                            {
                                res.Result=true;
                            }
                            else
                            {
                                res.Result = false;
                                res.StringError += DateTime.Now.ToString() + "Lỗi khi đồng bộ dữ liệu lên sever lỗi \r\n ";
                            }
                        }
                    }
                    else
                    {
                        res.Result = false;
                        res.StringError += DateTime.Now.ToString() + "Lỗi khi đồng bộ dữ liệu danh sách phiếu kết quả pdf";
                    }
                }
            }
            catch (Exception ex)
            {
                res.Result = false;
                res.StringError += DateTime.Now.ToString() + "Lỗi khi đồng bộ dữ liệu danh sách phiếu kết quả pdf \r\n " + ex.Message;
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
             
                using (Stream streamWriter = httpWebRequest.GetRequestStream())
                {
                    streamWriter.Write(file, 0, file.Length);
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
