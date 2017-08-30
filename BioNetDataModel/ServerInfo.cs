using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BioNetModel
{
    [XmlRoot("serverInfo")]
    public class ServerInfo
    {
        [XmlElement("encrypt")]
        public string Encrypt { get; set; }

        [XmlElement("servername")]
        public string ServerName { get; set; }

        [XmlElement("username")]
        public string UserName { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("database")]
        public string Database { get; set; }


    }
}
