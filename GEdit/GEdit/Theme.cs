using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using GEdit.Properties;

namespace GEDITER
{
    public partial class Theme : Form
    {
        public Theme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ColorPick = new ColorDialog();

            ColorPick.ShowDialog();

            pictureBox1.BackColor = ColorPick.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ColorPick = new ColorDialog();

            ColorPick.ShowDialog();

            pictureBox2.BackColor = ColorPick.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var FontName = new FontDialog();

            FontName.ShowDialog();

            label2.Text = FontName.Font.Size.ToString(CultureInfo.InvariantCulture);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveTheme("settings.xml");
        }

        private void LoadTheme(string file)
        {
            if (File.Exists(@file))
            {
                var mySerializer = new XmlSerializer(typeof(settings));

                var myFileStream = new FileStream(file, FileMode.Open);

                var myObject = (settings)mySerializer.Deserialize(myFileStream);

                pictureBox1.BackColor = Color.FromArgb(myObject.R1, myObject.G1, myObject.B1);
                pictureBox2.BackColor = Color.FromArgb(myObject.R2, myObject.G2, myObject.B2);
                pictureBox3.BackColor = Color.FromArgb(myObject.R3, myObject.G3, myObject.B3);
                //label1.Text = myObject.FontName;
                label2.Text = myObject.FontSize;

                myFileStream.Close();
            }
        }

        private void SaveTheme(string file)
        {
            var SSettings = new settings
            {
                //Foreground
                R1 = pictureBox1.BackColor.R,
                G1 = pictureBox1.BackColor.G,
                B1 = pictureBox1.BackColor.B,
                //Background
                R2 = pictureBox2.BackColor.R,
                G2 = pictureBox2.BackColor.G,
                B2 = pictureBox2.BackColor.B,
                //Line Highlight
                R3 = pictureBox3.BackColor.R,
                G3 = pictureBox3.BackColor.G,
                B3 = pictureBox3.BackColor.B,
                
                //FontName = label1.Text,
                FontSize = label2.Text
            };
            var x = new XmlSerializer(SSettings.GetType());

            var filez = new StreamWriter(@file);

            x.Serialize(filez, SSettings);


            filez.Close();    
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadTheme("settings.xml");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var ColorPick = new ColorDialog();

            ColorPick.ShowDialog();

            pictureBox3.BackColor = ColorPick.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var of = new OpenFileDialog();
                of.ShowDialog();
                LoadTheme(of.FileName);
                SaveTheme("settings.xml");
            }
            catch
            {
                MessageBox.Show(Resources.Settings_button3_Click_Error_loading_file_);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var op = new OpenFileDialog();
                op.ShowDialog();
                var file = op.FileName;

                File.Copy(file, Directory.GetCurrentDirectory() + "\\Themes\\" + Path.GetFileName(op.FileName));
            }
            catch
            {
                MessageBox.Show(Resources.Theme_button7_Click_Error_);
            }
        }
    }
}

public class settings
    {
        public int R1 = 0;
        public int G1 = 0;
        public int B1 = 0;
        public int R2 = 0;
        public int G2 = 0;
        public int B2 = 0;
        public int R3 = 0;
        public int G3 = 0;
        public int B3 = 0;
        //public string FontName = "";
        public string FontSize = "0";
    }