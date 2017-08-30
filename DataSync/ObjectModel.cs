using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSync
{
    public class ObjectModel
    {
        public class ResultReponse
        {
            public bool Result { get; set; }
            public string ValueResult { get; set; }
            public string ErorrResult { get; set; }
        }
        public class AccessToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }
        public class BodyAccessToken
        {
            public string grant_type { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }
        public class RootObjectAPI
        {
            public dynamic Items { get; set; }
            public int Page { get; set; }
            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
        }

        }
}
