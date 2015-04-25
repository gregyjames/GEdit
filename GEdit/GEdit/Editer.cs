using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using GEdit.Properties;
using Settings = GEDITER.Settings;

namespace GEdit
{
    public partial class Editer : Form
    {
        public string CurrentTab = "";

        public Editer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Controls.Add(new Texttab());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Add(new Texttab());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var op = new OpenFileDialog();
                op.ShowDialog();

                var sr = new StreamReader(op.FileName);


                var selectedRtb =
                    (FastColoredTextBoxNS.FastColoredTextBox)tabControl1.SelectedTab.Controls["textbox"];
                selectedRtb.Text = sr.ReadToEnd();

                tabControl1.SelectedTab.Text = op.FileName;
            }
            catch
            {
                MessageBox.Show(Resources.Form1_toolStripButton2_Click_Pick_a_file_);
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            

            var selectedRtb =
                (FastColoredTextBoxNS.FastColoredTextBox)tabControl1.SelectedTab.Controls["textbox"];

            try
            {
                if (File.Exists(tabControl1.SelectedTab.Text))
                {
                    File.WriteAllText(tabControl1.SelectedTab.Text, selectedRtb.Text);
                }
                else
                {
                    var sf = new SaveFileDialog();
                    sf.ShowDialog();
                    tabControl1.SelectedTab.Text = sf.FileName;
                }
            }
            catch { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var r = tabControl1.GetTabRect(i);
                var closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show(Resources.Form1_tabControl1_MouseDown_Would_you_like_to_Close_this_Tab_, Resources.Form1_tabControl1_MouseDown_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            var selectedRtb =
                (FastColoredTextBoxNS.FastColoredTextBox)tabControl1.SelectedTab.Controls["textbox"];

            var SaveDialoge = new SaveFileDialog();

            SaveDialoge.ShowDialog();

            File.WriteAllText(SaveDialoge.FileName, selectedRtb.Text);

            tabControl1.SelectedTab.Text = SaveDialoge.FileName;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripButton3.PerformClick();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripButton2.PerformClick();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var Settings = new Settings();

            Settings.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public sealed class Texttab : TabPage
    {
        private readonly FastColoredTextBoxNS.FastColoredTextBox _text = new FastColoredTextBoxNS.FastColoredTextBox();
        public string FILENAME = "";

        public Texttab()
        {
            if (File.Exists(@"settings.xml"))
            {
                var mySerializer = new XmlSerializer(typeof(settings));

                var myFileStream = new FileStream("settings.xml", FileMode.Open);

                var myObject = (settings)mySerializer.Deserialize(myFileStream);
                var family = new FontFamily(myObject.FontName);

                _text.ForeColor = Color.FromArgb(myObject.R1, myObject.G1, myObject.B1);
                _text.BackColor = Color.FromArgb(myObject.R2, myObject.G2, myObject.B2);

                _text.Font = new Font(family, Convert.ToSingle(myObject.FontSize), FontStyle.Regular);
                
                myFileStream.Close();
            }

            _text.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _text.Name = "textbox";
            _text.Dock = DockStyle.Fill;
            _text.CurrentLineColor = Color.LightGreen;
            _text.CommentPrefix = "//";
            
            Controls.Add(_text);
            //ImageIndex = 0;
            BackColor = Color.ForestGreen;
            Text = Resources.Texttab_Texttab_New_Tab;
        }

        
    }
}
