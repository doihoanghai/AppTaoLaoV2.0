using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Localization;
namespace BioNetSangLocSoSinh.CustomLayouts
{
    public class CustomGridDropDownSearchLookup : GridResLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            if (id == GridStringId.FindControlFindButton)
                return "Tìm";
            if (id == GridStringId.FindControlClearButton)
                return "Làm mới";
            return base.GetLocalizedString(id);
        }
    }
}
