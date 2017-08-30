using BioNetModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioNetModel
{
    public class PsEmployeePosition
    {
        public int PositionCode { get; set; }

        public string PositionName { get; set; }

        public int Level { get; set; }

        public List<PSEmployee> Employee { get; set; }
    }
}
