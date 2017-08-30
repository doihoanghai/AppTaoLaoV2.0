using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
   public class PsDichVu
    {
        public int RowID { get; set; }
        public string IDDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string TenHienThi { get; set; }
        public decimal GiaDichVu { get; set; }
        public string MaNhom { get; set; }
        public  bool isLocked { get; set; }
        public bool isChecked { get; set; }
    }
}
