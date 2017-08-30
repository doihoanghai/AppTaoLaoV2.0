using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
   public class PSKetQuaXetNghiem :Data.PSXN_TraKetQua
    {
     //  public Data.PSXN_TraKetQua KetQua = new Data.PSXN_TraKetQua();
        public List<Data.PSXN_TraKQ_ChiTiet> KetQuaChiTiet { get; set; }
    }
}
