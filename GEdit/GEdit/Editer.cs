using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using GEdit.Properties;
using Settings = GEDITER.Theme;

using System.Threading.Tasks;

namespace GEdit
{
    public partial class Editer : Form
    {
        public string CurrentTab = "";

        public Editer()
        {
            InitializeComponent();
        }

        private settings mySettings;

        async Task<settings> getSettings<settings>()
        {
            var fileName = "";

            if (File.Exists(@"settings.xml"))
            {
                fileName = "settings.xml";
            }

            else
            {
                fileName = Directory.GetCurrentDirectory() + "\\Themes\\Default.xml";
            }

            return await Task.Factory.StartNew<settings>(() =>
             {
                using (var myFileStream = new FileStream(fileName, FileMode.Open))
                 {
                     var mySerializer = new XmlSerializer(typeof(settings));

                     settings obj = (settings)mySerializer.Deserialize(myFileStream);

                     return obj;
                 }
             });
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            mySettings = await getSettings<settings>();
            tabControl1.Controls.Add(new Texttab());
        }

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

                var hor = (SplitContainer)tabControl1.SelectedTab.Controls["HOR"];
                var _text = (FastColoredTextBoxNS.FastColoredTextBox)hor.Panel1.Controls["textbox"];
                _text.ContextMenu = contextMenu;
            }
        }

        private void CutAction(object sender, EventArgs e)
        {
            var hor = (SplitContainer)tabControl1.SelectedTab.Controls["HOR"];
            var _text = (FastColoredTextBoxNS.FastColoredTextBox)hor.Panel1.Controls["textbox"];
            _text.Cut();
        }

        private void CopyAction(object sender, EventArgs e)
        {
            var hor = (SplitContainer)tabControl1.SelectedTab.Controls["HOR"];
            var _text = (FastColoredTextBoxNS.FastColoredTextBox)hor.Panel1.Controls["textbox"];
            Clipboard.SetData(DataFormats.Rtf, _text.Text);
            Clipboard.Clear();
        }

        private void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                var hor = (SplitContainer)tabControl1.SelectedTab.Controls["HOR"];
                var _text = (FastColoredTextBoxNS.FastColoredTextBox)hor.Panel1.Controls["textbox"];
                _text.Text += Clipboard.GetText(TextDataFormat.Text);
            }
        }

        private void addNewTab(object sender, EventArgs e)
        {
            //tabControl1.Controls.Add(globalTabTemplate.Clone());
            tabControl1.Controls.Add(new Texttab());
        }

        private void OpenFile(object sender, EventArgs e)
        {
            try
            {
                using (var op = new OpenFileDialog())
                {
                    op.ShowDialog();

                    var selectedRtb =
                        (FastColoredTextBoxNS.FastColoredTextBox)tabControl1.SelectedTab.Controls["textbox"];

                    Parallel.Invoke(() => selectedRtb.Text = File.ReadAllText(op.FileName));

                    tabControl1.SelectedTab.Text = op.FileName;
                }
            }
            catch
            {
                MessageBox.Show(Resources.Form1_toolStripButton2_Click_Pick_a_file_);
            }

        }

        private void SaveFile(object sender, EventArgs e)
        {


            var selectedRtb =
                (FastColoredTextBoxNS.FastColoredTextBox) tabControl1.SelectedTab.Controls["textbox"];

            try
            {
                if (File.Exists(tabControl1.SelectedTab.Text))
                {
                    //var x = 
                    var file = new StreamWriter(tabControl1.SelectedTab.Text);
                    Parallel.Invoke(() => file.WriteLine(selectedRtb.Text));


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

        private void drawX(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12,
                                  e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void closeTab(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var r = tabControl1.GetTabRect(i);
                var closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (
                        MessageBox.Show(Resources.Form1_tabControl1_MouseDown_Would_you_like_to_Close_this_Tab_,
                                        Resources.Form1_tabControl1_MouseDown_Confirm, MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tabControl1.TabPages[i].Dispose();
                        break;
                    }
                }
            }
        }

        private void save(object sender, EventArgs e)
        {

            var selectedRtb =
                (FastColoredTextBoxNS.FastColoredTextBox) tabControl1.SelectedTab.Controls["textbox"];

            using (var SaveDialoge = new SaveFileDialog())
            {
                SaveDialoge.ShowDialog();

                File.WriteAllText(SaveDialoge.FileName, selectedRtb.Text);

                tabControl1.SelectedTab.Text = SaveDialoge.FileName;
            }
        }

        private void saveMenu(object sender, EventArgs e)
        {
            saveFile.PerformClick();
        }

        private void openMenu(object sender, EventArgs e)
        {
            openFile.PerformClick();
        }

        private void openSettings(object sender, EventArgs e)
        {
            var Settings = new Settings();

            Settings.ShowDialog();
        }

        private void openAbout(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

        private void exit(object sender, EventArgs e)
        {
            Close();
        }

        private void runItem(object sender, EventArgs e)
        {
            var run = new Run();
            run.Show();
        }

        private void loadOnlineData(object sender, EventArgs e)
        {
            string url = Microsoft.VisualBasic.Interaction.InputBox("Enter URL", "Online Data Loader");
            var request = (HttpWebRequest) WebRequest.Create(url);
            var response = (HttpWebResponse) request.GetResponse();
            var resStream = response.GetResponseStream();
            int count;
            var buf = new byte[2048];
            var sb = new StringBuilder("");

            do
            {
                Debug.Assert(resStream != null, "resStream != null");
                count = resStream.Read(buf, 0, buf.Length);

                if (count != 0)
                {
                    string tempString = Encoding.ASCII.GetString(buf, 0, count);
                    sb.Append(tempString);
                }
            } while (count > 0);

            var selectedRtb = (FastColoredTextBoxNS.FastColoredTextBox) tabControl1.SelectedTab.Controls["textbox"];
            selectedRtb.Text = sb.ToString();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Parallel.Invoke(() => { 
            if (tabControl1.SelectedTab.Controls.ContainsKey("HOR"))
            {
                var hor = (SplitContainer)tabControl1.SelectedTab.Controls["HOR"];
                var _text = (ConsoleControl.ConsoleControl)hor.Panel2.Controls["CON"];

                _text.StopProcess();

                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    tabControl1.Controls.Add(new Texttab());
            }
            else
            {

                tabControl1.SelectedTab.Controls.Clear();
                
                var hor = new SplitContainer();
                var con = new ConsoleControl.ConsoleControl();
                con.StopProcess();
                var _text = new CustomText(mySettings);

                hor.Orientation = Orientation.Horizontal;
                hor.SplitterDistance = 100;
                con.Font = new Font(FontFamily.GenericMonospace, 10.00f);

                hor.Name = "HOR";
                con.Name = "CON";
                hor.Dock = DockStyle.Fill;
                con.Dock = DockStyle.Fill;

                tabControl1.SelectedTab.Controls.Add(hor);
                hor.Panel1.Controls.Add(_text);
                hor.Panel2.Controls.Add(con);

                con.StartProcess("cmd", "");
            }
            });
        }

    }
}
