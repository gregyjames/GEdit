using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEdit
{
    public partial class Run : Form
    {
        public Run()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sf = new OpenFileDialog();
            sf.ShowDialog();
            textBox1.Text = sf.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var command = textBox1.Text + " " + textBox2.Text;
            //System.Diagnostics.Process.Start("CMD.exe", command);

            string YourApplicationPath = textBox1.Text;  
            var processInfo = new ProcessStartInfo();
            processInfo.FileName = YourApplicationPath;
            processInfo.WorkingDirectory = textBox3.Text;
            processInfo.Arguments = textBox2.Text;
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;
            using (Process process = Process.Start(processInfo))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    richTextBox1.Text = result;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var form = new Editer();
            //var file = (TabControl)form.Controls["tabcontrol1"];
            var ex = Application.OpenForms["Editer"];
            var yx = (TabControl) ex.Controls["TabControl1"];
            //MessageBox.Show(yx.SelectedTab.Text);
            textBox2.Text += " " + yx.SelectedTab.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dir = new FolderBrowserDialog();
            dir.ShowDialog();
            textBox3.Text = dir.SelectedPath;
        }
    }
}
