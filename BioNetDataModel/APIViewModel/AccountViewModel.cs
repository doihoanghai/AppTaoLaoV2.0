using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class AccountViewModel
    {
        public string Username { get; set; }
        public string PasswordOld { get; set; }
        public string PasswordNew { get; set; }
    }
}