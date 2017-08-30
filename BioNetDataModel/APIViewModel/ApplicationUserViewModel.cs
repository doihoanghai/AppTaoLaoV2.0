using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class ApplicationUserViewModel
    {
        public string Id { set; get; }
        public string FullName { set; get; }
        public string BirthDay { set; get; }
        public string Bio { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }

        public string PhoneNumber { set; get; }
        public int? UserLevel { get; set; }

        public string LevelCode { get; set; }

        public IEnumerable<ApplicationGroupViewModel> Groups { set; get; }

        public IEnumerable<ApplicationRoleViewModel> Roles { set; get; }
    }
}