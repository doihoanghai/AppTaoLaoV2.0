using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class DanhMucDanhGiaChatLuongViewModel
    {
        public int RowIDChatLuongMau { get; set; }

        public string ChatLuongMau { get; set; }

        public bool? isLocked { get; set; }

        public string IDDanhGiaChatLuongMau { get; set; }
    }
}