using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using GEdit.Properties;
using Settings = GEDITER.Theme;

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

                sr.Close();

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
                    //var x = 
                    var file = new StreamWriter(tabControl1.SelectedTab.Text);
                    file.WriteLine(selectedRtb.Text);

                    file.Close();
                    //File.WriteAllText(tabControl1.SelectedTab.Text, selectedRtb.Text);
                    
                }
                else
                {
                    var sf = new SaveFileDialog();
                    sf.ShowDialog();
                    tabControl1.SelectedTab.Text = sf.FileName;
                    var file = new StreamWriter(tabControl1.SelectedTab.Text);
                    file.WriteLine(selectedRtb.Text);

                    file.Close();
                }
            }
            catch
            {
                MessageBox.Show(Resources.Editer_toolStripButton3_Click_Save_Error_);
            }
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

        public TabControl TabControl1
        {
            get
            {
                return tabControl1;
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var run = new Run();
            run.Show();
        }
    }

    public sealed class Texttab : TabPage
    {
        private readonly FastColoredTextBoxNS.FastColoredTextBox _text = new FastColoredTextBoxNS.FastColoredTextBox();
        public string FILENAME = "";

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

                _text.ContextMenu = contextMenu;
            }
        }

        void CutAction(object sender, EventArgs e)
        {
            _text.Cut();
        }

        void CopyAction(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Rtf, _text.Text);
            Clipboard.Clear();
        }

        void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                _text.Text += Clipboard.GetText(TextDataFormat.Text);
            }
        } 

        public Texttab()
        {
            if (File.Exists(@"settings.xml"))
            {
                var mySerializer = new XmlSerializer(typeof(settings));

                var myFileStream = new FileStream("settings.xml", FileMode.Open);

                var myObject = (settings)mySerializer.Deserialize(myFileStream);
                //var family = new FontFamily(myObject.FontName);
                _text.MouseUp += _text_MouseUp;
                _text.ForeColor = Color.FromArgb(myObject.R1, myObject.G1, myObject.B1);
                _text.BackColor = Color.FromArgb(myObject.R2, myObject.G2, myObject.B2);
                _text.CurrentLineColor = Color.FromArgb(myObject.R3, myObject.G3, myObject.B3);
                //_text.Font = new Font(family, Convert.ToSingle(myObject.FontSize), FontStyle.Regular);

                myFileStream.Close();
            }
            else
            {
                var mySerializer = new XmlSerializer(typeof(settings));

                var myFileStream = new FileStream(Directory.GetCurrentDirectory() + "\\Themes\\Default.xml", FileMode.Open);

                var myObject = (settings)mySerializer.Deserialize(myFileStream);
                _text.MouseUp += _text_MouseUp;
                _text.ForeColor = Color.FromArgb(myObject.R1, myObject.G1, myObject.B1);
                _text.BackColor = Color.FromArgb(myObject.R2, myObject.G2, myObject.B2);
                _text.CurrentLineColor = Color.FromArgb(myObject.R3, myObject.G3, myObject.B3);

                myFileStream.Close();
            }

            _text.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _text.Name = "textbox";
            _text.Dock = DockStyle.Fill;
            
            _text.CommentPrefix = "//";
            
            Controls.Add(_text);
            BackColor = Color.ForestGreen;
            Text = Resources.Texttab_Texttab_New_Tab;
        }

        
    }
}
