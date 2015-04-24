using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GEDITER
{
    public partial class Settings : Form
    {
        public Settings()
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

        private void button3_Click(object sender, EventArgs e)
        {
            var FontName = new FontDialog();

            FontName.ShowDialog();

            label1.Text = FontName.Font.FontFamily.Name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var FontName = new FontDialog();

            FontName.ShowDialog();

            label2.Text = FontName.Font.Size.ToString(CultureInfo.InvariantCulture);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var SSettings = new settings
                {
                    R1 = pictureBox1.BackColor.R,
                    G1 = pictureBox1.BackColor.G,
                    B1 = pictureBox1.BackColor.B,
                    R2 = pictureBox2.BackColor.R,
                    G2 = pictureBox2.BackColor.G,
                    B2 = pictureBox2.BackColor.B,
                    FontName = label1.Text,
                    FontSize = label2.Text
                };
            var x = new XmlSerializer(SSettings.GetType());

            var file = new StreamWriter(@"settings.xml");

            x.Serialize(file, SSettings);

            
            file.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"settings.xml"))
            {
                var mySerializer = new XmlSerializer(typeof(settings));

                var myFileStream = new FileStream("settings.xml", FileMode.Open);

                var myObject = (settings)mySerializer.Deserialize(myFileStream);

                pictureBox1.BackColor = Color.FromArgb(myObject.R1, myObject.G1, myObject.B1);
                pictureBox2.BackColor = Color.FromArgb(myObject.R2, myObject.G2, myObject.B2);
                label1.Text = myObject.FontName;
                label2.Text = myObject.FontSize;

                myFileStream.Close();
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
        public string FontName = "";
        public string FontSize = "0";
    }