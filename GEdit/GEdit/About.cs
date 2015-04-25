using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GEdit
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            var link = new LinkLabel.Link {LinkData = "https://github.com/gregyjames/GEdit"};
            linkLabel1.Links.Add(link);
        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start(e.Link.LinkData as string);
        }
    }
}
