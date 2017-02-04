using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastColoredTextBoxNS;
using System.Windows.Forms;
using System.Drawing;

namespace GEdit
{
    public class CustomText: FastColoredTextBox
    {
        public CustomText(userSettings Settings){
            this.Dock = DockStyle.Fill;
            this.Name = "textbox";
            this.LineNumberColor = Color.White;
            this.BackColor = Color.FromArgb(51,51,51);
            this.BorderStyle = BorderStyle.None;
            this.IndentBackColor = MaterialSkin.ColorExtension.ToColor((int)Settings.Primary);
            this.ServiceLinesColor = MaterialSkin.ColorExtension.ToColor((int)Settings.Primary);

            this.DisabledColor = MaterialSkin.ColorExtension.ToColor((int)Settings.Primary);
            this.ForeColor = Color.White;
            //this.PaddingBackColor =Color.FromArgb(55,71,79);
        }
    }
}
