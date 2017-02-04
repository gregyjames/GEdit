using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEdit
{
    class SplitContainerX: SplitContainer
    {
        public override System.Drawing.Rectangle DisplayRectangle
        {
            get
            {
                Rectangle r = base.DisplayRectangle;
                r.Inflate(2, 1);
                r.Offset(-1, 0);
                return r;
            }
        }

        public SplitContainerX()
        {
            Margin = new Padding(0);
            BorderStyle = BorderStyle.None;
            BackColor = Color.FromArgb(55, 71, 79);
            Orientation = Orientation.Horizontal;
            SplitterDistance = 100;
            IsSplitterFixed = true;
            Name = "HOR";
            SplitterWidth = 1;
            SplitterWidth = 1;
            Dock = DockStyle.Fill;
        }
    }
}
