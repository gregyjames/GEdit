using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEdit
{
    class CustomText : FastColoredTextBoxNS.FastColoredTextBox
    {
        private void _text_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var contextMenu = new ContextMenu();
                var menuItem = new MenuItem("Cut");
                menuItem.Click += CutAction;
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy");
                menuItem.Click += CopyAction;
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Paste");
                menuItem.Click += PasteAction;
                contextMenu.MenuItems.Add(menuItem);

                this.ContextMenu = contextMenu;
            }
        }

        private void CutAction(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void CopyAction(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Rtf, this.Text);
            Clipboard.Clear();
        }

        private void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                this.Text += Clipboard.GetText(TextDataFormat.Text);
            }
        }

        public CustomText(settings mySettings)
        {
            MouseUp += _text_MouseUp;
            ForeColor = System.Drawing.Color.FromArgb(mySettings.R1, mySettings.G1, mySettings.B1);
            BackColor = System.Drawing.Color.FromArgb(mySettings.R2, mySettings.G2, mySettings.B2);
            CurrentLineColor = System.Drawing.Color.FromArgb(mySettings.R3, mySettings.G3, mySettings.B3);
            float size = float.Parse(mySettings.FontSize, CultureInfo.InvariantCulture.NumberFormat);
            Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, size);
            Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Name = "textbox";
            Dock = DockStyle.Fill;
            CommentPrefix = "//";
        }
    }
}
