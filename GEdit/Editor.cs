using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GEdit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GEdit
{
    public partial class Editor : MaterialForm
    {
        userSettings mySettings = new userSettings();

        public userSettings LoadSettings()
        {
            if (File.Exists("settings.json"))
            {
                using (StreamReader file = File.OpenText(@"settings.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    mySettings = (userSettings)serializer.Deserialize(file, typeof(userSettings));
                }
            }

            return mySettings;
        }

        public Editor()
        {
            InitializeComponent();
            LoadSettings();
            var skinmanager = MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkinManager.Themes.DARK;
            skinmanager.ColorScheme = new ColorScheme(mySettings.Primary, mySettings.Primary, mySettings.Primary, mySettings.Accent, MaterialSkin.TextShade.WHITE);
            
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            var root = new FolderFileNode(path);
            treeView1.Nodes.Add(root);
            root.LoadNodes();

            treeView1.BeforeSelect += (sender, args) =>
            {
                (args.Node as FolderFileNode)?.LoadNodes();
            };

            treeView1.AfterExpand += (sender, args) =>
            {
                (args.Node as FolderFileNode)?.SetIcon();
            };

            treeView1.AfterCollapse += (sender, args) =>
            {
                (args.Node as FolderFileNode)?.SetIcon();
            };
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Parallel.Invoke(() => {
                ListDirectory(treeView1, path);
            });
        }

        private void materialTabSelector1_DoubleClick(object sender, EventArgs e)
        {
            if (materialTabControl1.TabCount != 1)
            {
                materialTabControl1.TabPages.RemoveAt(materialTabControl1.SelectedIndex);

            }
        }

        private void materialTabControl1_KeyDown_1(object sender, KeyEventArgs e)
        {
            SplitContainer HOR = (SplitContainer)materialTabControl1.SelectedTab.Controls["HOR"];
            var selectedRtb = HOR.Panel1.Controls["textbox"];
            var con = (ConsoleControl.ConsoleControl)HOR.Panel2.Controls["CON"];
            CustomTab tab = (CustomTab)materialTabControl1.SelectedTab;

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.T)
            {
                if (materialTabControl1.TabCount <= 10)
                {
                    materialTabControl1.TabPages.Add(new CustomTab());
                }
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                MessageBox.Show("Shortcuts:\nNew Tab\tCTRL+T\nSave\tCTRL+S\nOpen\tCTRL+O\nConsole\tCTRL+K\nSettings\tCTRL+L");
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.L)
            {
                Settings set = new Settings();
                set.Show();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.P)
            {
                if (splitContainer1.Panel1Collapsed)
                {
                    splitContainer1.Panel1Collapsed = false;
                }
                else
                {
                    splitContainer1.Panel1Collapsed = true;
                }
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                var oldIndex = materialTabControl1.SelectedIndex;
                if (oldIndex != 0)
                {
                    materialTabControl1.TabPages.Remove(materialTabControl1.SelectedTab);
                    materialTabControl1.SelectedIndex = oldIndex - 1;
                }
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                saveFileDialog1.ShowDialog();
                try
                {
                    if (tab.fileName == "")
                    {
                        Parallel.Invoke(() => File.WriteAllText(saveFileDialog1.FileName, selectedRtb.Text));
                        tab.fileName = saveFileDialog1.FileName;
                    }
                    else
                    {
                        File.WriteAllText(saveFileDialog1.FileName, selectedRtb.Text, Encoding.UTF8);
                    }
                }
                catch { }
            }

            if (materialTabControl1.SelectedIndex < materialTabControl1.TabPages.Count - 1)
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Right)
                {
                    materialTabControl1.SelectedTab = materialTabControl1.TabPages[materialTabControl1.SelectedIndex + 1];
                }
            }
            if (materialTabControl1.SelectedIndex > 0)
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Left)
                {
                    materialTabControl1.SelectedTab = materialTabControl1.TabPages[materialTabControl1.SelectedIndex - 1];
                }
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
            {
                openFileDialog1.ShowDialog();
                try
                {
                    selectedRtb.Text = File.ReadAllText(openFileDialog1.FileName);
                    tab.fileName = openFileDialog1.FileName;
                    var attr = Path.GetFileName(openFileDialog1.FileName);
                    tab.Text = attr;
                    materialTabSelector1.Refresh();
                }
                catch { }
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.K)
            {
                if (HOR.Panel2Collapsed)
                {
                    HOR.Panel2Collapsed = false;
                    if (con.IsProcessRunning == false)
                    {
                        con.StartProcess("cmd", "");
                    }
                }
                else
                {
                    HOR.Panel2Collapsed = true;
                }
            }
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            try
            {
                Parallel.Invoke(() =>
                {
                    CustomTab tab = (CustomTab)materialTabControl1.SelectedTab;
                    SplitContainer HOR = (SplitContainer)materialTabControl1.SelectedTab.Controls["HOR"];
                    var selectedRtb = HOR.Panel1.Controls["textbox"];
                    selectedRtb.Text = File.ReadAllText(((FolderFileNode)treeView1.SelectedNode)._path);
                });
            }
            catch { }
        }
    }
}
    
    public class FolderFileNode: TreeNode
    {
    public readonly string _path;

    public readonly bool _isFile;

    public FolderFileNode(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException(nameof(path));
        Text = Path.GetFileName(path);
        _isFile = File.Exists(path);
        _path = path;
        SetIcon();
    }

    public void SetIcon()
    {
        // image[2] is Folder Open image
        ImageIndex = _isFile ? ImageIndex = 1 : IsExpanded ? 2 : 0;
        SelectedImageIndex = _isFile ? ImageIndex = 1 : IsExpanded ? 2 : 0;
    }

    private IEnumerable<string> _children;
    public void LoadNodes()
    {
        if (!_isFile && _children == null)
        {
            _children = Directory.EnumerateFileSystemEntries(_path);
            Nodes.AddRange(
                _children.Select(x =>
                    // co-variant
                    (TreeNode)new FolderFileNode(x))
                    .ToArray());
        }
    }
}

    public class CustomTab: TabPage
    {
    public static userSettings LoadSettings(Boolean x)
    {
        userSettings mySettings = new userSettings();
        if (File.Exists("settings.json"))
        {
            using (StreamReader file = File.OpenText(@"settings.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                mySettings = (userSettings)serializer.Deserialize(file, typeof(userSettings));
            }
        }

        return mySettings;
    }

        public String fileName = "";
        public userSettings settings = LoadSettings(true);

        public CustomTab()
        {
        this.Text = "New Tab";
        var hor = new SplitContainerX();
        var con = new ConsoleControl.ConsoleControl();
        con.StopProcess();
        var _text = new CustomText(settings);

        
        con.Name = "CON";
        
        con.Dock = DockStyle.Fill;
        con.BackColor = ((int)settings.Primary).ToColor();
        con.BorderStyle = BorderStyle.None;
        con.Padding = new Padding(0);
        con.Margin = new Padding(0);
        con.InternalRichTextBox.BorderStyle = BorderStyle.None;
        this.Controls.Add(hor);
        hor.Panel1.Controls.Add(_text);
        
        hor.Panel2.Controls.Add(con);
        hor.Panel2Collapsed = true;
    }
    }

