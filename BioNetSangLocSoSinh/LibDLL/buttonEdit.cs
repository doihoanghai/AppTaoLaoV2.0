using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BioNetSangLocSoSinh.LibDLL
{
    public class ButtonEdit : Button
    {
        public ButtonEdit()
        {
            this.FlatStyle = FlatStyle.Flat;

            this.BackColor = Color.Transparent;

            this.FlatAppearance.MouseDownBackColor = Color.Transparent;

            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }
    }
}
