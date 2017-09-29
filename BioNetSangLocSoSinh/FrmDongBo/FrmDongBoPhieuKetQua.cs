using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.DashboardCommon;
using BioNetModel;
using BioNetModel.Data;
using BioNetBLL;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace BioNetSangLocSoSinh.FrmDongBo
{
    public partial class FrmDongBoPhieuKetQua : DevExpress.XtraEditors.XtraForm
    {
        public static BioNetDBContextDataContext db = null;
        public FrmDongBoPhieuKetQua()
        {
            try
            {
                string str = calltringconect();
                db = new BioNetDBContextDataContext(str);

                InitializeComponent();

            }
            catch (Exception ex) { }

        }
        private ServerInfo serverInfo = new ServerInfo();
        private string calltringconect()
        {
            try
            {
                string connectionstring;
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
                else
                {
                    this.serverInfo.Encrypt = "false";
                    this.serverInfo.ServerName = "powersoft.vn";
                    this.serverInfo.Database = "Bio";
                    this.serverInfo.UserName = "sa";
                    this.serverInfo.Password = "****";
                }
                connectionstring = "Data Source=" + this.serverInfo.ServerName + ";Initial Catalog=" + this.serverInfo.Database + ";User Id=" + this.serverInfo.UserName + ";Password=" + this.serverInfo.Password + ";";
                return connectionstring;
            }
            catch (Exception ex)
            {
                //this.connectionstring = string.Empty;
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

        private void butOK_Click(object sender, EventArgs e)
        {
           
           
        
        }
    }
}
    